import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function CompraYOGastos({ title = "Compra YO Gastos" }: { title?: string }) {
  return <CompraYOGastosList title={title} />;
}
export function CompraYOGastosList({ title = "Compra YO Gastos " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
