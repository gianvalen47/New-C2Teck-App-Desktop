import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function Recalcular({ title = "Recalcular" }: { title?: string }) {
  return <RecalcularList title={title} />;
}
export function RecalcularList({ title = "Recalcular " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
