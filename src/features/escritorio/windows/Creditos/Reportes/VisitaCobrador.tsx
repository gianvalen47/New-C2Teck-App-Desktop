import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReporteVisCo({ title = "Reporte de Visita de Cobrador" }: { title?: string }) {
  return <ReporteViscoList title={title} />;
}
export function ReporteViscoList({ title = "Reporte de Visita de Cobrador" }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
