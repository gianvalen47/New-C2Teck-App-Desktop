// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  Field,
  WindowShell,
  Fs,
  Radio
} from "@/components/ui/desktop-primitives";

export function ReporteGRPendienteList() {
  return (
    <WindowShell title="Reporte de Guías de Venta y Guías no Facturadas"
    >
      <div className="p-3 space-y-3 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <div className="grid grid-cols-[1.35fr_0.75fr] gap-3">
          <Fs legend="Fechas">
            <Field label="Del"><input className={inp} type="date" defaultValue="2026-01-07" /></Field>
            <Field label="Al"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
          </Fs>
          <div className="space-y-3">
            <Field label="Motivo"><select className={inp}><option>(Todos)</option></select></Field>
            <Fs legend="Facturado">
              <div className="flex flex-col gap-1">
                <Radio name="facturado" label="Pendientes de Facturación" defaultChecked />
                <Radio name="facturado" label="Todos" />
              </div>
            </Fs>
          </div>
        </div>

        <div className="grid grid-cols-[1.1fr_1fr] gap-3">
          <Fs legend="Locación">
            <div className="space-y-1">
              <label className="flex items-center gap-2"><input type="radio" name="ubicacion" defaultChecked className="accent-[#2A5590]" />Todos</label>
              <label className="flex items-center gap-2"><input type="radio" name="ubicacion" className="accent-[#2A5590]" />Uno</label>
            </div>
            <Field label="Oficina"><select className={inp}><option>LIMA</option></select></Field>
            <Field label="Almacén"><select className={inp}><option>COMERCIAL</option></select></Field>
          </Fs>
          <Fs legend="Buscar Cliente">
            <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Cliente</label>
            <Field label="Cliente"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
          </Fs>
        </div>

        <div className="grid grid-cols-[1.1fr_1fr] gap-3">
          <Fs legend="Buscar Por Vendedor">
            <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Vendedor</label>
            <Field label="Vendedor"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
          </Fs>
          <Fs legend="Tipo Reporte">
            <div className="flex flex-col gap-1">
              <Radio name="tiporeporte" label="Reporte de Guías" defaultChecked />
              <Radio name="tiporeporte" label="Reporte de G/R Por Fecha de Proceso" />
            </div>
          </Fs>
        </div>

        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}
