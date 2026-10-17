// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { GerenciaReporteDialog } from "@/features/escritorio/windows/Reportes/GerenciaReporteDialog";

export function EstadosFinancieros() {
  return <GerenciaReporteDialog label="Estados Financieros" />;
}

export function EstadosFinancierosWindow() {
  return <EstadosFinancieros />;
}

export function ReporteFinanciero({ title = "Estados Financieros" }: { title?: string }) {
  return <ReporteFinancieroList title={title} />;
}
export function ReporteFinancieroList({ title = "Reporte Financiero " }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <EstadosFinancierosWindow />
    </div>
  );
}
