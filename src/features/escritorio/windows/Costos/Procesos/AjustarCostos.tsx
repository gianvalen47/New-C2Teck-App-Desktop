import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function AjustarCostos({ title = "Ajustar Costos" }: { title?: string }) {
  return <AjustarCostosList title={title} />;
}
export function AjustarCostosList({ title = "Ajustar Costos " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
