import { DataTable, WindowShell } from "@/components/ui/desktop-primitives";

export function InfoCambiosList({
  title = "Información de Cambios — Changelog",
}: {
  title?: string;
}) {
  return (
    <WindowShell title={title}>
      <DataTable
        columns={["Versión", "Fecha", "Módulo", "Tipo", "Descripción"]}
        rows={10}
      />
    </WindowShell>
  );
}
