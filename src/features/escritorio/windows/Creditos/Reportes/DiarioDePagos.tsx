import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReporteDiario({ title = "Reporte Diario" }: { title?: string }) {
  return <ReporteDiarioList title={title} />;
}
export function ReporteDiarioList({ title = "Reporte Diario " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
