// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState } from "react";
import { Check, FileSpreadsheet, Filter, DollarSign } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function CtasXCobrarList() {
  const [search, setSearch] = useState("");
  const [vendor, setVendor] = useState("Todos");
  const [state, setState] = useState("Todos");
  const [currency, setCurrency] = useState("PEN");
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");

  return (
    <WindowShell title="Cuentas por Cobrar — Gestión de Deudas"
      toolbar={<>
        <input className={`${inp} w-64`} placeholder="Cliente / RUC / Documento..." value={search} onChange={(e) => setSearch(e.target.value)} />
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><DollarSign className="h-3.5 w-3.5" />Registrar Cobro</button>
        <button className={btn}><Check className="h-3.5 w-3.5" />Marcar Cobrado</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
        <span className="ml-auto text-[11px] text-slate-500">Deuda total: <b className="text-red-700">S/ 0.00</b></span>
      </>}>
      <div className="grid grid-cols-4 gap-2 mb-2 text-[11px]">
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Vigente:</span> <b className="font-mono text-slate-900">S/ 0.00</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Vencido:</span> <b className="font-mono text-red-700">S/ 0.00</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Cobrado:</span> <b className="font-mono text-emerald-700">S/ 0.00</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Registros:</span> <b className="font-mono text-slate-900">0</b></div>
      </div>
      <div className="grid grid-cols-6 gap-2 mb-3">
        <Field label="Vendedor"><select className={inp} value={vendor} onChange={(e) => setVendor(e.target.value)}><option>Todos</option></select></Field>
        <Field label="Estado"><select className={inp} value={state} onChange={(e) => setState(e.target.value)}><option>Todos</option><option>Vigente</option><option>Vencido</option><option>Cobrado</option></select></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>PEN</option><option>USD</option></select></Field>
        <Field label="Desde"><input className={inp} type="date" value={fromDate} onChange={(e) => setFromDate(e.target.value)} /></Field>
        <Field label="Hasta"><input className={inp} type="date" value={toDate} onChange={(e) => setToDate(e.target.value)} /></Field>
        <Field label="Cond. Pago"><select className={inp}><option>(Todas)</option><option>CONTADO</option><option>CRÉDITO 15</option><option>CRÉDITO 30</option></select></Field>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]">
            <tr>
              <th className="px-2 py-2 text-left border-b border-slate-300">Doc.</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Fecha Emis.</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Vence</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Moneda</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Total</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Saldo</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Días</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Estado</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Acción</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td colSpan={10} className="px-2 py-4 text-sm text-slate-500">No hay cuentas por cobrar.</td>
            </tr>
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}
