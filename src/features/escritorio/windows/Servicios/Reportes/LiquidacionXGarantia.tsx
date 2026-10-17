import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function LiquidacionXGarantia({ title = "Liquidacion X Garantia" }: { title?: string }) {
  return <LiquidacionXGarantiaList title={title} />;
}
export function LiquidacionXGarantiaList({
  title = "Liquidacion X Garantia ",
}: {
  title?: string;
}) {
  return <RegistryWindowList title={title} />;
}
