import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function MovimientoRepuestos({ title = "Movimiento Repuestos" }: { title?: string }) {
  return <MovimientoRepuestosList title={title} />;
}
export function MovimientoRepuestosList({ title = "Movimiento Repuestos " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
