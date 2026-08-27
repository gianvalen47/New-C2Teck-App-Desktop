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

export function ReporteConsignacionList() {
  return (
    <WindowShell title="Consignación"
    >
      <div className="p-3 space-y-2 max-w-2xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Fechas">
          <Field label="Del"><input className={inp} type="date" defaultValue="2026-01-07" /></Field>
          <Field label="Al"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
        </Fs>
        <Fs legend="Búsqueda Rápida">
          <Field label="Oficina"><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Almacén"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>
        <Fs legend="Buscar Mercadería">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Toda Mercadería</label>
          <Field label="Mercadería"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
        </Fs>
        <Fs legend="Paginación">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Con Paginación</label>
        </Fs>
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}
