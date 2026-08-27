// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function MotivosFaltasList() {
  return <MantenimientoCRUDList label="Motivos de Faltas" columns={["Código", "Motivo", "Justificada", "Descuenta", "Estado"]} />;
}
