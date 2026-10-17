import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ActualizarCostos({ title = "Actualizar Costos" }: { title?: string }) {
  return <ActualizarCostosList title={title} />;
}
export function ActualizarCostosList({ title = "Actualizar Costos " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
