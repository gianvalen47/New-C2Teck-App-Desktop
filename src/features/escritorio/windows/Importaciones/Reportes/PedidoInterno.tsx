import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function PedidoInterno({ title = "Pedido Interno" }: { title?: string }) {
  return <PedidoInternoList title={title} />;
}
export function PedidoInternoList({ title = "Pedido Interno " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
