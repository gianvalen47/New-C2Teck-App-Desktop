import sqlite3
import json
from pathlib import Path
from collections import Counter, defaultdict

DB = Path(__file__).resolve().parent.parent / "empresa.db"

def fetch_rows():
    conn = sqlite3.connect(str(DB))
    conn.row_factory = sqlite3.Row
    cur = conn.cursor()
    cur.execute("SELECT * FROM guias_remision")
    rows = [dict(r) for r in cur.fetchall()]
    conn.close()
    return rows


def top_counts(values, n=10):
    c = Counter(values)
    total = sum(c.values())
    items = c.most_common(n)
    return [{'value': k, 'count': v, 'pct': round(v/total*100,2)} for k,v in items]


def analyze(rows):
    if not rows:
        return {'error':'no rows'}
    cols = list(rows[0].keys())
    stats = {}
    for col in cols:
        vals = [r[col] for r in rows]
        nulls = sum(1 for v in vals if v is None or (isinstance(v,str) and v.strip()==""))
        distinct = len(set(v for v in vals if v is not None and not (isinstance(v,str) and v.strip()=="")))
        stats[col] = {
            'nulls': nulls,
            'distinct': distinct,
            'total': len(vals),
            'top': top_counts([v if v is not None else None for v in vals], n=10)
        }
    return stats


def find_bimodal_candidates(stats, rows_count, threshold_low=30, threshold_high=70):
    # columns where top value occupies between threshold_low and threshold_high percent
    candidates = []
    for col, s in stats.items():
        if not s['top']:
            continue
        top_pct = s['top'][0]['pct']
        if threshold_low <= top_pct <= threshold_high:
            candidates.append((col, top_pct, s['top'][0]))
    # sort by how close to 50% the top pct is
    candidates.sort(key=lambda x: abs(x[1]-50))
    return candidates


def keyword_scan(rows, keywords):
    hits = defaultdict(int)
    samples = defaultdict(list)
    for r in rows:
        text = ' '.join(str(r.get(c) or '') for c in ['observacion','cliente_nombre','pto_partida','pto_llegada','num_orden'])
        for kw in keywords:
            if kw.lower() in text.lower():
                hits[kw]+=1
                if len(samples[kw])<5:
                    samples[kw].append(text)
    return {k: {'count': v, 'samples': samples[k]} for k,v in hits.items()}


def main():
    rows = fetch_rows()
    stats = analyze(rows)
    candidates = find_bimodal_candidates(stats, len(rows))
    keywords = ['C2TECK','C2TECK S.A.C','EQUIMAP','EQUIMAP S.A.C','EQUIMAP']
    kw_hits = keyword_scan(rows, keywords)

    out = {
        'rows_total': len(rows),
        'columns_analyzed': len(stats),
        'stats': stats,
        'bimodal_candidates': [{'column':c,'top_pct':p,'top_value':tv} for c,p,tv in candidates],
        'keyword_hits': kw_hits
    }
    print(json.dumps(out, ensure_ascii=False, indent=2))

if __name__=='__main__':
    main()
