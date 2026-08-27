// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { RefreshCw, Filter } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  DataTable,
  WindowShell,
  Fs
} from "@/components/ui/desktop-primitives";

export function CostosReporteDialogList({ label }: { label: string }) {
  return (
    <WindowShell title={`Costos — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Calcular</button>
      </>}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Período de Costeo">
          <Field label="Mes"><input className={inp} type="month" defaultValue="2026-07" /></Field>
          <Field label="Almacén"><select className={inp}><option>(Todos)</option><option>Central</option><option>Repuestos</option></select></Field>
          <Field label="Método"><select className={inp}><option>Promedio</option><option>PEPS</option></select></Field>
          <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
        </Fs>
        <DataTable columns={["Ítem", "Cantidad", "Costo Unit", "Costo Total", "Venta", "Margen", "Estado"]} rows={8} />
      </div>
    </WindowShell>
  );
}
