import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function GastosDetallado({ title = "Gastos Detallado" }: { title?: string }) {
  return <GastosDetalladoList title={title} />;
}
export function GastosDetalladoList({ title = "Gastos Detallado " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
