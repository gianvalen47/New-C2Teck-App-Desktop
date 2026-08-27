// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function EquipoLectorList() {
  return <MantenimientoCRUDList label="Equipos Lectores (Biométricos)" columns={["Serie", "Marca", "IP", "Sede", "Estado"]} />;
}
