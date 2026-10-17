import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReporteDocEmi({ title = "Reporte Doc Emi" }: { title?: string }) {
  return <ReporteDocEmiList title={title} />;
}
export function ReporteDocEmiList({ title = "Reporte Doc Emi " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
