import logging

from fastapi import APIRouter, HTTPException, Query, status

from legacy_adapter import get_seguridad_legacy, is_legacy_source_enabled, list_seguridad_legacy

logger = logging.getLogger(__name__)
router = APIRouter(prefix="/seguridad", tags=["Seguridad"])


@router.get("", response_model=dict)
def list_seguridad(
    skip: int = 0,
    limit: int = 100,
    service: str | None = Query(default=None),
):
    """Query security metadata/status from the legacy SIGECOM backend."""
    if is_legacy_source_enabled():
        try:
            data = list_seguridad_legacy(skip=skip, limit=limit, service=service)
            if isinstance(data, dict):
                return data
            if isinstance(data, list):
                return {"items": data, "total": len(data)}
            raise HTTPException(status_code=status.HTTP_503_SERVICE_UNAVAILABLE, detail="Legacy adapter returned an unexpected payload")
        except Exception as exc:
            logger.exception("Failed to fetch security metadata from legacy adapter")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"Legacy adapter unavailable: {type(exc).__name__}. Confirm the original SIGECOM adapter is listening.",
            ) from exc

    return {"items": [], "total": 0, "message": "Seguridad not implemented in local fallback mode."}


@router.get("/health", response_model=dict)
def seguridad_health():
    """Return the health/status of the security layer."""
    if is_legacy_source_enabled():
        try:
            return get_seguridad_legacy(service="health")
        except Exception as exc:
            logger.exception("Security health probe failed against legacy adapter")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"Legacy adapter unavailable: {type(exc).__name__}. Confirm the original SIGECOM adapter is listening.",
            ) from exc

    return {"status": "ok", "source": "local-fallback", "message": "Security local fallback is not connected to SIGECOM."}
