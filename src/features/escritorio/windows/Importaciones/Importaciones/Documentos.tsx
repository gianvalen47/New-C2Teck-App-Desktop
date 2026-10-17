import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ImportDoc({ title = "Import Doc" }: { title?: string }) {
  return <ImportDocList title={title} />;
}
export function ImportDocList({ title = "Import Doc " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
