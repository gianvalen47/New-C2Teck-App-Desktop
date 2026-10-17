import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function Tablero({ title = "Tablero" }: { title?: string }) {
  return <TableroList title={title} />;
}
export function TableroList({ title = "Tablero " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
