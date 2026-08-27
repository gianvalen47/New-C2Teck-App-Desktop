// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { ListingBrowser6 } from "@/features/escritorio/windows/shared/LegacySupport";
import { stdToolbar6 } from "@/features/escritorio/windows/shared/toolbarPresets";
import { Notas } from "@/features/escritorio/windows/Ventas/Documentos/Notas";

export function ResumenDeBoletasList() {
  return (
    <ListingBrowser6
      toolbar2={stdToolbar6}
      columns={["Cod. Resumen", "Fecha", "N° Ticket", "Observacion", "Notas", "Estado Sunat"]}
      rows={0}
    />
  );
}
