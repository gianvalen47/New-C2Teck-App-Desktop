// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { GerenciaReporteDialog } from "@/features/escritorio/windows/Reportes/GerenciaReporteDialog";

export function Rpt020InventarioYCostos() {
  return <GerenciaReporteDialog label="020 - Inventario y Costos" />;
}

export function GerenciaInventarioCostosWindow() {
  return <Rpt020InventarioYCostos />;
}

export function ReporteInvencos({ title = "Reporte de Inventario y Costos" }: { title?: string }) {
  return <ReporteInvencosList title={title} />;
}
export function ReporteInvencosList({ title = "Reporte Invencos " }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <GerenciaInventarioCostosWindow />
    </div>
  );
}
