// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { TipoCambio as TipoCambioWindow } from "@/features/escritorio/windows/Creditos/Mantenimiento/RenuevaTipoCambio";

export function MantenimientoTipoDeCambio({ title = "Mantenimiento Tipo De Cambio" }: { title?: string }) {
  return <MantenimientoTipoDeCambioList title={title} />;
}
export function MantenimientoTipoDeCambioList({ title = "Mantenimiento Tipo De Cambio " }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <TipoCambioWindow />
    </div>
  );
}
