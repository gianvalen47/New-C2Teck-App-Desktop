import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReporteInventario({ title = "Reporte Inventario" }: { title?: string }) {
  return <ReporteInventarioList title={title} />;
}
export function ReporteInventarioList({ title = "Reporte Inventario " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
