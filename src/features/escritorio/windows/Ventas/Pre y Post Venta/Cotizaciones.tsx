// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search, RefreshCw, Filter } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  Field,
  WindowShell,
  Fs
} from "@/components/ui/desktop-primitives";

export function CotizacionesList() {
  return (
    <WindowShell title="Cotizaciones"
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
      </>}
    >
      <div className="p-3 space-y-3 max-w-xl mx-auto text-[11.5px] text-slate-800">
        <div className="grid grid-cols-[auto_1fr_auto_1fr] items-center gap-x-2 gap-y-2">
          <div className="text-right font-medium">Del :</div>
          <div><input className={inp} type="date" defaultValue="2026-08-01" /></div>
          <div className="text-right font-medium">Al :</div>
          <div><input className={inp} type="date" defaultValue="2026-08-08" /></div>
        </div>

        <div className="grid grid-cols-2 gap-3">
          <Field label="Oficina"><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Almacén"><select className={inp}><option>(Todos)</option></select></Field>
        </div>

        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Cliente</label>
          <Field label="Cliente"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
        </Fs>

        <Fs legend="Buscar Vendedor">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Vendedor</label>
          <Field label="Vendedor"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>

        <div className="grid grid-cols-[1.4fr_0.9fr] gap-3">
          <Fs legend="Opciones">
            <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Generados</option><option>Vencidos</option><option>Atendidos</option><option>Rechazados</option></select></Field>
            <Field label="Tipo de Rechazo"><select className={inp}><option>(Todos)</option></select></Field>
          </Fs>
          <div className="rounded border border-slate-300/80 bg-slate-50/80 p-3 text-[11px] text-slate-800">
            <div className="font-medium mb-2">Mostrar</div>
            <div className="space-y-1">
              <label className="flex items-center gap-2"><input type="radio" name="cotop" className="accent-[#2A5590]" defaultChecked />Todos</label>
              <label className="flex items-center gap-2"><input type="radio" name="cotop" className="accent-[#2A5590]" />Generados</label>
              <label className="flex items-center gap-2"><input type="radio" name="cotop" className="accent-[#2A5590]" />Vencidos</label>
              <label className="flex items-center gap-2"><input type="radio" name="cotop" className="accent-[#2A5590]" />Atendidos</label>
              <label className="flex items-center gap-2"><input type="radio" name="cotop" className="accent-[#2A5590]" />Rechazados</label>
            </div>
          </div>
        </div>

        <div className="mt-2 flex justify-center gap-2"><button className={btnPrimary}>Aceptar</button><button className={btn}>Cancelar</button></div>
      </div>
    </WindowShell>
  );
}
