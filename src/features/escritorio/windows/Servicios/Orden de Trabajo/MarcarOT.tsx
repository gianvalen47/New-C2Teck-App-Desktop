import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function MarcarOT({ title = "Marcar OT" }: { title?: string }) {
  return <MarcarOTList title={title} />;
}
export function MarcarOTList({ title = "Marcar OT " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
