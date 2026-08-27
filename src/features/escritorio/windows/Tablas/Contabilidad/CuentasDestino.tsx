// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function CuentasDestinoList() {
  return <MantenimientoCRUDList label="Cuentas Destino" columns={["Cuenta", "Destino", "Módulo", "Estado"]} />;
}
