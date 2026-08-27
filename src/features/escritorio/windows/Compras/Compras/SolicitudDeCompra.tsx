// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, Search, Plus, FileSpreadsheet } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  SearchBar,
  MasterDetailForm
} from "@/components/ui/desktop-primitives";

export function SolicitudCompraList() {
  return (
    <MasterDetailForm
      title="Solicitud de Compra — Requerimiento Interno"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Enviar Solicitud</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Añadir ítem</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      header={
        <div className="space-y-2">
          <div className="grid grid-cols-4 gap-2 text-[11px]">
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pendientes:</span> <b className="font-mono text-amber-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aprobadas:</span> <b className="font-mono text-emerald-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Urgentes:</span> <b className="font-mono text-red-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Solicitudes:</span> <b className="font-mono text-slate-900">0</b></div>
          </div>
          <div className="grid grid-cols-4 gap-3">
            <Field label="SC Nº"><input className={inp} placeholder="SC-2026-0001" /></Field>
            <Field label="Fecha"><input className={inp} type="date" /></Field>
            <Field label="Área Solicitante"><select className={inp}><option>Servicios Técnicos</option><option>Almacén</option><option>Administración</option><option>Ventas</option></select></Field>
            <Field label="Prioridad"><select className={inp}><option>Normal</option><option>Alta</option><option>Urgente</option></select></Field>
            <Field label="Solicitante" className="col-span-2"><input className={inp} /></Field>
            <Field label="Centro Costo"><select className={inp}><option>(Seleccionar)</option><option>Servicios</option><option>Operaciones</option><option>Administración</option></select></Field>
            <Field label="Estado"><select className={inp}><option>Borrador</option><option>Pendiente</option><option>Aprobada</option><option>Rechazada</option></select></Field>
          </div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Área" className="w-44"><select className={inp}><option>(Todas)</option><option>Servicios Técnicos</option><option>Almacén</option><option>Administración</option><option>Ventas</option></select></Field>
          <Field label="Prioridad" className="w-32"><select className={inp}><option>(Todas)</option><option>Normal</option><option>Alta</option><option>Urgente</option></select></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Pendiente</option><option>Aprobada</option><option>Rechazada</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["#", "Código", "Descripción", "U.M.", "Cant.", "Uso destinado", "Prioridad", "Acción"]}
      rows={5}
      footer={<div className="px-1.5 pb-1.5"><Field label="Justificación" className="w-full"><textarea className={`${inp} h-14 py-1`} /></Field></div>}
    />
  );
}
