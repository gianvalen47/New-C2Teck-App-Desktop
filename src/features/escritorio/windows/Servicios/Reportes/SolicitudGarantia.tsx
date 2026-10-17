import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function SolicitudGarantia({ title = "Solicitud Garantia" }: { title?: string }) {
  return <SolicitudGarantiaList title={title} />;
}
export function SolicitudGarantiaList({ title = "Solicitud Garantia " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
