// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search, RefreshCw, Filter } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  Field,
  DataTable,
  WindowShell,
  Fs,
  Radio
} from "@/components/ui/desktop-primitives";

export function ReporteGuiasList() {
  return (
    <WindowShell title="Reporte de Guías de Venta y Guías no Facturadas"
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
      </>}
    >
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Fechas">
          <Field label="Del"><input className={inp} type="date" defaultValue="2026-01-07" /></Field>
          <Field label="Al"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
        </Fs>
        <div className="grid grid-cols-2 gap-2">
          <Fs legend="Localización"><div className="flex gap-3"><label className="flex items-center gap-1"><input type="radio" name="loc" defaultChecked className="accent-[#2A5590]" />Todos</label><label className="flex items-center gap-1"><input type="radio" name="loc" className="accent-[#2A5590]" />Uno</label></div><Field label="Oficina"><select className={inp}><option>LIMA</option></select></Field><Field label="Almacén"><select className={inp}><option>COMERCIAL</option></select></Field></Fs>
          <Fs legend="Facturado"><div className="flex flex-col gap-1"><Radio name="fact" label="Pendientes de Facturación" defaultChecked /><Radio name="fact" label="Todos" /></div></Fs>
        </div>
        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Cliente</label>
          <Field label="Cliente"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
        </Fs>
        <Fs legend="Buscar Por Vendedor">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Vendedor</label>
          <Field label="Vendedor"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>
        <div className="grid grid-cols-2 gap-2">
          <Fs legend="Tipo Reporte"><div className="flex flex-col gap-1"><Radio name="tipo" label="Reporte de Guías" defaultChecked /><Radio name="tipo" label="Reporte de G/R Por Fecha de Proceso" /></div></Fs>
          <Fs legend="Motivo"><Field label=""><select className={inp}><option>(Todos)</option></select></Field></Fs>
        </div>
        <DataTable columns={["Fecha", "G/R", "Cliente", "Oficina", "Almacén", "Total Soles"]} rows={5} />
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}
