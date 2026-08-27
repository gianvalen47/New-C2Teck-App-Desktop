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
import { Cotizaciones } from "@/features/escritorio/windows/Ventas/Pre y Post Venta/Cotizaciones";

export function ReporteCotizacionesList() {
  return (
    <WindowShell title="Cotizaciones"
    >
      <div className="p-3 space-y-3 max-w-2xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Fechas">
          <Field label="Del"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Al"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
        </Fs>

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

        <div className="grid grid-cols-[1.3fr_0.9fr] gap-3">
          <Fs legend="Opciones">
            <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Generados</option><option>Vencidos</option><option>Atendidos</option><option>Rechazados</option></select></Field>
            <Field label="Tipo de Rechazo"><select className={inp}><option>(Todos)</option></select></Field>
          </Fs>
          <Fs legend="Mostrar">
            <div className="flex flex-col gap-1 text-[11px] text-slate-800">
              <label className="inline-flex items-center gap-2"><input type="radio" name="cot_op" defaultChecked className="accent-[#2A5590]" />Todos</label>
              <label className="inline-flex items-center gap-2"><input type="radio" name="cot_op" className="accent-[#2A5590]" />Generados</label>
              <label className="inline-flex items-center gap-2"><input type="radio" name="cot_op" className="accent-[#2A5590]" />Vencidos</label>
              <label className="inline-flex items-center gap-2"><input type="radio" name="cot_op" className="accent-[#2A5590]" />Atendidos</label>
              <label className="inline-flex items-center gap-2"><input type="radio" name="cot_op" className="accent-[#2A5590]" />Rechazados</label>
            </div>
          </Fs>
        </div>

        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}
