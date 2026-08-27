// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, FileSpreadsheet, Filter } from "lucide-react";
import {
  btn,
  btnPrimary,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function ActMinMaxList() {
  return (
    <WindowShell title="Actualización masiva de Stock Min / Max"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Aplicar cambios</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Importar Excel</button>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtrar categoría</button>
      </>}>
      <DataTable columns={["Código", "Producto", "Categoría", "Stock Actual", "Min Actual", "Max Actual", "Min Nuevo", "Max Nuevo"]} rows={10} />
    </WindowShell>
  );
}
