import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReportesCotizaciones({ title = "Reportes Cotizaciones" }: { title?: string }) {
  return <ReportesCotizacionesList title={title} />;
}
export function ReportesCotizacionesList({ title = "Reportes Cotizaciones " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
