"""Consulta de Guías de Remisión desde Python usando la API legacy de SIGECOM.

Ubicación original del servicio VB.NET:
- SIGECOM/SIGECOM/Service References/GuiaRemisionService/Reference.svcmap
- SIGECOM/SIGECOM/app.config
- Endpoint real: net.tcp://192.168.10.252/ServicioBLL/GuiaRemisionService/

Puente HTTP disponible en este workspace:
- sigecoom-wcf-adapter/Controllers/GuiasRemisionController.cs
- Endpoint expuesto: GET /api/v1/guias-remision

Este script intenta consumir la API HTTP del adaptador, que a su vez llama al servicio WCF
legacy de SIGECOM para devolver los mismos datos que la app VB.NET.
"""

from __future__ import annotations

import json
import os
from typing import Any
from urllib import error, request

DEFAULT_URL = os.getenv(
    "SIGECOM_GUIAS_URL",
    "http://170.231.82.58:8443/api/v1/guias-remision?limit=10",
)


def fetch_guia_json(url: str = DEFAULT_URL) -> Any:
    """Llama a la API del adaptador y devuelve el JSON de respuesta."""
    req = request.Request(url, headers={"Accept": "application/json"})
    with request.urlopen(req, timeout=15) as response:
        body = response.read().decode("utf-8")
        return json.loads(body)


def print_guia_rows(data: Any) -> None:
    if isinstance(data, list):
        rows = data
    elif isinstance(data, dict) and isinstance(data.get("items"), list):
        rows = data["items"]
    elif isinstance(data, dict):
        rows = [data]
    else:
        rows = []

    print(f"Se encontraron {len(rows)} registros.")
    for idx, row in enumerate(rows[:10], start=1):
        print(f"\n--- Registro {idx} ---")
        for key, value in row.items():
            print(f"{key}: {value}")


if __name__ == "__main__":
    print("Consultando API SIGECOM (Guías de Remisión)...")
    print(f"URL: {DEFAULT_URL}")
    try:
        payload = fetch_guia_json(DEFAULT_URL)
        print_guia_rows(payload)
    except error.HTTPError as exc:
        print(f"HTTPError: {exc.code} - {exc.reason}")
        try:
            detail = exc.read().decode("utf-8", errors="ignore")
            print(detail[:500])
        except Exception:
            pass
    except error.URLError as exc:
        print("ERROR: no se pudo conectar al adaptador SIGECOM legacy.")
        print(f"Detalle: {exc.reason}")
        print("\nVerifica que el servicio .NET del adaptador esté levantado:")
        print("- sigecoom-wcf-adapter")
        print("- endpoint esperado: http://170.231.82.58:8443/api/v1/guias-remision")
        print("- o que el servicio WCF original responda en: net.tcp://192.168.10.252/ServicioBLL/GuiaRemisionService/")
    except Exception as exc:  # pragma: no cover - diagnóstico
        print(f"ERROR inesperado: {type(exc).__name__}: {exc}")
