// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState } from "react";
import { Save, Printer, Search } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  WindowShell
} from "@/components/ui/desktop-primitives";
import {
  createSigecoomSale
} from "@/lib/sigecoom-api";
import { Factura } from "@/features/escritorio/windows/Ventas/Documentos/Facturas";

export function AnticiposList() {
  const [clientName, setClientName] = useState("");
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [currency, setCurrency] = useState("PEN");
  const [amount, setAmount] = useState(0);
  const [paymentMethod, setPaymentMethod] = useState("Transferencia");
  const [reference, setReference] = useState("");
  const [note, setNote] = useState("");
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);
  const [recent, setRecent] = useState<Array<{ id: string; date: string; client: string; currency: string; amount: number; reference: string }>>([]);

  const handleSave = async () => {
    if (!clientName.trim() || amount <= 0) {
      setMessage("Complete cliente y monto.");
      return;
    }
    setSaving(true);
    try {
      const created = await createSigecoomSale({
        type: "Anticipo",
        series: "ANT001",
        number: Math.floor(Math.random() * 10000),
        client_id: clientName,
        date,
        items: [{ description: `Anticipo ${paymentMethod} - ${reference}`, unit: "unidad", quantity: 1, price: amount }],
        subtotal: amount,
        tax: 0,
        total: amount,
      });
      setMessage(`Anticipo registrado para ${clientName} - ${currency} ${amount}`);
      setRecent((prev) => [
        {
          id: created.id,
          date,
          client: clientName,
          currency,
          amount,
          reference,
        },
        ...prev,
      ].slice(0, 8));
      setClientName("");
      setAmount(0);
      setReference("");
      setNote("");
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error");
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Anticipos de Clientes"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSave} disabled={saving}><Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Registrar Anticipo"}</button>
        <button className={btn}><Search className="h-3.5 w-3.5" />Aplicar a Factura</button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
      </>}>
      <div className="grid grid-cols-3 gap-2 mb-2 text-[11px]">
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Registros:</span> <b className="font-mono text-slate-900">{recent.length}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Total PEN:</span> <b className="font-mono text-slate-900">{recent.filter((row) => row.currency === "PEN").reduce((acc, row) => acc + row.amount, 0).toFixed(2)}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Total USD:</span> <b className="font-mono text-slate-900">{recent.filter((row) => row.currency === "USD").reduce((acc, row) => acc + row.amount, 0).toFixed(2)}</b></div>
      </div>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Cliente" className="col-span-2"><input className={inp} value={clientName} onChange={(e) => setClientName(e.target.value)} /></Field>
        <Field label="Fecha"><input className={inp} type="date" value={date} onChange={(e) => setDate(e.target.value)} /></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>PEN</option><option>USD</option></select></Field>
        <Field label="Monto"><input className={inp} type="number" value={amount} onChange={(e) => setAmount(Number(e.target.value))} /></Field>
        <Field label="Medio Pago"><select className={inp} value={paymentMethod} onChange={(e) => setPaymentMethod(e.target.value)}><option>Efectivo</option><option>Transferencia</option><option>Depósito</option></select></Field>
        <Field label="Referencia"><input className={inp} value={reference} onChange={(e) => setReference(e.target.value)} /></Field>
        <Field label="Observación" className="col-span-4"><input className={inp} value={note} onChange={(e) => setNote(e.target.value)} /></Field>
      </div>
      {message && <div className="mt-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="mt-3 border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]">
            <tr>
              <th className="px-2 py-2 text-left border-b border-slate-300">Fecha</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Mon.</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Monto</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Referencia</th>
            </tr>
          </thead>
          <tbody>
            {recent.length === 0 ? (
              <tr><td colSpan={5} className="px-2 py-4 text-sm text-slate-500">No hay anticipos registrados en esta sesión.</td></tr>
            ) : recent.map((row) => (
              <tr key={row.id}>
                <td className="px-2 py-2 border-b border-slate-200">{row.date}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.client}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.currency}</td>
                <td className="px-2 py-2 border-b border-slate-200 text-right font-mono">{row.amount.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.reference || "-"}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}
