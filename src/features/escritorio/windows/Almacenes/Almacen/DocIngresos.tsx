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
import {
  type Gasto
} from "@/lib/sigecoom-api";
import { stdToolbarAlmacen } from "@/features/escritorio/windows/shared/toolbarPresets";
import { Factura } from "@/features/escritorio/windows/Ventas/Documentos/Facturas";

export function DocIngresosList() {
  return (
    <ListQueryForm
      title="Movimiento de Ingresos Almacén"
      toolbar={stdToolbarAlmacen}
      filters={
        <SearchBar>
          <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
          <Field label="Mes" className="w-20"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
          <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
          <Field label="Almacén" className="w-28"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>SERVICIOS</option></select></Field>
          <Field label="Tipo Documento" className="w-32"><select className={inp}><option>(Todos)</option><option>Factura Compra</option><option>Guía Proveedor</option><option>Ingreso Interno</option></select></Field>
          <Field label="Proveedor" className="w-56">
            <div className="flex gap-1">
              <input className={`${inp} flex-1`} defaultValue="(Todos)" />
              <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
            </div>
          </Field>
          <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>ANULADO</option></select></Field>
          <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["T.Doc.", "Documento", "Fecha", "# OT", "Cliente", "Mon.", "Total", "Estado", "N° Gasto"]}
      rows={0}
    />
  );
}
