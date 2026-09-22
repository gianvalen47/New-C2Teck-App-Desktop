import logging

from fastapi import APIRouter, HTTPException, Query, status

from legacy_adapter import consultar_sunat_legacy, is_legacy_source_enabled, list_sunat_legacy

logger = logging.getLogger(__name__)
router = APIRouter(prefix="/sunat", tags=["SUNAT"])


@router.get("", response_model=dict)
def list_sunat(
    skip: int = 0,
    limit: int = 100,
    documento: str | None = Query(default=None),
    estado: str | None = Query(default=None),
):
    """List SUNAT-related operations from the legacy SIGECOM adapter."""
    if is_legacy_source_enabled():
        try:
            data = list_sunat_legacy(skip=skip, limit=limit, documento=documento, estado=estado)
            if isinstance(data, dict):
                return data
            if isinstance(data, list):
                return {"items": data, "total": len(data)}
            raise HTTPException(status_code=status.HTTP_503_SERVICE_UNAVAILABLE, detail="Legacy adapter returned an unexpected payload")
        except Exception as exc:
            logger.exception("Failed to fetch SUNAT entries from legacy adapter")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"Legacy adapter unavailable: {type(exc).__name__}. Confirm the original SIGECOM adapter is listening.",
            ) from exc

    return {"items": [], "total": 0, "message": "SUNAT query not implemented in local fallback mode."}


@router.get("/consultar", response_model=dict)
def consultar_sunat(documento: str | None = Query(default=None), estado: str | None = Query(default=None)):
    """Check a document status in the legacy SUNAT service."""
    if is_legacy_source_enabled():
        try:
            return consultar_sunat_legacy(documento=documento, estado=estado)
        except Exception as exc:
            logger.exception("Failed to consult SUNAT document status via legacy adapter")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"Legacy adapter unavailable: {type(exc).__name__}. Confirm the original SIGECOM adapter is listening.",
            ) from exc

    raise HTTPException(status_code=status.HTTP_501_NOT_IMPLEMENTED, detail="SUNAT consultation not implemented in local fallback mode.")
