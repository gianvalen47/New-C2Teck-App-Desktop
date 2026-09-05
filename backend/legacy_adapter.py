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
from urllib.error import HTTPError, URLError
from urllib.request import Request, urlopen

# Setup logging
logger = logging.getLogger(__name__)

LEGACY_ADAPTER_BASE_URL = os.getenv(
    "SIGECOM_LEGACY_ADAPTER_BASE_URL",
    "http://localhost:5041",
).rstrip("/")

SIGECOM_DATA_SOURCE = os.getenv("SIGECOM_DATA_SOURCE", "legacy").lower()


def is_legacy_source_enabled() -> bool:
    return SIGECOM_DATA_SOURCE in {"legacy", "sigecoom", "adapter", "wcf", "original"}


def build_legacy_url(path: str) -> str:
    return f"{LEGACY_ADAPTER_BASE_URL}{path}"


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


def legacy_health() -> dict:
    """Check if legacy adapter is healthy."""
    try:
        url = build_legacy_url("/health")
        result = _read_json(url)
        logger.info("Legacy adapter health check: OK")
        return result
    except Exception as e:
        logger.warning(f"Legacy adapter health check failed: {e}")
        return {"status": "unavailable", "error": str(e)}


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

        normalized = [_normalize_guia(g) for g in items]
        return normalized if isinstance(data, list) else {"items": normalized, "total": len(normalized)}
    except Exception as e:
        logger.error(f"Failed to list guías from legacy adapter: {e}")
        raise


def get_guia_legacy(id_guia: int | str):
    """Fetch a single guía by id."""
    endpoint = f"/api/v1/guias-remision/{id_guia}"
    try:
        data = _read_json(build_legacy_url(endpoint))
        return _normalize_guia(data)
    except Exception as e:
        logger.error(f"Failed to get guía {id_guia} from legacy adapter: {e}")
        raise


def _normalize_guia(guia: dict) -> dict:
    """Normalize guía data to consistent schema."""
    if not guia:
        return {}

    normalized = {
        "id": _normalize_id(guia.get("id") or guia.get("Id")),
        "id_locacion": _normalize_id(guia.get("id_locacion") or guia.get("IdLocacion")),
        "fec_doc": _normalize_datetime(guia.get("fec_doc") or guia.get("FecDoc")),
        "id_serie_doc": _normalize_id(guia.get("id_serie_doc") or guia.get("IdSerieDoc")),
        "num_doc": _normalize_id(guia.get("num_doc") or guia.get("NumDoc")),
        "id_cliente": _normalize_id(guia.get("id_cliente") or guia.get("IdCliente")),
        "id_loc_cli": _normalize_id(guia.get("id_loc_cli") or guia.get("IdLocCli")),
        "id_fiscal": _normalize_id(guia.get("id_fiscal") or guia.get("IdFiscal")),
        "cod_mot": str(guia.get("cod_mot") or guia.get("CodMot") or ""),
        "num_job": str(guia.get("num_job") or guia.get("NumJob") or ""),
        "pto_partida": str(guia.get("pto_partida") or guia.get("PtoPartida") or ""),
        "pto_llegada": str(guia.get("pto_llegada") or guia.get("PtoLlegada") or ""),
        "cod_mon": str(guia.get("cod_mon") or guia.get("CodMon") or "US"),
        "igv": _normalize_decimal(guia.get("igv") or guia.get("IGV")),
        "tip_cambio": _normalize_decimal(guia.get("tip_cambio") or guia.get("TipCambio")),
        "tot_flete": _normalize_decimal(guia.get("tot_flete") or guia.get("TotFlete")),
        "tot_embarque": _normalize_decimal(guia.get("tot_embarque") or guia.get("TotEmbarque")),
        "tot_bruto": _normalize_decimal(guia.get("tot_bruto") or guia.get("TotBruto")),
        "tot_dscto": _normalize_decimal(guia.get("tot_dscto") or guia.get("TotDscto")),
        "tot_venta": _normalize_decimal(guia.get("tot_venta") or guia.get("TotVenta")),
        "tot_igv": _normalize_decimal(guia.get("tot_igv") or guia.get("TotIGV")),
        "tot_neto": _normalize_decimal(guia.get("tot_neto") or guia.get("TotNeto")),
        "num_orden": str(guia.get("num_orden") or guia.get("NumOrden") or ""),
        "id_cotizacion": _normalize_id(guia.get("id_cotizacion") or guia.get("IdCotizacion")),
        "observacion": str(guia.get("observacion") or guia.get("Observacion") or ""),
        "peso_bruto": _normalize_decimal(guia.get("peso_bruto") or guia.get("PesoBruto")),
        "cod_uni_med_peso": str(guia.get("cod_uni_med_peso") or guia.get("CodUniMedPeso") or "KGM"),
        "numero_bultos": _normalize_id(guia.get("numero_bultos") or guia.get("NumeroBultos")),
        "fec_traslado": _normalize_datetime(guia.get("fec_traslado") or guia.get("FecTraslado")),
        "cod_modo": str(guia.get("cod_modo") or guia.get("CodModo") or ""),
        "estado": str(guia.get("estado") or guia.get("Estado") or ""),
        "created_at": _normalize_datetime(guia.get("created_at") or guia.get("CreatedAt")),
        "updated_at": _normalize_datetime(guia.get("updated_at") or guia.get("UpdatedAt")),
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
