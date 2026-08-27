// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  Field,
  SearchBar,
  MasterDetailForm
} from "@/components/ui/desktop-primitives";
import { stdToolbar21 } from "@/features/escritorio/windows/shared/toolbarPresets";

export function RecepcionDocCreditosList() {
  return (
    <MasterDetailForm
      title="Recepción de Documentos - Créditos"
      toolbar={stdToolbar21}
      header={
        <div className="grid grid-cols-5 gap-2">
          <Field label="N° Registro"><input className={`${inp} font-mono`} defaultValue="" /></Field>
          <Field label="Fecha"><input className={inp} type="date" defaultValue="2026-07-25" /></Field>
          <Field label="Cliente"><input className={inp} defaultValue="" /></Field>
          <Field label="Documento"><select className={inp}><option>LETRA</option><option>PAGARÉ</option><option>CONTRATO</option></select></Field>
          <Field label="Estado"><select className={inp}><option>RECEPCIONADO</option><option>OBSERVADO</option><option>DEVUELTO</option></select></Field>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Cliente" className="w-56"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Tipo" className="w-40"><select className={inp}><option>(Todos)</option><option>LETRA</option><option>PAGARÉ</option><option>CONTRATO</option></select></Field>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Fecha", "Cliente", "Documento", "Número", "Banco", "Vencimiento", "Monto", "Estado", "Recibido por"]}
      rows={0}
    />
  );
}
