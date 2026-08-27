// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function TarifaTaxisCasaList() {
  return <MantenimientoCRUDList label="Tarifa Taxis Casa" columns={["Zona", "Horario", "Moneda", "Tarifa", "Estado"]} />;
}
