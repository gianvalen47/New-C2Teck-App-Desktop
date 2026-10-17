// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { GerenciaReporteDialog } from "@/features/escritorio/windows/Reportes/GerenciaReporteDialog";

export function Tarjeta() {
  return <GerenciaReporteDialog label="Tarjeta" />;
}

export function TarjetaGerenciaWindow() {
  return <Tarjeta />;
}

export function ReporteTarjeta({ title = "Tarjeta de Gerencia" }: { title?: string }) {
  return <ReporteTarjetaList title={title} />;
}
export function ReporteTarjetaList({ title = "Reporte Tarjeta " }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <TarjetaGerenciaWindow />
    </div>
  );
}
