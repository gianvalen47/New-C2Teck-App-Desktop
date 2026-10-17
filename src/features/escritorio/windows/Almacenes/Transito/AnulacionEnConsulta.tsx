import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";
// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
export { TransitoDocs as AnulacionEnConsulta } from "@/features/escritorio/windows/Almacenes/Transito/Documentos";

export function AnulacionConsulta({ title = "Anulacion Consulta" }: { title?: string }) {
  return <AnulacionConsultaList title={title} />;
}
export function AnulacionConsultaList({ title = "Anulacion Consulta " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
