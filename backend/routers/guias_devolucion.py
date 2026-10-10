import logging
import os
from typing import List, Optional

from fastapi import APIRouter, HTTPException, Query, Header, status

from legacy_adapter import (
    is_legacy_source_enabled,
    list_guias_devolucion_legacy,
    get_guia_devolucion_legacy,
    _filter_active_company,
)

logger = logging.getLogger(__name__)
router = APIRouter(prefix="/guias-devolucion", tags=["Guías de Devolución"])


@router.get("", summary="Listar Guías de Devolución")
def list_guias_devolucion(
    anio: Optional[int] = Query(None, description="Año del documento"),
    mes: Optional[int] = Query(None, ge=1, le=12, description="Mes (1–12)"),
    id_locacion: Optional[int] = Query(None, description="ID de la oficina/almacén"),
    id_cliente: Optional[int] = Query(None, description="ID del cliente"),
    estado: Optional[str] = Query(None, description="Estado: GN | AP | CR | AN | IM"),
    num_doc: Optional[int] = Query(None, description="Número de documento"),
    search: Optional[str] = Query(None, description="Búsqueda por texto"),
    skip: int = 0,
    limit: int = 100,
    x_sigecoom_codemp: Optional[str] = Header(None, alias="X-Sigecoom-CodEmp"),
    x_sigecoom_empresas: Optional[str] = Header(None, alias="X-Sigecoom-Empresas"),
):
    """
    Listar Guías de Devolución: equivalente a `GuiaDevolucionService.Filtrar(...)` en SIGECOM VB.NET.
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
            items = list_guias_devolucion_legacy(
                anio=anio,
                mes=mes,
                id_locacion=id_locacion,
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
            logger.error(f"Failed to fetch guias devolucion from legacy adapter: {exc}")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"SIGECOM legacy adapter unavailable: {type(exc).__name__}. "
                       f"Verifique que sigecoom-wcf-adapter.exe esté ejecutándose.",
            )

    return []


@router.get("/{guia_id}", summary="Obtener Guía de Devolución por ID")
def get_guia_devolucion(guia_id: str):
    """Fetch single guia de devolucion from legacy adapter."""
    if is_legacy_source_enabled():
        try:
            return get_guia_devolucion_legacy(guia_id)
        except Exception as exc:
            logger.exception("Failed to fetch guia devolucion %s from legacy adapter", guia_id)
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"Legacy adapter unavailable: {type(exc).__name__}",
            ) from exc

    raise HTTPException(status_code=status.HTTP_501_NOT_IMPLEMENTED, detail="Guia devolucion detail lookup is not available in local fallback mode.")
