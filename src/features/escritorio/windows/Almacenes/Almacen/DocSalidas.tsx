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
import { Factura } from "@/features/escritorio/windows/Ventas/Documentos/Facturas";

export function DocSalidasList() {
  return (
    <ListQueryForm
      title="Movimiento de Salidas Almacén"
      toolbar={stdToolbarAlmacen}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Generados:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Entregados:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Anulados:</span> <b className="font-mono text-red-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Total S/:</span> <b className="font-mono text-slate-900">0.00</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
          <Field label="Mes" className="w-20"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
          <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
          <Field label="Almacén" className="w-28"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>SERVICIOS</option></select></Field>
          <Field label="Tipo Documento" className="w-32"><select className={inp}><option>(Todos)</option><option>Factura Venta</option><option>Guía Interna</option><option>Nota de Salida</option></select></Field>
          <Field label="Cliente" className="w-56">
            <div className="flex gap-1">
              <input className={`${inp} flex-1`} defaultValue="(Todos)" />
              <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
            </div>
          </Field>
          <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>ANULADO</option><option>ENTREGADO</option></select></Field>
          <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Número", "T.Doc.", "Fecha", "# OT", "Cliente", "Mon.", "Total", "Estado", "Acción"]}
      rows={0}
    />
  );
}
