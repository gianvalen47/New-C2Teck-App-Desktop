import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReporteReembolso({ title = "Reporte Reembolso" }: { title?: string }) {
  return <ReporteReembolsoList title={title} />;
}
export function ReporteReembolsoList({ title = "Reporte Reembolso " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
