import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function GastosPorRubros({ title = "Gastos Por Rubros" }: { title?: string }) {
  return <GastosPorRubrosList title={title} />;
}
export function GastosPorRubrosList({ title = "Gastos Por Rubros " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
