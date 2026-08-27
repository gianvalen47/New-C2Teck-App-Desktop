// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function CuentaContableList() {
  return <MantenimientoCRUDList label="Cuentas Contables" columns={["Cuenta", "Descripción", "Naturaleza", "Nivel", "Estado"]} />;
}
