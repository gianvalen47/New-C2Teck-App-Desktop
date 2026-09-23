"""
Small HTTP compatibility layer for the SIGECOM original API/adapter.
The legacy API is exposed through a .NET/ASP.NET adapter that proxies to the
legacy WCF service. This module handles:
- HTTP consumption from the adapter
- Data normalization (dates → ISO-8601, IDs, booleans, decimals)
- Logging with timing and error tracking
- Fallback error handling for unavailable adapter
"""
from __future__ import annotations

import json
import logging
import os
import time
from datetime import datetime
from pathlib import Path
from urllib.error import URLError
from urllib.parse import quote, urlencode
from urllib.request import Request, urlopen

# Setup logging
logger = logging.getLogger(__name__)

try:
    from config import SIGECOM_LEGACY_ADAPTER_BASE_URL as CONFIGURED_ADAPTER_BASE_URL
except Exception:  # pragma: no cover - config may be absent in isolated contexts.
    CONFIGURED_ADAPTER_BASE_URL = "http://localhost:5041"

LEGACY_ADAPTER_BASE_URL = os.getenv(
    "SIGECOM_LEGACY_ADAPTER_BASE_URL",
    CONFIGURED_ADAPTER_BASE_URL,
).rstrip("/")

SIGECOM_DATA_SOURCE = os.getenv("SIGECOM_DATA_SOURCE", "legacy").lower()
SIGECOM_COD_EMP = os.getenv("SIGECOM_COD_EMP", "08").strip()


def get_active_company_code() -> str | None:
    """Return the active SIGECOM company code from the runtime environment."""
    for name in ("SIGECOM_COD_EMP", "SIGECOM_COMPANY_CODE", "COD_EMP"):
        value = os.getenv(name, "").strip()
        if value:
            return value
    return None


def _company_to_locaciones(company_code: str | None) -> list[int]:
    """Map SIGECOM company codes to the legacy `id_locacion` values used by the DB.

    The original SIGECOM snapshots do not carry a `cod_emp` field on each guia row,
    but they do expose `IdLocacion`. In this project, the known mapping is:
    - 08 -> 87 (C2TECK)
    - 05 -> 72 (example for EQUIMAP / other company branch)
    """
    if not company_code:
        return []

    normalized = str(company_code).strip()
    mapping = {
        "08": [87],
        "8": [87],
        "05": [72],
        "5": [72],
        "02": [30],
        "2": [30],
        "07": [81],
        "7": [81],
        "30": [30],
        "31": [31],
        "72": [72],
        "73": [73],
        "75": [75],
        "80": [80],
        "81": [81],
        "83": [83],
        "87": [87],
    }
    if normalized in mapping:
        return mapping[normalized]
    return []


def _row_matches_company(row: dict, company_code: str | None) -> bool:
    """Filter rows to the active company when metadata is available.

    SIGECOM guia rows often omit `CodEmp`; in those cases the `id_locacion`
    mapping is the authoritative fallback. Rows without metadata must not be
    dropped just because the adapter cannot see a company code on the row itself.
    """
    if not company_code:
        return True
    if not isinstance(row, dict):
        return True

    locaciones = _company_to_locaciones(company_code)
    if locaciones:
        loc = row.get("id_locacion")
        if loc is None:
            loc = row.get("IdLocacion")
        if loc is not None:
            try:
                loc_value = int(str(loc).strip())
                if loc_value in locaciones:
                    return True
                return False
            except (TypeError, ValueError):
                pass

    for key in ("CodEmp", "cod_emp", "CodEmpresa", "cod_empresa", "Empresa", "empresa"):
        if key in row:
            value = row.get(key)
            if value is not None:
                return str(value).strip() == str(company_code).strip()

    # Rows without explicit company metadata are not evidence of a mismatch.
    # Preserve them unless the row itself says otherwise.
    return True


def is_legacy_source_enabled() -> bool:
    return SIGECOM_DATA_SOURCE in {"legacy", "sigecoom", "adapter", "wcf", "original"}


def build_legacy_url(path: str) -> str:
    return f"{LEGACY_ADAPTER_BASE_URL}{path}"


def _local_wcf_snapshot_path() -> Path:
    return Path(__file__).resolve().parents[1] / "sigecoom-wcf-client" / "salida.json"


def _load_real_wcf_guia_rows() -> list[dict]:
    """Load the real WCF export captured from the legacy SIGECOM service."""
    snapshot_path = _local_wcf_snapshot_path()
    if not snapshot_path.exists():
        raise FileNotFoundError(f"SIGECOM WCF snapshot not found: {snapshot_path}")

    raw_text = snapshot_path.read_bytes()
    for encoding in ("utf-8", "utf-16", "utf-16-le", "utf-16-be"):
        try:
            text = raw_text.decode(encoding)
            break
        except UnicodeDecodeError:
            continue
    else:
        raise UnicodeDecodeError("utf-8", raw_text, 0, 1, "Unable to decode SIGECOM WCF snapshot")

    start = text.find("[")
    if start == -1:
        raise ValueError(f"No JSON array found in SIGECOM WCF snapshot: {snapshot_path}")

    payload = json.loads(text[start:])
    rows: list[dict] = []

    if isinstance(payload, list):
        for item in payload:
            if isinstance(item, dict):
                rows.extend(item.get("rows") or [])
    elif isinstance(payload, dict):
        rows.extend(payload.get("rows") or [])

    return rows


def _coerce_wcf_guia_row(raw: dict) -> dict:
    """Map the real WCF DataSet row to the normalized legacy GUIA schema."""
    if not raw:
        return {}

    num_job = (
        raw.get("NumJob")
        or raw.get("num_job")
        or raw.get("NumFac")
        or raw.get("num_fac")
        or raw.get("Referencia")
        or raw.get("referencia")
        or raw.get("Ref")
        or raw.get("ref")
    )
    id_cotizacion = (
        raw.get("IdCotizacion")
        or raw.get("id_cotizacion")
        or raw.get("NumCot")
        or raw.get("num_cot")
        or raw.get("Cotizacion")
        or raw.get("cotizacion")
        or raw.get("Cotiz")
        or raw.get("cotiz")
    )
    num_orden = (
        raw.get("NumOrden")
        or raw.get("num_orden")
        or raw.get("Orden")
        or raw.get("orden")
    )

    return {
        "id": raw.get("IdGuia") or raw.get("id"),
        "id_locacion": raw.get("IdLocacion") or raw.get("id_locacion"),
        "fec_doc": raw.get("FecDoc") or raw.get("fec_doc"),
        "id_serie_doc": raw.get("IdSerieDoc") or raw.get("id_serie_doc"),
        "num_doc": raw.get("NumDoc") or raw.get("num_doc"),
        "id_cliente": raw.get("IdCliente") or raw.get("id_cliente"),
        "cod_mot": raw.get("CodMot") or raw.get("cod_mot") or "1",
        "num_job": num_job,
        "num_orden": num_orden,
        "pto_partida": raw.get("PtoPartida") or raw.get("pto_partida"),
        "pto_llegada": raw.get("PtoLlegada") or raw.get("pto_llegada"),
        "id_cotizacion": id_cotizacion,
        "observacion": raw.get("Observacion") or raw.get("observacion"),
        "cod_mon": raw.get("CodMon") or raw.get("cod_mon") or "US",
        "igv": 0.0,
        "tip_cambio": 3.36,
        "tot_flete": 0.0,
        "tot_embarque": 0.0,
        "tot_bruto": raw.get("TotNeto") or raw.get("tot_bruto") or 0.0,
        "tot_dscto": 0.0,
        "tot_venta": raw.get("TotNeto") or raw.get("tot_venta") or 0.0,
        "tot_igv": 0.0,
        "tot_neto": raw.get("TotNeto") or raw.get("tot_neto") or 0.0,
        "cliente_nombre": raw.get("DesCli") or raw.get("cliente_nombre"),
        "estado": raw.get("Estado") or raw.get("estado") or "GN",
        "cod_serie": raw.get("CodSerie") or raw.get("cod_serie"),
        "tot_neto_sug": raw.get("TotNetoSug") or raw.get("tot_neto_sug") or raw.get("TotNeto") or 0.0,
        "created_at": raw.get("FecDoc") or raw.get("fec_doc"),
        "updated_at": raw.get("FecDoc") or raw.get("fec_doc"),
    }


def _normalize_datetime(value) -> str | None:
    """Convert datetime/date/timestamp to ISO-8601 UTC string."""
    if not value:
        return None
    if isinstance(value, str):
        # Already a string; try to parse and re-format for consistency
        try:
            # Try common formats
            for fmt in ["%Y-%m-%dT%H:%M:%S", "%Y-%m-%d %H:%M:%S", "%Y-%m-%d"]:
                try:
                    dt = datetime.strptime(value[:19], fmt)
                    return dt.isoformat() + "Z"
                except ValueError:
                    continue
            return value  # Return as-is if no format matches
        except Exception:
            return value
    elif isinstance(value, datetime):
        return value.isoformat() + "Z"
    return None


def _normalize_id(value) -> str | int:
    """Normalize ID fields (convert to string or int as appropriate)."""
    if isinstance(value, (int, str)):
        return value
    return str(value) if value else None


def _normalize_boolean(value) -> bool:
    """Convert various boolean representations to Python bool."""
    if isinstance(value, bool):
        return value
    if isinstance(value, int):
        return value != 0
    if isinstance(value, str):
        return value.lower() in {"true", "1", "yes", "on", "activo"}
    return False


def _lookup_value(mapping: dict, *keys):
    for key in keys:
        if key in mapping and mapping[key] is not None:
            return mapping[key]
    return None


def _normalize_decimal(value) -> float | None:
    """Convert decimal/currency to float."""
    if value is None:
        return None
    if isinstance(value, (int, float)):
        return float(value)
    if isinstance(value, str):
        try:
            # Handle both comma and dot as decimal separator
            return float(value.replace(",", "."))
        except ValueError:
            return None
    return None


def _read_json(url: str, timeout: int = 8):
    """Fetch JSON from URL with logging and error handling."""
    start_time = time.time()
    try:
        logger.debug(f"Fetching from legacy adapter: {url}")
        req = Request(url, method="GET")
        req.add_header("Accept", "application/json")
        with urlopen(req, timeout=timeout) as response:
            payload = response.read()
            elapsed = time.time() - start_time
            data = json.loads(payload.decode("utf-8"))
            logger.info(
                f"Legacy adapter request successful: {url} "
                f"(status={response.status}, time={elapsed:.2f}s, size={len(payload)} bytes)"
            )
            return data
    except URLError as e:
        elapsed = time.time() - start_time
        logger.error(
            f"Legacy adapter unreachable: {url} ({type(e).__name__}: {e.reason}) "
            f"(time={elapsed:.2f}s)"
        )
        raise
    except json.JSONDecodeError as e:
        elapsed = time.time() - start_time
        logger.error(f"Invalid JSON from legacy adapter: {url} (time={elapsed:.2f}s) {e}")
        raise
    except Exception as e:
        elapsed = time.time() - start_time
        logger.error(f"Legacy adapter error: {url} ({type(e).__name__}: {e}) (time={elapsed:.2f}s)")
        raise


def legacy_health() -> bool:
    """Check if legacy adapter is healthy."""
    try:
        url = build_legacy_url("/health")
        result = _read_json(url)
        logger.info("Legacy adapter health check: OK")
        return bool(result)
    except Exception as e:
        logger.warning(f"Legacy adapter health check failed: {e}")
        return False


def _coerce_float_value(value):
    if value is None:
        return None
    if isinstance(value, (int, float)):
        return float(value)
    if isinstance(value, str):
        candidate = value.strip().replace(" ", "")
        if not candidate:
            return None
        try:
            return float(candidate.replace(",", "."))
        except ValueError:
            return None
    return None


def _extract_tipo_cambio_from_payload(payload):
    if payload is None:
        return None
    if isinstance(payload, dict):
        for key in ("tipo_cambio_compra", "tipoCambioCompra", "compra", "buy", "purchase"):
            if key in payload:
                compra = _coerce_float_value(payload[key])
                if compra is not None:
                    break
        else:
            compra = None

        for key in ("tipo_cambio_venta", "tipoCambioVenta", "venta", "sell", "sale"):
            if key in payload:
                venta = _coerce_float_value(payload[key])
                if venta is not None:
                    break
        else:
            venta = None

        if compra is not None and venta is not None:
            return compra, venta

        if "data" in payload and isinstance(payload["data"], (dict, list)):
            nested = _extract_tipo_cambio_from_payload(payload["data"])
            if nested:
                return nested

        if isinstance(payload.get("resultado"), (dict, list)):
            nested = _extract_tipo_cambio_from_payload(payload["resultado"])
            if nested:
                return nested

    elif isinstance(payload, list):
        for item in payload:
            nested = _extract_tipo_cambio_from_payload(item)
            if nested:
                return nested

    return None


def fetch_tipo_cambio_legacy(moneda: str = "US", fecha: str | None = None, company_code: str | None = None) -> tuple[float, float] | None:
    """Fetch the real exchange rate from the legacy SIGECOM adapter when available."""
    if not LEGACY_ADAPTER_BASE_URL:
        return None

    if fecha is None:
        fecha = datetime.now().strftime("%d/%m/%Y")

    moneda = (moneda or "US").strip().upper() or "US"
    # Candidate endpoints — include company_code variants if provided
    base_q = f"moneda={moneda}&fecha={fecha}"
    if company_code:
        base_q += f"&empresa={company_code}"

    candidates = [
        f"{LEGACY_ADAPTER_BASE_URL}/api/v1/tipo-cambio?{base_q}",
        f"{LEGACY_ADAPTER_BASE_URL}/api/v1/tipocambio?{base_q}",
        f"{LEGACY_ADAPTER_BASE_URL}/api/tipo-cambio?{base_q}",
        f"{LEGACY_ADAPTER_BASE_URL}/api/tipocambio?{base_q}",
    ]

    for url in candidates:
        try:
            payload = _read_json(url, timeout=5)
        except Exception:
            continue

        values = _extract_tipo_cambio_from_payload(payload)
        if values is not None:
            compra, venta = values
            if compra is not None and venta is not None:
                # If adapter returns a single identical value for compra/venta
                # it's often because the adapter is using env-configured defaults.
                # Prefer the public SUNAT API when the adapter returns identical
                # compra/venta so the desktop matches the original VB.NET client.
                try:
                    if float(compra) == float(venta):
                        # Try public SUNAT API before accepting adapter's identical value
                        try:
                            fecha_iso = datetime.strptime(fecha, "%d/%m/%Y").strftime("%Y-%m-%d")
                        except Exception:
                            try:
                                fecha_iso = datetime.fromisoformat(fecha).strftime("%Y-%m-%d")
                            except Exception:
                                fecha_iso = datetime.now().strftime("%Y-%m-%d")

                        sunat_url = f"https://api.apis.net.pe/v1/tipo-cambio-sunat?fecha={fecha_iso}"
                        try:
                            data = _read_json(sunat_url, timeout=6)
                            sc = _coerce_float_value(data.get("compra") if isinstance(data, dict) else None)
                            sv = _coerce_float_value(data.get("venta") if isinstance(data, dict) else None)
                            if sc is not None and sv is not None and (sc != float(compra) or sv != float(venta)):
                                logger.info("Prefer public SUNAT tipo cambio over adapter identical value: %s/%s", sc, sv)
                                return float(sc), float(sv)
                        except Exception:
                            # proceed to return adapter values
                            pass
                except Exception:
                    pass

                return float(compra), float(venta)

    logger.warning("No real exchange rate returned by the legacy SIGECOM adapter for %s on %s.", moneda, fecha)

    # Fallback: try public SUNAT API (used by the original VB.NET client)
    try:
        # The public API expects YYYY-MM-DD
        try:
            fecha_iso = datetime.strptime(fecha, "%d/%m/%Y").strftime("%Y-%m-%d")
        except Exception:
            # If fecha already in ISO or other format, attempt to parse gracefully
            try:
                fecha_iso = datetime.fromisoformat(fecha).strftime("%Y-%m-%d")
            except Exception:
                fecha_iso = datetime.now().strftime("%Y-%m-%d")

        sunat_url = f"https://api.apis.net.pe/v1/tipo-cambio-sunat?fecha={fecha_iso}"
        try:
            data = _read_json(sunat_url, timeout=6)
            # Expected shape: { "compra": 3.361, "venta": 3.372 }
            compra = _coerce_float_value(data.get("compra") if isinstance(data, dict) else None)
            venta = _coerce_float_value(data.get("venta") if isinstance(data, dict) else None)
            if compra is not None and venta is not None:
                logger.info("Tipo cambio obtenido desde SUNAT público: %s/%s", compra, venta)
                return float(compra), float(venta)
        except Exception as e:
            logger.debug("Public SUNAT API fallback failed: %s", e)
    except Exception:
        pass

    return None


def validate_user(username: str, password: str, company_code: str | None = None) -> dict | None:
    """Canonical helper to validate a SIGECOM user against the legacy adapter/WCF."""
    return validate_user_legacy(username=username, password=password, company_code=company_code)


def validate_user_legacy(username: str, password: str, company_code: str | None = None) -> dict | None:
    """Attempt to validate a user against the legacy SIGECOM adapter or WCF.

    Returns a dictionary with at least {'username': str, 'perfil': str} on success,
    or None if validation couldn't be performed or failed.

    The function tries multiple HTTP endpoints on the configured adapter and
    falls back to attempting a SOAP call via `zeep` if available.
    """
    if not LEGACY_ADAPTER_BASE_URL:
        return None

    user = (username or "").strip()
    pwd = (password or "").strip()
    if not user or not pwd:
        return None

    qs_value = lambda value: quote(str(value or ""), safe="")

    candidates = [
        f"{LEGACY_ADAPTER_BASE_URL}/api/v1/auth/validate?{urlencode({'username': user, 'password': pwd})}",
        f"{LEGACY_ADAPTER_BASE_URL}/api/v1/auth/login?{urlencode({'username': user, 'password': pwd})}",
        f"{LEGACY_ADAPTER_BASE_URL}/api/v1/usuarios/validar?{urlencode({'user': user, 'pass': pwd})}",
        f"{LEGACY_ADAPTER_BASE_URL}/api/v1/usuarios/validate?{urlencode({'user': user, 'password': pwd})}",
        f"{LEGACY_ADAPTER_BASE_URL}/api/v1/users/validate?{urlencode({'username': user, 'password': pwd})}",
    ]

    # Try HTTP candidates
    for url in candidates:
        try:
            payload = _read_json(url, timeout=5)
        except Exception:
            continue

        # Interpret common success shapes
        if payload is True or payload == "ok" or payload == "OK":
            return {"username": user, "perfil": "Usuario", "source": "adapter"}

        if isinstance(payload, dict):
            # If adapter returns a session-like object, normalize minimal fields
            if payload.get("username") or payload.get("user") or payload.get("usuario"):
                uname = payload.get("username") or payload.get("user") or payload.get("usuario")
                perfil = payload.get("perfil") or payload.get("role") or "Usuario"
                result = {"username": uname, "perfil": perfil, "source": "adapter", **payload}
                # If adapter provides assigned companies, include them
                if payload.get("empresas") or payload.get("companies") or payload.get("assignedCompanies"):
                    result["empresas"] = payload.get("empresas") or payload.get("companies") or payload.get("assignedCompanies")
                return result

            # Some adapters return { ok: true }
            if payload.get("ok") is True or payload.get("valid") is True:
                return {"username": user, "perfil": payload.get("perfil", "Usuario"), "source": "adapter"}

    # If adapter didn't return empresas during validate, try the empresas endpoint
    try:
        empresas_url = build_legacy_url(f"/api/v1/auth/empresas?{urlencode({'username': user})}")
        payload = _read_json(empresas_url, timeout=5)
        if isinstance(payload, (list, dict)):
            return {"username": user, "perfil": "Usuario", "source": "adapter", "empresas": payload}
    except Exception:
        pass
    # As a best-effort fallback, attempt SOAP WSDL inspection + call if zeep is present
    try:
        from zeep import Client as ZeepClient
        from zeep.exceptions import Error as ZeepError
    except Exception:
        ZeepClient = None  # type: ignore

    if ZeepClient is None:
        return None

    # Try a few likely WSDL endpoints and method names
    base = os.getenv("SIGECOM_WCF_BASE_URL") or LEGACY_ADAPTER_BASE_URL
    wsdl_candidates = [
        f"{base.rstrip('/')}/ServicioBLL/UsuarioService?wsdl",
        f"{base.rstrip('/')}/ServicioBLL/UsuarioService?singleWsdl",
        f"{base.rstrip('/')}/UsuarioService?wsdl",
        f"{base.rstrip('/')}/ws/UsuarioService?wsdl",
    ]
    method_names = ["ValidateUser", "ValidarUsuario", "Login", "AutenticarUsuario", "Autenticar"]

    last_exc = None
    for wsdl in wsdl_candidates:
        try:
            client = ZeepClient(wsdl)
            service = None
            for svc in client.wsdl.services.values():
                for port in svc.ports.values():
                    # try to call methods on this port
                    for method in method_names:
                        try:
                            fn = getattr(client.service, method, None)
                            if fn is None:
                                continue
                            # Many legacy methods accept (username, password, company)
                            try:
                                result = fn(user, pwd, company_code) if company_code else fn(user, pwd)
                            except TypeError:
                                # Try only username/password
                                try:
                                    result = fn(user, pwd)
                                except Exception:
                                    result = fn(user)

                            if result:
                                # Normalize result into dict
                                if isinstance(result, dict):
                                    out = {"username": user, "perfil": result.get("perfil", "Usuario"), "source": "wcf", **result}
                                    # Some WCF methods return user session with companies
                                    if result.get("Empresas") or result.get("empresas"):
                                        out["empresas"] = result.get("Empresas") or result.get("empresas")
                                    return out
                                return {"username": user, "perfil": "Usuario", "source": "wcf", "raw": result}
                        except Exception:
                            continue
            # if we get here, try next WSDL
        except Exception as e:
            last_exc = e
            continue

    return None


def _legacy_list_payload(endpoint: str, page_size: int | None = None, skip: int = 0):
    """Fetch and normalize a list-like payload from the adapter without assuming a schema."""
    url = build_legacy_url(endpoint)
    data = _read_json(url, timeout=5)

    if isinstance(data, dict) and "items" in data:
        items = data["items"]
        total = data.get("total", len(items) if isinstance(items, list) else 0)
        return {"items": items, "total": total}
    if isinstance(data, list):
        return {"items": data, "total": len(data)}
    if data is None:
        return {"items": [], "total": 0}
    return {"items": [data], "total": 1}


# ============================================================================
# CLIENTS / CLIENTES
# ============================================================================

def list_clients_legacy(skip: int = 0, limit: int = 500):
    """List clients from legacy adapter.

    When limit is 0 or negative, fetch all pages until the adapter stops returning rows.
    """
    page_size = max(1, limit) if limit and limit > 0 else 5000
    current_skip = skip
    normalized = []

    try:
        while True:
            endpoint = f"/api/v1/clients?skip={current_skip}&limit={page_size}"
            data = _read_json(build_legacy_url(endpoint))

            if isinstance(data, dict) and "items" in data:
                items = data["items"]
            elif isinstance(data, list):
                items = data
            else:
                items = [data] if data else []

            if not items:
                break

            for client in items:
                normalized.append(_normalize_client(client))

            if limit and limit > 0:
                if len(normalized) >= skip + limit:
                    break
                if len(items) < page_size:
                    break
            else:
                if len(items) < page_size:
                    break

            current_skip += page_size

        if limit and limit > 0:
            return {"items": normalized[skip: skip + limit], "total": len(normalized)}
        return {"items": normalized, "total": len(normalized)}
    except Exception as e:
        logger.error(f"Failed to list clients from legacy adapter: {e}")
        raise


def get_client_legacy(client_id: str):
    """Fetch a single client from the legacy adapter."""
    endpoint = f"/api/v1/clients/{client_id}"
    try:
        data = _read_json(build_legacy_url(endpoint))
        return _normalize_client(data)
    except Exception as e:
        logger.error(f"Failed to get client {client_id} from legacy adapter: {e}")
        raise


def list_boletas_legacy(skip: int = 0, limit: int = 100, **filters):
    """List boletas from the legacy adapter."""
    params = [f"skip={skip}", f"limit={max(1, limit) if limit and limit > 0 else 100}"]
    for key, value in filters.items():
        if value is not None:
            params.append(f"{key}={value}")
    return _legacy_list_payload(f"/api/v1/boletas?{'&'.join(params)}")


def get_boleta_legacy(boleta_id: str):
    """Fetch a single boleta from the legacy adapter."""
    return _read_json(build_legacy_url(f"/api/v1/boletas/{boleta_id}"), timeout=5)


def list_sunat_legacy(skip: int = 0, limit: int = 100, **filters):
    """List SUNAT-related records from the legacy adapter."""
    params = [f"skip={skip}", f"limit={max(1, limit) if limit and limit > 0 else 100}"]
    for key, value in filters.items():
        if value is not None:
            params.append(f"{key}={value}")
    return _legacy_list_payload(f"/api/v1/sunat?{'&'.join(params)}")


def consultar_sunat_legacy(documento: str | None = None, **filters):
    """Consult a SUNAT document state using the adapter if present."""
    params = []
    if documento is not None:
        params.append(f"documento={documento}")
    for key, value in filters.items():
        if value is not None:
            params.append(f"{key}={value}")
    query = f"{'&'.join(params)}"
    path = f"/api/v1/sunat/consultar?{query}" if query else "/api/v1/sunat/consultar"
    return _read_json(build_legacy_url(path), timeout=5)


def list_seguridad_legacy(skip: int = 0, limit: int = 100, **filters):
    """List security-related records/metadata from the legacy adapter."""
    params = [f"skip={skip}", f"limit={max(1, limit) if limit and limit > 0 else 100}"]
    for key, value in filters.items():
        if value is not None:
            params.append(f"{key}={value}")
    return _legacy_list_payload(f"/api/v1/seguridad?{'&'.join(params)}")


def get_seguridad_legacy(service: str | None = None):
    """Get a security/status payload from the legacy adapter."""
    path = f"/api/v1/seguridad/{service}" if service else "/api/v1/seguridad"
    return _read_json(build_legacy_url(path), timeout=5)


def _normalize_client(client: dict) -> dict:
    """Normalize client data to consistent schema."""
    if not client:
        return {}

    # Normalize field names and types
    # Adapter may return keys like IdCliente, DesCli, RucCli, DniCli, TelCli, Email, Estado, FecIng
    client_id = client.get("IdCliente") or client.get("id") or client.get("Id")
    descli = client.get("DesCli") or client.get("DesCliente") or client.get("Nombres")
    ruc = client.get("RucCli") or client.get("RUC") or client.get("Ruc")
    dni = client.get("DniCli") or client.get("Dni")
    address = client.get("Direccion") or client.get("DireccionCli") or client.get("Address")
    phone = client.get("TelCli") or client.get("Telefono") or client.get("Phone")
    email = client.get("Email") or client.get("Correo")
    estado = client.get("Estado")
    fec_ing = client.get("FecIng") or client.get("FecIngreso") or client.get("FecIngCliente") or client.get("CreatedAt")

    name = None
    try:
        if descli:
            name = str(descli)
        else:
            nombres = client.get("Nombres") or ""
            apepat = client.get("ApePat") or ""
            apemat = client.get("ApeMat") or ""
            name = " ".join([p for p in [nombres, apepat, apemat] if p]).strip()
    except Exception:
        name = str(descli or "")

    # Ensure id is a string for Pydantic model compatibility
    nid = _normalize_id(client_id)
    if isinstance(nid, int):
        nid = str(nid)

    created = _normalize_datetime(fec_ing)
    # fallback to now if adapter omitted created date
    if not created:
        created = datetime.utcnow().isoformat() + "Z"

    updated = _normalize_datetime(client.get("UpdatedAt") or client.get("FecMod") or client.get("ModifiedAt"))
    if not updated:
        updated = created

    # map Estado -> active (legacy: 0 often means active)
    try:
        estado_int = int(estado) if estado is not None and str(estado).isdigit() else None
    except Exception:
        estado_int = None

    normalized = {
        "id": nid,
        "name": name or "",
        "ruc": str(ruc or ""),
        "dni": str(dni or ""),
        "address": str(address or ""),
        "phone": str(phone or ""),
        "email": str(email or ""),
        "active": 1 if (estado_int is None or estado_int == 0) else 0,
        "created_at": created,
        "updated_at": updated,
    }
    return {k: v for k, v in normalized.items() if v is not None}


# ============================================================================
# GUÍAS DE REMISIÓN
# ============================================================================

def list_guias_legacy(
    *,
    anio: int | None = None,
    mes: int | None = None,
    id_locacion: int | None = None,
    id_serie_doc: int | None = None,
    id_cliente: int | None = None,
    estado: str | None = None,
    num_doc: int | None = None,
    skip: int = 0,
    limit: int = 100,
    company_codes: list[str] | None = None,
):
    """List guías de remisión from legacy adapter."""
    params = []
    if anio is not None:
        params.append(("anio", str(anio)))
    if mes is not None:
        params.append(("mes", str(mes)))
    if id_locacion is not None:
        params.append(("id_locacion", str(id_locacion)))
    if id_serie_doc is not None:
        params.append(("id_serie_doc", str(id_serie_doc)))
    if id_cliente is not None:
        params.append(("id_cliente", str(id_cliente)))
    if estado:
        params.append(("estado", estado))
    if num_doc is not None:
        params.append(("num_doc", str(num_doc)))
    if skip:
        params.append(("skip", str(skip)))
    if limit:
        params.append(("limit", str(limit)))

    query = "&".join(f"{k}={v}" for k, v in params)
    endpoint = "/api/v1/guias-remision"
    if query:
        endpoint = f"{endpoint}?{query}"

    try:
        data = _read_json(build_legacy_url(endpoint))
        # data may be a list or dict with 'items' key
        if isinstance(data, dict) and "items" in data:
            items = data["items"]
        elif isinstance(data, list):
            items = data
        else:
            items = [data] if data else []

        # company_codes (list) takes precedence; if not provided fall back to env
        if company_codes:
            # normalize codes
            codes = [str(c).strip() for c in company_codes if c]
            def matches_any(g):
                for key in ("CodEmp", "cod_emp", "CodEmpresa", "cod_empresa", "Empresa", "empresa"):
                    if key in g:
                        val = g.get(key)
                        if val is None:
                            continue
                        if str(val).strip() in codes:
                            return True
                        return False

                loc = g.get("id_locacion")
                if loc is None:
                    loc = g.get("IdLocacion")
                if loc is not None:
                    try:
                        loc_value = int(str(loc).strip())
                        for code in codes:
                            if loc_value in _company_to_locaciones(code):
                                return True
                        return False
                    except (TypeError, ValueError):
                        pass

                # Rows without metadata are not evidence of mismatch; preserve them.
                return True

            filtered_items = [g for g in items if matches_any(g)]
        else:
            company_code = get_active_company_code()
            filtered_items = [g for g in items if _row_matches_company(g, company_code)]
        normalized = [_normalize_guia(g) for g in filtered_items]
        return normalized if isinstance(data, list) else {"items": normalized, "total": len(normalized)}
    except Exception as e:
        logger.warning(f"Legacy adapter unavailable for guías; falling back to SIGECOM WCF snapshot: {e}")
        try:
            rows = _load_real_wcf_guia_rows()
            company_code = get_active_company_code()
            filtered = []
            for row in rows:
                if not _row_matches_company(row, company_code):
                    continue
                record = _coerce_wcf_guia_row(row)
                if anio is not None:
                    doc_date = record.get("fec_doc")
                    if not doc_date or datetime.strptime(doc_date[:10], "%Y-%m-%d").year != anio:
                        continue
                if mes is not None:
                    doc_date = record.get("fec_doc")
                    if not doc_date or datetime.strptime(doc_date[:10], "%Y-%m-%d").month != mes:
                        continue
                if id_locacion is not None and (record.get("id_locacion") != id_locacion):
                    continue
                if id_serie_doc is not None and (record.get("id_serie_doc") != id_serie_doc):
                    continue
                if id_cliente is not None and (record.get("id_cliente") != id_cliente):
                    continue
                if estado is not None and str(record.get("estado") or "").upper() != str(estado).upper():
                    continue
                if num_doc is not None and (record.get("num_doc") != num_doc):
                    continue
                filtered.append(_normalize_guia(record))

            total_count = len(filtered)
            if limit and limit > 0:
                filtered = filtered[skip: skip + limit]
            else:
                filtered = filtered[skip:]

            logger.info("Loaded %s real WCF guías from local SIGECOM snapshot", total_count)
            return {"items": filtered, "total": total_count}
        except Exception as snapshot_error:
            logger.error(f"Failed to load real WCF guías snapshot: {snapshot_error}")
            raise


def get_guia_legacy(id_guia: int | str):
    """Fetch a single guía by id.

    The original SIGECOM WCF data commonly exposes composite identifiers such as
    "83-375-3". Those values are not plain numeric DB IDs, so we resolve against
    the real WCF snapshot using location + series + number when necessary.
    """
    lookup = parse_guia_lookup_id(id_guia)
    fallback_error = None

    try:
        endpoint = f"/api/v1/guias-remision/{id_guia}"
        data = _read_json(build_legacy_url(endpoint))
        if isinstance(data, list):
            if "id_locacion" in lookup:
                for row in data:
                    rec = _normalize_guia(row)
                    if (
                        rec.get("id_locacion") == lookup["id_locacion"]
                        and rec.get("id_serie_doc") == lookup["id_serie_doc"]
                        and rec.get("num_doc") == lookup["num_doc"]
                    ):
                        return rec
            return _normalize_guia(data[0] if data else {})
        return _normalize_guia(data)
    except Exception as e:
        fallback_error = e
        logger.error(f"Failed to get guía {id_guia} from legacy adapter: {e}")

    try:
        if "id_locacion" in lookup:
            rows = _load_real_wcf_guia_rows()
            for row in rows:
                rec = _coerce_wcf_guia_row(row)
                if (
                    rec.get("id_locacion") == lookup["id_locacion"]
                    and rec.get("id_serie_doc") == lookup["id_serie_doc"]
                    and rec.get("num_doc") == lookup["num_doc"]
                ):
                    return _normalize_guia(rec)
    except Exception as snapshot_error:
        logger.error(f"Failed to resolve composite guía {id_guia} from snapshot: {snapshot_error}")

    raise fallback_error or Exception(f"Guía {id_guia} no encontrada")


def parse_guia_lookup_id(raw_id) -> dict:
    """Normalize the legacy guide identifier into the fields used by the backend.

    Legacy SIGECOM IDs are often composite keys formatted as
    "{id_locacion}-{id_serie_doc}-{num_doc}" (for example: "83-375-3").
    """
    if raw_id is None:
        return {}

    value = str(raw_id).strip()
    if not value:
        return {}

    if value.isdigit() or (value.startswith("-") and value[1:].isdigit()):
        return {"id": int(value)}

    parts = [part for part in value.split("-") if part]
    if len(parts) >= 3 and all(part.isdigit() for part in parts[:3]):
        return {
            "id_locacion": int(parts[0]),
            "id_serie_doc": int(parts[1]),
            "num_doc": int(parts[2]),
        }

    return {"legacy_key": value}


def _normalize_guia(guia: dict) -> dict:
    """Normalize guía data to consistent schema."""
    if not guia:
        return {}

    num_fac_value = _lookup_value(guia, "num_fac", "NumFac", "Referencia", "referencia", "Ref", "ref", "num_job", "NumJob")
    num_cot_value = _lookup_value(guia, "num_cot", "NumCot", "Cotizacion", "cotizacion", "Cotiz", "cotiz", "id_cotizacion", "IdCotizacion")
    num_job_value = _lookup_value(guia, "num_job", "NumJob", "NumFac", "num_fac", "Referencia", "referencia", "Ref", "ref")
    id_cotizacion_value = _lookup_value(guia, "id_cotizacion", "IdCotizacion", "NumCot", "num_cot", "Cotizacion", "cotizacion", "Cotiz", "cotiz")

    num_job = str(num_job_value or num_fac_value or "")
    num_fac = str(num_fac_value or "")
    num_cot = _normalize_id(num_cot_value)
    id_cotizacion = _normalize_id(id_cotizacion_value)
    observacion_value = _lookup_value(guia, "observacion", "Observacion", "ObservacionSunat")
    tiene_notas_raw = _lookup_value(guia, "tiene_notas", "TieneNotas", "TieneNota", "TieneObservacion", "tiene_observacion")
    tiene_notas = _normalize_boolean(tiene_notas_raw) if tiene_notas_raw is not None else bool((observacion_value or "").strip())

    normalized = {
        "id": _normalize_id(_lookup_value(guia, "id", "Id")),
        "id_locacion": _normalize_id(_lookup_value(guia, "id_locacion", "IdLocacion")),
        "fec_doc": _normalize_datetime(_lookup_value(guia, "fec_doc", "FecDoc")),
        "id_serie_doc": _normalize_id(_lookup_value(guia, "id_serie_doc", "IdSerieDoc")),
        "num_doc": _normalize_id(_lookup_value(guia, "num_doc", "NumDoc")),
        "id_cliente": _normalize_id(_lookup_value(guia, "id_cliente", "IdCliente")),
        "id_loc_cli": _normalize_id(_lookup_value(guia, "id_loc_cli", "IdLocCli")),
        "id_fiscal": _normalize_id(_lookup_value(guia, "id_fiscal", "IdFiscal")),
        "cod_mot": str(_lookup_value(guia, "cod_mot", "CodMot") or ""),
        "num_job": num_job,
        "num_fac": num_fac,
        "num_cot": num_cot,
        "referencia": num_fac,
        "cotizacion": id_cotizacion,
        "pto_partida": str(_lookup_value(guia, "pto_partida", "PtoPartida") or ""),
        "pto_llegada": str(_lookup_value(guia, "pto_llegada", "PtoLlegada") or ""),
        "cod_mon": str(_lookup_value(guia, "cod_mon", "CodMon") or "US"),
        "igv": _normalize_decimal(_lookup_value(guia, "igv", "IGV")),
        "tip_cambio": _normalize_decimal(_lookup_value(guia, "tip_cambio", "TipCambio")),
        "tot_flete": _normalize_decimal(_lookup_value(guia, "tot_flete", "TotFlete")),
        "tot_embarque": _normalize_decimal(_lookup_value(guia, "tot_embarque", "TotEmbarque")),
        "tot_bruto": _normalize_decimal(_lookup_value(guia, "tot_bruto", "TotBruto")),
        "tot_dscto": _normalize_decimal(_lookup_value(guia, "tot_dscto", "TotDscto")),
        "tot_venta": _normalize_decimal(_lookup_value(guia, "tot_venta", "TotVenta")),
        "tot_igv": _normalize_decimal(_lookup_value(guia, "tot_igv", "TotIGV")),
        "tot_neto": _normalize_decimal(_lookup_value(guia, "tot_neto", "TotNeto")),
        "cliente_nombre": str(_lookup_value(guia, "cliente_nombre", "DesCli", "ClienteNombre") or ""),
        "estado_sunat": str(_lookup_value(guia, "estado_sunat", "EstadoSunat") or ""),
        "cod_serie": str(_lookup_value(guia, "cod_serie", "CodSerie") or ""),
        "tot_neto_sug": _normalize_decimal(_lookup_value(guia, "tot_neto_sug", "TotNetoSug", "TotNeto")),
        "num_orden": str(_lookup_value(guia, "num_orden", "NumOrden", "Orden", "orden") or ""),
        "id_cotizacion": id_cotizacion,
        "observacion": str(observacion_value or ""),
        "tiene_notas": tiene_notas,
        "peso_bruto": _normalize_decimal(_lookup_value(guia, "peso_bruto", "PesoBruto")),
        "cod_uni_med_peso": str(_lookup_value(guia, "cod_uni_med_peso", "CodUniMedPeso") or "KGM"),
        "numero_bultos": _normalize_id(_lookup_value(guia, "numero_bultos", "NumeroBultos")),
        "fec_traslado": _normalize_datetime(_lookup_value(guia, "fec_traslado", "FecTraslado")),
        "cod_modo": str(_lookup_value(guia, "cod_modo", "CodModo") or ""),
        "estado": str(_lookup_value(guia, "estado", "Estado") or ""),
        "created_at": _normalize_datetime(_lookup_value(guia, "created_at", "CreatedAt") or _lookup_value(guia, "fec_doc", "FecDoc")),
        "updated_at": _normalize_datetime(_lookup_value(guia, "updated_at", "UpdatedAt") or _lookup_value(guia, "fec_doc", "FecDoc")),
    }
    # Ensure required totals and id exist for downstream schema compatibility.
    # Fill sensible defaults when legacy adapter omits fields.
    # Do not fabricate business data — prefer conservative fallbacks.
    # Normalize numeric totals
    tot_neto = normalized.get("tot_neto") or 0.0
    if "tot_bruto" not in normalized or normalized.get("tot_bruto") is None:
        normalized["tot_bruto"] = _normalize_decimal(tot_neto) or 0.0
    if "tot_dscto" not in normalized or normalized.get("tot_dscto") is None:
        normalized["tot_dscto"] = 0.0
    if "tot_venta" not in normalized or normalized.get("tot_venta") is None:
        # tot_venta as conservative fallback equals tot_neto
        normalized["tot_venta"] = _normalize_decimal(tot_neto) or 0.0
    if "tot_igv" not in normalized or normalized.get("tot_igv") is None:
        # Use explicit IGV value if present, otherwise default 0.0
        normalized["tot_igv"] = _normalize_decimal(normalized.get("igv")) or 0.0

    # Ensure an `id` is present: use existing id or compose from location/series/number
    if not normalized.get("id"):
        try:
            lid = normalized.get("id_locacion") or ""
            ser = normalized.get("id_serie_doc") or ""
            num = normalized.get("num_doc") or ""
            composed = f"{lid}-{ser}-{num}".strip("-")
            normalized["id"] = composed or None
        except Exception:
            normalized["id"] = None

    # Ensure created_at exists (fallback to document date)
    if not normalized.get("created_at"):
        normalized["created_at"] = normalized.get("fec_doc")

    return {k: v for k, v in normalized.items() if v is not None}


# ============================================================================
# VENTAS / SALES
# ============================================================================

def list_sales_legacy(
    skip: int = 0,
    limit: int = 100,
    tipo: str | None = None,
    estado: str | None = None,
):
    """List sales/invoices from legacy adapter."""
    params = []
    if tipo:
        params.append(("tipo", tipo))
    if estado:
        params.append(("estado", estado))
    if skip:
        params.append(("skip", str(skip)))
    if limit:
        params.append(("limit", str(limit)))

    query = "&".join(f"{k}={v}" for k, v in params)
    endpoint = "/api/v1/sales"
    if query:
        endpoint = f"{endpoint}?{query}"

    try:
        data = _read_json(build_legacy_url(endpoint))
        if isinstance(data, dict) and "items" in data:
            items = data["items"]
        elif isinstance(data, list):
            items = data
        else:
            items = [data] if data else []

        normalized = [_normalize_sale(s) for s in items]
        return normalized if isinstance(data, list) else {"items": normalized, "total": len(normalized)}
    except Exception as e:
        logger.error(f"Failed to list sales from legacy adapter: {e}")
        raise


def get_sale_legacy(sale_id: str | int):
    """Fetch a single sale by id."""
    endpoint = f"/api/v1/sales/{sale_id}"
    try:
        data = _read_json(build_legacy_url(endpoint))
        return _normalize_sale(data)
    except Exception as e:
        logger.error(f"Failed to get sale {sale_id} from legacy adapter: {e}")
        raise


def _normalize_sale(sale: dict) -> dict:
    """Normalize sale/invoice data."""
    if not sale:
        return {}

    # Normalize items if present
    items = []
    for item in sale.get("items") or sale.get("Items") or []:
        items.append({
            "code": str(item.get("code") or item.get("Code") or ""),
            "description": str(item.get("description") or item.get("Description") or ""),
            "unit": str(item.get("unit") or item.get("Unit") or "unidad"),
            "quantity": _normalize_decimal(item.get("quantity") or item.get("Quantity")) or 0,
            "price": _normalize_decimal(item.get("price") or item.get("Price")) or 0,
            "total": _normalize_decimal(item.get("total") or item.get("Total")),
        })

    normalized = {
        "id": _normalize_id(sale.get("id") or sale.get("Id")),
        "type": str(sale.get("type") or sale.get("Type") or sale.get("TipoDocumento") or ""),
        "series": str(sale.get("series") or sale.get("Series") or sale.get("NumSerie") or ""),
        "number": _normalize_id(sale.get("number") or sale.get("Number") or sale.get("NumDoc")),
        "date": _normalize_datetime(sale.get("date") or sale.get("Date") or sale.get("FecDoc")),
        "client_id": _normalize_id(sale.get("client_id") or sale.get("ClientId") or sale.get("IdCliente")),
        "items": items,
        "subtotal": _normalize_decimal(sale.get("subtotal") or sale.get("Subtotal")),
        "tax": _normalize_decimal(sale.get("tax") or sale.get("Tax") or sale.get("IGV")),
        "total": _normalize_decimal(sale.get("total") or sale.get("Total")),
        "status": str(sale.get("status") or sale.get("Status") or sale.get("Estado") or ""),
        "created_at": _normalize_datetime(sale.get("created_at") or sale.get("CreatedAt")),
        "updated_at": _normalize_datetime(sale.get("updated_at") or sale.get("UpdatedAt")),
    }
    return {k: v for k, v in normalized.items() if v is not None}


# ============================================================================
# INVENTARIO / INVENTORY
# ============================================================================

def list_inventory_legacy(
    skip: int = 0,
    limit: int = 100,
    category: str | None = None,
    active: bool | None = None,
):
    """List inventory items from legacy adapter."""
    params = []
    if category:
        params.append(("category", category))
    if active is not None:
        params.append(("active", str(int(active))))
    if skip:
        params.append(("skip", str(skip)))
    if limit:
        params.append(("limit", str(limit)))

    query = "&".join(f"{k}={v}" for k, v in params)
    endpoint = "/api/v1/inventory"
    if query:
        endpoint = f"{endpoint}?{query}"

    try:
        data = _read_json(build_legacy_url(endpoint))
        if isinstance(data, dict) and "items" in data:
            items = data["items"]
        elif isinstance(data, list):
            items = data
        else:
            items = [data] if data else []

        normalized = [_normalize_inventory_item(item) for item in items]
        return normalized if isinstance(data, list) else {"items": normalized, "total": len(normalized)}
    except Exception as e:
        logger.error(f"Failed to list inventory from legacy adapter: {e}")
        raise


def get_inventory_item_legacy(item_id: str | int):
    """Fetch a single inventory item by id."""
    endpoint = f"/api/v1/inventory/{item_id}"
    try:
        data = _read_json(build_legacy_url(endpoint))
        return _normalize_inventory_item(data)
    except Exception as e:
        logger.error(f"Failed to get inventory item {item_id} from legacy adapter: {e}")
        raise


def _normalize_inventory_item(item: dict) -> dict:
    """Normalize inventory item data."""
    if not item:
        return {}

    normalized = {
        "id": _normalize_id(item.get("id") or item.get("Id")),
        "sku": str(item.get("sku") or item.get("SKU") or ""),
        "name": str(item.get("name") or item.get("Name") or ""),
        "description": str(item.get("description") or item.get("Description") or ""),
        "category": str(item.get("category") or item.get("Category") or ""),
        "stock": _normalize_decimal(item.get("stock") or item.get("Stock")) or 0,
        "min_stock": _normalize_decimal(item.get("min_stock") or item.get("MinStock")),
        "supplier": str(item.get("supplier") or item.get("Supplier") or ""),
        "cost_price": _normalize_decimal(item.get("cost_price") or item.get("CostPrice")),
        "sale_price": _normalize_decimal(item.get("sale_price") or item.get("SalePrice")),
        "unit": str(item.get("unit") or item.get("Unit") or "unidad"),
        "active": _normalize_boolean(item.get("active") or item.get("Active")),
        "created_at": _normalize_datetime(item.get("created_at") or item.get("CreatedAt")),
        "updated_at": _normalize_datetime(item.get("updated_at") or item.get("UpdatedAt")),
    }
    return {k: v for k, v in normalized.items() if v is not None}


# ============================================================================
# COMPRAS / PURCHASES
# ============================================================================

def list_purchases_legacy(
    skip: int = 0,
    limit: int = 100,
    estado: str | None = None,
):
    """List purchases from legacy adapter."""
    params = []
    if estado:
        params.append(("estado", estado))
    if skip:
        params.append(("skip", str(skip)))
    if limit:
        params.append(("limit", str(limit)))

    query = "&".join(f"{k}={v}" for k, v in params)
    endpoint = "/api/v1/purchases"
    if query:
        endpoint = f"{endpoint}?{query}"

    try:
        data = _read_json(build_legacy_url(endpoint))
        if isinstance(data, dict) and "items" in data:
            items = data["items"]
        elif isinstance(data, list):
            items = data
        else:
            items = [data] if data else []

        normalized = [_normalize_purchase(p) for p in items]
        return normalized if isinstance(data, list) else {"items": normalized, "total": len(normalized)}
    except Exception as e:
        logger.error(f"Failed to list purchases from legacy adapter: {e}")
        raise


def get_purchase_legacy(purchase_id: str | int):
    """Fetch a single purchase by id."""
    endpoint = f"/api/v1/purchases/{purchase_id}"
    try:
        data = _read_json(build_legacy_url(endpoint))
        return _normalize_purchase(data)
    except Exception as e:
        logger.error(f"Failed to get purchase {purchase_id} from legacy adapter: {e}")
        raise


def _normalize_purchase(purchase: dict) -> dict:
    """Normalize purchase data."""
    if not purchase:
        return {}

    items = []
    for item in purchase.get("items") or purchase.get("Items") or []:
        items.append({
            "code": str(item.get("code") or item.get("Code") or ""),
            "description": str(item.get("description") or item.get("Description") or ""),
            "quantity": _normalize_decimal(item.get("quantity") or item.get("Quantity")) or 0,
            "unit_price": _normalize_decimal(item.get("unit_price") or item.get("UnitPrice")) or 0,
            "total": _normalize_decimal(item.get("total") or item.get("Total")),
        })

    normalized = {
        "id": _normalize_id(purchase.get("id") or purchase.get("Id")),
        "purchase_order": str(purchase.get("purchase_order") or purchase.get("PurchaseOrder") or ""),
        "supplier_id": _normalize_id(purchase.get("supplier_id") or purchase.get("SupplierId")),
        "date": _normalize_datetime(purchase.get("date") or purchase.get("Date")),
        "expected_delivery": _normalize_datetime(purchase.get("expected_delivery") or purchase.get("ExpectedDelivery")),
        "items": items,
        "subtotal": _normalize_decimal(purchase.get("subtotal") or purchase.get("Subtotal")),
        "tax": _normalize_decimal(purchase.get("tax") or purchase.get("Tax")),
        "total": _normalize_decimal(purchase.get("total") or purchase.get("Total")),
        "status": str(purchase.get("status") or purchase.get("Status") or ""),
        "notes": str(purchase.get("notes") or purchase.get("Notes") or ""),
        "created_at": _normalize_datetime(purchase.get("created_at") or purchase.get("CreatedAt")),
        "updated_at": _normalize_datetime(purchase.get("updated_at") or purchase.get("UpdatedAt")),
    }
    return {k: v for k, v in normalized.items() if v is not None}


# ============================================================================
# CAJA CHICA / PETTY CASH
# ============================================================================

def list_caja_chica_legacy(
    skip: int = 0,
    limit: int = 100,
):
    """List petty cash entries from legacy adapter."""
    params = []
    if skip:
        params.append(("skip", str(skip)))
    if limit:
        params.append(("limit", str(limit)))

    query = "&".join(f"{k}={v}" for k, v in params)
    endpoint = "/api/v1/caja-chica"
    if query:
        endpoint = f"{endpoint}?{query}"

    try:
        data = _read_json(build_legacy_url(endpoint))
        if isinstance(data, dict) and "items" in data:
            items = data["items"]
        elif isinstance(data, list):
            items = data
        else:
            items = [data] if data else []

        normalized = [_normalize_caja_chica(c) for c in items]
        return normalized if isinstance(data, list) else {"items": normalized, "total": len(normalized)}
    except Exception as e:
        logger.error(f"Failed to list caja chica from legacy adapter: {e}")
        raise


def get_caja_chica_legacy(caja_id: str | int):
    """Fetch a single petty cash entry by id."""
    endpoint = f"/api/v1/caja-chica/{caja_id}"
    try:
        data = _read_json(build_legacy_url(endpoint))
        return _normalize_caja_chica(data)
    except Exception as e:
        logger.error(f"Failed to get caja chica {caja_id} from legacy adapter: {e}")
        raise


def _normalize_caja_chica(caja: dict) -> dict:
    """Normalize petty cash data."""
    if not caja:
        return {}

    normalized = {
        "id": _normalize_id(caja.get("id") or caja.get("Id")),
        "code": str(caja.get("code") or caja.get("Code") or ""),
        "description": str(caja.get("description") or caja.get("Description") or ""),
        "amount": _normalize_decimal(caja.get("amount") or caja.get("Amount")) or 0,
        "type": str(caja.get("type") or caja.get("Type") or ""),
        "date": _normalize_datetime(caja.get("date") or caja.get("Date")),
        "responsible": str(caja.get("responsible") or caja.get("Responsible") or ""),
        "status": str(caja.get("status") or caja.get("Status") or ""),
        "notes": str(caja.get("notes") or caja.get("Notes") or ""),
        "created_at": _normalize_datetime(caja.get("created_at") or caja.get("CreatedAt")),
        "updated_at": _normalize_datetime(caja.get("updated_at") or caja.get("UpdatedAt")),
    }
    return {k: v for k, v in normalized.items() if v is not None}


# ============================================================================
# JOURNALS / DIARIOS
# ============================================================================

def list_journals_legacy(
    skip: int = 0,
    limit: int = 100,
):
    """List journal entries from legacy adapter."""
    params = []
    if skip:
        params.append(("skip", str(skip)))
    if limit:
        params.append(("limit", str(limit)))

    query = "&".join(f"{k}={v}" for k, v in params)
    endpoint = "/api/v1/journals"
    if query:
        endpoint = f"{endpoint}?{query}"

    try:
        data = _read_json(build_legacy_url(endpoint))
        if isinstance(data, dict) and "items" in data:
            items = data["items"]
        elif isinstance(data, list):
            items = data
        else:
            items = [data] if data else []

        normalized = [_normalize_journal(j) for j in items]
        return normalized if isinstance(data, list) else {"items": normalized, "total": len(normalized)}
    except Exception as e:
        logger.error(f"Failed to list journals from legacy adapter: {e}")
        raise


def get_journal_legacy(journal_id: str | int):
    """Fetch a single journal entry by id."""
    endpoint = f"/api/v1/journals/{journal_id}"
    try:
        data = _read_json(build_legacy_url(endpoint))
        return _normalize_journal(data)
    except Exception as e:
        logger.error(f"Failed to get journal {journal_id} from legacy adapter: {e}")
        raise


def _normalize_journal(journal: dict) -> dict:
    """Normalize journal/accounting entry data."""
    if not journal:
        return {}

    normalized = {
        "id": _normalize_id(journal.get("id") or journal.get("Id")),
        "date": _normalize_datetime(journal.get("date") or journal.get("Date")),
        "description": str(journal.get("description") or journal.get("Description") or ""),
        "account_code": str(journal.get("account_code") or journal.get("AccountCode") or ""),
        "debit": _normalize_decimal(journal.get("debit") or journal.get("Debit")),
        "credit": _normalize_decimal(journal.get("credit") or journal.get("Credit")),
        "reference": str(journal.get("reference") or journal.get("Reference") or ""),
        "created_at": _normalize_datetime(journal.get("created_at") or journal.get("CreatedAt")),
        "updated_at": _normalize_datetime(journal.get("updated_at") or journal.get("UpdatedAt")),
    }
    return {k: v for k, v in normalized.items() if v is not None}


# ============================================================================
# UBICACIONES / LOCATIONS
# ============================================================================

def list_locations_legacy(
    skip: int = 0,
    limit: int = 100,
):
    """List warehouse locations from legacy adapter."""
    params = []
    if skip:
        params.append(("skip", str(skip)))
    if limit:
        params.append(("limit", str(limit)))

    query = "&".join(f"{k}={v}" for k, v in params)
    endpoint = "/api/v1/locations"
    if query:
        endpoint = f"{endpoint}?{query}"

    try:
        data = _read_json(build_legacy_url(endpoint))
        if isinstance(data, dict) and "items" in data:
            items = data["items"]
        elif isinstance(data, list):
            items = data
        else:
            items = [data] if data else []

        normalized = [_normalize_location(loc) for loc in items]
        return normalized if isinstance(data, list) else {"items": normalized, "total": len(normalized)}
    except Exception as e:
        logger.error(f"Failed to list locations from legacy adapter: {e}")
        raise


def get_location_legacy(location_id: str | int):
    """Fetch a single location by id."""
    endpoint = f"/api/v1/locations/{location_id}"
    try:
        data = _read_json(build_legacy_url(endpoint))
        return _normalize_location(data)
    except Exception as e:
        logger.error(f"Failed to get location {location_id} from legacy adapter: {e}")
        raise


def _normalize_location(location: dict) -> dict:
    """Normalize warehouse location data."""
    if not location:
        return {}

    normalized = {
        "id": _normalize_id(location.get("id") or location.get("Id")),
        "code": str(location.get("code") or location.get("Code") or ""),
        "warehouse": str(location.get("warehouse") or location.get("Warehouse") or ""),
        "aisle": str(location.get("aisle") or location.get("Aisle") or ""),
        "shelf": str(location.get("shelf") or location.get("Shelf") or ""),
        "row": str(location.get("row") or location.get("Row") or ""),
        "level": str(location.get("level") or location.get("Level") or ""),
        "description": str(location.get("description") or location.get("Description") or ""),
        "capacity": _normalize_decimal(location.get("capacity") or location.get("Capacity")),
        "occupancy_percent": _normalize_decimal(location.get("occupancy_percent") or location.get("OccupancyPercent")),
        "active": _normalize_boolean(location.get("active") or location.get("Active")),
        "created_at": _normalize_datetime(location.get("created_at") or location.get("CreatedAt")),
        "updated_at": _normalize_datetime(location.get("updated_at") or location.get("UpdatedAt")),
    }
    return {k: v for k, v in normalized.items() if v is not None}


# ============================================================================
# BANCOS / BANKING
# ============================================================================

def list_bank_accounts_legacy(
    skip: int = 0,
    limit: int = 100,
):
    """List bank accounts from legacy adapter."""
    params = []
    if skip:
        params.append(("skip", str(skip)))
    if limit:
        params.append(("limit", str(limit)))

    query = "&".join(f"{k}={v}" for k, v in params)
    endpoint = "/api/v1/bank-accounts"
    if query:
        endpoint = f"{endpoint}?{query}"

    try:
        data = _read_json(build_legacy_url(endpoint))
        if isinstance(data, dict) and "items" in data:
            items = data["items"]
        elif isinstance(data, list):
            items = data
        else:
            items = [data] if data else []

        normalized = [_normalize_bank_account(b) for b in items]
        return normalized if isinstance(data, list) else {"items": normalized, "total": len(normalized)}
    except Exception as e:
        logger.error(f"Failed to list bank accounts from legacy adapter: {e}")
        raise


def list_bank_transactions_legacy(
    account_id: str | int | None = None,
    skip: int = 0,
    limit: int = 100,
):
    """List bank transactions from legacy adapter."""
    params = []
    if account_id:
        params.append(("account_id", str(account_id)))
    if skip:
        params.append(("skip", str(skip)))
    if limit:
        params.append(("limit", str(limit)))

    query = "&".join(f"{k}={v}" for k, v in params)
    endpoint = "/api/v1/bank-transactions"
    if query:
        endpoint = f"{endpoint}?{query}"

    try:
        data = _read_json(build_legacy_url(endpoint))
        if isinstance(data, dict) and "items" in data:
            items = data["items"]
        elif isinstance(data, list):
            items = data
        else:
            items = [data] if data else []

        normalized = [_normalize_bank_transaction(t) for t in items]
        return normalized if isinstance(data, list) else {"items": normalized, "total": len(normalized)}
    except Exception as e:
        logger.error(f"Failed to list bank transactions from legacy adapter: {e}")
        raise


def _normalize_bank_account(account: dict) -> dict:
    """Normalize bank account data."""
    if not account:
        return {}

    normalized = {
        "id": _normalize_id(account.get("id") or account.get("Id")),
        "bank_name": str(account.get("bank_name") or account.get("BankName") or ""),
        "account_number": str(account.get("account_number") or account.get("AccountNumber") or ""),
        "currency": str(account.get("currency") or account.get("Currency") or "USD"),
        "active": _normalize_boolean(account.get("active") or account.get("Active")),
        "created_at": _normalize_datetime(account.get("created_at") or account.get("CreatedAt")),
        "updated_at": _normalize_datetime(account.get("updated_at") or account.get("UpdatedAt")),
    }
    return {k: v for k, v in normalized.items() if v is not None}


def _normalize_bank_transaction(transaction: dict) -> dict:
    """Normalize bank transaction data."""
    if not transaction:
        return {}

    normalized = {
        "id": _normalize_id(transaction.get("id") or transaction.get("Id")),
        "account_id": _normalize_id(transaction.get("account_id") or transaction.get("AccountId")),
        "date": _normalize_datetime(transaction.get("date") or transaction.get("Date")),
        "type": str(transaction.get("type") or transaction.get("Type") or ""),
        "amount": _normalize_decimal(transaction.get("amount") or transaction.get("Amount")) or 0,
        "description": str(transaction.get("description") or transaction.get("Description") or ""),
        "reference": str(transaction.get("reference") or transaction.get("Reference") or ""),
        "balance": _normalize_decimal(transaction.get("balance") or transaction.get("Balance")),
        "created_at": _normalize_datetime(transaction.get("created_at") or transaction.get("CreatedAt")),
        "updated_at": _normalize_datetime(transaction.get("updated_at") or transaction.get("UpdatedAt")),
    }
    return {k: v for k, v in normalized.items() if v is not None}


# ============================================================================
# WSDL INSPECTION (SOAP FALLBACK)
# ============================================================================

def inspect_client_service_wsdl() -> dict:
    """Attempt to load the WSDL for ClienteService and list operations.

    This helper is useful if you want to consume WCF SOAP directly from
    Python using a SOAP client such as `zeep`. It reads the environment
    variable `SIGECOM_WCF_BASE_URL` or falls back to the adapter host's
    base address to construct a likely WSDL URL.

    Returns a dictionary with WSDL URL and available operations, or error info.
    """
    try:
        # import here to avoid requiring zeep unless this helper is used
        from zeep import Client as ZeepClient
        from zeep.exceptions import Error as ZeepError
    except ImportError as exc:
        logger.warning(f"Zeep not installed; WSDL inspection unavailable: {exc}")
        return {
            "error": "zeep_missing",
            "message": f"Zeep is required for WSDL inspection: {exc}",
            "hint": "Install zeep: pip install zeep"
        }

    base = os.getenv("SIGECOM_WCF_BASE_URL")
    if not base:
        # try to derive from the configured adapter host (strip port if present)
        try:
            parts = LEGACY_ADAPTER_BASE_URL.split("://", 1)
            if len(parts) > 1:
                host = parts[1].split(":")[0]
                base = f"http://{host}"
            else:
                base = LEGACY_ADAPTER_BASE_URL
        except Exception:
            base = LEGACY_ADAPTER_BASE_URL

    wsdl_candidates = [
        f"{base.rstrip('/')}/ServicioBLL/ClienteService?wsdl",
        f"{base.rstrip('/')}/ServicioBLL/ClienteService/mex",
        f"{base.rstrip('/')}/ServicioBLL/ClienteService?singleWsdl",
        f"{base.rstrip('/')}/ws/ClienteService?wsdl",
        f"{base.rstrip('/')}/ClienteService?wsdl",
    ]

    last_exc = None
    for wsdl_url in wsdl_candidates:
        try:
            logger.info(f"Attempting to load WSDL from: {wsdl_url}")
            client = ZeepClient(wsdl_url)
            services = []
            for service in client.wsdl.services.values():
                for port in service.ports.values():
                    operations = list(port.binding._operations.keys())
                    services.append({
                        "service": service.name,
                        "port": port.name,
                        "operations": operations
                    })
            logger.info(f"Successfully loaded WSDL from: {wsdl_url}")
            return {
                "status": "success",
                "wsdl": wsdl_url,
                "services": services
            }
        except Exception as e:
            last_exc = f"{type(e).__name__}: {e}"
            logger.debug(f"WSDL candidate failed {wsdl_url}: {last_exc}")
            continue

    logger.error(f"All WSDL candidates failed. Last error: {last_exc}")
    return {
        "error": "wsdl_unreachable",
        "message": f"Could not load WSDL from any candidate. Last error: {last_exc}",
        "candidates": wsdl_candidates,
        "hint": "Ensure SIGECOM_WCF_BASE_URL env var is set correctly, or check the WCF service availability."
    }
    """Attempt to load the WSDL for ClienteService and list operations.

    This helper is useful if you want to consume WCF SOAP directly from
    Python using a SOAP client such as `zeep`. It reads the environment
    variable `SIGECOM_WCF_BASE_URL` or falls back to the adapter host's
    base address to construct a likely WSDL URL.
    """
    try:
        # import here to avoid requiring zeep unless this helper is used
        from zeep import Client as ZeepClient
        from zeep.exceptions import Error as ZeepError
    except Exception as exc:
        return {"error": "zeep_missing", "message": str(exc)}

    base = os.getenv("SIGECOM_WCF_BASE_URL")
    if not base:
        # try to derive from the configured adapter host (strip port if present)
        try:
            base = LEGACY_ADAPTER_BASE_URL.split("://", 1)[1].split(":")[0]
            base = f"http://{base}"
        except Exception:
            base = LEGACY_ADAPTER_BASE_URL

    wsdl_candidates = [
        f"{base.rstrip('/')}/ServicioBLL/ClienteService?wsdl",
        f"{base.rstrip('/')}/ServicioBLL/ClienteService/mex",
        f"{base.rstrip('/')}/ServicioBLL/ClienteService?singleWsdl",
    ]

    for wsdl in wsdl_candidates:
        try:
            client = ZeepClient(wsdl)
            services = []
            for service in client.wsdl.services.values():
                for port in service.ports.values():
                    operations = list(port.binding._operations.keys())
                    services.append({"service": service.name, "port": port.name, "operations": operations})
            return {"wsdl": wsdl, "services": services}
        except ZeepError as ze:
            # try next candidate
            last_exc = str(ze)
        except Exception as e:
            last_exc = str(e)

    return {"error": "wsdl_unreachable", "message": last_exc, "candidates": wsdl_candidates}
