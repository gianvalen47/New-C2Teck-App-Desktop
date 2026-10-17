import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function VentasPorMantenimientos({
  title = "Ventas Por Mantenimientos",
}: {
  title?: string;
}) {
  return <VentasPorMantenimientosList title={title} />;
}
export function VentasPorMantenimientosList({
  title = "Ventas Por Mantenimientos ",
}: {
  title?: string;
}) {
  return <RegistryWindowList title={title} />;
}
