import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function DocumentoConsulta({ title = "Documento Consulta" }: { title?: string }) {
  return <DocumentoConsultaList title={title} />;
}
export function DocumentoConsultaList({ title = "Documento Consulta " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
