// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function TarifaTaxiDestinoList() {
  return <MantenimientoCRUDList label="Tarifas Taxi Destino" columns={["Destino", "Tipo", "Moneda", "Tarifa", "Estado"]} />;
}
