"""
Router for Guías de Devolución — lightweight proxy to legacy adapter.

Endpoints:
- GET /api/v1/guias-devolucion            -> list
- GET /api/v1/guias-devolucion/{id}/detalles -> detalles

When SIGECOM_DATA_SOURCE=legacy the router will call the legacy adapter
(`SIGECOM_LEGACY_ADAPTER_BASE_URL`) and forward the JSON. When legacy is
disabled it returns an empty list (no invented data).
"""
from typing import List
import logging

from fastapi import APIRouter, HTTPException, Query

from legacy_adapter import build_legacy_url, _read_json, is_legacy_source_enabled

logger = logging.getLogger(__name__)

router = APIRouter(prefix="/guias-devolucion", tags=["Guías de Devolución"])


@router.get("", summary="Listar Guías de Devolución")
def list_guias_devolucion(
    anio: int | None = Query(None),
    mes: int | None = Query(None),
    id_locacion: int | None = Query(None),
    id_cliente: int | None = Query(None),
    estado: str | None = Query(None),
    num_doc: int | None = Query(None),
    skip: int = Query(0),
    limit: int = Query(200),
):
    if not is_legacy_source_enabled():
        # Do not invent data — return empty list when legacy source is not enabled
        return []

    params = []
    if anio is not None:
        params.append(("anio", str(anio)))
    if mes is not None:
        params.append(("mes", str(mes)))
    if id_locacion is not None:
        params.append(("id_locacion", str(id_locacion)))
    if id_cliente is not None:
        params.append(("id_cliente", str(id_cliente)))
    if estado:
        params.append(("estado", estado))
    if num_doc is not None:
        params.append(("num_doc", str(num_doc)))
    if skip:
        params.append(("skip", str(skip)))
    if limit:
        params.append(("limit", str(limit)))

    query = "&".join(f"{k}={v}" for k, v in params)
    endpoint = "/api/v1/guias-devolucion"
    if query:
        endpoint = f"{endpoint}?{query}"

    try:
        data = _read_json(build_legacy_url(endpoint))
        # return raw payload (legacy adapter normalizes format already)
        return data
    except Exception as exc:
        logger.error(f"Failed to fetch guías de devolución from legacy adapter: {exc}")
        raise HTTPException(status_code=503, detail="SIGECOM legacy adapter unavailable")


@router.get("/{id_guia}/detalles", summary="Listar detalles de guía")
def list_detalles(id_guia: int):
    if not is_legacy_source_enabled():
        return []

    endpoint = f"/api/v1/guias-devolucion/{id_guia}/detalles"
    try:
        data = _read_json(build_legacy_url(endpoint))
        return data
    except Exception as exc:
        logger.error(f"Failed to fetch detalles for guia {id_guia} from legacy adapter: {exc}")
        raise HTTPException(status_code=503, detail="SIGECOM legacy adapter unavailable")


@router.get("/{id_guia}", summary="Obtener cabecera de Guía de Devolución")
def get_guia(id_guia: int):
    if not is_legacy_source_enabled():
        raise HTTPException(status_code=404, detail="No disponible en modo sin legacy")

    endpoint = f"/api/v1/guias-devolucion/{id_guia}"
    try:
        data = _read_json(build_legacy_url(endpoint))
        return data
    except Exception as exc:
        logger.error(f"Failed to fetch guia {id_guia} from legacy adapter: {exc}")
        raise HTTPException(status_code=503, detail="SIGECOM legacy adapter unavailable")
