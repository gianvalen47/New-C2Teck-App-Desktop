// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState } from "react";
import { Printer, Search, FileSpreadsheet, RefreshCw } from "lucide-react";
import {
  inp,
  btn,
  Field,
  WindowShell,
  SearchBar
} from "@/components/ui/desktop-primitives";

export function SaldoBancosCreditosList() {
  const [records, setRecords] = useState<Array<{
    id: string;
    date: string;
    bank: string;
    account: string;
    operation: string;
    description: string;
    currency: "PEN" | "USD";
    debit: number;
    credit: number;
    balance: number;
    status: "pendiente" | "conciliado";
  }>>([]);
  const [message, setMessage] = useState<string | null>(null);

  const totalDebit = records.reduce((acc, row) => acc + row.debit, 0);
  const totalCredit = records.reduce((acc, row) => acc + row.credit, 0);
  const saldoPen = records.filter((row) => row.currency === "PEN").reduce((acc, row) => acc + row.balance, 0);
  const saldoUsd = records.filter((row) => row.currency === "USD").reduce((acc, row) => acc + row.balance, 0);

  const handleLoadSample = () => {
    const seed = [
      { id: "sb-1", date: "2026-07-25", bank: "BCP", account: "191-1234567-0-12", operation: "DEP", description: "Cobranza cliente", currency: "PEN" as const, debit: 0, credit: 1250, balance: 1250, status: "pendiente" as const },
      { id: "sb-2", date: "2026-07-25", bank: "BBVA", account: "0011-098765", operation: "CHQ", description: "Pago proveedor", currency: "PEN" as const, debit: 480, credit: 0, balance: 770, status: "pendiente" as const },
      { id: "sb-3", date: "2026-07-25", bank: "INTERBANK", account: "88990011", operation: "TRF", description: "Transferencia interna", currency: "USD" as const, debit: 0, credit: 200, balance: 200, status: "conciliado" as const },
    ];
    setRecords(seed);
    setMessage("Movimientos cargados para conciliación.");
  };

  const handleConciliar = (id: string) => {
    setRecords((current) => current.map((row) => row.id === id ? { ...row, status: "conciliado" } : row));
    setMessage("Movimiento conciliado.");
  };

  return (
    <WindowShell title="Saldo de Bancos" toolbar={<>
      <button className={btn} onClick={handleLoadSample}><RefreshCw className="h-3.5 w-3.5" />Cargar Movimientos</button>
      <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
    </>}>
      <div className="mx-1.5 mt-1.5 grid grid-cols-4 gap-2 text-[11px]">
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Saldo PEN:</span> <b className="font-mono text-slate-900">{saldoPen.toFixed(2)}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Saldo USD:</span> <b className="font-mono text-slate-900">{saldoUsd.toFixed(2)}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Abonos:</span> <b className="font-mono text-slate-900">{totalCredit.toFixed(2)}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Cargos:</span> <b className="font-mono text-slate-900">{totalDebit.toFixed(2)}</b></div>
      </div>
      <SearchBar>
        <Field label="Banco" className="w-44"><select className={inp}><option>(Todos)</option><option>BCP</option><option>BBVA</option><option>INTERBANK</option></select></Field>
        <Field label="Cuenta" className="w-52"><input className={inp} defaultValue="(Todas)" /></Field>
        <Field label="Moneda" className="w-24"><select className={inp}><option>(Todas)</option><option>PEN</option><option>USD</option></select></Field>
        <Field label="Desde" className="w-32"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
        <Field label="Hasta" className="w-32"><input className={inp} type="date" defaultValue="2026-07-31" /></Field>
        <button className={`${btn} h-[28px]`}><Search className="h-3.5 w-3.5" />Buscar</button>
      </SearchBar>
      {message ? <div className="mb-2 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div> : null}
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">Fecha</th><th className="px-2 py-2 text-left border-b border-slate-300">Banco</th><th className="px-2 py-2 text-left border-b border-slate-300">Cuenta</th><th className="px-2 py-2 text-left border-b border-slate-300">Operación</th><th className="px-2 py-2 text-left border-b border-slate-300">Descripción</th><th className="px-2 py-2 text-left border-b border-slate-300">Mon.</th><th className="px-2 py-2 text-right border-b border-slate-300">Cargo</th><th className="px-2 py-2 text-right border-b border-slate-300">Abono</th><th className="px-2 py-2 text-right border-b border-slate-300">Saldo</th><th className="px-2 py-2 text-left border-b border-slate-300">Estado</th><th className="px-2 py-2 text-left border-b border-slate-300">Acción</th></tr></thead>
          <tbody>
            {records.length === 0 ? (
              <tr><td colSpan={11} className="px-2 py-4 text-sm text-slate-500">No hay movimientos cargados.</td></tr>
            ) : records.map((row) => (
              <tr key={row.id}>
                <td className="px-2 py-2 border-b border-slate-200">{row.date}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.bank}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.account}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.operation}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.description}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.currency}</td>
                <td className="px-2 py-2 border-b border-slate-200 text-right font-mono">{row.debit.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200 text-right font-mono">{row.credit.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200 text-right font-mono">{row.balance.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.status}</td>
                <td className="px-2 py-2 border-b border-slate-200">
                  <button className={btn} onClick={() => handleConciliar(row.id)} disabled={row.status === "conciliado"}>Conciliar</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}
