// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { RefreshCw } from "lucide-react";
import {
  inp,
  btnPrimary,
  Field,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function CambiarEmpresaList() {
  return (
    <WindowShell title="Cambiar Empresa / Sucursal Fiscal"
      toolbar={<><button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Cambiar</button></>}>
      <div className="max-w-md mx-auto mt-4 space-y-3">
        <Field label="Empresa actual"><input className={inp} defaultValue="C2TECK S.A.C." readOnly /></Field>
        <Field label="Cambiar a">
          <select className={inp}>
            <option>C2TECK S.A.C.</option>
            <option>C2TECK Holding</option>
            <option>Sucursal Norte</option>
            <option>Sucursal Sur</option>
          </select>
        </Field>
        <Field label="Sede / Locación">
          <select className={inp}><option>Central</option><option>Mina 1</option><option>Taller</option></select>
        </Field>
      </div>
    </WindowShell>
  );
}
