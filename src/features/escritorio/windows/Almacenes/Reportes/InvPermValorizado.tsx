import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReporteValorizado({ title = "Reporte Valorizado" }: { title?: string }) {
  return <ReporteValorizadoList title={title} />;
}
export function ReporteValorizadoList({ title = "Reporte Valorizado " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
