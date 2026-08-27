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
import { Despacho } from "@/features/escritorio/windows/Almacenes/Almacen/Despacho";

export function ValesList() {
  return (
    <ListQueryForm
      title="Vales"
      toolbar={stdToolbarAlmacen}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pendientes:</span> <b className="font-mono text-amber-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Despachados:</span> <b className="font-mono text-emerald-700">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Cerrados:</span> <b className="font-mono text-slate-900">0</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Monto S/:</span> <b className="font-mono text-slate-900">0.00</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
          <Field label="Mes" className="w-20"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
          <Field label="Oficina" className="w-24"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
          <Field label="Almacén" className="w-28"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>SERVICIOS</option></select></Field>
          <Field label="Tipo" className="w-32"><select className={inp}><option>Vale de Almacén</option><option>Despacho</option><option>Requisición</option></select></Field>
          <Field label="Cliente" className="w-56">
            <div className="flex gap-1">
              <input className={`${inp} flex-1`} defaultValue="(Todos)" />
              <button className={iconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
            </div>
          </Field>
          <Field label="Estado" className="w-24"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>DESPACHADO</option><option>CERRADO</option></select></Field>
          <Field label="OT" className="w-20"><input className={`${inp} font-mono`} /></Field>
          <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Número", "OT", "Fecha", "Cliente", "Mon.", "Total", "Estado", "Prioridad", "Acción"]}
      rows={0}
    />
  );
}
