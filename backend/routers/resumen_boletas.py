import logging
import os
from typing import List, Optional

from fastapi import APIRouter, HTTPException, Query, Header, status

from legacy_adapter import (
    is_legacy_source_enabled,
    list_resumen_boletas_legacy,
    _filter_active_company,
)

logger = logging.getLogger(__name__)
router = APIRouter(prefix="/resumen-boletas", tags=["Resumen de Boletas"])


@router.get("", summary="Listar Resumen de Boletas")
def list_resumen_boletas(
    anio: Optional[int] = Query(None, description="Año"),
    mes: Optional[int] = Query(None, ge=1, le=12, description="Mes (1–12)"),
    id_resumen: Optional[str] = Query(None, description="Código de resumen"),
    search: Optional[str] = Query(None, description="Búsqueda por texto"),
    skip: int = 0,
    limit: int = 100,
    x_sigecoom_codemp: Optional[str] = Header(None, alias="X-Sigecoom-CodEmp"),
    x_sigecoom_empresas: Optional[str] = Header(None, alias="X-Sigecoom-Empresas"),
):
    """
    Listar Resumen de Boletas: equivalente a `ResumenBoletasDigitalService.Filtrar(...)`.
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
            items = list_resumen_boletas_legacy(
                anio=anio,
                mes=mes,
                id_resumen=id_resumen,
                search=search,
                skip=skip,
                limit=limit,
                company_codes=allowed_codes or None,
            )
            return items
        except Exception as exc:
            logger.error(f"Failed to fetch resumen boletas from legacy adapter: {exc}")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"SIGECOM legacy adapter unavailable: {type(exc).__name__}. "
                       f"Verifique que sigecoom-wcf-adapter.exe esté ejecutándose.",
            )

    return []
