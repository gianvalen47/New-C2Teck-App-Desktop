import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function RepuestosAImportar({ title = "Repuestos A Importar" }: { title?: string }) {
  return <RepuestosAImportarList title={title} />;
}
export function RepuestosAImportarList({ title = "Repuestos A Importar " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
