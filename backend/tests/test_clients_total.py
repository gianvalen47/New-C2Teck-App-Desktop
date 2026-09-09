import sys
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parents[1]))

import legacy_adapter


def test_list_guias_legacy_uses_real_wcf_snapshot_when_adapter_is_down(monkeypatch):
    def fake_fail(url, timeout=8):
        raise OSError("adapter unavailable")

    monkeypatch.setattr(legacy_adapter, "_read_json", fake_fail)

    result = legacy_adapter.list_guias_legacy(id_cliente=57558, limit=50)

    assert result["total"] == 4
    assert [row["num_doc"] for row in result["items"]] == [3, 4, 5, 6]
    assert [row["cliente_nombre"] for row in result["items"]] == ["RIOS ROSALES CARLOS"] * 4


def test_list_clients_legacy_loads_all_pages_when_limit_zero(monkeypatch):
    responses = [
        {"items": [{"id": "1", "name": "A"}, {"id": "2", "name": "B"}, {"id": "3", "name": "C"}]},
        {"items": []},
    ]
    seen = []

    def fake_read_json(url, timeout=8):
        seen.append(url)
        return responses.pop(0)

    monkeypatch.setattr(legacy_adapter, "_read_json", fake_read_json)

    result = legacy_adapter.list_clients_legacy(skip=0, limit=0)

    assert result["total"] == 3
    assert [item["id"] for item in result["items"]] == ["1", "2", "3"]
    assert len(seen) == 1


def test_parse_guia_lookup_id_supports_composite_legacy_ids():
    assert legacy_adapter.parse_guia_lookup_id("83-375-3") == {
        "id_locacion": 83,
        "id_serie_doc": 375,
        "num_doc": 3,
    }
    assert legacy_adapter.parse_guia_lookup_id("3") == {"id": 3}


def test_get_guia_legacy_falls_back_to_local_sqlite_details(monkeypatch):
    def fake_fail(url, timeout=8):
        raise OSError("adapter unavailable")

    monkeypatch.setattr(legacy_adapter, "_read_json", fake_fail)

    result = legacy_adapter.get_guia_legacy("1-1-6")

    assert result["id_locacion"] == 1
    assert result["num_doc"] == 6
    assert result["detalles"][0]["cod_mer"] == "PROD-001"
    assert result["detalles"][0]["des_mer"] == "Servicio de instalación"
