import logging

from fastapi import APIRouter, HTTPException, Query, status

from legacy_adapter import is_legacy_source_enabled, list_boletas_legacy, get_boleta_legacy

logger = logging.getLogger(__name__)
router = APIRouter(prefix="/boletas", tags=["Boletas"])


@router.get("", response_model=dict)
def list_boletas(
    skip: int = 0,
    limit: int = 100,
    estado: str | None = Query(default=None),
    serie: str | None = Query(default=None),
    numero: str | None = Query(default=None),
):
    """List boletas using the legacy SIGECOM adapter if enabled."""
    if is_legacy_source_enabled():
        try:
            data = list_boletas_legacy(skip=skip, limit=limit, estado=estado, serie=serie, numero=numero)
            if isinstance(data, dict):
                return data
            if isinstance(data, list):
                return {"items": data, "total": len(data)}
            raise HTTPException(status_code=status.HTTP_503_SERVICE_UNAVAILABLE, detail="Legacy adapter returned an unexpected payload")
        except Exception as exc:
            logger.exception("Failed to fetch boletas from legacy adapter")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"Legacy adapter unavailable: {type(exc).__name__}. Confirm the original SIGECOM adapter is listening.",
            ) from exc

    return {"items": [], "total": 0, "message": "Boletas not implemented in local fallback mode."}


@router.get("/{boleta_id}", response_model=dict)
def get_boleta(boleta_id: str):
    """Fetch a single boleta from the legacy SIGECOM adapter if enabled."""
    if is_legacy_source_enabled():
        try:
            return get_boleta_legacy(boleta_id)
        except Exception as exc:
            logger.exception("Failed to fetch boleta %s from legacy adapter", boleta_id)
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"Legacy adapter unavailable: {type(exc).__name__}. Confirm the original SIGECOM adapter is listening.",
            ) from exc

    raise HTTPException(status_code=status.HTTP_501_NOT_IMPLEMENTED, detail="Boleta detail lookup is not available in local fallback mode.")
