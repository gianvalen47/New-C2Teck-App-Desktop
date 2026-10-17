import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReportProvisionales({ title = "Report Provisionales" }: { title?: string }) {
  return <ReportProvisionalesList title={title} />;
}
export function ReportProvisionalesList({ title = "Report Provisionales " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
