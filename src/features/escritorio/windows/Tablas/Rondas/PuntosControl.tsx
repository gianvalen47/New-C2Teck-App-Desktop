// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function PuntosControlList() {
  return <MantenimientoCRUDList label="Puntos de Control" columns={["Código", "Punto", "Dirección", "Ruta", "Estado"]} />;
}
