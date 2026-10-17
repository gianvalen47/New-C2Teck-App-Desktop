import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function RegistroDeCompras({ title = "Registro De Compras" }: { title?: string }) {
  return <RegistroDeComprasList title={title} />;
}
export function RegistroDeComprasList({ title = "Registro De Compras " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
