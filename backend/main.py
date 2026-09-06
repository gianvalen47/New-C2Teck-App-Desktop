"""
SIGECOM Backend API - Main application

FastAPI server for SIGECOM (Migracion VB.NET to Python)
- Clients management
- Sales/Invoices (Facturas, Boletas, Guías)
- Inventory management
- User authentication (coming soon)
"""

import logging
from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from datetime import datetime

from config import CORS_ALLOW_ORIGIN_REGEX, CORS_ORIGINS, API_V1_STR, PROJECT_NAME, PROJECT_VERSION, Base, engine, SessionLocal, SIGECOM_DATA_SOURCE
from schemas import HealthCheck
from routers import clients, sales, inventory
from routers import auth
from routers.locations import router as locations_router
from routers.journals import router as journals_router
from routers.banking import router as banking_router
from routers.purchases import router as purchases_router
from routers.caja_chica import router as caja_chica_router
from routers.guias_remision import router as guias_remision_router
from routers.guias_devolucion import router as guias_devolucion_router
from routers.admin import router as admin_router
from routers import productos, proveedores, facturas, ordenes_compra
from models import ClientModel, GuiaRemisionModel, GuiaRemisionDetModel
from legacy_adapter import is_legacy_source_enabled, legacy_health

# Setup logging
logging.basicConfig(
    level=logging.INFO,
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s"
)
logger = logging.getLogger(__name__)

# Create database tables
Base.metadata.create_all(bind=engine)

# Do not seed fake document data here. The real source of truth for guías de remisión
# is the legacy SIGECOM adapter / WCF service. The UI should filter against that data.


# Initialize FastAPI app
app = FastAPI(
    title=PROJECT_NAME,
    version=PROJECT_VERSION,
    description="Backend API for SIGECOM - Enterprise Management System",
)

# Add CORS middleware
app.add_middleware(
    CORSMiddleware,
    allow_origins=CORS_ORIGINS,
    allow_origin_regex=CORS_ALLOW_ORIGIN_REGEX,
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)


# ============================================================================
# HEALTH CHECK ENDPOINT
# ============================================================================

@app.get("/health", response_model=HealthCheck, tags=["Health"])
def health_check():
    """Health check endpoint with legacy adapter status"""
    legacy_available = legacy_health() if is_legacy_source_enabled() else False

    return HealthCheck(
        status="ok",
        version=PROJECT_VERSION,
        database=SIGECOM_DATA_SOURCE,
        legacy_adapter_available=legacy_available if is_legacy_source_enabled() else None,
    )


# ============================================================================
# API V1 ROUTES - Core Business
# ============================================================================

# Register core routers
app.include_router(clients.router, prefix=API_V1_STR)
app.include_router(sales.router, prefix=API_V1_STR)
app.include_router(inventory.router, prefix=API_V1_STR)
app.include_router(locations_router, prefix=API_V1_STR)
app.include_router(journals_router, prefix=API_V1_STR)
app.include_router(banking_router, prefix=API_V1_STR)
app.include_router(purchases_router, prefix=API_V1_STR)
app.include_router(caja_chica_router, prefix=API_V1_STR)
app.include_router(guias_remision_router, prefix=API_V1_STR)
app.include_router(guias_devolucion_router, prefix=API_V1_STR)

# ============================================================================
# API V1 ROUTES - Extended (from SIGECOM VB.NET forms analysis)
# ============================================================================

# Productos (from frmProducto.vb)
app.include_router(productos.router, prefix=API_V1_STR)

# Proveedores (from frmProveedor.vb)
app.include_router(proveedores.router, prefix=API_V1_STR)

# Facturas (from frmFactura.vb)
app.include_router(facturas.router, prefix=API_V1_STR)

# Órdenes de Compra (from frmComOrdenCompra.vb)
app.include_router(ordenes_compra.router, prefix=API_V1_STR)

# ============================================================================
# ADMINISTRATIVE ROUTES
# ============================================================================

# Admin endpoints for diagnostics, health, etc.
app.include_router(admin_router, prefix=API_V1_STR)

# Auth (demo)
app.include_router(auth.router, prefix=API_V1_STR)


# ============================================================================
# STARTUP AND SHUTDOWN EVENTS
# ============================================================================

@app.on_event("startup")
async def startup_event():
    """Initialize on app startup"""
    logger.info(f"SIGECOM Backend starting up...")
    logger.info(f"Environment: SIGECOM_DATA_SOURCE={SIGECOM_DATA_SOURCE}")
    logger.info(f"API Version: {PROJECT_VERSION}")

    if is_legacy_source_enabled():
        logger.info("Legacy adapter mode ENABLED")
        if legacy_health():
            logger.info("✓ Legacy adapter is reachable")
        else:
            logger.warning("✗ Legacy adapter is NOT reachable - using fallback")
    else:
        logger.info("SQLite mode ENABLED")


@app.on_event("shutdown")
async def shutdown_event():
    """Cleanup on app shutdown"""
    logger.info("SIGECOM Backend shutting down...")


# ============================================================================
# ROOT ENDPOINT
# ============================================================================

@app.get("/", tags=["Info"])
def root():
    """Root endpoint with API information"""
    return {
        "name": PROJECT_NAME,
        "version": PROJECT_VERSION,
        "status": "running",
        "mode": "legacy" if is_legacy_source_enabled() else "sqlite",
        "docs": "/docs",
        "redoc": "/redoc",
        "openapi": "/openapi.json",
    }



# Include routers with API prefix
app.include_router(clients.router, prefix=API_V1_STR)
app.include_router(sales.router, prefix=API_V1_STR)
app.include_router(inventory.router, prefix=API_V1_STR)
app.include_router(locations_router, prefix=API_V1_STR)
app.include_router(journals_router, prefix=API_V1_STR)
app.include_router(banking_router, prefix=API_V1_STR)
app.include_router(purchases_router, prefix=API_V1_STR)
app.include_router(caja_chica_router, prefix=API_V1_STR)
app.include_router(guias_remision_router, prefix=API_V1_STR)


# ============================================================================
# ROOT ENDPOINT
# ============================================================================

@app.get("/", tags=["Root"])
def root():
    """Root endpoint"""
    return {
        "message": "Welcome to SIGECOM Backend API",
        "version": PROJECT_VERSION,
        "docs": "/docs",
        "api_prefix": API_V1_STR,
        "timestamp": datetime.now().isoformat()
    }


if __name__ == "__main__":
    import uvicorn
    uvicorn.run(
        "main:app",
        host="0.0.0.0",
        port=8000,
        reload=True
    )
