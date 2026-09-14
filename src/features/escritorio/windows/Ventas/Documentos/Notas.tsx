import { createPortal } from "react-dom";
import { useCallback, useEffect, useMemo, useRef, useState, type ReactNode } from "react";
import {
  ArrowRight,
  AlertTriangle,
  Building2,
  DollarSign,
  Download,
  FileSearch,
  FileSpreadsheet,
  FolderOpen,
  LogOut,
  Mail,
  MapPin,
  Package,
  Pencil,
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
  XCircle,
} from "lucide-react";
import { toast } from "sonner";
import {
  createNota,
  fetchNotas,
  fetchSession,
  fetchSigecoomLocations,
  getSessionTipoCambioCompra,
  type FacturaRow,
  type Location,
  updateNota,
} from "@/lib/sigecoom-api";
import { actionBtn, btn, btnPrimary, iconBtn, squareIconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";

function Field({ label, className = "", children }: { label: string; className?: string; children: ReactNode }) {
  return (
    <label className={`flex flex-col gap-0.5 h-full ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium leading-tight">{label}</span>
      <div className="flex-1 flex items-center">{children}</div>
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
  children: ReactNode;
  className?: string;
  labelWidth?: string;
}) {
  return (
    <div className={`flex items-center gap-1 h-7 ${className} hover:bg-slate-50 hover:rounded-sm`}>
      <span className={`${labelWidth} shrink-0 text-right text-[11px] font-semibold text-slate-800 leading-tight`}>{label} :</span>
      <div className="min-w-0 flex-1 flex items-center">{children}</div>
    </div>
  );
}

const MESES = ["ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"];

const ESTADO_COLORS: Record<string, string> = {
  GENERADO: "text-blue-700 bg-blue-50 border-blue-200",
  APROBADO: "text-green-700 bg-green-50 border-green-200",
  CREDITOS: "text-amber-700 bg-amber-50 border-amber-200",
  ANULADO: "text-red-700 bg-red-50 border-red-200",
};

function EstadoBadge({ estado }: { estado: string }) {
  const cls = ESTADO_COLORS[estado] ?? "text-slate-600 bg-slate-50 border-slate-200";
  return <span className={`inline-block px-1.5 py-0 text-[10px] font-bold rounded border ${cls}`}>{estado}</span>;
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

type NotaFormProps = {
  nota?: FacturaRow;
  idNota?: string | number;
  idLocacion?: number;
  onClose: () => void;
  onSaved?: () => void;
  detailOnly?: boolean;
};

type NotaFormWindow = {
  id: string;
  idNota?: string;
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
  win: NotaFormWindow;
  onFocus: () => void;
  onMove: (id: string, x: number, y: number) => void;
  onClose: () => void;
  children: React.ReactNode;
}) {
  const dragRef = useRef<{ dx: number; dy: number } | null>(null);

  useEffect(() => {
    const handleMouseMove = (event: MouseEvent) => {
      if (!dragRef.current) return;
      const maxW = window.innerWidth;
      const maxH = Math.max(320, window.innerHeight - 56);
      const nextXRaw = event.clientX - dragRef.current.dx;
      const nextYRaw = event.clientY - dragRef.current.dy;
      const nextX = Math.max(0, Math.min(nextXRaw, Math.max(0, maxW - win.w)));
      const nextY = Math.max(0, Math.min(nextYRaw, Math.max(0, maxH - win.h)));
      onMove(win.id, nextX, nextY);
    };

    const handleMouseUp = () => {
      dragRef.current = null;
      document.body.style.userSelect = "";
    };

    window.addEventListener("mousemove", handleMouseMove);
    window.addEventListener("mouseup", handleMouseUp);
    return () => {
      window.removeEventListener("mousemove", handleMouseMove);
      window.removeEventListener("mouseup", handleMouseUp);
      document.body.style.userSelect = "";
    };
  }, [onMove, win.id, win.w, win.h]);

  if (typeof document === "undefined") return null;

  return createPortal(
    <div
      className="fixed bg-[#F1F3F8] border border-slate-500 shadow-2xl rounded-sm overflow-hidden pointer-events-auto"
      style={{ left: win.x, top: win.y, width: win.w, height: win.h, zIndex: win.z }}
      onMouseDown={onFocus}
      role="dialog"
      aria-modal="true"
    >
      <div
        className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] border-b border-[#1F2E3F] text-[12px] text-white cursor-move"
        onMouseDown={(e) => {
          onFocus();
          dragRef.current = { dx: e.clientX - win.x, dy: e.clientY - win.y };
          document.body.style.userSelect = "none";
          e.preventDefault();
        }}
      >
        <span className="font-medium">{win.title}</span>
        <button className="hover:bg-white/20 rounded px-1" onClick={onClose} title="Cerrar ventana">
          <X className="h-3.5 w-3.5 text-white" />
        </button>
      </div>
      <div className="h-[calc(100%-31px)] overflow-hidden bg-[#F8FBFF] text-slate-800">{children}</div>
    </div>,
    document.body
  );
}

type FormMode = "view" | "edit" | "new";

export function NotaForm({ nota, idNota, idLocacion = 1, onClose, onSaved, detailOnly = false }: NotaFormProps) {
  const isNew = !idNota;
  const [mode, setMode] = useState<FormMode>(isNew ? "new" : "view");
  const [numDoc, setNumDoc] = useState(isNew ? "" : "");
  const [fecDoc, setFecDoc] = useState(new Date().toISOString().slice(0, 10));
  const [codMon, setCodMon] = useState("NS");
  const [tipCambio, setTipCambio] = useState("3.411");
  const [idCliente, setIdCliente] = useState<number | "">("");
  const [desCliente, setDesCliente] = useState("");
  const [saving, setSaving] = useState(false);
  const [serie] = useState(nota?.series ?? "N001");
  const [showClienteLookup, setShowClienteLookup] = useState(false);
  const [number, setNumber] = useState(nota?.number ? String(nota.number) : "");
  const [fecha, setFecha] = useState((nota?.date ?? new Date().toISOString()).slice(0, 10));
  const [cliente, setCliente] = useState(nota?.client_id ?? "");
  const [moneda, setMoneda] = useState(String((nota?.extra_data?.moneda as string | undefined) ?? "PEN"));
  const [tipoNota, setTipoNota] = useState(String((nota?.extra_data?.tipo_nota as string | undefined) ?? "Crédito"));
  const [igv, setIgv] = useState(String(nota?.extra_data?.igv ?? "18.00"));
  const [tipoCambio, setTipoCambio] = useState<string>(() => {
    const valueFromNota = nota?.extra_data?.tipo_cambio;
    const valueFromSession = getSessionTipoCambioCompra();
    return String(valueFromNota ?? valueFromSession ?? 3.402);
  });

  useEffect(() => {
    if (nota?.extra_data?.tipo_cambio != null) return;
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
  }, [nota?.extra_data?.tipo_cambio]);

  const [direccionFiscal, setDireccionFiscal] = useState(String(nota?.extra_data?.direccion_fiscal ?? ""));
  const [locCliente, setLocCliente] = useState(String(nota?.extra_data?.loc_cliente ?? ""));
  const [motivo, setMotivo] = useState(String(nota?.extra_data?.motivo ?? "Venta"));
  const [guias, setGuias] = useState(String(nota?.extra_data?.guias ?? ""));
  const [condPago, setCondPago] = useState(String(nota?.extra_data?.cond_pago ?? "CONTADO"));
  const [numOrden, setNumOrden] = useState(String(nota?.extra_data?.num_orden ?? ""));
  const [vendedor, setVendedor] = useState(String(nota?.extra_data?.vendedor ?? ""));
  const [tipoAfectacion, setTipoAfectacion] = useState(String(nota?.extra_data?.tipo_afectacion_igv ?? "Gravado - Operación One"));
  const [tipoDoc, setTipoDoc] = useState(String(nota?.extra_data?.tipo_doc ?? "FACT"));
  const [serieDoc, setSerieDoc] = useState(String(nota?.extra_data?.serie_doc ?? ""));
  const [numDocRef, setNumDocRef] = useState(String(nota?.extra_data?.num_doc ?? ""));
  const [motivoReferencia, setMotivoReferencia] = useState(String(nota?.extra_data?.motivo_referencia ?? ""));
  const [notaTexto, setNotaTexto] = useState(String(nota?.extra_data?.nota ?? ""));
  const [descripcion] = useState(nota?.items?.[0]?.description ?? "NOTA DE CRÉDITO");
  const [cantidad] = useState(String(nota?.items?.[0]?.quantity ?? 1));
  const [precio] = useState(String(nota?.items?.[0]?.price ?? 0));

  const editable = mode === "new" || mode === "edit";

  const handleSave = async () => {
    setSaving(true);
    try {
      const qty = Number(cantidad) || 0;
      const unitPrice = Number(precio) || 0;
      const subtotal = Number((qty * unitPrice).toFixed(2));
      const tax = Number((subtotal * 0.18).toFixed(2));
      const total = Number((subtotal + tax).toFixed(2));

      const payload = {
        series: serie || "N001",
        number: number ? Number(number) : undefined,
        date: fecha,
        client_id: cliente || undefined,
        items: [{ description: descripcion, unit: "UND", quantity: qty || 1, price: unitPrice }],
        subtotal,
        tax,
        total,
        extra_data: {
          ...(nota?.extra_data ?? {}),
          moneda,
          tipo_nota: tipoNota,
          igv: Number(igv) || 0,
          tipo_cambio: Number(tipoCambio) || 0,
          direccion_fiscal: direccionFiscal || undefined,
          loc_cliente: locCliente || undefined,
          motivo: motivo || undefined,
          guias: guias || undefined,
          cond_pago: condPago || undefined,
          vendedor: vendedor || undefined,
          tipo_afectacion_igv: tipoAfectacion || undefined,
          num_orden: numOrden || undefined,
          tipo_doc: tipoDoc || undefined,
          serie_doc: serieDoc || undefined,
          num_doc: numDocRef || undefined,
          motivo_referencia: motivoReferencia || undefined,
          nota: notaTexto || undefined,
        },
      };

      if (isNew) {
        await createNota(payload);
        toast.success("Nota registrada");
      } else {
        await updateNota(String(nota?.id ?? idNota ?? ""), payload);
        toast.success("Nota actualizada");
      }
      onSaved?.();
    } catch (e: any) {
      toast.error(e.message ?? "Error al guardar nota");
    } finally {
      setSaving(false);
    }
  };

  return (
    <div className="h-full flex flex-col overflow-hidden bg-[#F3F6FA] text-[11px] select-none">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-300 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Editar cabecera">
          <Pencil className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Grabar" onClick={handleSave} disabled={saving}>
          <Save className="h-4 w-4 text-emerald-700" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Deshacer" onClick={onClose}>
          <RefreshCw className="h-4 w-4 text-blue-600" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Transportista">
          <Package className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Actualizar moneda">
          <DollarSign className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Salir" onClick={onClose}>
          <ArrowRight className="h-4 w-4 text-red-600" />
        </button>
      </div>

      <div className="text-center text-[11px] font-semibold text-slate-800 py-1 bg-[#EEF2F7] border-b border-slate-300 shrink-0">
        OFICINA: LIMA &nbsp;-&nbsp; ALMACEN: COMERCIAL
      </div>

      <div className="flex-1 overflow-hidden min-h-0">
        <div className="border border-slate-300 bg-[#F8FBFF] p-2 shadow-sm text-[11px] h-full flex flex-col">
          <div className="space-y-1 flex-1 flex flex-col">
            <div className="grid grid-cols-[100px_130px_110px_90px_120px] gap-2 items-center">
            <InlineField label="Número" labelWidth="w-[55px]">
              <input
                className={`${inp} font-mono`}
                value={number}
                onChange={(e) => setNumber(e.target.value)}
                readOnly={!editable || !isNew}
              />
            </InlineField>
            <InlineField label="Fecha" labelWidth="w-[45px]">
              <input
                className={inp}
                type="date"
                value={fecha}
                onChange={(e) => setFecha(e.target.value)}
                readOnly={!editable}
              />
            </InlineField>
            <InlineField label="Moneda" labelWidth="w-[52px]">
              <select className={inp} value={moneda} onChange={(e) => setMoneda(e.target.value)} disabled={!editable}>
                <option value="PEN">PEN (S/)</option>
                <option value="USD">USD ($)</option>
              </select>
            </InlineField>
            <InlineField label="I.G.V." labelWidth="w-[32px]">
              <input
                className={`${inp} font-mono`}
                value={igv}
                onChange={(e) => setIgv(e.target.value)}
                readOnly={!editable}
              />
            </InlineField>
            <InlineField label="T.Cambio" labelWidth="w-[58px]">
              <input
                className={`${inp} font-mono`}
                value={tipoCambio}
                onChange={(e) => setTipoCambio(e.target.value)}
                readOnly={!editable}
              />
            </InlineField>
          </div>

          <div className="grid grid-cols-[1fr_95px_95px] gap-2 items-center">
            <InlineField label="Cliente" labelWidth="w-[65px]">
              <div className="flex gap-1 items-center w-full">
                <input
                  className={inp}
                  value={desCliente || (idCliente ? `ID: ${idCliente}` : "")}
                  onChange={(e) => setDesCliente(e.target.value)}
                  readOnly={!editable}
                  placeholder="(Buscar cliente…)"
                />
                <button
                  type="button"
                  className={squareIconBtn}
                  title="Buscar Cliente"
                  onClick={() => setShowClienteLookup(true)}
                >
                  <Search className="h-3.5 w-3.5" />
                </button>
                <button type="button" className={actionBtn} title="Carpeta Cliente">
                  <Receipt className="h-3.5 w-3.5" />
                </button>
              </div>
            </InlineField>
            <InlineField label="Tipo" labelWidth="w-[32px]">
              <select className={inp} value={tipoNota} onChange={(e) => setTipoNota(e.target.value)} disabled={!editable}>
                <option value="Crédito">Crédito</option>
                <option value="Débito">Débito</option>
              </select>
            </InlineField>
            <InlineField label="# OT" labelWidth="w-[34px]">
              <div className="flex gap-1 items-center">
                <input className={inp} value={numOrden} onChange={(e) => setNumOrden(e.target.value)} readOnly={!editable} />
                <button type="button" className={actionBtn} title="Buscar OT">
                  <FolderOpen className="h-3.5 w-3.5" />
                </button>
              </div>
            </InlineField>
          </div>

          <div className="grid grid-cols-[1fr_200px] gap-2 items-center">
            <InlineField label="Dir. Fiscal" labelWidth="w-[70px]">
              <div className="flex gap-1 items-center">
                <input className={inp} value={direccionFiscal} onChange={(e) => setDireccionFiscal(e.target.value)} readOnly={!editable} />
                <button type="button" className={actionBtn} title="Editar Dirección Fiscal">
                  <Building2 className="h-3.5 w-3.5" />
                </button>
              </div>
            </InlineField>
            <InlineField label="Loc. Clie." labelWidth="w-[64px]">
              <div className="flex gap-1 items-center">
                <input className={inp} value={locCliente} onChange={(e) => setLocCliente(e.target.value)} readOnly={!editable} />
                <button type="button" className={actionBtn} title="Buscar Locación">
                  <MapPin className="h-3.5 w-3.5" />
                </button>
              </div>
            </InlineField>
          </div>

          <div className="grid grid-cols-[140px_155px_1fr] gap-2 items-center">
            <InlineField label="Motivo" labelWidth="w-[38px]">
              <select className={inp} value={motivo} onChange={(e) => setMotivo(e.target.value)} disabled={!editable}>
                <option value="Venta">Venta</option>
                <option value="Traslado">Traslado</option>
                <option value="Otros">Otros</option>
              </select>
            </InlineField>
            <InlineField label="Cond. Pag." labelWidth="w-[72px]">
              <select className={inp} value={condPago} onChange={(e) => setCondPago(e.target.value)} disabled={!editable}>
                <option value="CONTADO">CONTADO</option>
                <option value="CREDITO">CREDITO</option>
              </select>
            </InlineField>
            <InlineField label="Guías" labelWidth="w-[40px]">
              <div className="flex gap-1 items-center">
                <input className={inp} value={guias} onChange={(e) => setGuias(e.target.value)} readOnly={!editable} />
                <button type="button" className={actionBtn} title="Buscar Guías">
                  <Search className="h-3.5 w-3.5" />
                </button>
              </div>
            </InlineField>
          </div>

          <InlineField label="Observación" labelWidth="w-[90px]">
            <div className="flex gap-1 items-center w-full">
              <input className={inp} value={notaTexto} onChange={(e) => setNotaTexto(e.target.value)} readOnly={!editable} />
              <button type="button" className={actionBtn} title="Editar observación">
                <FileSearch className="h-3.5 w-3.5" />
              </button>
            </div>
          </InlineField>

          <InlineField label="Vendedor" labelWidth="w-[70px]">
            <input className={inp} value={vendedor} onChange={(e) => setVendedor(e.target.value)} readOnly={!editable} />
          </InlineField>

          <div className="rounded border border-slate-300 bg-white px-3 py-2">
            <div className="text-[11px] font-semibold text-slate-700 mb-2">Referencia</div>
            <div className="grid gap-2">
              <div className="grid grid-cols-[165px_1fr] gap-2 items-center">
                <InlineField label="Tipo Nota" labelWidth="w-[70px]">
                  <select className={inp} value={tipoNota} onChange={(e) => setTipoNota(e.target.value)} disabled={!editable}>
                    <option value="Crédito">Crédito</option>
                    <option value="Débito">Débito</option>
                  </select>
                </InlineField>
                <InlineField label="Motivo" labelWidth="w-[52px]">
                  <input className={inp} value={motivoReferencia} onChange={(e) => setMotivoReferencia(e.target.value)} readOnly={!editable} />
                </InlineField>
              </div>
              <div className="grid grid-cols-[115px_105px_130px_1fr] gap-2 items-center">
                <InlineField label="Tipo Doc" labelWidth="w-[64px]">
                  <select className={inp} value={tipoDoc} onChange={(e) => setTipoDoc(e.target.value)} disabled={!editable}>
                    <option value="FACT">FACT</option>
                    <option value="BOL">BOL</option>
                    <option value="NCD">NCD</option>
                  </select>
                </InlineField>
                <InlineField label="Serie" labelWidth="w-[45px]">
                  <input className={inp} value={serieDoc} onChange={(e) => setSerieDoc(e.target.value)} readOnly={!editable} />
                </InlineField>
                <InlineField label="N° Doc" labelWidth="w-[42px]">
                  <input className={inp} value={numDocRef} onChange={(e) => setNumDocRef(e.target.value)} readOnly={!editable} />
                </InlineField>
                <InlineField label="Tipo Afectación IGV" labelWidth="w-[120px]">
                  <select className={inp} value={tipoAfectacion} onChange={(e) => setTipoAfectacion(e.target.value)} disabled={!editable}>
                    <option value="Gravado - Operación One">Gravado - Operación One</option>
                    <option value="Exonerado">Exonerado</option>
                    <option value="Inafecto">Inafecto</option>
                  </select>
                </InlineField>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    </div>
  );
}

export function NotaVentaList() {
  const [rows, setRows] = useState<FacturaRow[]>([]);
  const [searched, setSearched] = useState(false);
  const [locations, setLocations] = useState<Location[]>([]);
  const [loading, setLoading] = useState(false);
  const [anio, setAnio] = useState(String(new Date().getFullYear()));
  const [mes, setMes] = useState(String(new Date().getMonth() + 1));
  const [estado, setEstado] = useState("");
  const [numDoc, setNumDoc] = useState("");
  const [cliente, setCliente] = useState("");
  const [officeFilter, setOfficeFilter] = useState("");
  const [warehouseFilter, setWarehouseFilter] = useState("");
  const [selected, setSelected] = useState<FacturaRow | null>(null);
  const [formWindows, setFormWindows] = useState<NotaFormWindow[]>([]);
  const zRef = useRef(9990);
  const cascadeRef = useRef(0);

  const load = useCallback(async () => {
    setLoading(true);
    try {
      const data = await fetchNotas({
        anio: anio ? Number(anio) : undefined,
        mes: mes ? Number(mes) : undefined,
        status: estado || undefined,
        number: numDoc ? Number(numDoc) : undefined,
        search: cliente || undefined,
        limit: 500,
      });
      setRows(data);
    } catch (e: any) {
      toast.error(e.message ?? "Error al cargar notas");
    } finally {
      setLoading(false);
    }
  }, [anio, mes, estado, numDoc, cliente]);

  useEffect(() => {
    load();
  }, [load]);

  useEffect(() => {
    let mounted = true;
    fetchSigecoomLocations()
      .then((data) => {
        if (mounted) setLocations(data);
      })
      .catch(() => undefined);
    return () => {
      mounted = false;
    };
  }, []);

  const officeOptions = useMemo(() => Array.from(new Set(locations.map((loc) => loc.code))).filter(Boolean), [locations]);
  const warehouseOptions = useMemo(() => Array.from(new Set(locations.map((loc) => loc.warehouse))).filter(Boolean), [locations]);

  const openFormWindow = useCallback((idNota?: string) => {
    const maxW = typeof window !== "undefined" ? window.innerWidth : 1280;
    const maxH = typeof window !== "undefined" ? Math.max(360, window.innerHeight - 56) : 720;
    const isNewForm = !idNota;
    const targetW = isNewForm ? 1300 : 1400;
    const targetH = isNewForm ? 1000 : 1080;
    const minW = isNewForm ? 1200 : 1300;
    const minH = isNewForm ? 900 : 950;
    const w = Math.min(targetW, Math.max(minW, maxW - 24));
    const h = Math.min(targetH, Math.max(minH, maxH - 24));
    zRef.current += 1;
    cascadeRef.current = (cascadeRef.current + 1) % 9;
    const offset = cascadeRef.current * 22;
    const id = `nota-form-${Date.now()}-${Math.random().toString(36).slice(2, 6)}`;
    const initialX = 55 + offset;
    const initialY = (isNewForm ? 18 : 32) + offset;
    const x = Math.max(0, Math.min(initialX, Math.max(0, maxW - w)));
    const y = Math.max(0, Math.min(initialY, Math.max(0, maxH - h)));
    setFormWindows((prev) => [
      ...prev,
      {
        id,
        idNota,
        title: idNota ? `NOTA ${idNota}` : "Registrar Nueva Nota de Crédito",
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

  const findNotaForWindow = useCallback(
    (idNota?: string) => (idNota ? rows.find((r) => r.id === idNota) : undefined),
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
      <NotaForm
        nota={findNotaForWindow(w.idNota)}
        idNota={w.idNota}
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
        <td className="px-3 py-2 border-r border-slate-100 font-mono font-medium">{`${r.series || "N001"}-${String(r.number || "").padStart(6, "0")}`}</td>
        <td className="px-3 py-2 border-r border-slate-100 whitespace-nowrap">{r.date ? new Date(r.date).toLocaleDateString("es-PE") : ""}</td>
        <td className="px-3 py-2 border-r border-slate-100 max-w-[200px] truncate">{r.client_id || "(Sin cliente)"}</td>
        <td className="px-3 py-2 border-r border-slate-100">{r.extra_data?.moneda || "PEN"}</td>
        <td className="px-3 py-2 border-r border-slate-100 font-mono text-right">{r.total.toFixed(2)}</td>
        <td className="px-3 py-2 border-r border-slate-100 font-semibold">{estadoText}</td>
        <td className="px-3 py-2 border-r border-slate-100">{estadoSunat(r)}</td>
        <td className="px-3 py-2 border-r border-slate-100">{String(r.extra_data?.tipo_nota || "")}</td>
        <td className="px-3 py-2 border-r border-slate-100 max-w-[200px] truncate">{String(r.extra_data?.nota || "")}</td>
        <td className="px-3 py-2 border-r border-slate-100 font-mono">{String(r.extra_data?.num_orden || "")}</td>
      </tr>
    );
  });

  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Imprimir Documento"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Crear un Nuevo Registro" onClick={handleNuevo}><Plus className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Mostrar los datos del registro seleccionado" disabled={!selected} onClick={() => selected && handleMostrar(selected)}>
          <Search className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Eliminar el registro seleccionado" disabled={!selected}>
          <Trash2 className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Anular" disabled={!selected}>
          <XCircle className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Enviar Factura Electrónica" disabled={!selected}>
          <Send className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Actualizar" onClick={() => void load()}>
          <RefreshCw className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Comunicado de Baja Nota Electrónica" disabled={!selected}>
          <AlertTriangle className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Descargar Nota Electrónica" disabled={!selected}>
          <Download className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Listar notas electrónicas">
          <FileSpreadsheet className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Listar notas electrónicas">
          <Mail className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Cerrar la ventana actual">
          <LogOut className="h-4 w-4" />
        </button>
      </div>

          <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
            <Field label="Año" className="w-14">
              <input className={`${inp} font-mono`} value={anio} onChange={(e) => setAnio(e.target.value)} />
            </Field>
            <Field label="Mes" className="w-24">
              <select className={inp} value={mes} onChange={(e) => setMes(e.target.value)}>
                <option value="">Todos</option>
                {MESES.map((m, i) => (
                  <option key={m} value={String(i + 1)}>{m}</option>
                ))}
              </select>
            </Field>
            <Field label="Oficina" className="w-28">
              <select className={inp} value={officeFilter} onChange={(e) => setOfficeFilter(e.target.value)}>
                <option value="">(Todas)</option>
                {officeOptions.map((code) => (
                  <option key={code} value={code}>{code}</option>
                ))}
              </select>
            </Field>
            <Field label="Almacén" className="w-32">
              <select className={inp} value={warehouseFilter} onChange={(e) => setWarehouseFilter(e.target.value)}>
                <option value="">(Todos)</option>
                {warehouseOptions.map((warehouse) => (
                  <option key={warehouse} value={warehouse}>{warehouse}</option>
                ))}
              </select>
            </Field>
            <Field label="Cliente" className="w-52">
              <div className="flex gap-1">
                <input className={inp} value={cliente} onChange={(e) => setCliente(e.target.value)} placeholder="(Todos)" />
                <button className={btn} type="button" title="Buscar cliente">
                  <Search className="h-3 w-3" />
                </button>
              </div>
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
            <Field label="Número" className="w-20">
              <input className={`${inp} font-mono`} value={numDoc} onChange={(e) => setNumDoc(e.target.value)} />
            </Field>
            <button className={btnPrimary} onClick={() => void load()} disabled={loading}>
              <Search className="h-3.5 w-3.5" />{loading ? "Buscando…" : "Buscar"}
            </button>
          </div>

          <div className="flex-1 min-h-0 overflow-auto p-1.5">
            <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
              <div className="overflow-auto flex-1">
              <table className="w-full text-[11.5px]">
                <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
                  <tr>
                    <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]">Serie</th>
                    <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'fec_doc' ? { col: 'fec_doc', asc: !prev.asc } : { col: 'fec_doc', asc: true })}>Fecha {sortBy?.col === 'fec_doc' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                    <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'cliente' ? { col: 'cliente', asc: !prev.asc } : { col: 'cliente', asc: true })}>Cliente {sortBy?.col === 'cliente' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                    <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'cod_mon' ? { col: 'cod_mon', asc: !prev.asc } : { col: 'cod_mon', asc: true })}>Mon. {sortBy?.col === 'cod_mon' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                    <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'tot_venta' ? { col: 'tot_venta', asc: !prev.asc } : { col: 'tot_venta', asc: false })}>Total {sortBy?.col === 'tot_venta' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                    <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'estado' ? { col: 'estado', asc: !prev.asc } : { col: 'estado', asc: true })}>EST {sortBy?.col === 'estado' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                    <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'estado_sunat' ? { col: 'estado_sunat', asc: !prev.asc } : { col: 'estado_sunat', asc: true })}>Estados Sunat {sortBy?.col === 'estado_sunat' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                    <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]">Tipo</th>
                    <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'observacion' ? { col: 'observacion', asc: !prev.asc } : { col: 'observacion', asc: true })}>Nota {sortBy?.col === 'observacion' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                    <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]">Observacion...</th>
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
