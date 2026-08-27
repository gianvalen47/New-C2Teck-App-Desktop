// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { X, Save } from "lucide-react";
import {
  btn,
  btnPrimary,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function AtenderSolicitudList() {
  return (
    <WindowShell title="Atender Solicitudes de Acceso"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Aprobar</button>
        <button className={btn}><X className="h-3.5 w-3.5" />Rechazar</button>
      </>}>
      <DataTable columns={["Fecha", "Usuario", "Solicitud", "Módulo", "Solicitado a", "Estado"]} rows={8} />
    </WindowShell>
  );
}
