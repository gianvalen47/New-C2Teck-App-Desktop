// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, Plus } from "lucide-react";
import {
  btn,
  btnPrimary,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function ComputadoraInvList() {
  return (
    <WindowShell title="Computadoras — Inventario Informático"
      toolbar={<>
        <button className={btnPrimary}><Plus className="h-3.5 w-3.5" />Nuevo</button>
        <button className={btn}><Save className="h-3.5 w-3.5" />Guardar</button>
      </>}>
      <DataTable columns={["Serie", "Marca", "Modelo", "Procesador", "RAM", "Almacenamiento", "Sede", "Estado"]} rows={10} />
    </WindowShell>
  );
}
