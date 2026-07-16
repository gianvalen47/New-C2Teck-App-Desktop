import { createContext, useContext, useState, useRef, useEffect, useCallback, type ReactNode, type CSSProperties, type RefObject, type MouseEvent as ReactMouseEvent } from "react";
import {
  X, Save, Printer, Search, Plus, Trash2, FileDown, FileSpreadsheet,
  Mail, Send, RefreshCw, Filter, Calendar, DollarSign, User, Package,
  Wrench, Clock, Car, MapPin, Phone, Users, GraduationCap, Fingerprint, Play, Square,
  Minus, Maximize2, Minimize2,
} from "lucide-react";
import {
  fetchSigecoomClients,
  fetchSigecoomSales,
  createSigecoomSale,
  issueSigecoomSale,
  updateSigecoomSale,
  sendSigecoomSaleEmail,
  linkSigecoomSalePurchase,
  fetchSigecoomJournalEntries,
  createSigecoomJournalEntry,
  fetchInventory,
  createInventoryItem,
  importSigecoomInventory,
  getInventoryItem,
  updateInventoryItem,
  deleteInventoryItem,
  fetchSigecoomLocations,
  createSigecoomLocation,
  updateSigecoomLocation,
  deleteSigecoomLocation,
  exportSigecoomInventory,
  exportSigecoomSales,
  fetchBankAccounts,
  createBankAccount,
  fetchBankTransactions,
  createBankTransaction,
  updateBankTransaction,
  fetchPurchaseRegisters,
  createPurchaseRegister,
  updatePurchaseRegister,
  deletePurchaseRegister,
  fetchCajaChica,
  createCajaChica,
  updateCajaChica,
  fetchGastos,
  createGasto,
  updateGasto,
  deleteGasto,
  submitGastos,
  reimburseGastos,
  getCajaBalance,
  type SigecoomClient,
  type SigecoomSale,
  type SigecoomJournalEntry,
  type SigecoomJournalLine,
  type BankAccount,
  type BankTransaction,
  type InventoryItem,
  type Location,
  type PurchaseRegister,
  type CajaChica,
  type Gasto,
} from "@/lib/sigecoom-api";

function downloadBlob(blob: Blob, filename: string) {
  const url = URL.createObjectURL(blob);
  const link = document.createElement("a");
  link.href = url;
  link.download = filename;
  document.body.appendChild(link);
  link.click();
  link.remove();
  URL.revokeObjectURL(url);
}

// ---------- Context (MDI floating windows) ----------
export type WindowSize = { w: number; h: number };
export type WindowPos = { x: number; y: number };

export type OpenWindow = {
  id: string;
  label: string;
  position: WindowPos;
  size: WindowSize;
  zIndex: number;
  isMaximized: boolean;
  isMinimized: boolean;
};

type Ctx = {
  windows: OpenWindow[];
  active: string | null;
  open: (label: string) => void;
  close: (id: string) => void;
  focus: (id: string) => void;
  move: (id: string, pos: WindowPos) => void;
  toggleMaximize: (id: string) => void;
  minimize: (id: string) => void;
  restore: (id: string) => void;
};

const WindowsCtx = createContext<Ctx | null>(null);

// Labels that should open wider by default (reports / analytical tables).
function getInitialSize(label: string): WindowSize {
  const wide = new Set<string>([
    "Consultas", "Cartera", "Documentos", "Tablero", "Kardex",
    "Registro de Venta", "Cuentas Corrientes", "Cuentas x Pagar",
    "Inventario", "Movimientos", "Stock Valorizado", "Planilla Sueldos",
    "OT", "Marcaciones",
  ]);
  if (wide.has(label) || /Reporte|Consultas|Tablero|Kardex/i.test(label)) {
    return { w: 900, h: 520 };
  }
  return { w: 680, h: 460 };
}

function normalizeWindowLabel(label: string) {
  return label.replace(/\s+/g, " ").replace(/\n/g, " ").trim();
}

export function WindowsProvider({ children }: { children: ReactNode }) {
  const [windows, setWindows] = useState<OpenWindow[]>([]);
  const [active, setActive] = useState<string | null>(null);
  const zRef = useRef(10);
  const cascadeRef = useRef(0);

  const bringToFront = useCallback((id: string) => {
    zRef.current += 1;
    const z = zRef.current;
    setWindows(prev => prev.map(w => w.id === id ? { ...w, zIndex: z, isMinimized: false } : w));
    setActive(id);
  }, []);

  const open = useCallback((label: string) => {
    const normalizedLabel = normalizeWindowLabel(label);
    setWindows(prev => {
      const existing = prev.find(w => w.label === normalizedLabel);
      if (existing) {
        zRef.current += 1;
        setActive(existing.id);
        return prev.map(w => w.id === existing.id
          ? { ...w, zIndex: zRef.current, isMinimized: false }
          : w);
      }
      zRef.current += 1;
      cascadeRef.current = (cascadeRef.current + 1) % 8;
      const offset = cascadeRef.current * 24;
      const id = `${normalizedLabel}-${Date.now()}-${Math.random().toString(36).slice(2, 6)}`;
      const size = getInitialSize(normalizedLabel);
      const win: OpenWindow = {
        id, label: normalizedLabel,
        position: { x: 40 + offset, y: 20 + offset },
        size,
        zIndex: zRef.current,
        isMaximized: false,
        isMinimized: false,
      };
      setActive(id);
      return [...prev, win];
    });
  }, []);

  const close = useCallback((id: string) => {
    setWindows(prev => {
      const next = prev.filter(w => w.id !== id);
      if (active === id) {
        const top = next.reduce<OpenWindow | null>((a, b) => (!a || b.zIndex > a.zIndex) ? b : a, null);
        setActive(top ? top.id : null);
      }
      return next;
    });
  }, [active]);

  const move = useCallback((id: string, pos: WindowPos) => {
    setWindows(prev => prev.map(w => w.id === id ? { ...w, position: pos } : w));
  }, []);

  const toggleMaximize = useCallback((id: string) => {
    zRef.current += 1;
    const z = zRef.current;
    setWindows(prev => prev.map(w => w.id === id
      ? { ...w, isMaximized: !w.isMaximized, isMinimized: false, zIndex: z }
      : w));
    setActive(id);
  }, []);

  const minimize = useCallback((id: string) => {
    setWindows(prev => prev.map(w => w.id === id ? { ...w, isMinimized: true } : w));
    setActive(prev => {
      // pick next top non-minimized
      return prev;
    });
  }, []);

  const restore = useCallback((id: string) => bringToFront(id), [bringToFront]);

  return (
    <WindowsCtx.Provider value={{
      windows, active, open, close,
      focus: bringToFront, move, toggleMaximize, minimize, restore,
    }}>
      {children}
    </WindowsCtx.Provider>
  );
}

export function useWindows() {
  const c = useContext(WindowsCtx);
  if (!c) throw new Error("useWindows outside provider");
  return c;
}

// ---------- Reusable primitives ----------
function Field({ label, children, className = "" }: { label: string; children: ReactNode; className?: string }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium">{label}</span>
      {children}
    </label>
  );
}
const inp = "h-7 px-2 text-[12px] bg-white border border-slate-400/70 rounded-sm outline-none focus:border-[#3E5B7A] focus:ring-1 focus:ring-[#3E5B7A]/30";
const btn = "inline-flex items-center gap-1 h-7 px-2.5 text-[11.5px] rounded-sm border border-slate-400/70 bg-gradient-to-b from-[#F6F9FC] to-[#DDE4EC] hover:from-[#EEF2F7] hover:to-[#C9D3DF] text-slate-800";
const btnPrimary = "inline-flex items-center gap-1 h-7 px-3 text-[11.5px] rounded-sm border border-[#2A3F55] bg-gradient-to-b from-[#4C6E93] to-[#2A3F55] hover:from-[#5A80A9] text-white font-medium";

function Toolbar({ children }: { children: ReactNode }) {
  return (
    <div className="flex items-center gap-1.5 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
      {children}
    </div>
  );
}

function DataTable({ columns, rows = 0 }: { columns: string[]; rows?: number }) {
  return (
    <div className="border border-slate-400/60 bg-white rounded-sm overflow-hidden">
      <table className="w-full text-[11.5px]">
        <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800">
          <tr>{columns.map(c => <th key={c} className="px-2 py-1 text-left border-r border-slate-300/70 font-semibold">{c}</th>)}</tr>
        </thead>
        <tbody>
          {Array.from({ length: rows }).map((_, i) => (
            <tr key={i} className={i % 2 ? "bg-[#F6F9FC]" : "bg-white"}>
              {columns.map(c => <td key={c} className="px-2 py-1 border-b border-r border-slate-200 text-slate-700">&nbsp;</td>)}
            </tr>
          ))}
          {rows === 0 && (
            <tr><td colSpan={columns.length} className="px-2 py-6 text-center text-slate-400 text-[11px]">— sin registros —</td></tr>
          )}
        </tbody>
      </table>
    </div>
  );
}

function WindowShell({ title, toolbar, children }: { title: string; toolbar?: ReactNode; children: ReactNode }) {
  return (
    <div className="h-full flex flex-col bg-[#F3F6FA]">
      <div className="window-shell-titlebar px-3 py-1.5 bg-gradient-to-b from-[#4C6E93] to-[#2A3F55] text-white text-[12px] font-semibold flex items-center gap-2 shrink-0">
        <span className="opacity-90">■</span> {title}
      </div>
      {toolbar && <Toolbar>{toolbar}</Toolbar>}
      <div className="flex-1 overflow-auto p-3">{children}</div>
    </div>
  );
}

// ---------- Ventas: Documentos ----------
function GuiaRemision() {
  const [clients, setClients] = useState<SigecoomClient[]>([]);
  const [selectedClientId, setSelectedClientId] = useState("");
  const [loadingClients, setLoadingClients] = useState(true);
  const [clientsError, setClientsError] = useState<string | null>(null);
  const [saving, setSaving] = useState(false);
  const [saveMessage, setSaveMessage] = useState<string | null>(null);
  const [number, setNumber] = useState(1);
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [origin, setOrigin] = useState("Almacén Central Lima");
  const [destination, setDestination] = useState("");
  const [reason, setReason] = useState("Venta");
  const [carrierRuc, setCarrierRuc] = useState("");
  const [carrierName, setCarrierName] = useState("");
  const [plate, setPlate] = useState("");
  const [driverDni, setDriverDni] = useState("");
  const [license, setLicense] = useState("");
  const [weight, setWeight] = useState(0);
  const [packages, setPackages] = useState(1);
  const [items, setItems] = useState([
    { id: "item-1", code: "", description: "", unit: "NIU", quantity: 1, price: 0 },
  ]);

  useEffect(() => {
    let active = true;
    setLoadingClients(true);
    fetchSigecoomClients()
      .then((data) => {
        if (!active) return;
        setClients(data);
        setClientsError(null);
      })
      .catch((error) => {
        if (!active) return;
        setClientsError(error instanceof Error ? error.message : "Error cargando los clientes");
      })
      .finally(() => {
        if (!active) return;
        setLoadingClients(false);
      });
    return () => { active = false; };
  }, []);

  const selectedClient = clients.find((client) => client.id === selectedClientId);
  const lineSubtotal = items.reduce((sum, item) => sum + item.quantity * item.price, 0);
  const tax = Number((lineSubtotal * 0.18).toFixed(2));
  const total = Number((lineSubtotal + tax).toFixed(2));

  const formatCurrency = (value: number) =>
    value.toLocaleString("es-PE", { style: "currency", currency: "PEN", minimumFractionDigits: 2 });

  const updateItem = (id: string, changes: Partial<typeof items[number]>) => {
    setItems((current) => current.map((item) => item.id === id ? { ...item, ...changes } : item));
  };

  const addItem = () => {
    setItems((current) => [
      ...current,
      { id: `item-${Date.now()}`, code: "", description: "", unit: "NIU", quantity: 1, price: 0 },
    ]);
  };

  const removeItem = (id: string) => {
    setItems((current) => current.filter((item) => item.id !== id));
  };

  const canSave = Boolean(selectedClientId && items.some((item) => item.description.trim() && item.quantity > 0 && item.price > 0));

  const handleSaveGuia = async () => {
    if (!canSave) {
      setSaveMessage("Seleccione un cliente y agregue al menos un ítem con descripción, cantidad y precio.");
      return;
    }

    setSaving(true);
    setSaveMessage(null);

    try {
      await createSigecoomSale({
        type: "Guía Remisión",
        series: "GR001",
        number,
        date,
        client_id: selectedClientId,
        items: items.map((item) => ({
          code: item.code || undefined,
          description: item.description,
          unit: item.unit,
          quantity: item.quantity,
          price: item.price,
        })),
        subtotal: lineSubtotal,
        tax,
        total,
      });
      setSaveMessage(`Guía de Remisión creada: GR001-${number.toString().padStart(7, "0")}`);
      setNumber((current) => current + 1);
    } catch (error) {
      setSaveMessage(error instanceof Error ? error.message : "No se pudo guardar la guía");
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Guía de Remisión — Emisión"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSaveGuia} disabled={saving}>
          <Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Guardar"}
        </button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
        <button className={btn}><Search className="h-3.5 w-3.5" />Buscar</button>
        <span className="ml-auto text-[11px] text-slate-500">Nº: <b>{`GR${number.toString().padStart(3, "0")}-${number.toString().padStart(7, "0")}`}</b></span>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Cliente" className="col-span-2">
          <select className={inp} value={selectedClientId} onChange={(event) => setSelectedClientId(event.target.value)}>
            <option value="">-- Seleccione cliente --</option>
            {clients.map((client) => (
              <option key={client.id} value={client.id}>
                {client.ruc ?? "N/A"} — {client.name}
              </option>
            ))}
          </select>
        </Field>
        <Field label="Almacén Origen">
          <select className={inp} value={origin} onChange={(event) => setOrigin(event.target.value)}>
            <option>Almacén Central Lima</option>
            <option>Almacén Norte</option>
          </select>
        </Field>
        <Field label="Punto de Llegada" className="col-span-3"><input className={inp} value={destination} onChange={(event) => setDestination(event.target.value)} placeholder="Dirección de destino" /></Field>
        <Field label="Motivo Traslado">
          <select className={inp} value={reason} onChange={(event) => setReason(event.target.value)}>
            <option>Venta</option>
            <option>Traslado entre almacenes</option>
            <option>Devolución</option>
          </select>
        </Field>
        <Field label="Fecha de Traslado"><input type="date" className={inp} value={date} onChange={(event) => setDate(event.target.value)} /></Field>
        <Field label="Transportista (RUC)"><input className={inp} value={carrierRuc} onChange={(event) => setCarrierRuc(event.target.value)} placeholder="20xxxxxxxxx" /></Field>
        <Field label="Razón Social" className="col-span-2"><input className={inp} value={carrierName} onChange={(event) => setCarrierName(event.target.value)} /></Field>
        <Field label="Vehículo (Placa)"><input className={inp} value={plate} onChange={(event) => setPlate(event.target.value)} placeholder="ABC-123" /></Field>
        <Field label="Conductor (DNI)"><input className={inp} value={driverDni} onChange={(event) => setDriverDni(event.target.value)} /></Field>
        <Field label="Licencia"><input className={inp} value={license} onChange={(event) => setLicense(event.target.value)} /></Field>
        <Field label="Peso Total (kg)"><input className={inp} type="number" value={weight} onChange={(event) => setWeight(Number(event.target.value))} /></Field>
        <Field label="Bultos"><input className={inp} type="number" value={packages} onChange={(event) => setPackages(Number(event.target.value))} /></Field>
      </div>
      <div className="mt-4 flex items-center justify-between mb-1.5">
        <div className="text-[12px] font-semibold text-slate-700">Detalle de ítems</div>
        <div className="flex gap-1.5">
          <button className={btn} onClick={addItem}><Plus className="h-3.5 w-3.5" />Añadir</button>
          <button className={btn} onClick={() => items.length > 1 && removeItem(items[items.length - 1].id)}><Trash2 className="h-3.5 w-3.5" />Quitar</button>
        </div>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA] text-slate-700">
            <tr>
              <th className="px-2 py-2 text-left border-b border-slate-300">#</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Código</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Descripción</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">U.M.</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Cant.</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">P.Unit</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Total</th>
              <th className="px-2 py-2 text-center border-b border-slate-300">Quitar</th>
            </tr>
          </thead>
          <tbody>
            {items.map((item, index) => (
              <tr key={item.id} className="odd:bg-[#FBFCFD] even:bg-white">
                <td className="px-2 py-2 border-b border-slate-200">{index + 1}</td>
                <td className="px-2 py-2 border-b border-slate-200"><input className={inp} value={item.code} onChange={(event) => updateItem(item.id, { code: event.target.value })} /></td>
                <td className="px-2 py-2 border-b border-slate-200"><input className={inp} value={item.description} onChange={(event) => updateItem(item.id, { description: event.target.value })} /></td>
                <td className="px-2 py-2 border-b border-slate-200"><input className={inp} value={item.unit} onChange={(event) => updateItem(item.id, { unit: event.target.value })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right"><input type="number" min="0" className={inp} value={item.quantity} onChange={(event) => updateItem(item.id, { quantity: Number(event.target.value) || 0 })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right"><input type="number" min="0" step="0.01" className={inp} value={item.price} onChange={(event) => updateItem(item.id, { price: Number(event.target.value) || 0 })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right">{formatCurrency(item.quantity * item.price)}</td>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><button type="button" className={btn} onClick={() => removeItem(item.id)}>✕</button></td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      <div className="mt-3 grid grid-cols-4 gap-2 max-w-md ml-auto text-[11.5px]">
        <div className="text-right text-slate-600 col-span-3">Subtotal:</div><div className="text-right font-mono">{formatCurrency(lineSubtotal)}</div>
        <div className="text-right text-slate-600 col-span-3">IGV (18%):</div><div className="text-right font-mono">{formatCurrency(tax)}</div>
        <div className="text-right font-bold text-[#2A3F55] col-span-3">TOTAL S/:</div><div className="text-right font-mono font-bold text-[#2A3F55]">{formatCurrency(total)}</div>
      </div>
      {saveMessage && <div className="mt-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{saveMessage}</div>}
    </WindowShell>
  );
}

function Factura() {
  const [clients, setClients] = useState<SigecoomClient[]>([]);
  const [selectedClientId, setSelectedClientId] = useState("");
  const [sales, setSales] = useState<SigecoomSale[]>([]);
  const [loadingSales, setLoadingSales] = useState(true);
  const [salesError, setSalesError] = useState<string | null>(null);
  const [clientsLoading, setClientsLoading] = useState(true);
  const [clientsError, setClientsError] = useState<string | null>(null);
  const [saving, setSaving] = useState(false);
  const [issuing, setIssuing] = useState(false);
  const [saveMessage, setSaveMessage] = useState<string | null>(null);
  const [createdSaleId, setCreatedSaleId] = useState<string | null>(null);

  const [series, setSeries] = useState("F001");
  const [number, setNumber] = useState(123);
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [currency, setCurrency] = useState("PEN");
  const [exchangeRate, setExchangeRate] = useState("3.411");
  const [paymentCondition, setPaymentCondition] = useState("Contado");
  const [dueDate, setDueDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [seller, setSeller] = useState("grios — G. Ríos");
  const [warehouse, setWarehouse] = useState("Central Lima");
  const [guideRef, setGuideRef] = useState("");
  const [items, setItems] = useState([
    { id: "item-1", code: "", description: "", unit: "NIU", quantity: 1, price: 0 },
  ]);

  useEffect(() => {
    let active = true;
    setClientsLoading(true);
    fetchSigecoomClients()
      .then((data) => {
        if (!active) return;
        setClients(data);
        setClientsError(null);
      })
      .catch((error) => {
        if (!active) return;
        setClientsError(error instanceof Error ? error.message : "Error cargando los clientes");
      })
      .finally(() => {
        if (!active) return;
        setClientsLoading(false);
      });
    return () => { active = false; };
  }, []);

  useEffect(() => {
    let active = true;
    setLoadingSales(true);
    fetchSigecoomSales()
      .then((data) => {
        if (!active) return;
        setSales(data);
        setSalesError(null);
      })
      .catch((error) => {
        if (!active) return;
        setSalesError(error instanceof Error ? error.message : "Error cargando las ventas");
      })
      .finally(() => {
        if (!active) return;
        setLoadingSales(false);
      });
    return () => { active = false; };
  }, []);

  const selectedClient = clients.find((client) => client.id === selectedClientId);
  const lineSubtotal = items.reduce((sum, item) => sum + item.quantity * item.price, 0);
  const tax = Number((lineSubtotal * 0.18).toFixed(2));
  const total = Number((lineSubtotal + tax).toFixed(2));

  const formatCurrency = (value: number) =>
    value.toLocaleString("es-PE", { style: "currency", currency: "PEN", minimumFractionDigits: 2 });

  const updateItem = (id: string, changes: Partial<typeof items[number]>) => {
    setItems((current) => current.map((item) => item.id === id ? { ...item, ...changes } : item));
  };

  const addItem = () => {
    setItems((current) => [
      ...current,
      { id: `item-${Date.now()}`, code: "", description: "", unit: "NIU", quantity: 1, price: 0 },
    ]);
  };

  const removeItem = (id: string) => {
    setItems((current) => current.filter((item) => item.id !== id));
  };

  const canSave = Boolean(selectedClientId && items.some((item) => item.description.trim() && item.quantity > 0 && item.price > 0));

  const handleSaveFactura = async () => {
    if (!canSave) {
      setSaveMessage("Seleccione un cliente y agregue al menos un ítem con descripción, cantidad y precio.");
      return;
    }

    setSaving(true);
    setSaveMessage(null);

    try {
      const created = await createSigecoomSale({
        type: "Factura",
        series,
        number,
        date,
        client_id: selectedClientId,
        items: items.map((item) => ({
          code: item.code || undefined,
          description: item.description,
          unit: item.unit,
          quantity: item.quantity,
          price: item.price,
        })),
        subtotal: lineSubtotal,
        tax,
        total,
      });

      setCreatedSaleId(created.id);
      setSales((current) => [created, ...current]);
      setSaveMessage(`Factura creada: ${created.series ?? "-"}-${created.number ?? "-"}`);
    } catch (error) {
      setSaveMessage(error instanceof Error ? error.message : "No se pudo emitir la factura");
    } finally {
      setSaving(false);
    }
  };

  const handleSendFacturaToSunat = async () => {
    if (!createdSaleId) {
      setSaveMessage("Guarde la factura antes de enviar a SUNAT.");
      return;
    }

    setIssuing(true);
    setSaveMessage(null);

    try {
      const issued = await issueSigecoomSale(createdSaleId);
      setSales((current) => [issued, ...current.filter((sale) => sale.id !== issued.id)]);
      setSaveMessage(`Factura enviada a SUNAT. Estado: ${issued.status ?? "enviado"}`);
    } catch (error) {
      setSaveMessage(error instanceof Error ? error.message : "No se pudo enviar la factura a SUNAT");
    } finally {
      setIssuing(false);
    }
  };

  const handleSearchFactura = () => {
    const found = sales.find((sale) => sale.series === series && sale.number === number);
    if (!found) {
      setSaveMessage("No se encontró una factura con esa serie y número.");
      return;
    }
    setSaveMessage(`Factura encontrada: ${found.series}-${found.number} · Estado: ${found.status ?? "pendiente"}`);
  };

  return (
    <WindowShell title="Factura Electrónica — Emisión"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSaveFactura} disabled={saving}>
          <Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Emitir"}
        </button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
        <button className={btn} onClick={handleSendFacturaToSunat} disabled={issuing || !createdSaleId}>
          <Mail className="h-3.5 w-3.5" />{issuing ? "Enviando..." : "Enviar SUNAT"}
        </button>
        <button className={btn} onClick={handleSearchFactura}>
          <Search className="h-3.5 w-3.5" />Buscar
        </button>
        <span className="ml-auto text-[11px] text-slate-500">Serie: <b>{series}</b> · Nº: <b>{number.toString().padStart(7, "0")}</b></span>
      </>}>
      <div className="grid grid-cols-2 gap-4">
        <div className="border border-slate-300 rounded-sm p-3 bg-white">
          <div className="text-[11px] font-semibold text-[#2A3F55] mb-2 uppercase">Datos del Cliente</div>
          <div className="grid grid-cols-3 gap-2">
            <Field label="Cliente" className="col-span-3">
              <select
                className={inp}
                value={selectedClientId}
                onChange={(event) => setSelectedClientId(event.target.value)}
              >
                <option value="">-- Seleccione cliente --</option>
                {clients.map((client) => (
                  <option key={client.id} value={client.id}>
                    {client.ruc ?? "N/A"} — {client.name}
                  </option>
                ))}
              </select>
            </Field>
            <Field label="Razón Social" className="col-span-3"><input className={inp} readOnly value={selectedClient?.name ?? ""} /></Field>
            <Field label="Dirección Fiscal" className="col-span-3"><input className={inp} readOnly value={selectedClient?.address ?? ""} /></Field>
            <Field label="Contacto" className="col-span-2"><input className={inp} readOnly value={selectedClient?.email ?? ""} /></Field>
            <Field label="Teléfono"><input className={inp} readOnly value={selectedClient?.phone ?? ""} /></Field>
            {clientsLoading && <div className="col-span-3 px-2 py-2 text-xs text-slate-500">Cargando clientes...</div>}
            {clientsError && <div className="col-span-3 px-2 py-2 text-xs text-red-600">{clientsError}</div>}
          </div>
        </div>
        <div className="border border-slate-300 rounded-sm p-3 bg-white">
          <div className="text-[11px] font-semibold text-[#2A3F55] mb-2 uppercase">Condiciones Comerciales</div>
          <div className="grid grid-cols-2 gap-2">
            <Field label="Moneda">
              <select className={inp} value={currency} onChange={(event) => setCurrency(event.target.value)}>
                <option value="PEN">PEN — Soles</option>
                <option value="USD">USD — Dólares</option>
              </select>
            </Field>
            <Field label="Tipo de Cambio"><input className={inp} value={exchangeRate} onChange={(event) => setExchangeRate(event.target.value)} /></Field>
            <Field label="Condición de Pago">
              <select className={inp} value={paymentCondition} onChange={(event) => setPaymentCondition(event.target.value)}>
                <option>Contado</option>
                <option>Crédito 30 días</option>
                <option>Crédito 60 días</option>
              </select>
            </Field>
            <Field label="Fecha"><input className={inp} type="date" value={date} onChange={(event) => setDate(event.target.value)} /></Field>
            <Field label="Fecha Vencimiento"><input className={inp} type="date" value={dueDate} onChange={(event) => setDueDate(event.target.value)} /></Field>
            <Field label="Vendedor"><input className={inp} value={seller} onChange={(event) => setSeller(event.target.value)} /></Field>
            <Field label="Almacén"><input className={inp} value={warehouse} onChange={(event) => setWarehouse(event.target.value)} /></Field>
            <Field label="Guía Referencia" className="col-span-2"><input className={inp} value={guideRef} onChange={(event) => setGuideRef(event.target.value)} placeholder="GR-0001-0000123" /></Field>
          </div>
        </div>
      </div>
      <div className="mt-4 flex items-center justify-between mb-1.5">
        <div className="text-[12px] font-semibold text-slate-700">Detalle de artículos</div>
        <div className="flex gap-1.5">
          <button type="button" className={btn} onClick={addItem}><Plus className="h-3.5 w-3.5" />Añadir ítem</button>
          <button type="button" className={btn} onClick={() => items.length > 1 && setItems(items.slice(0, -1))}><Trash2 className="h-3.5 w-3.5" />Eliminar último</button>
        </div>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA] text-slate-700">
            <tr>
              <th className="px-2 py-2 text-left border-b border-slate-300">#</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Código</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Descripción</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">U.M.</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Cant.</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">P.Unit</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Total</th>
              <th className="px-2 py-2 text-center border-b border-slate-300">Quitar</th>
            </tr>
          </thead>
          <tbody>
            {items.map((item, index) => (
              <tr key={item.id} className="odd:bg-[#FBFCFD] even:bg-white">
                <td className="px-2 py-2 border-b border-slate-200">{index + 1}</td>
                <td className="px-2 py-2 border-b border-slate-200"><input className={inp} value={item.code} onChange={(event) => updateItem(item.id, { code: event.target.value })} /></td>
                <td className="px-2 py-2 border-b border-slate-200"><input className={inp} value={item.description} onChange={(event) => updateItem(item.id, { description: event.target.value })} /></td>
                <td className="px-2 py-2 border-b border-slate-200"><input className={inp} value={item.unit} onChange={(event) => updateItem(item.id, { unit: event.target.value })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right"><input type="number" min="0" className={inp} value={item.quantity} onChange={(event) => updateItem(item.id, { quantity: Number(event.target.value) || 0 })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right"><input type="number" min="0" step="0.01" className={inp} value={item.price} onChange={(event) => updateItem(item.id, { price: Number(event.target.value) || 0 })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right">{formatCurrency(item.quantity * item.price)}</td>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><button type="button" className={btn} onClick={() => removeItem(item.id)}>✕</button></td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      <div className="mt-3 grid grid-cols-4 gap-2 max-w-md ml-auto text-[11.5px]">
        <div className="text-right text-slate-600 col-span-3">Subtotal:</div><div className="text-right font-mono">{formatCurrency(lineSubtotal)}</div>
        <div className="text-right text-slate-600 col-span-3">IGV (18%):</div><div className="text-right font-mono">{formatCurrency(tax)}</div>
        <div className="text-right font-bold text-[#2A3F55] col-span-3">TOTAL S/:</div><div className="text-right font-mono font-bold text-[#2A3F55]">{formatCurrency(total)}</div>
      </div>
      {saveMessage && <div className="mt-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{saveMessage}</div>}
      <div className="mt-6">
        <div className="flex items-center justify-between mb-2">
          <div className="text-[12px] font-semibold text-slate-700">Ventas recientes</div>
          <span className="text-[11px] text-slate-500">{sales.length} documentos cargados</span>
        </div>
        <div className="border border-slate-300 rounded-sm bg-white overflow-auto max-h-52">
          {loadingSales ? (
            <div className="px-3 py-4 text-sm text-slate-500">Cargando ventas desde el backend...</div>
          ) : salesError ? (
            <div className="px-3 py-4 text-sm text-red-600">{salesError}</div>
          ) : sales.length === 0 ? (
            <div className="px-3 py-4 text-sm text-slate-500">No hay ventas registradas.</div>
          ) : (
            <table className="w-full text-[11px] border-collapse">
              <thead className="bg-[#F3F6FA] text-slate-700">
                <tr>
                  <th className="px-2 py-2 text-left border-b border-slate-300">Tipo</th>
                  <th className="px-2 py-2 text-left border-b border-slate-300">Documento</th>
                  <th className="px-2 py-2 text-left border-b border-slate-300">Fecha</th>
                  <th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th>
                  <th className="px-2 py-2 text-right border-b border-slate-300">Total</th>
                  <th className="px-2 py-2 text-left border-b border-slate-300">Estado</th>
                </tr>
              </thead>
              <tbody>
                {sales.map((sale) => (
                  <tr key={sale.id} className="odd:bg-[#FBFCFD] even:bg-white">
                    <td className="px-2 py-2 border-b border-slate-200">{sale.type}</td>
                    <td className="px-2 py-2 border-b border-slate-200">{sale.series ?? "-"}-{sale.number ?? "-"}</td>
                    <td className="px-2 py-2 border-b border-slate-200">{new Date(sale.date).toLocaleDateString("es-PE")}</td>
                    <td className="px-2 py-2 border-b border-slate-200">{sale.client_id ?? "Cliente desconocido"}</td>
                    <td className="px-2 py-2 border-b border-slate-200 text-right">{formatCurrency(sale.total)}</td>
                    <td className="px-2 py-2 border-b border-slate-200">{sale.status}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </div>
      </div>
    </WindowShell>
  );
}

function Notas() {
  const [noteType, setNoteType] = useState("Nota de Crédito");
  const [referenceDoc, setReferenceDoc] = useState("");
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [reason, setReason] = useState("01 - Anulación de la operación");
  const [currency, setCurrency] = useState("PEN");
  const [description, setDescription] = useState("");
  const [items, setItems] = useState([{ id: "item-1", code: "", description: "", quantity: 1, price: 0 }]);
  const [saving, setSaving] = useState(false);
  const [saveMessage, setSaveMessage] = useState<string | null>(null);

  const lineSubtotal = items.reduce((sum, item) => sum + item.quantity * item.price, 0);
  const tax = Number((lineSubtotal * 0.18).toFixed(2));
  const total = Number((lineSubtotal + tax).toFixed(2));

  const formatCurrency = (value: number) =>
    value.toLocaleString("es-PE", { style: "currency", currency: "PEN", minimumFractionDigits: 2 });

  const updateItem = (id: string, changes: Partial<typeof items[number]>) => {
    setItems((current) => current.map((item) => item.id === id ? { ...item, ...changes } : item));
  };

  const addItem = () => {
    setItems((current) => [...current, { id: `item-${Date.now()}`, code: "", description: "", quantity: 1, price: 0 }]);
  };

  const removeItem = (id: string) => {
    setItems((current) => current.filter((item) => item.id !== id));
  };

  const canSave = Boolean(referenceDoc.trim() && items.some((item) => item.description.trim() && item.quantity > 0 && item.price > 0));

  const handleSaveNota = async () => {
    if (!canSave) {
      setSaveMessage("Complete documento de referencia y agregue al menos un ítem.");
      return;
    }
    setSaving(true);
    setSaveMessage(null);
    try {
      await createSigecoomSale({
        type: noteType,
        series: noteType === "Nota de Crédito" ? "NC001" : "ND001",
        number: Math.floor(Math.random() * 10000),
        date,
        items: items.map((item) => ({
          code: item.code || undefined,
          description: item.description,
          unit: "unidad",
          quantity: item.quantity,
          price: item.price,
        })),
        subtotal: lineSubtotal,
        tax,
        total,
      });
      setSaveMessage(`${noteType} creada exitosamente - Referencia: ${referenceDoc}`);
      setReferenceDoc("");
      setDescription("");
      setItems([{ id: "item-1", code: "", description: "", quantity: 1, price: 0 }]);
    } catch (error) {
      setSaveMessage(error instanceof Error ? error.message : `No se pudo emitir la ${noteType}`);
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Notas de Crédito / Débito"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSaveNota} disabled={saving}><Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Emitir"}</button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
        <span className="ml-auto text-[11px] text-slate-500">Tipo: <b>{noteType}</b></span>
      </>}>
      <div className="grid grid-cols-3 gap-3">
        <Field label="Tipo de Nota"><select className={inp} value={noteType} onChange={(e) => setNoteType(e.target.value)}><option>Nota de Crédito</option><option>Nota de Débito</option></select></Field>
        <Field label="Doc. Referencia (F/B)"><input className={inp} value={referenceDoc} onChange={(e) => setReferenceDoc(e.target.value)} placeholder="F001-0000123" /></Field>
        <Field label="Fecha"><input className={inp} type="date" value={date} onChange={(e) => setDate(e.target.value)} /></Field>
        <Field label="Motivo (SUNAT)" className="col-span-2"><select className={inp} value={reason} onChange={(e) => setReason(e.target.value)}><option>01 - Anulación de la operación</option><option>02 - Anulación por error en RUC</option><option>03 - Corrección por error en la descripción</option><option>07 - Devolución por ítem</option></select></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option value="PEN">PEN</option><option value="USD">USD</option></select></Field>
        <Field label="Descripción / Sustento" className="col-span-3"><textarea className={`${inp} h-16 py-1`} value={description} onChange={(e) => setDescription(e.target.value)} placeholder="Motivo y sustento de la nota..." /></Field>
      </div>
      <div className="mt-3 flex items-center justify-between mb-1.5">
        <div className="text-[12px] font-semibold text-slate-700">Ítems ajustados</div>
        <div className="flex gap-1.5">
          <button type="button" className={btn} onClick={addItem}><Plus className="h-3.5 w-3.5" />Añadir</button>
          <button type="button" className={btn} onClick={() => items.length > 1 && removeItem(items[items.length - 1].id)}><Trash2 className="h-3.5 w-3.5" />Quitar</button>
        </div>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">#</th><th className="px-2 py-2 text-left border-b border-slate-300">Código</th><th className="px-2 py-2 text-left border-b border-slate-300">Descripción</th><th className="px-2 py-2 text-right border-b border-slate-300">Cant.</th><th className="px-2 py-2 text-right border-b border-slate-300">P.Unit</th><th className="px-2 py-2 text-right border-b border-slate-300">Total</th><th className="px-2 py-2 text-center border-b border-slate-300">Quitar</th></tr></thead>
          <tbody>
            {items.map((item, idx) => (
              <tr key={item.id} className="odd:bg-[#FBFCFD] even:bg-white">
                <td className="px-2 py-2 border-b border-slate-200">{idx + 1}</td>
                <td className="px-2 py-2 border-b border-slate-200"><input className={inp} value={item.code} onChange={(e) => updateItem(item.id, { code: e.target.value })} /></td>
                <td className="px-2 py-2 border-b border-slate-200"><input className={inp} value={item.description} onChange={(e) => updateItem(item.id, { description: e.target.value })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right"><input type="number" min="0" className={inp} value={item.quantity} onChange={(e) => updateItem(item.id, { quantity: Number(e.target.value) || 0 })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right"><input type="number" min="0" step="0.01" className={inp} value={item.price} onChange={(e) => updateItem(item.id, { price: Number(e.target.value) || 0 })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right">{formatCurrency(item.quantity * item.price)}</td>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><button type="button" className={btn} onClick={() => removeItem(item.id)}>✕</button></td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      <div className="mt-3 grid grid-cols-4 gap-2 max-w-xs ml-auto text-[11.5px]">
        <div className="text-right text-slate-600 col-span-3">Subtotal:</div><div className="text-right font-mono">{formatCurrency(lineSubtotal)}</div>
        <div className="text-right text-slate-600 col-span-3">IGV (18%):</div><div className="text-right font-mono">{formatCurrency(tax)}</div>
        <div className="text-right font-bold text-[#2A3F55] col-span-3">TOTAL:</div><div className="text-right font-mono font-bold">{formatCurrency(total)}</div>
      </div>
      {saveMessage && <div className="mt-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{saveMessage}</div>}
    </WindowShell>
  );
}

function GuiaDevolucion() {
  const [referenceGuide, setReferenceGuide] = useState("");
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [returnReason, setReturnReason] = useState("No conforme");
  const [destination, setDestination] = useState("Central Lima");
  const [items, setItems] = useState([{ id: "item-1", code: "", description: "", originalQty: 1, returnQty: 1 }]);
  const [saving, setSaving] = useState(false);
  const [saveMessage, setSaveMessage] = useState<string | null>(null);

  const updateItem = (id: string, changes: Partial<typeof items[number]>) => {
    setItems((current) => current.map((item) => item.id === id ? { ...item, ...changes } : item));
  };

  const addItem = () => {
    setItems((current) => [...current, { id: `item-${Date.now()}`, code: "", description: "", originalQty: 1, returnQty: 1 }]);
  };

  const removeItem = (id: string) => {
    setItems((current) => current.filter((item) => item.id !== id));
  };

  const canSave = Boolean(referenceGuide.trim() && items.some((item) => item.description.trim() && item.returnQty > 0));

  const handleSaveDev = async () => {
    if (!canSave) {
      setSaveMessage("Complete guía de referencia y agregue ítems a devolver.");
      return;
    }
    setSaving(true);
    setSaveMessage(null);
    try {
      await createSigecoomSale({
        type: "Guía Devolución",
        series: "GD001",
        number: Math.floor(Math.random() * 10000),
        date,
        items: items.map((item) => ({
          code: item.code || undefined,
          description: `${item.description} (Dev: ${item.returnQty}/${item.originalQty})`,
          unit: "unidad",
          quantity: item.returnQty,
          price: 0,
        })),
        subtotal: 0,
        tax: 0,
        total: 0,
      });
      setSaveMessage(`Devolución registrada - Referencia: ${referenceGuide}`);
      setReferenceGuide("");
      setItems([{ id: "item-1", code: "", description: "", originalQty: 1, returnQty: 1 }]);
    } catch (error) {
      setSaveMessage(error instanceof Error ? error.message : "No se pudo registrar la devolución");
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Guía de Devolución"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSaveDev} disabled={saving}><Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Registrar Retorno"}</button>
        <button className={btn}><Search className="h-3.5 w-3.5" />Buscar G/R Original</button>
        <span className="ml-auto text-[11px] text-slate-500">Motivo: <b>{returnReason}</b></span>
      </>}>
      <div className="grid grid-cols-3 gap-3">
        <Field label="G/R Original" className="col-span-2"><input className={inp} value={referenceGuide} onChange={(e) => setReferenceGuide(e.target.value)} placeholder="GR-0001-0000000" /></Field>
        <Field label="Fecha Retorno"><input className={inp} type="date" value={date} onChange={(e) => setDate(e.target.value)} /></Field>
        <Field label="Almacén Destino"><select className={inp} value={destination} onChange={(e) => setDestination(e.target.value)}><option>Central Lima</option><option>Almacén Norte</option></select></Field>
        <Field label="Motivo" className="col-span-2"><select className={inp} value={returnReason} onChange={(e) => setReturnReason(e.target.value)}><option>No conforme</option><option>Rechazo cliente</option><option>Excedente</option><option>Dañado</option></select></Field>
      </div>
      <div className="mt-4 flex items-center justify-between mb-1.5">
        <div className="text-[12px] font-semibold text-slate-700">Ítems a devolver</div>
        <div className="flex gap-1.5">
          <button type="button" className={btn} onClick={addItem}><Plus className="h-3.5 w-3.5" />Añadir</button>
          <button type="button" className={btn} onClick={() => items.length > 1 && removeItem(items[items.length - 1].id)}><Trash2 className="h-3.5 w-3.5" />Quitar</button>
        </div>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">#</th><th className="px-2 py-2 text-left border-b border-slate-300">Código</th><th className="px-2 py-2 text-left border-b border-slate-300">Descripción</th><th className="px-2 py-2 text-right border-b border-slate-300">Cant. Original</th><th className="px-2 py-2 text-right border-b border-slate-300">Cant. Devuelta</th><th className="px-2 py-2 text-center border-b border-slate-300">Quitar</th></tr></thead>
          <tbody>
            {items.map((item, idx) => (
              <tr key={item.id} className="odd:bg-[#FBFCFD] even:bg-white">
                <td className="px-2 py-2 border-b border-slate-200">{idx + 1}</td>
                <td className="px-2 py-2 border-b border-slate-200"><input className={inp} value={item.code} onChange={(e) => updateItem(item.id, { code: e.target.value })} /></td>
                <td className="px-2 py-2 border-b border-slate-200"><input className={inp} value={item.description} onChange={(e) => updateItem(item.id, { description: e.target.value })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right"><input type="number" min="0" className={inp} value={item.originalQty} onChange={(e) => updateItem(item.id, { originalQty: Number(e.target.value) || 0 })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right"><input type="number" min="0" className={inp} value={item.returnQty} onChange={(e) => updateItem(item.id, { returnQty: Number(e.target.value) || 0 })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><button type="button" className={btn} onClick={() => removeItem(item.id)}>✕</button></td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      {saveMessage && <div className="mt-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{saveMessage}</div>}
    </WindowShell>
  );
}

function Boleta() {
  const [clients, setClients] = useState<SigecoomClient[]>([]);
  const [selectedClientId, setSelectedClientId] = useState("");
  const [sales, setSales] = useState<SigecoomSale[]>([]);
  const [loadingSales, setLoadingSales] = useState(true);
  const [salesError, setSalesError] = useState<string | null>(null);
  const [loadingClients, setLoadingClients] = useState(true);
  const [clientsError, setClientsError] = useState<string | null>(null);
  const [saving, setSaving] = useState(false);
  const [issuing, setIssuing] = useState(false);
  const [saveMessage, setSaveMessage] = useState<string | null>(null);
  const [createdSaleId, setCreatedSaleId] = useState<string | null>(null);

  const [series, setSeries] = useState("B001");
  const [number, setNumber] = useState(1);
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [currency, setCurrency] = useState("PEN");
  const [paymentCondition, setPaymentCondition] = useState("Contado");
  const [seller, setSeller] = useState("grios — G. Ríos");
  const [warehouse, setWarehouse] = useState("Central Lima");
  const [items, setItems] = useState([
    { id: "item-1", code: "", description: "", unit: "NIU", quantity: 1, price: 0 },
  ]);

  useEffect(() => {
    let active = true;
    setLoadingClients(true);
    fetchSigecoomClients()
      .then((data) => {
        if (!active) return;
        setClients(data);
        setClientsError(null);
      })
      .catch((error) => {
        if (!active) return;
        setClientsError(error instanceof Error ? error.message : "Error cargando los clientes");
      })
      .finally(() => {
        if (!active) return;
        setLoadingClients(false);
      });
    return () => { active = false; };
  }, []);

  useEffect(() => {
    let active = true;
    setLoadingSales(true);
    fetchSigecoomSales()
      .then((data) => {
        if (!active) return;
        setSales(data);
        setSalesError(null);
      })
      .catch((error) => {
        if (!active) return;
        setSalesError(error instanceof Error ? error.message : "Error cargando las ventas");
      })
      .finally(() => {
        if (!active) return;
        setLoadingSales(false);
      });
    return () => { active = false; };
  }, []);

  const selectedClient = clients.find((client) => client.id === selectedClientId);
  const lineSubtotal = items.reduce((sum, item) => sum + item.quantity * item.price, 0);
  const tax = Number((lineSubtotal * 0.18).toFixed(2));
  const total = Number((lineSubtotal + tax).toFixed(2));

  const formatCurrency = (value: number) =>
    value.toLocaleString("es-PE", { style: "currency", currency: "PEN", minimumFractionDigits: 2 });

  const updateItem = (id: string, changes: Partial<typeof items[number]>) => {
    setItems((current) => current.map((item) => item.id === id ? { ...item, ...changes } : item));
  };

  const addItem = () => {
    setItems((current) => [
      ...current,
      { id: `item-${Date.now()}`, code: "", description: "", unit: "NIU", quantity: 1, price: 0 },
    ]);
  };

  const removeItem = (id: string) => {
    setItems((current) => current.filter((item) => item.id !== id));
  };

  const canSave = Boolean(selectedClientId && items.some((item) => item.description.trim() && item.quantity > 0 && item.price > 0));

  const handleSaveBoleta = async () => {
    if (!canSave) {
      setSaveMessage("Seleccione un cliente y agregue al menos un ítem con descripción, cantidad y precio.");
      return;
    }

    setSaving(true);
    setSaveMessage(null);

    try {
      const created = await createSigecoomSale({
        type: "Boleta",
        series,
        number,
        date,
        client_id: selectedClientId,
        items: items.map((item) => ({
          code: item.code || undefined,
          description: item.description,
          unit: item.unit,
          quantity: item.quantity,
          price: item.price,
        })),
        subtotal: lineSubtotal,
        tax,
        total,
      });

      setCreatedSaleId(created.id);
      setSales((current) => [created, ...current]);
      setSaveMessage(`Boleta creada: ${created.series ?? "-"}-${created.number ?? "-"}`);
      setNumber((current) => current + 1);
      setItems([{ id: "item-1", code: "", description: "", unit: "NIU", quantity: 1, price: 0 }]);
      setSelectedClientId("");
    } catch (error) {
      setSaveMessage(error instanceof Error ? error.message : "No se pudo emitir la boleta");
    } finally {
      setSaving(false);
    }
  };

  const handleSendBoletaToSunat = async () => {
    if (!createdSaleId) {
      setSaveMessage("Guarde la boleta antes de enviar a SUNAT.");
      return;
    }

    setIssuing(true);
    setSaveMessage(null);

    try {
      const issued = await issueSigecoomSale(createdSaleId);
      setSales((current) => [issued, ...current.filter((sale) => sale.id !== issued.id)]);
      setSaveMessage(`Boleta enviada a SUNAT. Estado: ${issued.status ?? "enviado"}`);
    } catch (error) {
      setSaveMessage(error instanceof Error ? error.message : "No se pudo enviar la boleta a SUNAT");
    } finally {
      setIssuing(false);
    }
  };

  const handleSearchBoleta = () => {
    const found = sales.find((sale) => sale.series === series && sale.number === number);
    if (!found) {
      setSaveMessage("No se encontró una boleta con esa serie y número.");
      return;
    }
    setSaveMessage(`Boleta encontrada: ${found.series}-${found.number} · Estado: ${found.status ?? "pendiente"}`);
  };

  return (
    <WindowShell title="Boleta de Venta — Emisión Rápida"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSaveBoleta} disabled={saving}>
          <Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Emitir"}
        </button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
        <button className={btn} onClick={handleSendBoletaToSunat} disabled={issuing || !createdSaleId}>
          <Mail className="h-3.5 w-3.5" />{issuing ? "Enviando..." : "Enviar SUNAT"}
        </button>
        <button className={btn} onClick={handleSearchBoleta}>
          <Search className="h-3.5 w-3.5" />Buscar
        </button>
        <span className="ml-auto text-[11px] text-slate-500">Serie: <b>{series}</b> · Nº: <b>{number.toString().padStart(7, "0")}</b></span>
      </>}>
      <div className="grid grid-cols-2 gap-4">
        <div className="border border-slate-300 rounded-sm p-3 bg-white">
          <div className="text-[11px] font-semibold text-[#2A3F55] mb-2 uppercase">Datos del Cliente</div>
          <div className="grid grid-cols-3 gap-2">
            <Field label="Cliente" className="col-span-3">
              <select
                className={inp}
                value={selectedClientId}
                onChange={(event) => setSelectedClientId(event.target.value)}
              >
                <option value="">-- Seleccione cliente --</option>
                {clients.map((client) => (
                  <option key={client.id} value={client.id}>
                    {client.ruc ?? "N/A"} — {client.name}
                  </option>
                ))}
              </select>
            </Field>
            <Field label="Razón Social" className="col-span-3"><input className={inp} readOnly value={selectedClient?.name ?? ""} /></Field>
            <Field label="Dirección Fiscal" className="col-span-3"><input className={inp} readOnly value={selectedClient?.address ?? ""} /></Field>
            <Field label="Contacto" className="col-span-2"><input className={inp} readOnly value={selectedClient?.email ?? ""} /></Field>
            <Field label="Teléfono"><input className={inp} readOnly value={selectedClient?.phone ?? ""} /></Field>
            {loadingClients && <div className="col-span-3 px-2 py-2 text-xs text-slate-500">Cargando clientes...</div>}
            {clientsError && <div className="col-span-3 px-2 py-2 text-xs text-red-600">{clientsError}</div>}
          </div>
        </div>
        <div className="border border-slate-300 rounded-sm p-3 bg-white">
          <div className="text-[11px] font-semibold text-[#2A3F55] mb-2 uppercase">Condiciones</div>
          <div className="grid grid-cols-2 gap-2">
            <Field label="Moneda">
              <select className={inp} value={currency} onChange={(event) => setCurrency(event.target.value)}>
                <option value="PEN">PEN — Soles</option>
                <option value="USD">USD — Dólares</option>
              </select>
            </Field>
            <Field label="Condición de Pago">
              <select className={inp} value={paymentCondition} onChange={(event) => setPaymentCondition(event.target.value)}>
                <option>Contado</option>
                <option>Crédito 30 días</option>
                <option>Crédito 60 días</option>
              </select>
            </Field>
            <Field label="Fecha"><input className={inp} type="date" value={date} onChange={(event) => setDate(event.target.value)} /></Field>
            <Field label="Vendedor"><input className={inp} value={seller} onChange={(event) => setSeller(event.target.value)} /></Field>
            <Field label="Almacén" className="col-span-2"><input className={inp} value={warehouse} onChange={(event) => setWarehouse(event.target.value)} /></Field>
          </div>
        </div>
      </div>
      <div className="mt-4 flex items-center justify-between mb-1.5">
        <div className="text-[12px] font-semibold text-slate-700">Detalle de artículos</div>
        <div className="flex gap-1.5">
          <button type="button" className={btn} onClick={addItem}><Plus className="h-3.5 w-3.5" />Añadir ítem</button>
          <button type="button" className={btn} onClick={() => items.length > 1 && setItems(items.slice(0, -1))}><Trash2 className="h-3.5 w-3.5" />Eliminar último</button>
        </div>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA] text-slate-700">
            <tr>
              <th className="px-2 py-2 text-left border-b border-slate-300">#</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Código</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Descripción</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">U.M.</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Cant.</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">P.Unit</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Total</th>
              <th className="px-2 py-2 text-center border-b border-slate-300">Quitar</th>
            </tr>
          </thead>
          <tbody>
            {items.map((item, index) => (
              <tr key={item.id} className="odd:bg-[#FBFCFD] even:bg-white">
                <td className="px-2 py-2 border-b border-slate-200">{index + 1}</td>
                <td className="px-2 py-2 border-b border-slate-200"><input className={inp} value={item.code} onChange={(event) => updateItem(item.id, { code: event.target.value })} /></td>
                <td className="px-2 py-2 border-b border-slate-200"><input className={inp} value={item.description} onChange={(event) => updateItem(item.id, { description: event.target.value })} /></td>
                <td className="px-2 py-2 border-b border-slate-200"><input className={inp} value={item.unit} onChange={(event) => updateItem(item.id, { unit: event.target.value })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right"><input type="number" min="0" className={inp} value={item.quantity} onChange={(event) => updateItem(item.id, { quantity: Number(event.target.value) || 0 })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right"><input type="number" min="0" step="0.01" className={inp} value={item.price} onChange={(event) => updateItem(item.id, { price: Number(event.target.value) || 0 })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right">{formatCurrency(item.quantity * item.price)}</td>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><button type="button" className={btn} onClick={() => removeItem(item.id)}>✕</button></td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      <div className="mt-3 grid grid-cols-4 gap-2 max-w-md ml-auto text-[11.5px]">
        <div className="text-right text-slate-600 col-span-3">Subtotal:</div><div className="text-right font-mono">{formatCurrency(lineSubtotal)}</div>
        <div className="text-right text-slate-600 col-span-3">IGV (18%):</div><div className="text-right font-mono">{formatCurrency(tax)}</div>
        <div className="text-right font-bold text-[#2A3F55] col-span-3">TOTAL S/:</div><div className="text-right font-mono font-bold text-[#2A3F55]">{formatCurrency(total)}</div>
      </div>
      {saveMessage && <div className="mt-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{saveMessage}</div>}
      <div className="mt-6">
        <div className="flex items-center justify-between mb-2">
          <div className="text-[12px] font-semibold text-slate-700">Ventas recientes</div>
          <span className="text-[11px] text-slate-500">{sales.length} documentos cargados</span>
        </div>
        <div className="border border-slate-300 rounded-sm bg-white overflow-auto max-h-52">
          {loadingSales ? (
            <div className="px-3 py-4 text-sm text-slate-500">Cargando ventas desde el backend...</div>
          ) : salesError ? (
            <div className="px-3 py-4 text-sm text-red-600">{salesError}</div>
          ) : sales.length === 0 ? (
            <div className="px-3 py-4 text-sm text-slate-500">No hay ventas registradas.</div>
          ) : (
            <table className="w-full text-[11px] border-collapse">
              <thead className="bg-[#F3F6FA] text-slate-700">
                <tr>
                  <th className="px-2 py-2 text-left border-b border-slate-300">Tipo</th>
                  <th className="px-2 py-2 text-left border-b border-slate-300">Documento</th>
                  <th className="px-2 py-2 text-left border-b border-slate-300">Fecha</th>
                  <th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th>
                  <th className="px-2 py-2 text-right border-b border-slate-300">Total</th>
                  <th className="px-2 py-2 text-left border-b border-slate-300">Estado</th>
                </tr>
              </thead>
              <tbody>
                {sales.map((sale) => (
                  <tr key={sale.id} className="odd:bg-[#FBFCFD] even:bg-white">
                    <td className="px-2 py-2 border-b border-slate-200">{sale.type}</td>
                    <td className="px-2 py-2 border-b border-slate-200">{sale.series ?? "-"}-{sale.number ?? "-"}</td>
                    <td className="px-2 py-2 border-b border-slate-200">{new Date(sale.date).toLocaleDateString("es-PE")}</td>
                    <td className="px-2 py-2 border-b border-slate-200">{sale.client_id ?? "Cliente desconocido"}</td>
                    <td className="px-2 py-2 border-b border-slate-200 text-right">{formatCurrency(sale.total)}</td>
                    <td className="px-2 py-2 border-b border-slate-200">{sale.status}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </div>
      </div>
    </WindowShell>
  );
}

function ResumenBoletas() {
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [sales, setSales] = useState<SigecoomSale[]>([]);
  const [loadingSales, setLoadingSales] = useState(false);
  const [sending, setSending] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const handleLoadSales = async () => {
    setLoadingSales(true);
    try {
      const allSales = await fetchSigecoomSales();
      const filtered = allSales.filter((s) => s.type === "Boleta" && s.date.startsWith(date));
      setSales(filtered);
      setMessage(`${filtered.length} boletas cargadas para ${date}`);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error al cargar boletas");
    } finally {
      setLoadingSales(false);
    }
  };

  const handleSendSunat = async () => {
    if (sales.length === 0) {
      setMessage("No hay boletas para enviar.");
      return;
    }
    setSending(true);
    try {
      const issuedList = [] as SigecoomSale[];
      for (const sale of sales) {
        if (sale.id && sale.status === "draft") {
          const issued = await issueSigecoomSale(sale.id);
          issuedList.push(issued);
        } else {
          issuedList.push(sale);
        }
      }
      setSales(issuedList);
      setMessage(`Resumen de ${issuedList.length} boletas enviado a SUNAT. Estado actualizado.`);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error al enviar");
    } finally {
      setSending(false);
    }
  };

  const totalBase = sales.reduce((sum, s) => sum + (s.subtotal || 0), 0);
  const totalTax = sales.reduce((sum, s) => sum + (s.tax || 0), 0);
  const totalAmount = sales.reduce((sum, s) => sum + s.total, 0);

  const formatCurrency = (v: number) => v.toLocaleString("es-PE", { style: "currency", currency: "PEN", minimumFractionDigits: 2 });

  return (
    <WindowShell title="Resumen Diario de Boletas"
      toolbar={<>
        <Field label="Fecha"><input className={inp} type="date" value={date} onChange={(e) => setDate(e.target.value)} /></Field>
        <button className={btn} onClick={handleLoadSales} disabled={loadingSales}><RefreshCw className="h-3.5 w-3.5" />{loadingSales ? "Cargando..." : "Cargar"}</button>
        <button className={btnPrimary} onClick={handleSendSunat} disabled={sending || sales.length === 0}><Send className="h-3.5 w-3.5" />{sending ? "Enviando..." : "Enviar Resumen SUNAT"}</button>
        <span className="ml-auto text-[11px] text-slate-500">Boletas: <b>{sales.length}</b> · Estado: <b className={sales.length > 0 ? "text-emerald-700" : "text-slate-500"}>{sales.length > 0 ? "Listo" : "Vacío"}</b></span>
      </>}>
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        {sales.length === 0 ? (
          <div className="p-4 text-sm text-slate-500">Seleccione fecha y haga clic en "Cargar" para ver boletas del día.</div>
        ) : (
          <table className="w-full text-[11px] border-collapse">
            <thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">#</th><th className="px-2 py-2 text-left border-b border-slate-300">Serie</th><th className="px-2 py-2 text-left border-b border-slate-300">Número</th><th className="px-2 py-2 text-left border-b border-slate-300">Fecha</th><th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th><th className="px-2 py-2 text-right border-b border-slate-300">Base</th><th className="px-2 py-2 text-right border-b border-slate-300">IGV</th><th className="px-2 py-2 text-right border-b border-slate-300">Total</th><th className="px-2 py-2 text-left border-b border-slate-300">Estado</th></tr></thead>
            <tbody>
              {sales.map((s, idx) => (
                <tr key={s.id} className="odd:bg-[#FBFCFD] even:bg-white">
                  <td className="px-2 py-2 border-b border-slate-200">{idx + 1}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{s.series || "-"}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{String(s.number).padStart(7, "0")}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{new Date(s.date).toLocaleDateString("es-PE")}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{s.client_id || "Desconocido"}</td>
                  <td className="px-2 py-2 border-b border-slate-200 text-right">{formatCurrency(s.subtotal || 0)}</td>
                  <td className="px-2 py-2 border-b border-slate-200 text-right">{formatCurrency(s.tax || 0)}</td>
                  <td className="px-2 py-2 border-b border-slate-200 text-right font-semibold">{formatCurrency(s.total)}</td>
                  <td className="px-2 py-2 border-b border-slate-200"><span className="px-2 py-0.5 bg-slate-100 rounded text-xs">{s.status}</span></td>
                </tr>
              ))}
            </tbody>
            <tfoot className="bg-slate-50 font-semibold text-[11px]">
              <tr>
                <td colSpan={5} className="px-2 py-2 text-right border-t border-slate-300">TOTALES:</td>
                <td className="px-2 py-2 border-t border-slate-300 text-right">{formatCurrency(totalBase)}</td>
                <td className="px-2 py-2 border-t border-slate-300 text-right">{formatCurrency(totalTax)}</td>
                <td className="px-2 py-2 border-t border-slate-300 text-right">{formatCurrency(totalAmount)}</td>
                <td className="px-2 py-2 border-t border-slate-300"></td>
              </tr>
            </tfoot>
          </table>
        )}
      </div>
    </WindowShell>
  );
}

// ---------- Ventas: Pre y Post ----------
function Cotizaciones() {
  const [clientName, setClientName] = useState("");
  const [email, setEmail] = useState("");
  const [phone, setPhone] = useState("");
  const [validity, setValidity] = useState("15");
  const [items, setItems] = useState([{ id: "item-1", code: "", description: "", quantity: 1, price: 0, discount: 0 }]);
  const [saving, setSaving] = useState(false);
  const [savingEmail, setSavingEmail] = useState(false);
  const [converting, setConverting] = useState(false);
  const [saveMessage, setSaveMessage] = useState<string | null>(null);

  const lineSubtotal = items.reduce((sum, item) => sum + (item.quantity * item.price * (1 - item.discount / 100)), 0);
  const tax = Number((lineSubtotal * 0.18).toFixed(2));
  const total = Number((lineSubtotal + tax).toFixed(2));

  const formatCurrency = (v: number) => v.toLocaleString("es-PE", { style: "currency", currency: "PEN", minimumFractionDigits: 2 });

  const updateItem = (id: string, changes: Partial<typeof items[number]>) => {
    setItems((current) => current.map((item) => item.id === id ? { ...item, ...changes } : item));
  };

  const addItem = () => {
    setItems((current) => [...current, { id: `item-${Date.now()}`, code: "", description: "", quantity: 1, price: 0, discount: 0 }]);
  };

  const removeItem = (id: string) => {
    setItems((current) => current.filter((item) => item.id !== id));
  };

  const canSave = Boolean(clientName.trim() && items.some((item) => item.description.trim() && item.quantity > 0 && item.price > 0));

  const handleSave = async () => {
    if (!canSave) {
      setSaveMessage("Complete cliente y agregue al menos un ítem.");
      return;
    }
    setSaving(true);
    try {
      await createSigecoomSale({
        type: "Cotización",
        series: "COT001",
        number: Math.floor(Math.random() * 10000),
        date: new Date().toISOString().slice(0, 10),
        client_id: clientName,
        items: items.map((item) => ({
          code: item.code || undefined,
          description: item.description,
          unit: "unidad",
          quantity: item.quantity,
          price: item.price,
        })),
        subtotal: lineSubtotal,
        tax,
        total,
      });
      setSaveMessage(`Cotización guardada para ${clientName} - Válida por ${validity} días`);
      setClientName("");
      setEmail("");
      setPhone("");
      setItems([{ id: "item-1", code: "", description: "", quantity: 1, price: 0, discount: 0 }]);
    } catch (error) {
      setSaveMessage(error instanceof Error ? error.message : "Error al guardar");
    } finally {
      setSaving(false);
    }
  };

  const handleSendEmail = async () => {
    if (!email.trim()) {
      setSaveMessage("Ingrese correo electrónico para enviar la cotización.");
      return;
    }
    setSavingEmail(true);
    try {
      setSaveMessage(`Cotización enviada a ${email} (simulado)`);
    } catch (error) {
      setSaveMessage(error instanceof Error ? error.message : "Error al enviar correo");
    } finally {
      setSavingEmail(false);
    }
  };

  const handleConvertToFactura = async () => {
    if (!canSave) {
      setSaveMessage("Complete cliente y agregue al menos un ítem antes de convertir a factura.");
      return;
    }
    setConverting(true);
    try {
      await createSigecoomSale({
        type: "Factura",
        series: "F001",
        number: Math.floor(Math.random() * 10000),
        date: new Date().toISOString().slice(0, 10),
        client_id: clientName,
        items: items.map((item) => ({
          code: item.code || undefined,
          description: item.description,
          unit: "unidad",
          quantity: item.quantity,
          price: item.price,
        })),
        subtotal: lineSubtotal,
        tax,
        total,
      });
      setSaveMessage(`Cotización convertida a factura para ${clientName}`);
    } catch (error) {
      setSaveMessage(error instanceof Error ? error.message : "Error al convertir a factura");
    } finally {
      setConverting(false);
    }
  };

  return (
    <WindowShell title="Cotización / Proforma"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSave} disabled={saving}><Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Guardar"}</button>
        <button className={btn}><FileDown className="h-3.5 w-3.5" />PDF</button>
        <button className={btn} onClick={handleSendEmail} disabled={savingEmail}><Mail className="h-3.5 w-3.5" />{savingEmail ? "Enviando..." : "Enviar por correo"}</button>
        <button className={`${btn} border-emerald-700 text-emerald-800`} onClick={handleConvertToFactura} disabled={converting}>{converting ? "Convirtiendo..." : "→ Convertir a Factura"}</button>
      </>}>
      <div className="grid grid-cols-3 gap-3 mb-4">
        <Field label="Cliente Potencial" className="col-span-2"><input className={inp} value={clientName} onChange={(e) => setClientName(e.target.value)} /></Field>
        <Field label="Validez (días)"><input className={inp} type="number" value={validity} onChange={(e) => setValidity(e.target.value)} /></Field>
        <Field label="Correo"><input className={inp} type="email" value={email} onChange={(e) => setEmail(e.target.value)} /></Field>
        <Field label="Teléfono" className="col-span-2"><input className={inp} value={phone} onChange={(e) => setPhone(e.target.value)} /></Field>
      </div>
      <div className="flex items-center justify-between mb-1.5"><div className="text-[12px] font-semibold text-slate-700">Ítems</div><div className="flex gap-1.5"><button type="button" className={btn} onClick={addItem}><Plus className="h-3.5 w-3.5" />Añadir</button><button type="button" className={btn} onClick={() => items.length > 1 && removeItem(items[items.length - 1].id)}><Trash2 className="h-3.5 w-3.5" />Quitar</button></div></div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]">
            <tr>
              <th className="px-2 py-2 text-left border-b border-slate-300">#</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Código</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Descripción</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Cant.</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">P.Unit</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Desc.%</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Total</th>
              <th className="px-2 py-2 text-center border-b border-slate-300">Quitar</th>
            </tr>
          </thead>
          <tbody>
            {items.map((item, idx) => (
              <tr key={item.id} className="odd:bg-[#FBFCFD] even:bg-white">
                <td className="px-2 py-2 border-b border-slate-200">{idx + 1}</td>
                <td className="px-2 py-2 border-b border-slate-200"><input className={inp} value={item.code} onChange={(e) => updateItem(item.id, { code: e.target.value })} /></td>
                <td className="px-2 py-2 border-b border-slate-200"><input className={inp} value={item.description} onChange={(e) => updateItem(item.id, { description: e.target.value })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right"><input type="number" min="0" className={inp} value={item.quantity} onChange={(e) => updateItem(item.id, { quantity: Number(e.target.value) || 0 })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right"><input type="number" min="0" step="0.01" className={inp} value={item.price} onChange={(e) => updateItem(item.id, { price: Number(e.target.value) || 0 })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right"><input type="number" min="0" max="100" className={inp} value={item.discount} onChange={(e) => updateItem(item.id, { discount: Number(e.target.value) || 0 })} /></td>
                <td className="px-2 py-2 border-b border-slate-200 text-right">{formatCurrency(item.quantity * item.price * (1 - item.discount / 100))}</td>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><button type="button" className={btn} onClick={() => removeItem(item.id)}>✕</button></td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      <div className="mt-3 grid grid-cols-4 gap-2 max-w-xs ml-auto text-[11.5px]">
        <div className="text-right text-slate-600 col-span-3">Subtotal:</div><div className="text-right font-mono">{formatCurrency(lineSubtotal)}</div>
        <div className="text-right text-slate-600 col-span-3">IGV (18%):</div><div className="text-right font-mono">{formatCurrency(tax)}</div>
        <div className="text-right font-bold text-[#2A3F55] col-span-3">TOTAL S/:</div><div className="text-right font-mono font-bold">{formatCurrency(total)}</div>
      </div>
      {saveMessage && <div className="mt-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{saveMessage}</div>}
    </WindowShell>
  );
}

function ReclamoGarantia() {
  const [clientName, setClientName] = useState("");
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [product, setProduct] = useState("");
  const [serial, setSerial] = useState("");
  const [status, setStatus] = useState("Recibido");
  const [description, setDescription] = useState("");
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const handleSave = async () => {
    if (!clientName.trim() || !product.trim()) {
      setMessage("Complete cliente y producto.");
      return;
    }
    setSaving(true);
    try {
      await createSigecoomSale({
        type: "Reclamo Garantía",
        series: "RG001",
        number: Math.floor(Math.random() * 10000),
        date,
        client_id: clientName,
        items: [{ description: `${product} (SN: ${serial}) - ${description}`, unit: "unidad", quantity: 1, price: 0 }],
        subtotal: 0,
        tax: 0,
        total: 0,
      });
      setMessage(`Reclamo registrado para ${clientName}`);
      setClientName("");
      setProduct("");
      setSerial("");
      setDescription("");
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error al registrar");
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Reclamo por Garantía"
      toolbar={<><button className={btnPrimary} onClick={handleSave} disabled={saving}><Save className="h-3.5 w-3.5" />{saving ? "Registrando..." : "Registrar"}</button></>}>
      <div className="grid grid-cols-3 gap-3">
        <Field label="Cliente" className="col-span-2"><input className={inp} value={clientName} onChange={(e) => setClientName(e.target.value)} /></Field>
        <Field label="Fecha Reclamo"><input className={inp} type="date" value={date} onChange={(e) => setDate(e.target.value)} /></Field>
        <Field label="Producto" className="col-span-2"><input className={inp} value={product} onChange={(e) => setProduct(e.target.value)} /></Field>
        <Field label="Nº Serie"><input className={inp} value={serial} onChange={(e) => setSerial(e.target.value)} /></Field>
        <Field label="Estado" className="col-span-2"><select className={inp} value={status} onChange={(e) => setStatus(e.target.value)}><option>Recibido</option><option>En evaluación</option><option>Procedente</option><option>Improcedente</option></select></Field>
        <Field label="Descripción del fallo" className="col-span-3"><textarea className={`${inp} h-20 py-1`} value={description} onChange={(e) => setDescription(e.target.value)} /></Field>
      </div>
      {message && <div className="mt-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
    </WindowShell>
  );
}

function SepararOrden() {
  const [clientName, setClientName] = useState("");
  const [deposit, setDeposit] = useState(0);
  const [validityDate, setValidityDate] = useState(() => new Date(Date.now() + 30 * 24 * 60 * 60 * 1000).toISOString().slice(0, 10));
  const [seller, setSeller] = useState("grios");
  const [notes, setNotes] = useState("");
  const [items, setItems] = useState([{ id: "item-1", product: "", quantity: 1, price: 0 }]);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const updateItem = (id: string, changes: Partial<typeof items[number]>) => {
    setItems((current) => current.map((item) => item.id === id ? { ...item, ...changes } : item));
  };

  const handleSave = async () => {
    if (!clientName.trim()) {
      setMessage("Ingrese cliente.");
      return;
    }
    setSaving(true);
    try {
      await createSigecoomSale({
        type: "Separar Orden",
        series: "SEP001",
        number: Math.floor(Math.random() * 10000),
        client_id: clientName,
        date: new Date().toISOString().slice(0, 10),
        items: items.map((item) => ({
          description: `${item.product} (Depositado: ${item.price})`,
          unit: "unidad",
          quantity: item.quantity,
          price: item.price,
        })),
        subtotal: deposit,
        tax: 0,
        total: deposit,
      });
      setMessage(`Orden separada para ${clientName} - Vigencia hasta ${validityDate}`);
      setClientName("");
      setDeposit(0);
      setNotes("");
      setItems([{ id: "item-1", product: "", quantity: 1, price: 0 }]);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error al reservar");
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Separar Orden — Reserva de Stock"
      toolbar={<><button className={btnPrimary} onClick={handleSave} disabled={saving}><Save className="h-3.5 w-3.5" />{saving ? "Reservando..." : "Reservar"}</button></>}>
      <div className="grid grid-cols-3 gap-3 max-w-2xl">
        <Field label="Cliente" className="col-span-2"><input className={inp} value={clientName} onChange={(e) => setClientName(e.target.value)} /></Field>
        <Field label="Adelanto S/"><input className={inp} type="number" value={deposit} onChange={(e) => setDeposit(Number(e.target.value))} /></Field>
        <Field label="Vigencia Reserva"><input className={inp} type="date" value={validityDate} onChange={(e) => setValidityDate(e.target.value)} /></Field>
        <Field label="Vendedor" className="col-span-2"><select className={inp} value={seller} onChange={(e) => setSeller(e.target.value)}><option>grios</option><option>mlopez</option></select></Field>
        <Field label="Observaciones" className="col-span-3"><input className={inp} value={notes} onChange={(e) => setNotes(e.target.value)} /></Field>
      </div>
      {message && <div className="mt-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
    </WindowShell>
  );
}

function OrdenesCompra() {
  const [orders, setOrders] = useState<SigecoomSale[]>([]);
  const [filter, setFilter] = useState("");
  const [loadingOrders, setLoadingOrders] = useState(true);
  const [ordersError, setOrdersError] = useState<string | null>(null);
  const [creating, setCreating] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const loadOrders = async () => {
    setLoadingOrders(true);
    try {
      const data = await fetchSigecoomSales();
      setOrders(data.filter((sale) => sale.type.toLowerCase().includes("orden")));
      setOrdersError(null);
    } catch (error) {
      setOrdersError(error instanceof Error ? error.message : "Error cargando órdenes de compra");
    } finally {
      setLoadingOrders(false);
    }
  };

  useEffect(() => {
    let active = true;
    if (!active) return;
    loadOrders();
    return () => { active = false; };
  }, []);

  const handleRefresh = () => loadOrders();

  const handleCreateOrder = async () => {
    setCreating(true);
    try {
      const created = await createSigecoomSale({
        type: "Orden Compra",
        series: "OC001",
        number: Math.floor(Math.random() * 10000),
        date: new Date().toISOString().slice(0, 10),
        client_id: "Cliente Genérico",
        items: [{ description: "Orden de compra generada desde escritorio", unit: "unidad", quantity: 1, price: 0 }],
        subtotal: 0,
        tax: 0,
        total: 0,
      });
      setOrders((current) => [created, ...current]);
      setMessage(`Orden creada: ${created.series}-${created.number}`);
      setOrdersError(null);
    } catch (error) {
      setOrdersError(error instanceof Error ? error.message : "No se pudo crear la orden");
    } finally {
      setCreating(false);
    }
  };

  const filteredOrders = orders.filter((order) => {
    const needle = filter.trim().toLowerCase();
    if (!needle) return true;
    return [order.series, order.number?.toString(), order.client_id, order.type, order.status]
      .some((value) => value?.toString().toLowerCase().includes(needle));
  });

  return (
    <WindowShell title="Órdenes de Compra recibidas de Clientes"
      toolbar={<>
        <input className={`${inp} w-48`} placeholder="Filtrar OC..." value={filter} onChange={(e) => setFilter(e.target.value)} />
        <button className={btn} onClick={handleRefresh} disabled={loadingOrders}><RefreshCw className="h-3.5 w-3.5" />{loadingOrders ? "Cargando..." : "Actualizar"}</button>
        <button className={btn} onClick={handleCreateOrder} disabled={creating}><Plus className="h-3.5 w-3.5" />{creating ? "Creando..." : "Registrar OC"}</button>
      </>}>
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">OC N°</th><th className="px-2 py-2 text-left border-b border-slate-300">Fecha</th><th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th><th className="px-2 py-2 text-left border-b border-slate-300">Referencia</th><th className="px-2 py-2 text-right border-b border-slate-300">Monto</th><th className="px-2 py-2 text-left border-b border-slate-300">Estado</th><th className="px-2 py-2 text-left border-b border-slate-300">Tipo</th></tr></thead>
          <tbody>
            {filteredOrders.length === 0 ? (
              <tr><td colSpan={7} className="px-2 py-4 text-sm text-slate-500">No hay órdenes de compra registradas.</td></tr>
            ) : filteredOrders.map((order) => (
              <tr key={order.id} className="hover:bg-slate-50">
                <td className="px-2 py-2 border-b border-slate-200">{order.series}-{order.number}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.date}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.client_id}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.items[0]?.description ?? "-"}</td>
                <td className="px-2 py-2 text-right border-b border-slate-200">{order.total.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.status}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.type}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      {ordersError && <div className="mt-3 rounded-sm border border-red-300 bg-red-50 px-3 py-2 text-sm text-red-700">{ordersError}</div>}
    </WindowShell>
  );
}

function ActualizarVendedor() {
  const [sourceVendor, setSourceVendor] = useState("grios");
  const [destVendor, setDestVendor] = useState("mlopez");
  const [scope, setScope] = useState("Cartera de clientes");
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const handleReassign = async () => {
    setSaving(true);
    try {
      setMessage(`Reasignación completada: ${scope} de ${sourceVendor} → ${destVendor}`);
      setSourceVendor("grios");
      setDestVendor("mlopez");
    } catch (error) {
      setMessage("Error en reasignación");
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Actualizar Vendedor — Reasignación"
      toolbar={<><button className={btnPrimary} onClick={handleReassign} disabled={saving}><Save className="h-3.5 w-3.5" />{saving ? "Reasignando..." : "Reasignar"}</button></>}>
      <div className="grid grid-cols-2 gap-3 max-w-lg">
        <Field label="Vendedor Origen"><select className={inp} value={sourceVendor} onChange={(e) => setSourceVendor(e.target.value)}><option>grios</option><option>mlopez</option></select></Field>
        <Field label="Vendedor Destino"><select className={inp} value={destVendor} onChange={(e) => setDestVendor(e.target.value)}><option>mlopez</option><option>jperez</option></select></Field>
        <Field label="Alcance" className="col-span-2"><select className={inp} value={scope} onChange={(e) => setScope(e.target.value)}><option>Cartera de clientes</option><option>Documentos pendientes</option><option>Ambos</option></select></Field>
      </div>
      {message && <div className="mt-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
    </WindowShell>
  );
}

function EnviarCorreos() {
  const [docType, setDocType] = useState("Factura");
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [status, setStatus] = useState("Todos");
  const [sending, setSending] = useState(false);
  const [documents, setDocuments] = useState<SigecoomSale[]>([]);
  const [clients, setClients] = useState<SigecoomClient[]>([]);
  const [loadingDocs, setLoadingDocs] = useState(true);
  const [docsError, setDocsError] = useState<string | null>(null);
  const [message, setMessage] = useState<string | null>(null);

  const loadDocuments = async () => {
    setLoadingDocs(true);
    try {
      const [salesData, clientsData] = await Promise.all([fetchSigecoomSales(), fetchSigecoomClients()]);
      setClients(clientsData);
      setDocuments(salesData.filter((sale) => sale.type.toLowerCase().includes(docType.toLowerCase())));
      setDocsError(null);
    } catch (error) {
      setDocsError(error instanceof Error ? error.message : "Error cargando comprobantes");
    } finally {
      setLoadingDocs(false);
    }
  };

  useEffect(() => {
    loadDocuments();
  }, [docType]);

  const getStatusText = (sale: SigecoomSale) => {
    return sale.status || "Pendiente";
  };

  const resolveRecipient = (sale: SigecoomSale) => {
    const match = clients.find((client) => client.id === sale.client_id || client.name === sale.client_id);
    if (match?.email) return match.email;
    return sale.client_id && sale.client_id.includes("@") ? sale.client_id : "sin correo";
  };

  const handleSend = async () => {
    if (!fromDate || !toDate) {
      setMessage("Seleccione rango de fechas.");
      return;
    }
    setSending(true);
    setMessage(null);
    try {
      const toSend = documents.filter((doc) => {
        const issueDate = new Date(doc.date);
        const start = new Date(fromDate);
        const end = new Date(toDate);
        return issueDate >= start && issueDate <= end &&
          (status === "Todos" || getStatusText(doc).toLowerCase().includes(status.toLowerCase()));
      });

      const sentDocs = [] as SigecoomSale[];
      for (const doc of toSend) {
        const recipient = resolveRecipient(doc);
        if (recipient === "sin correo") {
          continue;
        }
        const updated = await sendSigecoomSaleEmail(doc.id, recipient);
        sentDocs.push(updated);
      }

      setDocuments((current) => current.map((doc) => {
        const updated = sentDocs.find((updatedDoc) => updatedDoc.id === doc.id);
        return updated ?? doc;
      }));

      setMessage(`Se enviaron ${sentDocs.length} comprobantes por correo.`);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error al enviar");
    } finally {
      setSending(false);
    }
  };

  const handleRefresh = async () => {
    await loadDocuments();
    setMessage("Documentos actualizados.");
  };

  return (
    <WindowShell title="Envío masivo de comprobantes"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSend} disabled={sending || loadingDocs}><Send className="h-3.5 w-3.5" />{sending ? "Enviando..." : "Enviar seleccionados"}</button>
        <button className={btn} onClick={handleRefresh} disabled={loadingDocs}><RefreshCw className="h-3.5 w-3.5" />{loadingDocs ? "Cargando..." : "Actualizar"}</button>
      </>}>
      <div className="grid grid-cols-4 gap-2 mb-3">
        <Field label="Tipo Doc."><select className={inp} value={docType} onChange={(e) => setDocType(e.target.value)}><option>Factura</option><option>Boleta</option><option>Cotización</option></select></Field>
        <Field label="Desde"><input className={inp} type="date" value={fromDate} onChange={(e) => setFromDate(e.target.value)} /></Field>
        <Field label="Hasta"><input className={inp} type="date" value={toDate} onChange={(e) => setToDate(e.target.value)} /></Field>
        <Field label="Estado"><select className={inp} value={status} onChange={(e) => setStatus(e.target.value)}><option>Todos</option><option>Pendiente</option><option>Enviado</option></select></Field>
      </div>
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-center border-b border-slate-300">✓</th><th className="px-2 py-2 text-left border-b border-slate-300">Doc.</th><th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th><th className="px-2 py-2 text-left border-b border-slate-300">Correo</th><th className="px-2 py-2 text-left border-b border-slate-300">Fecha Emisión</th><th className="px-2 py-2 text-left border-b border-slate-300">Estado envío</th></tr></thead>
          <tbody>
            {documents.length === 0 ? (
              <tr><td colSpan={6} className="px-2 py-4 text-sm text-slate-500">No hay comprobantes para enviar.</td></tr>
            ) : documents.map((doc) => (
              <tr key={doc.id} className="hover:bg-slate-50">
                <td className="px-2 py-2 border-b border-slate-200 text-center">✓</td>
                <td className="px-2 py-2 border-b border-slate-200">{doc.series}-{doc.number}</td>
                <td className="px-2 py-2 border-b border-slate-200">{doc.client_id}</td>
                <td className="px-2 py-2 border-b border-slate-200">{resolveRecipient(doc)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{doc.date}</td>
                <td className="px-2 py-2 border-b border-slate-200">{getStatusText(doc)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      {docsError && <div className="mt-3 rounded-sm border border-red-300 bg-red-50 px-3 py-2 text-sm text-red-700">{docsError}</div>}
    </WindowShell>
  );
}

// ---------- Clientes / Requisiciones ----------
function Cartera() {
  const [clients, setClients] = useState<SigecoomClient[]>([]);
  const [filter, setFilter] = useState("");
  const [loadingClients, setLoadingClients] = useState(true);
  const [clientsError, setClientsError] = useState<string | null>(null);

  useEffect(() => {
    let active = true;
    setLoadingClients(true);
    fetchSigecoomClients()
      .then((data) => {
        if (!active) return;
        setClients(data);
        setClientsError(null);
      })
      .catch((error) => {
        if (!active) return;
        setClientsError(error instanceof Error ? error.message : "Error cargando los clientes");
      })
      .finally(() => {
        if (!active) return;
        setLoadingClients(false);
      });
    return () => {
      active = false;
    };
  }, []);

  const filteredClients = clients.filter((client) => {
    const term = filter.trim().toLowerCase();
    if (!term) return true;
    return [client.name, client.ruc, client.phone, client.email, client.address]
      .some((value) => value?.toLowerCase().includes(term));
  });

  const total = clients.length;
  const activeCount = clients.filter((client) => client.active === 1).length;

  return (
    <WindowShell title="Cartera de Clientes"
      toolbar={<>
        <input
          className={`${inp} w-64`}
          placeholder="Buscar cliente por RUC o nombre..."
          value={filter}
          onChange={(event) => setFilter(event.target.value)}
        />
        <button className={btn} onClick={() => {}}><Search className="h-3.5 w-3.5" />Filtrar</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Exportar</button>
        <span className="ml-auto text-[11px] text-slate-500 flex gap-3">
          <span><User className="inline h-3 w-3" /> Total: <b>{total}</b></span>
          <span className="text-emerald-700">Activos: <b>{activeCount}</b></span>
          <span className="text-red-700">Inactivos: <b>{total - activeCount}</b></span>
        </span>
      </>}>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        {loadingClients ? (
          <div className="p-4 text-sm text-slate-500">Cargando clientes desde el backend...</div>
        ) : clientsError ? (
          <div className="p-4 text-sm text-red-600">{clientsError}</div>
        ) : filteredClients.length === 0 ? (
          <div className="p-4 text-sm text-slate-500">No se encontraron clientes.</div>
        ) : (
          <table className="w-full text-[11px] border-collapse">
            <thead className="bg-[#F3F6FA] text-slate-700">
              <tr>
                <th className="px-2 py-2 text-left border-b border-slate-300">RUC/DNI</th>
                <th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th>
                <th className="px-2 py-2 text-left border-b border-slate-300">Teléfono</th>
                <th className="px-2 py-2 text-left border-b border-slate-300">Dirección</th>
                <th className="px-2 py-2 text-left border-b border-slate-300">Estado</th>
              </tr>
            </thead>
            <tbody>
              {filteredClients.map((client) => (
                <tr key={client.id} className="odd:bg-[#FBFCFD] even:bg-white">
                  <td className="px-2 py-2 border-b border-slate-200">{client.ruc ?? "—"}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{client.name}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{client.phone ?? "—"}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{client.address ?? "—"}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{client.active === 1 ? "Activo" : "Inactivo"}</td>
                </tr>
              ))}
            </tbody>
          </table>
        )}
      </div>
    </WindowShell>
  );
}

function Despacho() {
  const [warehouse, setWarehouse] = useState("Todos");
  const [paymentStatus, setPaymentStatus] = useState("Pagado");
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [sales, setSales] = useState<SigecoomSale[]>([]);
  const [loadingSales, setLoadingSales] = useState(true);
  const [salesError, setSalesError] = useState<string | null>(null);
  const [selectedOrderId, setSelectedOrderId] = useState<string>("");
  const [statusMessage, setStatusMessage] = useState<string | null>(null);
  const [actionLoading, setActionLoading] = useState(false);

  useEffect(() => {
    let active = true;
    setLoadingSales(true);
    fetchSigecoomSales()
      .then((data) => {
        if (!active) return;
        setSales(data);
        setSalesError(null);
      })
      .catch((error) => {
        if (!active) return;
        setSalesError(error instanceof Error ? error.message : "Error cargando las órdenes de despacho");
      })
      .finally(() => {
        if (!active) return;
        setLoadingSales(false);
      });

    return () => { active = false; };
  }, []);

  const handleAuthorize = async () => {
    if (!selectedOrderId) {
      setStatusMessage("Seleccione un pedido antes de autorizar.");
      return;
    }
    setActionLoading(true);
    setStatusMessage(null);
    try {
      const updated = await updateSigecoomSale(selectedOrderId, { status: "authorized" });
      setSales((current) => current.map((sale) => sale.id === updated.id ? updated : sale));
      setStatusMessage(`Pedido ${updated.series}-${updated.number} autorizado.`);
    } catch (error) {
      setStatusMessage(error instanceof Error ? error.message : "No se pudo autorizar el despacho.");
    } finally {
      setActionLoading(false);
    }
  };

  const handleReject = async () => {
    if (!selectedOrderId) {
      setStatusMessage("Seleccione un pedido antes de rechazar.");
      return;
    }
    setActionLoading(true);
    setStatusMessage(null);
    try {
      const updated = await updateSigecoomSale(selectedOrderId, { status: "rejected" });
      setSales((current) => current.map((sale) => sale.id === updated.id ? updated : sale));
      setStatusMessage(`Pedido ${updated.series}-${updated.number} rechazado.`);
    } catch (error) {
      setStatusMessage(error instanceof Error ? error.message : "No se pudo rechazar el despacho.");
    } finally {
      setActionLoading(false);
    }
  };

  return (
    <WindowShell title="Autorización de Despacho"
      toolbar={<>
        <button className={btnPrimary} onClick={handleAuthorize} disabled={actionLoading}>
          ✓ Autorizar
        </button>
        <button className={btn} onClick={handleReject} disabled={actionLoading}>
          ✗ Rechazar
        </button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir G/R</button>
      </>}>
      <div className="grid grid-cols-4 gap-2 mb-3">
        <Field label="Almacén"><select className={inp} value={warehouse} onChange={(e) => setWarehouse(e.target.value)}><option>Todos</option><option>Central Lima</option><option>Almacén Norte</option></select></Field>
        <Field label="Pedido" className="col-span-2">
          <select className={inp} value={selectedOrderId} onChange={(e) => setSelectedOrderId(e.target.value)}>
            <option value="">-- Seleccione pedido --</option>
            {sales.map((sale) => (
              <option key={sale.id} value={sale.id}>
                {sale.series}-{sale.number?.toString().padStart(7, "0")} · {sale.client_id}
              </option>
            ))}
          </select>
        </Field>
        <Field label="Estado Pago"><select className={inp} value={paymentStatus} onChange={(e) => setPaymentStatus(e.target.value)}><option>Pagado</option><option>Con adelanto</option></select></Field>
        <Field label="Desde"><input className={inp} type="date" value={fromDate} onChange={(e) => setFromDate(e.target.value)} /></Field>
        <Field label="Hasta"><input className={inp} type="date" value={toDate} onChange={(e) => setToDate(e.target.value)} /></Field>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto"><table className="w-full text-[11px] border-collapse"><thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">Pedido</th><th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th><th className="px-2 py-2 text-left border-b border-slate-300">Fecha</th><th className="px-2 py-2 text-right border-b border-slate-300">Monto</th><th className="px-2 py-2 text-left border-b border-slate-300">Pago</th><th className="px-2 py-2 text-left border-b border-slate-300">Almacén</th><th className="px-2 py-2 text-left border-b border-slate-300">Estado</th><th className="px-2 py-2 text-left border-b border-slate-300">Transporte</th></tr></thead><tbody><tr><td colSpan={8} className="px-2 py-4 text-sm text-slate-500">No hay órdenes listas para despacho.</td></tr></tbody></table></div>
    </WindowShell>
  );
}

// ---------- Precios ----------
function PreciosManager({ initial }: { initial: string }) {
  const [tab, setTab] = useState(initial);
  const tabs = ["Precios Cliente", "Precio Oferta", "Factores Rubros", "Precio Lista", "Precio Fabricantes"];
  return (
    <WindowShell title="Gestor Maestro de Precios y Tarifas"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar cambios</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nuevo</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Importar Excel</button>
      </>}>
      <div className="flex gap-0.5 border-b border-slate-400/60 -mx-3 px-3">
        {tabs.map(t => (
          <button key={t} onClick={() => setTab(t)} className={[
            "px-3 py-1 text-[11.5px] rounded-t border-x border-t",
            tab === t ? "bg-white border-slate-400/60 text-[#2A3F55] font-semibold -mb-px" : "bg-transparent border-transparent text-slate-600 hover:bg-white/60",
          ].join(" ")}>{t}</button>
        ))}
      </div>
      <div className="mt-3">
        <div className="text-[11px] text-slate-600 mb-2">Editando: <b className="text-[#2A3F55]">{tab}</b></div>
        {tab === "Factores Rubros"
          ? <DataTable columns={["Rubro", "Margen %", "Descuento Máx %", "Vigencia"]} rows={6} />
          : <DataTable columns={["Código", "Producto", "Rubro", "Costo", "Precio", "Margen %", "Moneda", "Vigencia"]} rows={8} />}
      </div>
    </WindowShell>
  );
}

// ---------- Contenedor de Reportes ----------
function ReporteContainer({ label }: { label: string }) {
  return (
    <WindowShell title={`Reporte — ${label}`}
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <Field label=""><input className={inp} type="date" /></Field>
        <span className="text-[11px] text-slate-500">a</span>
        <Field label=""><input className={inp} type="date" /></Field>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
        <div className="ml-auto flex gap-1.5">
          <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
          <button className={btn}><FileDown className="h-3.5 w-3.5" />PDF</button>
          <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
        </div>
      </>}>
      <div className="text-[11px] text-slate-500 mb-2">
        Filtro pre-seleccionado: <b className="text-[#2A3F55]">{label}</b>
      </div>
      <DataTable columns={["#", "Fecha", "Documento", "Cliente / Ref.", "Vendedor", "Moneda", "Base", "IGV", "Total"]} rows={10} />
    </WindowShell>
  );
}

// ---------- Placeholder genérico ----------
function GenericWindow({ label }: { label: string }) {
  return (
    <WindowShell title={label}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Search className="h-3.5 w-3.5" />Buscar</button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
      </>}>
      <div className="border border-dashed border-slate-400 rounded-sm p-6 bg-white/60">
        <div className="text-[12px] text-slate-600">
          Módulo <b className="text-[#2A3F55]">{label}</b> — ventana lista para captura de datos.
        </div>
        <div className="mt-3 grid grid-cols-4 gap-3">
          <Field label="Código"><input className={inp} /></Field>
          <Field label="Descripción" className="col-span-2"><input className={inp} /></Field>
          <Field label="Fecha"><input className={inp} type="date" /></Field>
          <Field label="Responsable" className="col-span-2"><input className={inp} /></Field>
          <Field label="Monto"><input className={inp} type="number" /></Field>
          <Field label="Estado"><select className={inp}><option>Activo</option><option>Inactivo</option></select></Field>
        </div>
        <div className="mt-4"><DataTable columns={["#", "Detalle", "Referencia", "Fecha", "Valor"]} rows={4} /></div>
      </div>
    </WindowShell>
  );
}

// ============================================================
// MACRO 1 · CRÉDITOS
// ============================================================
function CtasXCobrar() {
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
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
        <span className="ml-auto text-[11px] text-slate-500">Deuda total S/: <b className="text-red-700">0.00</b></span>
      </>}>
      <div className="grid grid-cols-5 gap-2 mb-3">
        <Field label="Vendedor"><select className={inp} value={vendor} onChange={(e) => setVendor(e.target.value)}><option>Todos</option></select></Field>
        <Field label="Estado"><select className={inp} value={state} onChange={(e) => setState(e.target.value)}><option>Todos</option><option>Vigente</option><option>Vencido</option><option>Cobrado</option></select></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>PEN</option><option>USD</option></select></Field>
        <Field label="Desde"><input className={inp} type="date" value={fromDate} onChange={(e) => setFromDate(e.target.value)} /></Field>
        <Field label="Hasta"><input className={inp} type="date" value={toDate} onChange={(e) => setToDate(e.target.value)} /></Field>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto"><table className="w-full text-[11px] border-collapse"><thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">Doc.</th><th className="px-2 py-2 text-left border-b border-slate-300">Fecha Emis.</th><th className="px-2 py-2 text-left border-b border-slate-300">Vence</th><th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th><th className="px-2 py-2 text-left border-b border-slate-300">Moneda</th><th className="px-2 py-2 text-right border-b border-slate-300">Total</th><th className="px-2 py-2 text-right border-b border-slate-300">Saldo</th><th className="px-2 py-2 text-right border-b border-slate-300">Días</th><th className="px-2 py-2 text-left border-b border-slate-300">Estado</th></tr></thead><tbody><tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">No hay cuentas por cobrar.</td></tr></tbody></table></div>
    </WindowShell>
  );
}

function Anticipos() {
  const [clientName, setClientName] = useState("");
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [currency, setCurrency] = useState("PEN");
  const [amount, setAmount] = useState(0);
  const [paymentMethod, setPaymentMethod] = useState("Transferencia");
  const [reference, setReference] = useState("");
  const [note, setNote] = useState("");
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const handleSave = async () => {
    if (!clientName.trim() || amount <= 0) {
      setMessage("Complete cliente y monto.");
      return;
    }
    setSaving(true);
    try {
      await createSigecoomSale({
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
      </>}>
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
    </WindowShell>
  );
}

function Planillas() {
  const [collector, setCollector] = useState("");
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [route, setRoute] = useState("Lima Centro");
  const [currency, setCurrency] = useState("PEN");
  const [generating, setGenerating] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

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
      </>}>
      <div className="grid grid-cols-4 gap-2 mb-3">
        <Field label="Cobrador"><select className={inp} value={collector} onChange={(e) => setCollector(e.target.value)}><option value="">Asignar...</option><option value="grios">grios</option><option value="mlopez">mlopez</option></select></Field>
        <Field label="Fecha"><input className={inp} type="date" value={date} onChange={(e) => setDate(e.target.value)} /></Field>
        <Field label="Ruta"><select className={inp} value={route} onChange={(e) => setRoute(e.target.value)}><option>Lima Centro</option><option>Lima Norte</option></select></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>PEN</option></select></Field>
      </div>
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto"><table className="w-full text-[11px] border-collapse"><thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">#</th><th className="px-2 py-2 text-left border-b border-slate-300">Doc.</th><th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th><th className="px-2 py-2 text-left border-b border-slate-300">Dirección</th><th className="px-2 py-2 text-right border-b border-slate-300">Monto</th><th className="px-2 py-2 text-left border-b border-slate-300">Vence</th><th className="px-2 py-2 text-left border-b border-slate-300">Prioridad</th></tr></thead><tbody><tr><td colSpan={7} className="px-2 py-4 text-sm text-slate-500">No hay cobranzas programadas.</td></tr></tbody></table></div>
    </WindowShell>
  );
}

function Letras() {
  const [letters, setLetters] = useState<SigecoomSale[]>([]);
  const [selectedLetterId, setSelectedLetterId] = useState("");
  const [loadingLetters, setLoadingLetters] = useState(true);
  const [actionLoading, setActionLoading] = useState(false);
  const [statusMessage, setStatusMessage] = useState<string | null>(null);

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

  return (
    <WindowShell title="Letras de Cambio Financieras"
      toolbar={<>
        <button className={btnPrimary} onClick={handleGenerate} disabled={actionLoading}><Save className="h-3.5 w-3.5" />{actionLoading ? "Procesando..." : "Generar Letra"}</button>
        <button className={btn} onClick={() => updateSelectedLetterStatus("accepted")} disabled={actionLoading}>Aceptar</button>
        <button className={btn} onClick={() => updateSelectedLetterStatus("protested")} disabled={actionLoading}>Protestar</button>
      </>}>
      {statusMessage && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{statusMessage}</div>}
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">Sel</th><th className="px-2 py-2 text-left border-b border-slate-300">Nº Letra</th><th className="px-2 py-2 text-left border-b border-slate-300">Fecha Giro</th><th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th><th className="px-2 py-2 text-left border-b border-slate-300">Vencimiento</th><th className="px-2 py-2 text-left border-b border-slate-300">Moneda</th><th className="px-2 py-2 text-right border-b border-slate-300">Importe</th><th className="px-2 py-2 text-left border-b border-slate-300">Banco</th><th className="px-2 py-2 text-left border-b border-slate-300">Estado</th></tr></thead>
          <tbody>
            {letters.length === 0 ? (
              <tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">No hay letras registradas.</td></tr>
            ) : letters.map((letter) => (
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

function AprobacionCreditos() {
  const [type, setType] = useState("Extensión de línea");
  const [status, setStatus] = useState("Pendiente");
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");

  return (
    <WindowShell title="Aprobación de Créditos y Extensiones"
      toolbar={<>
        <button className={btnPrimary}>Aprobar</button>
        <button className={btn}>Rechazar</button>
        <button className={btn}><User className="h-3.5 w-3.5" />Ver Historial</button>
      </>}>
      <div className="grid grid-cols-4 gap-2 mb-3">
        <Field label="Tipo"><select className={inp} value={type} onChange={(e) => setType(e.target.value)}><option>Extensión de línea</option><option>Cotización especial</option><option>Documento recibido</option></select></Field>
        <Field label="Estado"><select className={inp} value={status} onChange={(e) => setStatus(e.target.value)}><option>Pendiente</option><option>Aprobado</option><option>Rechazado</option></select></Field>
        <Field label="Desde"><input className={inp} type="date" value={fromDate} onChange={(e) => setFromDate(e.target.value)} /></Field>
        <Field label="Hasta"><input className={inp} type="date" value={toDate} onChange={(e) => setToDate(e.target.value)} /></Field>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto"><table className="w-full text-[11px] border-collapse"><thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">#</th><th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th><th className="px-2 py-2 text-left border-b border-slate-300">Solicita</th><th className="px-2 py-2 text-left border-b border-slate-300">Vendedor</th><th className="px-2 py-2 text-right border-b border-slate-300">Monto</th><th className="px-2 py-2 text-left border-b border-slate-300">Línea Actual</th><th className="px-2 py-2 text-left border-b border-slate-300">Línea Solicitada</th><th className="px-2 py-2 text-left border-b border-slate-300">Estado</th></tr></thead><tbody><tr><td colSpan={8} className="px-2 py-4 text-sm text-slate-500">No hay solicitudes de crédito.</td></tr></tbody></table></div>
    </WindowShell>
  );
}

function TipoCambio() {
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [currency, setCurrency] = useState("USD");
  const [buy, setBuy] = useState(3.408);
  const [sell, setSell] = useState(3.412);
  const [saving, setSaving] = useState(false);

  const handleSave = async () => {
    setSaving(true);
    try {
      // Simulado
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Mantenimiento del Tipo de Cambio"
      toolbar={<><button className={btnPrimary} onClick={handleSave} disabled={saving}><Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Guardar T/C del día"}</button></>}>
      <div className="grid grid-cols-4 gap-3 max-w-2xl">
        <Field label="Fecha"><input className={inp} type="date" value={date} onChange={(e) => setDate(e.target.value)} /></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>USD — Dólares</option><option>EUR — Euros</option></select></Field>
        <Field label="Compra"><input className={inp} type="number" step="0.001" value={buy} onChange={(e) => setBuy(Number(e.target.value))} /></Field>
        <Field label="Venta"><input className={inp} type="number" step="0.001" value={sell} onChange={(e) => setSell(Number(e.target.value))} /></Field>
      </div>
      <div className="mt-4"><div className="border border-slate-300 rounded-sm bg-white overflow-auto"><table className="w-full text-[11px] border-collapse"><thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">Fecha</th><th className="px-2 py-2 text-left border-b border-slate-300">Moneda</th><th className="px-2 py-2 text-right border-b border-slate-300">Compra</th><th className="px-2 py-2 text-right border-b border-slate-300">Venta</th><th className="px-2 py-2 text-left border-b border-slate-300">Fuente</th></tr></thead><tbody><tr><td colSpan={5} className="px-2 py-4 text-sm text-slate-500">No hay cambios registrados.</td></tr></tbody></table></div></div>
    </WindowShell>
  );
}

// ============================================================
// MACRO 2 · ALMACENES
// ============================================================
function DocIngresos() {
  const [warehouse, setWarehouse] = useState("Central Lima");
  const [docType, setDocType] = useState("Factura Compra");
  const [docRef, setDocRef] = useState("");
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [provider, setProvider] = useState("");
  const [currency, setCurrency] = useState("PEN");
  const [saving, setSaving] = useState(false);
  const [linking, setLinking] = useState(false);
  const [message, setMessage] = useState<string | null>(null);
  const [lastCreatedSaleId, setLastCreatedSaleId] = useState<string | null>(null);

  const handleRegisterIngreso = async () => {
    if (!docRef.trim() || !provider.trim()) {
      setMessage("Complete documento de referencia y proveedor.");
      return;
    }
    setSaving(true);
    try {
      const created = await createSigecoomSale({
        type: "Ingreso Almacén",
        series: docType === "Factura Compra" ? "IC001" : docType === "Guía Proveedor" ? "GP001" : "ING001",
        number: Math.floor(Math.random() * 10000),
        date,
        client_id: provider,
        items: [{ description: `${docType} ${docRef} - ${warehouse}`, unit: "unidad", quantity: 1, price: 0 }],
        subtotal: 0,
        tax: 0,
        total: 0,
      });
      setLastCreatedSaleId(created.id);
      setMessage(`Ingreso registrado. Ahora haga clic en Vincular Compra para enlazar la compra.`);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo registrar el ingreso");
    } finally {
      setSaving(false);
    }
  };

  const handleLinkPurchase = async () => {
    if (!lastCreatedSaleId) {
      setMessage("Registre primero el ingreso antes de vincular la compra.");
      return;
    }
    if (!docRef.trim() || !provider.trim()) {
      setMessage("Complete referencia de compra y proveedor antes de vincular.");
      return;
    }
    setLinking(true);
    try {
      await linkSigecoomSalePurchase(lastCreatedSaleId, { purchase_reference: docRef, supplier: provider });
      setMessage(`Compra vinculada correctamente: ${docRef}`);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo vincular la compra");
    } finally {
      setLinking(false);
    }
  };

  return (
    <WindowShell title="Documento de Ingreso a Almacén"
      toolbar={<>
        <button className={btnPrimary} onClick={handleRegisterIngreso} disabled={saving}><Save className="h-3.5 w-3.5" />{saving ? "Registrando..." : "Registrar Ingreso"}</button>
        <button className={btn} onClick={handleLinkPurchase} disabled={linking}><Search className="h-3.5 w-3.5" />{linking ? "Vinculando..." : "Vincular Compra"}</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Almacén"><select className={inp} value={warehouse} onChange={(e) => setWarehouse(e.target.value)}><option>Central Lima</option><option>Norte</option></select></Field>
        <Field label="Tipo Doc."><select className={inp} value={docType} onChange={(e) => setDocType(e.target.value)}><option>Factura Compra</option><option>Guía Proveedor</option><option>Ingreso Interno</option></select></Field>
        <Field label="Documento Ref."><input className={inp} value={docRef} onChange={(e) => setDocRef(e.target.value)} placeholder="F-001-000123" /></Field>
        <Field label="Fecha"><input className={inp} type="date" value={date} onChange={(e) => setDate(e.target.value)} /></Field>
        <Field label="Proveedor" className="col-span-3"><input className={inp} value={provider} onChange={(e) => setProvider(e.target.value)} /></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>PEN</option><option>USD</option></select></Field>
      </div>
      <div className="mt-3"><DataTable columns={["#", "Código", "Producto", "U.M.", "Cant.", "Costo Unit.", "Total", "Ubicación"]} rows={6} /></div>
      {message && <div className="mt-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
    </WindowShell>
  );
}

function ChequeoFI() {
  const [items, setItems] = useState<InventoryItem[]>([]);
  const [physicalCounts, setPhysicalCounts] = useState<Record<string, number>>({});
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const loadItems = async () => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchInventory();
      setItems(data);
      setPhysicalCounts(Object.fromEntries(data.map((item) => [item.id, item.stock ?? 0])));
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando inventario");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadItems();
  }, []);

  const handleStockChange = (itemId: string, value: number) => {
    setPhysicalCounts((current) => ({ ...current, [itemId]: value }));
  };

  const handleSaveCounts = async () => {
    setSaving(true);
    setMessage(null);
    try {
      await Promise.all(items.map((item) => {
        const physicalStock = physicalCounts[item.id] ?? item.stock ?? 0;
        return updateInventoryItem(item.id, { stock: physicalStock });
      }));
      setMessage("Conteo físico guardado correctamente.");
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo guardar el conteo");
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Chequeo Físico F/I — Control de Calidad"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSaveCounts} disabled={saving || loading}><Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Guardar Conteo"}</button>
        <button className={btn} onClick={loadItems} disabled={loading}><RefreshCw className="h-3.5 w-3.5" />{loading ? "Cargando..." : "Refrescar"}</button>
      </>}>
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        {loading ? (
          <div className="p-4 text-sm text-slate-500">Cargando inventario para chequeo físico...</div>
        ) : (
          <table className="w-full text-[11px] border-collapse">
            <thead className="bg-[#F3F6FA]"><tr>
              <th className="px-2 py-2 text-left border-b border-slate-300">SKU</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Producto</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Stock actual</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Stock físico</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Diferencia</th>
            </tr></thead>
            <tbody>
              {items.length === 0 ? (
                <tr><td colSpan={5} className="px-2 py-4 text-sm text-slate-500">No hay artículos en inventario.</td></tr>
              ) : items.map((item) => {
                const recordedStock = item.stock ?? 0;
                return (
                  <tr key={item.id} className="hover:bg-slate-50">
                    <td className="px-2 py-2 border-b border-slate-200">{item.sku}</td>
                    <td className="px-2 py-2 border-b border-slate-200">{item.name}</td>
                    <td className="px-2 py-2 border-b border-slate-200">{recordedStock}</td>
                    <td className="px-2 py-2 border-b border-slate-200"><input className={inp} type="number" value={physicalCounts[item.id] ?? recordedStock} onChange={(e) => handleStockChange(item.id, Number(e.target.value))} /></td>
                    <td className="px-2 py-2 border-b border-slate-200">{(physicalCounts[item.id] ?? recordedStock) - recordedStock}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        )}
      </div>
    </WindowShell>
  );
}

function AtenderOT() {
  const [orders, setOrders] = useState<SigecoomSale[]>([]);
  const [searchNumber, setSearchNumber] = useState("");
  const [technician, setTechnician] = useState("");
  const [workDate, setWorkDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [selectedOrderId, setSelectedOrderId] = useState("");
  const [loading, setLoading] = useState(true);
  const [actionLoading, setActionLoading] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const loadOrders = async (search?: string) => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchSigecoomSales(search);
      setOrders(data.filter((sale) => sale.type.toLowerCase().includes("orden") || sale.type.toLowerCase().includes("ot")));
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando órdenes de trabajo");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadOrders();
  }, []);

  const handleSearchOT = () => {
    const query = searchNumber.trim() ? `OT ${searchNumber}` : "Orden Trabajo";
    loadOrders(query);
  };

  const handleDispatch = async () => {
    if (!selectedOrderId) {
      setMessage("Seleccione primero una orden de trabajo para despachar.");
      return;
    }
    setActionLoading(true);
    setMessage(null);
    try {
      const updated = await updateSigecoomSale(selectedOrderId, {
        status: "Despachado",
      });
      setOrders((current) => current.map((order) => order.id === updated.id ? updated : order));
      setMessage(`Orden ${updated.series}-${updated.number} despachada por ${technician || "taller"}.`);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo despachar la orden");
    } finally {
      setActionLoading(false);
    }
  };

  const visibleOrders = orders.filter((order) => {
    const needle = searchNumber.trim().toLowerCase();
    if (!needle) return true;
    return [order.series, order.number?.toString(), order.client_id, order.type, order.status]
      .some((value) => value?.toString().toLowerCase().includes(needle));
  });

  return (
    <WindowShell title="Atender Orden de Trabajo — Despacho de Repuestos"
      toolbar={<>
        <button className={btnPrimary} onClick={handleDispatch} disabled={actionLoading || loading}><Package className="h-3.5 w-3.5" />{actionLoading ? "Despachando..." : "Despachar"}</button>
        <button className={btn} onClick={handleSearchOT} disabled={loading}><Search className="h-3.5 w-3.5" />Buscar OT</button>
        <button className={btn} onClick={() => loadOrders()} disabled={loading}><RefreshCw className="h-3.5 w-3.5" />Refrescar</button>
      </>}
    >
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="grid grid-cols-4 gap-3 mb-3">
        <Field label="OT Nº"><input className={inp} value={searchNumber} onChange={(e) => setSearchNumber(e.target.value)} placeholder="Buscar por OT" /></Field>
        <Field label="Técnico" className="col-span-2"><input className={inp} value={technician} onChange={(e) => setTechnician(e.target.value)} placeholder="Nombre del técnico" /></Field>
        <Field label="Fecha"><input className={inp} type="date" value={workDate} onChange={(e) => setWorkDate(e.target.value)} /></Field>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr>
            <th className="px-2 py-2 text-left border-b border-slate-300">Sel</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">OT Nº</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Tipo</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Estado</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Fecha</th>
            <th className="px-2 py-2 text-right border-b border-slate-300">Total</th>
          </tr></thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={7} className="px-2 py-4 text-sm text-slate-500">Cargando órdenes de trabajo...</td></tr>
            ) : visibleOrders.length === 0 ? (
              <tr><td colSpan={7} className="px-2 py-4 text-sm text-slate-500">No se encontraron órdenes de trabajo.</td></tr>
            ) : visibleOrders.map((order) => (
              <tr key={order.id} className={`hover:bg-slate-50 ${selectedOrderId === order.id ? "bg-slate-100" : ""}`} onClick={() => setSelectedOrderId(order.id)}>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><input type="radio" name="selectedOrder" checked={selectedOrderId === order.id} readOnly /></td>
                <td className="px-2 py-2 border-b border-slate-200">{order.series}-{order.number}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.type}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.client_id}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.status}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.date}</td>
                <td className="px-2 py-2 text-right border-b border-slate-200">{order.total.toFixed(2)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

function Productos() {
  const [items, setItems] = useState<InventoryItem[]>([]);
  const [selectedItemId, setSelectedItemId] = useState<string>("");
  const [sku, setSku] = useState("");
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [category, setCategory] = useState("Repuestos");
  const [unit, setUnit] = useState("UND");
  const [supplier, setSupplier] = useState("");
  const [stock, setStock] = useState(0);
  const [minStock, setMinStock] = useState(10);
  const [costPrice, setCostPrice] = useState(0);
  const [salePrice, setSalePrice] = useState(0);
  const [search, setSearch] = useState("");
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);
  const [importing, setImporting] = useState(false);
  const fileInputRef = useRef<HTMLInputElement | null>(null);

  const loadItems = async (query?: string) => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchInventory(query?.trim() ? query : undefined);
      setItems(data);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando productos");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadItems();
  }, []);

  const clearForm = () => {
    setSelectedItemId("");
    setSku("");
    setName("");
    setDescription("");
    setCategory("Repuestos");
    setUnit("UND");
    setSupplier("");
    setStock(0);
    setMinStock(10);
    setCostPrice(0);
    setSalePrice(0);
    setMessage(null);
  };

  const handleSelect = (item: InventoryItem) => {
    setSelectedItemId(item.id);
    setSku(item.sku);
    setName(item.name);
    setDescription(item.description ?? "");
    setCategory(item.category ?? "Repuestos");
    setUnit(item.unit ?? "UND");
    setSupplier(item.supplier ?? "");
    setStock(item.stock ?? 0);
    setMinStock(item.min_stock ?? 0);
    setCostPrice(item.cost_price ?? 0);
    setSalePrice(item.sale_price ?? 0);
    setMessage(null);
  };

  const handleSave = async () => {
    if (!sku.trim() || !name.trim()) {
      setMessage("SKU y nombre son obligatorios.");
      return;
    }

    setSaving(true);
    try {
      if (selectedItemId) {
        const updated = await updateInventoryItem(selectedItemId, {
          name,
          description,
          category,
          unit,
          supplier,
          stock,
          min_stock: minStock,
          cost_price: costPrice,
          sale_price: salePrice,
        });
        setItems((current) => current.map((item) => item.id === updated.id ? updated : item));
        setMessage(`Producto actualizado: ${updated.sku}`);
      } else {
        const created = await createInventoryItem({
          sku,
          name,
          description,
          category,
          unit,
          supplier,
          stock,
          min_stock: minStock,
          cost_price: costPrice,
          sale_price: salePrice,
        });
        setItems((current) => [created, ...current]);
        setSelectedItemId(created.id);
        setMessage(`Producto creado: ${created.sku}`);
      }
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo guardar el producto");
    } finally {
      setSaving(false);
    }
  };

  const handleSearch = async () => {
    await loadItems(search);
  };

  const handleExport = async () => {
    try {
      const blob = await exportSigecoomInventory("csv");
      downloadBlob(blob, "inventario_export.csv");
      setMessage("Exportación de inventario iniciada.");
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo exportar el inventario");
    }
  };

  const handleImportClick = () => {
    fileInputRef.current?.click();
  };

  const handleImport = async (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (!file) {
      return;
    }
    setImporting(true);
    setMessage(null);
    try {
      const result = await importSigecoomInventory(file);
      setMessage(`Importados ${result.created} nuevos / actualizados ${result.updated}`);
      await loadItems();
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo importar el inventario");
    } finally {
      setImporting(false);
      event.target.value = "";
    }
  };

  const handleLabel = () => {
    if (!selectedItemId) {
      setMessage("Seleccione un producto para generar etiqueta.");
      return;
    }
    setMessage(`Etiqueta generada para ${sku}`);
  };

  return (
    <WindowShell title="Maestro de Productos — Ficha SKU"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSave} disabled={saving}><Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Guardar"}</button>
        <button className={btn} onClick={clearForm}><Plus className="h-3.5 w-3.5" />Nuevo</button>
        <button className={btn} onClick={handleSearch}><Search className="h-3.5 w-3.5" />Buscar</button>
        <button className={btn} onClick={handleLabel}><Printer className="h-3.5 w-3.5" />Etiqueta</button>
        <button className={btn} onClick={handleImportClick} disabled={importing}><FileSpreadsheet className="h-3.5 w-3.5" />Importar Excel</button>
        <button className={btn} onClick={handleExport}><FileDown className="h-3.5 w-3.5" />Exportar CSV</button>
        <input ref={fileInputRef} type="file" accept=".csv" className="hidden" onChange={handleImport} />
      </>}
    >
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="grid grid-cols-2 gap-4">
        <div className="border border-slate-300 rounded-sm p-3 bg-white">
          <div className="text-[11px] font-semibold text-[#2A3F55] mb-2 uppercase">Identificación</div>
          <div className="grid grid-cols-2 gap-2">
            <Field label="Código SKU"><input className={inp} value={sku} onChange={(e) => setSku(e.target.value)} /></Field>
            <Field label="Descripción" className="col-span-2"><input className={inp} value={name} onChange={(e) => setName(e.target.value)} /></Field>
            <Field label="Código de Barras"><input className={inp} value={description} onChange={(e) => setDescription(e.target.value)} /></Field>
            <Field label="Categoría"><select className={inp} value={category} onChange={(e) => setCategory(e.target.value)}><option>Repuestos</option><option>Herramientas</option><option>Consumibles</option></select></Field>
            <Field label="Unidad Medida"><select className={inp} value={unit} onChange={(e) => setUnit(e.target.value)}><option>UND</option><option>KG</option><option>MT</option></select></Field>
            <Field label="Marca"><input className={inp} value={supplier} onChange={(e) => setSupplier(e.target.value)} /></Field>
          </div>
        </div>
        <div className="border border-slate-300 rounded-sm p-3 bg-white">
          <div className="text-[11px] font-semibold text-[#2A3F55] mb-2 uppercase">Stocks y Precios</div>
          <div className="grid grid-cols-2 gap-2">
            <Field label="Stock Actual"><input className={inp} type="number" value={stock} onChange={(e) => setStock(Number(e.target.value))} /></Field>
            <Field label="Stock Mínimo"><input className={inp} type="number" value={minStock} onChange={(e) => setMinStock(Number(e.target.value))} /></Field>
            <Field label="Costo"><input className={inp} type="number" value={costPrice} onChange={(e) => setCostPrice(Number(e.target.value))} /></Field>
            <Field label="Precio Venta"><input className={inp} type="number" value={salePrice} onChange={(e) => setSalePrice(Number(e.target.value))} /></Field>
            <Field label="Proveedor"><input className={inp} value={supplier} onChange={(e) => setSupplier(e.target.value)} /></Field>
            <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
          </div>
        </div>
      </div>
      <div className="mt-4 border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr>
            <th className="px-2 py-2 text-left border-b border-slate-300">SKU</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Descripción</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Categoría</th>
            <th className="px-2 py-2 text-right border-b border-slate-300">Stock</th>
            <th className="px-2 py-2 text-right border-b border-slate-300">Precio</th>
          </tr></thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={5} className="px-2 py-4 text-sm text-slate-500">Cargando productos...</td></tr>
            ) : items.length === 0 ? (
              <tr><td colSpan={5} className="px-2 py-4 text-sm text-slate-500">No hay productos registrados.</td></tr>
            ) : items.map((item) => (
              <tr key={item.id} className={`hover:bg-slate-50 ${selectedItemId === item.id ? "bg-slate-100" : ""}`} onClick={() => handleSelect(item)}>
                <td className="px-2 py-2 border-b border-slate-200">{item.sku}</td>
                <td className="px-2 py-2 border-b border-slate-200">{item.name}</td>
                <td className="px-2 py-2 border-b border-slate-200">{item.category || "—"}</td>
                <td className="px-2 py-2 text-right border-b border-slate-200">{item.stock ?? 0}</td>
                <td className="px-2 py-2 text-right border-b border-slate-200">{item.sale_price?.toFixed(2) ?? "0.00"}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

function ActMinMax() {
  return (
    <WindowShell title="Actualización masiva de Stock Min / Max"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Aplicar cambios</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Importar Excel</button>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtrar categoría</button>
      </>}>
      <DataTable columns={["Código", "Producto", "Categoría", "Stock Actual", "Min Actual", "Max Actual", "Min Nuevo", "Max Nuevo"]} rows={10} />
    </WindowShell>
  );
}

function Ubicaciones() {
  const [locations, setLocations] = useState<Location[]>([]);
  const [selectedLocationId, setSelectedLocationId] = useState("");
  const [code, setCode] = useState("");
  const [warehouse, setWarehouse] = useState("Central Lima");
  const [aisle, setAisle] = useState("");
  const [shelf, setShelf] = useState("");
  const [row, setRow] = useState("");
  const [level, setLevel] = useState("");
  const [capacity, setCapacity] = useState<number | "">("");
  const [occupancy, setOccupancy] = useState<number | "">("");
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const resetForm = () => {
    setSelectedLocationId("");
    setCode("");
    setWarehouse("Central Lima");
    setAisle("");
    setShelf("");
    setRow("");
    setLevel("");
    setCapacity("");
    setOccupancy("");
    setMessage(null);
  };

  const loadLocations = async () => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchSigecoomLocations();
      setLocations(data);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando ubicaciones");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadLocations();
  }, []);

  const handleSave = async () => {
    if (!code.trim() || !warehouse.trim()) {
      setMessage("Código y almacén son obligatorios.");
      return;
    }
    setSaving(true);
    setMessage(null);
    try {
      const payload = {
        code: code.trim(),
        warehouse: warehouse.trim(),
        aisle: aisle.trim() || undefined,
        shelf: shelf.trim() || undefined,
        row: row.trim() || undefined,
        level: level.trim() || undefined,
        description: undefined,
        capacity: capacity === "" ? undefined : Number(capacity),
        occupancy_percent: occupancy === "" ? undefined : Number(occupancy),
      };
      if (selectedLocationId) {
        await updateSigecoomLocation(selectedLocationId, payload);
        setMessage("Ubicación actualizada correctamente.");
      } else {
        await createSigecoomLocation(payload);
        setMessage("Ubicación creada correctamente.");
      }
      resetForm();
      await loadLocations();
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo guardar la ubicación");
    } finally {
      setSaving(false);
    }
  };

  const handleSelect = (location: Location) => {
    setSelectedLocationId(location.id);
    setCode(location.code);
    setWarehouse(location.warehouse);
    setAisle(location.aisle ?? "");
    setShelf(location.shelf ?? "");
    setRow(location.row ?? "");
    setLevel(location.level ?? "");
    setCapacity(location.capacity ?? "");
    setOccupancy(location.occupancy_percent ?? "");
    setMessage(null);
  };

  const handleDelete = async () => {
    if (!selectedLocationId) {
      setMessage("Seleccione primero una ubicación para eliminar.");
      return;
    }
    setSaving(true);
    setMessage(null);
    try {
      await deleteSigecoomLocation(selectedLocationId);
      setMessage("Ubicación eliminada correctamente.");
      resetForm();
      await loadLocations();
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo eliminar la ubicación");
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Ubicaciones de Almacén — Configuración geométrica"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSave} disabled={saving}><Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Guardar"}</button>
        <button className={btn} onClick={resetForm}><Plus className="h-3.5 w-3.5" />Nueva ubicación</button>
        <button className={btn} onClick={handleDelete} disabled={saving || !selectedLocationId}><Trash2 className="h-3.5 w-3.5" />Eliminar</button>
      </>}
    >
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="grid grid-cols-5 gap-2 mb-3">
        <Field label="Código"><input className={inp} value={code} onChange={(e) => setCode(e.target.value)} placeholder="UB-001" /></Field>
        <Field label="Almacén"><select className={inp} value={warehouse} onChange={(e) => setWarehouse(e.target.value)}><option>Central Lima</option><option>Norte</option><option>Sur</option></select></Field>
        <Field label="Pasillo"><input className={inp} value={aisle} onChange={(e) => setAisle(e.target.value)} /></Field>
        <Field label="Estantería"><input className={inp} value={shelf} onChange={(e) => setShelf(e.target.value)} /></Field>
        <Field label="Fila"><input className={inp} value={row} onChange={(e) => setRow(e.target.value)} /></Field>
        <Field label="Nivel"><input className={inp} value={level} onChange={(e) => setLevel(e.target.value)} /></Field>
        <Field label="Capacidad"><input className={inp} type="number" value={capacity} onChange={(e) => setCapacity(e.target.value === "" ? "" : Number(e.target.value))} /></Field>
        <Field label="Ocupación %"><input className={inp} type="number" value={occupancy} onChange={(e) => setOccupancy(e.target.value === "" ? "" : Number(e.target.value))} /></Field>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr>
            <th className="px-2 py-2 text-left border-b border-slate-300">Sel</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Código</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Almacén</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Pasillo</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Estantería</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Fila</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Nivel</th>
            <th className="px-2 py-2 text-right border-b border-slate-300">Capacidad</th>
            <th className="px-2 py-2 text-right border-b border-slate-300">Ocupación</th>
          </tr></thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">Cargando ubicaciones...</td></tr>
            ) : locations.length === 0 ? (
              <tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">No hay ubicaciones registradas.</td></tr>
            ) : locations.map((location) => (
              <tr key={location.id} className={`hover:bg-slate-50 ${selectedLocationId === location.id ? "bg-slate-100" : ""}`} onClick={() => handleSelect(location)}>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><input type="radio" name="selectedLocation" checked={selectedLocationId === location.id} readOnly /></td>
                <td className="px-2 py-2 border-b border-slate-200">{location.code}</td>
                <td className="px-2 py-2 border-b border-slate-200">{location.warehouse}</td>
                <td className="px-2 py-2 border-b border-slate-200">{location.aisle}</td>
                <td className="px-2 py-2 border-b border-slate-200">{location.shelf}</td>
                <td className="px-2 py-2 border-b border-slate-200">{location.row}</td>
                <td className="px-2 py-2 border-b border-slate-200">{location.level}</td>
                <td className="px-2 py-2 text-right border-b border-slate-200">{location.capacity ?? "-"}</td>
                <td className="px-2 py-2 text-right border-b border-slate-200">{location.occupancy_percent ?? "-"}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

function TransitoDocs() {
  const [sales, setSales] = useState<SigecoomSale[]>([]);
  const [search, setSearch] = useState("");
  const [loading, setLoading] = useState(true);
  const [statusMessage, setStatusMessage] = useState<string | null>(null);
  const [actionLoading, setActionLoading] = useState(false);
  const [selectedSaleId, setSelectedSaleId] = useState("");

  const loadSales = async (query?: string) => {
    setLoading(true);
    setStatusMessage(null);
    try {
      const data = await fetchSigecoomSales(query?.trim() ? query : undefined);
      setSales(data);
    } catch (error) {
      setStatusMessage(error instanceof Error ? error.message : "Error cargando documentos en tránsito");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadSales();
  }, []);

  const handleRefresh = () => {
    loadSales(search);
  };

  const handleMarkInTransit = async () => {
    if (!selectedSaleId) {
      setStatusMessage("Seleccione un documento antes de marcarlo en tránsito.");
      return;
    }
    setActionLoading(true);
    setStatusMessage(null);
    try {
      const updated = await updateSigecoomSale(selectedSaleId, { status: "in_transit" });
      setSales((current) => current.map((sale) => sale.id === updated.id ? updated : sale));
      setStatusMessage(`Documento ${updated.series}-${updated.number} marcado en tránsito.`);
    } catch (error) {
      setStatusMessage(error instanceof Error ? error.message : "No se pudo actualizar el estado del documento.");
    } finally {
      setActionLoading(false);
    }
  };

  const visibleSales = sales.filter((sale) => {
    const needle = search.trim().toLowerCase();
    if (!needle) return true;
    return [sale.series, sale.number?.toString(), sale.client_id, sale.type, sale.status]
      .some((value) => value?.toString().toLowerCase().includes(needle));
  });

  return (
    <WindowShell title="Motores en Tránsito — Seguimiento"
      toolbar={<>
        <input className={`${inp} w-48`} placeholder="Buscar documento..." value={search} onChange={(e) => setSearch(e.target.value)} />
        <button className={btn} onClick={handleRefresh} disabled={loading}><RefreshCw className="h-3.5 w-3.5" />{loading ? "Cargando..." : "Actualizar"}</button>
        <button className={btn} onClick={handleMarkInTransit} disabled={actionLoading || loading}><Package className="h-3.5 w-3.5" />Marcar tránsito</button>
      </>}
    >
      {statusMessage && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{statusMessage}</div>}
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr>
            <th className="px-2 py-2 text-left border-b border-slate-300">Documento</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Tipo</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Estado</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Fecha</th>
            <th className="px-2 py-2 text-right border-b border-slate-300">Total</th>
          </tr></thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={6} className="px-2 py-4 text-sm text-slate-500">Cargando documentos en tránsito...</td></tr>
            ) : visibleSales.length === 0 ? (
              <tr><td colSpan={6} className="px-2 py-4 text-sm text-slate-500">No hay documentos para este filtro.</td></tr>
            ) : visibleSales.map((sale) => (
              <tr key={sale.id} className={`hover:bg-slate-50 ${selectedSaleId === sale.id ? "bg-slate-100" : ""}`} onClick={() => setSelectedSaleId(sale.id)}>
                <td className="px-2 py-2 border-b border-slate-200">{sale.series}-{sale.number}</td>
                <td className="px-2 py-2 border-b border-slate-200">{sale.type}</td>
                <td className="px-2 py-2 border-b border-slate-200">{sale.client_id}</td>
                <td className="px-2 py-2 border-b border-slate-200">{sale.status}</td>
                <td className="px-2 py-2 border-b border-slate-200">{sale.date?.toString().slice(0, 10)}</td>
                <td className="px-2 py-2 text-right border-b border-slate-200">{sale.total.toFixed(2)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

// ============================================================
// MACRO 2 · IMPORTACIONES
// ============================================================
function OrdenImportacion() {
  const [orders, setOrders] = useState<SigecoomSale[]>([]);
  const [selectedOrderId, setSelectedOrderId] = useState("");
  const [oiNumber, setOiNumber] = useState("");
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [foreignSupplier, setForeignSupplier] = useState("");
  const [country, setCountry] = useState("");
  const [incoterm, setIncoterm] = useState("FOB");
  const [currency, setCurrency] = useState("USD");
  const [container, setContainer] = useState("");
  const [customsAgency, setCustomsAgency] = useState("");
  const [dua, setDua] = useState("");
  const [freight, setFreight] = useState<number | "">("");
  const [etaPort, setEtaPort] = useState("");
  const [etaWarehouse, setEtaWarehouse] = useState("");
  const [shippingLine, setShippingLine] = useState("");
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const loadOrders = async () => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchSigecoomSales();
      setOrders(data.filter((sale) => sale.type.toLowerCase().includes("orden import")));
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando órdenes de importación");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadOrders();
  }, []);

  const resetForm = () => {
    setSelectedOrderId("");
    setOiNumber("");
    setDate(new Date().toISOString().slice(0, 10));
    setForeignSupplier("");
    setCountry("");
    setIncoterm("FOB");
    setCurrency("USD");
    setContainer("");
    setCustomsAgency("");
    setDua("");
    setFreight("");
    setEtaPort("");
    setEtaWarehouse("");
    setShippingLine("");
    setMessage(null);
  };

  const handleSave = async () => {
    if (!oiNumber.trim() || !foreignSupplier.trim()) {
      setMessage("Complete el Nº de OI y el proveedor extranjero.");
      return;
    }

    setSaving(true);
    setMessage(null);
    try {
      const extra_data = {
        oi_number: oiNumber.trim(),
        country: country.trim(),
        incoterm,
        currency,
        container: container.trim(),
        customs_agency: customsAgency.trim(),
        dua: dua.trim(),
        freight: freight === "" ? 0 : Number(freight),
        eta_port: etaPort,
        eta_warehouse: etaWarehouse,
        shipping_line: shippingLine.trim(),
      };

      if (selectedOrderId) {
        await updateSigecoomSale(selectedOrderId, {
          client_id: foreignSupplier.trim(),
          date,
          extra_data,
          subtotal: freight === "" ? 0 : Number(freight),
          total: freight === "" ? 0 : Number(freight),
        });
        setMessage("Orden de importación actualizada correctamente.");
      } else {
        await createSigecoomSale({
          type: "Orden Importación",
          series: "OI",
          number: parseInt(oiNumber.replace(/\D/g, "")) || Math.floor(Math.random() * 1000) + 1,
          date,
          client_id: foreignSupplier.trim(),
          items: [{ description: `Orden de importación ${oiNumber}`, unit: "unidad", quantity: 1, price: freight === "" ? 0 : Number(freight) }],
          subtotal: freight === "" ? 0 : Number(freight),
          tax: 0,
          total: freight === "" ? 0 : Number(freight),
          extra_data,
        });
        setMessage("Orden de importación registrada correctamente.");
      }
      await loadOrders();
      resetForm();
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo guardar la orden de importación");
    } finally {
      setSaving(false);
    }
  };

  const handleSelect = (order: SigecoomSale) => {
    setSelectedOrderId(order.id);
    setOiNumber(order.extra_data?.oi_number ?? order.series ?? "");
    setDate(order.date.slice(0, 10));
    setForeignSupplier(order.client_id ?? "");
    setCountry(order.extra_data?.country ?? "");
    setIncoterm(order.extra_data?.incoterm ?? "FOB");
    setCurrency(order.extra_data?.currency ?? "USD");
    setContainer(order.extra_data?.container ?? "");
    setCustomsAgency(order.extra_data?.customs_agency ?? "");
    setDua(order.extra_data?.dua ?? "");
    setFreight(order.extra_data?.freight ?? "");
    setEtaPort(order.extra_data?.eta_port ?? "");
    setEtaWarehouse(order.extra_data?.eta_warehouse ?? "");
    setShippingLine(order.extra_data?.shipping_line ?? "");
    setMessage(null);
  };

  return (
    <WindowShell title="Orden de Importación"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSave} disabled={saving}>{saving ? "Guardando..." : "Guardar"}</button>
        <button className={btn} onClick={resetForm}><Plus className="h-3.5 w-3.5" />Nueva</button>
        <button className={btn} onClick={loadOrders} disabled={loading}><RefreshCw className="h-3.5 w-3.5" />Refrescar</button>
      </>}
    >
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="grid grid-cols-4 gap-3">
        <Field label="OI Nº"><input className={inp} placeholder="OI-2026-0001" value={oiNumber} onChange={(e) => setOiNumber(e.target.value)} /></Field>
        <Field label="Fecha"><input className={inp} type="date" value={date} onChange={(e) => setDate(e.target.value)} /></Field>
        <Field label="Proveedor Extranjero" className="col-span-2"><input className={inp} value={foreignSupplier} onChange={(e) => setForeignSupplier(e.target.value)} /></Field>
        <Field label="País"><input className={inp} value={country} onChange={(e) => setCountry(e.target.value)} /></Field>
        <Field label="Incoterm"><select className={inp} value={incoterm} onChange={(e) => setIncoterm(e.target.value)}><option>FOB</option><option>CIF</option><option>EXW</option><option>DDP</option></select></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>USD</option><option>EUR</option></select></Field>
        <Field label="Nº Contenedor"><input className={inp} value={container} onChange={(e) => setContainer(e.target.value)} /></Field>
        <Field label="Agencia Aduana" className="col-span-2"><input className={inp} value={customsAgency} onChange={(e) => setCustomsAgency(e.target.value)} /></Field>
        <Field label="Dua / Dami"><input className={inp} value={dua} onChange={(e) => setDua(e.target.value)} /></Field>
        <Field label="Flete Internacional"><input className={inp} type="number" value={freight} onChange={(e) => setFreight(e.target.value === "" ? "" : Number(e.target.value))} /></Field>
        <Field label="ETA Puerto"><input className={inp} type="date" value={etaPort} onChange={(e) => setEtaPort(e.target.value)} /></Field>
        <Field label="ETA Almacén"><input className={inp} type="date" value={etaWarehouse} onChange={(e) => setEtaWarehouse(e.target.value)} /></Field>
        <Field label="Naviera"><input className={inp} value={shippingLine} onChange={(e) => setShippingLine(e.target.value)} /></Field>
      </div>
      <div className="mt-3 border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr>
            <th className="px-2 py-2 text-left border-b border-slate-300">Sel</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">OI Nº</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Proveedor</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Incoterm</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">País</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Flete</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">ETA Puerto</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">ETA Almacén</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Estado</th>
          </tr></thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">Cargando órdenes de importación...</td></tr>
            ) : orders.length === 0 ? (
              <tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">No hay órdenes de importación registradas.</td></tr>
            ) : orders.map((order) => (
              <tr key={order.id} className={`hover:bg-slate-50 ${selectedOrderId === order.id ? "bg-slate-100" : ""}`} onClick={() => handleSelect(order)}>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><input type="radio" name="selectedOrder" checked={selectedOrderId === order.id} readOnly /></td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.oi_number ?? order.series}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.client_id}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.incoterm}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.country}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.freight ?? 0}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.eta_port}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.eta_warehouse}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.status}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

// ============================================================
// MACRO 2 · ACTIVOS
// ============================================================
function ActivosFijos() {
  const [assets, setAssets] = useState<InventoryItem[]>([]);
  const [selectedAssetId, setSelectedAssetId] = useState("");
  const [sku, setSku] = useState("");
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [category, setCategory] = useState("Activo Fijo");
  const [unit, setUnit] = useState("UND");
  const [acquisitionDate, setAcquisitionDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [costPrice, setCostPrice] = useState(0);
  const [bookValue, setBookValue] = useState(0);
  const [responsible, setResponsible] = useState("");
  const [location, setLocation] = useState("");
  const [status, setStatus] = useState("Óptimo");
  const [search, setSearch] = useState("");
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const loadAssets = async (query?: string) => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchInventory(query?.trim() ? query : undefined);
      setAssets(data.filter((item) =>
        item.category?.toLowerCase().includes("activo") ||
        item.description?.toLowerCase().includes("activo") ||
        item.name.toLowerCase().includes("activo")
      ));
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando activos fijos");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadAssets();
  }, []);

  const clearForm = () => {
    setSelectedAssetId("");
    setSku("");
    setName("");
    setDescription("");
    setCategory("Activo Fijo");
    setUnit("UND");
    setAcquisitionDate(new Date().toISOString().slice(0, 10));
    setCostPrice(0);
    setBookValue(0);
    setResponsible("");
    setLocation("");
    setStatus("Óptimo");
    setMessage(null);
  };

  const handleSelectAsset = (item: InventoryItem) => {
    setSelectedAssetId(item.id);
    setSku(item.sku);
    setName(item.name);
    setDescription(item.description ?? "");
    setCategory(item.category ?? "Activo Fijo");
    setUnit(item.unit ?? "UND");
    setCostPrice(item.cost_price ?? 0);
    setBookValue(item.sale_price ?? 0);
    setResponsible(item.supplier ?? "");
    setLocation(item.category ?? "");
    setStatus(item.active === 1 ? "Activo" : "Inactivo");
    setMessage(null);
  };

  const handleSave = async () => {
    if (!sku.trim() || !name.trim()) {
      setMessage("SKU y descripción son obligatorios.");
      return;
    }

    setSaving(true);
    setMessage(null);

    try {
      if (selectedAssetId) {
        const updated = await updateInventoryItem(selectedAssetId, {
          name,
          description,
          category,
          unit,
          supplier: responsible,
          cost_price: costPrice,
          sale_price: bookValue,
          active: status === "Activo" ? 1 : 0,
        });
        setAssets((current) => current.map((item) => item.id === updated.id ? updated : item));
        setMessage(`Activo fijo actualizado: ${updated.sku}`);
      } else {
        const created = await createInventoryItem({
          sku,
          name,
          description,
          category,
          unit,
          supplier: responsible,
          cost_price: costPrice,
          sale_price: bookValue,
          stock: 1,
          min_stock: 0,
        });
        setAssets((current) => [created, ...current]);
        setSelectedAssetId(created.id);
        setMessage(`Activo fijo creado: ${created.sku}`);
      }
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo guardar el activo fijo");
    } finally {
      setSaving(false);
    }
  };

  const visibleAssets = assets.filter((item) => {
    const query = search.trim().toLowerCase();
    if (!query) return true;
    return [item.sku, item.name, item.category, item.description, item.supplier]
      .some((value) => value?.toLowerCase().includes(query));
  });

  return (
    <WindowShell title="Activos Fijos — Inventario"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSave} disabled={saving || loading}><Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Guardar"}</button>
        <button className={btn} onClick={clearForm} disabled={saving}><Plus className="h-3.5 w-3.5" />Nuevo Activo</button>
        <button className={btn} onClick={() => loadAssets(search)} disabled={loading}><RefreshCw className="h-3.5 w-3.5" />Refrescar</button>
      </>}
    >
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="grid grid-cols-4 gap-3 mb-3">
        <Field label="Buscar Activo" className="col-span-2"><input className={inp} value={search} onChange={(e) => setSearch(e.target.value)} placeholder="Código, nombre o categoría" /></Field>
        <Field label="SKU"><input className={inp} value={sku} onChange={(e) => setSku(e.target.value)} placeholder="AF-0001" /></Field>
        <Field label="Categoría"><input className={inp} value={category} onChange={(e) => setCategory(e.target.value)} /></Field>
        <Field label="Descripción" className="col-span-2"><input className={inp} value={name} onChange={(e) => setName(e.target.value)} /></Field>
        <Field label="Fecha Adquisición"><input className={inp} type="date" value={acquisitionDate} onChange={(e) => setAcquisitionDate(e.target.value)} /></Field>
        <Field label="Costo Adquisición"><input className={inp} type="number" value={costPrice} onChange={(e) => setCostPrice(Number(e.target.value))} /></Field>
        <Field label="Valor en Libros"><input className={inp} type="number" value={bookValue} onChange={(e) => setBookValue(Number(e.target.value))} /></Field>
        <Field label="Responsable"><input className={inp} value={responsible} onChange={(e) => setResponsible(e.target.value)} /></Field>
        <Field label="Ubicación / Área"><input className={inp} value={location} onChange={(e) => setLocation(e.target.value)} /></Field>
        <Field label="Estado"><select className={inp} value={status} onChange={(e) => setStatus(e.target.value)}><option>Óptimo</option><option>Bueno</option><option>Regular</option><option>Baja</option><option>Inactivo</option></select></Field>
        <Field label="Departamento" className="col-span-2"><input className={inp} placeholder="Área interna" /></Field>
      </div>

      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr>
            <th className="px-2 py-2 text-left border-b border-slate-300">SKU</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Activo</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Categoría</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Costo</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Valor Libros</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Responsable</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Estado</th>
          </tr></thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={7} className="px-2 py-4 text-sm text-slate-500">Cargando activos fijos...</td></tr>
            ) : visibleAssets.length === 0 ? (
              <tr><td colSpan={7} className="px-2 py-4 text-sm text-slate-500">No se encontraron activos fijos.</td></tr>
            ) : visibleAssets.map((asset) => (
              <tr key={asset.id} className={`hover:bg-slate-50 ${selectedAssetId === asset.id ? "bg-slate-100" : ""}`} onClick={() => handleSelectAsset(asset)}>
                <td className="px-2 py-2 border-b border-slate-200">{asset.sku}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.name}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.category}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.cost_price?.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.sale_price?.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.supplier}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.active === 1 ? "Activo" : "Inactivo"}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

// ============================================================
// MACRO 3 · COSTOS
// ============================================================
function ValorizarFI() {
  const [items, setItems] = useState<InventoryItem[]>([]);
  const [search, setSearch] = useState("");
  const [oiNumber, setOiNumber] = useState("OI-2026-0001");
  const [currency, setCurrency] = useState("USD");
  const [exchangeRate, setExchangeRate] = useState("3.411");
  const [freight, setFreight] = useState(0);
  const [insurance, setInsurance] = useState(0);
  const [customs, setCustoms] = useState(0);
  const [otherCosts, setOtherCosts] = useState(0);
  const [baseProrrateo, setBaseProrrateo] = useState("Valor FOB");
  const [selectedIds, setSelectedIds] = useState<string[]>([]);
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const loadItems = async (query?: string) => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchInventory(query?.trim() ? query : undefined);
      setItems(data);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando inventario");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadItems();
  }, []);

  const computedCosts = items.map((item) => {
    const stock = item.stock ?? 1;
    const baseValue = (item.cost_price ?? 0) * stock;
    return {
      ...item,
      stock,
      baseValue,
    };
  });

  const totalBase = computedCosts.reduce((sum, item) => sum + item.baseValue, 0);
  const totalExtras = freight + insurance + customs + otherCosts;

  const previewItems = computedCosts.map((item) => {
    const ratio = totalBase > 0 ? item.baseValue / totalBase : 1 / Math.max(items.length, 1);
    const proratedCost = totalExtras * ratio;
    const costPerUnit = item.stock > 0 ? proratedCost / item.stock : proratedCost;
    const netCost = (item.cost_price ?? 0) + costPerUnit;
    return {
      ...item,
      ratio,
      proratedCost,
      costPerUnit,
      netCost,
    };
  });

  const visibleItems = previewItems.filter((item) => {
    const needle = search.trim().toLowerCase();
    if (!needle) return true;
    return [item.sku, item.name, item.category, item.description].some((value) =>
      value?.toLowerCase().includes(needle)
    );
  });

  const toggleSelect = (itemId: string) => {
    setSelectedIds((current) =>
      current.includes(itemId) ? current.filter((id) => id !== itemId) : [...current, itemId]
    );
  };

  const handleApplyProrrateo = async () => {
    if (selectedIds.length === 0) {
      setMessage("Seleccione al menos un artículo para aplicar el prorrateo.");
      return;
    }
    setSaving(true);
    setMessage(null);
    try {
      const selected = previewItems.filter((item) => selectedIds.includes(item.id));
      const selectedTotalBase = selected.reduce((sum, item) => sum + item.baseValue, 0);
      await Promise.all(selected.map((item) => {
        const ratio = selectedTotalBase > 0 ? item.baseValue / selectedTotalBase : 1 / selected.length;
        const proratedCost = totalExtras * ratio;
        const priceIncrease = item.stock > 0 ? proratedCost / item.stock : proratedCost;
        const newCost = (item.cost_price ?? 0) + priceIncrease;
        return updateInventoryItem(item.id, {
          cost_price: Number(newCost.toFixed(2)),
        });
      }));
      await loadItems(search);
      setMessage("Prorrateo aplicado correctamente a los artículos seleccionados.");
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo aplicar el prorrateo");
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Valorizar F/I — Prorrateo de Costos de Importación"
      toolbar={<>
        <button className={btnPrimary} onClick={handleApplyProrrateo} disabled={saving || loading}>
          <Save className="h-3.5 w-3.5" />{saving ? "Aplicando..." : "Aplicar prorrateo"}
        </button>
        <button className={btn} onClick={() => loadItems(search)} disabled={loading}>
          <RefreshCw className="h-3.5 w-3.5" />{loading ? "Cargando..." : "Recalcular"}
        </button>
      </>}
    >
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="grid grid-cols-4 gap-3 mb-3">
        <Field label="OI / Embarque" className="col-span-2"><input className={inp} value={oiNumber} onChange={(e) => setOiNumber(e.target.value)} placeholder="OI-2026-0001" /></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>USD</option><option>PEN</option></select></Field>
        <Field label="T/C"><input className={inp} value={exchangeRate} onChange={(e) => setExchangeRate(e.target.value)} /></Field>
        <Field label="Flete Internacional"><input className={inp} type="number" value={freight} onChange={(e) => setFreight(Number(e.target.value))} /></Field>
        <Field label="Seguro"><input className={inp} type="number" value={insurance} onChange={(e) => setInsurance(Number(e.target.value))} /></Field>
        <Field label="Aduana / DUA"><input className={inp} type="number" value={customs} onChange={(e) => setCustoms(Number(e.target.value))} /></Field>
        <Field label="Otros Gastos"><input className={inp} type="number" value={otherCosts} onChange={(e) => setOtherCosts(Number(e.target.value))} /></Field>
        <Field label="Base Prorrateo"><select className={inp} value={baseProrrateo} onChange={(e) => setBaseProrrateo(e.target.value)}><option>Valor FOB</option><option>Peso</option><option>Volumen</option></select></Field>
      </div>
      <div className="grid grid-cols-4 gap-3 mb-4">
        <Field label="Buscar artículo" className="col-span-2"><input className={inp} value={search} onChange={(e) => setSearch(e.target.value)} placeholder="SKU, nombre, categoría" /></Field>
        <Field label="Total Base"><input className={inp} value={totalBase.toFixed(2)} readOnly /></Field>
        <Field label="Total Gastos"><input className={inp} value={totalExtras.toFixed(2)} readOnly /></Field>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr>
            <th className="px-2 py-2 text-left border-b border-slate-300">Sel</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">SKU</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Producto</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Cant.</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">FOB Unit.</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Prorrateo</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Costo Neto</th>
          </tr></thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={7} className="px-2 py-4 text-sm text-slate-500">Cargando artículos...</td></tr>
            ) : visibleItems.length === 0 ? (
              <tr><td colSpan={7} className="px-2 py-4 text-sm text-slate-500">No se encontraron artículos.</td></tr>
            ) : visibleItems.map((item) => (
              <tr key={item.id} className={`hover:bg-slate-50 ${selectedIds.includes(item.id) ? "bg-slate-100" : ""}`}>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><input type="checkbox" checked={selectedIds.includes(item.id)} onChange={() => toggleSelect(item.id)} /></td>
                <td className="px-2 py-2 border-b border-slate-200">{item.sku}</td>
                <td className="px-2 py-2 border-b border-slate-200">{item.name}</td>
                <td className="px-2 py-2 border-b border-slate-200">{item.stock}</td>
                <td className="px-2 py-2 border-b border-slate-200">{(item.cost_price ?? 0).toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{item.proratedCost?.toFixed(2) ?? "0.00"}</td>
                <td className="px-2 py-2 border-b border-slate-200">{item.netCost?.toFixed(2) ?? (item.cost_price ?? 0).toFixed(2)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}

function ProcesoLote({ label, subtitle }: { label: string; subtitle: string }) {
  return (
    <WindowShell title={`Proceso: ${label}`}
      toolbar={<>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Iniciar Proceso</button>
        <button className={btn}>Detener</button>
        <span className="ml-auto text-[11px] text-slate-500">Estado: <b className="text-emerald-700">Listo</b></span>
      </>}>
      <div className="text-[12px] text-slate-600 mb-3">{subtitle}</div>
      <div className="grid grid-cols-3 gap-3 mb-4">
        <Field label="Periodo"><input className={inp} type="month" /></Field>
        <Field label="Almacén"><select className={inp}><option>Todos</option><option>Central Lima</option></select></Field>
        <Field label="Método Costeo"><select className={inp}><option>Promedio Ponderado</option><option>PEPS / FIFO</option></select></Field>
      </div>
      <div className="space-y-3">
        <div>
          <div className="flex justify-between text-[11px] text-slate-600 mb-1"><span>Validación de saldos</span><span>0 / 0</span></div>
          <div className="h-2 bg-slate-200 rounded-sm overflow-hidden"><div className="h-full bg-gradient-to-r from-[#4C6E93] to-[#2A3F55] w-0"></div></div>
        </div>
        <div>
          <div className="flex justify-between text-[11px] text-slate-600 mb-1"><span>Recálculo de costos</span><span>0 / 0</span></div>
          <div className="h-2 bg-slate-200 rounded-sm overflow-hidden"><div className="h-full bg-gradient-to-r from-[#4C6E93] to-[#2A3F55] w-0"></div></div>
        </div>
        <div>
          <div className="flex justify-between text-[11px] text-slate-600 mb-1"><span>Cierre y bloqueo del periodo</span><span>0 / 0</span></div>
          <div className="h-2 bg-slate-200 rounded-sm overflow-hidden"><div className="h-full bg-gradient-to-r from-[#4C6E93] to-[#2A3F55] w-0"></div></div>
        </div>
      </div>
      <div className="mt-4 border border-slate-300 rounded-sm bg-slate-950 text-emerald-300 text-[11px] font-mono p-3 h-28 overflow-auto">
        <div>[sistema] Esperando inicio de proceso…</div>
      </div>
    </WindowShell>
  );
}

// ============================================================
// MACRO 3 · CONTABILIDAD
// ============================================================
type JournalLineForm = {
  id: string;
  account: string;
  description: string;
  reference: string;
  debit: number;
  credit: number;
  cost_center: string;
};

function Asientos() {
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

function MovimientoBancos() {
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

function RegistroCompra() {
  const [registers, setRegisters] = useState<PurchaseRegister[]>([]);
  const [loading, setLoading] = useState(false);
  const [filter, setFilter] = useState<"all" | "draft" | "registered">("all");

  // Form state
  const [docType, setDocType] = useState("Factura");
  const [series, setSeries] = useState("");
  const [number, setNumber] = useState("");
  const [docDate, setDocDate] = useState(new Date().toISOString().split('T')[0]);
  const [supplierRuc, setSupplierRuc] = useState("");
  const [supplierName, setSupplierName] = useState("");
  const [currency, setCurrency] = useState("PEN");
  const [taxableBase, setTaxableBase] = useState(0);
  const [igv, setIgv] = useState(0);
  const [nonTaxable, setNonTaxable] = useState(0);
  const [retention, setRetention] = useState(0);
  const [costCenter, setCostCenter] = useState("");

  // Load registers on mount
  useEffect(() => {
    loadRegisters();
  }, [filter]);

  const loadRegisters = async () => {
    try {
      setLoading(true);
      const statusFilter = filter === "all" ? undefined : filter;
      const data = await fetchPurchaseRegisters(statusFilter);
      setRegisters(data);
    } catch (error) {
      console.error("Error loading purchase registers:", error);
    } finally {
      setLoading(false);
    }
  };

  const handleSave = async () => {
    if (!supplierRuc || !supplierName || taxableBase + nonTaxable === 0) {
      alert("Ingrese datos requeridos: RUC, Razón Social y montos");
      return;
    }

    try {
      const total = taxableBase + igv + nonTaxable - retention;
      await createPurchaseRegister({
        document_type: docType,
        series: series || undefined,
        number: number || undefined,
        document_date: new Date(docDate).toISOString(),
        supplier_ruc: supplierRuc,
        supplier_name: supplierName,
        currency,
        taxable_base: taxableBase,
        igv,
        non_taxable: nonTaxable,
        total,
        retention: retention || undefined,
        cost_center: costCenter || undefined,
      });

      alert("Registro de compra creado exitosamente");
      // Clear form
      setSupplierRuc("");
      setSupplierName("");
      setSeries("");
      setNumber("");
      setTaxableBase(0);
      setIgv(0);
      setNonTaxable(0);
      setRetention(0);
      setCostCenter("");
      // Reload
      loadRegisters();
    } catch (error) {
      alert(`Error: ${(error as Error).message}`);
    }
  };

  const total = taxableBase + igv + nonTaxable - retention;

  return (
    <WindowShell title="Registro de Compras / Recibo por Honorarios"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSave}><Save className="h-3.5 w-3.5" />Registrar</button>
        <button className={btn} onClick={loadRegisters}><RefreshCw className="h-3.5 w-3.5" />Recargar</button>
        <select className={inp} value={filter} onChange={(e) => setFilter(e.target.value as any)} style={{ maxWidth: "120px" }}>
          <option value="all">Todos</option>
          <option value="draft">Borrador</option>
          <option value="registered">Registrado</option>
        </select>
      </>}>
      
      {/* Input Section */}
      <div className="grid grid-cols-4 gap-3 mb-4 p-3 bg-slate-50 rounded">
        <Field label="Tipo Doc.">
          <select className={inp} value={docType} onChange={(e) => setDocType(e.target.value)}>
            <option>Factura</option>
            <option>Boleta</option>
            <option>Recibo x Honorarios</option>
            <option>Nota Crédito</option>
          </select>
        </Field>
        <Field label="Serie"><input className={inp} value={series} onChange={(e) => setSeries(e.target.value)} /></Field>
        <Field label="Número"><input className={inp} value={number} onChange={(e) => setNumber(e.target.value)} /></Field>
        <Field label="Fecha Emisión"><input className={inp} type="date" value={docDate} onChange={(e) => setDocDate(e.target.value)} /></Field>
        <Field label="Proveedor RUC/DNI"><input className={inp} value={supplierRuc} onChange={(e) => setSupplierRuc(e.target.value)} placeholder="12345678901" /></Field>
        <Field label="Razón Social" className="col-span-2"><input className={inp} value={supplierName} onChange={(e) => setSupplierName(e.target.value)} /></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}>
          <option value="PEN">PEN</option>
          <option value="USD">USD</option>
        </select></Field>

        <Field label="Base Imponible"><input className={inp} type="number" value={taxableBase} onChange={(e) => setTaxableBase(parseFloat(e.target.value) || 0)} /></Field>
        <Field label="IGV"><input className={inp} type="number" value={igv} onChange={(e) => setIgv(parseFloat(e.target.value) || 0)} /></Field>
        <Field label="No Gravado"><input className={inp} type="number" value={nonTaxable} onChange={(e) => setNonTaxable(parseFloat(e.target.value) || 0)} /></Field>
        <Field label="Retención 4ta / Detracción"><input className={inp} type="number" value={retention} onChange={(e) => setRetention(parseFloat(e.target.value) || 0)} /></Field>
        <Field label="Centro Costo" className="col-span-2"><select className={inp} value={costCenter} onChange={(e) => setCostCenter(e.target.value)}>
          <option value="">-- Seleccionar --</option>
          <option value="Administración">Administración</option>
          <option value="Ventas">Ventas</option>
          <option value="Servicios">Servicios</option>
          <option value="Operaciones">Operaciones</option>
        </select></Field>

        <div className="col-span-4 text-right font-semibold text-slate-700">
          Total: <span className="text-lg font-mono">{total.toFixed(2)}</span>
        </div>
      </div>

      {/* Registers List */}
      <div className="mt-4">
        <div className="overflow-auto max-h-96 border border-slate-200 rounded">
          <table className="w-full text-sm">
            <thead className="sticky top-0 bg-slate-100 border-b">
              <tr>
                <th className="px-3 py-2 text-left">Tipo</th>
                <th className="px-3 py-2 text-left">Series</th>
                <th className="px-3 py-2 text-left">RUC</th>
                <th className="px-3 py-2 text-left">Proveedor</th>
                <th className="px-3 py-2 text-right">Base</th>
                <th className="px-3 py-2 text-right">IGV</th>
                <th className="px-3 py-2 text-right">Total</th>
                <th className="px-3 py-2 text-center">Estado</th>
              </tr>
            </thead>
            <tbody>
              {loading ? (
                <tr><td colSpan={8} className="px-3 py-2 text-center text-slate-500">Cargando...</td></tr>
              ) : registers.length === 0 ? (
                <tr><td colSpan={8} className="px-3 py-2 text-center text-slate-500">Sin registros</td></tr>
              ) : (
                registers.map((reg) => (
                  <tr key={reg.id} className="border-b hover:bg-slate-50 cursor-pointer">
                    <td className="px-3 py-2 text-xs">{reg.document_type}</td>
                    <td className="px-3 py-2 text-xs">{reg.series || "-"}</td>
                    <td className="px-3 py-2 text-xs font-mono">{reg.supplier_ruc}</td>
                    <td className="px-3 py-2 text-xs">{reg.supplier_name}</td>
                    <td className="px-3 py-2 text-right text-xs font-mono">{reg.taxable_base.toFixed(2)}</td>
                    <td className="px-3 py-2 text-right text-xs font-mono">{reg.igv.toFixed(2)}</td>
                    <td className="px-3 py-2 text-right text-xs font-mono font-semibold">{reg.total.toFixed(2)}</td>
                    <td className="px-3 py-2 text-center">
                      <span className={`text-xs px-2 py-1 rounded ${reg.status === 'registered' ? 'bg-green-100 text-green-700' : 'bg-blue-100 text-blue-700'}`}>
                        {reg.status === 'registered' ? 'Registrado' : 'Borrador'}
                      </span>
                    </td>
                  </tr>
                ))
              )}
            </tbody>
          </table>
        </div>
      </div>
    </WindowShell>
  );
}

function CajaChica() {
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

function GenerarTXT() {
  return (
    <WindowShell title="Generar TXT — Libros Electrónicos SUNAT"
      toolbar={<>
        <button className={btnPrimary}><FileDown className="h-3.5 w-3.5" />Generar archivo .TXT</button>
      </>}>
      <div className="grid grid-cols-3 gap-3">
        <Field label="Libro"><select className={inp}><option>Registro de Ventas</option><option>Registro de Compras</option><option>Libro Diario</option><option>Libro Mayor</option></select></Field>
        <Field label="Periodo"><input className={inp} type="month" /></Field>
        <Field label="Formato"><select className={inp}><option>PLE 5.2</option><option>PLE 5.3</option></select></Field>
      </div>
      <div className="mt-3 text-[11px] text-slate-600">Estructura del archivo se validará automáticamente contra el esquema oficial antes de la descarga.</div>
      <div className="mt-3"><DataTable columns={["Archivo", "Registros", "Tamaño", "Estado", "Fecha generación"]} rows={4} /></div>
    </WindowShell>
  );
}

function FlujoCaja() {
  return (
    <WindowShell title="Flujo de Caja Proyectado"
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Recalcular</button>
      </>}>
      <DataTable columns={["Semana", "Ingresos Proyectados", "Cobranza CxC", "Egresos Fijos", "Pagos CxP", "Saldo Neto", "Saldo Acumulado"]} rows={8} />
    </WindowShell>
  );
}

// ============================================================
// MACRO 3 · COMPRAS
// ============================================================
function SolicitudCompra() {
  return (
    <WindowShell title="Solicitud de Compra — Requerimiento Interno"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Enviar Solicitud</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Añadir ítem</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="SC Nº"><input className={inp} placeholder="SC-2026-0001" /></Field>
        <Field label="Fecha"><input className={inp} type="date" /></Field>
        <Field label="Área Solicitante"><select className={inp}><option>Servicios Técnicos</option><option>Almacén</option><option>Administración</option><option>Ventas</option></select></Field>
        <Field label="Prioridad"><select className={inp}><option>Normal</option><option>Alta</option><option>Urgente</option></select></Field>
        <Field label="Solicitante" className="col-span-2"><input className={inp} /></Field>
        <Field label="Justificación" className="col-span-4"><textarea className={`${inp} h-16 py-1`} /></Field>
      </div>
      <div className="mt-3"><DataTable columns={["#", "Código", "Descripción", "U.M.", "Cant.", "Uso destinado"]} rows={5} /></div>
    </WindowShell>
  );
}

function CotizacionesCompra() {
  return (
    <WindowShell title="Cuadro Comparativo de Cotizaciones"
      toolbar={<>
        <button className={btnPrimary}>✓ Adjudicar Proveedor</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nuevo proveedor</button>
        <button className={btn}><FileDown className="h-3.5 w-3.5" />PDF</button>
      </>}>
      <div className="grid grid-cols-3 gap-3 mb-3">
        <Field label="Solicitud Ref."><input className={inp} placeholder="SC-2026-0001" /></Field>
        <Field label="Fecha"><input className={inp} type="date" /></Field>
        <Field label="Criterio"><select className={inp}><option>Menor precio</option><option>Mejor plazo</option><option>Puntaje ponderado</option></select></Field>
      </div>
      <DataTable columns={["Producto", "Cant.", "Proveedor A", "Proveedor B", "Proveedor C", "Mejor Precio", "Plazo (días)", "Selección"]} rows={6} />
    </WindowShell>
  );
}

function OrdenCompra() {
  return (
    <WindowShell title="Orden de Compra"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Emitir OC</button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
        <button className={btn}><Mail className="h-3.5 w-3.5" />Enviar Proveedor</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="OC Nº"><input className={inp} placeholder="OC-2026-0001" /></Field>
        <Field label="Fecha"><input className={inp} type="date" /></Field>
        <Field label="Fecha Entrega"><input className={inp} type="date" /></Field>
        <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
        <Field label="Proveedor RUC"><input className={inp} /></Field>
        <Field label="Razón Social" className="col-span-2"><input className={inp} /></Field>
        <Field label="Condición Pago"><select className={inp}><option>Contado</option><option>Crédito 30</option><option>Crédito 60</option></select></Field>
        <Field label="Almacén Destino"><select className={inp}><option>Central Lima</option></select></Field>
        <Field label="Solicitud Ref."><input className={inp} /></Field>
        <Field label="Comprador" className="col-span-2"><input className={inp} /></Field>
      </div>
      <div className="mt-3"><DataTable columns={["#", "Código", "Descripción", "Cant.", "P.Unit", "Desc.", "IGV", "Total"]} rows={6} /></div>
      <div className="mt-3 grid grid-cols-4 gap-2 max-w-md ml-auto text-[11.5px]">
        <div className="text-right text-slate-600 col-span-3">Subtotal:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right text-slate-600 col-span-3">IGV:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right font-bold text-[#2A3F55] col-span-3">TOTAL:</div><div className="text-right font-mono font-bold">0.00</div>
      </div>
    </WindowShell>
  );
}

function Viaticos() {
  return (
    <WindowShell title="Planilla de Viáticos — Liquidación de Gastos de Viaje"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Liquidar</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Añadir gasto</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Personal" className="col-span-2"><input className={inp} /></Field>
        <Field label="Destino"><input className={inp} /></Field>
        <Field label="Motivo"><select className={inp}><option>Visita técnica</option><option>Visita comercial</option><option>Capacitación</option></select></Field>
        <Field label="Fecha Ida"><input className={inp} type="date" /></Field>
        <Field label="Fecha Retorno"><input className={inp} type="date" /></Field>
        <Field label="Adelanto S/"><input className={inp} type="number" /></Field>
        <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
      </div>
      <div className="mt-3"><DataTable columns={["#", "Fecha", "Concepto", "Comprobante", "Categoría", "Monto"]} rows={6} /></div>
      <div className="mt-3 grid grid-cols-4 gap-2 max-w-md ml-auto text-[11.5px]">
        <div className="text-right text-slate-600 col-span-3">Total gastado:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right text-slate-600 col-span-3">Adelanto:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right font-bold text-[#2A3F55] col-span-3">Saldo a favor / a devolver:</div><div className="text-right font-mono font-bold">0.00</div>
      </div>
    </WindowShell>
  );
}

function CtasXPagar() {
  return (
    <WindowShell title="Cuentas por Pagar — Programación de Pagos"
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><DollarSign className="h-3.5 w-3.5" />Programar Pago</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
        <span className="ml-auto text-[11px] text-slate-500">Deuda total S/: <b className="text-red-700">0.00</b></span>
      </>}>
      <div className="grid grid-cols-5 gap-2 mb-3">
        <Field label="Proveedor" className="col-span-2"><input className={inp} placeholder="RUC / Razón Social" /></Field>
        <Field label="Estado"><select className={inp}><option>Todos</option><option>Vigente</option><option>Vencido</option><option>Pagado</option></select></Field>
        <Field label="Desde"><input className={inp} type="date" /></Field>
        <Field label="Hasta"><input className={inp} type="date" /></Field>
      </div>
      <DataTable columns={["Doc.", "Fecha", "Vence", "Proveedor", "Moneda", "Total", "Saldo", "Días", "Estado"]} rows={10} />
    </WindowShell>
  );
}

// ============= SERVICIOS / TALLERES =============
function OrdenTrabajo() {
  return (
    <WindowShell title="Orden de Trabajo — Taller / Servicio Técnico"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar OT</button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
        <button className={btn}><Wrench className="h-3.5 w-3.5" />Asignar mecánicos</button>
        <span className="ml-auto text-[11px] text-slate-500">Estado: <b className="text-amber-700">En proceso</b></span>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Nº OT"><input className={inp} defaultValue="OT-000000" readOnly /></Field>
        <Field label="Fecha"><input className={inp} type="date" /></Field>
        <Field label="Cliente" className="col-span-2"><input className={inp} placeholder="RUC / DNI / Razón Social" /></Field>
        <Field label="Placa / Equipo"><input className={inp} /></Field>
        <Field label="Marca"><input className={inp} /></Field>
        <Field label="Modelo"><input className={inp} /></Field>
        <Field label="Kilometraje"><input className={inp} type="number" /></Field>
        <Field label="Descripción de la falla" className="col-span-4">
          <textarea className={inp + " h-14 py-1"} />
        </Field>
      </div>
      <div className="grid grid-cols-2 gap-3 mt-3">
        <div>
          <div className="text-[11px] font-semibold text-slate-600 mb-1">Mano de Obra</div>
          <DataTable columns={["Mecánico", "Tarea", "Inicio", "Fin", "Horas", "Costo"]} rows={4} />
        </div>
        <div>
          <div className="text-[11px] font-semibold text-slate-600 mb-1">Repuestos utilizados</div>
          <DataTable columns={["Código", "Descripción", "Cant.", "P. Unit", "Total"]} rows={4} />
        </div>
      </div>
      <div className="mt-3 grid grid-cols-4 gap-2 max-w-md ml-auto text-[11.5px]">
        <div className="text-right text-slate-600 col-span-3">Mano de obra:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right text-slate-600 col-span-3">Repuestos:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right font-bold text-[#2A3F55] col-span-3">Total OT S/:</div><div className="text-right font-mono font-bold">0.00</div>
      </div>
    </WindowShell>
  );
}

function Marcaciones({ title = "Marcación de Tareas OT" }: { title?: string }) {
  return (
    <WindowShell title={title}
      toolbar={<>
        <button className={btnPrimary}><Play className="h-3.5 w-3.5" />Inicio Tarea</button>
        <button className={btn}><Square className="h-3.5 w-3.5" />Fin Tarea</button>
        <button className={btn}><Clock className="h-3.5 w-3.5" />Reloj biométrico</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Mecánico"><input className={inp} placeholder="Código / Nombre" /></Field>
        <Field label="OT"><input className={inp} /></Field>
        <Field label="Tarea" className="col-span-2"><input className={inp} /></Field>
      </div>
      <div className="mt-3"><DataTable columns={["Fecha", "Mecánico", "OT", "Tarea", "Inicio", "Fin", "Horas", "Estado"]} rows={8} /></div>
    </WindowShell>
  );
}

function PedirRepuestos() {
  return (
    <WindowShell title="Pedir Repuestos — Enlace Taller ↔ Almacén"
      toolbar={<>
        <button className={btnPrimary}><Send className="h-3.5 w-3.5" />Enviar solicitud</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="OT origen"><input className={inp} /></Field>
        <Field label="Mecánico"><input className={inp} /></Field>
        <Field label="Almacén destino"><select className={inp}><option>Central</option><option>Repuestos</option></select></Field>
        <Field label="Prioridad"><select className={inp}><option>Normal</option><option>Urgente</option></select></Field>
      </div>
      <div className="mt-3"><DataTable columns={["Código", "Descripción", "Cant. solicitada", "Cant. atendida", "Estado"]} rows={6} /></div>
    </WindowShell>
  );
}

function GarantiaWin({ title }: { title: string }) {
  return (
    <WindowShell title={title + " — Gestión de Garantía"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Registrar</button>
        <button className={btn}><FileDown className="h-3.5 w-3.5" />Adjuntos</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Cliente" className="col-span-2"><input className={inp} /></Field>
        <Field label="Nº póliza / Serie"><input className={inp} /></Field>
        <Field label="Fecha reclamo"><input className={inp} type="date" /></Field>
        <Field label="Fabricante"><input className={inp} /></Field>
        <Field label="Equipo / Vehículo" className="col-span-2"><input className={inp} /></Field>
        <Field label="Cubre"><select className={inp}><option>Fabricante</option><option>Empresa</option><option>Compartida</option></select></Field>
        <Field label="Descripción del defecto" className="col-span-4"><textarea className={inp + " h-16 py-1"} /></Field>
      </div>
      <div className="mt-3"><DataTable columns={["Repuesto", "Cant.", "Costo cubierto", "Aprobado por", "Estado"]} rows={4} /></div>
    </WindowShell>
  );
}

function Kilometraje() {
  return (
    <WindowShell title="Kilometraje / Horómetros — Flota Vehicular"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Registrar lectura</button>
        <button className={btn}><Car className="h-3.5 w-3.5" />Alertas mantenimiento</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Placa / Equipo"><input className={inp} /></Field>
        <Field label="Fecha lectura"><input className={inp} type="date" /></Field>
        <Field label="Kilometraje / Horas"><input className={inp} type="number" /></Field>
        <Field label="Próximo servicio en"><input className={inp} type="number" /></Field>
      </div>
      <div className="mt-3"><DataTable columns={["Placa", "Última lectura", "Fecha", "Prox. servicio", "Días restantes", "Estado"]} rows={8} /></div>
    </WindowShell>
  );
}

function OficinaUsuario() {
  return (
    <WindowShell title="Oficina / Bahías del Taller"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nueva bahía</button>
      </>}>
      <DataTable columns={["Código", "Bahía / Puesto", "Sede", "Encargado", "Capacidad", "Estado"]} rows={8} />
    </WindowShell>
  );
}

// ============= RONDAS =============
function PuntosControl({ title }: { title: string }) {
  return (
    <WindowShell title={title + " — Rondas / Rutas de Control"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><MapPin className="h-3.5 w-3.5" />Ver en mapa</button>
        <button className={btn}><RefreshCw className="h-3.5 w-3.5" />Optimizar ruta</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Ruta" className="col-span-2"><input className={inp} /></Field>
        <Field label="Vigilante / Chofer"><input className={inp} /></Field>
        <Field label="Turno"><select className={inp}><option>Día</option><option>Noche</option></select></Field>
      </div>
      <div className="mt-3"><DataTable columns={["#", "Punto de control", "Dirección", "Hora exigida", "Tolerancia (min)", "Marcación"]} rows={8} /></div>
    </WindowShell>
  );
}

// ============= TELEFONÍA =============
function TelefoniaInv({ title }: { title: string }) {
  return (
    <WindowShell title={title + " — Inventario de Telefonía Corporativa"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nuevo</button>
        <button className={btn}><Phone className="h-3.5 w-3.5" />Operadora</button>
      </>}>
      <DataTable columns={["Código", title, "Marca / Detalle", "Operadora", "Costo mensual", "Estado"]} rows={8} />
    </WindowShell>
  );
}

function AsignaPersona() {
  return (
    <WindowShell title="Asignar Teléfono / Línea a Colaborador"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Asignar</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Colaborador" className="col-span-2"><input className={inp} placeholder="DNI / Nombre" /></Field>
        <Field label="Equipo"><input className={inp} /></Field>
        <Field label="Línea"><input className={inp} /></Field>
        <Field label="Plan"><input className={inp} /></Field>
        <Field label="Fecha entrega"><input className={inp} type="date" /></Field>
        <Field label="Estado"><select className={inp}><option>Activo</option><option>Devuelto</option><option>Perdido</option></select></Field>
      </div>
      <div className="mt-3"><DataTable columns={["Fecha", "Colaborador", "Equipo", "Línea", "Plan", "Estado"]} rows={6} /></div>
    </WindowShell>
  );
}

// ============= PERSONAL / PLANILLAS =============
function PersonalTiempo({ title }: { title: string }) {
  return (
    <WindowShell title={title + " — Gestión de Tiempo / Planilla"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}>
      <div className="grid grid-cols-5 gap-2 mb-3">
        <Field label="Colaborador" className="col-span-2"><input className={inp} placeholder="DNI / Nombre" /></Field>
        <Field label="Área"><input className={inp} /></Field>
        <Field label="Desde"><input className={inp} type="date" /></Field>
        <Field label="Hasta"><input className={inp} type="date" /></Field>
      </div>
      <DataTable columns={["Fecha", "Colaborador", "Área", title, "Horas", "Estado", "Aprobado por"]} rows={10} />
    </WindowShell>
  );
}

function MarcacionOnline() {
  return (
    <WindowShell title="Marcación en línea — Relojes Biométricos"
      toolbar={<>
        <button className={btn}><RefreshCw className="h-3.5 w-3.5" />Sincronizar relojes</button>
        <button className={btn}><Fingerprint className="h-3.5 w-3.5" />Historial</button>
        <span className="ml-auto text-[11px] text-slate-500">Última sincronización: <b>—</b></span>
      </>}>
      <div className="grid grid-cols-4 gap-3 mb-3">
        <Field label="Sede / Mina"><select className={inp}><option>Todas</option><option>Sede Central</option><option>Mina 1</option></select></Field>
        <Field label="Fecha"><input className={inp} type="date" /></Field>
        <Field label="Turno"><select className={inp}><option>Todos</option><option>Mañana</option><option>Tarde</option><option>Noche</option></select></Field>
      </div>
      <DataTable columns={["Hora", "Colaborador", "Sede", "Tipo", "Estado"]} rows={12} />
    </WindowShell>
  );
}

function FichaGeneral() {
  return (
    <WindowShell title="Ficha General del Empleado"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir ficha</button>
        <button className={btn}><FileDown className="h-3.5 w-3.5" />Contrato PDF</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="DNI"><input className={inp} /></Field>
        <Field label="Apellidos" className="col-span-2"><input className={inp} /></Field>
        <Field label="Nombres"><input className={inp} /></Field>
        <Field label="Fecha nacimiento"><input className={inp} type="date" /></Field>
        <Field label="Estado civil"><select className={inp}><option>Soltero</option><option>Casado</option><option>Conviviente</option></select></Field>
        <Field label="Dirección" className="col-span-2"><input className={inp} /></Field>
        <Field label="Teléfono"><input className={inp} /></Field>
        <Field label="Email"><input className={inp} type="email" /></Field>
        <Field label="Contacto emergencia" className="col-span-2"><input className={inp} /></Field>
        <Field label="Tipo de contrato"><select className={inp}><option>Indefinido</option><option>Plazo fijo</option><option>Locación</option></select></Field>
        <Field label="Régimen salud"><select className={inp}><option>EsSalud</option><option>EPS</option></select></Field>
        <Field label="AFP"><select className={inp}><option>Integra</option><option>Prima</option><option>Profuturo</option><option>Habitat</option><option>ONP</option></select></Field>
        <Field label="Sueldo base S/"><input className={inp} type="number" /></Field>
      </div>
      <div className="mt-3">
        <div className="text-[11px] font-semibold text-slate-600 mb-1">Historial de puestos</div>
        <DataTable columns={["Desde", "Hasta", "Puesto", "Área", "Sueldo", "Motivo cambio"]} rows={4} />
      </div>
    </WindowShell>
  );
}

function CapacitacionesWin({ title }: { title: string }) {
  return (
    <WindowShell title={title + " — Personal"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Programar</button>
        <button className={btn}><GraduationCap className="h-3.5 w-3.5" />Certificados</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Colaborador" className="col-span-2"><input className={inp} /></Field>
        <Field label="Área"><input className={inp} /></Field>
        <Field label="Periodo"><input className={inp} placeholder="2026" /></Field>
      </div>
      <div className="mt-3"><DataTable columns={["Fecha", "Colaborador", title, "Duración", "Resultado", "Estado"]} rows={8} /></div>
    </WindowShell>
  );
}

function PlanillaSueldos() {
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

function ProcesarMarcas() {
  return <ProcesoLote label="Procesar Marcas" subtitle="Consolida marcaciones biométricas y calcula asistencia, tardanzas y horas trabajadas del periodo." />;
}

// ============= MACRO 6 · TABLAS MAESTRAS (CRUD) =============
function MantenimientoCRUD({ label, columns }: { label: string; columns: string[] }) {
  return (
    <WindowShell title={"Mantenimiento — " + label}
      toolbar={<>
        <button className={btnPrimary}><Plus className="h-3.5 w-3.5" />Nuevo</button>
        <button className={btn}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Trash2 className="h-3.5 w-3.5" />Eliminar</button>
        <button className={btn}><Search className="h-3.5 w-3.5" />Buscar</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
        <span className="ml-auto text-[11px] text-slate-500">Registros: <b>—</b></span>
      </>}>
      <div className="grid grid-cols-4 gap-3 mb-3">
        <Field label="Código"><input className={inp} /></Field>
        <Field label={label} className="col-span-2"><input className={inp} placeholder={"Descripción de " + label} /></Field>
        <Field label="Estado"><select className={inp}><option>Activo</option><option>Inactivo</option></select></Field>
      </div>
      <DataTable columns={columns} rows={10} />
    </WindowShell>
  );
}

// ============= MACRO 6 · LOGUEO =============
function CerrarSesion() {
  return (
    <WindowShell title="Cerrar Sesión">
      <div className="max-w-md mx-auto mt-6 p-6 border border-slate-300 rounded bg-slate-50">
        <div className="text-center text-[13px] text-slate-700 mb-4">¿Está seguro que desea cerrar la sesión actual? Se destruirá el token de autenticación y volverá a la pantalla de Login.</div>
        <div className="flex gap-2 justify-center">
          <button className={btnPrimary}>Sí, cerrar sesión</button>
          <button className={btn}>Cancelar</button>
        </div>
      </div>
    </WindowShell>
  );
}

function CambiarContrasena() {
  return (
    <WindowShell title="Cambiar Contraseña"
      toolbar={<><button className={btnPrimary}><Save className="h-3.5 w-3.5" />Actualizar</button></>}>
      <div className="max-w-md mx-auto mt-4 space-y-3">
        <Field label="Contraseña actual"><input className={inp} type="password" /></Field>
        <Field label="Nueva contraseña"><input className={inp} type="password" /></Field>
        <Field label="Confirmar nueva contraseña"><input className={inp} type="password" /></Field>
        <div className="text-[10.5px] text-slate-500 pt-1">Mínimo 8 caracteres, incluir mayúscula, minúscula, número y carácter especial.</div>
      </div>
    </WindowShell>
  );
}

function CambiarEmpresa() {
  return (
    <WindowShell title="Cambiar Empresa / Sucursal Fiscal"
      toolbar={<><button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Cambiar</button></>}>
      <div className="max-w-md mx-auto mt-4 space-y-3">
        <Field label="Empresa actual"><input className={inp} defaultValue="C2TECK S.A.C." readOnly /></Field>
        <Field label="Cambiar a">
          <select className={inp}>
            <option>C2TECK S.A.C.</option>
            <option>C2TECK Holding</option>
            <option>Sucursal Norte</option>
            <option>Sucursal Sur</option>
          </select>
        </Field>
        <Field label="Sede / Locación">
          <select className={inp}><option>Central</option><option>Mina 1</option><option>Taller</option></select>
        </Field>
      </div>
    </WindowShell>
  );
}

// ============= MACRO 6 · ADMINISTRACIÓN =============
function UsuariosAdmin() {
  return (
    <WindowShell title="Usuarios — Administración"
      toolbar={<>
        <button className={btnPrimary}><Plus className="h-3.5 w-3.5" />Nuevo usuario</button>
        <button className={btn}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Trash2 className="h-3.5 w-3.5" />Desactivar</button>
      </>}>
      <div className="grid grid-cols-4 gap-3 mb-3">
        <Field label="Usuario"><input className={inp} /></Field>
        <Field label="Nombre completo" className="col-span-2"><input className={inp} /></Field>
        <Field label="Perfil"><select className={inp}><option>Administrador</option><option>Vendedor</option><option>Almacenero</option><option>Contador</option></select></Field>
        <Field label="Email"><input className={inp} type="email" /></Field>
        <Field label="DNI"><input className={inp} /></Field>
        <Field label="Sede"><select className={inp}><option>Central</option><option>Norte</option></select></Field>
        <Field label="Estado"><select className={inp}><option>Activo</option><option>Bloqueado</option></select></Field>
      </div>
      <DataTable columns={["Usuario", "Nombre", "Perfil", "Sede", "Último acceso", "Estado"]} rows={10} />
    </WindowShell>
  );
}

function Perfiles() {
  return (
    <WindowShell title="Perfiles — Permisos Granulares"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar permisos</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nuevo perfil</button>
      </>}>
      <div className="grid grid-cols-3 gap-3 mb-3">
        <Field label="Perfil"><select className={inp}><option>Administrador</option><option>Vendedor</option><option>Almacenero</option></select></Field>
        <Field label="Descripción" className="col-span-2"><input className={inp} /></Field>
      </div>
      <DataTable columns={["Módulo", "Pestaña", "Lectura", "Escritura", "Aprobar", "Sin acceso"]} rows={10} />
    </WindowShell>
  );
}

function Sesiones() {
  return (
    <WindowShell title="Sesiones activas — Auditoría"
      toolbar={<>
        <button className={btn}><RefreshCw className="h-3.5 w-3.5" />Refrescar</button>
        <button className={btnPrimary}><X className="h-3.5 w-3.5" />Cerrar sesión remota</button>
      </>}>
      <DataTable columns={["Usuario", "IP", "Equipo", "Inicio sesión", "Última acción", "Módulo", "Estado"]} rows={12} />
    </WindowShell>
  );
}

function AtenderSolicitud() {
  return (
    <WindowShell title="Atender Solicitudes de Acceso"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Aprobar</button>
        <button className={btn}><X className="h-3.5 w-3.5" />Rechazar</button>
      </>}>
      <DataTable columns={["Fecha", "Usuario", "Solicitud", "Módulo", "Solicitado a", "Estado"]} rows={8} />
    </WindowShell>
  );
}

function EncuestaWin({ title }: { title: string }) {
  return (
    <WindowShell title={title + " — Clima Laboral / Satisfacción"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Send className="h-3.5 w-3.5" />Enviar</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Encuesta" className="col-span-2"><input className={inp} /></Field>
        <Field label="Público"><select className={inp}><option>Colaboradores</option><option>Clientes internos</option></select></Field>
        <Field label="Periodo"><input className={inp} placeholder="2026-Q3" /></Field>
      </div>
      <div className="mt-3"><DataTable columns={["#", "Pregunta", "Tipo", "Escala", "Obligatoria"]} rows={6} /></div>
    </WindowShell>
  );
}

function ComputadoraAsignar() {
  return (
    <WindowShell title="Asignar Computadora — Inventario TI"
      toolbar={<><button className={btnPrimary}><Save className="h-3.5 w-3.5" />Asignar</button></>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Colaborador" className="col-span-2"><input className={inp} /></Field>
        <Field label="Equipo (Serie)"><input className={inp} /></Field>
        <Field label="Fecha entrega"><input className={inp} type="date" /></Field>
        <Field label="Tipo"><select className={inp}><option>Laptop</option><option>Desktop</option><option>Monitor</option></select></Field>
        <Field label="Licencias"><input className={inp} placeholder="Office, Antivirus…" /></Field>
        <Field label="Estado"><select className={inp}><option>Asignado</option><option>Devuelto</option><option>Baja</option></select></Field>
      </div>
      <div className="mt-3"><DataTable columns={["Fecha", "Colaborador", "Equipo", "Tipo", "Licencias", "Estado"]} rows={6} /></div>
    </WindowShell>
  );
}

function ComputadoraInv() {
  return (
    <WindowShell title="Computadoras — Inventario Informático"
      toolbar={<>
        <button className={btnPrimary}><Plus className="h-3.5 w-3.5" />Nuevo</button>
        <button className={btn}><Save className="h-3.5 w-3.5" />Guardar</button>
      </>}>
      <DataTable columns={["Serie", "Marca", "Modelo", "Procesador", "RAM", "Almacenamiento", "Sede", "Estado"]} rows={10} />
    </WindowShell>
  );
}

function LlamadasWin() {
  return (
    <WindowShell title="Llamadas — Auditoría de Central Telefónica"
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}>
      <div className="grid grid-cols-5 gap-2 mb-3">
        <Field label="Anexo"><input className={inp} /></Field>
        <Field label="Número marcado"><input className={inp} /></Field>
        <Field label="Desde"><input className={inp} type="date" /></Field>
        <Field label="Hasta"><input className={inp} type="date" /></Field>
        <Field label="Tipo"><select className={inp}><option>Todas</option><option>Entrante</option><option>Saliente</option></select></Field>
      </div>
      <DataTable columns={["Fecha", "Hora", "Anexo", "Colaborador", "Nº marcado", "Duración", "Tipo", "Costo"]} rows={10} />
    </WindowShell>
  );
}

function ConfigTabla({ title, columns }: { title: string; columns: string[] }) {
  return (
    <WindowShell title={title + " — Configuración Avanzada"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Plus className="h-3.5 w-3.5" />Nuevo</button>
      </>}>
      <DataTable columns={columns} rows={8} />
    </WindowShell>
  );
}

// ============= MACRO 6 · AYUDA =============
function SolicitudSoporte() {
  return (
    <WindowShell title="Solicitud de Soporte — Ticket TI"
      toolbar={<><button className={btnPrimary}><Send className="h-3.5 w-3.5" />Enviar ticket</button></>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Nº ticket"><input className={inp} defaultValue="TCK-0000" readOnly /></Field>
        <Field label="Prioridad"><select className={inp}><option>Baja</option><option>Media</option><option>Alta</option><option>Crítica</option></select></Field>
        <Field label="Módulo afectado" className="col-span-2"><input className={inp} /></Field>
        <Field label="Asunto" className="col-span-4"><input className={inp} /></Field>
        <Field label="Descripción del problema" className="col-span-4"><textarea className={inp + " h-24 py-1"} /></Field>
        <Field label="Adjuntar captura" className="col-span-2"><input className={inp} type="file" /></Field>
      </div>
    </WindowShell>
  );
}

function Acerca() {
  return (
    <WindowShell title="Acerca de Systeck ERP Pro">
      <div className="max-w-lg mx-auto mt-4 p-5 border border-slate-300 rounded bg-slate-50 space-y-2 text-[12px]">
        <div className="font-display text-2xl font-bold text-[#2A3F55]">Systeck ERP Pro</div>
        <div className="text-slate-600">Versión <b>10.6.3.0</b></div>
        <div className="text-slate-600">Build: 2026.07.08</div>
        <hr className="my-2" />
        <div className="font-semibold text-slate-700">Notas del último parche</div>
        <ul className="list-disc pl-5 text-slate-600 space-y-0.5">
          <li>Nuevo panel de sesiones activas con cierre remoto.</li>
          <li>Mejoras en cálculo de quinta categoría.</li>
          <li>Integración con relojes biométricos de sedes remotas.</li>
        </ul>
        <hr className="my-2" />
        <div className="text-[10.5px] text-slate-500">© 2026 C2TECK S.A.C. — Todos los derechos reservados.</div>
      </div>
    </WindowShell>
  );
}

function InfoCambios() {
  return (
    <WindowShell title="Información de Cambios — Changelog">
      <DataTable columns={["Versión", "Fecha", "Módulo", "Tipo", "Descripción"]} rows={10} />
    </WindowShell>
  );
}

// ---------- Registry ----------
const REGISTRY: Record<string, (label: string) => ReactNode> = {
  // Ventas > Documentos
  "Guía Remisión": () => <GuiaRemision />,
  "Factura": () => <Factura />,
  "Notas": () => <Notas />,
  "Guía Devolución": () => <GuiaDevolucion />,
  "Boleta": () => <Boleta />,
  "Resumen de Boletas": () => <ResumenBoletas />,
  // Pre y Post
  "Cotizaciones": () => <Cotizaciones />,
  "Reclamo Garantía": () => <ReclamoGarantia />,
  "Separar Orden": () => <SepararOrden />,
  "Ordenes Compra": () => <OrdenesCompra />,
  "Actualizar Vendedor": () => <ActualizarVendedor />,
  "Enviar Correos": () => <EnviarCorreos />,
  // Clientes / Requisiciones
  "Cartera": () => <Cartera />,
  "Despacho": () => <Despacho />,
  // Precios
  "Precios Cliente": () => <PreciosManager initial="Precios Cliente" />,
  "Precio Oferta": () => <PreciosManager initial="Precio Oferta" />,
  "Factores Rubros": () => <PreciosManager initial="Factores Rubros" />,
  "Precio Lista": () => <PreciosManager initial="Precio Lista" />,
  "Precio Fabricantes": () => <PreciosManager initial="Precio Fabricantes" />,

  // === CRÉDITOS ===
  "Ctas x Cobrar": () => <CtasXCobrar />,
  "Cuentas x Cobrar": () => <CtasXCobrar />,
  "Anticipos": () => <Anticipos />,
  "Planillas": () => <Planillas />,
  "Letras": () => <Letras />,
  "Créditos": () => <AprobacionCreditos />,
  "Creditos": () => <AprobacionCreditos />,
  "Permiso Usuario": () => <AprobacionCreditos />,
  "Cotiz. Taller": () => <AprobacionCreditos />,
  "Recepcion Doc.": () => <AprobacionCreditos />,
  "Recepción Doc.": () => <AprobacionCreditos />,
  "Saldo Bancos": () => <AprobacionCreditos />,
  "Tipo Cambio Ventas": () => <TipoCambio />,
  "Mantenimiento Tipo de Cambio": () => <TipoCambio />,
  "Renueva Tipo Cambio": () => <TipoCambio />,

  // === ALMACENES ===
  "Doc. Ingresos": () => <DocIngresos />,
  "Chequeo F/I": () => <ChequeoFI />,
  "MTI": () => <TransitoDocs />,
  "Atender OT": () => <AtenderOT />,
  "Datos Despacho Clientes": () => <Despacho />,
  "Doc. Salidas": () => <DocIngresos />,
  "T / I": () => <TransitoDocs />,
  "T/I": () => <TransitoDocs />,
  "Vales / Despachos": () => <AtenderOT />,
  "Productos": () => <Productos />,
  "Act. Min Max": () => <ActMinMax />,
  "Ubicaciones": () => <Ubicaciones />,
  "Transferencias": () => <TransitoDocs />,
  "Compras": () => <TransitoDocs />,
  "Documentos": () => <TransitoDocs />,
  "Anulación en Consulta": () => <TransitoDocs />,

  // === IMPORTACIONES ===
  "Orden Importación": () => <OrdenImportacion />,
  "Orden de Importación": () => <OrdenImportacion />,
  "Embarque": () => <OrdenImportacion />,
  "Internos": () => <OrdenImportacion />,
  "Pedido Interno": () => <OrdenImportacion />,
  "Embarques de Importación": () => <OrdenImportacion />,

  // === ACTIVOS ===
  "Activos Fijos": () => <ActivosFijos />,
  "Reporte Activos Fijos": (label) => <ReporteContainer label={label} />,

  // === COSTOS ===
  "Valorizar F/I": () => <ValorizarFI />,
  "Ajustar Costos": () => <ValorizarFI />,
  "Recalcular": () => <ProcesoLote label="Recalcular Costos" subtitle="Recalcula el costo promedio ponderado de todos los productos del periodo seleccionado." />,
  "Cerrar Mes": () => <ProcesoLote label="Cerrar Mes" subtitle="Congela el mes comercial: bloquea documentos y libera datos para auditoría." />,
  "Trasladar Costos": () => <ProcesoLote label="Trasladar Costos" subtitle="Transfiere costos calculados hacia contabilidad y kardex valorizado." />,
  "Inv. Rotativo": () => <ProcesoLote label="Inventario Rotativo" subtitle="Genera muestras de conteo rotativo por categoría / ubicación." />,
  "Consolidado": () => <ProcesoLote label="Consolidado" subtitle="Consolida movimientos y saldos de todos los almacenes." />,
  "Generar Periodo": () => <ProcesoLote label="Generar Periodo" subtitle="Crea el nuevo periodo contable / comercial." />,

  // === CONTABILIDAD ===
  "Asientos": () => <Asientos />,
  "Movimiento Bancos": () => <MovimientoBancos />,
  "Registro Compra": () => <RegistroCompra />,
  "Recibo Honorario": () => <RegistroCompra />,
  "Diario": () => <ReporteContainer label="Libro Diario" />,
  "Provisional": () => <CajaChica />,
  "Reembolso": () => <CajaChica />,
  "Arqueo Caja": () => <CajaChica />,
  "Cierre Mes": () => <ProcesoLote label="Cierre Mes" subtitle="Cierre contable mensual con validación de saldos cuadrados." />,
  "Cuenta Destino": () => <ProcesoLote label="Cuenta Destino" subtitle="Reasigna asientos entre cuentas contables destino." />,
  "Dif. Tipo Cambio": () => <ProcesoLote label="Diferencia de Tipo de Cambio" subtitle="Calcula pérdidas / ganancias por diferencia en tipo de cambio del periodo." />,
  "Flujo de Caja": () => <FlujoCaja />,
  "Generar TXT Libros": () => <GenerarTXT />,

  // === COMPRAS ===
  "Solicitud de Compra": () => <SolicitudCompra />,
  "Solicitud Compra": () => <SolicitudCompra />,
  "Orden de Compra": () => <OrdenCompra />,
  "Orden Compra": () => <OrdenCompra />,
  "Solicitud Gasto": () => <SolicitudCompra />,
  "Planilla Viático": () => <Viaticos />,
  "Planilla Viáticos": () => <Viaticos />,
  "Tarifas": () => <PreciosManager initial="Precio Lista" />,
  "Cuentas x Pagar": () => <CtasXPagar />,
  "Ctas x Pagar": () => <CtasXPagar />,

  // === SERVICIOS / TALLERES ===
  "Pedir Repuestos": () => <PedirRepuestos />,
  "Solicitud OT": () => <OrdenTrabajo />,
  "OT": () => <OrdenTrabajo />,
  "Orden de Trabajo": () => <OrdenTrabajo />,
  "Marcaciones": () => <Marcaciones title="Marcaciones — OT" />,
  "Pre Marcacion": () => <Marcaciones title="Pre Marcación — OT" />,
  "Pre Marcación": () => <Marcaciones title="Pre Marcación — OT" />,
  "Marcar OT": () => <Marcaciones title="Marcar OT" />,
  "Gastos Reales": () => <OrdenTrabajo />,
  "Orden Reparación": () => <GarantiaWin title="Orden de Reparación" />,
  "Reclamo Cliente": () => <GarantiaWin title="Reclamo Cliente" />,
  "Garantía": () => <GarantiaWin title="Garantía" />,
  "Garantia": () => <GarantiaWin title="Garantía" />,
  "Kilometraje": () => <Kilometraje />,
  "Oficina Usuario": () => <OficinaUsuario />,

  // === RONDAS ===
  "Puntos Control Rutas": () => <PuntosControl title="Puntos de Control" />,
  "Rondas": () => <PuntosControl title="Rondas" />,
  "Ruteador Rutas": () => <PuntosControl title="Ruteador de Rutas" />,

  // === TELEFONÍA ===
  "Modelos": () => <TelefoniaInv title="Modelos" />,
  "Planes": () => <TelefoniaInv title="Planes" />,
  "Líneas": () => <TelefoniaInv title="Líneas" />,
  "Lineas": () => <TelefoniaInv title="Líneas" />,
  "Equipos": () => <TelefoniaInv title="Equipos" />,
  "Asigna Persona": () => <AsignaPersona />,

  // === PERSONAL / PLANILLAS ===
  "Faltas": () => <PersonalTiempo title="Faltas" />,
  "Asigna H. Extra": () => <PersonalTiempo title="Asignación H. Extra" />,
  "Horas Extras": () => <PersonalTiempo title="Horas Extras" />,
  "Descuentos": () => <PersonalTiempo title="Descuentos" />,
  "Recursos": () => <PersonalTiempo title="Recursos" />,
  "Marcación Online": () => <MarcacionOnline />,
  "Marcacion Online": () => <MarcacionOnline />,
  "Marcación": () => <MarcacionOnline />,
  "Marcacion": () => <MarcacionOnline />,
  "Horarios": () => <PersonalTiempo title="Horarios / Turnos" />,
  "Ingresos": () => <PersonalTiempo title="Ingresos" />,
  "Jefe Área": () => <PersonalTiempo title="Jefe de Área" />,
  "Jefe Area": () => <PersonalTiempo title="Jefe de Área" />,
  "Cronograma Mina": () => <PersonalTiempo title="Cronograma Mina" />,
  "Ficha General": () => <FichaGeneral />,
  "Capacitaciones": () => <CapacitacionesWin title="Capacitaciones" />,
  "Vacaciones": () => <CapacitacionesWin title="Vacaciones" />,
  "Evaluaciones": () => <CapacitacionesWin title="Evaluaciones de Desempeño" />,
  "Quinta Categoría": () => <PlanillaSueldos />,
  "Quinta Categoria": () => <PlanillaSueldos />,
  "Planilla Sueldos": () => <PlanillaSueldos />,
  "Admin. Lector": () => <MarcacionOnline />,
  "Procesar Marcas": () => <ProcesarMarcas />,
  "Comunicaciones": () => <EnviarCorreos />,

  // === MACRO 6 · TABLAS MAESTRAS (CRUD) ===
  "Clientes": () => <MantenimientoCRUD label="Clientes" columns={["Código", "Razón Social / Nombres", "Doc.", "Nº Doc.", "Dirección", "Teléfono", "Estado"]} />,
  "Modelos ": () => <MantenimientoCRUD label="Modelos" columns={["Código", "Modelo", "Marca", "Estado"]} />,
  "Categorías": () => <MantenimientoCRUD label="Categorías" columns={["Código", "Categoría", "Rubro", "Estado"]} />,
  "Categorias": () => <MantenimientoCRUD label="Categorías" columns={["Código", "Categoría", "Rubro", "Estado"]} />,
  "Partidas": () => <MantenimientoCRUD label="Partidas Arancelarias" columns={["Partida", "Descripción", "Ad Valorem", "Estado"]} />,
  "Marcas": () => <MantenimientoCRUD label="Marcas" columns={["Código", "Marca", "Origen", "Estado"]} />,
  "Plantillas Repuestos": () => <MantenimientoCRUD label="Plantillas de Repuestos" columns={["Código", "Plantilla", "Modelo", "Nº items", "Estado"]} />,
  "Vehículos": () => <MantenimientoCRUD label="Vehículos" columns={["Placa", "Marca", "Modelo", "Año", "Cliente", "Estado"]} />,
  "Vehiculos": () => <MantenimientoCRUD label="Vehículos" columns={["Placa", "Marca", "Modelo", "Año", "Cliente", "Estado"]} />,
  "Proveedores": () => <MantenimientoCRUD label="Proveedores" columns={["RUC", "Razón Social", "Dirección", "Contacto", "Teléfono", "Estado"]} />,
  "Cuenta Contable": () => <MantenimientoCRUD label="Cuentas Contables" columns={["Cuenta", "Descripción", "Naturaleza", "Nivel", "Estado"]} />,
  "Cuentas Destino": () => <MantenimientoCRUD label="Cuentas Destino" columns={["Cuenta", "Destino", "Módulo", "Estado"]} />,
  "Rubro Planilla": () => <MantenimientoCRUD label="Rubros de Planilla" columns={["Código", "Rubro", "Tipo", "Afecta", "Estado"]} />,
  "Horarios ": () => <MantenimientoCRUD label="Horarios" columns={["Código", "Horario", "Entrada", "Salida", "Tolerancia", "Estado"]} />,
  "Feriados": () => <MantenimientoCRUD label="Feriados" columns={["Fecha", "Descripción", "Tipo", "Ámbito", "Estado"]} />,
  "AFP": () => <MantenimientoCRUD label="AFP" columns={["Código", "AFP", "Comisión %", "Prima %", "Aporte %", "Estado"]} />,
  "Cargos": () => <MantenimientoCRUD label="Cargos" columns={["Código", "Cargo", "Área", "Nivel", "Estado"]} />,
  "Áreas": () => <MantenimientoCRUD label="Áreas" columns={["Código", "Área", "Responsable", "Estado"]} />,
  "Areas": () => <MantenimientoCRUD label="Áreas" columns={["Código", "Área", "Responsable", "Estado"]} />,
  "Motivos Faltas": () => <MantenimientoCRUD label="Motivos de Faltas" columns={["Código", "Motivo", "Justificada", "Descuenta", "Estado"]} />,
  "Equipo Lector": () => <MantenimientoCRUD label="Equipos Lectores (Biométricos)" columns={["Serie", "Marca", "IP", "Sede", "Estado"]} />,
  "Ruteador": () => <MantenimientoCRUD label="Ruteadores de Rondas" columns={["Código", "Ruteador", "Zona", "Estado"]} />,
  "Rutas": () => <MantenimientoCRUD label="Rutas" columns={["Código", "Ruta", "Zona", "Nº puntos", "Estado"]} />,
  "Puntos Control": () => <MantenimientoCRUD label="Puntos de Control" columns={["Código", "Punto", "Dirección", "Ruta", "Estado"]} />,

  // === MACRO 6 · LOGUEO ===
  "Cerrar Sesión": () => <CerrarSesion />,
  "Cerrar Sesion": () => <CerrarSesion />,
  "Cambiar Contraseña": () => <CambiarContrasena />,
  "Cambiar Contrasena": () => <CambiarContrasena />,
  "Cambiar Empresa": () => <CambiarEmpresa />,

  // === MACRO 6 · ADMINISTRACIÓN ===
  "Usuarios": () => <UsuariosAdmin />,
  "Perfiles": () => <Perfiles />,
  "Sesiones": () => <Sesiones />,
  "Atender Solicitud": () => <AtenderSolicitud />,
  "Indicadores": () => <EncuestaWin title="Indicadores de Encuesta" />,
  "Encuesta": () => <EncuestaWin title="Encuesta" />,
  "Resultado": () => <ReporteContainer label="Resultados de Encuesta" />,
  "Asignar Computadora": () => <ComputadoraAsignar />,
  "Computadora": () => <ComputadoraInv />,
  "Llamadas": () => <LlamadasWin />,
  "Equipos Marcación Personal": () => <ConfigTabla title="Equipos Marcación Personal" columns={["Serie", "IP", "Sede", "Modelo", "Estado"]} />,
  "Empresas": () => <ConfigTabla title="Empresas" columns={["RUC", "Razón Social", "Sucursal", "Régimen", "Estado"]} />,
  "Series Documentos": () => <ConfigTabla title="Series de Documentos" columns={["Tipo Doc.", "Serie", "Correlativo", "Sede", "Estado"]} />,
  "Locaciones": () => <ConfigTabla title="Locaciones / Sedes" columns={["Código", "Locación", "Dirección", "Ubigeo", "Estado"]} />,
  "Rubros de Productos": () => <ConfigTabla title="Rubros de Productos" columns={["Código", "Rubro", "Cuenta contable", "Estado"]} />,
  "Parámetros Locaciones": () => <ConfigTabla title="Parámetros de Locaciones" columns={["Locación", "Parámetro", "Valor", "Descripción"]} />,
  "Parametros Locaciones": () => <ConfigTabla title="Parámetros de Locaciones" columns={["Locación", "Parámetro", "Valor", "Descripción"]} />,
  "Parámetros Planilla Sueldos": () => <ConfigTabla title="Parámetros Planilla de Sueldos" columns={["Parámetro", "Valor", "Vigente desde", "Descripción"]} />,
  "Parametros Planilla Sueldos": () => <ConfigTabla title="Parámetros Planilla de Sueldos" columns={["Parámetro", "Valor", "Vigente desde", "Descripción"]} />,
  "Rubros x Empresa": () => <ConfigTabla title="Rubros por Empresa" columns={["Empresa", "Rubro", "Cuenta", "Estado"]} />,

  // === MACRO 6 · AYUDA ===
  "Solicitud": () => <SolicitudSoporte />,
  "Información Cambios": () => <InfoCambios />,
  "Informacion Cambios": () => <InfoCambios />,
  "Acerca": () => <Acerca />,
};

// Reports of Ventas
const VENTAS_REPORTES = new Set([
  "Registro de Venta", "Acumulada", "Mensuales x Cliente", "Reclamos", "Consignaciones",
  "Presupuesto Venta", "Detalle", "G/R Pendiente", "Vale Requisición", "Detalle Descuento",
  "Órdenes Compra", "Guías Remisión", "Comisiones",
]);

// Reports of Créditos
const CREDITOS_REPORTES = new Set([
  "Cuentas Corrientes", "Documentos Emitidos", "Notas Débito/Crédito", "Notas Débito / Crédito",
  "Vista Cobrador", "Clientes", "Diario de Pagos", "Letras Aceptadas",
  "Vencimientos",
]);

// Reports of Almacenes
const ALMACEN_REPORTES = new Set([
  "Inventario", "Movimientos", "Toma de Inventario", "Vale Materiales",
  "Inv. Perm. Valorizado", "Sin Movimiento",
]);

// Reports of Costos
const COSTOS_REPORTES = new Set([
  "Actualizar Costos", "Diario de Almacén", "Stock Valorizado", "Kardex", "Condensados",
  "Resumen General", "GMROI", "Cuadrar Cierre", "Costo de Venta", "Motores", "Sobregiro",
]);

// Reports of Contabilidad
const CONTABILIDAD_REPORTES = new Set([
  "Reembolsos", "Ctas Ctes", "Mayor Auxiliar", "Cheques Girados",
  "Libros Oficiales", "Ctas Ctes Pendiente", "Estado Financiero", "Provisionales",
]);

// Reports of Compras
const COMPRAS_REPORTES = new Set([
  "Ordenes Compra", "Pagos Cuentas x Pagar", "Solicitud Gastos",
  "Cuentas x Pagar Por Unidad",
]);

// Reports of Servicios / Talleres
const SERVICIOS_REPORTES = new Set([
  "Actividades", "Plantilla", "Productividad", "Programación", "Programacion", "Tablero",
  "Movimiento Repuestos", "Horas Motor", "Seguimiento", "Generar Pedido", "Horas Escalon", "Horas Escalón",
  "Motores", "Repuestos", "Gastos Detallados", "Horas de Trabajo", "Gastos Por Rubros",
  "Liquidación x Garantía", "Liquidacion x Garantia", "Solicitud Garantía", "Solicitud Garantia",
  "Horas Muertas", "Pendiente Facturación", "Pendiente Facturacion", "Tiempo Reparación", "Tiempo Reparacion",
  "Proyección", "Proyeccion",
]);

// Reports of Personal / RRHH
const PERSONAL_REPORTES = new Set([
  "Tardanzas", "Contratos", "Asistencia", "Onomásticos", "Onomasticos", "Asignación Horario", "Asignacion Horario",
]);

export function renderWindow(label: string): ReactNode {
  const normalizedLabel = normalizeWindowLabel(label);
  if (REGISTRY[normalizedLabel]) return REGISTRY[normalizedLabel](normalizedLabel);
  if (VENTAS_REPORTES.has(normalizedLabel)) return <ReporteContainer label={normalizedLabel} />;
  if (CREDITOS_REPORTES.has(normalizedLabel)) return <ReporteContainer label={normalizedLabel} />;
  if (ALMACEN_REPORTES.has(normalizedLabel)) return <ReporteContainer label={normalizedLabel} />;
  if (COSTOS_REPORTES.has(normalizedLabel)) return <ReporteContainer label={normalizedLabel} />;
  if (CONTABILIDAD_REPORTES.has(normalizedLabel)) return <ReporteContainer label={normalizedLabel} />;
  if (COMPRAS_REPORTES.has(normalizedLabel)) return <ReporteContainer label={normalizedLabel} />;
  if (SERVICIOS_REPORTES.has(normalizedLabel)) return <ReporteContainer label={normalizedLabel} />;
  if (PERSONAL_REPORTES.has(normalizedLabel)) return <ReporteContainer label={normalizedLabel} />;
  return <GenericWindow label={normalizedLabel} />;
}


// ---------- MDI floating workspace ----------
export function Workspace() {
  const { windows, active, close, focus, move, toggleMaximize, minimize, restore } = useWindows();
  const containerRef = useRef<HTMLDivElement>(null);

  const visible = windows.filter(w => !w.isMinimized);
  const minimized = windows.filter(w => w.isMinimized);

  return (
    <div
      ref={containerRef}
      className="relative flex-1 bg-slate-200/70 overflow-visible z-20 min-h-0"
      style={{ flex: 1, backgroundImage: "radial-gradient(circle at 1px 1px, rgba(62,91,122,0.10) 1px, transparent 0)", backgroundSize: "22px 22px" }}
    >
      {/* Empty-state watermark */}
      {windows.length === 0 && (
        <div className="absolute inset-0 grid place-items-center select-none pointer-events-none">
          <div className="text-center">
            <div className="font-display text-[140px] leading-none font-bold bg-gradient-to-b from-[#7FA8D6] to-[#3E5B7A] bg-clip-text text-transparent tracking-tight">C2TECK</div>
            <div className="text-slate-400 text-sm mt-2 tracking-widest">S.A.C.</div>
            <div className="text-slate-500 text-[11px] mt-4">Haz clic en cualquier botón del ribbon para abrir una ventana flotante</div>
          </div>
        </div>
      )}

      {/* Floating windows */}
      {visible.map(w => (
        <FloatingWindow
          key={w.id}
          win={w}
          isActive={active === w.id}
          containerRef={containerRef}
          onFocus={() => focus(w.id)}
          onClose={() => close(w.id)}
          onMove={(pos) => move(w.id, pos)}
          onToggleMaximize={() => toggleMaximize(w.id)}
          onMinimize={() => minimize(w.id)}
        />
      ))}

      {/* Taskbar for minimized windows */}
      {minimized.length > 0 && (
        <div className="absolute bottom-0 left-0 right-0 h-8 bg-gradient-to-t from-[#2A3F55] to-[#3E5B7A] border-t border-slate-900/40 flex items-center gap-1 px-2 z-[9999]">
          {minimized.map(w => (
            <button
              key={w.id}
              onClick={() => restore(w.id)}
              className="h-6 px-2 max-w-[180px] flex items-center gap-1.5 text-[11px] text-white bg-white/10 hover:bg-white/20 rounded-sm border border-white/10 truncate"
              title={w.label}
            >
              <Square className="h-2.5 w-2.5 shrink-0" />
              <span className="truncate">{w.label}</span>
            </button>
          ))}
        </div>
      )}
    </div>
  );
}

type FWProps = {
  win: OpenWindow;
  isActive: boolean;
  containerRef: RefObject<HTMLDivElement | null>;
  onFocus: () => void;
  onClose: () => void;
  onMove: (pos: WindowPos) => void;
  onToggleMaximize: () => void;
  onMinimize: () => void;
};

function FloatingWindow({ win, isActive, containerRef, onFocus, onClose, onMove, onToggleMaximize, onMinimize }: FWProps) {
  const dragRef = useRef<{ startX: number; startY: number; origX: number; origY: number } | null>(null);

  const onDragStart = (e: ReactMouseEvent) => {
    if (win.isMaximized) return;
    if ((e.target as HTMLElement).closest("[data-window-control]")) return;
    onFocus();
    dragRef.current = {
      startX: e.clientX, startY: e.clientY,
      origX: win.position.x, origY: win.position.y,
    };
    e.preventDefault();
  };

  useEffect(() => {
    const onMouseMove = (e: MouseEvent) => {
      const d = dragRef.current;
      if (!d) return;
      const dx = e.clientX - d.startX;
      const dy = e.clientY - d.startY;
      onMove({ x: d.origX + dx, y: d.origY + dy });
    };
    const onMouseUp = () => { dragRef.current = null; };
    window.addEventListener("mousemove", onMouseMove);
    window.addEventListener("mouseup", onMouseUp);
    return () => {
      window.removeEventListener("mousemove", onMouseMove);
      window.removeEventListener("mouseup", onMouseUp);
    };
  }, [onMove]);

  const style: CSSProperties = win.isMaximized
    ? { left: 0, top: 0, right: 0, bottom: 0, width: "auto", height: "auto", zIndex: win.zIndex, position: "fixed" }
    : { left: win.position.x, top: win.position.y, width: win.size.w, height: win.size.h, zIndex: win.zIndex, position: "fixed" };

  return (
    <div
      className={[
        "flex flex-col bg-white border border-slate-400/60 shadow-2xl",
        win.isMaximized ? "rounded-none" : "rounded-lg",
        isActive
          ? "ring-2 ring-[#3B5998]/40"
          : "ring-1 ring-slate-300/40",
      ].join(" ")}
      style={style}
      onMouseDown={onFocus}
    >
      {/* Title bar */}
      <div
        onMouseDown={onDragStart}
        onDoubleClick={onToggleMaximize}
        className={[
          "h-9 px-3 flex items-center justify-between select-none shrink-0",
          win.isMaximized ? "cursor-default" : "cursor-move",
          isActive
            ? "bg-gradient-to-b from-[#4C6E93] to-[#2A3F55] text-white"
            : "bg-gradient-to-b from-slate-300 to-slate-400 text-slate-800",
        ].join(" ")}
      >
        <div className="flex items-center gap-2 min-w-0">
          <div className={["h-4 w-4 rounded-sm grid place-items-center shrink-0", isActive ? "bg-white/20" : "bg-white/40"].join(" ")}>
            <Square className="h-2.5 w-2.5" />
          </div>
          <span className="text-[12px] font-semibold truncate">{win.label}</span>
        </div>
        <div className="flex items-center gap-0.5" data-window-control>
          <button
            onClick={(e) => { e.stopPropagation(); onMinimize(); }}
            className="h-6 w-8 grid place-items-center rounded hover:bg-white/20"
            title="Minimizar"
          >
            <Minus className="h-3.5 w-3.5" />
          </button>
          <button
            onClick={(e) => { e.stopPropagation(); onToggleMaximize(); }}
            className="h-6 w-8 grid place-items-center rounded hover:bg-white/20"
            title={win.isMaximized ? "Restaurar" : "Maximizar"}
          >
            {win.isMaximized ? <Minimize2 className="h-3.5 w-3.5" /> : <Maximize2 className="h-3.5 w-3.5" />}
          </button>
          <button
            onClick={(e) => { e.stopPropagation(); onClose(); }}
            className="h-6 w-8 grid place-items-center rounded hover:bg-red-600 hover:text-white"
            title="Cerrar"
          >
            <X className="h-3.5 w-3.5" />
          </button>
        </div>
      </div>

      {/* Body */}
      <div className="flex-1 overflow-auto bg-white">
        {renderWindow(win.label)}
      </div>
    </div>
  );
}
