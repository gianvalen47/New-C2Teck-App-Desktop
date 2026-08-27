// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, Plus } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function ViaticosList() {
  return (
    <WindowShell title="Planilla de Viáticos — Liquidación de Gastos de Viaje"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Liquidar</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Añadir gasto</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Personal" className="col-span-2"><input className={inp} /></Field>
        <Field label="Destino"><input className={inp} /></Field>
        <Field label="Motivo"><select className={inp}><option>Visita técnica</option><option>Visita comercial</option><option>Capacitación</option></select></Field>
        <Field label="Fecha Ida"><input className={inp} type="date" /></Field>
        <Field label="Fecha Retorno"><input className={inp} type="date" /></Field>
        <Field label="Adelanto S/"><input className={inp} type="number" /></Field>
        <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
      </div>
      <div className="mt-3"><DataTable columns={["#", "Fecha", "Concepto", "Comprobante", "Categoría", "Monto"]} rows={6} /></div>
      <div className="mt-3 grid grid-cols-4 gap-2 max-w-md ml-auto text-[11.5px]">
        <div className="text-right text-slate-600 col-span-3">Total gastado:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right text-slate-600 col-span-3">Adelanto:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right font-bold text-[#2A3F55] col-span-3">Saldo a favor / a devolver:</div><div className="text-right font-mono font-bold">0.00</div>
      </div>
    </WindowShell>
  );
}
