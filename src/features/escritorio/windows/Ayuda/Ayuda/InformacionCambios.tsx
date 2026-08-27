// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import {
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function InfoCambios() {
  return (
    <WindowShell title="Información de Cambios — Changelog">
      <DataTable columns={["Versión", "Fecha", "Módulo", "Tipo", "Descripción"]} rows={10} />
    </WindowShell>
  );
}
