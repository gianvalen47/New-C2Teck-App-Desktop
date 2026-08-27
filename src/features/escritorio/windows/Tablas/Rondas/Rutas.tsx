// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function RutasList() {
  return <MantenimientoCRUDList label="Rutas" columns={["Código", "Ruta", "Zona", "Nº puntos", "Estado"]} />;
}
