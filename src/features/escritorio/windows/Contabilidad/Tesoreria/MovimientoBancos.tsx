// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState, useRef, useEffect, useCallback } from "react";
import { Plus, RefreshCw } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  WindowShell
} from "@/components/ui/desktop-primitives";
import {
  fetchBankAccounts,
  createBankAccount,
  fetchBankTransactions,
  createBankTransaction,
  updateBankTransaction,
  type BankAccount,
  type BankTransaction
} from "@/lib/sigecoom-api";

export function MovimientoBancosList() {
  const [accounts, setAccounts] = useState<BankAccount[]>([]);
  const [selectedAccountId, setSelectedAccountId] = useState("");
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [bankTransactions, setBankTransactions] = useState<BankTransaction[]>([]);
  const [erpTransactions, setErpTransactions] = useState<BankTransaction[]>([]);
  const [selectedIds, setSelectedIds] = useState<string[]>([]);
  const [loading, setLoading] = useState(true);
  const [actionLoading, setActionLoading] = useState(false);
  const fileInputRef = useRef<HTMLInputElement>(null);

  const loadAccounts = useCallback(async () => {
    setLoading(true);
    try {
      const accountsData = await fetchBankAccounts();
      if (accountsData.length === 0) {
        const created = await createBankAccount({
          bank_name: "BCP",
          account_number: "194-0000000-0",
          currency: "PEN",
        });
        setAccounts([created]);
        setSelectedAccountId(created.id);
      } else {
        setAccounts(accountsData);
        if (!selectedAccountId) {
          setSelectedAccountId(accountsData[0].id);
        }
      }
    } catch (error) {
      console.error(error);
    } finally {
      setLoading(false);
    }
  }, [selectedAccountId]);

  const loadTransactions = useCallback(async (accountId?: string) => {
    setLoading(true);
    try {
      const [bankData, erpData] = await Promise.all([
        fetchBankTransactions("bank", accountId),
        fetchBankTransactions("erp"),
      ]);
      setBankTransactions(bankData);
      setErpTransactions(erpData);
    } catch (error) {
      console.error(error);
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    loadAccounts();
  }, [loadAccounts]);

  useEffect(() => {
    if (selectedAccountId) {
      loadTransactions(selectedAccountId);
    }
  }, [selectedAccountId, loadTransactions]);

  const toggleSelection = (id: string) => {
    setSelectedIds(prev => prev.includes(id) ? prev.filter(item => item !== id) : [...prev, id]);
  };

  const handleConciliar = async () => {
    if (selectedIds.length === 0) {
      alert("Seleccione al menos una transacción para conciliar.");
      return;
    }

    setActionLoading(true);
    try {
      await Promise.all(selectedIds.map(id => updateBankTransaction(id, { reconciled: true })));
      setSelectedIds([]);
      await loadTransactions(selectedAccountId);
    } catch (error) {
      console.error(error);
      alert("No se pudo conciliar las transacciones seleccionadas.");
    } finally {
      setActionLoading(false);
    }
  };

  const handleImportClick = () => {
    fileInputRef.current?.click();
  };

  const handleFileSelected = async (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (!file) return;
    if (!selectedAccountId) {
      alert("Seleccione primero una cuenta bancaria.");
      return;
    }

    const text = await file.text();
    const lines = text.split(/\r?\n/).map(line => line.trim()).filter(Boolean);
    if (lines.length < 2) {
      alert("El archivo debe tener encabezado y al menos una fila de datos.");
      return;
    }

    const headers = lines[0].split(",").map(cell => cell.trim().toLowerCase());
    const dateIndex = headers.indexOf("date");
    const descriptionIndex = headers.indexOf("description");
    const cargoIndex = headers.indexOf("cargo");
    const abonoIndex = headers.indexOf("abono");
    const referenceIndex = headers.indexOf("reference");

    if (dateIndex === -1 || descriptionIndex === -1 || cargoIndex === -1 || abonoIndex === -1) {
      alert("El CSV debe incluir columnas: date, description, cargo, abono, reference.");
      return;
    }

    setActionLoading(true);
    try {
      const rows = lines.slice(1);
      await Promise.all(rows.map(async line => {
        const columns = line.split(",").map(cell => cell.trim());
        const date = columns[dateIndex] || new Date().toISOString().slice(0, 10);
        const description = columns[descriptionIndex] || "Movimiento bancario";
        const cargo = Number(columns[cargoIndex] || 0);
        const abono = Number(columns[abonoIndex] || 0);
        const reference = referenceIndex !== -1 ? columns[referenceIndex] : undefined;
        const direction = cargo > 0 ? "cargo" : "abono";
        const amount = Math.max(cargo, abono, 0);
        if (amount <= 0) return;

        await createBankTransaction({
          bank_account_id: selectedAccountId,
          source: "bank",
          date,
          description,
          reference,
          amount,
          direction,
        });
      }));
      await loadTransactions(selectedAccountId);
      alert("Estado de cuenta importado correctamente.");
    } catch (error) {
      console.error(error);
      alert("Error al importar el estado de cuenta.");
    } finally {
      setActionLoading(false);
      if (event.target) {
        event.target.value = "";
      }
    }
  };

  const handleCreateErpMovement = async () => {
    setActionLoading(true);
    try {
      await createBankTransaction({
        source: "erp",
        date: new Date().toISOString().slice(0, 10),
        description: "Pago ERP registrado",
        reference: `ERP-${Date.now()}`,
        amount: 1200,
        direction: "debe",
      });
      await loadTransactions(selectedAccountId);
    } catch (error) {
      console.error(error);
      alert("No se pudo crear el movimiento ERP.");
    } finally {
      setActionLoading(false);
    }
  };

  const showRows = loading ? 0 : undefined;

  return (
    <WindowShell title="Conciliación Bancaria"
      toolbar={<>
        <button className={btnPrimary} onClick={handleConciliar} disabled={actionLoading || selectedIds.length === 0}>
          ✓ Conciliar seleccionados
        </button>
        <button className={btn} onClick={handleImportClick} type="button" disabled={actionLoading}>
          <RefreshCw className="h-3.5 w-3.5" />Importar Estado Cta.
        </button>
        <button className={btn} onClick={handleCreateErpMovement} type="button" disabled={actionLoading}>
          <Plus className="h-3.5 w-3.5" />Agregar Movimiento ERP
        </button>
        <span className="ml-auto text-[11px] text-slate-600">Seleccionados: <b>{selectedIds.length}</b></span>
      </>}
    >
      <input ref={fileInputRef} type="file" accept=".csv,text/csv" className="hidden" onChange={handleFileSelected} />

      <div className="grid grid-cols-4 gap-3 mb-3">
        <Field label="Banco">
          <select className={inp} value={selectedAccountId} onChange={e => setSelectedAccountId(e.target.value)}>
            {accounts.map(account => (
              <option key={account.id} value={account.id}>{account.bank_name} — {account.account_number}</option>
            ))}
          </select>
        </Field>
        <Field label="Cuenta">
          <input className={inp} value={accounts.find(item => item.id === selectedAccountId)?.account_number || ""} readOnly />
        </Field>
        <Field label="Desde"><input className={inp} type="date" value={fromDate} onChange={e => setFromDate(e.target.value)} /></Field>
        <Field label="Hasta"><input className={inp} type="date" value={toDate} onChange={e => setToDate(e.target.value)} /></Field>
      </div>

      <div className="grid grid-cols-2 gap-3">
        <div>
          <div className="text-[11px] font-semibold text-[#2A3F55] mb-1 uppercase">Estado de Cuenta Banco</div>
          <div className="overflow-auto border border-slate-300 rounded-sm bg-white">
            <table className="w-full text-[11px] border-collapse">
              <thead className="bg-[#EEF2F7] text-slate-800">
                <tr>
                  <th className="px-2 py-2 border-b border-slate-300 text-left">Sel</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-left">Fecha</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-left">Concepto</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-right">Cargo</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-right">Abono</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-left">Ref.</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-center">Rec.</th>
                </tr>
              </thead>
              <tbody>
                {loading && (
                  <tr><td colSpan={7} className="px-2 py-4 text-center text-slate-500">Cargando transacciones...</td></tr>
                )}
                {!loading && bankTransactions.length === 0 && (
                  <tr><td colSpan={7} className="px-2 py-4 text-center text-slate-500">No hay movimientos bancarios</td></tr>
                )}
                {bankTransactions.map(tx => (
                  <tr key={tx.id} className={tx.reconciled ? "bg-emerald-50" : "even:bg-[#F8FBFF]"}>
                    <td className="px-2 py-1 border-b border-slate-200 text-center">
                      <input type="checkbox" checked={selectedIds.includes(tx.id)} onChange={() => toggleSelection(tx.id)} />
                    </td>
                    <td className="px-2 py-1 border-b border-slate-200">{new Date(tx.date).toLocaleDateString()}</td>
                    <td className="px-2 py-1 border-b border-slate-200">{tx.description}</td>
                    <td className="px-2 py-1 border-b border-slate-200 text-right">{tx.direction === "cargo" ? tx.amount.toFixed(2) : ""}</td>
                    <td className="px-2 py-1 border-b border-slate-200 text-right">{tx.direction === "abono" ? tx.amount.toFixed(2) : ""}</td>
                    <td className="px-2 py-1 border-b border-slate-200">{tx.reference || "—"}</td>
                    <td className="px-2 py-1 border-b border-slate-200 text-center">{tx.reconciled ? "Sí" : "No"}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>

        <div>
          <div className="text-[11px] font-semibold text-[#2A3F55] mb-1 uppercase">Movimientos ERP</div>
          <div className="overflow-auto border border-slate-300 rounded-sm bg-white">
            <table className="w-full text-[11px] border-collapse">
              <thead className="bg-[#EEF2F7] text-slate-800">
                <tr>
                  <th className="px-2 py-2 border-b border-slate-300 text-left">Sel</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-left">Fecha</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-left">Doc.</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-right">Debe</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-right">Haber</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-left">Descripción</th>
                  <th className="px-2 py-2 border-b border-slate-300 text-center">Rec.</th>
                </tr>
              </thead>
              <tbody>
                {loading && (
                  <tr><td colSpan={7} className="px-2 py-4 text-center text-slate-500">Cargando movimientos ERP...</td></tr>
                )}
                {!loading && erpTransactions.length === 0 && (
                  <tr><td colSpan={7} className="px-2 py-4 text-center text-slate-500">No hay movimientos ERP</td></tr>
                )}
                {erpTransactions.map(tx => (
                  <tr key={tx.id} className={tx.reconciled ? "bg-emerald-50" : "even:bg-[#F8FBFF]"}>
                    <td className="px-2 py-1 border-b border-slate-200 text-center">
                      <input type="checkbox" checked={selectedIds.includes(tx.id)} onChange={() => toggleSelection(tx.id)} />
                    </td>
                    <td className="px-2 py-1 border-b border-slate-200">{new Date(tx.date).toLocaleDateString()}</td>
                    <td className="px-2 py-1 border-b border-slate-200">{tx.reference || "ERP"}</td>
                    <td className="px-2 py-1 border-b border-slate-200 text-right">{tx.direction === "debe" ? tx.amount.toFixed(2) : ""}</td>
                    <td className="px-2 py-1 border-b border-slate-200 text-right">{tx.direction === "haber" ? tx.amount.toFixed(2) : ""}</td>
                    <td className="px-2 py-1 border-b border-slate-200">{tx.description}</td>
                    <td className="px-2 py-1 border-b border-slate-200 text-center">{tx.reconciled ? "Sí" : "No"}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}
