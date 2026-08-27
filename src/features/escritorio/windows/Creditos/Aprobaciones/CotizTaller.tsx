// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  Field,
  SearchBar,
  ListQueryForm
} from "@/components/ui/desktop-primitives";
import { stdToolbar20 } from "@/features/escritorio/windows/shared/toolbarPresets";
import { Cotizaciones } from "@/features/escritorio/windows/Ventas/Pre y Post Venta/Cotizaciones";

export function CotizTallerCreditoList() {
  return (
    <ListQueryForm
      title="Cotizaciones de Taller para Evaluación"
      toolbar={stdToolbar20}
      filters={
        <SearchBar>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Cliente" className="w-56"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Estado" className="w-36"><select className={inp}><option>(Todos)</option><option>PENDIENTE</option><option>APROBADO</option><option>RECHAZADO</option></select></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["N° Cotiz.", "Fecha", "Cliente", "OT", "Mon.", "Total", "Solicita", "Estado", "Obs."]}
      rows={0}
    />
  );
}
