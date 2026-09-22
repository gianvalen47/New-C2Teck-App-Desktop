import json
from pathlib import Path

BASE = Path(__file__).resolve().parent.parent
OUT_JSON = BASE / 'tmp' / 'guias_raw.json'
OUT_CSV = BASE / 'tmp' / 'guias_all.csv'
OUT_JSON.parent.mkdir(parents=True, exist_ok=True)

try:
    # try to use configured legacy adapter via import to avoid network issues
    from backend import legacy_adapter
    print('Using legacy_adapter.list_guias_legacy() (may call HTTP adapter or snapshot)')
    items = legacy_adapter.list_guias_legacy(limit=0, company_codes=None)
    # legacy_adapter returns dict {'items':..., 'total':...} when not list
    if isinstance(items, dict) and 'items' in items:
        items = items['items']
except Exception as e:
    print('fallback: adapter call failed, trying direct HTTP')
    try:
        import requests
        from backend.config import SIGECOM_LEGACY_ADAPTER_BASE_URL as BASE_URL
        url = BASE_URL + '/api/v1/guias-remision?limit=0'
        print('Requesting', url)
        r = requests.get(url, timeout=10)
        r.raise_for_status()
        items = r.json()
        if isinstance(items, dict) and 'items' in items:
            items = items['items']
    except Exception as e2:
        print('Both adapter import and HTTP failed:', e2)
        items = []

# normalize items to list of dict
if items is None:
    items = []

# write raw json
with open(OUT_JSON, 'w', encoding='utf-8') as f:
    json.dump(items, f, ensure_ascii=False, indent=2)

# gather all keys
all_keys = set()
for it in items:
    if isinstance(it, dict):
        all_keys.update(it.keys())

all_keys = sorted(all_keys)

# write CSV
if items:
    import csv
    with open(OUT_CSV, 'w', newline='', encoding='utf-8') as f:
        writer = csv.writer(f)
        writer.writerow(all_keys)
        for it in items:
            row = [it.get(k, '') if isinstance(it, dict) else '' for k in all_keys]
            writer.writerow(row)

print('Wrote', len(items), 'items to', OUT_JSON, 'and', OUT_CSV)
