// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search, Plus, FileSpreadsheet, Send } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  SearchBar,
  MasterDetailForm
} from "@/components/ui/desktop-primitives";

export function PedirRepuestosList() {
  return (
    <MasterDetailForm
      title="Pedir Repuestos — Enlace Taller ↔ Almacén"
      toolbar={<>
        <button className={btnPrimary}><Send className="h-3.5 w-3.5" />Enviar solicitud</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Añadir ítem</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      header={
        <div className="space-y-2">
          <div className="grid grid-cols-4 gap-2 text-[11px]">
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pendientes:</span> <b className="font-mono text-amber-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Atendidas:</span> <b className="font-mono text-emerald-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Parciales:</span> <b className="font-mono text-slate-900">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Urgentes:</span> <b className="font-mono text-red-700">0</b></div>
          </div>
          <div className="grid grid-cols-4 gap-3">
            <Field label="OT origen"><input className={inp} /></Field>
            <Field label="Mecánico"><input className={inp} /></Field>
            <Field label="Almacén destino"><select className={inp}><option>Central</option><option>Repuestos</option></select></Field>
            <Field label="Prioridad"><select className={inp}><option>Normal</option><option>Urgente</option></select></Field>
          </div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Pendiente</option><option>Atendido</option><option>Parcial</option></select></Field>
          <Field label="Taller" className="w-40"><select className={inp}><option>(Todos)</option><option>Taller Central</option><option>Taller Mina</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Código", "Descripción", "Cant. solicitada", "Cant. atendida", "Estado", "Acción"]}
      rows={6}
    />
  );
}
