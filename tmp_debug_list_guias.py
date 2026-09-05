from backend.legacy_adapter import list_guias_legacy
import json, traceback

try:
    items = list_guias_legacy(limit=1)
    print('TYPE:', type(items))
    if isinstance(items, list):
        print('LENGTH:', len(items))
        if items:
            print(json.dumps(items[0], indent=2, default=str, ensure_ascii=False))
    else:
        print(json.dumps(items, indent=2, default=str, ensure_ascii=False))
except Exception as e:
    print('EXCEPTION:', type(e).__name__, str(e))
    traceback.print_exc()
