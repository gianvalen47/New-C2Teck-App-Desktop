import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function LibroMayor({ title = "Libro Mayor" }: { title?: string }) {
  return <LibroMayorList title={title} />;
}
export function LibroMayorList({ title = "Libro Mayor " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
