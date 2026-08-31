import { useCallback, useEffect, useMemo, useState, type ReactNode } from "react";
import {
  Check,
  ChevronRight,
  CircleAlert,
  ClipboardList,
  FileText,
  Filter,
  MapPin,
  Package,
  Pencil,
  Plus,
  Printer,
  RefreshCw,
  Save,
  Search,
  Trash2,
  Truck,
  Wallet,
  X,
} from "lucide-react";
import { toast } from "sonner";
import {
  fetchSigecoomClients,
  fetchSigecoomLocations,
  getSigecoomClient,
  type Location,
  type SigecoomClient,
} from "@/lib/sigecoom-api";

const inp =
  "h-8 w-full rounded-sm border border-slate-300 bg-white px-2 text-[11px] text-slate-800 outline-none transition focus:border-sky-500 focus:ring-2 focus:ring-sky-200";
const btn =
  "inline-flex items-center gap-1.5 rounded-sm border border-slate-300 bg-slate-100 px-2.5 py-1.5 text-[11px] font-medium text-slate-700 transition hover:bg-slate-200 disabled:cursor-not-allowed disabled:opacity-50";
const btnPrimary =
  "inline-flex items-center gap-1.5 rounded-sm border border-sky-700 bg-sky-700 px-2.5 py-1.5 text-[11px] font-medium text-white transition hover:bg-sky-800 disabled:cursor-not-allowed disabled:opacity-50";
const panel = "rounded-sm border border-slate-300 bg-white shadow-sm";

const NOW = new Date();

type GuiaDevolucionEstado = "GENERADO" | "IMPRESO" | "PROCESADO" | "ANULADO" | "PENDIENTE";

type GuiaDevolucionRow = {
  id: number;
  numero: string;
  fecha: string;
  cliente: string;
  ruc: string;
  tipoDoc: string;
  referencia: string;
  moneda: string;
  total: number;
  estado: GuiaDevolucionEstado;
  motivo: string;
  ubicacion: string;
};

type GuiaDevolucionDet = {
  id: number;
  producto: string;
  unidad: string;
  cantidad: number;
  precio: number;
  descuento: number;
  importe: number;
};

type GuiaDevolucionFormState = {
  id: number | null;
  numero: string;
  fecha: string;
  clienteId: string;
  clienteNombre: string;
  ruc: string;
  tipoDoc: string;
  referencia: string;
  ubicacionId: string;
  ubicacionNombre: string;
  observacion: string;
  motivo: string;
  estado: GuiaDevolucionEstado;
  moneda: string;
};

const MOCK_GUIAS: GuiaDevolucionRow[] = [
  {
    id: 1,
    numero: "GD-2026-0001",
    fecha: "2026-08-18",
    cliente: "ACME DISTRIBUCIONES SAC",
    ruc: "20456789011",
    tipoDoc: "FACTURA",
    referencia: "F001-000102",
    moneda: "PEN",
    total: 1550.0,
    estado: "GENERADO",
    motivo: "Devolución por producto vencido",
    ubicacion: "LIMA - SAN ISIDRO",
  },
  {
    id: 2,
    numero: "GD-2026-0002",
    fecha: "2026-08-20",
    cliente: "MIRAFLORES COMERCIAL S.A.C.",
    ruc: "20567890123",
    tipoDoc: "BOLETA",
    referencia: "B001-000832",
    moneda: "PEN",
    total: 985.5,
    estado: "IMPRESO",
    motivo: "Devolución por falta de marca",
    ubicacion: "LIMA - MIRAFLORES",
  },
  {
    id: 3,
    numero: "GD-2026-0003",
    fecha: "2026-08-22",
    cliente: "NOVA LOGISTICA E.I.R.L.",
    ruc: "20678901234",
    tipoDoc: "FACTURA",
    referencia: "F001-000221",
    moneda: "USD",
    total: 2260.0,
    estado: "PROCESADO",
    motivo: "Devolución por revisión de calidad",
    ubicacion: "AREQUIPA - CERRO COLORADO",
  },
  {
    id: 4,
    numero: "GD-2026-0004",
    fecha: "2026-08-24",
    cliente: "DISTRIBUIDORA SOLAR SRL",
    ruc: "20123456789",
    tipoDoc: "NOTA DE CRÉDITO",
    referencia: "NC-000900",
    moneda: "PEN",
    total: 430.0,
    estado: "ANULADO",
    motivo: "Anulada por duplicidad",
    ubicacion: "TRUJILLO - LA LIBERTAD",
  },
];

const MOCK_DETALLES: Record<number, GuiaDevolucionDet[]> = {
  1: [
    { id: 1, producto: "CINTA ADSIVA 2P 5M", unidad: "UND", cantidad: 8, precio: 55, descuento: 0, importe: 440 },
    { id: 2, producto: "TUBO PVC 1/2", unidad: "M", cantidad: 22, precio: 18, descuento: 5, importe: 375 },
    { id: 3, producto: "PINTURA ROJA 20L", unidad: "UND", cantidad: 3, precio: 245, descuento: 0, importe: 735 },
  ],
  2: [
    { id: 1, producto: "BOLSA DE POLIPROPILENO", unidad: "UND", cantidad: 12, precio: 28, descuento: 0, importe: 336 },
    { id: 2, producto: "CABLE 3X1.5", unidad: "M", cantidad: 50, precio: 12.9, descuento: 2, importe: 632.5 },
  ],
  3: [
    { id: 1, producto: "MOTOR 220V 2HP", unidad: "UND", cantidad: 2, precio: 840, descuento: 0, importe: 1680 },
    { id: 2, producto: "KIT DE ACCESORIOS", unidad: "UND", cantidad: 1, precio: 580, descuento: 0, importe: 580 },
  ],
  4: [
    { id: 1, producto: "PANEL FIJO 120W", unidad: "UND", cantidad: 1, precio: 430, descuento: 0, importe: 430 },
  ],
};

const ESTADO_COLORS: Record<string, string> = {
  GENERADO: "border-blue-200 bg-blue-50 text-blue-700",
  IMPRESO: "border-amber-200 bg-amber-50 text-amber-700",
  PROCESADO: "border-emerald-200 bg-emerald-50 text-emerald-700",
  ANULADO: "border-red-200 bg-red-50 text-red-700",
  PENDIENTE: "border-slate-200 bg-slate-100 text-slate-600",
};

function StateBadge({ estado }: { estado: string }) {
  const cls = ESTADO_COLORS[estado] ?? "border-slate-200 bg-slate-100 text-slate-600";
  return <span className={`inline-flex rounded border px-1.5 py-0.5 text-[10px] font-bold ${cls}`}>{estado}</span>;
}

function Field({ label, children, className = "" }: { label: string; children: ReactNode; className?: string }) {
  return (
    <label className={`flex flex-col gap-1 ${className}`}>
      <span className="text-[10.5px] font-semibold uppercase tracking-[0.04em] text-slate-600">{label}</span>
      {children}
    </label>
  );
}

function formatMoney(value: number) {
  return new Intl.NumberFormat("es-PE", {
    style: "currency",
    currency: "PEN",
    minimumFractionDigits: 2,
  }).format(value);
}

function ClienteLookupModal({
  onClose,
  onSelect,
}: {
  onClose: () => void;
  onSelect: (c: SigecoomClient) => void;
}) {
  const [rows, setRows] = useState<SigecoomClient[]>([]);
  const [loading, setLoading] = useState(true);
  const [desc, setDesc] = useState("");
  const [doc, setDoc] = useState("");
  const [selectedId, setSelectedId] = useState<string | null>(null);

  useEffect(() => {
    let mounted = true;
    fetchSigecoomClients(200)
      .then((data) => {
        if (!mounted) return;
        setRows(data);
      })
      .catch(() => toast.error("No se pudo cargar la lista de clientes"))
      .finally(() => mounted && setLoading(false));

    return () => {
      mounted = false;
    };
  }, []);

  const filtered = rows.filter((row) => {
    const byDesc = !desc || row.name.toLowerCase().includes(desc.toLowerCase());
    const byDoc = !doc || (row.ruc ?? "").toLowerCase().includes(doc.toLowerCase());
    return byDesc && byDoc;
  });

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/30 backdrop-blur-[1px]">
      <div className="w-[820px] overflow-hidden rounded-sm border border-slate-400 bg-[#f4f7fb] shadow-2xl">
        <div className="flex items-center justify-between bg-gradient-to-r from-slate-700 to-slate-800 px-3 py-2 text-[12px] font-semibold text-white">
          <span>Buscar cliente</span>
          <button onClick={onClose} className="rounded-sm p-1 hover:bg-white/10">
            <X className="h-3.5 w-3.5" />
          </button>
        </div>

        <div className="border-b border-slate-300 bg-[#edf2f8] p-2">
          <div className="mb-2 text-[11px] font-semibold uppercase tracking-[0.04em] text-slate-700">Búsqueda</div>
          <div className="grid grid-cols-[1fr_180px_110px] gap-2">
            <div>
              <div className="mb-1 text-[10.5px] font-semibold text-slate-600">Razón social</div>
              <input className={inp} value={desc} onChange={(e) => setDesc(e.target.value)} />
            </div>
            <div>
              <div className="mb-1 text-[10.5px] font-semibold text-slate-600">RUC/DNI</div>
              <input className={inp} value={doc} onChange={(e) => setDoc(e.target.value)} />
            </div>
            <div className="self-end">
              <button className={`${btn} w-full justify-center`}>
                <Search className="h-3.5 w-3.5" />
                Buscar
              </button>
            </div>
          </div>
        </div>

        <div className="p-2">
          <div className="max-h-[340px] overflow-auto border border-slate-300 bg-white">
            <table className="w-full text-[11px]">
              <thead className="sticky top-0 bg-gradient-to-b from-slate-200 to-slate-100">
                <tr>
                  <th className="border-r border-slate-300 px-2 py-1 text-left font-semibold text-slate-700">Código</th>
                  <th className="border-r border-slate-300 px-2 py-1 text-left font-semibold text-slate-700">Cliente</th>
                  <th className="px-2 py-1 text-left font-semibold text-slate-700">RUC</th>
                </tr>
              </thead>
              <tbody>
                {loading ? (
                  <tr>
                    <td colSpan={3} className="px-2 py-5 text-center text-slate-500">
                      Cargando clientes...
                    </td>
                  </tr>
                ) : filtered.length === 0 ? (
                  <tr>
                    <td colSpan={3} className="px-2 py-5 text-center text-slate-500">
                      Sin resultados
                    </td>
                  </tr>
                ) : (
                  filtered.map((row) => {
                    const isSelected = row.id === selectedId;
                    return (
                      <tr
                        key={row.id}
                        className={`cursor-pointer border-b border-slate-200 ${isSelected ? "bg-sky-100" : "bg-white hover:bg-slate-50"}`}
                        onClick={() => setSelectedId(row.id)}
                        onDoubleClick={() => onSelect(row)}
                      >
                        <td className="border-r border-slate-200 px-2 py-1 font-mono">{row.id}</td>
                        <td className="border-r border-slate-200 px-2 py-1">{row.name}</td>
                        <td className="px-2 py-1 font-mono">{row.ruc ?? "-"}</td>
                      </tr>
                    );
                  })
                )}
              </tbody>
            </table>
          </div>
        </div>

        <div className="flex items-center justify-between border-t border-slate-300 bg-[#edf2f8] px-3 py-2">
          <span className="text-[11px] text-slate-600">Registros: {filtered.length}</span>
          <div className="flex gap-2">
            <button className={btn} onClick={onClose}>
              <X className="h-3.5 w-3.5" />
              Cerrar
            </button>
            <button
              className={btnPrimary}
              onClick={() => {
                const item = filtered.find((row) => row.id === selectedId);
                if (item) onSelect(item);
              }}
              disabled={!selectedId}
            >
              <Check className="h-3.5 w-3.5" />
              Seleccionar
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

function TransportistaModal({
  onClose,
  onSave,
}: {
  onClose: () => void;
  onSave: (v: { nombre: string; dni: string; placa: string; chofer: string }) => void;
}) {
  const [nombre, setNombre] = useState("");
  const [dni, setDni] = useState("");
  const [placa, setPlaca] = useState("");
  const [chofer, setChofer] = useState("");

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/30 backdrop-blur-[1px]">
      <div className="w-[520px] overflow-hidden rounded-sm border border-slate-400 bg-[#f4f7fb] shadow-2xl">
        <div className="flex items-center justify-between bg-gradient-to-r from-slate-700 to-slate-800 px-3 py-2 text-[12px] font-semibold text-white">
          <span>Transporte / responsable</span>
          <button onClick={onClose} className="rounded-sm p-1 hover:bg-white/10">
            <X className="h-3.5 w-3.5" />
          </button>
        </div>

        <div className="grid gap-3 p-3 md:grid-cols-2">
          <Field label="Empresa">
            <input className={inp} value={nombre} onChange={(e) => setNombre(e.target.value)} />
          </Field>
          <Field label="RUC / DNI">
            <input className={inp} value={dni} onChange={(e) => setDni(e.target.value)} />
          </Field>
          <Field label="Placa">
            <input className={inp} value={placa} onChange={(e) => setPlaca(e.target.value)} />
          </Field>
          <Field label="Chofer">
            <input className={inp} value={chofer} onChange={(e) => setChofer(e.target.value)} />
          </Field>
        </div>

        <div className="flex justify-end gap-2 border-t border-slate-300 bg-[#edf2f8] px-3 py-2">
          <button className={btn} onClick={onClose}>
            <X className="h-3.5 w-3.5" />
            Cancelar
          </button>
          <button
            className={btnPrimary}
            onClick={() => {
              onSave({ nombre, dni, placa, chofer });
              onClose();
            }}
          >
            <Save className="h-3.5 w-3.5" />
            Guardar
          </button>
        </div>
      </div>
    </div>
  );
}

function GuiaDevolucionForm({
  initialId,
  onClose,
}: {
  initialId?: number | null;
  onClose?: () => void;
}) {
  const emptyForm: GuiaDevolucionFormState = {
    id: initialId ?? null,
    numero: "GD-2026-0008",
    fecha: NOW.toISOString().slice(0, 10),
    clienteId: "0",
    clienteNombre: "",
    ruc: "",
    tipoDoc: "FACTURA",
    referencia: "",
    ubicacionId: "0",
    ubicacionNombre: "",
    observacion: "",
    motivo: "",
    estado: "GENERADO",
    moneda: "PEN",
  };

  const [form, setForm] = useState<GuiaDevolucionFormState>(emptyForm);
  const [detalles, setDetalles] = useState<GuiaDevolucionDet[]>(() => MOCK_DETALLES[initialId ?? 1] ?? []);
  const [locaciones, setLocaciones] = useState<Location[]>([]);
  const [clientes, setClientes] = useState<SigecoomClient[]>([]);
  const [showClienteDialog, setShowClienteDialog] = useState(false);
  const [showTransportistaDialog, setShowTransportistaDialog] = useState(false);
  const [transportista, setTransportista] = useState({ nombre: "", dni: "", placa: "", chofer: "" });

  useEffect(() => {
    let active = true;
    Promise.all([fetchSigecoomClients(200), fetchSigecoomLocations()])
      .then(([clienteData, locData]) => {
        if (!active) return;
        setClientes(clienteData);
        setLocaciones(locData);
        if (initialId) {
          const row = MOCK_GUIAS.find((item) => item.id === initialId);
          if (row) {
            setForm({
              id: row.id,
              numero: row.numero,
              fecha: row.fecha,
              clienteId: String(row.id),
              clienteNombre: row.cliente,
              ruc: row.ruc,
              tipoDoc: row.tipoDoc,
              referencia: row.referencia,
              ubicacionId: "1",
              ubicacionNombre: row.ubicacion,
              observacion: row.motivo,
              motivo: row.motivo,
              estado: row.estado,
              moneda: row.moneda,
            });
            setDetalles(MOCK_DETALLES[row.id] ?? []);
          }
        }
      })
      .catch(() => toast.error("No se pudieron cargar los catálogos"));

    return () => {
      active = false;
    };
  }, [initialId]);

  const subtotal = useMemo(
    () => detalles.reduce((acc, item) => acc + item.importe, 0),
    [detalles],
  );

  const handleSelectCliente = useCallback((cliente: SigecoomClient) => {
    setForm((prev) => ({
      ...prev,
      clienteId: String(cliente.id),
      clienteNombre: cliente.name,
      ruc: cliente.ruc ?? "",
    }));
    setShowClienteDialog(false);
  }, []);

  const handleAddDetalle = useCallback(() => {
    setDetalles((prev) => [
      ...prev,
      {
        id: Date.now(),
        producto: "Nuevo producto",
        unidad: "UND",
        cantidad: 1,
        precio: 0,
        descuento: 0,
        importe: 0,
      },
    ]);
  }, []);

  const handleDeleteDetalle = useCallback((id: number) => {
    setDetalles((prev) => prev.filter((d) => d.id !== id));
  }, []);

  const handleDetalleChange = useCallback((id: number, field: keyof GuiaDevolucionDet, value: string | number) => {
    setDetalles((prev) =>
      prev.map((item) => {
        if (item.id !== id) return item;

        const next = { ...item, [field]: value } as GuiaDevolucionDet;
        const qty = Number(next.cantidad ?? 0);
        const price = Number(next.precio ?? 0);
        const disc = Number(next.descuento ?? 0);
        const base = qty * price;
        next.importe = Math.max(0, base - (base * disc) / 100);
        return next;
      }),
    );
  }, []);

  const handleSave = useCallback(() => {
    toast.success(`Guía de devolución ${form.numero || "nueva"} guardada correctamente.`);
    onClose?.();
  }, [form.numero, onClose]);

  return (
    <div className="min-h-[760px] bg-[#edf3f9] p-4 text-slate-800">
      <div className="mb-3 flex items-center justify-between rounded-sm border border-slate-300 bg-gradient-to-r from-slate-700 to-slate-800 px-3 py-2 text-white shadow-sm">
        <div className="flex items-center gap-2">
          <ClipboardList className="h-4 w-4" />
          <span className="text-[13px] font-semibold uppercase tracking-[0.08em]">
            {initialId ? `Guía de devolución ${form.numero}` : "Registrar guía de devolución"}
          </span>
        </div>

        <div className="flex items-center gap-2">
          <button className={btnPrimary} onClick={handleSave}>
            <Save className="h-3.5 w-3.5" />
            Guardar
          </button>
          <button className={btn} onClick={onClose}>
            <X className="h-3.5 w-3.5" />
            Cerrar
          </button>
        </div>
      </div>

      <div className={`${panel} p-3`}>
        <div className="mb-3 grid grid-cols-1 gap-3 lg:grid-cols-5">
          <Field label="N° documento">
            <input className={inp} value={form.numero} onChange={(e) => setForm((p) => ({ ...p, numero: e.target.value }))} />
          </Field>
          <Field label="Fecha emisión">
            <input type="date" className={inp} value={form.fecha} onChange={(e) => setForm((p) => ({ ...p, fecha: e.target.value }))} />
          </Field>
          <Field label="Tipo doc.">
            <select className={inp} value={form.tipoDoc} onChange={(e) => setForm((p) => ({ ...p, tipoDoc: e.target.value }))}>
              <option>FACTURA</option>
              <option>BOLETA</option>
              <option>NOTA DE CRÉDITO</option>
              <option>GUIA</option>
            </select>
          </Field>
          <Field label="Referencia">
            <input className={inp} value={form.referencia} onChange={(e) => setForm((p) => ({ ...p, referencia: e.target.value }))} />
          </Field>
          <Field label="Moneda">
            <select className={inp} value={form.moneda} onChange={(e) => setForm((p) => ({ ...p, moneda: e.target.value }))}>
              <option value="PEN">PEN</option>
              <option value="USD">USD</option>
            </select>
          </Field>
        </div>

        <div className="grid grid-cols-1 gap-3 lg:grid-cols-[1.4fr_0.9fr_0.9fr_0.9fr]">
          <Field label="Cliente" className="lg:col-span-1">
            <div className="flex gap-2">
              <input
                className={`${inp} flex-1`}
                value={form.clienteNombre}
                placeholder="Seleccione cliente"
                readOnly
              />
              <button className={btnPrimary} onClick={() => setShowClienteDialog(true)}>
                <Search className="h-3.5 w-3.5" />
                Buscar
              </button>
            </div>
          </Field>

          <Field label="RUC / DNI">
            <input className={inp} value={form.ruc} readOnly />
          </Field>

          <Field label="Ubicación">
            <select
              className={inp}
              value={form.ubicacionId}
              onChange={(e) => {
                const selected = locaciones.find((l) => String(l.id) === e.target.value);
                setForm((p) => ({
                  ...p,
                  ubicacionId: e.target.value,
                  ubicacionNombre: selected
                    ? `${selected.warehouse}${selected.description ? ` - ${selected.description}` : ""}`
                    : "",
                }));
              }}
            >
              <option value="0">Seleccione</option>
              {locaciones.map((loc) => (
                <option key={loc.id} value={String(loc.id)}>
                  {loc.warehouse || loc.code}
                </option>
              ))}
            </select>
          </Field>

          <Field label="Estado">
            <select
              className={inp}
              value={form.estado}
              onChange={(e) => setForm((p) => ({ ...p, estado: e.target.value as GuiaDevolucionEstado }))}
            >
              <option value="GENERADO">GENERADO</option>
              <option value="IMPRESO">IMPRESO</option>
              <option value="PROCESADO">PROCESADO</option>
              <option value="ANULADO">ANULADO</option>
              <option value="PENDIENTE">PENDIENTE</option>
            </select>
          </Field>
        </div>

        <div className="mt-3 grid grid-cols-1 gap-3 lg:grid-cols-[1.4fr_0.6fr]">
          <Field label="Motivo / observación">
            <textarea
              className={`${inp} min-h-[78px] resize-none`}
              value={form.observacion}
              onChange={(e) => setForm((p) => ({ ...p, observacion: e.target.value, motivo: e.target.value }))}
            />
          </Field>

          <div className="space-y-3">
            <Field label="Responsable de transporte">
              <div className="flex gap-2">
                <input className={`${inp} flex-1`} value={transportista.nombre} readOnly placeholder="Empresa / transportista" />
                <button className={btn} onClick={() => setShowTransportistaDialog(true)}>
                  <Truck className="h-3.5 w-3.5" />
                  Editar
                </button>
              </div>
            </Field>
            <Field label="Placa / conductor">
              <input className={inp} value={`${transportista.placa} / ${transportista.chofer}`.trim()} readOnly />
            </Field>
          </div>
        </div>
      </div>

      <div className={`${panel} mt-4 overflow-hidden`}>
        <div className="flex items-center justify-between border-b border-slate-300 bg-slate-100 px-3 py-2">
          <div className="flex items-center gap-2 text-[12px] font-semibold text-slate-700">
            <Package className="h-4 w-4" />
            Detalle de productos devueltos
          </div>

          <div className="flex items-center gap-2">
            <button className={btnPrimary} onClick={handleAddDetalle}>
              <Plus className="h-3.5 w-3.5" />
              Agregar fila
            </button>
          </div>
        </div>

        <div className="overflow-auto">
          <table className="min-w-full border-separate border-spacing-0 text-[11px]">
            <thead className="bg-gradient-to-b from-slate-200 to-slate-100 text-slate-700">
              <tr>
                <th className="border-r border-slate-300 px-2 py-2 text-left font-semibold">Producto</th>
                <th className="border-r border-slate-300 px-2 py-2 text-left font-semibold">Und.</th>
                <th className="border-r border-slate-300 px-2 py-2 text-left font-semibold">Cant.</th>
                <th className="border-r border-slate-300 px-2 py-2 text-left font-semibold">Precio</th>
                <th className="border-r border-slate-300 px-2 py-2 text-left font-semibold">Desc.</th>
                <th className="border-r border-slate-300 px-2 py-2 text-left font-semibold">Importe</th>
                <th className="px-2 py-2 text-left font-semibold">Acción</th>
              </tr>
            </thead>
            <tbody>
              {detalles.length === 0 ? (
                <tr>
                  <td colSpan={7} className="px-3 py-6 text-center text-slate-500">
                    No hay líneas registradas.
                  </td>
                </tr>
              ) : (
                detalles.map((item) => (
                  <tr key={item.id} className="border-b border-slate-200 bg-white hover:bg-slate-50">
                    <td className="border-r border-slate-200 px-2 py-1.5">
                      <input
                        className={inp}
                        value={item.producto}
                        onChange={(e) => handleDetalleChange(item.id, "producto", e.target.value)}
                      />
                    </td>
                    <td className="border-r border-slate-200 px-2 py-1.5">
                      <input
                        className={inp}
                        value={item.unidad}
                        onChange={(e) => handleDetalleChange(item.id, "unidad", e.target.value)}
                      />
                    </td>
                    <td className="border-r border-slate-200 px-2 py-1.5">
                      <input
                        type="number"
                        className={inp}
                        value={item.cantidad}
                        onChange={(e) => handleDetalleChange(item.id, "cantidad", Number(e.target.value || 0))}
                      />
                    </td>
                    <td className="border-r border-slate-200 px-2 py-1.5">
                      <input
                        type="number"
                        step="0.01"
                        className={inp}
                        value={item.precio}
                        onChange={(e) => handleDetalleChange(item.id, "precio", Number(e.target.value || 0))}
                      />
                    </td>
                    <td className="border-r border-slate-200 px-2 py-1.5">
                      <input
                        type="number"
                        step="0.01"
                        className={inp}
                        value={item.descuento}
                        onChange={(e) => handleDetalleChange(item.id, "descuento", Number(e.target.value || 0))}
                      />
                    </td>
                    <td className="border-r border-slate-200 px-2 py-1.5 font-medium text-slate-800">
                      {formatMoney(item.importe)}
                    </td>
                    <td className="px-2 py-1.5">
                      <button className={btn} onClick={() => handleDeleteDetalle(item.id)}>
                        <Trash2 className="h-3.5 w-3.5" />
                        Quitar
                      </button>
                    </td>
                  </tr>
                ))
              )}
            </tbody>
          </table>
        </div>
      </div>

      <div className="mt-4 grid grid-cols-1 gap-3 lg:grid-cols-[1fr_320px]">
        <div className={`${panel} p-3`}>
          <div className="flex items-center gap-2 text-[12px] font-semibold text-slate-700">
            <CircleAlert className="h-4 w-4 text-amber-600" />
            Reglas de negocio
          </div>
          <ul className="mt-2 list-inside list-disc space-y-1 text-[11px] text-slate-600">
            <li>La guía no puede anexar más de 15 líneas si la observación supera el formato de impresión.</li>
            <li>Si el estado es ANULADO, los botones de imprimir y mostrar quedan deshabilitados.</li>
            <li>La generación de nota de crédito solo se habilita cuando el documento fue impreso.</li>
          </ul>
        </div>

        <div className={`${panel} p-3`}>
          <div className="space-y-3 text-[12px] text-slate-700">
            <div className="flex items-center justify-between">
              <span>Subtotal</span>
              <span className="font-semibold">{formatMoney(subtotal)}</span>
            </div>
            <div className="flex items-center justify-between">
              <span>IGV</span>
              <span className="font-semibold">{formatMoney(subtotal * 0.18)}</span>
            </div>
            <div className="flex items-center justify-between border-t border-slate-300 pt-2">
              <span>Total</span>
              <span className="text-[15px] font-bold text-slate-900">{formatMoney(subtotal * 1.18)}</span>
            </div>
          </div>
        </div>
      </div>

      {showClienteDialog && (
        <ClienteLookupModal
          onClose={() => setShowClienteDialog(false)}
          onSelect={handleSelectCliente}
        />
      )}

      {showTransportistaDialog && (
        <TransportistaModal
          onClose={() => setShowTransportistaDialog(false)}
          onSave={(value) => setTransportista(value)}
        />
      )}
    </div>
  );
}

export function GuiaDevolucionList() {
  const [rows, setRows] = useState<GuiaDevolucionRow[]>(MOCK_GUIAS);
  const [filtroNumero, setFiltroNumero] = useState("");
  const [filtroCliente, setFiltroCliente] = useState("");
  const [filtroEstado, setFiltroEstado] = useState("TODOS");
  const [selectedId, setSelectedId] = useState<number | null>(null);
  const [showForm, setShowForm] = useState(false);

  const filteredRows = useMemo(() => {
    return rows.filter((row) => {
      const matchNumero = !filtroNumero || row.numero.toLowerCase().includes(filtroNumero.toLowerCase());
      const matchCliente = !filtroCliente || row.cliente.toLowerCase().includes(filtroCliente.toLowerCase());
      const matchEstado = filtroEstado === "TODOS" || row.estado === filtroEstado;
      return matchNumero && matchCliente && matchEstado;
    });
  }, [filtroCliente, filtroEstado, filtroNumero, rows]);

  const selectedRow = filteredRows.find((row) => row.id === selectedId) ?? filteredRows[0] ?? null;

  const handleOpenNew = useCallback(() => {
    setSelectedId(null);
    setShowForm(true);
  }, []);

  const handleOpenEdit = useCallback((id: number) => {
    setSelectedId(id);
    setShowForm(true);
  }, []);

  const handleDelete = useCallback((id: number) => {
    setRows((prev) => prev.filter((g) => g.id !== id));
    if (selectedId === id) setSelectedId(null);
    toast.success("Guía de devolución eliminada");
  }, [selectedId]);

  return (
    <div className="min-h-[760px] bg-[#edf3f9] p-4 text-slate-800">
      {!showForm ? (
        <>
          <div className="mb-3 flex items-center justify-between rounded-sm border border-slate-300 bg-gradient-to-r from-slate-700 to-slate-800 px-3 py-2 text-white shadow-sm">
            <div className="flex items-center gap-2">
              <FileText className="h-4 w-4" />
              <span className="text-[13px] font-semibold uppercase tracking-[0.08em]">Guías de devolución</span>
            </div>

            <div className="flex items-center gap-2">
              <button className={btnPrimary} onClick={handleOpenNew}>
                <Plus className="h-3.5 w-3.5" />
                Nueva
              </button>
              <button className={btn}>
                <RefreshCw className="h-3.5 w-3.5" />
                Actualizar
              </button>
            </div>
          </div>

          <div className={`${panel} p-3`}>
            <div className="mb-3 flex items-center gap-2 text-[12px] font-semibold text-slate-700">
              <Filter className="h-4 w-4" />
              Filtros de búsqueda
            </div>

            <div className="grid grid-cols-1 gap-3 md:grid-cols-4">
              <Field label="Número">
                <input className={inp} value={filtroNumero} onChange={(e) => setFiltroNumero(e.target.value)} />
              </Field>
              <Field label="Cliente">
                <input className={inp} value={filtroCliente} onChange={(e) => setFiltroCliente(e.target.value)} />
              </Field>
              <Field label="Estado">
                <select className={inp} value={filtroEstado} onChange={(e) => setFiltroEstado(e.target.value)}>
                  <option value="TODOS">TODOS</option>
                  <option value="GENERADO">GENERADO</option>
                  <option value="IMPRESO">IMPRESO</option>
                  <option value="PROCESADO">PROCESADO</option>
                  <option value="ANULADO">ANULADO</option>
                  <option value="PENDIENTE">PENDIENTE</option>
                </select>
              </Field>
              <div className="flex items-end">
                <button className={`${btnPrimary} w-full justify-center`}>
                  <Search className="h-3.5 w-3.5" />
                  Consultar
                </button>
              </div>
            </div>
          </div>

          <div className={`${panel} mt-4 overflow-hidden`}>
            <div className="overflow-auto">
              <table className="min-w-full text-[11px]">
                <thead className="bg-gradient-to-b from-slate-200 to-slate-100 text-slate-700">
                  <tr>
                    <th className="border-r border-slate-300 px-2 py-2 text-left font-semibold">N°</th>
                    <th className="border-r border-slate-300 px-2 py-2 text-left font-semibold">Fecha</th>
                    <th className="border-r border-slate-300 px-2 py-2 text-left font-semibold">Cliente</th>
                    <th className="border-r border-slate-300 px-2 py-2 text-left font-semibold">Ref.</th>
                    <th className="border-r border-slate-300 px-2 py-2 text-left font-semibold">Mon.</th>
                    <th className="border-r border-slate-300 px-2 py-2 text-left font-semibold">Total</th>
                    <th className="border-r border-slate-300 px-2 py-2 text-left font-semibold">Estado</th>
                    <th className="px-2 py-2 text-left font-semibold">Acciones</th>
                  </tr>
                </thead>
                <tbody>
                  {filteredRows.length === 0 ? (
                    <tr>
                      <td colSpan={8} className="px-3 py-8 text-center text-slate-500">
                        No se encontraron registros.
                      </td>
                    </tr>
                  ) : (
                    filteredRows.map((row) => (
                      <tr
                        key={row.id}
                        className={`border-b border-slate-200 ${selectedRow?.id === row.id ? "bg-sky-50" : "bg-white hover:bg-slate-50"}`}
                        onClick={() => setSelectedId(row.id)}
                      >
                        <td className="border-r border-slate-200 px-2 py-2 font-semibold text-slate-700">{row.numero}</td>
                        <td className="border-r border-slate-200 px-2 py-2">{row.fecha}</td>
                        <td className="border-r border-slate-200 px-2 py-2">{row.cliente}</td>
                        <td className="border-r border-slate-200 px-2 py-2">{row.referencia}</td>
                        <td className="border-r border-slate-200 px-2 py-2">{row.moneda}</td>
                        <td className="border-r border-slate-200 px-2 py-2 font-semibold">{formatMoney(row.total)}</td>
                        <td className="border-r border-slate-200 px-2 py-2">
                          <StateBadge estado={row.estado} />
                        </td>
                        <td className="px-2 py-2">
                          <div className="flex items-center gap-1.5">
                            <button className={btn} onClick={() => handleOpenEdit(row.id)}>
                              <Pencil className="h-3.5 w-3.5" />
                              Ver
                            </button>
                            <button className={btn} onClick={() => handleDelete(row.id)}>
                              <Trash2 className="h-3.5 w-3.5" />
                              Borrar
                            </button>
                          </div>
                        </td>
                      </tr>
                    ))
                  )}
                </tbody>
              </table>
            </div>
          </div>
        </>
      ) : (
        <GuiaDevolucionForm initialId={selectedId} onClose={() => setShowForm(false)} />
      )}
    </div>
  );
}

export function GuiaDevolucion() {
  return <GuiaDevolucionList />;
}

export default GuiaDevolucion;
