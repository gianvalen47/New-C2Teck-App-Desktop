// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, Printer, Search, FileSpreadsheet, Mail } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  SearchBar,
  CalculationSummaryBlock,
  MasterDetailForm
} from "@/components/ui/desktop-primitives";

export function OrdenCompraList() {
  return (
    <MasterDetailForm
      title="Orden de Compra"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Emitir OC</button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
        <button className={btn}><Mail className="h-3.5 w-3.5" />Enviar Proveedor</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}
      header={
        <div className="space-y-2">
          <div className="grid grid-cols-4 gap-3">
            <Field label="OC Nº"><input className={inp} placeholder="OC-2026-0001" /></Field>
            <Field label="Fecha"><input className={inp} type="date" /></Field>
            <Field label="Fecha Entrega"><input className={inp} type="date" /></Field>
            <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
            <Field label="Proveedor RUC"><input className={inp} /></Field>
            <Field label="Razón Social" className="col-span-2"><input className={inp} /></Field>
            <Field label="Condición Pago"><select className={inp}><option>Contado</option><option>Crédito 30</option><option>Crédito 60</option></select></Field>
            <Field label="Almacén Destino"><select className={inp}><option>Central Lima</option><option>Norte</option><option>Sur</option></select></Field>
            <Field label="Solicitud Ref."><input className={inp} /></Field>
            <Field label="Comprador" className="col-span-2"><input className={inp} /></Field>
          </div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Proveedor" className="w-56"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>(Todos)</option><option>EMITIDA</option><option>PARCIAL</option><option>CERRADA</option><option>ANULADA</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["#", "Código", "Descripción", "Cant.", "P.Unit", "Desc.", "IGV", "Total", "Acción"]}
      rows={6}
      summary={<CalculationSummaryBlock values={{ subtotal: 0, discount: 0, igv: 0, total: 0 }} />}
    />
  );
}
