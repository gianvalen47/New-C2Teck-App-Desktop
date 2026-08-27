// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  Field,
  SearchBar,
  ListQueryForm
} from "@/components/ui/desktop-primitives";
import { stdToolbar5 } from "@/features/escritorio/windows/shared/toolbarPresets";

export function FactoresRubrosList() {
  return (
    <ListQueryForm
      title="Factores por Rubro"
      toolbar={stdToolbar5}
      filters={(
        <SearchBar>
          <Field label="Rubro" className="w-64"><input className={inp} /></Field>
          <Field label="Estado" className="w-28"><select className={inp}><option>(Todos)</option><option>ACTIVO</option><option>INACTIVO</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      )}
      columns={["Código", "Rubro", "Abrev.", "Fac. Costo", "Fac. Venta", "Dscto Máx", "Estado"]}
      rows={0}
    />
  );
}
