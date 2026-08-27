import os
import re
root = r"SIGECOM\\SIGECOM"
pattern = re.compile(r"(?:Friend|Private|Protected|Public)\s+WithEvents\s+(\w+)\s+As\s+System\.Windows\.Forms\.ToolStripButton", re.IGNORECASE)
report = []
all_buttons = []
for dirpath, dirnames, filenames in os.walk(root):
    for fn in filenames:
        if fn.lower().endswith('.designer.vb'):
            path = os.path.join(dirpath, fn)
            try:
                text = open(path, 'r', encoding='utf-8', errors='ignore').read()
            except Exception:
                continue
            names = sorted(set(pattern.findall(text)))
            if names:
                report.append((path, names))
                all_buttons.extend(names)
report.sort()
unique_buttons = sorted(set(all_buttons))
print('TOTAL_FORMS_WITH_TOOLSTRIPBUTTONS:', len(report))
print('TOTAL_BUTTON_INSTANCES:', len(all_buttons))
print('TOTAL_UNIQUE_BUTTON_NAMES:', len(unique_buttons))
for path, names in report:
    print(path)
    print('  count=', len(names))
    print('  ', ', '.join(names))
print('UNIQUE BUTTON NAMES:')
print(', '.join(unique_buttons))
