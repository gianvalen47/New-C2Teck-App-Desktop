// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Printer, FileDown, FileSpreadsheet, RefreshCw, Filter } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function ReporteContainerList({ label }: { label: string }) {
  return (
    <WindowShell title={`Reporte — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <Field label=""><input className={inp} type="date" /></Field>
        <span className="text-[11px] text-slate-500">a</span>
        <Field label=""><input className={inp} type="date" /></Field>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
        <div className="ml-auto flex gap-1.5">
          <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
          <button className={btn}><FileDown className="h-3.5 w-3.5" />PDF</button>
          <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
        </div>
      </>}>
      <div className="text-[11px] text-slate-500 mb-2">
        Filtro pre-seleccionado: <b className="text-[#2A3F55]">{label}</b>
      </div>
      <DataTable columns={["#", "Fecha", "Documento", "Cliente / Ref.", "Vendedor", "Moneda", "Base", "IGV", "Total"]} rows={10} />
    </WindowShell>
  );
}
