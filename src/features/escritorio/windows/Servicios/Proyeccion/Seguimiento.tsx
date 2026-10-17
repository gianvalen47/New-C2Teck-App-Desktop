import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function Seguimiento({ title = "Seguimiento" }: { title?: string }) {
  return <SeguimientoList title={title} />;
}
export function SeguimientoList({ title = "Seguimiento " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
