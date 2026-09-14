import os
import re
from datetime import date
from fastapi import APIRouter, HTTPException, status
from pydantic import BaseModel

from legacy_adapter import fetch_tipo_cambio_legacy

router = APIRouter()


def _get_default_float(env_name: str, fallback: str) -> float:
    raw_value = os.getenv(env_name, "").strip()
    if not raw_value:
        return float(fallback)
    try:
        return float(raw_value)
    except ValueError:
        return float(fallback)


LEGACY_USERNAME = os.getenv("SIGECOM_LEGACY_USERNAME", "").strip().lower()
LEGACY_PASSWORD_LENGTH = int(os.getenv("SIGECOM_LEGACY_PASSWORD_LENGTH", "3"))
DEFAULT_TIPO_CAMBIO_COMPRA = _get_default_float("SIGECOM_TIPO_CAMBIO_COMPRA", "3.36")
DEFAULT_TIPO_CAMBIO_VENTA = _get_default_float("SIGECOM_TIPO_CAMBIO_VENTA", "3.369")


class LoginRequest(BaseModel):
    username: str
    password: str


class EmpresaAsignada(BaseModel):
    codigo: str
    nombre: str
    ruc: str | None = None
    descripcion: str | None = None


class SessionInfo(BaseModel):
    username: str
    perfil: str
    fecha_transaccion: str
    tipo_cambio_compra: float
    tipo_cambio_venta: float
    empresa_actual: EmpresaAsignada | None = None
    empresas: list[EmpresaAsignada] = []


def _fetch_legacy_tipo_cambio(moneda: str, fecha: str):
    values = fetch_tipo_cambio_legacy(moneda=moneda, fecha=fecha)
    if values is None:
        return None
    compra, venta = values
    return float(compra), float(venta)


def _get_empresas_asignadas(username: str) -> list[EmpresaAsignada]:
    raw = os.getenv("SIGECOM_EMPRESAS_ASIGNADAS", "").strip()
    if raw:
        empresas: list[EmpresaAsignada] = []
        for chunk in re.split(r"[;\n,]+", raw):
            item = chunk.strip()
            if not item:
                continue
            if ":" in item:
                codigo, nombre = item.split(":", 1)
                codigo = codigo.strip()
                nombre = nombre.strip()
                empresas.append(EmpresaAsignada(
                    codigo=codigo,
                    nombre=nombre or codigo,
                    descripcion=None,
                ))
            elif "|" in item:
                parts = [p.strip() for p in item.split("|", 2)]
                if len(parts) >= 2:
                    codigo = parts[0]
                    nombre = parts[1] or codigo
                    ruc = parts[2] if len(parts) > 2 else None
                    empresas.append(EmpresaAsignada(codigo=codigo, nombre=nombre, ruc=ruc, descripcion=None))
            else:
                item = item.strip()
                empresas.append(EmpresaAsignada(
                    codigo=item,
                    nombre=item,
                    descripcion=None,
                ))
        if empresas:
            return empresas

    return []


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

    empresas = _get_empresas_asignadas(user)
    empresa_actual = empresas[0] if empresas else None
    fecha = date.today().strftime("%d/%m/%Y")
    tipo_cambio = _fetch_legacy_tipo_cambio("US", fecha) or (
        DEFAULT_TIPO_CAMBIO_COMPRA,
        DEFAULT_TIPO_CAMBIO_VENTA,
    )

    if user == LEGACY_USERNAME:
        return SessionInfo(
            username=LEGACY_USERNAME,
            perfil="Consultor",
            fecha_transaccion=fecha,
            tipo_cambio_compra=tipo_cambio[0],
            tipo_cambio_venta=tipo_cambio[1],
            empresa_actual=empresa_actual,
            empresas=empresas,
        )

    return SessionInfo(
        username=payload.username,
        perfil="Usuario",
        fecha_transaccion=fecha,
        tipo_cambio_compra=tipo_cambio[0],
        tipo_cambio_venta=tipo_cambio[1],
        empresa_actual=empresa_actual,
        empresas=empresas,
    )


@router.get("/auth/session", response_model=SessionInfo)
def get_session():
    """Return the current user session with the real assigned companies."""
    fecha = date.today().strftime("%d/%m/%Y")
    username = os.getenv("SIGECOM_LOGGED_IN_USER", LEGACY_USERNAME).strip().lower()
    empresas = _get_empresas_asignadas(username)
    perfil = "Consultor" if username == LEGACY_USERNAME else "Usuario"
    tipo_cambio = _fetch_legacy_tipo_cambio("US", fecha) or (
        DEFAULT_TIPO_CAMBIO_COMPRA,
        DEFAULT_TIPO_CAMBIO_VENTA,
    )
    return SessionInfo(
        username=username,
        perfil=perfil,
        fecha_transaccion=fecha,
        tipo_cambio_compra=tipo_cambio[0],
        tipo_cambio_venta=tipo_cambio[1],
        empresa_actual=empresas[0] if empresas else None,
        empresas=empresas,
    )
