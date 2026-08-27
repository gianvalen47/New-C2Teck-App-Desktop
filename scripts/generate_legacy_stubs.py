#!/usr/bin/env python3
"""
Genera stubs React TSX y copia recursos legacy desde
`SIGECOM/SIGECOM/Interfaces` hacia
`src/features/escritorio/windows/legacy/...`.

Uso: ejecutar desde la raíz del repo:
  python scripts/generate_legacy_stubs.py

Nota: sobrescribe archivos en destino si ya existen.
"""
import shutil
from pathlib import Path
import sys

ROOT = Path(__file__).resolve().parent.parent
SRC_ROOT = ROOT / 'src' / 'features' / 'escritorio' / 'windows' / 'legacy'
SIGECOM_IFACES = ROOT / 'SIGECOM' / 'SIGECOM' / 'Interfaces'

COPY_EXTS = {'.vb', '.resx', '.xml', '.rpt'}

def make_tsx_stub(target_dir: Path, original_rel: Path, vb_name: str):
    """Create a minimal TSX stub file referencing the legacy file."""
    comp_name = vb_name
    tsx_path = target_dir / (vb_name + '.tsx')
    rel_path = Path('.') / original_rel
    content = f"""// Auto-generated stub for legacy form
// Original: {rel_path.as_posix()}
import React from 'react'

export default function {comp_name}() {{
  return (
    <div style={{padding:20}}>
      <h2>Legacy form: {vb_name}</h2>
      <p>Original file copied to: <code>{rel_path.as_posix()}</code></p>
      <p>This component is a placeholder. Implement React UI here.</p>
    </div>
  )
}}
"""
    tsx_path.write_text(content, encoding='utf-8')

def main():
    if not SIGECOM_IFACES.exists():
        print(f"ERROR: source interfaces folder not found: {SIGECOM_IFACES}")
        sys.exit(1)

    files_processed = 0
    stubs_created = 0

    for src_path in SIGECOM_IFACES.rglob('*'):
        if src_path.is_file() and src_path.suffix.lower() in COPY_EXTS:
            rel = src_path.relative_to(SIGECOM_IFACES)
            dest_dir = SRC_ROOT / rel.parent
            dest_dir.mkdir(parents=True, exist_ok=True)
            dest_file = dest_dir / src_path.name
            shutil.copy2(src_path, dest_file)
            files_processed += 1

            # If it's a form VB file (starts with frm or contains 'frm') generate TSX stub
            name = src_path.stem
            if name.lower().startswith('frm') or name.lower().startswith('rp') or name.lower().startswith('rp'):
                # normalize component name (remove invalid chars)
                comp_name = ''.join(ch if ch.isalnum() else '_' for ch in name)
                try:
                    make_tsx_stub(dest_dir, rel, comp_name)
                    stubs_created += 1
                except Exception as e:
                    print(f"Warning: failed creating stub for {src_path}: {e}")

    print(f"Copied {files_processed} resource files.")
    print(f"Created {stubs_created} TSX stubs.")

if __name__ == '__main__':
    main()
