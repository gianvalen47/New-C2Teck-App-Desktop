import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReporteSolicitudOT({ title = "Reporte Solicitud OT" }: { title?: string }) {
  return <ReporteSolicitudOTList title={title} />;
}
export function ReporteSolicitudOTList({ title = "Reporte Solicitud OT " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
