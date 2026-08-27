// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, Plus, Phone } from "lucide-react";
import {
  btn,
  btnPrimary,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function TelefoniaInvList({ title }: { title: string }) {
  return (
    <WindowShell title={title + " — Inventario de Telefonía Corporativa"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nuevo</button>
        <button className={btn}><Phone className="h-3.5 w-3.5" />Operadora</button>
      </>}>
      <DataTable columns={["Código", title, "Marca / Detalle", "Operadora", "Costo mensual", "Estado"]} rows={8} />
    </WindowShell>
  );
}
