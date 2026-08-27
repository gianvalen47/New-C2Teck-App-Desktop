// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { ListingBrowser5 } from "@/features/escritorio/windows/shared/LegacySupport";
import { stdToolbar5 } from "@/features/escritorio/windows/shared/toolbarPresets";

export function BoletaList() {
  return (
    <ListingBrowser5
      toolbar2={stdToolbar5}
      columns={["Número", "Fecha", "Cliente", "Mon.", "Total", "EST", "Estado Sunat", "C", "TotNetoSug", "ObservacionSunat"]}
      rows={0}
    />
  );
}
