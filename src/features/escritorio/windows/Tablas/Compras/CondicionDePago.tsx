// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function CondicionDePagoList() {
  return <MantenimientoCRUDList label="Condición de Pago" columns={["Código", "Descripción", "Días", "Tipo", "Estado"]} />;
}
