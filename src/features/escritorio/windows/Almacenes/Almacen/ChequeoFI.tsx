// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  iconBtn,
  Field,
  SearchBar,
  ListQueryForm
} from "@/components/ui/desktop-primitives";
import { stdToolbarAlmacen } from "@/features/escritorio/windows/shared/toolbarPresets";

export function ChequeoFIList() {
  return (
    <ListQueryForm
      title="Chequeo de Facturas de Importación"
      toolbar={stdToolbarAlmacen}
      filters={
        <SearchBar>
          <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
          <Field label="Almacén" className="w-28"><select className={inp}><option>SERVICIOS</option><option>COMERCIAL</option><option>REPUESTOS</option></select></Field>
          <Field label="Proveedor" className="w-56">
            <div className="flex gap-1">
              <input className={`${inp} flex-1`} defaultValue="(Todos)" />
              <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
            </div>
          </Field>
          <Field label="Fecha Inicio" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Fecha Fin" className="w-32"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
          <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>RECHAZADO</option></select></Field>
          <Field label="Embarque" className="w-24"><input className={inp} /></Field>
          <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Número", "Fecha", "Proveedor", "Embarque", "Total ($)", "Estado", "Resultado", "Acción"]}
      rows={0}
    />
  );
}
