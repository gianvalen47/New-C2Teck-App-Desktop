// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { GerenciaReporteDialog } from "@/features/escritorio/windows/Reportes/GerenciaReporteDialog";

export function Rpt040CreditosYCobranzas() {
  return <GerenciaReporteDialog label="040 - Creditos y Cobranzas" />;
}

export function GerenciaCreditosWindow() {
  return <Rpt040CreditosYCobranzas />;
}

export function ReporteCreco({ title = "Reporte de Cr?ditos y Cobranzas" }: { title?: string }) {
  return <ReporteCrecoList title={title} />;
}
export function ReporteCrecoList({ title = "Reporte Creco " }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <GerenciaCreditosWindow />
    </div>
  );
}
