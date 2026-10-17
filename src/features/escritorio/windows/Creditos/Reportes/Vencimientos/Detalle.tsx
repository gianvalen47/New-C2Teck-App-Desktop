import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function Detalle({ title = "Detalle" }: { title?: string }) {
  return <DetalleList title={title} />;
}
export function DetalleList({ title = "Detalle " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
