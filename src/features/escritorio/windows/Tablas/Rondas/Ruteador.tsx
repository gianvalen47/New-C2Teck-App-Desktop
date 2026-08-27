// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function RuteadorList() {
  return <MantenimientoCRUDList label="Ruteadores de Rondas" columns={["Código", "Ruteador", "Zona", "Estado"]} />;
}
