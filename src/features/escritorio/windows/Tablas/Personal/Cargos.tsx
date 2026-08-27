// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function CargosList() {
  return <MantenimientoCRUDList label="Cargos" columns={["Código", "Cargo", "Área", "Nivel", "Estado"]} />;
}
