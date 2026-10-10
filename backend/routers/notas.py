import logging
import os
from typing import List, Optional

from fastapi import APIRouter, HTTPException, Query, Header, status

from legacy_adapter import (
    is_legacy_source_enabled,
    list_notas_legacy,
    get_nota_legacy,
    _filter_active_company,
)

logger = logging.getLogger(__name__)
router = APIRouter(prefix="/notas", tags=["Notas de Crédito"])


@router.get("", summary="Listar Notas de Crédito")
def list_notas(
    anio: Optional[int] = Query(None, description="Año del documento"),
    mes: Optional[int] = Query(None, ge=1, le=12, description="Mes (1–12)"),
    id_locacion: Optional[int] = Query(None, description="ID de la oficina/almacén"),
    id_serie_doc: Optional[int] = Query(None, description="ID serie"),
    id_cliente: Optional[int] = Query(None, description="ID del cliente"),
    estado: Optional[str] = Query(None, description="Estado: GN | AP | CR | AN | IM"),
    num_doc: Optional[int] = Query(None, description="Número de documento"),
    search: Optional[str] = Query(None, description="Búsqueda por texto (número o cliente)"),
    skip: int = 0,
    limit: int = 100,
    x_sigecoom_codemp: Optional[str] = Header(None, alias="X-Sigecoom-CodEmp"),
    x_sigecoom_empresas: Optional[str] = Header(None, alias="X-Sigecoom-Empresas"),
):
    """
    Listar Notas de Crédito: equivalente a `NotaCreditoService.Filtrar(...)` en SIGECOM VB.NET.
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
            items = list_notas_legacy(
                anio=anio,
                mes=mes,
                id_locacion=id_locacion,
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
            logger.error(f"Failed to fetch notas from legacy adapter: {exc}")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"SIGECOM legacy adapter unavailable: {type(exc).__name__}. "
                       f"Verifique que sigecoom-wcf-adapter.exe esté ejecutándose.",
            )

    return []


@router.get("/{nota_id}", summary="Obtener Nota por ID")
def get_nota(nota_id: str):
    """Fetch single nota from legacy adapter."""
    if is_legacy_source_enabled():
        try:
            return get_nota_legacy(nota_id)
        except Exception as exc:
            logger.exception("Failed to fetch nota %s from legacy adapter", nota_id)
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"Legacy adapter unavailable: {type(exc).__name__}",
            ) from exc

    raise HTTPException(status_code=status.HTTP_501_NOT_IMPLEMENTED, detail="Nota detail lookup is not available in local fallback mode.")
