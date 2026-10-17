import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReporteClientes({ title = "Reporte Clientes" }: { title?: string }) {
  return <ReporteClientesList title={title} />;
}
export function ReporteClientesList({ title = "Reporte Clientes " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
