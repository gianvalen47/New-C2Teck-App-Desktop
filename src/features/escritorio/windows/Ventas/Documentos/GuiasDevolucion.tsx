import { useCallback, useEffect, useMemo, useState, type ReactNode } from "react";
import {
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
  fetchGuiasDevolucion,
  fetchGuiaDevolucionDetalles,
  fetchGuiaDevolucion,
  type Location,
  type SigecoomClient,
} from "@/lib/sigecoom-api";
import { inp, btn, btnPrimary, iconBtn, actionBtn, squareIconBtn, tbSep } from "@/features/escritorio/windows/uiStyles";

const MESES = [
  "ENERO",
  "FEBRERO",
  "MARZO",
  "ABRIL",
  "MAYO",
  "JUNIO",
  "JULIO",
  "AGOSTO",
  "SETIEMBRE",
  "OCTUBRE",
  "NOVIEMBRE",
  "DICIEMBRE",
];

const NOW = new Date();

type GuiaDevolucionEstado = "GENERADO" | "IMPRESO" | "PROCESADO" | "ANULADO" | "PENDIENTE";

type GuiaDevolucionRow = {
  id: number;
  numero: string;
  fecha: string;
  cliente: string;
  ruc?: string;
  tipoDoc?: string;
  referencia?: string;
  moneda?: string;
  total: number;
  estado: string;
  motivo?: string;
  ubicacion?: string;
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

const ESTADO_COLORS: Record<string, string> = {
  GENERADO: "border-blue-200 bg-blue-50 text-blue-700",
  IMPRESO: "border-amber-200 bg-amber-50 text-amber-700",
  PROCESADO: "border-emerald-200 bg-emerald-50 text-emerald-700",
  ANULADO: "border-red-200 bg-red-50 text-red-700",
  PENDIENTE: "border-slate-200 bg-slate-100 text-slate-600",
};

function formatMoney(value: number) {
  return new Intl.NumberFormat("es-PE", {
    style: "currency",
    currency: "PEN",
    minimumFractionDigits: 2,
    maximumFractionDigits: 2,
  }).format(Number.isFinite(value) ? value : 0);
}

function StateBadge({ estado }: { estado: string }) {
  const cls = ESTADO_COLORS[estado] ?? "border-slate-200 bg-slate-100 text-slate-600";
  return <span className={`inline-flex rounded border px-1.5 py-0.5 text-[10px] font-bold ${cls}`}>{estado}</span>;
}

function Field({ label, children, className = "" }: { label: string; children: ReactNode; className?: string }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] font-medium text-slate-600">{label}</span>
      {children}
    </label>
  );
}

function InlineField({ label, children, className = "", labelWidth = "w-[74px]" }: { label: string; children: ReactNode; className?: string; labelWidth?: string }) {
  return (
    <div className={`flex items-center gap-1 ${className}`}>
      <span className={`${labelWidth} shrink-0 text-right text-[11px] font-semibold text-slate-800`}>{label} :</span>
      <div className="min-w-0 flex-1">{children}</div>
    </div>
  );
}

function ClienteLookupModal({ onClose, onSelect }: { onClose: () => void; onSelect: (c: SigecoomClient) => void }) {
  const [rows, setRows] = useState<SigecoomClient[]>([]);
  const [loading, setLoading] = useState(true);
  const [selectedId, setSelectedId] = useState<number | null>(null);
  const [desc, setDesc] = useState("");
  const [doc, setDoc] = useState("");

  useEffect(() => {
    let active = true;
    fetchSigecoomClients(0, 100)
      .then((res) => {
        if (!active) return;
        setRows(res.items);
      })
      .catch(() => toast.error("No se pudo cargar clientes"))
      .finally(() => {
        if (active) setLoading(false);
      });

    return () => {
      active = false;
    };
  }, []);

  const filtered = rows.filter((row) => {
    const qDesc = desc.trim().toLowerCase();
    const qDoc = doc.trim().toLowerCase();
    const byDesc = !qDesc || row.name.toLowerCase().includes(qDesc);
    const byDoc = !qDoc || (row.ruc ?? "").toLowerCase().includes(qDoc);
    return byDesc && byDoc;
  });

  return (
    <div className="fixed inset-0 z-[10000] flex items-center justify-center bg-black/35">
      <div className="w-[760px] overflow-hidden rounded-sm border border-slate-500 bg-[#f2f5fa] shadow-2xl">
        <div className="flex items-center justify-between bg-gradient-to-b from-[#3e5b7a] to-[#2a3f55] px-3 py-1.5 text-[12px] text-white">
          <span className="font-semibold">Buscar Cliente</span>
          <button onClick={onClose} className="rounded px-1 hover:bg-white/20">
            <X className="h-3.5 w-3.5" />
          </button>
        </div>
        <div className="border-b border-slate-300 bg-[#eef2f7] p-2">
          <div className="mb-1 text-[11px] font-semibold text-slate-700">Datos de Búsqueda</div>
          <div className="grid grid-cols-[1fr_180px_86px] gap-2">
            <div>
              <div className="mb-0.5 text-[10.5px] text-slate-600">Descripción</div>
              <input className={inp} value={desc} onChange={(e) => setDesc(e.target.value)} />
            </div>
            <div>
              <div className="mb-0.5 text-[10.5px] text-slate-600">N° de Documento</div>
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
          <div className="h-[280px] overflow-auto border border-slate-300 bg-white">
            <table className="w-full text-[11px]">
              <thead className="sticky top-0 z-10 bg-gradient-to-b from-[#eef2f7] to-[#d6dee8] text-slate-700">
                <tr>
                  <th className="border-r border-slate-300 px-2 py-1 text-left font-semibold">Código</th>
                  <th className="border-r border-slate-300 px-2 py-1 text-left font-semibold">Descripción</th>
                  <th className="px-2 py-1 text-left font-semibold">R.U.C.</th>
                </tr>
              </thead>
              <tbody>
                {loading ? (
                  <tr><td colSpan={3} className="px-2 py-4 text-center text-slate-500">Cargando...</td></tr>
                ) : filtered.length === 0 ? (
                  <tr><td colSpan={3} className="px-2 py-4 text-center text-slate-500">Sin resultados</td></tr>
                ) : (
                  filtered.map((client, idx) => {
                      const clientId = Number(client.id);
                    const isSelected = !Number.isNaN(clientId) && clientId === selectedId;
                    return (
                      <tr key={client.id} onClick={() => setSelectedId(clientId)} onDoubleClick={() => onSelect(client)} className={["cursor-pointer border-b border-slate-200", idx % 2 ? "bg-[#f6f9fc]" : "bg-white", isSelected ? "!bg-[#d6e4f4]" : "hover:bg-[#e8f0f8]/70"].join(" ")}>
                        <td className="border-r border-slate-200 px-2 py-1 font-mono">{String(client.id).slice(0, 8).toUpperCase()}</td>
                        <td className="border-r border-slate-200 px-2 py-1">{client.name}</td>
                        <td className="px-2 py-1 font-mono">{client.ruc || "-"}</td>
                      </tr>
                    );
                  })
                )}
              </tbody>
            </table>
          </div>
          <div className="mt-2 flex items-center justify-between">
            <div className="text-[11px] text-slate-600">Registros: {filtered.length}</div>
            <div className="flex items-center gap-2">
              <button className={btn} onClick={onClose}><X className="h-3.5 w-3.5" />Cerrar</button>
              <button className={btnPrimary} onClick={() => { const selected = filtered.find((client) => Number(client.id) === selectedId); if (selected) onSelect(selected); }} disabled={!selectedId}><Save className="h-3.5 w-3.5" />Seleccionar</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

function TransportistaModal({ onClose, onSave }: { onClose: () => void; onSave: (v: { nombre: string; dni: string; placa: string; chofer: string }) => void }) {
  const [nombre, setNombre] = useState("");
  const [dni, setDni] = useState("");
  const [placa, setPlaca] = useState("");
  const [chofer, setChofer] = useState("");

  return (
    <div className="fixed inset-0 z-[10000] flex items-center justify-center bg-black/35">
      <div className="w-[520px] overflow-hidden rounded-sm border border-slate-500 bg-[#f1f3f8] shadow-2xl">
        <div className="flex items-center justify-between bg-gradient-to-b from-[#3e5b7a] to-[#2a3f55] px-3 py-1.5 text-[12px] text-white">
          <span className="font-semibold">Transportista</span>
          <button onClick={onClose} className="rounded px-1 hover:bg-white/20"><X className="h-3.5 w-3.5" /></button>
        </div>
        <div className="grid gap-3 p-3 md:grid-cols-2">
          <Field label="Empresa"><input className={inp} value={nombre} onChange={(e) => setNombre(e.target.value)} /></Field>
          <Field label="RUC / DNI"><input className={inp} value={dni} onChange={(e) => setDni(e.target.value)} /></Field>
          <Field label="Placa"><input className={inp} value={placa} onChange={(e) => setPlaca(e.target.value)} /></Field>
          <Field label="Chofer"><input className={inp} value={chofer} onChange={(e) => setChofer(e.target.value)} /></Field>
        </div>
        <div className="flex justify-end gap-2 border-t border-slate-300 bg-[#edf2f8] px-3 py-2">
          <button className={btn} onClick={onClose}><X className="h-3.5 w-3.5" />Cancelar</button>
          <button className={btnPrimary} onClick={() => { onSave({ nombre, dni, placa, chofer }); onClose(); }}><Save className="h-3.5 w-3.5" />Guardar</button>
        </div>
      </div>
    </div>
  );
}

function GuiaDevolucionForm({ initialId, onClose }: { initialId?: number | null; onClose?: () => void }) {
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
  const [detalles, setDetalles] = useState<GuiaDevolucionDet[]>([]);
  const [locaciones, setLocaciones] = useState<Location[]>([]);
  const [showClienteDialog, setShowClienteDialog] = useState(false);
  const [showTransportistaDialog, setShowTransportistaDialog] = useState(false);
  const [transportista, setTransportista] = useState({ nombre: "", dni: "", placa: "", chofer: "" });

  useEffect(() => {
    let active = true;
    Promise.all([fetchSigecoomClients(0, 200), fetchSigecoomLocations()])
      .then(([clienteRes, locData]) => {
        if (!active) return;
        setLocaciones(locData);
        if (!form.clienteNombre && clienteRes.items[0]) {
          setForm((prev) => ({ ...prev, clienteNombre: clienteRes.items[0].name, clienteId: String(clienteRes.items[0].id), ruc: clienteRes.items[0].ruc ?? "" }));
        }
      })
      .catch(() => toast.error("No se pudieron cargar los catálogos"));

    if (initialId) {
      fetchGuiaDevolucion(initialId)
        .then((g) => {
          if (!active) return;
          setForm((prev) => ({ ...prev, id: g.id ?? initialId, numero: g.numero ?? prev.numero, fecha: g.fecha ?? prev.fecha, clienteNombre: g.cliente ?? prev.clienteNombre, ruc: g.ruc ?? prev.ruc, referencia: g.referencia ?? prev.referencia, motivo: g.motivo ?? prev.motivo, estado: (g.estado as GuiaDevolucionEstado) ?? prev.estado, moneda: g.moneda ?? prev.moneda }));
        })
        .catch(() => toast.error("No se pudo cargar la guía"));

      fetchGuiaDevolucionDetalles(initialId)
        .then((d) => {
          if (!active) return;
          setDetalles(d);
        })
        .catch(() => toast.error("No se pudieron cargar los detalles de la guía"));
    }

    return () => { active = false; };
  }, [initialId]);

  const subtotal = useMemo(() => detalles.reduce((acc, item) => acc + item.importe, 0), [detalles]);

  const handleSelectCliente = useCallback((cliente: SigecoomClient) => {
    setForm((prev) => ({ ...prev, clienteId: String(cliente.id), clienteNombre: cliente.name, ruc: cliente.ruc ?? "" }));
    setShowClienteDialog(false);
  }, []);

  const handleAddDetalle = useCallback(() => {
    setDetalles((prev) => [...prev, { id: Date.now(), producto: "Nuevo producto", unidad: "UND", cantidad: 1, precio: 0, descuento: 0, importe: 0 }]);
  }, []);

  const handleDeleteDetalle = useCallback((id: number) => {
    setDetalles((prev) => prev.filter((d) => d.id !== id));
  }, []);

  const handleDetalleChange = useCallback((id: number, field: keyof GuiaDevolucionDet, value: string | number) => {
    setDetalles((prev) => prev.map((item) => {
      if (item.id !== id) return item;
      const next = { ...item, [field]: value } as GuiaDevolucionDet;
      const qty = Number(next.cantidad ?? 0);
      const price = Number(next.precio ?? 0);
      const disc = Number(next.descuento ?? 0);
      const base = qty * price;
      next.importe = Math.max(0, base - (base * disc) / 100);
      return next;
    }));
  }, []);

  const handleSave = useCallback(() => {
    toast.success(`Guía de devolución ${form.numero || "nueva"} guardada correctamente.`);
    onClose?.();
  }, [form.numero, onClose]);

  return (
    <div className="h-full min-h-[760px] bg-[#dfe5ee] p-2 text-slate-800">
      <div className="mx-auto overflow-hidden rounded-sm border border-slate-400 bg-[#e9eef4] shadow-[0_0_0_1px_rgba(89,104,121,0.35)]">
        <div className="flex items-center justify-between bg-gradient-to-b from-[#5a7893] to-[#2d4359] px-3 py-1.5 text-white">
          <div className="flex items-center gap-2">
            <ClipboardList className="h-4 w-4" />
            <span className="text-[12px] font-semibold uppercase tracking-[0.08em]">{initialId ? `Guía de devolución ${form.numero}` : "Registrar guía de devolución"}</span>
          </div>
          <button onClick={onClose} className="rounded px-1 hover:bg-white/20" aria-label="Cerrar"><X className="h-4 w-4" /></button>
        </div>
        <div className="flex items-center gap-1 border-b border-slate-300 bg-[#dfeaf5] px-2 py-1.5">
          <button className={iconBtn} title="Guardar" onClick={handleSave}><Save className="h-3.5 w-3.5" /></button>
          <button className={iconBtn} title="Imprimir"><Printer className="h-3.5 w-3.5" /></button>
          <button className={iconBtn} title="Buscar cliente" onClick={() => setShowClienteDialog(true)}><Search className="h-3.5 w-3.5" /></button>
          {tbSep}
          <button className={actionBtn} title="Agregar detalle" onClick={handleAddDetalle}><Plus className="h-3.5 w-3.5" /></button>
        </div>
        <div className="bg-[#edf3f8] p-3">
          <div className="grid grid-cols-1 gap-3 lg:grid-cols-5">
            <Field label="N° documento"><input className={inp} value={form.numero} onChange={(e) => setForm((p) => ({ ...p, numero: e.target.value }))} /></Field>
            <Field label="Fecha emisión"><input type="date" className={inp} value={form.fecha} onChange={(e) => setForm((p) => ({ ...p, fecha: e.target.value }))} /></Field>
            <Field label="Tipo doc."><select className={inp} value={form.tipoDoc} onChange={(e) => setForm((p) => ({ ...p, tipoDoc: e.target.value }))}><option>FACTURA</option><option>BOLETA</option><option>NOTA DE CRÉDITO</option><option>GUIA</option></select></Field>
            <Field label="Referencia"><input className={inp} value={form.referencia} onChange={(e) => setForm((p) => ({ ...p, referencia: e.target.value }))} /></Field>
            <Field label="Moneda"><select className={inp} value={form.moneda} onChange={(e) => setForm((p) => ({ ...p, moneda: e.target.value }))}><option value="PEN">PEN</option><option value="USD">USD</option></select></Field>
          </div>
          <div className="mt-3 grid grid-cols-1 gap-3 lg:grid-cols-[1.3fr_0.8fr_0.8fr_0.8fr]">
            <Field label="Cliente"><div className="flex gap-2"><input className={`${inp} flex-1`} value={form.clienteNombre} readOnly placeholder="Seleccione cliente" /><button className={btnPrimary} onClick={() => setShowClienteDialog(true)}><Search className="h-3.5 w-3.5" />Buscar</button></div></Field>
            <Field label="RUC / DNI"><input className={inp} value={form.ruc} readOnly /></Field>
            <Field label="Ubicación"><select className={inp} value={form.ubicacionId} onChange={(e) => { const selected = locaciones.find((l) => String(l.id) === e.target.value); setForm((p) => ({ ...p, ubicacionId: e.target.value, ubicacionNombre: selected ? `${selected.warehouse}${selected.description ? ` - ${selected.description}` : ""}` : "" })); }}><option value="0">Seleccione</option>{locaciones.map((loc) => <option key={loc.id} value={String(loc.id)}>{loc.warehouse || loc.code}</option>)}</select></Field>
            <Field label="Estado"><select className={inp} value={form.estado} onChange={(e) => setForm((p) => ({ ...p, estado: e.target.value as GuiaDevolucionEstado }))}><option value="GENERADO">GENERADO</option><option value="IMPRESO">IMPRESO</option><option value="PROCESADO">PROCESADO</option><option value="ANULADO">ANULADO</option><option value="PENDIENTE">PENDIENTE</option></select></Field>
          </div>
          <div className="mt-3 grid grid-cols-1 gap-3 lg:grid-cols-[1.4fr_0.8fr]">
            <Field label="Motivo / observación"><textarea className={`${inp} min-h-[80px] resize-none`} value={form.observacion} onChange={(e) => setForm((p) => ({ ...p, observacion: e.target.value, motivo: e.target.value }))} /></Field>
            <div className="space-y-3">
              <Field label="Responsable de transporte"><div className="flex gap-2"><input className={`${inp} flex-1`} value={transportista.nombre} readOnly placeholder="Empresa / transportista" /><button className={btn} onClick={() => setShowTransportistaDialog(true)}><Truck className="h-3.5 w-3.5" />Editar</button></div></Field>
              <Field label="Placa / conductor"><input className={inp} value={`${transportista.placa} / ${transportista.chofer}`.trim()} readOnly /></Field>
            </div>
          </div>
        </div>

        <div className="border-t border-slate-300 bg-[#edf3f8]">
          <div className="flex items-center justify-between border-b border-slate-300 bg-[#dfeaf5] px-3 py-2">
            <div className="flex items-center gap-2 text-[12px] font-semibold text-slate-700"><Package className="h-4 w-4" />Detalle de productos devueltos</div>
            <button className={btnPrimary} onClick={handleAddDetalle}><Plus className="h-3.5 w-3.5" />Agregar fila</button>
          </div>
          <div className="overflow-auto">
            <table className="min-w-full border-separate border-spacing-0 text-[11px]">
              <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800">
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
                  <tr><td colSpan={7} className="px-3 py-6 text-center text-slate-500">No hay líneas registradas.</td></tr>
                ) : (
                  detalles.map((item) => (
                    <tr key={item.id} className="border-b border-slate-200 bg-white hover:bg-slate-50">
                      <td className="border-r border-slate-200 px-2 py-1.5"><input className={inp} value={item.producto} onChange={(e) => handleDetalleChange(item.id, "producto", e.target.value)} /></td>
                      <td className="border-r border-slate-200 px-2 py-1.5"><input className={inp} value={item.unidad} onChange={(e) => handleDetalleChange(item.id, "unidad", e.target.value)} /></td>
                      <td className="border-r border-slate-200 px-2 py-1.5"><input type="number" className={inp} value={item.cantidad} onChange={(e) => handleDetalleChange(item.id, "cantidad", Number(e.target.value || 0))} /></td>
                      <td className="border-r border-slate-200 px-2 py-1.5"><input type="number" step="0.01" className={inp} value={item.precio} onChange={(e) => handleDetalleChange(item.id, "precio", Number(e.target.value || 0))} /></td>
                      <td className="border-r border-slate-200 px-2 py-1.5"><input type="number" step="0.01" className={inp} value={item.descuento} onChange={(e) => handleDetalleChange(item.id, "descuento", Number(e.target.value || 0))} /></td>
                      <td className="border-r border-slate-200 px-2 py-1.5 font-medium text-slate-800">{formatMoney(item.importe)}</td>
                      <td className="px-2 py-1.5"><button className={btn} onClick={() => handleDeleteDetalle(item.id)}><Trash2 className="h-3.5 w-3.5" />Quitar</button></td>
                    </tr>
                  ))
                )}
              </tbody>
            </table>
          </div>
        </div>
        <div className="grid grid-cols-1 gap-3 bg-[#edf3f8] p-3 lg:grid-cols-[1fr_320px]">
          <div className="rounded-sm border border-slate-300 bg-white p-3 shadow-sm">
            <div className="flex items-center gap-2 text-[12px] font-semibold text-slate-700"><CircleAlert className="h-4 w-4 text-amber-600" />Reglas de negocio</div>
            <ul className="mt-2 list-inside list-disc space-y-1 text-[11px] text-slate-600">
              <li>La guía no puede anexar más de 15 líneas si la observación supera el formato de impresión.</li>
              <li>Si el estado es ANULADO, los botones de imprimir y mostrar quedan deshabilitados.</li>
              <li>La generación de nota de crédito solo se habilita cuando el documento fue impreso.</li>
            </ul>
          </div>
          <div className="rounded-sm border border-slate-300 bg-white p-3 shadow-sm">
            <div className="space-y-3 text-[12px] text-slate-700">
              <div className="flex items-center justify-between"><span>Subtotal</span><span className="font-semibold">{formatMoney(subtotal)}</span></div>
              <div className="flex items-center justify-between"><span>IGV</span><span className="font-semibold">{formatMoney(subtotal * 0.18)}</span></div>
              <div className="flex items-center justify-between border-t border-slate-300 pt-2"><span>Total</span><span className="text-[15px] font-bold text-slate-900">{formatMoney(subtotal * 1.18)}</span></div>
            </div>
          </div>
        </div>
      </div>
      {showClienteDialog && <ClienteLookupModal onClose={() => setShowClienteDialog(false)} onSelect={handleSelectCliente} />}
      {showTransportistaDialog && <TransportistaModal onClose={() => setShowTransportistaDialog(false)} onSave={(value) => setTransportista(value)} />}
    </div>
  );
}

export function GuiaDevolucionList() {
  const [rows, setRows] = useState<GuiaDevolucionRow[]>([]);
  const [filtroNumero, setFiltroNumero] = useState("");
  const [filtroCliente, setFiltroCliente] = useState("");
  const [filtroEstado, setFiltroEstado] = useState("TODOS");
  const [selectedId, setSelectedId] = useState<number | null>(null);
  const [showForm, setShowForm] = useState(false);
  const [anio, setAnio] = useState(String(NOW.getFullYear()));
  const [mes, setMes] = useState(String(NOW.getMonth() + 1));

  const refreshRows = useCallback(() => {
    fetchGuiasDevolucion({ anio: Number(anio || NOW.getFullYear()), mes: Number(mes || NOW.getMonth() + 1) })
      .then((data) => setRows(data.map((row) => ({
        ...row,
        ruc: row.ruc ?? "",
        total: Number(row.total ?? 0),
        estado: (row.estado as GuiaDevolucionEstado) ?? "GENERADO",
        moneda: row.moneda ?? "PEN",
        referencia: row.referencia ?? "",
      }))))
      .catch(() => toast.error("No se pudo cargar las guías de devolución desde el backend"));
  }, [anio, mes]);

  const filteredRows = useMemo(() => rows.filter((row) => {
    const matchNumero = !filtroNumero || row.numero.toLowerCase().includes(filtroNumero.toLowerCase());
    const matchCliente = !filtroCliente || row.cliente.toLowerCase().includes(filtroCliente.toLowerCase());
    const matchEstado = filtroEstado === "TODOS" || row.estado === filtroEstado;
    return matchNumero && matchCliente && matchEstado;
  }), [filtroCliente, filtroEstado, filtroNumero, rows]);

  const selectedRow = filteredRows.find((row) => row.id === selectedId) ?? filteredRows[0] ?? null;

  useEffect(() => { void refreshRows(); }, [refreshRows]);

  const handleOpenNew = useCallback(() => { setSelectedId(null); setShowForm(true); }, []);
  const handleOpenEdit = useCallback((id: number) => { setSelectedId(id); setShowForm(true); }, []);
  const handleDelete = useCallback((id: number) => { setRows((prev) => prev.filter((g) => g.id !== id)); if (selectedId === id) setSelectedId(null); toast.success("Guía de devolución eliminada"); }, [selectedId]);

  if (showForm) {
    return <GuiaDevolucionForm initialId={selectedId} onClose={() => setShowForm(false)} />;
  }

  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-2 py-1.5 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Nuevo" onClick={handleOpenNew}><Plus className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Editar" onClick={() => selectedRow && handleOpenEdit(selectedRow.id)} disabled={!selectedRow}><Pencil className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Anular" onClick={() => selectedRow && handleDelete(selectedRow.id)} disabled={!selectedRow}><Trash2 className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Buscar"><Search className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar" onClick={() => void refreshRows()}><RefreshCw className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Cerrar"><X className="h-4 w-4" /></button>
      </div>

      <div className="flex flex-wrap items-end gap-2 border-b border-slate-300 bg-[#F0F4F8] px-2 py-1.5">
        <Field label="Año" className="w-14"><input className={`${inp} font-mono`} value={anio} onChange={(e) => setAnio(e.target.value)} /></Field>
        <Field label="Mes" className="w-28"><select className={inp} value={mes} onChange={(e) => setMes(e.target.value)}>{MESES.map((month, idx) => <option key={month} value={String(idx + 1)}>{month}</option>)}</select></Field>
        <Field label="Oficina" className="w-28"><select className={inp} defaultValue="LIMA"><option>LIMA</option></select></Field>
        <Field label="Almacén" className="w-32"><select className={inp} defaultValue="COMERCIAL"><option>COMERCIAL</option></select></Field>
        <Field label="Cliente" className="w-52"><div className="flex gap-1"><input className={inp} value={filtroCliente} onChange={(e) => setFiltroCliente(e.target.value)} placeholder="(Todos)" /><button className={btn} type="button" title="Buscar cliente"><Search className="h-3 w-3" /></button></div></Field>
        <Field label="Estado" className="w-28"><select className={inp} value={filtroEstado} onChange={(e) => setFiltroEstado(e.target.value)}><option value="TODOS">(Todos)</option><option value="GENERADO">GENERADO</option><option value="IMPRESO">IMPRESO</option><option value="PROCESADO">PROCESADO</option><option value="ANULADO">ANULADO</option><option value="PENDIENTE">PENDIENTE</option></select></Field>
        <Field label="Número" className="w-24"><input className={`${inp} font-mono`} value={filtroNumero} onChange={(e) => setFiltroNumero(e.target.value)} /></Field>
        <button className={btnPrimary} onClick={() => void refreshRows()}><Search className="h-3.5 w-3.5" />Buscar</button>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="h-full overflow-auto rounded-sm border border-slate-400/60 bg-white">
          <table className="w-full text-[11.5px]">
            <thead className="sticky top-0 z-10 bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800">
              <tr>
                <th className="border-r border-slate-300/70 px-2 py-1 text-center font-semibold">Número</th>
                <th className="border-r border-slate-300/70 px-2 py-1 text-center font-semibold">Fecha</th>
                <th className="border-r border-slate-300/70 px-2 py-1 text-center font-semibold">Referencia</th>
                <th className="border-r border-slate-300/70 px-2 py-1 text-center font-semibold">Cliente</th>
                <th className="border-r border-slate-300/70 px-2 py-1 text-center font-semibold">Mon.</th>
                <th className="border-r border-slate-300/70 px-2 py-1 text-center font-semibold">Total</th>
                <th className="border-r border-slate-300/70 px-2 py-1 text-center font-semibold">EST</th>
                <th className="px-2 py-1 text-center font-semibold">Acción</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-slate-100">
              {filteredRows.length === 0 ? (
                <tr><td colSpan={8} className="py-12 text-center text-[12px] text-slate-400">Sin registros para los filtros seleccionados</td></tr>
              ) : (
                filteredRows.map((row, index) => (
                  <tr key={row.id} onClick={() => setSelectedId(row.id)} onDoubleClick={() => handleOpenEdit(row.id)} className={["cursor-pointer transition-colors", index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]", selectedRow?.id === row.id ? "!bg-[#D6E4F4] font-medium" : "hover:bg-[#E8F0F8]/70"].join(" ")}>
                    <td className="border-r border-slate-100 px-3 py-2 font-mono font-medium">{row.numero}</td>
                    <td className="border-r border-slate-100 px-3 py-2 whitespace-nowrap">{row.fecha}</td>
                    <td className="border-r border-slate-100 px-3 py-2">{row.referencia || "-"}</td>
                    <td className="border-r border-slate-100 px-3 py-2 max-w-[220px] truncate">{row.cliente || "(Sin cliente)"}</td>
                    <td className="border-r border-slate-100 px-3 py-2">{row.moneda}</td>
                    <td className="border-r border-slate-100 px-3 py-2 font-mono text-right">{formatMoney(row.total ?? 0)}</td>
                    <td className="border-r border-slate-100 px-3 py-2"><StateBadge estado={row.estado ?? "GENERADO"} /></td>
                    <td className="px-3 py-2"><div className="flex items-center gap-1.5"><button className={btn} onClick={() => handleOpenEdit(row.id)}><Search className="h-3.5 w-3.5" />Ver</button><button className={btn} onClick={() => handleDelete(row.id)}><Trash2 className="h-3.5 w-3.5" />Borrar</button></div></td>
                  </tr>
                ))
              )}
            </tbody>
          </table>
        </div>
      </div>

      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-center text-[11px] font-medium text-slate-700">Registros : {filteredRows.length}</div>
    </div>
  );
}

export function GuiaDevolucion() {
  return <GuiaDevolucionList />;
}

export default GuiaDevolucion;
