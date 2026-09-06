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
