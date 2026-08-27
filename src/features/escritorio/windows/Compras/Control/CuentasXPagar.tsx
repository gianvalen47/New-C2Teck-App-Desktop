// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  Field,
  SearchBar,
  ListQueryForm
} from "@/components/ui/desktop-primitives";

export function CtasXPagarList() {
  return (
    <ListQueryForm
      title="Cuentas por Pagar — Programación de Pagos"
      toolbar={<>
      </>}
      extraTop={
        <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Vigente:</span> <b className="font-mono text-slate-900">S/ 0.00</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Vencido:</span> <b className="font-mono text-red-700">S/ 0.00</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Programado:</span> <b className="font-mono text-amber-700">S/ 0.00</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pagado:</span> <b className="font-mono text-emerald-700">S/ 0.00</b></div>
        </div>
      }
      filters={
        <SearchBar>
          <Field label="Proveedor" className="w-64"><input className={inp} placeholder="RUC / Razón Social" /></Field>
          <Field label="Estado" className="w-32"><select className={inp}><option>Todos</option><option>Vigente</option><option>Vencido</option><option>Pagado</option></select></Field>
          <Field label="Moneda" className="w-24"><select className={inp}><option>(Todas)</option><option>PEN</option><option>USD</option></select></Field>
          <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
          <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </SearchBar>
      }
      columns={["Doc.", "Fecha", "Vence", "Proveedor", "Moneda", "Total", "Saldo", "Días", "Estado", "Acción"]}
      rows={10}
    />
  );
}
