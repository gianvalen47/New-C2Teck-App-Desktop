// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function RubroPlanillaList() {
  return <MantenimientoCRUDList label="Rubros de Planilla" columns={["Código", "Rubro", "Tipo", "Afecta", "Estado"]} />;
}
