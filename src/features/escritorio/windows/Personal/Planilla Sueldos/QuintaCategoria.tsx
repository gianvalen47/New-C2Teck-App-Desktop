// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState } from "react";
import { FileDown, Mail, Users } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";
import {
  createSigecoomSale,
  sendSigecoomSaleEmail
} from "@/lib/sigecoom-api";

export function PlanillaSueldosList() {
  const [period, setPeriod] = useState("2026-07");
  const [branch, setBranch] = useState("Todas");
  const [regimen, setRegimen] = useState("General");
  const [bank, setBank] = useState("BCP");
  const [currency, setCurrency] = useState("PEN");
  const [processing, setProcessing] = useState(false);
  const [sending, setSending] = useState(false);
  const [message, setMessage] = useState<string | null>(null);
  const [lastPayrollId, setLastPayrollId] = useState<string | null>(null);

  const handleProcess = async () => {
    setProcessing(true);
    setMessage(null);
    try {
      const created = await createSigecoomSale({
        type: "Planilla Sueldos",
        series: "PLS001",
        number: Math.floor(Math.random() * 10000),
        date: new Date().toISOString().slice(0, 10),
        client_id: branch,
        items: [{ description: `Planilla ${period} — ${branch} — ${regimen}` , unit: "unidad", quantity: 1, price: 0 }],
        subtotal: 0,
        tax: 0,
        total: 0,
      });
      setLastPayrollId(created.id);
      setMessage(`Planilla procesada: ${created.series}-${created.number}`);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error al procesar la planilla");
    } finally {
      setProcessing(false);
    }
  };

  const handleSendBoletas = async () => {
    if (!lastPayrollId) {
      setMessage("Procese la planilla antes de enviar las boletas.");
      return;
    }
    setSending(true);
    setMessage(null);
    try {
      await sendSigecoomSaleEmail(lastPayrollId);
      setMessage("Boletas enviadas correctamente.");
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo enviar las boletas");
    } finally {
      setSending(false);
    }
  };

  return (
    <WindowShell title="Planilla de Sueldos — Cálculo Mensual"
      toolbar={<>
        <button className={btnPrimary} onClick={handleProcess} disabled={processing}><Users className="h-3.5 w-3.5" />{processing ? "Procesando..." : "Procesar planilla"}</button>
        <button className={btn} disabled>{/* TXT bancario no implementado todavía */}<FileDown className="h-3.5 w-3.5" />TXT Bancario</button>
        <button className={btn} onClick={handleSendBoletas} disabled={sending || processing}><Mail className="h-3.5 w-3.5" />{sending ? "Enviando..." : "Enviar boletas"}</button>
      </>}
    >
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="grid grid-cols-5 gap-2 mb-3">
        <Field label="Periodo"><input className={inp} value={period} onChange={(e) => setPeriod(e.target.value)} placeholder="2026-07" /></Field>
        <Field label="Sede"><select className={inp} value={branch} onChange={(e) => setBranch(e.target.value)}><option>Todas</option><option>Central</option><option>Mina 1</option></select></Field>
        <Field label="Régimen"><select className={inp} value={regimen} onChange={(e) => setRegimen(e.target.value)}><option>General</option><option>Mype</option></select></Field>
        <Field label="Banco"><select className={inp} value={bank} onChange={(e) => setBank(e.target.value)}><option>BCP</option><option>BBVA</option><option>Interbank</option><option>Scotiabank</option></select></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>PEN</option><option>USD</option></select></Field>
      </div>
      <DataTable columns={["DNI", "Colaborador", "Sueldo base", "H. Extras", "Descuentos", "5ta Categoría", "AFP/ONP", "Neto"]} rows={10} />
      <div className="mt-3 grid grid-cols-4 gap-2 max-w-md ml-auto text-[11.5px]">
        <div className="text-right text-slate-600 col-span-3">Total bruto:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right text-slate-600 col-span-3">Retenciones:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right font-bold text-[#2A3F55] col-span-3">Neto a pagar S/:</div><div className="text-right font-mono font-bold">0.00</div>
      </div>
    </WindowShell>
  );
}
