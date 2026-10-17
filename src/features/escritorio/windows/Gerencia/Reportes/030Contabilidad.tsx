// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { GerenciaReporteDialog } from "@/features/escritorio/windows/Reportes/GerenciaReporteDialog";

export function Rpt030Contabilidad() {
  return <GerenciaReporteDialog label="030 - Contabilidad" />;
}

export function GerenciaContabilidadWindow() {
  return <Rpt030Contabilidad />;
}

export function ReporteContabilidad({ title = "Reporte de Contabilidad" }: { title?: string }) {
  return <ReporteContabilidadList title={title} />;
}
export function ReporteContabilidadList({ title = "Reporte Contabilidad " }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <GerenciaContabilidadWindow />
    </div>
  );
}
