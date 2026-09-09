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
                empresas.append(EmpresaAsignada(
                    codigo=codigo.strip(),
                    nombre=nombre.strip() or "Empresa",
                    descripcion=f"Empresa asignada al usuario {username}",
                ))
            elif "|" in item:
                parts = [p.strip() for p in item.split("|", 2)]
                if len(parts) >= 2:
                    codigo = parts[0]
                    nombre = parts[1]
                    ruc = parts[2] if len(parts) > 2 else None
                    empresas.append(EmpresaAsignada(codigo=codigo, nombre=nombre, ruc=ruc, descripcion=f"Empresa asignada al usuario {username}"))
            else:
                empresas.append(EmpresaAsignada(
                    codigo=item,
                    nombre=f"Empresa {item}",
                    descripcion=f"Empresa asignada al usuario {username}",
                ))
        if empresas:
            return empresas

    codigo = (os.getenv("SIGECOM_COD_EMP", "08") or "08").strip() or "08"
    nombre = (os.getenv("SIGECOM_EMPRESA_NOMBRE", "C2TECK S.A.C.") or "C2TECK S.A.C.").strip() or "C2TECK S.A.C."
    ruc = (os.getenv("SIGECOM_RUC_EMPRESA", "20608806700") or "").strip() or None
    return [
        EmpresaAsignada(
            codigo=codigo,
            nombre=nombre,
            ruc=ruc,
            descripcion=f"Empresa asignada al usuario {username}",
        )
    ]


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
    empresa_actual = empresas[0]

    if user == LEGACY_USERNAME:
        fecha = date.today().strftime("%d/%m/%Y")
        return SessionInfo(
            username=LEGACY_USERNAME,
            perfil="Consultor",
            fecha_transaccion=fecha,
            tipo_cambio_compra=3.36,
            tipo_cambio_venta=3.369,
            empresa_actual=empresa_actual,
            empresas=empresas,
        )

    fecha = date.today().strftime("%d/%m/%Y")
    return SessionInfo(
        username=payload.username,
        perfil="Usuario",
        fecha_transaccion=fecha,
        tipo_cambio_compra=3.36,
        tipo_cambio_venta=3.369,
        empresa_actual=empresa_actual,
        empresas=empresas,
    )


@router.get("/auth/session", response_model=SessionInfo)
def get_session():
    """Return the current user session with the real assigned companies."""
    fecha = date.today().strftime("%d/%m/%Y")
    username = LEGACY_USERNAME
    empresas = _get_empresas_asignadas(username)
    return SessionInfo(
        username=username,
        perfil="Consultor",
        fecha_transaccion=fecha,
        tipo_cambio_compra=3.36,
        tipo_cambio_venta=3.369,
        empresa_actual=empresas[0],
        empresas=empresas,
    )
