import json
from pathlib import Path
from collections import Counter, defaultdict
import csv

SNAP = Path(__file__).resolve().parents[2] / 'sigecoom-wcf-client' / 'salida.json'
OUT_CSV = Path(__file__).resolve().parents[1] / 'tmp' / 'guias_snapshot.csv'
OUT_SUM = Path(__file__).resolve().parents[1] / 'tmp' / 'guias_snapshot_summary.json'
OUT_CSV.parent.mkdir(parents=True, exist_ok=True)

raw = SNAP.read_bytes()
text = None
for enc in ('utf-8', 'utf-16', 'utf-16-le', 'utf-16-be'):
    try:
        text = raw.decode(enc)
        break
    except Exception:
        continue
if text is None:
    raise SystemExit('Unable to decode snapshot file')
start = text.find('[')
end = text.rfind(']')
if start == -1 or end == -1 or end <= start:
    raise SystemExit('No JSON array found in snapshot')
payload = json.loads(text[start:end+1])
rows = []
if isinstance(payload, list):
    for item in payload:
        if isinstance(item, dict):
            rows.extend(item.get('rows') or [])
elif isinstance(payload, dict):
    rows.extend(payload.get('rows') or [])

# gather keys
all_keys = set()
for r in rows:
    if isinstance(r, dict):
        all_keys.update(r.keys())
all_keys = sorted(all_keys)

# write csv
with open(OUT_CSV, 'w', newline='', encoding='utf-8') as f:
    writer = csv.writer(f)
    writer.writerow(all_keys)
    for r in rows:
        writer.writerow([r.get(k, '') for k in all_keys])

# summary counts for DesCli and CodSerie and CodMon and IdLocacion
cnt_descli = Counter()
cnt_codserie = Counter()
cnt_codmon = Counter()
cnt_idloc = Counter()
for r in rows:
    cnt_descli[r.get('DesCli') or r.get('descli') or r.get('cliente_nombre') or ''] += 1
    cnt_codserie[r.get('CodSerie') or r.get('cod_serie') or ''] += 1
    cnt_codmon[r.get('CodMon') or r.get('cod_mon') or ''] += 1
    cnt_idloc[r.get('IdLocacion') or r.get('id_locacion') or ''] += 1

summary = {
    'total_rows': len(rows),
    'top_descli': cnt_descli.most_common(30),
    'top_codserie': cnt_codserie.most_common(30),
    'top_codmon': cnt_codmon.most_common(30),
    'top_idlocacion': cnt_idloc.most_common(30),
}

with open(OUT_SUM, 'w', encoding='utf-8') as f:
    json.dump(summary, f, ensure_ascii=False, indent=2)

print('Wrote', len(rows), 'rows to', OUT_CSV)
print('Summary at', OUT_SUM)
