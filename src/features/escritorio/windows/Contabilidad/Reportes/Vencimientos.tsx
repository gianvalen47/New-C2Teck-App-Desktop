import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReporteVencimiento({ title = "Reporte Vencimiento" }: { title?: string }) {
  return <ReporteVencimientoList title={title} />;
}
export function ReporteVencimientoList({ title = "Reporte Vencimiento " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
