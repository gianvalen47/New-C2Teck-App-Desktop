// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function PartidasList() {
  return <MantenimientoCRUDList label="Partidas Arancelarias" columns={["Partida", "Descripción", "Ad Valorem", "Estado"]} />;
}
