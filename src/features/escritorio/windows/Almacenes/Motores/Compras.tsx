import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function CompraMotores({ title = "Compras de Motores" }: { title?: string }) {
  return <CompraMotoresList title={title} />;
}
export function CompraMotoresList({ title = "Compra Motores " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
