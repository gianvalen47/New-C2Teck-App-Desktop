// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, Search, FileSpreadsheet, Filter } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  SearchBar,
  ListQueryForm
} from "@/components/ui/desktop-primitives";

export function PersonalTiempoList({ title }: { title: string }) {
  return (
    <ListQueryForm
      title={title + " — Gestión de Tiempo / Planilla"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pendiente aprobación:</span> <b className="font-mono text-amber-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aprobado:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Observado:</span> <b className="font-mono text-red-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Horas acumuladas:</span> <b className="font-mono text-slate-900">0.00</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Colaborador" className="w-64"><input className={inp} placeholder="DNI / Nombre" /></Field>
          <Field label="Área" className="w-44"><input className={inp} /></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Pendiente</option><option>Aprobado</option><option>Observado</option></select></Field>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Fecha", "Colaborador", "Área", title, "Horas", "Estado", "Aprobado por", "Acción"]}
      rows={10}
    />
  );
}
