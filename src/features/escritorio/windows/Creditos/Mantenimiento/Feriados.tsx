// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function FeriadosList() {
  return <MantenimientoCRUDList label="Feriados" columns={["Fecha", "Descripción", "Tipo", "Ámbito", "Estado"]} />;
}
