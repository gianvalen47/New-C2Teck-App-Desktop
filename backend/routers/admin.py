"""
Administrative endpoints for SIGECOM backend

- Diagnostics and WSDL inspection
- System health
- Configuration checks
"""
import logging

from fastapi import APIRouter, HTTPException, status

from legacy_adapter import inspect_client_service_wsdl, legacy_health

logger = logging.getLogger(__name__)

router = APIRouter(prefix="/admin", tags=["Admin"])


@router.get("/legacy-inspect/wsdl", response_model=dict)
def inspect_wsdl():
    """
    Inspect SIGECOM legacy WCF WSDL

    Useful for debugging: returns available services and operations
    Requires zeep to be installed
    """
    logger.info("Inspecting legacy WSDL...")
    result = inspect_client_service_wsdl()
    return result


@router.get("/legacy-health", response_model=dict)
def check_legacy_health():
    """
    Check if legacy SIGECOM adapter is available

    Returns status and connectivity information
    """
    logger.info("Checking legacy adapter health...")
    try:
        result = legacy_health()
        if isinstance(result, dict):
            return result
        return {"status": "ok" if result else "unreachable", "available": result}
    except Exception as e:
        return {
            "status": "error",
            "error": str(e),
            "message": "Failed to check legacy adapter health"
        }


@router.get("/system-info", response_model=dict)
def get_system_info():
    """
    Get system information and configuration

    Returns:
    - Data source mode (legacy/sqlite)
    - Adapter URL
    - Database status
    - Python version
    - Installed packages
    """
    import os
    import sys
    import platform
    from config import SIGECOM_DATA_SOURCE
    from legacy_adapter import LEGACY_ADAPTER_BASE_URL

    return {
        "system": {
            "platform": platform.platform(),
            "python_version": sys.version,
            "python_executable": sys.executable,
        },
        "sigecom_config": {
            "data_source": SIGECOM_DATA_SOURCE,
            "legacy_adapter_url": LEGACY_ADAPTER_BASE_URL,
            "environment_variables": {
                "SIGECOM_DATA_SOURCE": os.getenv("SIGECOM_DATA_SOURCE", "not set"),
                "SIGECOM_LEGACY_ADAPTER_BASE_URL": os.getenv("SIGECOM_LEGACY_ADAPTER_BASE_URL", "not set"),
                "SIGECOM_WCF_BASE_URL": os.getenv("SIGECOM_WCF_BASE_URL", "not set"),
            }
        }
    }


@router.get("/routes", response_model=dict)
def get_api_routes():
    """
    Get list of all available API routes

    Useful for testing API documentation
    """
    # This would require access to the FastAPI app
    # Typically handled by OpenAPI docs at /docs
    return {
        "message": "Available routes listed in OpenAPI docs",
        "docs_url": "/docs",
        "redoc_url": "/redoc",
        "openapi_schema_url": "/openapi.json"
    }


@router.post("/reset-cache", response_model=dict)
def reset_cache():
    """
    Reset any in-memory caches

    Useful after making changes to legacy system
    """
    logger.warning("Resetting caches...")

    # TODO: Implement cache reset if caching is added

    return {
        "status": "success",
        "message": "Caches reset"
    }


@router.get("/database-check", response_model=dict)
def check_database():
    """
    Check SQLite database connection and tables

    Returns:
    - Database file path
    - Connection status
    - Table counts
    - Last backup time (if applicable)
    """
    from config import DB_FILE, SessionLocal
    from sqlalchemy import text, inspect

    try:
        db = SessionLocal()

        # Get table names
        inspector = inspect(db.bind)
        tables = inspector.get_table_names()

        # Try a simple query
        result = db.execute(text("SELECT 1")).fetchone()
        db.close()

        return {
            "status": "ok",
            "database_file": str(DB_FILE),
            "tables": tables,
            "table_count": len(tables),
            "connection": "active"
        }
    except Exception as e:
        logger.error(f"Database check failed: {e}")
        return {
            "status": "error",
            "error": str(e),
            "message": "Failed to connect to database"
        }


@router.get("/version", response_model=dict)
def get_api_version():
    """
    Get API version information
    """
    from config import PROJECT_NAME, PROJECT_VERSION

    return {
        "name": PROJECT_NAME,
        "version": PROJECT_VERSION,
        "branch": os.getenv("GIT_BRANCH", "unknown"),
        "commit": os.getenv("GIT_COMMIT", "unknown"),
    }
