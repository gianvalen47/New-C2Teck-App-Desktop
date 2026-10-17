import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function HorasDeTrabajo({ title = "Horas De Trabajo" }: { title?: string }) {
  return <HorasDeTrabajoList title={title} />;
}
export function HorasDeTrabajoList({ title = "Horas De Trabajo " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
