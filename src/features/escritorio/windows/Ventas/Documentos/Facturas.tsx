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
  fetchSigecoomClients,
  fetchSigecoomLocations,
  type Location,
  type SigecoomClient,
  type FacturaRow,
  updateFactura,
} from "@/lib/sigecoom-api";
import { Field, InlineField, YearMonthFields, DraggableFormWindow, CodeDescSelector, ESTADO_FILTER_OPTIONS } from "@/features/escritorio/windows/shared/uiComponents";
import { inp, btn, btnPrimary, iconBtn, actionBtn, squareIconBtn, tbSep } from "@/features/escritorio/windows/uiStyles";


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

const FACTURA_ESTADO_LABELS: Record<string, string> = {
  GN: "GENERADO",
  AP: "APROBADO",
  CR: "CREDITOS",
  AN: "ANULADO",
  IM: "IMPRESO",
  GENERADO: "GENERADO",
  APROBADO: "APROBADO",
  CREDITOS: "CREDITOS",
  ANULADO: "ANULADO",
  IMPRESO: "IMPRESO",
};

function facturaNumero(row: FacturaRow): string {
  const num = row.num_doc ?? row.number;
  return num != null ? String(num) : "";
}

function facturaFecha(row: FacturaRow): string {
  const raw = row.fec_doc || row.date;
  if (!raw) return "";
  try {
    const d = new Date(raw);
    if (isNaN(d.getTime())) return String(raw).slice(0, 10);
    const day = String(d.getDate()).padStart(2, "0");
    const month = String(d.getMonth() + 1).padStart(2, "0");
    const year = d.getFullYear();
    return `${day}/${month}/${year}`;
  } catch (_) {
    return String(raw).slice(0, 10);
  }
}

function facturaCliente(row: FacturaRow): string {
  return row.cliente_nombre || row.client_id || "(Sin cliente)";
}

function facturaMoneda(row: FacturaRow): string {
  const m = String(row.cod_mon || row.extra_data?.moneda || "").trim().toUpperCase();
  if (m.includes("SOL") || m === "01" || m === "MN" || m === "S" || m === "NS") return "NS";
  if (m.includes("DOL") || m.includes("USA") || m === "02" || m === "ME" || m === "D" || m === "USD" || m === "US") return "US";
  return m || "NS";
}

function facturaTotal(row: FacturaRow): number {
  return Number(row.tot_neto ?? row.total ?? 0);
}

function facturaTotNetoSug(row: FacturaRow): number {
  return Number(row.tot_neto_sug ?? 0);
}

function facturaEst(row: FacturaRow): string {
  const raw = String(row.estado || row.status || "").trim().toUpperCase();
  if (raw === "GENERADO") return "GN";
  if (raw === "APROBADO") return "AP";
  if (raw === "CREDITOS") return "CR";
  if (raw === "IMPRESO") return "IM";
  if (raw === "ANULADO") return "AN";
  return raw;
}

function facturaEstadoSunat(row: FacturaRow): string {
  if (row.estado_sunat && String(row.estado_sunat).trim()) return String(row.estado_sunat).trim().toUpperCase();
  if (row.extra_data?.sunat_status) return String(row.extra_data.sunat_status).trim().toUpperCase();
  const est = facturaEst(row);
  if (est === "AN" || est === "ANULADO") return "BAJA";
  if (est === "AP" || est === "IM" || est === "APROBADO" || est === "IMPRESO") return "ACEPTADO";
  return "PENDIENTE";
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
  const [moneda, setMoneda] = useState(String(factura?.extra_data?.moneda ?? "USD"));
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
        await updateFactura(String(factura.id), payload);
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

  const filtered = useMemo(() => {
    return rows.filter((row) => {
      const qDesc = desc.trim().toLowerCase();
      const qDoc = doc.trim().toLowerCase();
      const docNum = row.ruc || row.document_number || "";
      const byDesc = !qDesc || (row.name && row.name.toLowerCase().includes(qDesc));
      const byDoc = !qDoc || docNum.toLowerCase().includes(qDoc);
      return byDesc && byDoc;
    });
  }, [rows, desc, doc]);

  const selectedClient = useMemo(() => rows.find((r) => Number(r.id) === selectedId), [rows, selectedId]);

  return (
    <div className="fixed inset-0 z-[10060] flex items-center justify-center bg-black/40">
      <div className="flex h-[420px] w-[620px] flex-col overflow-hidden rounded-sm border border-slate-400 bg-white shadow-2xl text-[11px]">
        <div className="flex items-center justify-between border-b border-slate-300 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-3 py-1.5">
          <span className="font-semibold text-slate-800">Buscar Cliente</span>
          <button type="button" className={actionBtn} onClick={onClose}>
            <X className="h-3.5 w-3.5" />
          </button>
        </div>

        <div className="grid grid-cols-[1fr_120px] gap-2 border-b border-slate-200 bg-[#F8FBFF] p-2">
          <div className="flex flex-col gap-0.5">
            <span className="text-[10px] text-slate-600 font-medium">Descripción / Razón Social</span>
            <input
              className={inp}
              placeholder="Buscar por nombre..."
              value={desc}
              onChange={(e) => setDesc(e.target.value)}
              autoFocus
            />
          </div>
          <div className="flex flex-col gap-0.5">
            <span className="text-[10px] text-slate-600 font-medium">N° Documento</span>
            <input
              className={`${inp} font-mono`}
              placeholder="RUC / DNI"
              value={doc}
              onChange={(e) => setDoc(e.target.value)}
            />
          </div>
        </div>

        <div className="flex-1 overflow-auto p-1">
          <table className="w-full text-[11px] border-collapse">
            <thead className="sticky top-0 bg-[#EEF2F7] text-slate-700">
              <tr>
                <th className="border-b border-r border-slate-300 px-2 py-1 text-left">Documento</th>
                <th className="border-b border-slate-300 px-2 py-1 text-left">Razón Social / Nombre</th>
              </tr>
            </thead>
            <tbody>
              {loading ? (
                <tr><td colSpan={2} className="py-8 text-center text-slate-400">Cargando clientes...</td></tr>
              ) : filtered.length === 0 ? (
                <tr><td colSpan={2} className="py-8 text-center text-slate-400">No se encontraron clientes</td></tr>
              ) : (
                filtered.map((c) => {
                  const isSel = Number(c.id) === selectedId;
                  return (
                    <tr
                      key={c.id}
                      className={`cursor-pointer border-b border-slate-100 ${isSel ? "bg-[#D6E4F4] font-medium" : "hover:bg-[#E8F0F8]/60"}`}
                      onClick={() => setSelectedId(Number(c.id))}
                      onDoubleClick={() => {
                        onSelect(c);
                        onClose();
                      }}
                    >
                      <td className="border-r border-slate-100 px-2 py-1 font-mono text-slate-600">{c.ruc || c.document_number || "-"}</td>
                      <td className="px-2 py-1 text-slate-800">{c.name}</td>
                    </tr>
                  );
                })
              )}
            </tbody>
          </table>
        </div>

        <div className="flex items-center justify-end gap-2 border-t border-slate-300 bg-[#EEF2F7] px-3 py-1.5">
          <button
            type="button"
            className={btnPrimary}
            disabled={!selectedClient}
            onClick={() => {
              if (selectedClient) {
                onSelect(selectedClient);
                onClose();
              }
            }}
          >
            Seleccionar
          </button>
          <button type="button" className={btn} onClick={onClose}>
            Cancelar
          </button>
        </div>
      </div>
    </div>
  );
}

export function FacturaVentaList() {
  const [rows, setRows] = useState<FacturaRow[]>([]);
  const [loading, setLoading] = useState(false);
  const [searched, setSearched] = useState(false);

  // Lookups
  const [locations, setLocations] = useState<Location[]>([]);

  // Filtros principales (idénticos a frmFacturas.vb)
  const [anio, setAnio] = useState(() => getTodayDateParts().year);
  const [mes, setMes] = useState("");
  const [officeFilter, setOfficeFilter] = useState("");
  const [warehouseFilter, setWarehouseFilter] = useState("");
  const [locationFilterId, setLocationFilterId] = useState<number | "">("");
  const [tipFac, setTipFac] = useState("1"); // 1 = Credito, 2 = Contado
  const [serieFilter, setSerieFilter] = useState("");
  const [clientFilterId, setClientFilterId] = useState<number | "">("");
  const [clientFilterLabel, setClientFilterLabel] = useState("(Todos)");
  const [showClientLookup, setShowClientLookup] = useState(false);
  const [estado, setEstado] = useState("");
  const [numDoc, setNumDoc] = useState("");

  const [selected, setSelected] = useState<FacturaRow | null>(null);
  const [formWindows, setFormWindows] = useState<FacturaFormWindow[]>([]);
  const zRef = useRef(9990);
  const cascadeRef = useRef(0);

  useEffect(() => {
    fetchSigecoomLocations()
      .then((locs) => setLocations(locs))
      .catch(() => {});
  }, []);

  const officeOptions = useMemo(
    () => Array.from(new Set(locations.map((loc) => loc.code))).filter(Boolean),
    [locations]
  );
  const warehouseOptions = useMemo(
    () => Array.from(new Set(locations.map((loc) => loc.warehouse))).filter(Boolean),
    [locations]
  );

  useEffect(() => {
    if (!officeFilter && !warehouseFilter) {
      setLocationFilterId("");
      return;
    }
    const candidate = locations.find((loc) => {
      const officeMatch = officeFilter ? loc.code === officeFilter : true;
      const warehouseMatch = warehouseFilter ? loc.warehouse === warehouseFilter : true;
      return officeMatch && warehouseMatch;
    });
    if (candidate) {
      setLocationFilterId(Number(candidate.id));
    }
  }, [officeFilter, warehouseFilter, locations]);

  const load = useCallback(async () => {
    setLoading(true);
    try {
      const queryParams = {
        anio: anio ? Number(anio) : undefined,
        mes: mes ? Number(mes) : undefined,
        id_locacion: locationFilterId !== "" ? Number(locationFilterId) : undefined,
        tip_fac: tipFac || undefined,
        id_serie_doc: undefined,
        id_cliente: clientFilterId !== "" ? Number(clientFilterId) : undefined,
        estado: estado || undefined,
        num_doc: numDoc ? Number(numDoc) : undefined,
        search: clientFilterId === "" && clientFilterLabel !== "(Todos)" ? clientFilterLabel : undefined,
        limit: 500,
      };

      const data = await fetchFacturas(queryParams);
      setRows(data);
      setSearched(true);
    } catch (e: any) {
      toast.error(e.message ?? "Error al cargar facturas");
    } finally {
      setLoading(false);
    }
  }, [anio, mes, locationFilterId, tipFac, clientFilterId, clientFilterLabel, estado, numDoc]);

  useEffect(() => {
    load();
  }, [load]);

  const handleEmitir = async () => {
    if (!selected) return;
    try {
      await emitirFactura(String(selected.id));
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
      await anularFactura(String(selected.id));
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
      await deleteFactura(String(selected.id));
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
    openFormWindow(String(row.id));
  };

  const handleEnviarCorreo = async () => {
    if (!selected) return;
    try {
      await enviarFacturaCorreo(String(selected.id));
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

  // Ordenamiento exacto por columnas
  const [sortBy, setSortBy] = useState<{ col: string; asc: boolean }>({ col: "num_doc", asc: false });
  const rowsView = useMemo(() => {
    const arr = [...rows];
    const col = sortBy.col;
    arr.sort((a: any, b: any) => {
      let va = a[col];
      let vb = b[col];
      if (col === "fec_doc") {
        va = a.fec_doc ? new Date(a.fec_doc).getTime() : 0;
        vb = b.fec_doc ? new Date(b.fec_doc).getTime() : 0;
      }
      if (va == null && vb == null) return 0;
      if (va == null) return sortBy.asc ? -1 : 1;
      if (vb == null) return sortBy.asc ? 1 : -1;
      if (typeof va === "number" && typeof vb === "number") return sortBy.asc ? va - vb : vb - va;
      if (typeof va === "boolean" && typeof vb === "boolean") return sortBy.asc ? (va === vb ? 0 : va ? 1 : -1) : (va === vb ? 0 : va ? -1 : 1);
      return sortBy.asc ? String(va).localeCompare(String(vb)) : String(vb).localeCompare(String(va));
    });
    return arr;
  }, [rows, sortBy]);

  const toggleSortBy = useCallback((col: string) => {
    setSortBy((prev) => (prev.col === col ? { col, asc: !prev.asc } : { col, asc: true }));
  }, []);

  const findFacturaForWindow = useCallback(
    (idFactura?: string) => (idFactura ? rows.find((r) => String(r.id) === idFactura) : undefined),
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

  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      {/* Toolbar principal fiel a frmFacturas.vb */}
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

      {/* Datos de Búsqueda fiel a frmFacturas.vb */}
      <div className="flex items-center gap-1.5 flex-wrap px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300 text-[11px]">
        {/* Año */}
        <div className="flex flex-col gap-0.5">
          <span className="text-[10px] text-slate-600 font-medium">Año</span>
          <YearSpinner value={anio} onChange={setAnio} />
        </div>
        {/* Mes */}
        <div className="flex flex-col gap-0.5 w-[110px]">
          <span className="text-[10px] text-slate-600 font-medium">Mes</span>
          <MonthSelector value={mes} onChange={setMes} />
        </div>
        {/* Oficina */}
        <div className="flex flex-col gap-0.5 w-[110px]">
          <span className="text-[10px] text-slate-600 font-medium">Oficina</span>
          <select
            className={inp}
            value={officeFilter}
            onChange={(e) => setOfficeFilter(e.target.value)}
          >
            <option value="">(Todos)</option>
            {officeOptions.map((o) => (
              <option key={o} value={o}>{o}</option>
            ))}
          </select>
        </div>
        {/* Almacén */}
        <div className="flex flex-col gap-0.5 w-[120px]">
          <span className="text-[10px] text-slate-600 font-medium">Almacén</span>
          <select
            className={inp}
            value={warehouseFilter}
            onChange={(e) => setWarehouseFilter(e.target.value)}
          >
            <option value="">(Todos)</option>
            {warehouseOptions.map((w) => (
              <option key={w} value={w}>{w}</option>
            ))}
          </select>
        </div>
        {/* Tipo */}
        <div className="flex flex-col gap-0.5 w-[90px]">
          <span className="text-[10px] text-slate-600 font-medium">Tipo</span>
          <select
            className={inp}
            value={tipFac}
            onChange={(e) => setTipFac(e.target.value)}
          >
            <option value="1">Credito</option>
            <option value="2">Contado</option>
            <option value="">(Todos)</option>
          </select>
        </div>
        {/* Serie */}
        <div className="flex flex-col gap-0.5 w-[85px]">
          <span className="text-[10px] text-slate-600 font-medium">Serie</span>
          <select
            className={inp}
            value={serieFilter}
            onChange={(e) => setSerieFilter(e.target.value)}
          >
            <option value="">(Todos)</option>
            <option value="F001">F001</option>
            <option value="F002">F002</option>
            <option value="F003">F003</option>
            <option value="F005">F005</option>
            <option value="F008">F008</option>
          </select>
        </div>
        {/* Cliente */}
        <div className="flex flex-col gap-0.5 w-[180px]">
          <span className="text-[10px] text-slate-600 font-medium">Cliente</span>
          <div className="flex gap-1">
            <input
              className={inp}
              value={clientFilterLabel}
              placeholder="(Todos)"
              readOnly
            />
            <button
              type="button"
              className={actionBtn}
              title="Limpiar Cliente"
              onClick={() => {
                setClientFilterId("");
                setClientFilterLabel("(Todos)");
              }}
            >
              <X className="h-3.5 w-3.5 text-amber-700" />
            </button>
            <button
              type="button"
              className={actionBtn}
              title="Buscar Cliente"
              onClick={() => setShowClientLookup(true)}
            >
              <Search className="h-3.5 w-3.5" />
            </button>
          </div>
        </div>
        {/* Estado */}
        <div className="flex flex-col gap-0.5 w-[100px]">
          <span className="text-[10px] text-slate-600 font-medium">Estado</span>
          <select
            className={inp}
            value={estado}
            onChange={(e) => setEstado(e.target.value)}
          >
            <option value="">(Todos)</option>
            <option value="GN">GENERADO</option>
            <option value="AP">APROBADO</option>
            <option value="CR">CREDITOS</option>
            <option value="IM">IMPRESO</option>
            <option value="AN">ANULADO</option>
          </select>
        </div>
        {/* Número */}
        <div className="flex flex-col gap-0.5 w-[70px]">
          <span className="text-[10px] text-slate-600 font-medium">Número</span>
          <input
            className={`${inp} font-mono text-center`}
            value={numDoc}
            onChange={(e) => setNumDoc(e.target.value)}
            onKeyDown={(e) => e.key === "Enter" && load()}
          />
        </div>
        {/* Buscar */}
        <button
          type="button"
          className={`${btnPrimary} mt-auto h-7`}
          onClick={load}
          disabled={loading}
        >
          <Search className="h-3.5 w-3.5" />
          <span>{loading ? "Buscando..." : "Buscar"}</span>
        </button>
      </div>

      {/* Grid: Columnas exactas de Facturas de Venta */}
      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <div className="overflow-auto flex-1 h-full">
            <table className="w-full text-[11.5px] border-collapse">
              <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10 select-none shadow-xs">
                <tr>
                  <th className="w-6 px-1 py-1 text-center border-r border-slate-300 font-semibold"></th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy('num_doc')}>
                    Número {sortBy.col === 'num_doc' ? (sortBy.asc ? '▲' : '▼') : ''}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy('fec_doc')}>
                    Fecha {sortBy.col === 'fec_doc' ? (sortBy.asc ? '▲' : '▼') : ''}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy('cliente_nombre')}>
                    Cliente {sortBy.col === 'cliente_nombre' ? (sortBy.asc ? '▲' : '▼') : ''}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy('cod_mon')}>
                    Mon. {sortBy.col === 'cod_mon' ? (sortBy.asc ? '▲' : '▼') : ''}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy('tot_neto')}>
                    Total {sortBy.col === 'tot_neto' ? (sortBy.asc ? '▲' : '▼') : ''}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy('estado')}>
                    EST {sortBy.col === 'estado' ? (sortBy.asc ? '▲' : '▼') : ''}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy('estado_sunat')}>
                    Estado Sunat {sortBy.col === 'estado_sunat' ? (sortBy.asc ? '▲' : '▼') : ''}
                  </th>
                  <th className="w-8 px-1 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy('contabilizado')}>
                    C {sortBy.col === 'contabilizado' ? (sortBy.asc ? '▲' : '▼') : ''}
                  </th>
                  <th className="w-10 px-1 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy('tiene_notas')}>
                    Nota {sortBy.col === 'tiene_notas' ? (sortBy.asc ? '▲' : '▼') : ''}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy('tot_neto_sug')}>
                    TotNetoSug {sortBy.col === 'tot_neto_sug' ? (sortBy.asc ? '▲' : '▼') : ''}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy('num_orden')}>
                    NumOrden {sortBy.col === 'num_orden' ? (sortBy.asc ? '▲' : '▼') : ''}
                  </th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-200">
                {rowsView.length === 0 ? (
                  <tr>
                    <td colSpan={12} className="text-center py-8 text-slate-400 text-[11px]">
                      {loading ? "Cargando facturas..." : searched ? "Sin registros para los filtros seleccionados" : "Use los filtros y pulse Buscar"}
                    </td>
                  </tr>
                ) : (
                  rowsView.map((r, i) => {
                    const isSel = selected?.id === r.id;
                    return (
                      <tr
                        key={r.id}
                        onClick={() => setSelected(r)}
                        onDoubleClick={() => handleMostrar(r)}
                        className={[
                          "cursor-pointer border-b border-slate-200 transition-colors",
                          i % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]",
                          isSel ? "!bg-[#D6E4F4] outline outline-1 outline-[#3E5B7A] font-medium" : "hover:bg-[#E8F0F8]/70",
                        ].join(" ")}
                      >
                        {/* Selector arrow indicator */}
                        <td className="w-6 px-1 py-1 text-center border-r border-slate-200 text-[#2D5A88] text-[10px] select-none font-bold">
                          {isSel ? "▶" : ""}
                        </td>
                        {/* Número */}
                        <td className="px-2 py-1 border-r border-slate-200 font-mono text-center font-semibold text-slate-800">
                          {facturaNumero(r)}
                        </td>
                        {/* Fecha */}
                        <td className="px-2 py-1 border-r border-slate-200 text-center whitespace-nowrap font-mono text-slate-700">
                          {facturaFecha(r)}
                        </td>
                        {/* Cliente */}
                        <td className="px-2 py-1 border-r border-slate-200 max-w-[280px] truncate text-slate-800" title={facturaCliente(r)}>
                          {facturaCliente(r)}
                        </td>
                        {/* Mon. */}
                        <td className="px-2 py-1 border-r border-slate-200 text-center font-mono text-slate-700">
                          {facturaMoneda(r)}
                        </td>
                        {/* Total */}
                        <td className="px-2 py-1 border-r border-slate-200 font-mono text-right font-semibold text-slate-800">
                          {facturaTotal(r).toFixed(2)}
                        </td>
                        {/* EST */}
                        <td className="px-2 py-1 border-r border-slate-200 text-center font-mono font-bold text-slate-800">
                          {facturaEst(r)}
                        </td>
                        {/* Estado Sunat */}
                        <td className="px-2 py-1 border-r border-slate-200 text-center font-medium text-slate-700">
                          {facturaEstadoSunat(r)}
                        </td>
                        {/* C (Contabilizado) */}
                        <td className="w-8 px-1 py-1 border-r border-slate-200 text-center">
                          <input
                            type="checkbox"
                            checked={Boolean(r.contabilizado)}
                            readOnly
                            className="h-3.5 w-3.5 accent-blue-700 pointer-events-none rounded-sm border border-slate-400 bg-white"
                            title={r.contabilizado ? "Contabilizado" : "No contabilizado"}
                          />
                        </td>
                        {/* Nota (TieneNotas) */}
                        <td className="w-10 px-1 py-1 border-r border-slate-200 text-center">
                          <input
                            type="checkbox"
                            checked={Boolean(r.tiene_notas)}
                            readOnly
                            className="h-3.5 w-3.5 accent-blue-700 pointer-events-none rounded-sm border border-slate-400 bg-white"
                            title={r.tiene_notas ? "Tiene nota" : "Sin nota"}
                          />
                        </td>
                        {/* TotNetoSug */}
                        <td className="px-2 py-1 border-r border-slate-200 font-mono text-right font-semibold text-slate-700">
                          {facturaTotNetoSug(r).toFixed(2)}
                        </td>
                        {/* NumOrden */}
                        <td className="px-2 py-1 border-r border-slate-200 font-mono text-slate-700">
                          {String(r.num_orden || r.extra_data?.num_orden || "")}
                        </td>
                      </tr>
                    );
                  })
                )}
              </tbody>
            </table>
          </div>
        </div>
      </div>

      {/* Footer fiel a frmFacturas.vb */}
      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-[11px] text-slate-700 text-center font-medium flex items-center justify-center whitespace-nowrap overflow-hidden">
        Registros : {rows.length}
      </div>

      {showClientLookup && (
        <ClienteLookupModal
          onClose={() => setShowClientLookup(false)}
          onSelect={(c) => {
            setClientFilterId(Number(c.id));
            setClientFilterLabel(c.name);
            setShowClientLookup(false);
          }}
        />
      )}

      {formWindowElements}
    </div>
  );
}