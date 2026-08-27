// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function PlantillaRepuestosList() {
  return <MantenimientoCRUDList label="Plantillas de Repuestos" columns={["Código", "Plantilla", "Modelo", "Nº items", "Estado"]} />;
}
