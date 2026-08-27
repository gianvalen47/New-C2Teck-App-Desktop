// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState, useEffect } from "react";
import { Save, Plus } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  WindowShell
} from "@/components/ui/desktop-primitives";
import {
  fetchSigecoomJournalEntries,
  createSigecoomJournalEntry,
  type SigecoomJournalEntry
} from "@/lib/sigecoom-api";

export function AsientosList() {
  const [entries, setEntries] = useState<SigecoomJournalEntry[]>([]);
  const [loadingEntries, setLoadingEntries] = useState(true);
  const [saving, setSaving] = useState(false);
  const [entryNumber, setEntryNumber] = useState("0001");
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [entryType, setEntryType] = useState("Diario");
  const [currency, setCurrency] = useState("PEN");
  const [exchangeRate, setExchangeRate] = useState(1);
  const [description, setDescription] = useState("");
  const [lines, setLines] = useState<JournalLineForm[]>([
    { id: "line-1", account: "", description: "", reference: "", debit: 0, credit: 0, cost_center: "" },
  ]);

  useEffect(() => {
    fetchSigecoomJournalEntries()
      .then(setEntries)
      .catch(console.error)
      .finally(() => setLoadingEntries(false));
  }, []);

  const totalDebit = lines.reduce((sum, line) => sum + line.debit, 0);
  const totalCredit = lines.reduce((sum, line) => sum + line.credit, 0);
  const diff = totalDebit - totalCredit;

  const addLine = () => {
    setLines(prev => [
      ...prev,
      {
        id: `line-${Date.now()}`,
        account: "",
        description: "",
        reference: "",
        debit: 0,
        credit: 0,
        cost_center: "",
      },
    ]);
  };

  const updateLine = (lineId: string, field: keyof JournalLineForm, value: string) => {
    setLines(prev => prev.map(line => {
      if (line.id !== lineId) return line;
      if (field === "debit" || field === "credit") {
        return { ...line, [field]: Number(value) || 0 };
      }
      return { ...line, [field]: value };
    }));
  };

  const removeLine = (lineId: string) => {
    setLines(prev => prev.filter(line => line.id !== lineId));
  };

  const resetForm = () => {
    setEntryNumber(prev => String(Number(prev || "0") + 1).padStart(4, "0"));
    setDate(new Date().toISOString().slice(0, 10));
    setEntryType("Diario");
    setCurrency("PEN");
    setExchangeRate(1);
    setDescription("");
    setLines([
      { id: `line-${Date.now()}`, account: "", description: "", reference: "", debit: 0, credit: 0, cost_center: "" },
    ]);
  };

  const handleRegister = async () => {
    if (diff !== 0) {
      alert("El debe y el haber deben estar balanceados.");
      return;
    }

    setSaving(true);
    try {
      const created = await createSigecoomJournalEntry({
        entry_number: entryNumber,
        date,
        type: entryType,
        currency,
        exchange_rate: exchangeRate,
        description,
        lines: lines.map(line => ({
          account: line.account,
          description: line.description,
          reference: line.reference,
          debit: line.debit,
          credit: line.credit,
          cost_center: line.cost_center,
        })),
      });

      setEntries(prev => [created, ...prev]);
      resetForm();
    } catch (error) {
      console.error(error);
      alert("No se pudo guardar el asiento contable. Revise los datos e intente de nuevo.");
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Asientos Contables — Doble Entrada"
      toolbar={<>
        <button className={btnPrimary} onClick={handleRegister} disabled={saving}>
          <Save className="h-3.5 w-3.5" />{saving ? "Guardando…" : "Registrar"}
        </button>
        <button className={btn} onClick={addLine} type="button"><Plus className="h-3.5 w-3.5" />Nueva línea</button>
        <span className="ml-auto text-[11px] text-slate-600">
          Debe: <b className="font-mono">{totalDebit.toFixed(2)}</b> · Haber: <b className="font-mono">{totalCredit.toFixed(2)}</b> · Dif: <b className={diff === 0 ? "font-mono text-emerald-700" : "font-mono text-red-700"}>{diff.toFixed(2)}</b>
        </span>
      </>}
    >
      <div className="grid grid-cols-4 gap-3">
        <Field label="Nº Asiento"><input className={inp} value={entryNumber} onChange={e => setEntryNumber(e.target.value)} /></Field>
        <Field label="Fecha"><input className={inp} type="date" value={date} onChange={e => setDate(e.target.value)} /></Field>
        <Field label="Tipo">
          <select className={inp} value={entryType} onChange={e => setEntryType(e.target.value)}>
            <option>Diario</option>
            <option>Ventas</option>
            <option>Compras</option>
            <option>Caja/Bancos</option>
          </select>
        </Field>
        <Field label="Moneda">
          <select className={inp} value={currency} onChange={e => setCurrency(e.target.value)}>
            <option>PEN</option>
            <option>USD</option>
          </select>
        </Field>
        <Field label="Tipo de cambio"><input className={inp} type="number" step="0.0001" value={exchangeRate} onChange={e => setExchangeRate(Number(e.target.value) || 1)} /></Field>
        <Field label="Glosa" className="col-span-3"><input className={inp} value={description} onChange={e => setDescription(e.target.value)} /></Field>
      </div>

      <div className="mt-3 overflow-auto border border-slate-300 rounded-sm bg-white">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#EEF2F7] text-slate-800">
            <tr>
              <th className="px-2 py-2 border-b border-slate-300 text-left">Cuenta</th>
              <th className="px-2 py-2 border-b border-slate-300 text-left">Descripción</th>
              <th className="px-2 py-2 border-b border-slate-300 text-left">Doc. Ref.</th>
              <th className="px-2 py-2 border-b border-slate-300 text-right">Debe</th>
              <th className="px-2 py-2 border-b border-slate-300 text-right">Haber</th>
              <th className="px-2 py-2 border-b border-slate-300 text-left">C. Costo</th>
              <th className="px-2 py-2 border-b border-slate-300 text-center">Acción</th>
            </tr>
          </thead>
          <tbody>
            {lines.map(line => (
              <tr key={line.id} className="even:bg-[#F8FBFF]">
                <td className="px-2 py-1 border-b border-slate-200"><input className={inp} value={line.account} onChange={e => updateLine(line.id, "account", e.target.value)} placeholder="Cuenta" /></td>
                <td className="px-2 py-1 border-b border-slate-200"><input className={inp} value={line.description} onChange={e => updateLine(line.id, "description", e.target.value)} placeholder="Descripción" /></td>
                <td className="px-2 py-1 border-b border-slate-200"><input className={inp} value={line.reference} onChange={e => updateLine(line.id, "reference", e.target.value)} placeholder="Ref." /></td>
                <td className="px-2 py-1 border-b border-slate-200 text-right"><input className={`${inp} text-right`} type="number" step="0.01" value={line.debit} onChange={e => updateLine(line.id, "debit", e.target.value)} /></td>
                <td className="px-2 py-1 border-b border-slate-200 text-right"><input className={`${inp} text-right`} type="number" step="0.01" value={line.credit} onChange={e => updateLine(line.id, "credit", e.target.value)} /></td>
                <td className="px-2 py-1 border-b border-slate-200"><input className={inp} value={line.cost_center} onChange={e => updateLine(line.id, "cost_center", e.target.value)} placeholder="C. Costo" /></td>
                <td className="px-2 py-1 border-b border-slate-200 text-center"><button className={btn} type="button" onClick={() => removeLine(line.id)}>Eliminar</button></td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <div className="mt-3 grid grid-cols-3 gap-3 text-[12px] text-slate-700">
        <div className="p-2 bg-slate-50 rounded-sm border border-slate-200">Total Debe: <b>{totalDebit.toFixed(2)}</b></div>
        <div className="p-2 bg-slate-50 rounded-sm border border-slate-200">Total Haber: <b>{totalCredit.toFixed(2)}</b></div>
        <div className={`p-2 rounded-sm border ${diff === 0 ? "border-emerald-300 bg-emerald-50 text-emerald-700" : "border-rose-300 bg-rose-50 text-rose-700"}`}>Diferencia: <b>{diff.toFixed(2)}</b></div>
      </div>

      <div className="mt-6">
        <div className="text-[11px] font-semibold text-slate-700 uppercase mb-2">Últimos asientos registrados</div>
        <div className="overflow-auto border border-slate-300 rounded-sm bg-white">
          <table className="w-full text-[11px] border-collapse">
            <thead className="bg-[#EEF2F7] text-slate-800">
              <tr>
                <th className="px-2 py-2 border-b border-slate-300 text-left">Asiento</th>
                <th className="px-2 py-2 border-b border-slate-300 text-left">Fecha</th>
                <th className="px-2 py-2 border-b border-slate-300 text-left">Tipo</th>
                <th className="px-2 py-2 border-b border-slate-300 text-left">Moneda</th>
                <th className="px-2 py-2 border-b border-slate-300 text-left">Glosa</th>
              </tr>
            </thead>
            <tbody>
              {loadingEntries && (
                <tr><td colSpan={5} className="px-2 py-4 text-center text-slate-500">Cargando asientos…</td></tr>
              )}
              {!loadingEntries && entries.length === 0 && (
                <tr><td colSpan={5} className="px-2 py-4 text-center text-slate-500">No hay asientos registrados</td></tr>
              )}
              {entries.map(entry => (
                <tr key={entry.id} className="even:bg-[#F8FBFF]">
                  <td className="px-2 py-2 border-b border-slate-200">{entry.entry_number}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{new Date(entry.date).toLocaleDateString()}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{entry.type}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{entry.currency}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{entry.description || "—"}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </WindowShell>
  );
}
