// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState, useEffect } from "react";
import { Plus, RefreshCw } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  WindowShell
} from "@/components/ui/desktop-primitives";
import {
  fetchCajaChica,
  fetchGastos,
  createGasto,
  deleteGasto,
  submitGastos,
  reimburseGastos,
  getCajaBalance,
  type CajaChica,
  type Gasto
} from "@/lib/sigecoom-api";
import { Factura } from "@/features/escritorio/windows/Ventas/Documentos/Facturas";

export function CajaChicaList() {
  const [cajas, setCajas] = useState<CajaChica[]>([]);
  const [selectedCajaId, setSelectedCajaId] = useState<string | null>(null);
  const [gastos, setGastos] = useState<Gasto[]>([]);
  const [balance, setBalance] = useState<any>(null);
  const [loading, setLoading] = useState(false);
  const [showNewGasto, setShowNewGasto] = useState(false);

  // New gasto form state
  const [concept, setConcept] = useState("");
  const [voucherType, setVoucherType] = useState("");
  const [voucherNumber, setVoucherNumber] = useState("");
  const [amount, setAmount] = useState(0);
  const [category, setCategory] = useState("Alimentación");
  const [description, setDescription] = useState("");

  // Load cajas on mount
  useEffect(() => {
    loadCajas();
  }, []);

  // Load gastos when caja changes
  useEffect(() => {
    if (selectedCajaId) {
      loadGastos();
      loadBalance();
    }
  }, [selectedCajaId]);

  const loadCajas = async () => {
    try {
      setLoading(true);
      const data = await fetchCajaChica();
      setCajas(data);
      if (data.length > 0 && !selectedCajaId) {
        setSelectedCajaId(data[0].id);
      }
    } catch (error) {
      console.error("Error loading cajas:", error);
    } finally {
      setLoading(false);
    }
  };

  const loadGastos = async () => {
    if (!selectedCajaId) return;
    try {
      const data = await fetchGastos(selectedCajaId);
      setGastos(data);
    } catch (error) {
      console.error("Error loading gastos:", error);
    }
  };

  const loadBalance = async () => {
    if (!selectedCajaId) return;
    try {
      const data = await getCajaBalance(selectedCajaId);
      setBalance(data);
    } catch (error) {
      console.error("Error loading balance:", error);
    }
  };

  const handleAddGasto = async () => {
    if (!selectedCajaId || !concept || amount <= 0) {
      alert("Ingrese datos requeridos");
      return;
    }

    try {
      await createGasto(selectedCajaId, {
        concept,
        voucher_type: voucherType || undefined,
        voucher_number: voucherNumber || undefined,
        amount,
        category,
        description: description || undefined,
      });

      // Reset form
      setConcept("");
      setVoucherType("");
      setVoucherNumber("");
      setAmount(0);
      setCategory("Alimentación");
      setDescription("");
      setShowNewGasto(false);

      // Reload
      await loadGastos();
      await loadBalance();
    } catch (error) {
      alert(`Error: ${(error as Error).message}`);
    }
  };

  const handleDeleteGasto = async (gastoId: string) => {
    if (!confirm("¿Eliminar este gasto?")) return;
    try {
      await deleteGasto(gastoId);
      await loadGastos();
      await loadBalance();
    } catch (error) {
      alert(`Error: ${(error as Error).message}`);
    }
  };

  const handleSubmitGastos = async () => {
    if (!selectedCajaId) return;
    const pendingIds = gastos
      .filter((g) => g.status === "pending")
      .map((g) => g.id);
    if (pendingIds.length === 0) {
      alert("No hay gastos pendientes para presentar");
      return;
    }

    try {
      await submitGastos(selectedCajaId, pendingIds);
      await loadGastos();
      await loadBalance();
      alert("Gastos presentados para reembolso");
    } catch (error) {
      alert(`Error: ${(error as Error).message}`);
    }
  };

  const handleReimburse = async () => {
    if (!selectedCajaId) return;
    const submittedIds = gastos
      .filter((g) => g.status === "submitted")
      .map((g) => g.id);
    if (submittedIds.length === 0) {
      alert("No hay gastos para reembolsar");
      return;
    }

    try {
      await reimburseGastos(selectedCajaId, submittedIds);
      await loadGastos();
      await loadBalance();
      alert("Gastos reembolsados");
    } catch (error) {
      alert(`Error: ${(error as Error).message}`);
    }
  };

  const currentCaja = cajas.find((c) => c.id === selectedCajaId);

  return (
    <WindowShell
      title="Caja Chica — Rendición y Arqueo"
      toolbar={
        <>
          <button className={btnPrimary} onClick={loadGastos}>
            <RefreshCw className="h-3.5 w-3.5" />
            Recargar
          </button>
          <button className={btn} onClick={() => setShowNewGasto(!showNewGasto)}>
            <Plus className="h-3.5 w-3.5" />
            Nuevo gasto
          </button>
          <button className={btn} onClick={handleSubmitGastos}>
            Reembolso
          </button>
          <button className={btn} onClick={handleReimburse}>
            Arqueo
          </button>
        </>
      }
    >
      {/* Caja Selection & Info */}
      <div className="grid grid-cols-4 gap-3 mb-3 p-3 bg-slate-50 rounded">
        <Field label="Caja">
          <select
            className={inp}
            value={selectedCajaId || ""}
            onChange={(e) => setSelectedCajaId(e.target.value)}
          >
            <option value="">-- Seleccionar --</option>
            {cajas.map((c) => (
              <option key={c.id} value={c.id}>
                {c.name}
              </option>
            ))}
          </select>
        </Field>
        {currentCaja && (
          <>
            <Field label="Responsable" className="col-span-2">
              <input className={inp} value={currentCaja.responsible} readOnly />
            </Field>
            <Field label="Fondo Asignado">
              <input
                className={inp}
                type="number"
                value={currentCaja.assigned_fund}
                readOnly
              />
            </Field>
          </>
        )}
      </div>

      {/* New Gasto Form */}
      {showNewGasto && selectedCajaId && (
        <div className="mb-4 p-3 border border-blue-200 bg-blue-50 rounded">
          <h4 className="font-semibold text-sm mb-3">Nuevo Gasto</h4>
          <div className="grid grid-cols-4 gap-3">
            <Field label="Concepto">
              <input
                className={inp}
                value={concept}
                onChange={(e) => setConcept(e.target.value)}
              />
            </Field>
            <Field label="Tipo Comprobante">
              <select
                className={inp}
                value={voucherType}
                onChange={(e) => setVoucherType(e.target.value)}
              >
                <option value="">-- Ninguno --</option>
                <option value="Ticket">Ticket</option>
                <option value="Factura">Factura</option>
                <option value="Recibo">Recibo</option>
              </select>
            </Field>
            <Field label="N° Comprobante">
              <input
                className={inp}
                value={voucherNumber}
                onChange={(e) => setVoucherNumber(e.target.value)}
              />
            </Field>
            <Field label="Monto">
              <input
                className={inp}
                type="number"
                value={amount}
                onChange={(e) => setAmount(parseFloat(e.target.value) || 0)}
              />
            </Field>
            <Field label="Categoría">
              <select
                className={inp}
                value={category}
                onChange={(e) => setCategory(e.target.value)}
              >
                <option>Alimentación</option>
                <option>Transporte</option>
                <option>Oficina</option>
                <option>Suministros</option>
                <option>Otros</option>
              </select>
            </Field>
            <Field label="Descripción" className="col-span-2">
              <input
                className={inp}
                value={description}
                onChange={(e) => setDescription(e.target.value)}
              />
            </Field>
            <div className="col-span-4 flex gap-2">
              <button
                className={btnPrimary}
                onClick={handleAddGasto}
              >
                Guardar
              </button>
              <button
                className={btn}
                onClick={() => {
                  setShowNewGasto(false);
                  setConcept("");
                  setAmount(0);
                  setDescription("");
                }}
              >
                Cancelar
              </button>
            </div>
          </div>
        </div>
      )}

      {/* Gastos Table */}
      <div className="mt-4 overflow-auto max-h-64 border border-slate-200 rounded">
        <table className="w-full text-sm">
          <thead className="sticky top-0 bg-slate-100 border-b">
            <tr>
              <th className="px-3 py-2 text-left">#</th>
              <th className="px-3 py-2 text-left">Fecha</th>
              <th className="px-3 py-2 text-left">Concepto</th>
              <th className="px-3 py-2 text-left">Comprobante</th>
              <th className="px-3 py-2 text-right">Monto</th>
              <th className="px-3 py-2 text-left">Categoría</th>
              <th className="px-3 py-2 text-center">Estado</th>
              <th className="px-3 py-2 text-center">Acciones</th>
            </tr>
          </thead>
          <tbody>
            {loading ? (
              <tr>
                <td colSpan={8} className="px-3 py-2 text-center text-slate-500">
                  Cargando...
                </td>
              </tr>
            ) : gastos.length === 0 ? (
              <tr>
                <td colSpan={8} className="px-3 py-2 text-center text-slate-500">
                  Sin gastos
                </td>
              </tr>
            ) : (
              gastos.map((gasto, idx) => (
                <tr key={gasto.id} className="border-b hover:bg-slate-50">
                  <td className="px-3 py-2 text-xs">{idx + 1}</td>
                  <td className="px-3 py-2 text-xs">
                    {new Date(gasto.date).toLocaleDateString()}
                  </td>
                  <td className="px-3 py-2 text-xs">{gasto.concept}</td>
                  <td className="px-3 py-2 text-xs">
                    {gasto.voucher_type} {gasto.voucher_number || "-"}
                  </td>
                  <td className="px-3 py-2 text-right text-xs font-mono">
                    {gasto.amount.toFixed(2)}
                  </td>
                  <td className="px-3 py-2 text-xs">{gasto.category}</td>
                  <td className="px-3 py-2 text-center">
                    <span
                      className={`text-xs px-2 py-1 rounded ${
                        gasto.status === "reimbursed"
                          ? "bg-green-100 text-green-700"
                          : gasto.status === "submitted"
                            ? "bg-yellow-100 text-yellow-700"
                            : "bg-blue-100 text-blue-700"
                      }`}
                    >
                      {gasto.status === "reimbursed"
                        ? "Reembolsado"
                        : gasto.status === "submitted"
                          ? "Presentado"
                          : "Pendiente"}
                    </span>
                  </td>
                  <td className="px-3 py-2 text-center">
                    {gasto.status === "pending" && (
                      <button
                        className="text-red-600 hover:text-red-800 text-xs"
                        onClick={() => handleDeleteGasto(gasto.id)}
                      >
                        Eliminar
                      </button>
                    )}
                  </td>
                </tr>
              ))
            )}
          </tbody>
        </table>
      </div>

      {/* Balance Summary */}
      {balance && (
        <div className="mt-3 grid grid-cols-4 gap-2 max-w-md ml-auto text-[11.5px]">
          <div className="text-right text-slate-600 col-span-3">
            Gastos registrados:
          </div>
          <div className="text-right font-mono">
            {(balance.total_gastos_pending + balance.total_gastos_reimbursed).toFixed(
              2
            )}
          </div>
          <div className="text-right text-slate-600 col-span-3">Saldo en caja:</div>
          <div className="text-right font-mono font-semibold">
            {balance.saldo_actual.toFixed(2)}
          </div>
          <div className="text-right font-bold text-[#2A3F55] col-span-3">
            Reembolso a solicitar:
          </div>
          <div className="text-right font-mono font-bold">
            {balance.reembolso_a_solicitar.toFixed(2)}
          </div>
        </div>
      )}
    </WindowShell>
  );
}
