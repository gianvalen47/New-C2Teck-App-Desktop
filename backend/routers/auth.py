import os
import re
from datetime import date
from fastapi import APIRouter, HTTPException, status
from pydantic import BaseModel

router = APIRouter()

LEGACY_USERNAME = os.getenv("SIGECOM_LEGACY_USERNAME", "grios").strip().lower()
LEGACY_PASSWORD_LENGTH = int(os.getenv("SIGECOM_LEGACY_PASSWORD_LENGTH", "3"))


class LoginRequest(BaseModel):
    username: str
    password: str


class SessionInfo(BaseModel):
    username: str
    perfil: str
    fecha_transaccion: str
    tipo_cambio_compra: float
    tipo_cambio_venta: float


@router.post("/auth/login", response_model=SessionInfo)
def login(payload: LoginRequest):
    """Validate the legacy SIGECOM login pattern used by the VB.NET server: user + 3-digit numeric password."""
    user = payload.username.strip().lower()
    password = payload.password.strip()

    if not user:
        raise HTTPException(status_code=status.HTTP_400_BAD_REQUEST, detail="username required")

    if not re.fullmatch(rf"\d{{{LEGACY_PASSWORD_LENGTH}}}", password):
        raise HTTPException(
            status_code=status.HTTP_400_BAD_REQUEST,
            detail=f"La contraseña del servidor SIGECOM debe tener {LEGACY_PASSWORD_LENGTH} dígitos.",
        )

    if user == LEGACY_USERNAME:
        fecha = date.today().strftime("%d/%m/%Y")
        return SessionInfo(
            username=LEGACY_USERNAME,
            perfil="Consultor",
            fecha_transaccion=fecha,
            tipo_cambio_compra=3.36,
            tipo_cambio_venta=3.369,
        )

    fecha = date.today().strftime("%d/%m/%Y")
    return SessionInfo(
        username=payload.username,
        perfil="Usuario",
        fecha_transaccion=fecha,
        tipo_cambio_compra=3.36,
        tipo_cambio_venta=3.369,
    )


@router.get("/auth/session", response_model=SessionInfo)
def get_session():
    """Return a demo session for the current user (dev only)."""
    fecha = date.today().strftime("%d/%m/%Y")
    return SessionInfo(
        username="grios",
        perfil="Consultor",
        fecha_transaccion=fecha,
        tipo_cambio_compra=3.36,
        tipo_cambio_venta=3.369,
    )
