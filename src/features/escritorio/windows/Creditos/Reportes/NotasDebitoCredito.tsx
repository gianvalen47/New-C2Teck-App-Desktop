import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReporteNotDebCred({ title = "Reporte Not Deb Cred" }: { title?: string }) {
  return <ReporteNotDebCredList title={title} />;
}
export function ReporteNotDebCredList({ title = "Reporte Not Deb Cred " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
