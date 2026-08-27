// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  Field,
  SearchBar,
  ListQueryForm
} from "@/components/ui/desktop-primitives";
import { stdToolbar7 } from "@/features/escritorio/windows/shared/toolbarPresets";

export function PrecioFabricantesList() {
  return (
    <ListQueryForm
      title="Precios de Fabricantes"
      toolbar={stdToolbar7}
      filters={(
        <SearchBar>
          <Field label="Fabricante" className="w-56"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Lista Precio" className="w-56"><select className={inp}><option>(Todos)</option><option>FABRICANTE A</option><option>FABRICANTE B</option></select></Field>
          <Field label="Estado" className="w-36"><select className={inp}><option>(Todos)</option><option>Vigente</option><option>No vigente</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      )}
      columns={["Fabricante", "Lista", "Mon.", "Observación", "Fec. Inicio", "Fec. Venc.", "Vigente"]}
      rows={0}
    />
  );
}
