import json
import os
import re
from datetime import date
from fastapi import APIRouter, HTTPException, status
from pydantic import BaseModel

from legacy_adapter import fetch_tipo_cambio_legacy, validate_user, validate_user_legacy, is_legacy_source_enabled

router = APIRouter()

# In-memory current session (simple server-side session for desktop app).
# This keeps the last authenticated session info so `/auth/session` can
# return the real username/perfil without relying on env vars.
_CURRENT_SESSION: dict | None = None


def _local_fallback_enabled() -> bool:
    """Only enable local fallback when explicitly configured for development.

    Real authentication must use the legacy SIGECOM service; the local JSON file is
    a development-only escape hatch and must never activate automatically.
    """
    value = (os.getenv("SIGECOM_ENABLE_LOCAL_FALLBACK") or "").strip().lower()
    return value in {"1", "true", "yes", "on"}


def _load_local_users() -> list[dict]:
    """Load registered SIGECOM users from the local JSON fallback file.

    This is intentionally disabled by default. Real authenticated data must come
    from the legacy SIGECOM adapter/WCF, not from a fake in-repo list.
    """
    if not _local_fallback_enabled():
        return []

    candidates = []
    env_path = (os.getenv("SIGECOM_LOCAL_USERS_FILE") or "").strip()
    if env_path:
        candidates.append(env_path)
    candidates.extend([
        os.path.join(os.path.dirname(os.path.dirname(__file__)), "sigecoom-wcf-adapter", "local_users.json"),
        os.path.join(os.getcwd(), "sigecoom-wcf-adapter", "local_users.json"),
    ])

    for path in candidates:
        try:
            if not path:
                continue
            with open(path, "r", encoding="utf-8") as handle:
                payload = json.load(handle)
            if isinstance(payload, list):
                return payload
        except Exception:
            continue
    return []


def _validate_local_user_credentials(username: str, password: str) -> dict | None:
    """Validate a user against the local SIGECOM users file when explicitly enabled."""
    if not _local_fallback_enabled():
        return None

    user = (username or "").strip().lower()
    pwd = (password or "").strip()
    if not user or not pwd:
        return None

    for entry in _load_local_users():
        if not isinstance(entry, dict):
            continue
        entry_user = str(entry.get("username") or "").strip().lower()
        entry_password = str(entry.get("password") or "").strip()
        if entry_user == user and entry_password == pwd:
            perfil = str(entry.get("perfil") or "Usuario").strip() or "Usuario"
            empresas = entry.get("empresas") or []
            return {"username": user, "perfil": perfil, "empresas": empresas, "source": "local"}
    return None


def _user_exists_in_local_file(username: str) -> bool:
    if not _local_fallback_enabled():
        return False

    user = (username or "").strip().lower()
    if not user:
        return False
    for entry in _load_local_users():
        if isinstance(entry, dict) and str(entry.get("username") or "").strip().lower() == user:
            return True
    return False


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


class CompanySwitchRequest(BaseModel):
    codigo: str | None = None
    cod_emp: str | None = None
    empresa: str | None = None


def _normalize_empresa(item) -> EmpresaAsignada | None:
    try:
        if isinstance(item, EmpresaAsignada):
            return item
        if isinstance(item, dict):
            codigo = str(item.get("codigo") or item.get("Codigo") or item.get("cod") or item.get("cod_emp") or item.get("CodEmp") or item.get("codigoEmpresa") or "").strip()
            nombre = str(item.get("nombre") or item.get("Nombre") or item.get("razon") or item.get("Des") or item.get("descripcion") or codigo).strip()
            ruc = item.get("ruc") or item.get("RUC") or item.get("rucEmpresa")
            descripcion = item.get("descripcion") or item.get("descripcionEmpresa") or item.get("Des")
            if not codigo:
                return None
            return EmpresaAsignada(codigo=codigo, nombre=nombre or codigo, ruc=ruc, descripcion=descripcion)
        if item is not None:
            codigo = str(item).strip()
            if codigo:
                return EmpresaAsignada(codigo=codigo, nombre=codigo, descripcion=None)
    except Exception:
        return None
    return None


def _normalize_empresa_list(raw_empresas) -> list[EmpresaAsignada]:
    empresas: list[EmpresaAsignada] = []
    if not isinstance(raw_empresas, (list, tuple)):
        return empresas
    for item in raw_empresas:
        empresa = _normalize_empresa(item)
        if empresa and empresa.codigo not in {e.codigo for e in empresas}:
            empresas.append(empresa)
    return empresas


def _build_session_from_state(username: str, perfil: str, empresas: list[EmpresaAsignada], tipo_cambio: tuple[float, float], empresa_actual: EmpresaAsignada | None = None) -> SessionInfo:
    if empresa_actual is None:
        empresa_actual = empresas[0] if empresas else None
    session = SessionInfo(
        username=username,
        perfil=perfil,
        fecha_transaccion=date.today().strftime("%d/%m/%Y"),
        tipo_cambio_compra=float(tipo_cambio[0]),
        tipo_cambio_venta=float(tipo_cambio[1]),
        empresa_actual=empresa_actual,
        empresas=empresas,
    )
    return session


def _effective_session_state() -> dict:
    global _CURRENT_SESSION
    if _CURRENT_SESSION:
        return dict(_CURRENT_SESSION)

    username = (os.getenv("SIGECOM_LOGGED_IN_USER") or LEGACY_USERNAME or "").strip().lower()
    empresas = _get_empresas_asignadas(username)
    perfil = "Consultor" if username == LEGACY_USERNAME and username else "Usuario"
    fecha = date.today().strftime("%d/%m/%Y")
    tipo_cambio = _fetch_legacy_tipo_cambio("US", fecha, company_code=empresas[0].codigo if empresas else None) or (
        DEFAULT_TIPO_CAMBIO_COMPRA,
        DEFAULT_TIPO_CAMBIO_VENTA,
    )
    return {
        "username": username,
        "perfil": perfil,
        "fecha_transaccion": fecha,
        "tipo_cambio_compra": float(tipo_cambio[0]),
        "tipo_cambio_venta": float(tipo_cambio[1]),
        "empresa_actual": empresas[0] if empresas else None,
        "empresas": empresas,
    }


def _legacy_user_validator():
    """Return whichever validator is currently active, preserving compatibility."""
    if "validate_user_legacy" in globals() and callable(globals()["validate_user_legacy"]):
        return globals()["validate_user_legacy"]
    if "validate_user" in globals() and callable(globals()["validate_user"]):
        return globals()["validate_user"]
    return None


def _persist_session(session_payload: dict):
    global _CURRENT_SESSION
    try:
        _CURRENT_SESSION = SessionInfo(**session_payload).model_dump()
    except Exception:
        _CURRENT_SESSION = dict(session_payload)
    username = str(_CURRENT_SESSION.get("username") or "").strip().lower()
    if username:
        os.environ["SIGECOM_LOGGED_IN_USER"] = username
    empresa_actual = _CURRENT_SESSION.get("empresa_actual")
    if isinstance(empresa_actual, dict):
        codigo = str(empresa_actual.get("codigo") or "").strip()
        if codigo:
            os.environ["SIGECOM_EMPRESA_ACTIVA"] = codigo


def _fetch_legacy_tipo_cambio(moneda: str, fecha: str, company_code: str | None = None):
    values = fetch_tipo_cambio_legacy(moneda=moneda, fecha=fecha, company_code=company_code)
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
    """Validate a user against the real legacy SIGECOM backend using the original credentials.

    The local JSON fallback is only valid when explicitly enabled via
    SIGECOM_ENABLE_LOCAL_FALLBACK; otherwise the app must use the real SIGECOM
    service/users and their actual passwords.
    """
    user = payload.username.strip().lower()
    password = payload.password.strip()

    if not user:
        raise HTTPException(status_code=status.HTTP_400_BAD_REQUEST, detail="username required")

    # Prefer the actual per-user credentials stored in the local SIGECOM fallback layer.
    local_validated = _validate_local_user_credentials(user, password)
    empresas = _get_empresas_asignadas(user)
    empresa_actual = empresas[0] if empresas else None
    fecha = date.today().strftime("%d/%m/%Y")

    # Try to validate against legacy adapter / WCF if configured.
    if is_legacy_source_enabled():
        try:
            validator = _legacy_user_validator()
            if validator is None:
                validated = local_validated
            else:
                validated = validator(user, password, company_code=None) or local_validated
        except Exception:
            validated = local_validated

        empresas = _get_empresas_asignadas(user)
        empresa_actual = empresas[0] if empresas else None

        if validated is None:
            if _user_exists_in_local_file(user):
                raise HTTPException(
                    status_code=status.HTTP_401_UNAUTHORIZED,
                    detail="Credenciales inválidas para el usuario SIGECOM.",
                )
            raise HTTPException(
                status_code=status.HTTP_401_UNAUTHORIZED,
                detail="Credenciales SIGECOM inválidas o el servicio legacy no está disponible.",
            )
        else:
            perfil = validated.get("perfil", "Usuario")
            user = (validated.get("username") or user).strip().lower()
            if isinstance(validated.get("empresas"), (list, tuple)) and validated.get("empresas"):
                empresas = []
                for item in validated.get("empresas"):
                    try:
                        if isinstance(item, dict):
                            codigo = str(item.get("codigo") or item.get("Codigo") or item.get("cod") or item.get("cod_emp") or item.get("CodEmp") or item.get("codigoEmpresa") or "").strip()
                            nombre = str(item.get("nombre") or item.get("Nombre") or item.get("razon") or item.get("Des") or codigo).strip()
                            ruc = item.get("ruc") or item.get("RUC") or item.get("rucEmpresa")
                            empresas.append(EmpresaAsignada(codigo=codigo, nombre=nombre, ruc=ruc, descripcion=None))
                        else:
                            empresas.append(EmpresaAsignada(codigo=str(item), nombre=str(item), descripcion=None))
                    except Exception:
                        continue
                empresa_actual = empresas[0] if empresas else empresa_actual

    else:
        validated = local_validated
        if validated is None:
            if _user_exists_in_local_file(user):
                raise HTTPException(
                    status_code=status.HTTP_401_UNAUTHORIZED,
                    detail="Credenciales inválidas para el usuario SIGECOM.",
                )
            raise HTTPException(
                status_code=status.HTTP_401_UNAUTHORIZED,
                detail="Credenciales SIGECOM inválidas o el servicio legacy no está disponible.",
            )
        else:
            perfil = validated.get("perfil", "Usuario")
            if isinstance(validated.get("empresas"), (list, tuple)) and validated.get("empresas"):
                empresas = []
                for item in validated.get("empresas"):
                    try:
                        if isinstance(item, dict):
                            codigo = str(item.get("codigo") or item.get("Codigo") or item.get("cod") or item.get("cod_emp") or item.get("CodEmp") or item.get("codigoEmpresa") or "").strip()
                            nombre = str(item.get("nombre") or item.get("Nombre") or item.get("razon") or item.get("Des") or codigo).strip()
                            ruc = item.get("ruc") or item.get("RUC") or item.get("rucEmpresa")
                            empresas.append(EmpresaAsignada(codigo=codigo, nombre=nombre, ruc=ruc, descripcion=None))
                        else:
                            empresas.append(EmpresaAsignada(codigo=str(item), nombre=str(item), descripcion=None))
                    except Exception:
                        continue
                empresa_actual = empresas[0] if empresas else empresa_actual

    # Prefer fetching tipo cambio with the active company context when available
    tipo_cambio = _fetch_legacy_tipo_cambio("US", fecha, company_code=empresa_actual.codigo if empresa_actual else None) or (
        DEFAULT_TIPO_CAMBIO_COMPRA,
        DEFAULT_TIPO_CAMBIO_VENTA,
    )

    # If the username is the special LEGACY_USERNAME, present as Consultor
    if user == LEGACY_USERNAME:
        perfil = "Consultor"

    session_obj = SessionInfo(
        username=user,
        perfil=perfil,
        fecha_transaccion=fecha,
        tipo_cambio_compra=tipo_cambio[0],
        tipo_cambio_venta=tipo_cambio[1],
        empresa_actual=empresa_actual,
        empresas=empresas,
    )

    # Persist last session in memory for subsequent /auth/session calls.
    _persist_session(session_obj.model_dump())

    return session_obj


@router.get("/auth/empresas", response_model=list[EmpresaAsignada])
@router.post("/auth/empresas", response_model=list[EmpresaAsignada])
def list_empresas(username: str | None = None):
    """Return the companies assigned to the logged user (multiempresa)."""
    session = _effective_session_state()
    target_username = (username or session.get("username") or os.getenv("SIGECOM_LOGGED_IN_USER") or LEGACY_USERNAME or "").strip().lower()
    if target_username:
        empresas = _get_empresas_asignadas(target_username)
        if not empresas and session.get("empresas"):
            empresas = _normalize_empresa_list(session.get("empresas"))
    else:
        empresas = _normalize_empresa_list(session.get("empresas"))
    if not empresas and _CURRENT_SESSION:
        empresas = _normalize_empresa_list(_CURRENT_SESSION.get("empresas"))
    return empresas


@router.get("/auth/multiempresa", response_model=SessionInfo)
@router.get("/auth/multi-empresa", response_model=SessionInfo)
def get_multiempresa(username: str | None = None):
    session = _effective_session_state()
    target_username = (username or session.get("username") or os.getenv("SIGECOM_LOGGED_IN_USER") or LEGACY_USERNAME or "").strip().lower()
    if target_username:
        empresas = _get_empresas_asignadas(target_username)
        if not empresas and session.get("empresas"):
            empresas = _normalize_empresa_list(session.get("empresas"))
    else:
        empresas = _normalize_empresa_list(session.get("empresas"))
    if session.get("empresa_actual") and isinstance(session.get("empresa_actual"), dict):
        actual = _normalize_empresa(session.get("empresa_actual"))
    else:
        actual = empresas[0] if empresas else None
    perfil = str(session.get("perfil") or "Usuario")
    if not session.get("username") and target_username:
        session["username"] = target_username
    return _build_session_from_state(
        username=session.get("username") or target_username or "",
        perfil=perfil,
        empresas=empresas,
        tipo_cambio=(session.get("tipo_cambio_compra", DEFAULT_TIPO_CAMBIO_COMPRA), session.get("tipo_cambio_venta", DEFAULT_TIPO_CAMBIO_VENTA)),
        empresa_actual=actual,
    )


@router.post("/auth/cambiar-empresa", response_model=SessionInfo)
@router.post("/auth/cambiarempresa", response_model=SessionInfo)
@router.post("/auth/change-company", response_model=SessionInfo)
def cambiar_empresa(payload: CompanySwitchRequest):
    """Set the active company for the current user session."""
    codigo = (payload.codigo or payload.cod_emp or payload.empresa or "").strip()
    if not codigo:
        raise HTTPException(status_code=status.HTTP_400_BAD_REQUEST, detail="Debe indicar el código de empresa a seleccionar.")

    session = _effective_session_state()
    empresas = _normalize_empresa_list(session.get("empresas"))
    if not empresas:
        empresas = _get_empresas_asignadas(str(session.get("username") or "").strip().lower())

    match = next((empresa for empresa in empresas if str(empresa.codigo).strip() == codigo), None)
    if match is None:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail=f"La empresa {codigo} no está asignada al usuario actual.")

    session["empresa_actual"] = match
    session["empresas"] = empresas
    _persist_session(session)
    session_obj = SessionInfo(**session)
    return session_obj


@router.post("/auth/logout")
def logout():
    """Clear the in-memory session for the current desktop user."""
    global _CURRENT_SESSION
    _CURRENT_SESSION = None
    os.environ.pop("SIGECOM_LOGGED_IN_USER", None)
    os.environ.pop("SIGECOM_EMPRESA_ACTIVA", None)
    return {"ok": True, "message": "Sesión cerrada"}


@router.get("/auth/session", response_model=SessionInfo)
@router.get("/auth", response_model=SessionInfo)
def get_session():
    """Return the current user session with the real assigned companies."""
    # If we have an in-memory session from a prior login, return it directly.
    global _CURRENT_SESSION
    if _CURRENT_SESSION:
        try:
            return SessionInfo(**_CURRENT_SESSION)
        except Exception:
            pass

    session = _effective_session_state()
    empresas = _normalize_empresa_list(session.get("empresas"))
    if not empresas:
        username = str(session.get("username") or os.getenv("SIGECOM_LOGGED_IN_USER") or LEGACY_USERNAME or "").strip().lower()
        empresas = _get_empresas_asignadas(username)
    empresa_actual = _normalize_empresa(session.get("empresa_actual")) if session.get("empresa_actual") else (empresas[0] if empresas else None)
    perfil = str(session.get("perfil") or "Usuario")
    return _build_session_from_state(
        username=str(session.get("username") or os.getenv("SIGECOM_LOGGED_IN_USER") or LEGACY_USERNAME or "").strip().lower(),
        perfil=perfil,
        empresas=empresas,
        tipo_cambio=(session.get("tipo_cambio_compra", DEFAULT_TIPO_CAMBIO_COMPRA), session.get("tipo_cambio_venta", DEFAULT_TIPO_CAMBIO_VENTA)),
        empresa_actual=empresa_actual,
    )
