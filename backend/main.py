"""
SIGECOM Backend API - Main application

FastAPI server for SIGECOM (Migracion VB.NET to Python)
- Clients management
- Sales/Invoices (Facturas, Boletas, Guías)
- Inventory management
- User authentication (coming soon)
"""

from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from datetime import datetime

from config import CORS_ORIGINS, API_V1_STR, PROJECT_NAME, PROJECT_VERSION, Base, engine
from schemas import HealthCheck
from routers import clients, sales, inventory
from routers.locations import router as locations_router
from routers.journals import router as journals_router
from routers.banking import router as banking_router
from routers.purchases import router as purchases_router
from routers.caja_chica import router as caja_chica_router

# Create database tables
Base.metadata.create_all(bind=engine)

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
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)


# ============================================================================
# HEALTH CHECK ENDPOINT
# ============================================================================

@app.get("/health", response_model=HealthCheck, tags=["Health"])
def health_check():
    """Health check endpoint"""
    return HealthCheck(
        status="ok",
        version=PROJECT_VERSION,
        database="sqlite"
    )


# ============================================================================
# API V1 ROUTES
# ============================================================================

# Include routers with API prefix
app.include_router(clients.router, prefix=API_V1_STR)
app.include_router(sales.router, prefix=API_V1_STR)
app.include_router(inventory.router, prefix=API_V1_STR)
app.include_router(locations_router, prefix=API_V1_STR)
app.include_router(journals_router, prefix=API_V1_STR)
app.include_router(banking_router, prefix=API_V1_STR)
app.include_router(purchases_router, prefix=API_V1_STR)
app.include_router(caja_chica_router, prefix=API_V1_STR)


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
