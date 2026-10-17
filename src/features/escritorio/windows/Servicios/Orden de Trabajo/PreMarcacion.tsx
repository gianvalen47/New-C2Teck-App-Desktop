import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function PreMarcacion({ title = "Pre Marcacion" }: { title?: string }) {
  return <PreMarcacionList title={title} />;
}
export function PreMarcacionList({ title = "Pre Marcacion " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
