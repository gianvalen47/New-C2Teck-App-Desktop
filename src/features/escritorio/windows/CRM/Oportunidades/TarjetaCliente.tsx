import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function CRMTarjetaCliente({ title = "CRM Tarjeta Cliente" }: { title?: string }) {
  return <CRMTarjetaClienteList title={title} />;
}
export function CRMTarjetaClienteList({ title = "CRM Tarjeta Cliente " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
