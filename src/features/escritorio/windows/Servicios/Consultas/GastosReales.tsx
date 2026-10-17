import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ConsultasGastosReales({ title = "Consultas Gastos Reales" }: { title?: string }) {
  return <ConsultasGastosRealesList title={title} />;
}
export function ConsultasGastosRealesList({
  title = "Consultas Gastos Reales ",
}: {
  title?: string;
}) {
  return <RegistryWindowList title={title} />;
}
