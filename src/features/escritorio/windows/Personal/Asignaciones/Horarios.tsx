// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function HorariosList() {
  return <MantenimientoCRUDList label="Horarios" columns={["Código", "Horario", "Entrada", "Salida", "Tolerancia", "Estado"]} />;
}
