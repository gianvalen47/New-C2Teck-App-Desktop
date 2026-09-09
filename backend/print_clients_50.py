import requests, json
r = requests.get('http://127.0.0.1:8001/api/v1/clients?limit=50')
print('STATUS', r.status_code)
j = r.json()
items = j.get('items', [])
print('COUNT', len(items))
for i, it in enumerate(items, 1):
    name = it.get('name') or it.get('descripcion') or it.get('des') or ''
    ruc = it.get('ruc') or it.get('R.U.C') or ''
    print(f"{i:02d}. {name} — {ruc}")
