import { ListQueryForm, SearchBar, Field } from "@/components/ui/desktop-primitives";
import { stdToolbar3 } from "../../shared/toolbarPresets";
import { inp, btn, iconBtn } from "@/components/ui/desktop-primitives";
import { Search } from "lucide-react";

export function PrecioClienteList() {
  return (
    <ListQueryForm
      title="Precios por Cliente"
      toolbar={stdToolbar3}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-3 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Vigentes:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Por vencer:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Vencidos:</span> <b className="font-mono text-slate-900">0</b></div>
        </div>
      }
      filters={(
        <SearchBar>
          <Field label="Cliente" className="w-64">
            <div className="flex gap-1">
              <input className={`${inp} flex-1`} defaultValue="(Todos)" />
              <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
            </div>
          </Field>
          <Field label="Estado" className="w-36"><select className={inp}><option>(Todos)</option><option>Generado</option><option>Vigente</option><option>Vencido</option></select></Field>
          <Field label="N° Contrato" className="w-40"><input className={inp} /></Field>
          <Field label="Moneda" className="w-24"><select className={inp}><option>(Todos)</option><option>PEN</option><option>USD</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      )}
      columns={["Cód.", "Cliente", "N° Contrato", "Lista", "Mon.", "Observación", "Estado", "Fec. Inicio", "Fec. Venc."]}
      rows={0}
    />
  );
}