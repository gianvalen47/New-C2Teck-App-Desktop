// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, Search, Plus, FileSpreadsheet } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  SearchBar,
  ListQueryForm
} from "@/components/ui/desktop-primitives";

export function OficinaUsuarioList() {
  return (
    <ListQueryForm
      title="Oficina / Bahías del Taller"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nueva bahía</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Bahías operativas:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">En mantenimiento:</span> <b className="font-mono text-amber-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Inactivas:</span> <b className="font-mono text-red-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Capacidad total:</span> <b className="font-mono text-slate-900">0</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Sede" className="w-44"><select className={inp}><option>(Todas)</option><option>Central</option><option>Norte</option><option>Sur</option></select></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Operativa</option><option>Mantenimiento</option><option>Inactiva</option></select></Field>
          <Field label="Encargado" className="w-52"><input className={inp} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Código", "Bahía / Puesto", "Sede", "Encargado", "Capacidad", "Estado", "Acción"]}
      rows={8}
    />
  );
}
