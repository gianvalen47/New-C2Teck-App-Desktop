import { ListQueryForm, SearchBar, Field } from "@/components/ui/desktop-primitives";
import { stdToolbar6 } from "../../shared/toolbarPresets";
import { inp, btn } from "@/components/ui/desktop-primitives";
import { Search } from "lucide-react";

export function PrecioListaList() {
  return (
    <ListQueryForm
      title="Listas de Precios"
      toolbar={stdToolbar6}
      filters={(
        <SearchBar>
          <Field label="Lista Precio" className="w-56"><select className={inp}><option>(Todos)</option><option>LISTA GENERAL</option><option>LISTA MAYORISTA</option></select></Field>
          <Field label="Estado" className="w-36"><select className={inp}><option>(Todos)</option><option>Vigente</option><option>No vigente</option></select></Field>
          <Field label="Moneda" className="w-24"><select className={inp}><option>(Todos)</option><option>PEN</option><option>USD</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      )}
      columns={["Cód.", "Nombre", "Moneda", "Observación", "Fec. Inicio", "Fec. Venc.", "Vigente"]}
      rows={0}
    />
  );
}