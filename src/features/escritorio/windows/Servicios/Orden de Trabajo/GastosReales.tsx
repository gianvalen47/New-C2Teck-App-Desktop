import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function GastosReales({ title = "Gastos Reales" }: { title?: string }) {
  return <GastosRealesList title={title} />;
}
export function GastosRealesList({ title = "Gastos Reales " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
