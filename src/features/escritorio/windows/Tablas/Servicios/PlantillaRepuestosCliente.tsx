// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function PlantillaRepuestosClienteList() {
  return <MantenimientoCRUDList label="Plantillas de Repuestos por Cliente" columns={["Cliente", "Plantilla", "Modelo", "Vigencia", "Estado"]} />;
}
