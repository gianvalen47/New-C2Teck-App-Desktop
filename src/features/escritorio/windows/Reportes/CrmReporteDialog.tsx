// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { FileDown, FileSpreadsheet, RefreshCw, Filter } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  DataTable,
  WindowShell,
  Fs
} from "@/components/ui/desktop-primitives";

export function CrmReporteDialogList({ label }: { label: string }) {
  const n = label.toLowerCase();
  const isOportunidad = n.includes("oportunidad");
  const isVisita = n.includes("visita");

  return (
    <WindowShell title={`CRM — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
        <div className="ml-auto flex gap-1.5">
          <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
          <button className={btn}><FileDown className="h-3.5 w-3.5" />PDF</button>
        </div>
      </>}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Fechas">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
        </Fs>

        <Fs legend="Filtro Comercial">
          <Field label="Cliente"><input className={inp} /></Field>
          <Field label="Ejecutivo"><input className={inp} /></Field>
          <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Abierto</option><option>En negociación</option><option>Cerrado</option></select></Field>
          {isOportunidad && <Field label="Etapa"><select className={inp}><option>(Todas)</option><option>Prospección</option><option>Cotización</option><option>Negociación</option></select></Field>}
          {isVisita && <Field label="Tipo visita"><select className={inp}><option>(Todas)</option><option>Comercial</option><option>Técnica</option><option>Postventa</option></select></Field>}
        </Fs>

        <DataTable columns={["Fecha", "Cliente", "Ejecutivo", "Actividad", "Estado", "Monto", "Resultado"]} rows={8} />
      </div>
    </WindowShell>
  );
}
