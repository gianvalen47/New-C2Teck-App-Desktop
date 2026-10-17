import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function TarjetaCliente({ title = "Tarjeta Cliente" }: { title?: string }) {
  return <TarjetaClienteList title={title} />;
}
export function TarjetaClienteList({ title = "Tarjeta Cliente " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
