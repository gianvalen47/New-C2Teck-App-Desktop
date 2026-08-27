// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { MantenimientoCRUDList } from "@/features/escritorio/windows/shared/LegacySupport";

export function ProveedoresList() {
  return <MantenimientoCRUDList label="Proveedores" columns={["RUC", "Razón Social", "Dirección", "Contacto", "Teléfono", "Estado"]} />;
}
