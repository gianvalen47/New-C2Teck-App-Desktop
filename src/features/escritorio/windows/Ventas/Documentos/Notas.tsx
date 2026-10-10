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

function notaNumero(row: any): string {
  const num = row.num_doc ?? row.number;
  if (num === null || num === undefined || num === "") return "";
  return String(num);
}

function notaFecha(row: any): string {
  const f = row.fec_doc ?? row.date;
  if (!f) return "";
  const s = String(f);
  if (s.includes("T")) {
    const [d] = s.split("T");
    const [yy, mm, dd] = d.split("-");
    if (yy && mm && dd) return `${dd}/${mm}/${yy}`;
  }
  if (s.includes("-")) {
    const [yy, mm, dd] = s.slice(0, 10).split("-");
    if (yy && mm && dd) return `${dd}/${mm}/${yy}`;
  }
  return s;
}

function notaCliente(row: any): string {
  return String(row.cliente_nombre ?? row.cliente?.nombre ?? row.client_id ?? "").trim();
}

function notaMoneda(row: any): string {
  const m = String(row.cod_mon ?? row.moneda ?? "").trim().toUpperCase();
  if (m === "US" || m === "USD" || m.includes("DOL")) return "US";
  if (m === "NS" || m === "PEN" || m.includes("SOL")) return "NS";
  return m || "NS";
}

function notaTotal(row: any): number {
  const t = Number(row.tot_neto ?? row.total ?? 0);
  return Number.isFinite(t) ? t : 0;
}

function notaEst(row: any): string {
  const e = String(row.estado ?? row.status ?? "").trim().toUpperCase();
  if (e === "GENERADO") return "GN";
  if (e === "APROBADO") return "AP";
  if (e === "CREDITOS") return "CR";
  if (e === "ANULADO") return "AN";
  if (e === "IMPRESO") return "IM";
  return e.slice(0, 2);
}

function notaEstadoSunat(row: any): string {
  return String(row.estado_sunat ?? "PENDIENTE").trim().toUpperCase();
}

export function NotaVentaList() {
  const [rows, setRows] = useState<any[]>([]);
  const [searched, setSearched] = useState(false);
  const [locations, setLocations] = useState<Location[]>([]);
  const [loading, setLoading] = useState(false);
  const [anio, setAnio] = useState(() => {
    const today = new Date();
    return String(today.getFullYear());
  });
  const [mes, setMes] = useState(() => {
    const today = new Date();
    return String(today.getMonth() + 1);
  });
  const [estado, setEstado] = useState("");
  const [numDoc, setNumDoc] = useState("");
  const [serieFilter, setSerieFilter] = useState("");
  const [officeFilter, setOfficeFilter] = useState("");
  const [warehouseFilter, setWarehouseFilter] = useState("");
  const [clientFilterLabel, setClientFilterLabel] = useState("(Todos)");
  const [clientFilterId, setClientFilterId] = useState("");
  const [selected, setSelected] = useState<any | null>(null);
  const [formWindows, setFormWindows] = useState<NotaFormWindow[]>([]);
  const [sortBy, setSortBy] = useState<{ col: string; asc: boolean }>({ col: "num_doc", asc: false });
  const zRef = useRef(9990);
  const cascadeRef = useRef(0);

  const load = useCallback(async () => {
    setLoading(true);
    setSearched(true);
    try {
      const data = await fetchNotas({
        anio: anio ? Number(anio) : undefined,
        mes: mes ? Number(mes) : undefined,
        estado: estado || undefined,
        cod_serie: serieFilter || undefined,
        num_doc: numDoc ? Number(numDoc) : undefined,
        id_cliente: clientFilterId ? Number(clientFilterId) : undefined,
        limit: 500,
      });
      setRows(data);
      if (data.length > 0) {
        setSelected(data[0]);
      } else {
        setSelected(null);
      }
    } catch (e: any) {
      toast.error(e.message ?? "Error al cargar notas");
      setRows([]);
      setSelected(null);
    } finally {
      setLoading(false);
    }
  }, [anio, mes, estado, serieFilter, numDoc, clientFilterId]);

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

  const handleMostrar = (row: any) => {
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

  const toggleSortBy = (col: string) => {
    setSortBy((prev) => ({
      col,
      asc: prev.col === col ? !prev.asc : true,
    }));
  };

  const rowsView = useMemo(() => {
    const arr = [...rows];
    const col = sortBy.col;
    arr.sort((a: any, b: any) => {
      let va = a[col];
      let vb = b[col];
      if (col === "total" || col === "tot_neto") {
        va = notaTotal(a);
        vb = notaTotal(b);
      }
      if (va == null && vb == null) return 0;
      if (va == null) return sortBy.asc ? -1 : 1;
      if (vb == null) return sortBy.asc ? 1 : -1;
      if (typeof va === "number" && typeof vb === "number") return sortBy.asc ? va - vb : vb - va;
      return sortBy.asc ? String(va).localeCompare(String(vb)) : String(vb).localeCompare(String(va));
    });
    return arr;
  }, [rows, sortBy]);

  const findNotaForWindow = useCallback(
    (idNota?: string) => (idNota ? rows.find((r) => String(r.id) === String(idNota)) : undefined),
    [rows]
  );

  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      {/* Toolbar fiel a frmNotasCredito.vb */}
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
        <button className={iconBtn} title="Enviar Nota Electrónica" disabled={!selected}>
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

      {/* Barra de Filtros fiel a frmNotasCredito.vb */}
      <div className="flex items-center gap-1.5 flex-wrap px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300 text-[11px]">
        {/* Año */}
        <div className="flex flex-col gap-0.5">
          <span className="text-[10px] text-slate-600 font-medium">Año</span>
          <input className={`${inp} w-16 font-mono text-center`} value={anio} onChange={(e) => setAnio(e.target.value)} />
        </div>
        {/* Mes */}
        <div className="flex flex-col gap-0.5 w-[110px]">
          <span className="text-[10px] text-slate-600 font-medium">Mes</span>
          <select className={inp} value={mes} onChange={(e) => setMes(e.target.value)}>
            <option value="">(Todos)</option>
            {MESES.map((m, i) => (
              <option key={m} value={String(i + 1)}>{m}</option>
            ))}
          </select>
        </div>
        {/* Oficina */}
        <div className="flex flex-col gap-0.5 w-[110px]">
          <span className="text-[10px] text-slate-600 font-medium">Oficina</span>
          <select className={inp} value={officeFilter} onChange={(e) => setOfficeFilter(e.target.value)}>
            <option value="">(Todas)</option>
            {officeOptions.map((code) => (
              <option key={code} value={code}>{code}</option>
            ))}
          </select>
        </div>
        {/* Almacén */}
        <div className="flex flex-col gap-0.5 w-[120px]">
          <span className="text-[10px] text-slate-600 font-medium">Almacén</span>
          <select className={inp} value={warehouseFilter} onChange={(e) => setWarehouseFilter(e.target.value)}>
            <option value="">(Todos)</option>
            {warehouseOptions.map((w) => (
              <option key={w} value={w}>{w}</option>
            ))}
          </select>
        </div>
        {/* Serie */}
        <div className="flex flex-col gap-0.5 w-[85px]">
          <span className="text-[10px] text-slate-600 font-medium">Serie</span>
          <select className={inp} value={serieFilter} onChange={(e) => setSerieFilter(e.target.value)}>
            <option value="">(Todos)</option>
            <option value="FN01">FN01</option>
            <option value="BN01">BN01</option>
            <option value="FC01">FC01</option>
            <option value="BC01">BC01</option>
          </select>
        </div>
        {/* Cliente */}
        <div className="flex flex-col gap-0.5 w-[180px]">
          <span className="text-[10px] text-slate-600 font-medium">Cliente</span>
          <div className="flex gap-1">
            <input className={inp} value={clientFilterLabel} placeholder="(Todos)" readOnly />
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
          </div>
        </div>
        {/* Estado */}
        <div className="flex flex-col gap-0.5 w-[100px]">
          <span className="text-[10px] text-slate-600 font-medium">Estado</span>
          <select className={inp} value={estado} onChange={(e) => setEstado(e.target.value)}>
            <option value="">(Todos)</option>
            <option value="GN">GENERADO</option>
            <option value="AP">APROBADO</option>
            <option value="CR">CREDITOS</option>
            <option value="AN">ANULADO</option>
            <option value="IM">IMPRESO</option>
          </select>
        </div>
        {/* Número */}
        <div className="flex flex-col gap-0.5 w-[80px]">
          <span className="text-[10px] text-slate-600 font-medium">Número</span>
          <input className={`${inp} font-mono`} value={numDoc} onChange={(e) => setNumDoc(e.target.value)} placeholder="0" />
        </div>
        {/* Botón Buscar */}
        <div className="flex flex-col justify-end">
          <button className={btnPrimary} onClick={() => void load()} disabled={loading}>
            <Search className="h-3.5 w-3.5" />
            {loading ? "Buscando..." : "Buscar"}
          </button>
        </div>
      </div>

      {/* Grid fiel a dgvDatos de frmNotasCredito.vb */}
      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <div className="overflow-auto flex-1 h-full">
            <table className="w-full text-[11.5px] border-collapse">
              <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10 select-none shadow-xs">
                <tr>
                  <th className="w-6 px-1 py-1 text-center border-r border-slate-300 font-semibold"></th>
                  <th className="w-[55px] px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("cod_serie")}>
                    Serie {sortBy.col === "cod_serie" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="w-[76px] px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("num_doc")}>
                    Número {sortBy.col === "num_doc" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="w-[98px] px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("fec_doc")}>
                    Fecha {sortBy.col === "fec_doc" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("cliente_nombre")}>
                    Cliente {sortBy.col === "cliente_nombre" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="w-[45px] px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("cod_mon")}>
                    Mon. {sortBy.col === "cod_mon" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="w-[99px] px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("tot_neto")}>
                    Total {sortBy.col === "tot_neto" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="w-[35px] px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("estado")}>
                    Est. {sortBy.col === "estado" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("estado_sunat")}>
                    Estado Sunat {sortBy.col === "estado_sunat" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="w-[26px] px-1 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("contabilizado")}>
                    C {sortBy.col === "contabilizado" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="w-[39px] px-1 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("tiene_notas")}>
                    Nota {sortBy.col === "tiene_notas" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                  <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSortBy("observacion_sunat")}>
                    ObservacionSunat {sortBy.col === "observacion_sunat" ? (sortBy.asc ? "▲" : "▼") : ""}
                  </th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-200">
                {rowsView.length === 0 ? (
                  <tr>
                    <td colSpan={12} className="text-center py-8 text-slate-400 text-[11px]">
                      {loading ? "Cargando notas de crédito..." : searched ? "Sin registros para los filtros seleccionados" : "Use los filtros y pulse Buscar"}
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
                        {/* Indicador flecha ▶ */}
                        <td className="w-6 px-1 py-1 text-center border-r border-slate-200 text-[#2D5A88] text-[10px] select-none font-bold">
                          {isSel ? "▶" : ""}
                        </td>
                        {/* Serie */}
                        <td className="w-[55px] px-2 py-1 border-r border-slate-200 text-center font-mono font-medium text-slate-800">
                          {r.cod_serie || r.series || "FN01"}
                        </td>
                        {/* Número */}
                        <td className="w-[76px] px-2 py-1 border-r border-slate-200 font-mono text-center font-semibold text-slate-800">
                          {notaNumero(r)}
                        </td>
                        {/* Fecha */}
                        <td className="w-[98px] px-2 py-1 border-r border-slate-200 text-center whitespace-nowrap font-mono text-slate-700">
                          {notaFecha(r)}
                        </td>
                        {/* Cliente */}
                        <td className="px-2 py-1 border-r border-slate-200 max-w-[330px] truncate text-slate-800" title={notaCliente(r)}>
                          {notaCliente(r)}
                        </td>
                        {/* Mon. */}
                        <td className="w-[45px] px-2 py-1 border-r border-slate-200 text-center font-mono text-slate-700">
                          {notaMoneda(r)}
                        </td>
                        {/* Total */}
                        <td className="w-[99px] px-2 py-1 border-r border-slate-200 font-mono text-right font-semibold text-slate-800">
                          {notaTotal(r).toFixed(2)}
                        </td>
                        {/* Est. */}
                        <td className="w-[35px] px-2 py-1 border-r border-slate-200 text-center font-mono font-bold text-slate-800">
                          {notaEst(r)}
                        </td>
                        {/* Estado Sunat */}
                        <td className="px-2 py-1 border-r border-slate-200 text-center font-medium text-slate-700">
                          {notaEstadoSunat(r)}
                        </td>
                        {/* C (Contabilizado) */}
                        <td className="w-[26px] px-1 py-1 border-r border-slate-200 text-center">
                          <input
                            type="checkbox"
                            checked={Boolean(r.contabilizado)}
                            readOnly
                            className="h-3.5 w-3.5 accent-blue-700 pointer-events-none rounded-sm border border-slate-400 bg-white"
                            title={r.contabilizado ? "Contabilizado" : "No contabilizado"}
                          />
                        </td>
                        {/* Nota (TieneNotas) */}
                        <td className="w-[39px] px-1 py-1 border-r border-slate-200 text-center">
                          <input
                            type="checkbox"
                            checked={Boolean(r.tiene_notas)}
                            readOnly
                            className="h-3.5 w-3.5 accent-blue-700 pointer-events-none rounded-sm border border-slate-400 bg-white"
                            title={r.tiene_notas ? "Tiene nota" : "Sin nota"}
                          />
                        </td>
                        {/* ObservacionSunat */}
                        <td className="px-2 py-1 border-r border-slate-200 text-slate-700 truncate max-w-[200px]" title={r.observacion_sunat || r.observacion || ""}>
                          {r.observacion_sunat || r.observacion || ""}
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

      {/* Footer fiel a sslTotal: "Registros : {count}" */}
      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-[11px] text-slate-700 font-medium flex items-center justify-between whitespace-nowrap overflow-hidden">
        <div>Registros : {rowsView.length}</div>
        <div className="text-[10.5px] text-slate-500">
          Total Selección: {selected ? `${notaMoneda(selected)} ${notaTotal(selected).toFixed(2)}` : "-"}
        </div>
      </div>

      {formWindows.map((w) => (
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
      ))}
    </div>
  );
}

export function Notas() {
  return <NotaVentaList />;
}

export default Notas;

