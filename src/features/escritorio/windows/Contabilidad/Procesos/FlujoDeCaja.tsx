// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { FileSpreadsheet, RefreshCw, Filter } from "lucide-react";
import {
  btn,
  btnPrimary,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function FlujoCajaList() {
  return (
    <WindowShell title="Flujo de Caja Proyectado"
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Recalcular</button>
      </>}>
      <DataTable columns={["Semana", "Ingresos Proyectados", "Cobranza CxC", "Egresos Fijos", "Pagos CxP", "Saldo Neto", "Saldo Acumulado"]} rows={8} />
    </WindowShell>
  );
}
