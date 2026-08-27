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

export function CreditosReporteDialogList({ label }: { label: string }) {
  return (
    <WindowShell title={`Créditos — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
      </>}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Fechas">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Cobrador"><input className={inp} /></Field>
          <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Vigente</option><option>Vencido</option><option>Cancelado</option></select></Field>
        </Fs>
        <DataTable columns={["Documento", "Cliente", "Emisión", "Vence", "Saldo", "Estado", "Responsable"]} rows={8} />
      </div>
    </WindowShell>
  );
}
