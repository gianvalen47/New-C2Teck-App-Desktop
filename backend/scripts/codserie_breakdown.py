import json
from pathlib import Path
from collections import Counter

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

for serie in ('T010','T001'):
    c = Counter()
    for r in rows:
        if (r.get('CodSerie') or '').upper() == serie:
            c[(r.get('DesCli') or '').strip()] += 1
    print('\nTop customers for', serie, ':')
    for k,v in c.most_common(10):
        print(v, k)
