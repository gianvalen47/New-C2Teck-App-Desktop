// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, Search, FileDown, FileSpreadsheet } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  SearchBar,
  MasterDetailForm
} from "@/components/ui/desktop-primitives";

export function GarantiaWinList({ title }: { title: string }) {
  return (
    <MasterDetailForm
      title={title + " — Gestión de Garantía"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Registrar</button>
        <button className={btn}><FileDown className="h-3.5 w-3.5" />Adjuntos</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      header={
        <div className="space-y-2">
          <div className="grid grid-cols-4 gap-2 text-[11px]">
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Registradas:</span> <b className="font-mono text-slate-900">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aprobadas:</span> <b className="font-mono text-emerald-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Rechazadas:</span> <b className="font-mono text-red-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">En taller:</span> <b className="font-mono text-amber-700">0</b></div>
          </div>
          <div className="grid grid-cols-4 gap-3">
            <Field label="Cliente" className="col-span-2"><input className={inp} /></Field>
            <Field label="Nº póliza / Serie"><input className={inp} /></Field>
            <Field label="Fecha reclamo"><input className={inp} type="date" /></Field>
            <Field label="Fabricante"><input className={inp} /></Field>
            <Field label="Equipo / Vehículo" className="col-span-2"><input className={inp} /></Field>
            <Field label="Cubre"><select className={inp}><option>Fabricante</option><option>Empresa</option><option>Compartida</option></select></Field>
            <Field label="Estado"><select className={inp}><option>Registrado</option><option>Evaluación</option><option>Aprobado</option><option>Rechazado</option></select></Field>
          </div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Estado" className="w-40"><select className={inp}><option>(Todos)</option><option>Evaluación</option><option>Aprobado</option><option>Rechazado</option></select></Field>
          <Field label="Fabricante" className="w-52"><input className={inp} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Repuesto", "Cant.", "Costo cubierto", "Aprobado por", "Estado", "Acción"]}
      rows={4}
      footer={<div className="px-1.5 pb-1.5"><Field label="Descripción del defecto" className="w-full"><textarea className={inp + " h-14 py-1"} /></Field></div>}
    />
  );
}
