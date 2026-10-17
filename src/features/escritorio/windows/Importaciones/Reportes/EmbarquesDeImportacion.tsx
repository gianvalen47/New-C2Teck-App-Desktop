import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function EmbarqueImportacion({ title = "Embarque Importacion" }: { title?: string }) {
  return <EmbarqueImportacionList title={title} />;
}
export function EmbarqueImportacionList({ title = "Embarque Importacion " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
