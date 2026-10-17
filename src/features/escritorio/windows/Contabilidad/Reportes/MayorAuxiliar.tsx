import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReportAuxiliar({ title = "Report Auxiliar" }: { title?: string }) {
  return <ReportAuxiliarList title={title} />;
}
export function ReportAuxiliarList({ title = "Report Auxiliar " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
