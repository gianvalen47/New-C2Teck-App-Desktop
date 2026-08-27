// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function TarifaGastoViajeList() {
  return <MantenimientoCRUDList label="Tarifa Gasto Viaje" columns={["Ruta", "Categoría", "Moneda", "Tarifa", "Estado"]} />;
}
