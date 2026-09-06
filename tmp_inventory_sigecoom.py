import os, re, glob
root = r'C:\Users\Giancarlo\new-c2teck-app-desktop\SIGECOM\SIGECOM\Service References'
files = glob.glob(os.path.join(root, '**', 'configuration91.svcinfo'), recursive=True)
entries = []
seen = set()
for f in files:
    txt = open(f, 'r', encoding='utf-8', errors='ignore').read()
    for m in re.finditer(r'<endpoint\s+name="([^"]+)"\s+contract="([^"]+)"\s+bindingType="([^"]+)"\s+address="([^"]+)"', txt):
        name, contract, binding, address = m.groups()
        if address not in seen:
            seen.add(address)
            entries.append({
                'address': address,
                'name': name,
                'contract': contract,
                'bindingType': binding,
                'file': os.path.relpath(f, r'C:\Users\Giancarlo\new-c2teck-app-desktop'),
            })
entries.sort(key=lambda x: x['address'])
print('TOTAL_ENDPOINTS', len(entries))
for e in entries:
    print(f"{e['address']} | {e['name']} | {e['contract']} | {e['bindingType']} | {e['file']}")
