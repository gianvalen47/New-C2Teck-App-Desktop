import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function TrasladarCostos({ title = "Trasladar Costos" }: { title?: string }) {
  return <TrasladarCostosList title={title} />;
}
export function TrasladarCostosList({ title = "Trasladar Costos " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
