import sys
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parents[1]))

import legacy_adapter


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
