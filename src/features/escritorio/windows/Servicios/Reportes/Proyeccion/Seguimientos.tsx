import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function Seguimientos({ title = "Seguimientos" }: { title?: string }) {
  return <SeguimientosList title={title} />;
}
export function SeguimientosList({ title = "Seguimientos " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
