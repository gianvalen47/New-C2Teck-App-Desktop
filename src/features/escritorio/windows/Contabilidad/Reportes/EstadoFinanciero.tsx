import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function EstadoFinanciero({ title = "Estado Financiero" }: { title?: string }) {
  return <EstadoFinancieroList title={title} />;
}
export function EstadoFinancieroList({ title = "Estado Financiero " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
