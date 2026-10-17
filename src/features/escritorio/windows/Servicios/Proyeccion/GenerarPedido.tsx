import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function GenerarPedido({ title = "Generar Pedido" }: { title?: string }) {
  return <GenerarPedidoList title={title} />;
}
export function GenerarPedidoList({ title = "Generar Pedido " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
