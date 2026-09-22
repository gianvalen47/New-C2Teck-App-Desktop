import sqlite3
from pathlib import Path
import json
DB = Path(__file__).resolve().parent.parent / "empresa.db"
try:
    conn = sqlite3.connect(str(DB))
    cur = conn.cursor()
    cur.execute("PRAGMA table_info('guias_remision')")
    cols = cur.fetchall()
    cur.execute("SELECT * FROM guias_remision LIMIT 5")
    rows = cur.fetchall()
    out = {
        'columns': [{'cid': c[0], 'name': c[1], 'type': c[2], 'notnull': c[3], 'dflt_value': c[4], 'pk': c[5]} for c in cols],
        'sample_rows_count': len(rows),
        'sample_rows': rows
    }
except Exception as e:
    out = {'error': str(e)}
finally:
    try:
        conn.close()
    except:
        pass
print(json.dumps(out, ensure_ascii=False, indent=2))
