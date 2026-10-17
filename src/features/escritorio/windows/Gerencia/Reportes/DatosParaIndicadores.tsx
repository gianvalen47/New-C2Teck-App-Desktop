// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { GerenciaReporteDialog } from "@/features/escritorio/windows/Reportes/GerenciaReporteDialog";

export function DatosParaIndicadores() {
  return <GerenciaReporteDialog label="Datos para Indicadores" />;
}

export function DatosParaIndicadoresWindow() {
  return <DatosParaIndicadores />;
}

export function ReporteIndicador({ title = "Datos para Indicadores" }: { title?: string }) {
  return <ReporteIndicadorList title={title} />;
}
export function ReporteIndicadorList({ title = "Reporte Indicador " }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <DatosParaIndicadoresWindow />
    </div>
  );
}
