// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function TipoHoraExtraList() {
  return <MantenimientoCRUDList label="Tipo Hora Extra" columns={["Código", "Tipo", "Factor", "Máximo", "Estado"]} />;
}
