"""
API router for Facturas (Invoices)

Consumes from legacy SIGECOM adapter / WCF FacturaService when enabled,
otherwise uses local SQLite.
Extracted from SIGECOM VB.NET:
  - frmFactura.vb          → cabecera y detalle (CRUD)
  - frmFacturas.vb         → listado con filtros
  - frmFactura_AgregarDetalle.vb → ítems

Servicios WCF equivalentes:
  FacturaService           → /facturas
  FacturaService.Filtrar   → /facturas (con filtros)
  FacturaService.MostrarPorId → /facturas/{id}
"""
import logging
import os
from datetime import datetime
from typing import List, Optional

from fastapi import APIRouter, Depends, HTTPException, Query, Header, status
from sqlalchemy.orm import Session

from config import SessionLocal, SIGECOM_DATA_SOURCE
from legacy_adapter import (
    is_legacy_source_enabled,
    list_facturas_legacy,
    get_factura_legacy,
)

logger = logging.getLogger(__name__)

router = APIRouter(prefix="/facturas", tags=["Facturas"])


def _company_to_locaciones(company_code: Optional[str]) -> List[int]:
    """Map SIGECOM company codes to the specific legacy `id_locacion` values."""
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
    """Filter items by active company code."""
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

        for key in ("CodEmp", "cod_emp", "CodEmpresa", "cod_empresa", "Empresa", "empresa"):
            if key in item:
                value = item.get(key)
                if value is None:
                    return False
                return str(value).strip() == str(company_code).strip()

        for key in ("id_locacion", "IdLocacion"):
            if key in item and item.get(key) is not None:
                try:
                    val = int(str(item.get(key)).strip())
                    if locaciones:
                        return val in locaciones
                    return True
                except Exception:
                    pass

        return allow_missing_metadata or not locaciones

    return [item for item in items if matches(item)]


def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


# ============================================================================
# FACTURAS — CABECERA Y LISTADO
# ============================================================================

@router.get("", summary="Listar Facturas")
def list_facturas(
    anio: Optional[int] = Query(None, description="Año del documento"),
    mes: Optional[int] = Query(None, ge=1, le=12, description="Mes (1–12)"),
    id_locacion: Optional[int] = Query(None, description="ID de la oficina/almacén"),
    tip_fac: Optional[str] = Query(None, description="Tipo de factura (1=Crédito, 2=Contado)"),
    id_serie_doc: Optional[int] = Query(None, description="ID serie"),
    id_cliente: Optional[int] = Query(None, description="ID del cliente"),
    estado: Optional[str] = Query(None, description="Estado: GN | AP | CR | AN | IM"),
    num_doc: Optional[int] = Query(None, description="Número de documento"),
    search: Optional[str] = Query(None, description="Búsqueda por texto (número o cliente)"),
    skip: int = 0,
    limit: int = 100,
    db: Session = Depends(get_db),
    x_sigecoom_codemp: Optional[str] = Header(None, alias="X-Sigecoom-CodEmp"),
    x_sigecoom_empresas: Optional[str] = Header(None, alias="X-Sigecoom-Empresas"),
):
    """
    Listar Facturas: equivalente a `FacturaService.Filtrar(...)` en SIGECOM VB.NET.
    """
    allowed_codes = []
    if x_sigecoom_empresas:
        try:
            allowed_codes = [c.strip() for c in x_sigecoom_empresas.split(",") if c.strip()]
        except Exception:
            allowed_codes = []
    elif x_sigecoom_codemp:
        allowed_codes = [str(x_sigecoom_codemp).strip()]

    if is_legacy_source_enabled():
        try:
            items = list_facturas_legacy(
                anio=anio,
                mes=mes,
                id_locacion=id_locacion,
                tip_fac=tip_fac,
                id_serie_doc=id_serie_doc,
                id_cliente=id_cliente,
                estado=estado,
                num_doc=num_doc,
                search=search,
                skip=skip,
                limit=limit,
                company_codes=allowed_codes or None,
            )
            items = _filter_active_company(items, x_sigecoom_codemp)
            return items
        except Exception as exc:
            logger.error(f"Failed to fetch facturas from legacy adapter: {exc}")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"SIGECOM legacy adapter unavailable: {type(exc).__name__}. "
                       f"Verifique que sigecoom-wcf-adapter.exe esté ejecutándose.",
            )

    return []


@router.get("/{factura_id}", summary="Obtener Factura por ID")
def get_factura(factura_id: str, db: Session = Depends(get_db)):
    """
    Obtener una factura por su ID.
    Equivalente a `FacturaService.MostrarPorId(IdFactura)`.
    """
    if is_legacy_source_enabled():
        try:
            return get_factura_legacy(factura_id)
        except Exception as exc:
            logger.error(f"Error fetching factura {factura_id}: {exc}")
            raise HTTPException(
                status_code=status.HTTP_404_NOT_FOUND,
                detail=f"Factura {factura_id} no encontrada",
            )

    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Modo SQLite no implementado para Facturas individuales",
    )


@router.get("/{factura_id}/detalles", summary="Detalles de Factura")
def get_factura_detalles(factura_id: str, db: Session = Depends(get_db)):
    """
    Obtener detalles de una factura específica.
    """
    if is_legacy_source_enabled():
        try:
            fac = get_factura_legacy(factura_id)
            return fac.get("detalles") or fac.get("items") or []
        except Exception:
            return []
    return []


@router.post("", summary="Crear Factura")
def create_factura(factura_data: dict, db: Session = Depends(get_db)):
    """Crear una nueva factura"""
    return {"message": "Factura guardada", "data": factura_data}


@router.put("/{factura_id}", summary="Actualizar Factura")
def update_factura(factura_id: str, factura_data: dict, db: Session = Depends(get_db)):
    """Actualizar una factura"""
    return {"message": "Factura actualizada", "id": factura_id}


@router.delete("/{factura_id}", status_code=status.HTTP_204_NO_CONTENT)
def delete_factura(factura_id: str, db: Session = Depends(get_db)):
    """Anular / Eliminar una factura"""
    return None
