// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function AreasList() {
  return <MantenimientoCRUDList label="Áreas" columns={["Código", "Área", "Responsable", "Estado"]} />;
}
