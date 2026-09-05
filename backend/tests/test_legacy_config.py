import importlib
import os


def reload_legacy_adapter():
    import legacy_adapter
    return importlib.reload(legacy_adapter)


def test_legacy_source_defaults_to_legacy_mode(monkeypatch):
    monkeypatch.delenv("SIGECOM_DATA_SOURCE", raising=False)
    monkeypatch.delenv("SIGECOM_LEGACY_ADAPTER_BASE_URL", raising=False)

    legacy = reload_legacy_adapter()

    assert legacy.is_legacy_source_enabled() is True
    assert legacy.LEGACY_ADAPTER_BASE_URL == "http://170.231.82.58:8443"
