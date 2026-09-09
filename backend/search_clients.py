import requests

names_to_find = ["PUBLICO GENERAL", "MATA DAVILA JOSEP", "LUCERO RAMIREZ"]

r = requests.get('http://127.0.0.1:8001/api/v1/clients?limit=1000')
if r.status_code != 200:
    print('ERROR', r.status_code, r.text)
    raise SystemExit(1)

j = r.json()
items = j.get('items', [])
found = {n: [] for n in names_to_find}

for i, it in enumerate(items, 1):
    name = (it.get('name') or it.get('descripcion') or '').upper()
    for n in names_to_find:
        if n in name:
            found[n].append((i, it.get('name'), it.get('ruc')))

print('TOTAL ITEMS CHECKED:', len(items))
for n in names_to_find:
    entries = found[n]
    if entries:
        print(f"\nFound '{n}' {len(entries)} time(s):")
        for idx, nm, ruc in entries:
            print(f"  - #{idx}: {nm} — {ruc}")
    else:
        print(f"\nNot found: '{n}'")
