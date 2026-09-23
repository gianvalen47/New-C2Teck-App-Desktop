import { createPortal } from "react-dom";
import { useCallback, useEffect, useMemo, useRef, useState } from "react";
import {
  ArrowRight,
  Clock,
  DollarSign,
  FileDown,
  FileSearch,
  FileSpreadsheet,
  LogOut,
  Mail,
  MapPin,
  Package,
  Pencil,
  Percent,
  Plus,
  Printer,
  Receipt,
  RefreshCw,
  Save,
  Search,
  Send,
  Trash2,
  Wrench,
  X,
  Filter,
  UserPlus,
  Building2,
  FileEdit,
  FolderOpen,
  FolderPlus,
  ChevronUp,
  ChevronDown,
} from "lucide-react";
import { toast } from "sonner";
import {
  anularFactura,
  createFactura,
  deleteFactura,
  emitirFactura,
  enviarFacturaCorreo,
  fetchFacturas,
  fetchSession,
  getSessionTipoCambioCompra,
  type FacturaRow,
  updateFactura,
} from "@/lib/sigecoom-api";

// Estilos base responsivos y estilizados
const inp =
  "h-7 px-2 text-[11px] bg-white border border-slate-300 rounded outline-none focus:border-slate-500 focus:ring-1 focus:ring-slate-400/50 w-full text-slate-800 shadow-xs transition-all";
const btnPrimary =
  "inline-flex items-center justify-center gap-1.5 h-7 px-3 text-[11px] rounded bg-slate-700 hover:bg-slate-800 text-white font-medium shrink-0 shadow-xs transition-all cursor-pointer";
const iconBtn =
  "inline-flex items-center justify-center h-7 w-7 rounded text-slate-600 hover:text-slate-900 hover:bg-slate-200/70 active:bg-slate-300/60 disabled:opacity-40 disabled:cursor-not-allowed transition-all cursor-pointer";
const actionBtn =
  "inline-flex items-center justify-center h-7 w-7 border border-slate-300 bg-slate-50 hover:bg-slate-100 text-slate-700 rounded shadow-xs active:bg-slate-200 transition-all cursor-pointer shrink-0";
const tbSep = <span className="mx-0.5 h-4 w-px bg-slate-300 inline-block" aria-hidden="true" />;

const MESES = [
  "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO",
  "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE",
];

function getTodayDateParts() {
  const today = new Date();
  return {
    year: String(today.getFullYear()),
    month: String(today.getMonth() + 1),
  };
}

type FacturaFormProps = {
  factura?: FacturaRow;
  onClose: () => void;
  onSaved: () => void;
};

function Field({
  label,
  className = "",
  children,
}: {
  label: string;
  className?: string;
  children: React.ReactNode;
}) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium">{label}</span>
      {children}
    </label>
  );
}

function InlineField({
  label,
  children,
  className = "",
  labelWidth = "w-[74px]",
}: {
  label: string;
  children: React.ReactNode;
  className?: string;
  labelWidth?: string;
}) {
  return (
    <div className={`flex items-center gap-1 ${className} hover:bg-slate-50 hover:rounded-sm`}>
      <span className={`${labelWidth} shrink-0 text-right text-[11px] font-semibold text-slate-800`}>{label} :</span>
      <div className="min-w-0 flex-1">{children}</div>
    </div>
  );
}

type FacturaFormWindow = {
  id: string;
  idFactura?: string;
  title: string;
  x: number;
  y: number;
  w: number;
  h: number;
  z: number;
};

function DraggableFormWindow({
  win,
  onFocus,
  onMove,
  onClose,
  children,
}: {
  win: FacturaFormWindow;
  onFocus: () => void;
  onMove: (id: string, x: number, y: number) => void;
  onClose: () => void;
  children: React.ReactNode;
}) {
  const DESKTOP_STATUS_BAR_H = 56;
  const dragRef = useRef<{ dx: number; dy: number } | null>(null);

  useEffect(() => {
    const onMouseMove = (e: MouseEvent) => {
      if (!dragRef.current) return;
      const maxW = window.innerWidth;
      const maxH = Math.max(320, window.innerHeight - DESKTOP_STATUS_BAR_H);
      const nextXRaw = e.clientX - dragRef.current.dx;
      const nextYRaw = e.clientY - dragRef.current.dy;
      const nextX = Math.max(0, Math.min(nextXRaw, Math.max(0, maxW - win.w)));
      const nextY = Math.max(0, Math.min(nextYRaw, Math.max(0, maxH - win.h)));
      onMove(win.id, nextX, nextY);
    };
    const onMouseUp = () => {
      dragRef.current = null;
      document.body.style.userSelect = "";
    };
    window.addEventListener("mousemove", onMouseMove);
    window.addEventListener("mouseup", onMouseUp);
    return () => {
      window.removeEventListener("mousemove", onMouseMove);
      window.removeEventListener("mouseup", onMouseUp);
      document.body.style.userSelect = "";
    };
  }, [onMove, win.id, win.w, win.h]);

  if (typeof document === "undefined") return null;

  return createPortal(
    <div
      className="fixed bg-[#EFEFEF] border border-slate-400 shadow-2xl rounded-md overflow-hidden pointer-events-auto flex flex-col font-sans"
      style={{ left: win.x, top: win.y, width: win.w, height: win.h, zIndex: win.z }}
      onMouseDown={onFocus}
    >
      <div
        className="flex items-center justify-between px-3 py-1 bg-[#2C4053] text-[12px] text-white cursor-move select-none shrink-0"
        onMouseDown={(e) => {
          onFocus();
          dragRef.current = { dx: e.clientX - win.x, dy: e.clientY - win.y };
          document.body.style.userSelect = "none";
          e.preventDefault();
        }}
      >
        <span className="font-semibold text-[12px] tracking-wide">{win.title}</span>
        <button
          onClick={onClose}
          className="hover:bg-white/20 rounded p-0.5 transition-colors"
          title="Cerrar"
        >
          <X className="h-4 w-4" />
        </button>
      </div>
      <div className="flex-1 overflow-auto bg-[#EFEFEF] text-slate-800">{children}</div>
    </div>,
    document.body
  );
}

function estadoSunat(row: FacturaRow): string {
  if (row.extra_data?.sunat_status) return String(row.extra_data.sunat_status);
  if (row.status === "issued") return "ACEPTADO";
  if (row.status === "cancelled") return "BAJA";
  if (row.status === "sent") return "ENVIADO";
  return "PENDIENTE";
}

function etiquetaEstado(status: string): string {
  if (status === "draft") return "GENERADO";
  if (status === "issued") return "APROBADO";
  if (status === "cancelled") return "ANULADO";
  if (status === "sent") return "ENVIADO";
  return status.toUpperCase();
}

function YearSpinner({ value, onChange }: { value: string; onChange: (next: string) => void }) {
  const currentYear = Number(value || new Date().getFullYear());
  const stepYear = (delta: number) => {
    const next = Math.max(2000, currentYear + delta);
    onChange(String(next));
  };

  return (
    <div className="flex h-7 w-[82px] items-stretch overflow-hidden rounded border border-slate-300 bg-white shadow-xs">
      <input
        type="number"
        min={2000}
        value={value}
        onChange={(e) => {
          const next = e.target.value;
          onChange(next === "" ? String(new Date().getFullYear()) : next);
        }}
        className="w-[58px] border-0 bg-transparent px-2 py-0 text-[11px] font-mono text-slate-800 outline-none [appearance:textfield] [&::-webkit-inner-spin-button]:appearance-none [&::-webkit-outer-spin-button]:appearance-none"
      />
      <div className="flex w-[18px] flex-col border-l border-slate-300">
        <button
          type="button"
          className="flex h-1/2 w-full items-center justify-center bg-slate-100 text-slate-700 transition-colors hover:bg-slate-200"
          title="Subir año"
          onClick={() => stepYear(1)}
        >
          <ChevronUp className="h-3 w-3" />
        </button>
        <button
          type="button"
          className="flex h-1/2 w-full items-center justify-center border-t border-slate-300 bg-slate-100 text-slate-700 transition-colors hover:bg-slate-200"
          title="Bajar año"
          onClick={() => stepYear(-1)}
        >
          <ChevronDown className="h-3 w-3" />
        </button>
      </div>
    </div>
  );
}

function MonthSelector({ value, onChange }: { value: string; onChange: (next: string) => void }) {
  const [open, setOpen] = useState(false);
  const [sortMode, setSortMode] = useState<"code" | "month">("code");
  const [sortDirection, setSortDirection] = useState<"asc" | "desc">("asc");
  const ref = useRef<HTMLDivElement | null>(null);

  useEffect(() => {
    const handleClickOutside = (event: MouseEvent) => {
      if (!ref.current) return;
      if (!ref.current.contains(event.target as Node)) {
        setOpen(false);
      }
    };

    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, []);

  const selectedLabel = value ? MESES[Number(value) - 1] ?? "Todos" : "Todos";

  const monthRows = useMemo(() => {
    return MESES.map((month, index) => ({
      code: String(index + 1).padStart(2, "0"),
      value: String(index + 1),
      month,
    })).sort((a, b) => {
      if (sortMode === "code") {
        const diff = Number(a.value) - Number(b.value);
        return sortDirection === "asc" ? diff : -diff;
      }
      const diff = a.month.localeCompare(b.month, "es");
      return sortDirection === "asc" ? diff : -diff;
    });
  }, [sortMode, sortDirection]);

  const handleSortToggle = (mode: "code" | "month") => {
    if (sortMode === mode) {
      setSortDirection((prev) => (prev === "asc" ? "desc" : "asc"));
      return;
    }

    setSortMode(mode);
    setSortDirection("asc");
  };

  return (
    <div ref={ref} className="relative w-full">
      <button
        type="button"
        className={`${inp} flex w-full items-center justify-between gap-2 px-2 text-left`}
        onClick={() => setOpen((prev) => !prev)}
      >
        <span className="truncate text-[11px] text-slate-700">{selectedLabel}</span>
        <ChevronDown className="h-3.5 w-3.5 text-slate-500" />
      </button>

      {open && (
        <div className="absolute z-40 mt-1 w-[220px] overflow-hidden rounded-sm border border-slate-300 bg-white shadow-lg">
          <div className="max-h-64 overflow-auto">
            <div className="grid grid-cols-[58px_1fr] items-center border-b border-slate-200 bg-slate-100 px-2 py-1 text-[10px] font-semibold uppercase tracking-wide text-slate-600">
              <button
                type="button"
                onClick={() => handleSortToggle("code")}
                className="flex items-center justify-center gap-1 text-center transition-colors duration-150 hover:bg-slate-200/80 rounded-sm px-1 focus:outline-none"
              >
                <span>Codigo</span>
                {sortMode === "code" && (
                  <span className="text-[9px]">{sortDirection === "asc" ? "▲" : "▼"}</span>
                )}
              </button>
              <button
                type="button"
                onClick={() => handleSortToggle("month")}
                className="flex items-center justify-center gap-1 border-l border-slate-300 pl-2 text-center transition-colors duration-150 hover:bg-slate-200/80 rounded-sm px-1 focus:outline-none"
              >
                <span>Mes</span>
                {sortMode === "month" && (
                  <span className="text-[9px]">{sortDirection === "asc" ? "▲" : "▼"}</span>
                )}
              </button>
            </div>
            <button
              type="button"
              className="grid w-full grid-cols-[58px_1fr] items-center border-b border-slate-200 px-2 py-1 text-[11px] text-slate-700 transition-colors duration-150 hover:bg-slate-200/80"
              onClick={() => {
                onChange("");
                setOpen(false);
              }}
            >
              <span className="text-center font-mono">--</span>
              <span className="border-l border-slate-300 pl-2 text-center">Todos</span>
            </button>
            {monthRows.map(({ code, value: monthValue, month }) => {
              const active = value === monthValue;
              return (
                <button
                  key={month}
                  type="button"
                  className={`grid w-full grid-cols-[58px_1fr] items-center border-b border-slate-200 px-2 py-1 text-[11px] transition-colors duration-150 ${active ? "bg-[#EAF2FF] text-[#1F3E68] font-semibold" : "text-slate-700 hover:bg-slate-200/80"}`}
                  onClick={() => {
                    onChange(monthValue);
                    setOpen(false);
                  }}
                >
                  <span className="text-center font-mono text-slate-600">{code}</span>
                  <span className="border-l border-slate-300 pl-2 text-center">{month}</span>
                </button>
              );
            })}
          </div>
        </div>
      )}
    </div>
  );
}

function FacturaForm({ factura, onClose, onSaved }: FacturaFormProps) {
  const isNew = !factura;
  const [saving, setSaving] = useState(false);

  const [serie] = useState(factura?.series ?? "F001");
  const [number, setNumber] = useState(factura?.number ? String(factura.number) : "511");
  const [fecha, setFecha] = useState((factura?.date ?? new Date().toISOString()).slice(0, 10));
  const [cliente, setCliente] = useState(factura?.client_id ?? "");
  const [descripcion] = useState(factura?.items?.[0]?.description ?? "VENTA DE PRODUCTOS");
  const [cantidad] = useState(String(factura?.items?.[0]?.quantity ?? 1));
  const [precio] = useState(String(factura?.items?.[0]?.price ?? 0));
  const [moneda, setMoneda] = useState(factura?.extra_data?.moneda ?? "USD");
  const [igv, setIgv] = useState(String(factura?.extra_data?.igv ?? "18.00"));
  const [tipoCambio, setTipoCambio] = useState<string>(() => {
    const valueFromFactura = factura?.extra_data?.tipo_cambio;
    const valueFromSession = getSessionTipoCambioCompra();
    return String(valueFromFactura ?? valueFromSession ?? 3.402);
  });

  useEffect(() => {
    if (factura?.extra_data?.tipo_cambio != null) return;
    const sessionValue = getSessionTipoCambioCompra();
    if (sessionValue != null) {
      setTipoCambio(String(sessionValue));
      return;
    }

    fetchSession()
      .then((session) => {
        if (session.tipo_cambio_compra != null) {
          setTipoCambio(String(session.tipo_cambio_compra));
        }
      })
      .catch(() => {
        setTipoCambio("3.402");
      });
  }, [factura?.extra_data?.tipo_cambio]);

  const [direccionFiscal, setDireccionFiscal] = useState(String(factura?.extra_data?.direccion_fiscal ?? ""));
  const [locCliente, setLocCliente] = useState(String(factura?.extra_data?.loc_cliente ?? ""));
  const [motivo, setMotivo] = useState(String(factura?.extra_data?.motivo ?? "Venta"));
  const [guias, setGuias] = useState(String(factura?.extra_data?.guias ?? ""));
  const [condPago, setCondPago] = useState(String(factura?.extra_data?.cond_pago ?? "CONTADO"));
  const [cotizas, setCotizas] = useState(String(factura?.extra_data?.cotizas ?? ""));
  const [oc, setOc] = useState(String(factura?.extra_data?.oc ?? ""));
  const [vendedor, setVendedor] = useState(String(factura?.extra_data?.vendedor ?? ""));
  const [tipoAfectacion, setTipoAfectacion] = useState(
    String(factura?.extra_data?.tipo_afectacion_igv ?? "Gravado - Operación One")
  );
  const [afectoDetraccion, setAfectoDetraccion] = useState(
    Boolean(factura?.extra_data?.afecto_detraccion ?? false)
  );
  const [tipoDetraccion, setTipoDetraccion] = useState(
    String(factura?.extra_data?.tipo_detraccion ?? "")
  );
  const [numOrden, setNumOrden] = useState(String(factura?.extra_data?.num_orden ?? ""));
  const [nota, setNota] = useState(String(factura?.extra_data?.nota ?? ""));
  const [flete, setFlete] = useState(String(factura?.extra_data?.flete ?? "0.00"));
  const [embarque, setEmbarque] = useState(String(factura?.extra_data?.embarque ?? "0.00"));

  const qty = Number(cantidad) || 0;
  const unitPrice = Number(precio) || 0;
  const subtotal = Number((qty * unitPrice).toFixed(2));
  const tax = Number((subtotal * 0.18).toFixed(2));
  const total = Number((subtotal + tax).toFixed(2));
  const statusLabel = isNew ? "" : factura?.status?.toUpperCase() ?? "NUEVA";

  const handleSave = async () => {
    if (!descripcion.trim()) {
      toast.error("La descripción es obligatoria");
      return;
    }
    setSaving(true);
    try {
      const payload = {
        series: serie || "F001",
        number: number ? Number(number) : undefined,
        date: fecha,
        client_id: cliente || undefined,
        items: [{ description: descripcion, unit: "UND", quantity: qty || 1, price: unitPrice }],
        subtotal,
        tax,
        total,
        extra_data: {
          ...(factura?.extra_data ?? {}),
          moneda,
          igv: Number(igv) || 0,
          tipo_cambio: Number(tipoCambio) || 0,
          direccion_fiscal: direccionFiscal || undefined,
          loc_cliente: locCliente || undefined,
          motivo: motivo || undefined,
          guias: guias || undefined,
          cond_pago: condPago || undefined,
          cotizas: cotizas || undefined,
          oc: oc || undefined,
          vendedor: vendedor || undefined,
          tipo_afectacion_igv: tipoAfectacion || undefined,
          afecto_detraccion: afectoDetraccion || undefined,
          tipo_detraccion: tipoDetraccion || undefined,
          num_orden: numOrden || undefined,
          flete: Number(flete) || 0,
          embarque: Number(embarque) || 0,
          nota: nota || undefined,
        },
      };

      if (isNew) {
        await createFactura(payload);
        toast.success("Factura registrada");
      } else {
        await updateFactura(factura.id, payload);
        toast.success("Factura actualizada");
      }
      onSaved();
    } catch (e: any) {
      toast.error(e.message ?? "Error al guardar factura");
    } finally {
      setSaving(false);
    }
  };

  return (
    <div className="h-full flex flex-col overflow-hidden bg-[#F3F6FA] text-[11px] select-none">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-300 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Editar cabecera"><Pencil className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Sugerir factor"><Filter className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Grabar" onClick={handleSave} disabled={saving}><Save className="h-4 w-4 text-emerald-700" /></button>
        {tbSep}
        <button className={iconBtn} title="Deshacer" onClick={onClose}><RefreshCw className="h-4 w-4 text-blue-600" /></button>
        {tbSep}
        <button className={iconBtn} title="Transportista"><Package className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar moneda"><DollarSign className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Salir" onClick={onClose}><ArrowRight className="h-4 w-4 text-red-600" /></button>
      </div>

      <div className="text-center text-[11px] font-semibold text-slate-800 py-1 bg-[#EEF2F7] border-b border-slate-300">
        OFICINA: LIMA &nbsp;-&nbsp; ALMACEN: COMERCIAL
      </div>

      <div className="p-1.5 overflow-auto flex-1 space-y-1">
        <div className="border border-slate-300 bg-[#F8FBFF] p-2 shadow-sm text-[11px]">
          <div className="min-w-[820px] space-y-1">
            <div className="grid grid-cols-[1fr_auto] gap-2 items-start">
              <div className="space-y-1">
                <div className="grid grid-cols-[150px_160px_135px_100px_130px] gap-1 items-center">
                  <InlineField label="Número" labelWidth="w-[55px]">
                    <input className={`${inp} font-mono`} value={number} onChange={(e) => setNumber(e.target.value)} />
                  </InlineField>
                  <InlineField label="Fecha" labelWidth="w-[45px]">
                    <input className={inp} type="date" value={fecha} onChange={(e) => setFecha(e.target.value)} />
                  </InlineField>
                  <InlineField label="Moneda" labelWidth="w-[52px]">
                    <select className={inp} value={moneda} onChange={(e) => setMoneda(e.target.value)}>
                      <option value="USD">USD</option>
                      <option value="PEN">PEN</option>
                    </select>
                  </InlineField>
                  <InlineField label="IGV" labelWidth="w-[32px]">
                    <input className={`${inp} font-mono`} value={igv} onChange={(e) => setIgv(e.target.value)} />
                  </InlineField>
                  <InlineField label="Tip.Cam." labelWidth="w-[58px]">
                    <input className={`${inp} font-mono`} value={tipoCambio} onChange={(e) => setTipoCambio(e.target.value)} />
                  </InlineField>
                </div>

                <div className="grid grid-cols-[1fr_1.1fr] gap-2 items-center">
                  <InlineField label="Cliente" labelWidth="w-[65px]">
                    <div className="flex gap-1 w-full">
                      <input className={inp} value={cliente} onChange={(e) => setCliente(e.target.value)} />
                      <button type="button" className={actionBtn} title="Buscar Cliente">
                        <Search className="h-3.5 w-3.5" />
                      </button>
                      <button type="button" className={actionBtn} title="Carpeta Cliente">
                        <FolderPlus className="h-3.5 w-3.5" />
                      </button>
                    </div>
                  </InlineField>
                  <InlineField label="Loc.Clie." labelWidth="w-[75px]">
                    <div className="flex gap-1 w-full">
                      <input className={inp} value={locCliente} onChange={(e) => setLocCliente(e.target.value)} />
                      <button type="button" className={actionBtn} title="Editar Locación Cliente">
                        <MapPin className="h-3.5 w-3.5" />
                      </button>
                    </div>
                  </InlineField>
                </div>

                <div className="grid grid-cols-[1fr_1.1fr] gap-2 items-center">
                  <InlineField label="Dir. Fiscal" labelWidth="w-[65px]">
                    <div className="flex gap-1 w-full">
                      <input className={inp} value={direccionFiscal} onChange={(e) => setDireccionFiscal(e.target.value)} />
                      <button type="button" className={actionBtn} title="Editar Dirección Fiscal">
                        <Building2 className="h-3.5 w-3.5" />
                      </button>
                    </div>
                  </InlineField>
                  <InlineField label="Motivo" labelWidth="w-[75px]">
                    <div className="flex gap-1 w-full">
                      <select className={inp} value={motivo} onChange={(e) => setMotivo(e.target.value)}>
                        <option value="Venta">Venta</option>
                        <option value="Traslado">Traslado</option>
                      </select>
                      <button type="button" className={actionBtn} title="Configurar Motivo">
                        <Building2 className="h-3.5 w-3.5" />
                      </button>
                    </div>
                  </InlineField>
                </div>

                <div className="grid grid-cols-[1fr_1.1fr] gap-2 items-center">
                  <div className="grid grid-cols-[1fr_1.1fr] gap-1 items-center">
                    <InlineField label="Guías" labelWidth="w-[65px]">
                      <div className="flex gap-1 w-full">
                        <input className={inp} value={guias} onChange={(e) => setGuias(e.target.value)} />
                        <button type="button" className={actionBtn} title="Buscar Guías">
                          <Search className="h-3.5 w-3.5" />
                        </button>
                      </div>
                    </InlineField>
                    <InlineField label="Con.Pag." labelWidth="w-[70px]">
                      <select className={inp} value={condPago} onChange={(e) => setCondPago(e.target.value)}>
                        <option value="CONTADO">CONTADO</option>
                        <option value="CREDITO">CREDITO</option>
                      </select>
                    </InlineField>
                  </div>
                  <InlineField label="Cotiz." labelWidth="w-[75px]">
                    <select className={inp} value={cotizas} onChange={(e) => setCotizas(e.target.value)}>
                      <option value=""></option>
                    </select>
                  </InlineField>
                </div>

                <InlineField label="Observación" labelWidth="w-[85px]">
                  <div className="flex gap-1 w-full">
                    <input className={inp} value={nota} onChange={(e) => setNota(e.target.value)} />
                    <button type="button" className={actionBtn} title="Editar observación">
                      <FileSearch className="h-3.5 w-3.5" />
                    </button>
                  </div>
                </InlineField>

                <div className="grid grid-cols-[110px_1fr_260px] gap-2 items-center pt-1">
                  <InlineField label="O/C" labelWidth="w-[35px]">
                    <input className={inp} value={oc} onChange={(e) => setOc(e.target.value)} />
                  </InlineField>
                  <InlineField label="Vendedor" labelWidth="w-[60px]">
                    <input className={inp} value={vendedor} onChange={(e) => setVendedor(e.target.value)} />
                  </InlineField>
                  <InlineField label="Tipo Afectación" labelWidth="w-[100px]">
                    <select className={inp} value={tipoAfectacion} onChange={(e) => setTipoAfectacion(e.target.value)}>
                      <option value="Gravado - Operación One">Gravado - Operación One</option>
                      <option value="Exonerado">Exonerado</option>
                      <option value="Inafecto">Inafecto</option>
                    </select>
                  </InlineField>
                </div>

                <div className="flex items-center gap-4 pt-1">
                  <div className="flex items-center gap-1.5">
                    <span className="text-[11px] font-bold text-slate-800">Afecto a Detracción?</span>
                    <input
                      type="checkbox"
                      className="h-3.5 w-3.5 rounded border-slate-300 text-slate-700 focus:ring-slate-400 cursor-pointer"
                      checked={afectoDetraccion}
                      onChange={(e) => setAfectoDetraccion(e.target.checked)}
                    />
                  </div>
                  <InlineField label="Tipo(%)" labelWidth="w-[60px]" className="w-28">
                    <select className={inp} value={tipoDetraccion} onChange={(e) => setTipoDetraccion(e.target.value)}>
                      <option value=""></option>
                      <option value="4%">4%</option>
                      <option value="10%">10%</option>
                      <option value="12%">12%</option>
                    </select>
                  </InlineField>
                </div>
              </div>

              <div className="flex flex-col gap-1">
                <div className="h-6 bg-slate-200/70 border border-slate-300 rounded-sm flex items-center justify-center text-[11px] font-bold text-slate-800">
                  {statusLabel}
                </div>
                <div className="pt-0.5">
                  <InlineField label="# OT" labelWidth="w-[70px]">
                    <div className="flex gap-1 w-full">
                      <input className={inp} value={numOrden} onChange={(e) => setNumOrden(e.target.value)} />
                      <button type="button" className={actionBtn} title="Buscar OT">
                        <Search className="h-3.5 w-3.5" />
                      </button>
                    </div>
                  </InlineField>
                </div>
                <div className="border border-slate-300 bg-white p-1.5 shadow-xs">
                  <div className="mb-1 text-[11px] font-bold text-slate-800">Gastos Adicionales</div>
                  <div className="space-y-1">
                    <InlineField label="Flete" labelWidth="w-[70px]">
                      <input className={`${inp} font-mono text-right`} value={flete} onChange={(e) => setFlete(e.target.value)} />
                    </InlineField>
                    <InlineField label="Embarque" labelWidth="w-[70px]">
                      <input className={`${inp} font-mono text-right`} value={embarque} onChange={(e) => setEmbarque(e.target.value)} />
                    </InlineField>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export function FacturaVentaList() {
  const [rows, setRows] = useState<FacturaRow[]>([]);
  const [loading, setLoading] = useState(false);
  const [searched, setSearched] = useState(false);

  const [anio, setAnio] = useState(() => getTodayDateParts().year);
  const [mes, setMes] = useState(() => getTodayDateParts().month);
  const [estado, setEstado] = useState("");
  const [numDoc, setNumDoc] = useState("");
  const [cliente, setCliente] = useState("");

  const [selected, setSelected] = useState<FacturaRow | null>(null);
  const [formWindows, setFormWindows] = useState<FacturaFormWindow[]>([]);
  const zRef = useRef(9990);
  const cascadeRef = useRef(0);

  const load = useCallback(async () => {
    setLoading(true);
    try {
      const data = await fetchFacturas({
        anio: anio ? Number(anio) : undefined,
        mes: mes ? Number(mes) : undefined,
        status: estado || undefined,
        number: numDoc ? Number(numDoc) : undefined,
        search: cliente || undefined,
        limit: 500,
      });
      setRows(data);
      setSearched(true);
    } catch (e: any) {
      toast.error(e.message ?? "Error al cargar facturas");
    } finally {
      setLoading(false);
    }
  }, [anio, mes, estado, numDoc, cliente]);

  useEffect(() => {
    load();
  }, [load]);

  const handleEmitir = async () => {
    if (!selected) return;
    try {
      await emitirFactura(selected.id);
      toast.success("Factura emitida");
      await load();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo emitir la factura");
    }
  };

  const handleAnular = async () => {
    if (!selected) return;
    if (!confirm(`¿Anular ${selected.series || "F001"}-${selected.number || ""}?`)) return;
    try {
      await anularFactura(selected.id);
      toast.success("Factura anulada");
      await load();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo anular la factura");
    }
  };

  const handleEliminar = async () => {
    if (!selected) return;
    if (!confirm("¿Eliminar la factura seleccionada?")) return;
    try {
      await deleteFactura(selected.id);
      toast.success("Factura eliminada");
      setSelected(null);
      await load();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo eliminar la factura");
    }
  };

  const openFormWindow = useCallback((idFactura?: string) => {
    const maxW = typeof window !== "undefined" ? window.innerWidth : 1280;
    const maxH = typeof window !== "undefined" ? Math.max(320, window.innerHeight - 56) : 720;
    const isNewForm = !idFactura;
    const targetW = isNewForm ? 960 : 1000;
    const targetH = isNewForm ? 430 : 500;
    const minW = isNewForm ? 850 : 900;
    const minH = isNewForm ? 380 : 440;
    const w = Math.min(targetW, Math.max(minW, maxW - 24));
    const h = Math.min(targetH, Math.max(minH, maxH - 24));
    zRef.current += 1;
    cascadeRef.current = (cascadeRef.current + 1) % 9;
    const offset = cascadeRef.current * 22;
    const id = `factura-form-${Date.now()}-${Math.random().toString(36).slice(2, 6)}`;
    const initialX = 55 + offset;
    const initialY = (isNewForm ? 18 : 32) + offset;
    const x = Math.max(0, Math.min(initialX, Math.max(0, maxW - w)));
    const y = Math.max(0, Math.min(initialY, Math.max(0, maxH - h)));
    setFormWindows((prev) => [
      ...prev,
      {
        id,
        idFactura,
        title: idFactura ? `FACTURA ${idFactura}` : "Registrar Nueva Factura al Credito",
        x,
        y,
        w,
        h,
        z: zRef.current,
      },
    ]);
  }, []);

  const handleNuevo = () => {
    setSelected(null);
    openFormWindow(undefined);
  };

  const handleMostrar = (row: FacturaRow) => {
    setSelected(row);
    openFormWindow(row.id);
  };

  const handleEnviarCorreo = async () => {
    if (!selected) return;
    try {
      await enviarFacturaCorreo(selected.id);
      toast.success("Factura enviada por correo");
      await load();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo enviar el correo");
    }
  };

  const focusFormWindow = useCallback((id: string) => {
    zRef.current += 1;
    setFormWindows((prev) => prev.map((w) => (w.id === id ? { ...w, z: zRef.current } : w)));
  }, []);

  const moveFormWindow = useCallback((id: string, x: number, y: number) => {
    setFormWindows((prev) => prev.map((w) => (w.id === id ? { ...w, x, y } : w)));
  }, []);

  const closeFormWindow = useCallback((id: string) => {
    setFormWindows((prev) => prev.filter((w) => w.id !== id));
  }, []);

  useEffect(() => {
    const onResize = () => {
      const maxW = window.innerWidth;
      const maxH = Math.max(320, window.innerHeight - 56);
      setFormWindows((prev) =>
        prev.map((w) => {
          const nx = Math.max(0, Math.min(w.x, Math.max(0, maxW - w.w)));
          const ny = Math.max(0, Math.min(w.y, Math.max(0, maxH - w.h)));
          return nx === w.x && ny === w.y ? w : { ...w, x: nx, y: ny };
        })
      );
    };
    window.addEventListener("resize", onResize);
    return () => window.removeEventListener("resize", onResize);
  }, []);

  const [sortBy, setSortBy] = useState<{ col: string; asc: boolean }>({ col: "number", asc: false });
  const rowsView = useMemo(() => {
    const arr = [...rows];
    const col = sortBy.col;
    arr.sort((a: any, b: any) => {
      const va = a[col];
      const vb = b[col];
      if (va == null && vb == null) return 0;
      if (va == null) return sortBy.asc ? -1 : 1;
      if (vb == null) return sortBy.asc ? 1 : -1;
      if (typeof va === "number" && typeof vb === "number") return sortBy.asc ? va - vb : vb - va;
      return sortBy.asc ? String(va).localeCompare(String(vb)) : String(vb).localeCompare(String(va));
    });
    return arr;
  }, [rows, sortBy]);

  const toggleSortBy = useCallback((col: string) => {
    setSortBy((prev) => (prev.col === col ? { col, asc: !prev.asc } : { col, asc: true }));
  }, []);

  const findFacturaForWindow = useCallback(
    (idFactura?: string) => (idFactura ? rows.find((r) => r.id === idFactura) : undefined),
    [rows]
  );

  const formWindowElements = formWindows.map((w) => (
    <DraggableFormWindow
      key={w.id}
      win={w}
      onFocus={() => focusFormWindow(w.id)}
      onMove={moveFormWindow}
      onClose={() => closeFormWindow(w.id)}
    >
      <FacturaForm
        factura={findFacturaForWindow(w.idFactura)}
        onClose={() => closeFormWindow(w.id)}
        onSaved={() => {
          closeFormWindow(w.id);
          load();
        }}
      />
    </DraggableFormWindow>
  ));

  const rowsViewElements = rowsView.map((r, i) => {
    const isSel = selected?.id === r.id;
    const estadoText = r.status === "draft" && !isSel ? "" : etiquetaEstado(r.status);
    return (
      <tr
        key={r.id}
        onClick={() => setSelected(r)}
        onDoubleClick={() => handleMostrar(r)}
        className={[
          "cursor-pointer transition-colors",
          i % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]",
          isSel ? "!bg-[#D6E4F4] font-medium" : "hover:bg-[#E8F0F8]/70",
        ].join(" ")}
      >
        <td className="px-3 py-2 border-r border-slate-100 font-mono font-medium">{`${r.series || "F001"}-${String(r.number || "").padStart(6, "0")}`}</td>
        <td className="px-3 py-2 border-r border-slate-100 whitespace-nowrap">{r.date ? new Date(r.date).toLocaleDateString("es-PE") : ""}</td>
        <td className="px-3 py-2 border-r border-slate-100 max-w-[200px] truncate">{r.client_id || "(Sin cliente)"}</td>
        <td className="px-3 py-2 border-r border-slate-100">{r.extra_data?.moneda || "PEN"}</td>
        <td className="px-3 py-2 border-r border-slate-100 font-mono text-right">{r.total.toFixed(2)}</td>
        <td className="px-3 py-2 border-r border-slate-100 font-semibold">{estadoText}</td>
        <td className="px-3 py-2 border-r border-slate-100">{estadoSunat(r)}</td>
        <td className="px-3 py-2 border-r border-slate-100 max-w-[150px] truncate">{String(r.extra_data?.nota || "")}</td>
        <td className="px-3 py-2 border-r border-slate-100 font-mono text-right font-semibold text-slate-700">{r.total.toFixed(2)}</td>
        <td className="px-3 py-2 border-r border-slate-100 font-mono">{String(r.extra_data?.num_orden || "")}</td>
      </tr>
    );
  });

  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      {/* Toolbar principal */}
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Enviar"><Send className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="B2Mining"><Package className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Nueva Factura" onClick={handleNuevo}><Plus className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Mostrar Factura" disabled={!selected} onClick={() => selected && handleMostrar(selected)}><Search className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Eliminar Factura" disabled={!selected} onClick={handleEliminar}><Trash2 className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Mostrar Estados"><Clock className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Facturar OT"><Wrench className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Facturar Grupo G/R"><Package className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Sugerir Factor"><Percent className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Precios Sugeridos"><DollarSign className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar" onClick={load}><RefreshCw className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar Locación"><MapPin className="h-4 w-4" /></button>
        <button className={iconBtn} title="Generar Nota Crédito"><Receipt className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Enviar Nota Crédito"><Mail className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Enviar Factura Electrónica" disabled={!selected} onClick={handleEnviarCorreo}><Send className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Generar Factura Electrónica" disabled={!selected} onClick={handleEmitir}><FileSpreadsheet className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Comunicación de Baja" disabled={!selected} onClick={handleAnular}><X className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Descargar Factura Electrónica"><FileDown className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Listar Facturas"><FileSearch className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
      </div>

      {/* Filtros */}
      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="Año" className="w-[84px]">
          <YearSpinner value={anio} onChange={setAnio} />
        </Field>
        <Field label="Mes" className="w-32">
          <MonthSelector value={mes} onChange={setMes} />
        </Field>
        <Field label="Cliente" className="w-52">
          <input className={inp} value={cliente} onChange={(e) => setCliente(e.target.value)} placeholder="(Todos)" />
        </Field>
        <Field label="Estado" className="w-28">
          <select className={inp} value={estado} onChange={(e) => setEstado(e.target.value)}>
            <option value="">(Todos)</option>
            <option value="draft">GENERADO</option>
            <option value="issued">APROBADO</option>
            <option value="sent">ENVIADO</option>
            <option value="cancelled">ANULADO</option>
          </select>
        </Field>
        <Field label="N° Doc" className="w-20">
          <input className={`${inp} font-mono`} value={numDoc} onChange={(e) => setNumDoc(e.target.value)} />
        </Field>
        <button className={btnPrimary} onClick={load} disabled={loading}>
          <Search className="h-3.5 w-3.5" />
          {loading ? "Buscando..." : "Buscar"}
        </button>
      </div>

      {/* Grid */}
      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <div className="overflow-auto flex-1">
            <table className="w-full text-[11.5px]">
              <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
                <tr>
                  <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy('series')}>
                    Número {sortBy.col === 'series' ? (sortBy.asc ? '▲' : '▼') : ''}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy('date')}>
                    Fecha {sortBy.col === 'date' ? (sortBy.asc ? '▲' : '▼') : ''}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy('client_id')}>
                    Cliente {sortBy.col === 'client_id' ? (sortBy.asc ? '▲' : '▼') : ''}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]">Mon.</th>
                  <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy('total')}>
                    Total {sortBy.col === 'total' ? (sortBy.asc ? '▲' : '▼') : ''}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]">EST</th>
                  <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]">Estado Sunat</th>
                  <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]">Nota</th>
                  <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]">TotNetoSug</th>
                  <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]">NumOrden</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {rowsView.length === 0 ? (
                  <tr>
                    <td colSpan={10} className="text-center py-12 text-slate-400 text-[12px]">
                      {loading ? "Cargando..." : searched ? "Sin registros para los filtros seleccionados" : "Use los filtros y pulse Buscar"}
                    </td>
                  </tr>
                ) : (
                  rowsViewElements
                )}
              </tbody>
            </table>
          </div>
        </div>
      </div>

      {/* Footer */}
      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-[11px] text-slate-700 text-center font-medium flex items-center justify-center whitespace-nowrap overflow-hidden">
        Registros : {rows.length}
      </div>

      {formWindowElements}
    </div>
  );
}