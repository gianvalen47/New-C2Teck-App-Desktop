// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { GerenciaReporteDialog } from "@/features/escritorio/windows/Reportes/GerenciaReporteDialog";

export function ContenedorReportes() {
  return <GerenciaReporteDialog label="Contenedor Reportes" />;
}

export function ContenedorReportesWindow() {
  return <ContenedorReportes />;
}

export function ReporteContenedor({ title = "Contenedor de Reportes" }: { title?: string }) {
  return <ReporteContenedorList title={title} />;
}
export function ReporteContenedorList({ title = "Reporte Contenedor " }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <ContenedorReportesWindow />
    </div>
  );
}
