import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ImportEmbarque({ title = "Import Embarque" }: { title?: string }) {
  return <ImportEmbarqueList title={title} />;
}
export function ImportEmbarqueList({ title = "Import Embarque " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
