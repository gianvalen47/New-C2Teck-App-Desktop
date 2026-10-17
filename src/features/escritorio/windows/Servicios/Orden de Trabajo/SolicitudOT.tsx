import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function SolicitudOT({ title = "Solicitud OT" }: { title?: string }) {
  return <SolicitudOTList title={title} />;
}
export function SolicitudOTList({ title = "Solicitud OT " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
