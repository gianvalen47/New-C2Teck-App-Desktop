// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function TipoMotoresList() {
  return <MantenimientoCRUDList label="Tipo Motores" columns={["Código", "Tipo", "Marca", "Estado"]} />;
}
