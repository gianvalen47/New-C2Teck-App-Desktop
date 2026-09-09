// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState } from "react";
import {
  inp,
  btn,
  Field,
  WindowShell
} from "@/components/ui/desktop-primitives";

const formatTipoCambio = (value: number | null) => {
  if (value === null || Number.isNaN(value)) return "—";
  return Number(value).toFixed(3).replace(/(\.\d*?)0+$/, "$1").replace(/\.$/, "");
};

export function TipoCambioList() {
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [currency, setCurrency] = useState("USD");
  const [buy, setBuy] = useState<number | null>(null);
  const [sell, setSell] = useState<number | null>(null);
  const [saving, setSaving] = useState(false);
  const [history, setHistory] = useState<Array<{ id: string; date: string; currency: string; buy: number; sell: number; source: string }>>([]);
  const [message, setMessage] = useState<string | null>(null);

  const handleSave = async () => {
    setSaving(true);
    try {
      const row = {
        id: `${currency}-${date}-${Date.now()}`,
        date,
        currency,
        buy,
        sell,
        source: "Manual",
      };
      setHistory((prev) => [row, ...prev].slice(0, 20));
      setMessage("Tipo de cambio guardado en historial.");
    } finally {
      setSaving(false);
    }
  };

  const handleRefreshSunat = () => {
    setMessage("No hay valor real disponible en esta sesión; debe cargar el tipo de cambio desde el servicio SIGECOM o la base de datos vigente.");
  };

  return (
    <WindowShell title="Mantenimiento del Tipo de Cambio">
      <div className="grid grid-cols-4 gap-2 mb-2 text-[11px]">
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Registros:</span> <b className="font-mono text-slate-900">{history.length}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Moneda:</span> <b className="font-mono text-slate-900">{currency}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Compra:</span> <b className="font-mono text-slate-900">{formatTipoCambio(buy)}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Venta:</span> <b className="font-mono text-slate-900">{formatTipoCambio(sell)}</b></div>
      </div>
      <div className="grid grid-cols-4 gap-3 max-w-2xl">
        <Field label="Fecha"><input className={inp} type="date" value={date} onChange={(e) => setDate(e.target.value)} /></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>USD — Dólares</option><option>EUR — Euros</option></select></Field>
        <Field label="Compra"><input className={inp} type="number" step="0.001" value={buy ?? ""} onChange={(e) => setBuy(e.target.value === "" ? null : Number(e.target.value))} /></Field>
        <Field label="Venta"><input className={inp} type="number" step="0.001" value={sell ?? ""} onChange={(e) => setSell(e.target.value === "" ? null : Number(e.target.value))} /></Field>
      </div>
      {message ? <div className="mt-2 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div> : null}
      <div className="mt-4"><div className="border border-slate-300 rounded-sm bg-white overflow-auto"><table className="w-full text-[11px] border-collapse"><thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">Fecha</th><th className="px-2 py-2 text-left border-b border-slate-300">Moneda</th><th className="px-2 py-2 text-right border-b border-slate-300">Compra</th><th className="px-2 py-2 text-right border-b border-slate-300">Venta</th><th className="px-2 py-2 text-left border-b border-slate-300">Fuente</th><th className="px-2 py-2 text-left border-b border-slate-300">Acción</th></tr></thead><tbody>{history.length === 0 ? <tr><td colSpan={6} className="px-2 py-4 text-sm text-slate-500">No hay cambios registrados.</td></tr> : history.map((row) => <tr key={row.id}><td className="px-2 py-2 border-b border-slate-200">{row.date}</td><td className="px-2 py-2 border-b border-slate-200">{row.currency}</td><td className="px-2 py-2 border-b border-slate-200 text-right font-mono">{row.buy.toFixed(3)}</td><td className="px-2 py-2 border-b border-slate-200 text-right font-mono">{row.sell.toFixed(3)}</td><td className="px-2 py-2 border-b border-slate-200">{row.source}</td><td className="px-2 py-2 border-b border-slate-200"><button className={btn}>Usar</button></td></tr>)}</tbody></table></div></div>
    </WindowShell>
  );
}
