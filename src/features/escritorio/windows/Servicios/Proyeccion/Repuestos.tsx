import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function Repuestos({ title = "Repuestos" }: { title?: string }) {
  return <RepuestosList title={title} />;
}
export function RepuestosList({ title = "Repuestos " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
