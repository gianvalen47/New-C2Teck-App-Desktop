// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  Field,
  SearchBar,
  ListQueryForm
} from "@/components/ui/desktop-primitives";
import { stdToolbarAlmacen } from "@/features/escritorio/windows/shared/toolbarPresets";

export function AtenderOTList() {
  return (
    <ListQueryForm
      title="Atender Job"
      toolbar={stdToolbarAlmacen}
      filters={
        <SearchBar>
          <Field label="Locación OT" className="w-32"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
          <Field label="Cliente" className="w-56"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>PENDIENTE</option><option>EN PROCESO</option><option>ATENDIDO</option></select></Field>
          <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["OT", "Descripción", "Cliente", "Estado", "Prioridad", "Responsable", "Acción"]}
      rows={0}
    />
  );
}
