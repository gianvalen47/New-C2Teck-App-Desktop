import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function DiarioCompras({ title = "Diario Compras" }: { title?: string }) {
  return <DiarioComprasList title={title} />;
}
export function DiarioComprasList({ title = "Diario Compras " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
