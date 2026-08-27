// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState } from "react";
import { Save, Printer, FileSpreadsheet } from "lucide-react";
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

export function PlanillasList() {
  const [collector, setCollector] = useState("");
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [route, setRoute] = useState("Lima Centro");
  const [currency, setCurrency] = useState("PEN");
  const [generating, setGenerating] = useState(false);
  const [message, setMessage] = useState<string | null>(null);
  const [planillas, setPlanillas] = useState<Array<{ id: string; number: string; collector: string; route: string; date: string; currency: string; total: number; state: string }>>([]);

  const handleGenerate = async () => {
    if (!collector) {
      setMessage("Seleccione un cobrador antes de generar la planilla.");
      return;
    }
    setGenerating(true);
    setMessage(null);
    try {
      const created = await createSigecoomSale({
        type: "Planilla",
        series: "PL001",
        number: Math.floor(Math.random() * 10000),
        date,
        client_id: collector,
        items: [{ description: `Planilla cobranza ${route}`, unit: "unidad", quantity: 1, price: 0 }],
        subtotal: 0,
        tax: 0,
        total: 0,
      });
      setMessage(`Planilla generada: ${created.series}-${created.number}`);
      setPlanillas((prev) => [
        {
          id: created.id,
          number: `${created.series}-${created.number}`,
          collector,
          route,
          date,
          currency,
          total: created.total,
          state: "Generada",
        },
        ...prev,
      ].slice(0, 10));
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error al generar planilla");
    } finally {
      setGenerating(false);
    }
  };

  return (
    <WindowShell title="Planillas de Cobranza"
      toolbar={<>
        <button className={btnPrimary} onClick={handleGenerate} disabled={generating}><Save className="h-3.5 w-3.5" />{generating ? "Generando..." : "Generar Planilla"}</button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}>
      <div className="grid grid-cols-4 gap-2 mb-2 text-[11px]">
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Planillas:</span> <b className="font-mono text-slate-900">{planillas.length}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Ruta Centro:</span> <b className="font-mono text-slate-900">{planillas.filter((row) => row.route === "Lima Centro").length}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Ruta Norte:</span> <b className="font-mono text-slate-900">{planillas.filter((row) => row.route === "Lima Norte").length}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Total:</span> <b className="font-mono text-slate-900">{planillas.reduce((acc, row) => acc + row.total, 0).toFixed(2)}</b></div>
      </div>
      <div className="grid grid-cols-6 gap-2 mb-3">
        <Field label="Cobrador"><select className={inp} value={collector} onChange={(e) => setCollector(e.target.value)}><option value="">Asignar...</option><option value="grios">grios</option><option value="mlopez">mlopez</option></select></Field>
        <Field label="Fecha"><input className={inp} type="date" value={date} onChange={(e) => setDate(e.target.value)} /></Field>
        <Field label="Ruta"><select className={inp} value={route} onChange={(e) => setRoute(e.target.value)}><option>Lima Centro</option><option>Lima Norte</option></select></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>PEN</option></select></Field>
        <Field label="Prioridad"><select className={inp}><option>(Todas)</option><option>Alta</option><option>Media</option><option>Baja</option></select></Field>
        <Field label="Estado"><select className={inp}><option>(Todos)</option><option>Generada</option><option>En ruta</option><option>Cerrada</option></select></Field>
      </div>
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]">
            <tr>
              <th className="px-2 py-2 text-left border-b border-slate-300">Planilla</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Cobrador</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Ruta</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Fecha</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Moneda</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Total</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Estado</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Acción</th>
            </tr>
          </thead>
          <tbody>
            {planillas.length === 0 ? (
              <tr><td colSpan={8} className="px-2 py-4 text-sm text-slate-500">No hay planillas generadas en esta sesión.</td></tr>
            ) : planillas.map((row) => (
              <tr key={row.id}>
                <td className="px-2 py-2 border-b border-slate-200 font-mono">{row.number}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.collector}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.route}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.date}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.currency}</td>
                <td className="px-2 py-2 border-b border-slate-200 text-right font-mono">{row.total.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{row.state}</td>
                <td className="px-2 py-2 border-b border-slate-200"><button className={btn}>Ver Detalle</button></td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}
