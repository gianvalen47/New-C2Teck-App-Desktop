// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { GerenciaReporteDialog } from "@/features/escritorio/windows/Reportes/GerenciaReporteDialog";

export function Rpt000Ventas() {
  return <GerenciaReporteDialog label="000 - Ventas" />;
}

export function GerenciaVentasWindow() {
  return <Rpt000Ventas />;
}

export function ReporteVentas({ title = "Reporte de Ventas" }: { title?: string }) {
  return <ReporteVentasList title={title} />;
}
export function ReporteVentasList({ title = "Reporte Ventas " }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <GerenciaVentasWindow />
    </div>
  );
}
