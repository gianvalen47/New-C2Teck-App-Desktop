// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search, RefreshCw, Fingerprint } from "lucide-react";
import {
  inp,
  btn,
  Field,
  SearchBar,
  ListQueryForm
} from "@/components/ui/desktop-primitives";
import { MarcacionesList } from "@/features/escritorio/windows/Servicios/Orden de Trabajo/Marcaciones";

export function MarcacionOnlineList() {
  return (
    <ListQueryForm
      title="Marcación en línea — Relojes Biométricos"
      toolbar={<>
        <button className={btn}><RefreshCw className="h-3.5 w-3.5" />Sincronizar relojes</button>
        <button className={btn}><Fingerprint className="h-3.5 w-3.5" />Historial</button>
        <span className="ml-auto text-[11px] text-slate-500">Última sincronización: <b>—</b></span>
      </>}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Marcaciones válidas:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Observadas:</span> <b className="font-mono text-red-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Tardanzas:</span> <b className="font-mono text-amber-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Ausencias:</span> <b className="font-mono text-slate-900">0</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Sede / Mina" className="w-40"><select className={inp}><option>Todas</option><option>Sede Central</option><option>Mina 1</option></select></Field>
          <Field label="Fecha" className="w-32"><input className={inp} type="date" defaultValue="2026-07-25" /></Field>
          <Field label="Turno" className="w-32"><select className={inp}><option>Todos</option><option>Mañana</option><option>Tarde</option><option>Noche</option></select></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>Válida</option><option>Observada</option><option>Tardanza</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Hora", "Colaborador", "Sede", "Tipo", "Estado", "Acción"]}
      rows={12}
    />
  );
}
