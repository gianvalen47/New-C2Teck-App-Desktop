// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function UbicacionServicioList() {
  return <MantenimientoCRUDList label="Ubicación de Servicio" columns={["Código", "Ubicación", "Sede", "Responsable", "Estado"]} />;
}
