import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function Acumulado({ title = "Acumulado" }: { title?: string }) {
  return <AcumuladoList title={title} />;
}
export function AcumuladoList({ title = "Acumulado " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
