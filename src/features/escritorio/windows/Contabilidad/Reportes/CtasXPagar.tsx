import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReportCtasXPagar({ title = "Report Ctas X Pagar" }: { title?: string }) {
  return <ReportCtasXPagarList title={title} />;
}
export function ReportCtasXPagarList({ title = "Report Ctas X Pagar " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
