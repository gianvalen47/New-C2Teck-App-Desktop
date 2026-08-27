// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { ListingBrowser4 } from "@/features/escritorio/windows/shared/LegacySupport";
import { stdToolbar4 } from "@/features/escritorio/windows/shared/toolbarPresets";

export function GuiaDevolucionList() {
  return (
    <ListingBrowser4
      toolbar2={stdToolbar4}
      columns={["Número", "Fecha", "Referencia", "Cliente", "Mon.", "Total", "EST", "Doc.Devuelto", "TipMov"]}
      rows={0}
    />
  );
}
