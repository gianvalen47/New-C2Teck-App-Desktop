import sqlite3
import json
from pathlib import Path

DB = Path(__file__).resolve().parent.parent / "empresa.db"
out = {"groups": [], "total": 0}
try:
    conn = sqlite3.connect(str(DB))
    cur = conn.cursor()
    cur.execute("SELECT cod_emp, COUNT(*) FROM guias_remision GROUP BY cod_emp")
    rows = cur.fetchall()
    out['groups'] = [{'cod_emp': r[0], 'count': r[1]} for r in rows]
    cur.execute("SELECT COUNT(*) FROM guias_remision")
    out['total'] = cur.fetchone()[0]
except Exception as e:
    out = {'error': str(e)}
finally:
    try:
        conn.close()
    except:
        pass

print(json.dumps(out, ensure_ascii=False, indent=2))
