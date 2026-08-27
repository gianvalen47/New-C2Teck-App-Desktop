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

export function ComprasReporteDialogList({ label }: { label: string }) {
  return (
    <WindowShell title={`Compras — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
      </>}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Compra">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Proveedor"><input className={inp} placeholder="RUC / Razón Social" /></Field>
          <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Pendiente</option><option>Aprobada</option><option>Pagada</option></select></Field>
        </Fs>
        <DataTable columns={["Fecha", "Documento", "Proveedor", "Moneda", "Base", "IGV", "Total", "Estado"]} rows={8} />
      </div>
    </WindowShell>
  );
}
