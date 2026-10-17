import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function TableroIndicador({ title = "Tablero Indicador" }: { title?: string }) {
  return <TableroIndicadorList title={title} />;
}
export function TableroIndicadorList({ title = "Tablero Indicador " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
