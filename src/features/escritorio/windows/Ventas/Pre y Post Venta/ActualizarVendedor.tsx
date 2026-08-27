// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { X, Save, Search } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  SearchBar,
  MasterDetailForm
} from "@/components/ui/desktop-primitives";
import { stdToolbar11 } from "@/features/escritorio/windows/shared/toolbarPresets";

export function ActualizarVendedorList() {
  return (
    <MasterDetailForm
      title="Actualizar Vendedor por Documento"
      toolbar={stdToolbar11}
      header={
        <div className="grid grid-cols-5 gap-2">
          <Field label="Documento"><input className={`${inp} font-mono`} defaultValue="" /></Field>
          <Field label="Fecha"><input className={inp} type="date" defaultValue="2026-07-25" /></Field>
          <Field label="Cliente"><input className={inp} defaultValue="" /></Field>
          <Field label="Vendedor Actual"><input className={inp} defaultValue="" /></Field>
          <Field label="Nuevo Vendedor"><select className={inp}><option>(Seleccionar)</option><option>VENDEDOR 01</option><option>VENDEDOR 02</option></select></Field>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Año" className="w-16"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
          <Field label="Mes" className="w-28"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
          <Field label="Oficina" className="w-32"><select className={inp}><option>(Todas)</option><option>LIMA</option><option>AREQUIPA</option></select></Field>
          <Field label="Estado" className="w-28"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>EMITIDO</option><option>ANULADO</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Sel", "Documento", "Fecha", "Cliente", "Vendedor Actual", "Nuevo Vendedor", "Moneda", "Total", "Estado"]}
      rows={0}
      footer={
        <div className="px-1.5 pb-1.5 flex justify-end gap-2">
          <button className={btn}><X className="h-3.5 w-3.5" />Cancelar</button>
          <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Aplicar Cambio</button>
        </div>
      }
    />
  );
}
