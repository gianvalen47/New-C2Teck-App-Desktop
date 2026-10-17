import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function OT({ title = "OT" }: { title?: string }) {
  return <OTList title={title} />;
}
export function OTList({ title = "OT " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
