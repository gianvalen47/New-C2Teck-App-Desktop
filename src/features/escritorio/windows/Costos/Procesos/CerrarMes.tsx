import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function CerrarMes({ title = "Cerrar Mes" }: { title?: string }) {
  return <CerrarMesList title={title} />;
}
export function CerrarMesList({ title = "Cerrar Mes " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
