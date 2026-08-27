// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  Field,
  SearchBar,
  ListQueryForm
} from "@/components/ui/desktop-primitives";
import { stdToolbar4 } from "@/features/escritorio/windows/shared/toolbarPresets";

export function PrecioOfertaList() {
  return (
    <ListQueryForm
      title="Precios de Oferta"
      toolbar={stdToolbar4}
      filters={(
        <SearchBar>
          <Field label="Estado" className="w-40"><select className={inp}><option>(Todos)</option><option>Vigente</option><option>Expirado</option><option>Programado</option></select></Field>
          <Field label="Rubro" className="w-44"><select className={inp}><option>(Todos)</option><option>REPUESTOS</option><option>SERVICIOS</option><option>LUBRICANTES</option></select></Field>
          <Field label="Buscar" className="w-64"><input className={inp} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      )}
      columns={["Cód.", "Nombre", "Rubro", "Moneda", "Precio Oferta", "Observación", "Fec. Venc.", "Estado"]}
      rows={0}
    />
  );
}
