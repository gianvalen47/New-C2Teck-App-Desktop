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

# counts of CodSerie overall and for EQUIMAP/C2TECK
codserie_all = Counter()
codserie_equimap = Counter()
loc_equimap = Counter()
codserie_c2teck = Counter()
loc_c2teck = Counter()

def norm(s):
    return (s or '').strip().upper()

for r in rows:
    cs = norm(r.get('CodSerie') or r.get('CodSerie'.lower()))
    codserie_all[cs]+=1
    des = norm(r.get('DesCli') or '')
    if 'EQUIMAP' in des:
        codserie_equimap[cs]+=1
        loc_equimap[r.get('IdLocacion')] += 1
    if 'C2TECK' in des or 'C2 TECK' in des or 'C2TEK' in des:
        codserie_c2teck[cs]+=1
        loc_c2teck[r.get('IdLocacion')] += 1

print('Top CodSerie overall:', codserie_all.most_common(10))
print('\nEQUIMAP counts by CodSerie:', codserie_equimap.most_common())
print('EQUIMAP counts by IdLocacion:', loc_equimap.most_common())
print('\nC2TECK counts by CodSerie:', codserie_c2teck.most_common())
print('C2TECK counts by IdLocacion:', loc_c2teck.most_common())

# Also show examples of DesCli matching EQUIMAP
examples = [r for r in rows if 'EQUIMAP' in norm(r.get('DesCli') or '')][:10]
for ex in examples:
    print('\nExample:', ex.get('IdGuia'), ex.get('DesCli'), ex.get('CodSerie'), ex.get('IdLocacion'))
