// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { ConfigTabla } from "@/features/escritorio/windows/shared/LegacySupport";

export function EmpresasList() {
  return <ConfigTabla title="Empresas" columns={["RUC", "Razón Social", "Sucursal", "Régimen", "Estado"]} />;
}
