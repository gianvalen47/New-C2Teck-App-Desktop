// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, Search, Plus, GraduationCap } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  SearchBar,
  MasterDetailForm
} from "@/components/ui/desktop-primitives";

export function CapacitacionesWinList({ title }: { title: string }) {
  return (
    <MasterDetailForm
      title={title + " — Personal"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Programar</button>
        <button className={btn}><GraduationCap className="h-3.5 w-3.5" />Certificados</button>
      </>}
      header={
        <div className="space-y-2">
          <div className="grid grid-cols-4 gap-2 text-[11px]">
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Programadas:</span> <b className="font-mono text-slate-900">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">En curso:</span> <b className="font-mono text-amber-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aprobadas:</span> <b className="font-mono text-emerald-700">0</b></div>
            <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Observadas:</span> <b className="font-mono text-red-700">0</b></div>
          </div>
          <div className="grid grid-cols-4 gap-3">
            <Field label="Colaborador" className="col-span-2"><input className={inp} /></Field>
            <Field label="Área"><input className={inp} /></Field>
            <Field label="Periodo"><input className={inp} placeholder="2026" /></Field>
          </div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Programada</option><option>En curso</option><option>Aprobada</option><option>Observada</option></select></Field>
          <Field label="Instructor" className="w-52"><input className={inp} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Fecha", "Colaborador", title, "Duración", "Resultado", "Estado", "Acción"]}
      rows={8}
    />
  );
}
