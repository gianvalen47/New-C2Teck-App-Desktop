import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function Actividades({ title = "Actividades" }: { title?: string }) {
  return <ActividadesList title={title} />;
}
export function ActividadesList({ title = "Actividades " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
