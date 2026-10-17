import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReportePlanillas({ title = "Reporte Planillas" }: { title?: string }) {
  return <ReportePlanillasList title={title} />;
}
export function ReportePlanillasList({ title = "Reporte Planillas " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
