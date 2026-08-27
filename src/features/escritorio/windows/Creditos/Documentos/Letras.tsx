// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState, useEffect } from "react";
import { Save, RefreshCw } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  WindowShell
} from "@/components/ui/desktop-primitives";
import {
  fetchSigecoomSales,
  createSigecoomSale,
  updateSigecoomSale,
  type SigecoomSale
} from "@/lib/sigecoom-api";

export function LetrasList() {
  const [letters, setLetters] = useState<SigecoomSale[]>([]);
  const [selectedLetterId, setSelectedLetterId] = useState("");
  const [loadingLetters, setLoadingLetters] = useState(true);
  const [actionLoading, setActionLoading] = useState(false);
  const [statusMessage, setStatusMessage] = useState<string | null>(null);
  const [statusFilter, setStatusFilter] = useState("Todos");
  const [clientFilter, setClientFilter] = useState("");

  const loadLetters = async () => {
    setLoadingLetters(true);
    try {
      const data = await fetchSigecoomSales();
      setLetters(data.filter((sale) => sale.type.toLowerCase().includes("letra")));
      setStatusMessage(null);
    } catch (error) {
      setStatusMessage(error instanceof Error ? error.message : "Error cargando letras");
    } finally {
      setLoadingLetters(false);
    }
  };

  useEffect(() => {
    loadLetters();
  }, []);

  const handleGenerate = async () => {
    setActionLoading(true);
    setStatusMessage(null);
    try {
      const created = await createSigecoomSale({
        type: "Letra",
        series: "LT001",
        number: Math.floor(Math.random() * 10000),
        date: new Date().toISOString().slice(0, 10),
        client_id: "Cliente Letra",
        items: [{ description: "Letra de cambio generada desde escritorio", unit: "unidad", quantity: 1, price: 0 }],
        subtotal: 0,
        tax: 0,
        total: 0,
      });
      setLetters((current) => [created, ...current]);
      setStatusMessage(`Letra generada: ${created.series}-${created.number}`);
    } catch (error) {
      setStatusMessage(error instanceof Error ? error.message : "Error al generar letra");
    } finally {
      setActionLoading(false);
    }
  };

  const updateSelectedLetterStatus = async (status: string) => {
    if (!selectedLetterId) {
      setStatusMessage("Seleccione una letra antes de continuar.");
      return;
    }
    setActionLoading(true);
    setStatusMessage(null);
    try {
      const updated = await updateSigecoomSale(selectedLetterId, { status });
      setLetters((current) => current.map((letter) => letter.id === updated.id ? updated : letter));
      setStatusMessage(`Letra ${updated.series}-${updated.number} ${status}.`);
    } catch (error) {
      setStatusMessage(error instanceof Error ? error.message : "Error al actualizar letra");
    } finally {
      setActionLoading(false);
    }
  };

  const visibleLetters = letters.filter((letter) => {
    const statusText = String(letter.status ?? "").toLowerCase();
    const statusMatch = statusFilter === "Todos" || statusText === statusFilter.toLowerCase();
    const clientText = String(letter.client_id ?? "").toLowerCase();
    const clientMatch = !clientFilter.trim() || clientText.includes(clientFilter.trim().toLowerCase());
    return statusMatch && clientMatch;
  });

  const totalAmount = visibleLetters.reduce((acc, letter) => acc + letter.total, 0);
  const acceptedCount = visibleLetters.filter((letter) => String(letter.status ?? "").toLowerCase() === "accepted").length;
  const protestedCount = visibleLetters.filter((letter) => String(letter.status ?? "").toLowerCase() === "protested").length;

  return (
    <WindowShell title="Letras de Cambio Financieras"
      toolbar={<>
        <button className={btnPrimary} onClick={handleGenerate} disabled={actionLoading}><Save className="h-3.5 w-3.5" />{actionLoading ? "Procesando..." : "Generar Letra"}</button>
        <button className={btn} onClick={() => updateSelectedLetterStatus("accepted")} disabled={actionLoading}>Aceptar</button>
        <button className={btn} onClick={() => updateSelectedLetterStatus("protested")} disabled={actionLoading}>Protestar</button>
        <button className={btn} onClick={loadLetters} disabled={actionLoading}><RefreshCw className="h-3.5 w-3.5" />Actualizar</button>
      </>}>
      {statusMessage && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{statusMessage}</div>}
      <div className="grid grid-cols-4 gap-2 mb-2 text-[11px]">
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Registros:</span> <b className="font-mono text-slate-900">{visibleLetters.length}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aceptadas:</span> <b className="font-mono text-emerald-700">{acceptedCount}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Protestadas:</span> <b className="font-mono text-amber-700">{protestedCount}</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Importe total:</span> <b className="font-mono text-slate-900">{totalAmount.toFixed(2)}</b></div>
      </div>
      <div className="grid grid-cols-3 gap-2 mb-3">
        <Field label="Cliente"><input className={inp} value={clientFilter} onChange={(e) => setClientFilter(e.target.value)} placeholder="Filtrar cliente" /></Field>
        <Field label="Estado"><select className={inp} value={statusFilter} onChange={(e) => setStatusFilter(e.target.value)}><option>Todos</option><option>draft</option><option>issued</option><option>accepted</option><option>protested</option></select></Field>
        <Field label="Carga"><input className={inp} value={loadingLetters ? "Cargando..." : "Lista actualizada"} readOnly /></Field>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">Sel</th><th className="px-2 py-2 text-left border-b border-slate-300">Nº Letra</th><th className="px-2 py-2 text-left border-b border-slate-300">Fecha Giro</th><th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th><th className="px-2 py-2 text-left border-b border-slate-300">Vencimiento</th><th className="px-2 py-2 text-left border-b border-slate-300">Moneda</th><th className="px-2 py-2 text-right border-b border-slate-300">Importe</th><th className="px-2 py-2 text-left border-b border-slate-300">Banco</th><th className="px-2 py-2 text-left border-b border-slate-300">Estado</th></tr></thead>
          <tbody>
            {visibleLetters.length === 0 ? (
              <tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">No hay letras registradas.</td></tr>
            ) : visibleLetters.map((letter) => (
              <tr key={letter.id} className={`hover:bg-slate-50 ${selectedLetterId === letter.id ? "bg-slate-100" : ""}`}>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><input type="radio" name="selectedLetter" checked={selectedLetterId === letter.id} onChange={() => setSelectedLetterId(letter.id)} /></td>
                <td className="px-2 py-2 border-b border-slate-200">{letter.series}-{letter.number}</td>
                <td className="px-2 py-2 border-b border-slate-200">{letter.date}</td>
                <td className="px-2 py-2 border-b border-slate-200">{letter.client_id}</td>
                <td className="px-2 py-2 border-b border-slate-200">{letter.date}</td>
                <td className="px-2 py-2 border-b border-slate-200">PEN</td>
                <td className="px-2 py-2 border-b border-slate-200 text-right">{letter.total.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">Banco</td>
                <td className="px-2 py-2 border-b border-slate-200">{letter.status}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}
