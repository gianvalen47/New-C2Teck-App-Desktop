// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  Field,
  SearchBar,
  CalculationSummaryBlock,
  MasterDetailForm
} from "@/components/ui/desktop-primitives";
import { stdToolbar9 } from "@/features/escritorio/windows/shared/toolbarPresets";

export function SepararOrdenList() {
  return (
    <MasterDetailForm
      title="Separación de Orden"
      toolbar={stdToolbar9}
      header={
        <div className="grid grid-cols-6 gap-2">
          <Field label="N° Orden"><input className={`${inp} font-mono`} defaultValue="" /></Field>
          <Field label="Fecha"><input className={inp} type="date" defaultValue="2026-07-25" /></Field>
          <Field label="Cliente"><input className={inp} defaultValue="" /></Field>
          <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
          <Field label="Estado"><select className={inp}><option>PENDIENTE</option><option>SEPARADO</option><option>ATENDIDO</option><option>ANULADO</option></select></Field>
          <Field label="Vendedor"><input className={inp} defaultValue="" /></Field>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Cliente" className="w-64"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Estado" className="w-36"><select className={inp}><option>(Todos)</option><option>PENDIENTE</option><option>SEPARADO</option><option>ATENDIDO</option><option>ANULADO</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Ítem", "Código", "Descripción", "Stock", "Cant. Sol.", "Cant. Sep.", "Mon.", "P.Unit", "Total"]}
      rows={0}
      summary={<CalculationSummaryBlock values={{ subtotal: 0, discount: 0, igv: 0, total: 0 }} />}
    />
  );
}
