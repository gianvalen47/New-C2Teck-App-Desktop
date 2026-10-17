import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ReporteOrdenImportacion({
  title = "Reporte Orden Importacion",
}: {
  title?: string;
}) {
  return <ReporteOrdenImportacionList title={title} />;
}
export function ReporteOrdenImportacionList({
  title = "Reporte Orden Importacion ",
}: {
  title?: string;
}) {
  return <RegistryWindowList title={title} />;
}
