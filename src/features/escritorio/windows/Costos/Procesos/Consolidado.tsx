import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function Consolidado({ title = "Consolidado" }: { title?: string }) {
  return <ConsolidadoList title={title} />;
}
export function ConsolidadoList({ title = "Consolidado " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
