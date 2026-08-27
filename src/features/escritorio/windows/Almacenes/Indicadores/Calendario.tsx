// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search, FileSpreadsheet, RefreshCw, Calendar } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  SearchBar,
  ListQueryForm
} from "@/components/ui/desktop-primitives";

export function CalendarioList() {
  return (
    <ListQueryForm
      title="Calendario de Almacén"
      toolbar={<>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Actualizar</button>
        <button className={btn}><Calendar className="h-3.5 w-3.5" />Ver Mes</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Eventos:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Inventarios:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Traslados:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Conteos:</span> <b className="font-mono text-amber-700">0</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Año" className="w-20"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
          <Field label="Mes" className="w-24"><select className={inp}><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
          <Field label="Almacén" className="w-32"><select className={inp}><option>Central Lima</option><option>Norte</option><option>Sur</option></select></Field>
          <Field label="Tipo Evento" className="w-40"><select className={inp}><option>(Todos)</option><option>Inventario</option><option>Traslado</option><option>Conteo</option></select></Field>
          <Field label="Responsable" className="w-48"><input className={inp} defaultValue="(Todos)" /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Fecha", "Evento", "Almacén", "Documento", "Responsable", "Estado", "Acción"]}
      rows={6}
    />
  );
}
