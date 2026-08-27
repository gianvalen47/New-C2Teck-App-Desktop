// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  iconBtn,
  Field,
  SearchBar,
  CalculationSummaryBlock,
  MasterDetailForm
} from "@/components/ui/desktop-primitives";
import { stdToolbar10 } from "@/features/escritorio/windows/shared/toolbarPresets";

export function OrdenesCompraList() {
  return (
    <MasterDetailForm
      title="Órdenes de Compra de Venta"
      toolbar={stdToolbar10}
      header={
        <div className="grid grid-cols-6 gap-2">
          <Field label="Número"><input className={`${inp} font-mono`} defaultValue="000123" /></Field>
          <Field label="Fecha"><input className={inp} type="date" defaultValue="2026-07-25" /></Field>
          <Field label="Estado"><select className={inp}><option>PENDIENTE</option><option>ATENDIDO</option><option>ANULADO</option></select></Field>
          <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
          <Field label="Vendedor"><input className={inp} defaultValue="(Asignar)" /></Field>
          <Field label="Prioridad"><select className={inp}><option>NORMAL</option><option>URGENTE</option></select></Field>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Cliente" className="w-64">
            <div className="flex gap-1">
              <input className={`${inp} flex-1`} defaultValue="(Todos)" />
              <button className={iconBtn} title="Buscar cliente"><Search className="h-3.5 w-3.5" /></button>
            </div>
          </Field>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Tipo" className="w-32"><select className={inp}><option>(Todos)</option><option>Nacional</option><option>Importación</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Ítem", "Código", "Descripción", "Cant.", "P.Unit", "Desc.", "SubTotal", "IGV", "Total"]}
      rows={8}
      summary={<CalculationSummaryBlock values={{ subtotal: 0, discount: 0, igv: 0, total: 0 }} />}
    />
  );
}
