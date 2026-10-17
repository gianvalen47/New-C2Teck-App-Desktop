import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReporteOT({ title = "Reporte OT" }: { title?: string }) {
  return <ReporteOTList title={title} />;
}
export function ReporteOTList({ title = "Reporte OT " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
