import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReporteTransferencia({ title = "Reporte Transferencia" }: { title?: string }) {
  return <ReporteTransferenciaList title={title} />;
}
export function ReporteTransferenciaList({ title = "Reporte Transferencia " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
