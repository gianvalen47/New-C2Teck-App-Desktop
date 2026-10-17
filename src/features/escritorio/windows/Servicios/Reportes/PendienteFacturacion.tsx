import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function PendienteFacturacion({ title = "Pendiente Facturacion" }: { title?: string }) {
  return <PendienteFacturacionList title={title} />;
}
export function PendienteFacturacionList({ title = "Pendiente Facturacion " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
