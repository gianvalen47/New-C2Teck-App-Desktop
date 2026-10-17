import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";
// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
export { TipoCambioList as TipoCambioVentas } from "@/features/escritorio/windows/Creditos/Mantenimiento/RenuevaTipoCambio";

export function TipoCambiosVentas({ title = "Tipo Cambios Ventas" }: { title?: string }) {
  return <TipoCambiosVentasList title={title} />;
}
export function TipoCambiosVentasList({ title = "Tipo Cambios Ventas " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
