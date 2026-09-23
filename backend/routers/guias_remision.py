"""
API router for Guías de Remisión (Delivery Notes)

Consumes from legacy SIGECOM adapter when enabled, otherwise uses local SQLite.
Extraído de SIGECOM VB.NET:
  - frmGuiaRemision.vb          → cabecera (CRUD)
  - frmGuiaRemision_AgregarDetalle.vb → ítems (CRUD)
  - frmGuiasRemision.vb         → listado con filtros
  - frmGuiaRemision_Transportista.vb → transportista

Servicios WCF equivalentes:
  GuiaRemisionService    → /guias-remision
  GuiaRemisionDetService → /guias-remision/{id}/detalles
  TransportistaService   → /guias-remision/{id}/transportista
"""
import logging
from datetime import datetime
from typing import List, Optional

import os
from fastapi import APIRouter, Depends, HTTPException, Query, status, Header
from fastapi.responses import JSONResponse
from sqlalchemy.orm import Session
from sqlalchemy import or_

from config import SessionLocal, SIGECOM_DATA_SOURCE
from legacy_adapter import (
    get_guia_legacy,
    is_legacy_source_enabled,
    list_guias_legacy,
    parse_guia_lookup_id,
)
from models import ClientModel, GuiaRemisionModel, GuiaRemisionDetModel, TransportistaGuiaModel
from schemas import (
    GuiaRemisionCreate,
    GuiaRemisionUpdate,
    GuiaRemisionRead,
    GuiaRemisionListRead,
    GuiaRemisionDetCreate,
    GuiaRemisionDetUpdate,
    GuiaRemisionDetRead,
    TransportistaCreate,
    TransportistaRead,
)

logger = logging.getLogger(__name__)

router = APIRouter(prefix="/guias-remision", tags=["Guías de Remisión"])


def _company_matches(row: dict, company_code: Optional[str]) -> bool:
    """Filter row-level data to the active empresa when company metadata exists."""
    if not company_code or not isinstance(row, dict):
        return True
    found = False
    for key in ("CodEmp", "cod_emp", "CodEmpresa", "cod_empresa", "Empresa", "empresa"):
        if key in row:
            found = True
            value = row.get(key)
            if value is not None:
                return str(value).strip() == str(company_code).strip()
    # If the row lacks company metadata, do NOT include it when a company_code is specified.
    return not bool(company_code) if not found else False


def _company_to_locaciones(company_code: Optional[str]) -> List[int]:
    """Map SIGECOM company codes to the specific legacy `id_locacion` values.

    This is needed because the guías dataset does not carry `cod_emp` per row.
    The known mapping for the active project is:
    - 08 -> 87 (C2TECK)
    - 05 -> 72
    """
    if not company_code:
        return []

    normalized = str(company_code).strip()
    mapping = {
        "08": [87],
        "8": [87],
        "05": [72],
        "5": [72],
        "02": [30],
        "2": [30],
        "07": [81],
        "7": [81],
        "30": [30],
        "31": [31],
        "72": [72],
        "73": [73],
        "75": [75],
        "80": [80],
        "81": [81],
        "83": [83],
        "87": [87],
    }
    return mapping.get(normalized, [])


def _filter_active_company(items: List[dict], company_code: Optional[str]) -> List[dict]:
    """Filter items by active company code.

    `company_code` is expected to come from a request header `X-Sigecoom-CodEmp`
    (preferred) or fall back to `SIGECOM_COD_EMP` when the header is not present.

    IMPORTANT: unknown company codes must not collapse the dataset to empty. When
    the legacy mapping does not know this company, we must preserve rows unless the
    payload itself contains an explicit company match that disagrees.
    """
    if not company_code:
        company_code = os.getenv("SIGECOM_COD_EMP", "08").strip() or None
    if not company_code:
        return items

    env_default = (os.getenv("SIGECOM_COD_EMP", "08") or "08").strip()
    locaciones = _company_to_locaciones(company_code)
    allow_missing_metadata = str(company_code).strip() == env_default

    def matches(item: dict) -> bool:
        if not isinstance(item, dict):
            return False

        # If an explicit company code exists in the payload, trust it over the
        # legacy location fallback. This keeps filters precise for real rows.
        for key in ("CodEmp", "cod_emp", "CodEmpresa", "cod_empresa", "Empresa", "empresa"):
            if key in item:
                value = item.get(key)
                if value is None:
                    return False
                return str(value).strip() == str(company_code).strip()

        # Prefer the legacy `id_locacion` field when a known mapping exists.
        for key in ("id_locacion", "IdLocacion"):
            if key in item and item.get(key) is not None:
                try:
                    val = int(str(item.get(key)).strip())
                    if locaciones:
                        return val in locaciones
                    return True
                except Exception:
                    pass

        # Unknown company codes are a valid state; if we cannot map the company to
        # a legacy location, do not empty the result set just because the code is
        # new or not in the old compatibility table.
        return allow_missing_metadata or not locaciones

    return [item for item in items if matches(item)]


# ---------------------------------------------------------------------------
# Dependency
# ---------------------------------------------------------------------------

def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


# ---------------------------------------------------------------------------
# Helpers
# ---------------------------------------------------------------------------

def _recalculate_totals(db: Session, id_guia: int) -> None:
    """Recalculate header totals from detail lines."""
    guia = db.query(GuiaRemisionModel).filter(GuiaRemisionModel.id == id_guia).first()
    if not guia:
        return
    detalles = db.query(GuiaRemisionDetModel).filter(GuiaRemisionDetModel.id_guia == id_guia).all()

    tot_bruto = sum((d.can_mer * d.pre_mer) for d in detalles)
    tot_dscto = sum((d.can_mer * d.dsc_mer) for d in detalles)
    tot_venta = tot_bruto - tot_dscto + guia.tot_flete + guia.tot_embarque
    tot_igv   = round(tot_venta * (guia.igv / 100), 2)
    tot_neto  = tot_venta + tot_igv

    # Recalculate each line total
    for d in detalles:
        d.total_fila = round(d.can_mer * d.pre_mer - d.can_mer * d.dsc_mer, 4)

    guia.tot_bruto = round(tot_bruto, 4)
    guia.tot_dscto = round(tot_dscto, 4)
    guia.tot_venta = round(tot_venta, 4)
    guia.tot_igv   = tot_igv
    guia.tot_neto  = round(tot_neto, 4)
    db.commit()


def _estado_sunat(estado: str) -> str:
    estado = (estado or "").upper()
    if estado == "ANULADO":
        return "BAJA"
    if estado == "APROBADO":
        return "ACEPTADO"
    if estado == "CREDITOS":
        return "CREDITOS"
    if estado == "GENERADO":
        return "PENDIENTE"
    return estado or "PENDIENTE"


def _build_list_row(guia: GuiaRemisionModel, db: Session) -> dict:
    client = db.query(ClientModel).filter(ClientModel.id == str(guia.id_cliente)).first()
    row = guia.__dict__.copy()
    row.pop("_sa_instance_state", None)
    row["cliente_nombre"] = client.name if client else None
    row["estado_sunat"] = _estado_sunat(guia.estado)
    row["tot_neto_sug"] = guia.tot_neto
    row["cod_serie"] = str(guia.id_serie_doc) if guia.id_serie_doc is not None else None
    return row


def _to_read(guia: GuiaRemisionModel, db: Session) -> GuiaRemisionRead:
    """Build a GuiaRemisionRead from the ORM model."""
    detalles = db.query(GuiaRemisionDetModel).filter(
        GuiaRemisionDetModel.id_guia == guia.id
    ).order_by(GuiaRemisionDetModel.item).all()

    transportista = db.query(TransportistaGuiaModel).filter(
        TransportistaGuiaModel.id_guia == guia.id
    ).first()

    data = guia.__dict__.copy()
    data.pop("_sa_instance_state", None)
    data["detalles"] = detalles
    data["transportista"] = transportista
    return GuiaRemisionRead.model_validate(data)


# ===========================================================================
# GUÍA DE REMISIÓN — CABECERA
# ===========================================================================

@router.get("", summary="Listar Guías de Remisión")
def list_guias(
    anio: Optional[int] = Query(None, description="Año del documento"),
    mes: Optional[int] = Query(None, ge=1, le=12, description="Mes (1–12)"),
    id_locacion: Optional[int] = Query(None, description="ID de la oficina/almacén"),
    id_serie_doc: Optional[int] = Query(None, description="ID de la serie del documento"),
    id_cliente: Optional[int] = Query(None, description="ID del cliente"),
    estado: Optional[str] = Query(None, description="Estado: GENERADO | APROBADO | CREDITOS | ANULADO"),
    num_doc: Optional[int] = Query(None, description="Número de documento"),
    skip: int = 0,
    limit: int = 100,
    db: Session = Depends(get_db),
    x_sigecoom_codemp: Optional[str] = Header(None, alias="X-Sigecoom-CodEmp"),
    x_sigecoom_empresas: Optional[str] = Header(None, alias="X-Sigecoom-Empresas"),
):
    """
    Listar Guías de Remisión: equivalente a `GuiaRemisionService.Filtrar(...)` en SIGECOM VB.NET.

    Cuando SIGECOM_DATA_SOURCE=legacy: consulta el adaptador HTTP SIGECOM original.
    Si el adaptador no responde: devuelve HTTP 503 (no fallback a SQLite en modo legacy).
    """
    # Build allowed company codes list from headers (used by legacy adapter branch too)
    allowed_codes = []
    if x_sigecoom_empresas:
        try:
            allowed_codes = [c.strip() for c in x_sigecoom_empresas.split(',') if c.strip()]
        except Exception:
            allowed_codes = []
    elif x_sigecoom_codemp:
        allowed_codes = [str(x_sigecoom_codemp).strip()]

    if is_legacy_source_enabled():
        try:
            data = list_guias_legacy(
                anio=anio,
                mes=mes,
                id_locacion=id_locacion,
                id_serie_doc=id_serie_doc,
                id_cliente=id_cliente,
                estado=estado,
                num_doc=num_doc,
                skip=skip,
                limit=limit,
                company_codes=allowed_codes or None,
            )
            # Normalize possible shapes from legacy adapter and keep only records
            # from the active SIGECOM company when that metadata is present.
            if isinstance(data, dict) and "items" in data:
                items = data["items"]
                total = data.get("total")
            elif isinstance(data, list):
                items = data
                total = len(items)
            else:
                items = [data] if data else []
                total = len(items)

            items = _filter_active_company(items, x_sigecoom_codemp)
            total = len(items) if total is None else min(total, len(items))

            # If the adapter provided a total different from returned page
            # we may need to compute the global total_amount (sum of tot_venta)
            total_amount = None
            try:
                if isinstance(data, dict) and data.get("total") and data.get("total") > len(items):
                    # need to fetch full set to compute total_amount
                    full = list_guias_legacy(
                        anio=anio,
                        mes=mes,
                        id_locacion=id_locacion,
                        id_serie_doc=id_serie_doc,
                        id_cliente=id_cliente,
                        estado=estado,
                        num_doc=num_doc,
                        skip=0,
                        limit=0,
                        company_codes=allowed_codes or None,
                    )
                    full_items = full.get("items") if isinstance(full, dict) else (full if isinstance(full, list) else [])
                    total_amount = sum(float(x.get("tot_venta") or x.get("tot_neto") or 0) for x in full_items)
                else:
                    # compute from returned items only
                    total_amount = sum(float(x.get("tot_venta") or x.get("tot_neto") or 0) for x in items)
            except Exception:
                total_amount = None

            return items
        except Exception as exc:
            logger.error(f"Failed to fetch guías from legacy adapter: {exc}")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"SIGECOM legacy adapter unavailable: {type(exc).__name__}. "
                       f"Start sigecoom-wcf-adapter.exe or check SIGECOM_LEGACY_ADAPTER_BASE_URL.",
            )

    # Fallback to local SQLite
    query = db.query(GuiaRemisionModel)
    if anio:
        query = query.filter(
            GuiaRemisionModel.fec_doc >= datetime(anio, 1, 1),
            GuiaRemisionModel.fec_doc < datetime(anio + 1, 1, 1),
        )
    if mes and anio:
        import calendar
        last_day = calendar.monthrange(anio, mes)[1]
        query = query.filter(
            GuiaRemisionModel.fec_doc >= datetime(anio, mes, 1),
            GuiaRemisionModel.fec_doc <= datetime(anio, mes, last_day, 23, 59, 59),
        )
    if id_locacion is not None:
        query = query.filter(GuiaRemisionModel.id_locacion == id_locacion)
    if id_serie_doc is not None:
        query = query.filter(GuiaRemisionModel.id_serie_doc == id_serie_doc)
    if id_cliente is not None:
        query = query.filter(GuiaRemisionModel.id_cliente == id_cliente)
    if estado:
        query = query.filter(GuiaRemisionModel.estado == estado.upper())
    if num_doc is not None:
        query = query.filter(GuiaRemisionModel.num_doc == num_doc)

    # Filter by the actual SIGECOM company-to-location mapping. The local SQLite
    # dataset does not carry a `cod_emp` field on each row, so the only reliable
    # discriminator is the legacy `id_locacion` value. In particular, company 08
    # maps to `id_locacion = 87` (C2TECK).
    if allowed_codes:
        locaciones = []
        for code in allowed_codes:
            locaciones.extend(_company_to_locaciones(code))

        if locaciones:
            query = query.filter(GuiaRemisionModel.id_locacion.in_(locaciones))
        else:
            env_default = (os.getenv("SIGECOM_COD_EMP", "08") or "08").strip()
            permit_missing = env_default in allowed_codes
            if permit_missing:
                query = query.filter(or_(GuiaRemisionModel.cod_emp == None, GuiaRemisionModel.cod_emp.in_(allowed_codes)))
            else:
                query = query.filter(GuiaRemisionModel.cod_emp.in_(allowed_codes))
    else:
        env_default = (os.getenv("SIGECOM_COD_EMP", "08") or "08").strip()
        locaciones = _company_to_locaciones(env_default)
        if locaciones:
            query = query.filter(GuiaRemisionModel.id_locacion.in_(locaciones))
        else:
            query = query.filter(or_(GuiaRemisionModel.cod_emp == None, GuiaRemisionModel.cod_emp == env_default))

    guias = query.order_by(GuiaRemisionModel.fec_doc.desc()).offset(skip).limit(limit).all()
    return [_build_list_row(guia, db) for guia in guias]


@router.get("/{id_guia}", summary="Obtener Guía de Remisión")
def get_guia(id_guia: str, db: Session = Depends(get_db)):
    """
    Equivalente a `GuiaRemisionService.MostrarPorId(IdGuia)`.
    Devuelve cabecera + detalles + transportista.

    El legado de SIGECOM usa IDs compuestos como "83-375-3". Necesitamos aceptar
    esos valores y resolverlos por localizacion + serie + documento cuando sea necesario.
    """
    if SIGECOM_DATA_SOURCE in {"legacy", "sigecoom", "adapter", "wcf", "original"}:
        try:
            return get_guia_legacy(id_guia)
        except Exception as exc:
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"No se pudo consultar SIGECOM legacy: {exc}",
            )

    lookup = parse_guia_lookup_id(id_guia)
    query = db.query(GuiaRemisionModel)

    if "id" in lookup:
        guia = query.filter(GuiaRemisionModel.id == lookup["id"]).first()
    elif "id_locacion" in lookup and "id_serie_doc" in lookup and "num_doc" in lookup:
        guia = query.filter(
            GuiaRemisionModel.id_locacion == lookup["id_locacion"],
            GuiaRemisionModel.id_serie_doc == lookup["id_serie_doc"],
            GuiaRemisionModel.num_doc == lookup["num_doc"],
        ).first()
    else:
        guia = None

    if not guia:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Guía no encontrada")
    return _to_read(guia, db)


@router.post("", response_model=GuiaRemisionRead, status_code=status.HTTP_201_CREATED,
             summary="Registrar nueva Guía de Remisión")
def create_guia(payload: GuiaRemisionCreate, db: Session = Depends(get_db)):
    """
    Equivalente a `GuiaRemisionService.Insertar(registro)`.

    Crea la cabecera y, si se proporcionan, las líneas de detalle.
    Los totales se calculan automáticamente.

    Campos del formulario SIGECOM → campo API:
    - Número          → num_doc
    - Fecha           → fec_doc
    - Moneda          → cod_mon  (NS=Soles, US=Dólares)
    - IGV             → igv  (porcentaje, ej. 18.0)
    - Tip.Cam.        → tip_cambio
    - Cliente         → id_cliente
    - Loc.Cliente     → id_loc_cli
    - Dir. Fiscal     → id_fiscal
    - # OT            → num_job
    - Cotización      → id_cotizacion
    - Partida         → pto_partida
    - Motivo          → cod_mot
    - Llegada         → pto_llegada
    - Vendedor        → (se asigna desde sesión)
    - O/C             → num_orden
    - Unid.Medida Peso→ cod_uni_med_peso  (KGM, TNE, ...)
    - Cant.Bultos     → numero_bultos
    - Modo Traslado   → cod_modo  (01=Público, 02=Privado)
    - Fecha Traslado  → fec_traslado
    - Flete           → tot_flete
    - Embarque        → tot_embarque
    - Observación     → observacion
    """
    # Duplicate check: same locacion + serie + num_doc
    existing = db.query(GuiaRemisionModel).filter(
        GuiaRemisionModel.id_locacion == payload.id_locacion,
        GuiaRemisionModel.id_serie_doc == payload.id_serie_doc,
        GuiaRemisionModel.num_doc == payload.num_doc,
    ).first()
    if existing:
        raise HTTPException(
            status_code=status.HTTP_409_CONFLICT,
            detail=f"El N° {payload.num_doc} de la guía ya existe para esta oficina/serie.",
        )

    guia_data = payload.model_dump(exclude={"detalles"})
    guia = GuiaRemisionModel(**guia_data, estado="GENERADO")
    db.add(guia)
    db.flush()  # get guia.id before inserting details

    for idx, det in enumerate(payload.detalles, start=1):
        det_data = det.model_dump()
        det_data.setdefault("item", idx)
        det_data["id_guia"] = guia.id
        det_data["total_fila"] = round(det.can_mer * det.pre_mer - det.can_mer * det.dsc_mer, 4)
        db.add(GuiaRemisionDetModel(**det_data))

    db.commit()
    _recalculate_totals(db, guia.id)
    db.refresh(guia)
    return _to_read(guia, db)


@router.put("/{id_guia}", response_model=GuiaRemisionRead, summary="Actualizar cabecera de Guía")
def update_guia(id_guia: int, payload: GuiaRemisionUpdate, db: Session = Depends(get_db)):
    """
    Equivalente a `GuiaRemisionService.Actualizar(registro)`.

    Solo se pueden modificar guías en estado GENERADO o APROBADO.
    """
    guia = db.query(GuiaRemisionModel).filter(GuiaRemisionModel.id == id_guia).first()
    if not guia:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Guía no encontrada")
    if guia.estado not in ("GENERADO", "APROBADO", "CREDITOS"):
        raise HTTPException(
            status_code=status.HTTP_422_UNPROCESSABLE_ENTITY,
            detail=f"La guía en estado '{guia.estado}' ya no se puede modificar.",
        )

    for field, value in payload.model_dump(exclude_none=True).items():
        setattr(guia, field, value)

    db.commit()
    _recalculate_totals(db, id_guia)
    db.refresh(guia)
    return _to_read(guia, db)


@router.delete("/{id_guia}", status_code=status.HTTP_204_NO_CONTENT,
               summary="Anular Guía de Remisión")
def delete_guia(id_guia: int, db: Session = Depends(get_db)):
    """
    Marca la guía como ANULADO (no se elimina físicamente).
    Solo permite anular guías en estado GENERADO o APROBADO.
    """
    guia = db.query(GuiaRemisionModel).filter(GuiaRemisionModel.id == id_guia).first()
    if not guia:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Guía no encontrada")
    if guia.estado not in ("GENERADO", "APROBADO"):
        raise HTTPException(
            status_code=status.HTTP_422_UNPROCESSABLE_ENTITY,
            detail=f"No se puede anular una guía en estado '{guia.estado}'.",
        )
    guia.estado = "ANULADO"
    db.commit()


# ===========================================================================
# GUÍA DE REMISIÓN — DETALLES (ÍTEMS)
# ===========================================================================


# ---------------------------------------------------------------------------
# Borrado físico (solo cuando el usuario lo solicita expresamente)
# ---------------------------------------------------------------------------
@router.delete("/{id_guia}/borrar", status_code=status.HTTP_204_NO_CONTENT,
               summary="Eliminar físicamente Guía de Remisión")
def delete_guia_force(id_guia: int, db: Session = Depends(get_db)):
    """
    Elimina físicamente la guía, sus detalles y datos asociados.
    Use con precaución: esto borra registros de la base de datos.
    """
    guia = db.query(GuiaRemisionModel).filter(GuiaRemisionModel.id == id_guia).first()
    if not guia:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Guía no encontrada")

    # Eliminar transportista si existe
    db.query(TransportistaGuiaModel).filter(TransportistaGuiaModel.id_guia == id_guia).delete()
    # Eliminar detalles
    db.query(GuiaRemisionDetModel).filter(GuiaRemisionDetModel.id_guia == id_guia).delete()
    # Eliminar la cabecera
    db.delete(guia)
    db.commit()

@router.get("/{id_guia}/detalles", response_model=List[GuiaRemisionDetRead],
            summary="Listar ítems de la guía")
def list_detalles(id_guia: int, db: Session = Depends(get_db)):
    """
    Equivalente a `GuiaRemisionDetService.Mostrar(IdGuia)`.
    """
    return db.query(GuiaRemisionDetModel).filter(
        GuiaRemisionDetModel.id_guia == id_guia
    ).order_by(GuiaRemisionDetModel.item).all()


@router.post("/{id_guia}/detalles", response_model=GuiaRemisionDetRead,
             status_code=status.HTTP_201_CREATED, summary="Agregar ítem a la guía")
def add_detalle(id_guia: int, payload: GuiaRemisionDetCreate, db: Session = Depends(get_db)):
    """
    Equivalente a `GuiaRemisionDetService.Insertar(registro)`.

    Campos del formulario SIGECOM → campo API:
    - Código Mer.   → cod_mer
    - Descripción   → des_mer
    - Und.Med.      → cod_uni_med
    - Cantidad      → can_mer
    - Precio        → pre_mer
    - Descuento     → dsc_mer
    - Ítem          → item
    - Regalo        → regalo
    - Sin Core      → no_core
    """
    guia = db.query(GuiaRemisionModel).filter(GuiaRemisionModel.id == id_guia).first()
    if not guia:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Guía no encontrada")
    if guia.estado not in ("GENERADO", "APROBADO"):
        raise HTTPException(
            status_code=status.HTTP_422_UNPROCESSABLE_ENTITY,
            detail="Solo se pueden agregar ítems a guías en estado GENERADO o APROBADO.",
        )

    det_data = payload.model_dump()
    det_data["id_guia"] = id_guia
    det_data["total_fila"] = round(payload.can_mer * payload.pre_mer - payload.can_mer * payload.dsc_mer, 4)
    det = GuiaRemisionDetModel(**det_data)
    db.add(det)
    db.commit()
    db.refresh(det)

    _recalculate_totals(db, id_guia)
    db.refresh(det)
    return det


@router.put("/{id_guia}/detalles/{id_det}", response_model=GuiaRemisionDetRead,
            summary="Actualizar ítem de la guía")
def update_detalle(id_guia: int, id_det: int, payload: GuiaRemisionDetUpdate,
                   db: Session = Depends(get_db)):
    """
    Equivalente a `GuiaRemisionDetService.Actualizar(registro)` y
    `GuiaRemisionDetService.ActualizarDescripcion(...)`.
    """
    det = db.query(GuiaRemisionDetModel).filter(
        GuiaRemisionDetModel.id == id_det,
        GuiaRemisionDetModel.id_guia == id_guia,
    ).first()
    if not det:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Detalle no encontrado")

    for field, value in payload.model_dump(exclude_none=True).items():
        setattr(det, field, value)

    det.total_fila = round(det.can_mer * det.pre_mer - det.can_mer * det.dsc_mer, 4)
    db.commit()
    _recalculate_totals(db, id_guia)
    db.refresh(det)
    return det


@router.delete("/{id_guia}/detalles/{id_det}", status_code=status.HTTP_204_NO_CONTENT,
               summary="Eliminar ítem de la guía")
def delete_detalle(id_guia: int, id_det: int, db: Session = Depends(get_db)):
    """
    Equivalente a `GuiaRemisionDetService.Borrar(IdGuiaDet, IdGuia)`.
    """
    guia = db.query(GuiaRemisionModel).filter(GuiaRemisionModel.id == id_guia).first()
    if not guia:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Guía no encontrada")
    if guia.estado not in ("GENERADO", "APROBADO"):
        raise HTTPException(
            status_code=status.HTTP_422_UNPROCESSABLE_ENTITY,
            detail="Solo se pueden eliminar ítems de guías en estado GENERADO o APROBADO.",
        )

    det = db.query(GuiaRemisionDetModel).filter(
        GuiaRemisionDetModel.id == id_det,
        GuiaRemisionDetModel.id_guia == id_guia,
    ).first()
    if not det:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Detalle no encontrado")

    db.delete(det)
    db.commit()
    _recalculate_totals(db, id_guia)


# ===========================================================================
# TRANSPORTISTA
# ===========================================================================

@router.get("/{id_guia}/transportista", response_model=TransportistaRead,
            summary="Ver datos del transportista")
def get_transportista(id_guia: int, db: Session = Depends(get_db)):
    """
    Equivalente a `TransportistaService.MostrarPorGuia(IdGuia)`.
    """
    t = db.query(TransportistaGuiaModel).filter(
        TransportistaGuiaModel.id_guia == id_guia
    ).first()
    if not t:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND,
                            detail="Transportista no registrado para esta guía")
    return t


@router.put("/{id_guia}/transportista", response_model=TransportistaRead,
            summary="Guardar/actualizar datos del transportista")
def upsert_transportista(id_guia: int, payload: TransportistaCreate,
                         db: Session = Depends(get_db)):
    """
    Equivalente a la acción del botón «Transportista» (`frmGuiaRemision_Transportista`).

    Crea o reemplaza los datos del transportista vinculado a la guía.

    Campos del formulario SIGECOM → campo API:
    - Empresa       → empresa
    - Dirección     → direccion
    - RUC           → ruc
    - Vehículo      → vehiculo
    - Placa         → placa
    - Chofer        → chofer
    - Licencia      → licencia
    - Tipo doc.     → cod_doc_chofer  (1=DNI, 4=Carné ext., 7=Pasaporte)
    - N° documento  → num_doc_chofer
    - Const.Inscr.  → con_ins
    """
    guia = db.query(GuiaRemisionModel).filter(GuiaRemisionModel.id == id_guia).first()
    if not guia:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Guía no encontrada")

    t = db.query(TransportistaGuiaModel).filter(
        TransportistaGuiaModel.id_guia == id_guia
    ).first()

    if t:
        for field, value in payload.model_dump(exclude_none=True).items():
            setattr(t, field, value)
    else:
        t = TransportistaGuiaModel(id_guia=id_guia, **payload.model_dump())
        db.add(t)

    db.commit()
    db.refresh(t)
    return t


# ===========================================================================
# ESTADO — Aprobar / Anular
# ===========================================================================

@router.patch("/{id_guia}/estado", response_model=GuiaRemisionListRead,
              summary="Cambiar estado de la guía")
def cambiar_estado(
    id_guia: int,
    nuevo_estado: str = Query(..., description="APROBADO | ANULADO | CREDITOS | GENERADO"),
    db: Session = Depends(get_db),
):
    """
    Equivalente a las transiciones de estado dentro de SIGECOM:
    GENERADO → APROBADO → CREDITOS / ANULADO
    """
    estados_validos = {"GENERADO", "APROBADO", "CREDITOS", "ANULADO"}
    if nuevo_estado.upper() not in estados_validos:
        raise HTTPException(
            status_code=status.HTTP_400_BAD_REQUEST,
            detail=f"Estado inválido. Válidos: {', '.join(estados_validos)}",
        )
    guia = db.query(GuiaRemisionModel).filter(GuiaRemisionModel.id == id_guia).first()
    if not guia:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Guía no encontrada")

    guia.estado = nuevo_estado.upper()
    db.commit()
    db.refresh(guia)
    return guia
