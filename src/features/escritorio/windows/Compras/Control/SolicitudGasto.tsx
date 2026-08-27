// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, Search, Plus, FileSpreadsheet } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  SearchBar,
  CalculationSummaryBlock,
  MasterDetailForm
} from "@/components/ui/desktop-primitives";
import {
  type Gasto
} from "@/lib/sigecoom-api";

export function SolicitudGastoList() {
  return (
    <MasterDetailForm
      title="Solicitud de Gasto — Caja / Compras Menores"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Enviar Solicitud</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Añadir concepto</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      header={
        <div className="space-y-2">
          <div className="grid grid-cols-4 gap-2 text-[11px]">
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pendientes:</span> <b className="font-mono text-amber-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aprobadas:</span> <b className="font-mono text-emerald-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Rendidas:</span> <b className="font-mono text-slate-900">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Monto total:</span> <b className="font-mono text-[#2A3F55]">S/ 0.00</b></div>
          </div>
          <div className="grid grid-cols-4 gap-3">
            <Field label="SG Nº"><input className={inp} placeholder="SG-2026-0001" /></Field>
            <Field label="Fecha"><input className={inp} type="date" /></Field>
            <Field label="Área"><select className={inp}><option>Administración</option><option>Operaciones</option><option>Ventas</option><option>Servicios</option></select></Field>
            <Field label="Prioridad"><select className={inp}><option>Normal</option><option>Alta</option><option>Urgente</option></select></Field>
            <Field label="Solicitante" className="col-span-2"><input className={inp} /></Field>
            <Field label="Tipo Gasto"><select className={inp}><option>Operativo</option><option>Servicio</option><option>Movilidad</option><option>Representación</option></select></Field>
            <Field label="Estado"><select className={inp}><option>Borrador</option><option>Pendiente</option><option>Aprobada</option><option>Rendida</option><option>Rechazada</option></select></Field>
          </div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Pendiente</option><option>Aprobada</option><option>Rendida</option></select></Field>
          <Field label="Área" className="w-40"><select className={inp}><option>(Todas)</option><option>Administración</option><option>Operaciones</option><option>Ventas</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["#", "Concepto", "Centro costo", "Cant.", "P.Unit", "Subtotal", "IGV", "Total", "Acción"]}
      rows={5}
      summary={<CalculationSummaryBlock values={{ subtotal: 0, discount: 0, igv: 0, total: 0 }} />}
      footer={<div className="px-1.5 pb-1.5"><Field label="Justificación" className="w-full"><textarea className={`${inp} h-14 py-1`} /></Field></div>}
    />
  );
}
