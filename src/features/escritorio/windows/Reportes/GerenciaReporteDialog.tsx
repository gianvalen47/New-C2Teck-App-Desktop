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

export function GerenciaReporteDialogList({ label }: { label: string }) {
  const n = label.toLowerCase();
  const isFinanzas = n.includes("financier") || n.includes("contabilidad") || n.includes("ctas");
  const isIndicadores = n.includes("indicador") || n.includes("tarjeta");

  return (
    <WindowShell title={`Gerencia — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Actualizar</button>
        <div className="ml-auto flex gap-1.5">
          <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
          <button className={btn}><FileDown className="h-3.5 w-3.5" />PDF</button>
        </div>
      </>}>
      <div className="p-3 space-y-2 max-w-5xl mx-auto text-[11.5px] text-slate-800">

        <Fs legend="Rango Ejecutivo">
          <Field label="Desde"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <Field label="Empresa"><select className={inp}><option>(Todas)</option><option>C2TECK S.A.C.</option><option>Sucursal Norte</option></select></Field>
          <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
          {isFinanzas && <Field label="Centro Costo"><select className={inp}><option>(Todos)</option><option>Administración</option><option>Operaciones</option><option>Servicios</option></select></Field>}
          {isIndicadores && <Field label="Frecuencia"><select className={inp}><option>Diaria</option><option>Semanal</option><option>Mensual</option></select></Field>}
        </Fs>

        <DataTable columns={["Periodo", "Unidad", "Indicador", "Meta", "Real", "Desvío", "Estado"]} rows={8} />
      </div>
    </WindowShell>
  );
}
