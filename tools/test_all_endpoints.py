"""
Script para consultar y ver los datos de todos los endpoints de la API de SIGECOM.
Uso:
    python tools/test_all_endpoints.py            -> Lista todos los endpoints y prueba los GET
    python tools/test_all_endpoints.py facturas   -> Muestra todos los datos de Facturas
    python tools/test_all_endpoints.py guias      -> Muestra todos los datos de Guías de Remisión
"""
import sys
import json
import urllib.request
import urllib.error

if hasattr(sys.stdout, "reconfigure"):
    sys.stdout.reconfigure(encoding="utf-8", errors="replace")

BASE_URL = "http://127.0.0.1:8000"
HEADERS = {
    "X-Sigecoom-CodEmp": "08",
    "Accept": "application/json"
}

def get(path: str):
    url = f"{BASE_URL}{path}"
    req = urllib.request.Request(url, headers=HEADERS)
    try:
        with urllib.request.urlopen(req, timeout=10) as resp:
            data = resp.read().decode("utf-8")
            return resp.status, json.loads(data) if data else None
    except urllib.error.HTTPError as e:
        body = e.read().decode("utf-8")
        try:
            return e.code, json.loads(body)
        except Exception:
            return e.code, body
    except Exception as e:
        return 500, str(e)

def main():
    arg = sys.argv[1].lower() if len(sys.argv) > 1 else ""

    if arg in ("facturas", "factura"):
        print("=" * 70)
        print("DATOS REALES: /api/v1/facturas?anio=2026")
        print("=" * 70)
        status, data = get("/api/v1/facturas?anio=2026")
        print(f"Status: {status} | Registros: {len(data) if isinstance(data, list) else 'N/A'}")
        print(json.dumps(data, indent=2, ensure_ascii=False))
        return

    if arg in ("guias", "guias-remision"):
        print("=" * 70)
        print("DATOS REALES: /api/v1/guias-remision?limit=20")
        print("=" * 70)
        status, data = get("/api/v1/guias-remision?limit=20")
        print(f"Status: {status} | Registros: {len(data) if isinstance(data, list) else 'N/A'}")
        print(json.dumps(data, indent=2, ensure_ascii=False))
        return

    # Listar y probar todos los endpoints GET desde openapi.json
    try:
        status, openapi = get("/openapi.json")
    except Exception as e:
        print(f"No se pudo conectar a {BASE_URL}: {e}")
        return

    paths = openapi.get("paths", {})
    print("=" * 80)
    print(f"ESTADO DE TODOS LOS ENDPOINTS (Total registrados: {len(paths)})")
    print("=" * 80)

    for path, methods in sorted(paths.items()):
        if "get" not in methods:
            continue
        
        # Saltar endpoints que requieren parámetros en la ruta como {id}
        if "{" in path:
            print(f"GET  {path:<45} (Requiere ID)")
            continue

        query = ""
        if path == "/api/v1/facturas":
            query = "?anio=2026"
        elif path == "/api/v1/guias-remision":
            query = "?limit=5"

        st, res = get(f"{path}{query}")
        count = len(res) if isinstance(res, list) else (1 if isinstance(res, dict) else 0)
        print(f"GET  {path + query:<45} -> Status: {st} | Filas: {count}")

if __name__ == "__main__":
    main()
