import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function Programacion({ title = "Programacion" }: { title?: string }) {
  return <ProgramacionList title={title} />;
}
export function ProgramacionList({ title = "Programacion " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
