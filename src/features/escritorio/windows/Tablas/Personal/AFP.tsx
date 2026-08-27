// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function AFPList() {
  return <MantenimientoCRUDList label="AFP" columns={["Código", "AFP", "Comisión %", "Prima %", "Aporte %", "Estado"]} />;
}
