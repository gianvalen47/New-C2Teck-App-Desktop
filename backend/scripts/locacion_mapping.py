import json
from pathlib import Path
from collections import Counter, defaultdict

SNAP = Path(__file__).resolve().parents[2] / 'sigecoom-wcf-client' / 'salida.json'
raw = SNAP.read_bytes()
text = None
for enc in ('utf-8','utf-16','utf-16-le','utf-16-be'):
    try:
        text = raw.decode(enc)
        break
    except Exception:
        continue
start = text.find('[')
end = text.rfind(']')
payload = json.loads(text[start:end+1])
rows = []
for item in payload:
    if isinstance(item, dict):
        rows.extend(item.get('rows') or [])

by_loc = defaultdict(Counter)
for r in rows:
    loc = r.get('IdLocacion')
    des = (r.get('DesCli') or '').strip()
    by_loc[loc][des]+=1

out = {loc: by_loc[loc].most_common(5) for loc in sorted(by_loc.keys())}
print(json.dumps({'loc_map': out}, ensure_ascii=False, indent=2))
