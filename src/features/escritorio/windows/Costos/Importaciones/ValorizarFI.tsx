import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ImportValorizarFI({ title = "Import Valorizar FI" }: { title?: string }) {
  return <ImportValorizarFIList title={title} />;
}
export function ImportValorizarFIList({ title = "Import Valorizar FI " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
