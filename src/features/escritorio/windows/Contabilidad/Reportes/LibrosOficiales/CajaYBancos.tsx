import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function CajaYBancos({ title = "Caja Y Bancos" }: { title?: string }) {
  return <CajaYBancosList title={title} />;
}
export function CajaYBancosList({ title = "Caja Y Bancos " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
