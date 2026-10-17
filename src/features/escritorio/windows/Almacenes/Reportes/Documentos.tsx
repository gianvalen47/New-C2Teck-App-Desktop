import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function DocumentoReporte({ title = "Documento Reporte" }: { title?: string }) {
  return <DocumentoReporteList title={title} />;
}
export function DocumentoReporteList({ title = "Documento Reporte " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
