import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function PrecioConsulta({ title = "Precio Consulta" }: { title?: string }) {
  return <PrecioConsultaList title={title} />;
}
export function PrecioConsultaList({ title = "Precio Consulta " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
