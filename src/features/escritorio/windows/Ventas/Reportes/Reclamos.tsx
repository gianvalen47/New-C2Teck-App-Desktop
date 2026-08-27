// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  Field,
  WindowShell,
  Fs
} from "@/components/ui/desktop-primitives";

export function ReporteReclamosList() {
  return (
    <WindowShell title="Reporte de Reclamos"
    >
      <div className="p-3 space-y-3 max-w-sm mx-auto text-[11.5px] text-slate-800">
        <div className="grid grid-cols-[auto_1fr_auto_1fr] items-center gap-x-2 gap-y-2">
          <div className="text-right font-medium">Del :</div>
          <div><input className={inp} type="date" defaultValue="2026-08-01" /></div>
          <div className="text-right">Al</div>
          <div><input className={inp} type="date" defaultValue="2026-08-08" /></div>
        </div>

        <Field label="Oficina"><select className={inp}><option>LIMA</option></select></Field>
        <Field label="Almacén"><select className={inp}><option>COMERCIAL</option></select></Field>
        <Field label="Estado :"><select className={inp}><option>(Todos)</option></select></Field>

        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Cliente</label>
          <Field label="Cliente"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
        </Fs>

        <div className="mt-2 flex justify-center gap-2"><button className={btnPrimary}>Aceptar</button><button className={btn}>Cancelar</button></div>
      </div>
    </WindowShell>
  );
}
