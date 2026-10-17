// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { GerenciaReporteDialog } from "@/features/escritorio/windows/Reportes/GerenciaReporteDialog";

export function Rpt010Importaciones() {
  return <GerenciaReporteDialog label="010 - Importaciones" />;
}

export function GerenciaImportacionesWindow() {
  return <Rpt010Importaciones />;
}

export function ReporteImportacion({ title = "Reporte de Importaciones" }: { title?: string }) {
  return <ReporteImportacionList title={title} />;
}
export function ReporteImportacionList({ title = "Reporte Importacion " }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <GerenciaImportacionesWindow />
    </div>
  );
}
