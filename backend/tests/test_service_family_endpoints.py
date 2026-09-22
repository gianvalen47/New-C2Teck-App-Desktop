import importlib
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
if str(ROOT) not in sys.path:
    sys.path.insert(0, str(ROOT))


def test_service_family_modules_exist():
    for name in ["boletas", "sunat", "seguridad"]:
        module = importlib.import_module(f"routers.{name}")
        assert hasattr(module, "router")
