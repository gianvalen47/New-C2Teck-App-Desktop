/**
 * Guías de Remisión — Módulo completo (frmGuiasRemision + frmGuiaRemision + Transportista)
 *
 * Extraído fielmente de SIGECOM VB.NET:
 *   frmGuiasRemision.vb          → GuiaRemisionList  (listado con filtros)
 *   frmGuiaRemision.vb           → GuiaRemisionForm  (cabecera + detalles)
 *   frmGuiaRemision_Transportista.vb → TransportistaModal
 */

import { useState, useEffect, useCallback, useRef, useMemo } from "react";
import { createPortal } from "react-dom";
import {
  Printer, Plus, Search, Trash2, X, Save, RefreshCw, LogOut,
  Car, CreditCard, Receipt, Package, Filter, Wrench, Clock,
  DollarSign, ArrowDown, FileSpreadsheet, Send,
  ChevronDown, ChevronRight, ChevronUp, Pencil, Check, Trash, Eye,
  Warehouse, UploadCloud, Percent, Download, List, FilePlus2,
  RotateCw, Loader2, FolderOpen
} from "lucide-react";
import { toast } from "sonner";
import {
  fetchGuiasRemision,
  fetchGuiaRemision,
  createGuiaRemision,
  updateGuiaRemision,
  anularGuiaRemision,
  deleteGuiaRemision,
  addGuiaRemisionDet,
  updateGuiaRemisionDet,
  deleteGuiaRemisionDet,
  upsertTransportistaGuia,
  transferirGuiaRemision,
  fetchAtencionJob,
  ingresarConsumoJob,
  fetchGuiaRemisionDigital,
  type JobConsumoItem,
  type GuiaRemisionDigital,
  fetchSigecoomClients,
  fetchSigecoomLocations,
  getSigecoomClient,
  type GuiaRemisionRow,
  type GuiaRemisionFull,
  type GuiaRemisionDet,
  type GuiaRemisionTransportista,
  type SigecoomClient,
  type Location,
} from "@/lib/sigecoom-api";

import { inp, btn, btnPrimary, iconBtn, actionBtn, squareIconBtn, tbSep } from "@/features/escritorio/windows/uiStyles";

function Field({ label, children, className = "" }: { label: string; children: React.ReactNode; className?: string }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium">{label}</span>
      {children}
    </label>
  );
}

function InlineField({
  label, children, className = "", labelWidth = "w-[74px]",
}: { label: string; children: React.ReactNode; className?: string; labelWidth?: string }) {
  return (
    <div className={`flex items-center gap-1 ${className} hover:bg-slate-50 hover:rounded-sm`}>
      <span className={`${labelWidth} shrink-0 text-right text-[11px] font-semibold text-slate-800`}>{label} :</span>
      <div className="min-w-0 flex-1">{children}</div>
    </div>
  );
}

const ESTADO_COLORS: Record<string, string> = {
  GENERADO: "text-blue-700 bg-blue-50 border-blue-200",
  APROBADO: "text-green-700 bg-green-50 border-green-200",
  CREDITOS: "text-amber-700 bg-amber-50 border-amber-200",
  ANULADO:  "text-red-700 bg-red-50 border-red-200",
};

const GUIA_ESTADO_DESCRIPCIONES: Record<string, string> = {
  GN: "GENERADO",
  CR: "CREDITOS",
  AP: "APROBADO",
  IM: "IMPRESO",
  AN: "ANULADO",
  FC: "FACTURADO",
  TR: "TRANSFERIDO",
  GENERADO: "GENERADO",
  CREDITOS: "CREDITOS",
  APROBADO: "APROBADO",
  IMPRESO: "IMPRESO",
  ANULADO: "ANULADO",
  FACTURADO: "FACTURADO",
  TRANSFERIDO: "TRANSFERIDO",
};

// Mismas 6 opciones que antes tenía el <select> de Estado, con su abreviatura real
// (columna "EST" del listado) como código para el selector Código/Descripción.
const ESTADO_FILTER_OPTIONS: CodeDescOption[] = [
  { code: "GN", label: "GENERADO", value: "GENERADO" },
  { code: "AP", label: "APROBADO", value: "APROBADO" },
  { code: "CR", label: "CREDITOS", value: "CREDITOS" },
  { code: "AN", label: "ANULADO", value: "ANULADO" },
  { code: "FC", label: "FACTURADO", value: "FACTURADO" },
  { code: "TR", label: "TRANSFERIDO", value: "TRANSFERIDO" },
];

function getGuideEstadoDisplay(value: string | null | undefined) {
  const raw = String(value ?? "").trim();
  if (!raw) return "";
  const key = raw.toUpperCase();
  const label = GUIA_ESTADO_DESCRIPCIONES[key];
  if (label) {
    return label;
  }
  return raw;
}

function EstadoBadge({ estado }: { estado: string }) {
  const cls = ESTADO_COLORS[estado] ?? "text-slate-600 bg-slate-50 border-slate-200";
  return (
    <span className={`inline-block px-1.5 py-0 text-[10px] font-bold rounded border ${cls}`}>{estado}</span>
  );
}

const MESES = ["ENERO","FEBRERO","MARZO","ABRIL","MAYO","JUNIO","JULIO","AGOSTO","SETIEMBRE","OCTUBRE","NOVIEMBRE","DICIEMBRE"];

function getTodayDateParts() {
  const today = new Date();
  return {
    year: String(today.getFullYear()),
    month: String(today.getMonth() + 1),
  };
}

function pickFirstNonEmpty(...values: Array<string | number | null | undefined>) {
  for (const value of values) {
    if (value === null || value === undefined) continue;
    const text = String(value).trim();
    if (text !== "") return value;
  }
  return "";
}

function getAnyValue(row: any, ...keys: string[]) {
  for (const key of keys) {
    const value = row?.[key];
    if (value === null || value === undefined) continue;
    const text = String(value).trim();
    if (text !== "") return value;
  }
  return "";
}

function findAnyLegacyValue(value: any, aliases: string[]): any {
  if (value === null || value === undefined) return "";

  const normalizedAliases = new Set(aliases.map((alias) => alias.toLowerCase()));
  const visited = new Set<any>();

  const scan = (current: any): any => {
    if (current === null || current === undefined) return "";
    if (typeof current === "string" || typeof current === "number" || typeof current === "boolean") {
      const text = String(current).trim();
      return text !== "" ? current : "";
    }
    if (typeof current !== "object") return "";
    if (visited.has(current)) return "";
    visited.add(current);

    if (Array.isArray(current)) {
      for (const item of current) {
        const found = scan(item);
        if (found !== "" && found !== null && found !== undefined) return found;
      }
      return "";
    }

    for (const [key, nestedValue] of Object.entries(current)) {
      if (!normalizedAliases.has(key.toLowerCase())) continue;

      if (nestedValue === null || nestedValue === undefined) continue;

      if (typeof nestedValue === "string" || typeof nestedValue === "number" || typeof nestedValue === "boolean") {
        const text = String(nestedValue).trim();
        if (text !== "") return nestedValue;
      }

      const nestedFound = scan(nestedValue);
      if (nestedFound !== "" && nestedFound !== null && nestedFound !== undefined) return nestedFound;
    }

    return "";
  };

  return scan(value);
}

function normalizeReferenceDisplay(value: string | number | null | undefined) {
  if (value === null || value === undefined) return "";
  const text = String(value).trim();
  if (!text) return "";
  return text.replace(/\s*\/\s*/g, " / ");
}

function resolveLegacyGuideDisplayFields(g: any) {
  const clientPayload = g?.Cliente ?? g?.cliente ?? {};
  const nestedAddress = pickFirstNonEmpty(
    clientPayload?.Direccion,
    clientPayload?.direccion,
    clientPayload?.DireccionFiscal,
    clientPayload?.direccion_fiscal,
    clientPayload?.DirCli,
    clientPayload?.dir_cli,
    clientPayload?.Direccion?.Direccion,
    clientPayload?.direccion?.Direccion,
  );

  const fiscalObject = g?.DireccionFiscal ?? g?.direccion_fiscal ?? g?.Fiscal ?? g?.fiscal ?? {};
  const motivoObj = g?.Motivos ?? g?.motivos ?? g?.Motivo ?? g?.motivo ?? {};
  const cotizacionObj = g?.Cotizacion ?? g?.cotizacion ?? {};

  const referenceValue = pickFirstNonEmpty(
    findAnyLegacyValue(g, ["NumJob", "num_job", "Referencia", "referencia", "Ref", "ref", "NumFac", "num_fac"]),
    getAnyValue(g, "NumJob", "num_job", "Referencia", "referencia", "Ref", "ref", "NumFac", "num_fac"),
    getAnyValue(g, "NumFac", "num_fac", "NumJob", "num_job", "Referencia", "referencia", "Ref", "ref"),
    (g as any)?.NumJob,
    (g as any)?.num_job,
    (g as any)?.Referencia,
    (g as any)?.referencia,
    (g as any)?.Ref,
    (g as any)?.ref,
  );

  const cotizacionValue = pickFirstNonEmpty(
    findAnyLegacyValue(g, ["IdCotizacion", "id_cotizacion", "NumCot", "num_cot", "Cotizacion", "cotizacion", "Cotiz", "cotiz"]),
    getAnyValue(g, "IdCotizacion", "id_cotizacion", "NumCot", "num_cot", "Cotizacion", "cotizacion", "Cotiz", "cotiz"),
    getAnyValue(g, "NumCot", "num_cot", "IdCotizacion", "id_cotizacion", "Cotizacion", "cotizacion", "Cotiz", "cotiz"),
    cotizacionObj?.IdCotizacion,
    cotizacionObj?.id_cotizacion,
    cotizacionObj?.NumCot,
    cotizacionObj?.num_cot,
    g?.Cotizacion?.IdCotizacion,
    g?.cotizacion?.IdCotizacion,
    g?.Cotizacion?.NumCot,
    g?.cotizacion?.NumCot,
  );

  const clienteNombre = pickFirstNonEmpty(
    findAnyLegacyValue(g, ["DesCli", "des_cli", "ClienteNombre", "cliente_nombre", "Nombre", "nombre", "RazonSocial", "razon_social"]),
    g?.cliente_nombre,
    g?.ClienteNombre,
    g?.DesCli,
    g?.des_cli,
    g?.cliente,
    g?.Cliente,
    clientPayload?.DesCli,
    clientPayload?.des_cli,
    clientPayload?.Nombre,
    clientPayload?.nombre,
    clientPayload?.RazonSocial,
    clientPayload?.razon_social,
  );

  const fiscalAddress = pickFirstNonEmpty(
    findAnyLegacyValue(g, ["DireccionFiscal", "direccion_fiscal", "DirFiscal", "dir_fiscal", "Direccion", "direccion", "DirCli", "dir_cli"]),
    g?.des_fiscal,
    g?.DirFiscal,
    g?.dir_fiscal,
    g?.DireccionFiscal,
    g?.direccion_fiscal,
    fiscalObject?.Direccion,
    fiscalObject?.direccion,
    fiscalObject?.DirFiscal,
    fiscalObject?.dir_fiscal,
    g?.Direccion,
    g?.direccion,
    nestedAddress,
    clientPayload?.Direccion,
    clientPayload?.direccion,
    clientPayload?.DireccionFiscal,
    clientPayload?.direccion_fiscal,
  );

  const partida = pickFirstNonEmpty(
    findAnyLegacyValue(g, ["PtoPartida", "pto_partida", "Partida", "partida", "PuntoPartida", "punto_partida"]),
    g?.pto_partida,
    g?.PtoPartida,
    g?.Locacion?.PuntoPartida,
    g?.locacion?.PuntoPartida,
    g?.partida,
    g?.Partida,
  );

  const llegada = pickFirstNonEmpty(
    findAnyLegacyValue(g, ["PtoLlegada", "pto_llegada", "Llegada", "llegada", "PuntoLlegada", "punto_llegada"]),
    g?.pto_llegada,
    g?.PtoLlegada,
    g?.Locacion?.PuntoLlegada,
    g?.locacion?.PuntoLlegada,
    g?.llegada,
    g?.Llegada,
  );

  const motivo = pickFirstNonEmpty(
    findAnyLegacyValue(g, ["CodMot", "cod_mot", "DesMot", "des_mot", "Motivo", "motivo", "Descripcion", "descripcion"]),
    g?.cod_mot,
    g?.CodMot,
    g?.motivo,
    g?.Motivo,
    motivoObj?.DesMot,
    motivoObj?.des_mot,
    motivoObj?.Descripcion,
    motivoObj?.descripcion,
  );

  const numOrden = pickFirstNonEmpty(
    findAnyLegacyValue(g, ["NumOrden", "num_orden", "Orden", "orden", "OrdenCompra", "orden_compra"]),
    g?.num_orden,
    g?.NumOrden,
    g?.orden,
    g?.Orden,
    g?.OrdenCompra,
    g?.orden_compra,
  );

  const localizacion = pickFirstNonEmpty(
    findAnyLegacyValue(g, ["IdLocCli", "id_loc_cli", "LocCli", "loc_cli", "Locacion", "locacion", "LocacionCliente", "locacion_cliente"]),
    g?.id_loc_cli,
    g?.IdLocCli,
    g?.loc_cli,
    g?.LocCli,
    g?.locacion,
    g?.Locacion,
    g?.LocacionCliente,
    g?.locacion_cliente,
  );

  return {
    referencia: normalizeReferenceDisplay(referenceValue),
    cotizacion: cotizacionValue === "" ? "" : String(cotizacionValue),
    clienteNombre: clienteNombre === "" ? "" : String(clienteNombre),
    fiscalAddress: fiscalAddress === "" ? "" : String(fiscalAddress),
    partida: partida === "" ? "" : String(partida),
    llegada: llegada === "" ? "" : String(llegada),
    motivo: motivo === "" ? "" : String(motivo),
    numOrden: numOrden === "" ? "" : String(numOrden),
    localizacion,
  };
}

// Selector genérico "Código / Descripción" (mismo patrón visual y de orden que MonthSelector),
// reutilizado en Oficina, Almacén y Estado para que todos los casilleros se vean/comporten igual.
type CodeDescOption = { code: string; label: string; value: string; extra?: string };

function CodeDescSelector({
  value,
  onChange,
  options,
  allLabel = "Todos",
  width = "w-[220px]",
  extraHeader,
}: {
  value: string;
  onChange: (next: string) => void;
  options: CodeDescOption[];
  allLabel?: string;
  width?: string;
  /** Encabezado de una 3ª columna opcional (ej. "CodAlm" en el combo de Almacén de frmGuiasRemision.vb) */
  extraHeader?: string;
}) {
  const gridCols = extraHeader ? "grid-cols-[46px_1fr_64px]" : "grid-cols-[58px_1fr]";
  const [open, setOpen] = useState(false);
  const [sortMode, setSortMode] = useState<"code" | "label">("code");
  const [sortDirection, setSortDirection] = useState<"asc" | "desc">("asc");
  const ref = useRef<HTMLDivElement | null>(null);
  const panelRef = useRef<HTMLDivElement | null>(null);
  const [panelPos, setPanelPos] = useState({ top: 0, left: 0 });

  // El panel se pinta con un portal a document.body y posición "fixed" calculada desde el
  // botón, para que NO quede recortado por el overflow/tamaño de la ventana flotante que lo
  // contiene (frmGuiaRemision) — se ve "afuera" de la ventana, igual que en el VB original.
  const updatePanelPos = useCallback(() => {
    const el = ref.current;
    if (!el) return;
    const rect = el.getBoundingClientRect();
    setPanelPos({ top: rect.bottom + 2, left: rect.left });
  }, []);

  useEffect(() => {
    if (!open) return;
    updatePanelPos();
    window.addEventListener("scroll", updatePanelPos, true);
    window.addEventListener("resize", updatePanelPos);
    return () => {
      window.removeEventListener("scroll", updatePanelPos, true);
      window.removeEventListener("resize", updatePanelPos);
    };
  }, [open, updatePanelPos]);

  useEffect(() => {
    const handleClickOutside = (event: MouseEvent) => {
      const target = event.target as Node;
      if (ref.current?.contains(target)) return;
      if (panelRef.current?.contains(target)) return;
      setOpen(false);
    };
    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, []);

  const selected = options.find((o) => o.value === value);
  const selectedLabel = value ? (selected?.label ?? value) : allLabel;

  const rows = useMemo(() => {
    return [...options].sort((a, b) => {
      const diff =
        sortMode === "code"
          ? a.code.localeCompare(b.code, "es")
          : a.label.localeCompare(b.label, "es");
      return sortDirection === "asc" ? diff : -diff;
    });
  }, [options, sortMode, sortDirection]);

  const handleSortToggle = (mode: "code" | "label") => {
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

      {open && createPortal(
        <div
          ref={panelRef}
          style={{ position: "fixed", top: panelPos.top, left: panelPos.left }}
          className={`z-[10050] ${width} overflow-hidden rounded-sm border border-slate-300 bg-white shadow-2xl`}
        >
          <div className="max-h-64 overflow-auto">
            <div className={`grid ${gridCols} items-center border-b border-slate-200 bg-slate-100 px-2 py-1 text-[10px] font-semibold uppercase tracking-wide text-slate-600`}>
              <button
                type="button"
                onClick={() => handleSortToggle("code")}
                className="flex items-center justify-center gap-1 text-center transition-colors duration-150 hover:bg-slate-200/80 rounded-sm px-1 focus:outline-none"
              >
                <span>Código</span>
                {sortMode === "code" && <span className="text-[9px]">{sortDirection === "asc" ? "▲" : "▼"}</span>}
              </button>
              <button
                type="button"
                onClick={() => handleSortToggle("label")}
                className="flex items-center justify-center gap-1 border-l border-slate-300 pl-2 text-center transition-colors duration-150 hover:bg-slate-200/80 rounded-sm px-1 focus:outline-none"
              >
                <span>Descripción</span>
                {sortMode === "label" && <span className="text-[9px]">{sortDirection === "asc" ? "▲" : "▼"}</span>}
              </button>
              {extraHeader && (
                <span className="border-l border-slate-300 pl-2 text-center">{extraHeader}</span>
              )}
            </div>
            <button
              type="button"
              className={`grid w-full ${gridCols} items-center border-b border-slate-200 px-2 py-1 text-[11px] text-slate-700 transition-colors duration-150 hover:bg-slate-200/80`}
              onClick={() => { onChange(""); setOpen(false); }}
            >
              <span className="text-center font-mono">--</span>
              <span className="border-l border-slate-300 pl-2 text-center">{allLabel}</span>
              {extraHeader && <span className="border-l border-slate-300 pl-2 text-center">--</span>}
            </button>
            {rows.map((row) => {
              const active = value === row.value;
              return (
                <button
                  key={row.value}
                  type="button"
                  className={`grid w-full ${gridCols} items-center border-b border-slate-200 px-2 py-1 text-[11px] transition-colors duration-150 ${active ? "bg-[#EAF2FF] text-[#1F3E68] font-semibold" : "text-slate-700 hover:bg-slate-200/80"}`}
                  onClick={() => { onChange(row.value); setOpen(false); }}
                >
                  <span className="text-center font-mono text-slate-600">{row.code}</span>
                  <span className="border-l border-slate-300 pl-2 text-center">{row.label}</span>
                  {extraHeader && (
                    <span className="border-l border-slate-300 pl-2 text-center font-mono text-slate-600">{row.extra ?? "-"}</span>
                  )}
                </button>
              );
            })}
          </div>
        </div>,
        document.body
      )}
    </div>
  );
}

// "Mes" reutiliza el mismo CodeDescSelector (con su portal a document.body) que Oficina/
// Almacén/Estado, para que se comporte y se vea exactamente igual en los 4 casilleros.
function MonthSelector({ value, onChange }: { value: string; onChange: (next: string) => void }) {
  const options = useMemo<CodeDescOption[]>(
    () => MESES.map((month, index) => ({
      code: String(index + 1).padStart(2, "0"),
      label: month,
      value: String(index + 1),
    })),
    []
  );
  return <CodeDescSelector value={value} onChange={onChange} options={options} allLabel="Todos" width="w-[220px]" />;
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

// Modal para editar la Observación
function ObservacionModal({
  value,
  onClose,
  onSave,
}: {
  value: string;
  onClose: () => void;
  onSave: (val: string) => void;
}) {
  const [text, setText] = useState(value);

  return (
    <div className="fixed inset-0 z-[10000] flex items-center justify-center bg-black/35 backdrop-blur-[0.5px]">
      <div className="w-[580px] bg-[#F1F3F8] border border-slate-500 shadow-2xl rounded-sm overflow-hidden animate-in fade-in zoom-in-95 duration-100">
        <div className="flex items-center justify-between px-3 py-1 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] text-white text-[12px]">
          <span className="font-semibold">Modificar Observación</span>
          <button onClick={onClose} className="hover:bg-white/20 rounded px-1"><X className="h-3.5 w-3.5" /></button>
        </div>

        <div className="p-3">
          <div className="text-center font-semibold text-slate-800 text-[11px] mb-2">
            [ Observación ]
          </div>
          <textarea
            className="w-full h-[220px] p-2 bg-white border border-slate-400 rounded-sm text-[12px] text-slate-800 outline-none focus:border-[#3E5B7A] focus:ring-1 focus:ring-[#3E5B7A]/30 resize-none font-sans"
            value={text}
            onChange={(e) => setText(e.target.value)}
            autoFocus
          />

          <div className="mt-3 flex justify-end gap-2">
            <button
              className={btnPrimary}
              onClick={() => {
                onSave(text);
                onClose();
              }}
            >
              <Save className="h-3.5 w-3.5" /> Guardar
            </button>
            <button className={btn} onClick={onClose}>
              <X className="h-3.5 w-3.5" /> Cancelar
            </button>
          </div>
        </div>
      </div>
    </div>
  );
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
  const [loadingMore, setLoadingMore] = useState(false);
  const [skip, setSkip] = useState(0);
  const pageSize = 50;
  const [total, setTotal] = useState<number | null>(null);
  const [desc, setDesc] = useState("");
  const [doc, setDoc] = useState("");
  const [selectedId, setSelectedId] = useState<string | null>(null);

  useEffect(() => {
    let mounted = true;
    setLoading(true);
    setSkip(0);
    fetchSigecoomClients(0, pageSize)
      .then((res) => {
        if (!mounted) return;
        setRows(res.items);
        setTotal(res.total ?? res.items.length);
      })
      .catch((e: any) => toast.error(e.message ?? "No se pudo cargar clientes"))
      .finally(() => {
        if (mounted) setLoading(false);
      });
    return () => {
      mounted = false;
    };
  }, []);

  const loadMore = async () => {
    if (loadingMore) return;
    setLoadingMore(true);
    try {
      const nextSkip = skip + pageSize;
      const res = await fetchSigecoomClients(nextSkip, pageSize);
      setRows((prev) => [...prev, ...res.items]);
      setSkip(nextSkip);
      if (res.total !== undefined) setTotal(res.total);
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo cargar más clientes");
    } finally {
      setLoadingMore(false);
    }
  };

  const qDesc = desc.trim().toLowerCase();
  const qDoc = doc.trim().toLowerCase();
  const filtered = rows.filter((r) => {
    const byDesc = !qDesc || r.name.toLowerCase().includes(qDesc);
    const byDoc = !qDoc || (r.ruc ?? "").toLowerCase().includes(qDoc);
    return byDesc && byDoc;
  });
  const selected = filtered.find((c) => c.id === selectedId);

  return (
    <div className="fixed inset-0 z-[10000] flex items-center justify-center bg-black/35">
      <div className="w-[760px] bg-[#F2F5FA] border border-slate-500 shadow-2xl rounded-sm overflow-hidden">
        <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] text-white text-[12px]">
          <span className="font-semibold">Buscar Cliente</span>
          <button onClick={onClose} className="hover:bg-white/20 rounded px-1"><X className="h-3.5 w-3.5" /></button>
        </div>

        <div className="p-2 border-b border-slate-300 bg-[#EEF2F7]">
          <div className="text-[11px] font-semibold text-slate-700 mb-1">Datos de Búsqueda</div>
          <div className="grid grid-cols-[1fr_180px_86px] gap-2">
            <div>
              <div className="text-[10.5px] text-slate-600 mb-0.5">Descripción</div>
              <input className={inp} value={desc} onChange={(e) => setDesc(e.target.value)} />
            </div>
            <div>
              <div className="text-[10.5px] text-slate-600 mb-0.5">N° de Documento</div>
              <input className={inp} value={doc} onChange={(e) => setDoc(e.target.value)} />
            </div>
            <div className="self-end">
              <button className={`${btn} w-full justify-center`}><Search className="h-3.5 w-3.5" />Buscar</button>
            </div>
          </div>
        </div>

        <div className="p-2">
          <div className="border border-slate-300 bg-white h-[280px] overflow-auto">
            <table className="w-full text-[11px]">
              <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] sticky top-0 z-10">
                <tr>
                  <th className="px-2 py-1 text-left border-r border-slate-300 font-semibold">Código</th>
                  <th className="px-2 py-1 text-left border-r border-slate-300 font-semibold">Descripción</th>
                  <th className="px-2 py-1 text-left font-semibold">R.U.C.</th>
                </tr>
              </thead>
              <tbody>
                {loading ? (
                  <tr><td colSpan={3} className="px-2 py-4 text-center text-slate-500">Cargando...</td></tr>
                ) : filtered.length === 0 ? (
                  <tr><td colSpan={3} className="px-2 py-4 text-center text-slate-500">Sin resultados</td></tr>
                ) : filtered.map((c, i) => {
                  const isSel = c.id === selectedId;
                  return (
                    <tr
                      key={c.id}
                      onClick={() => setSelectedId(c.id)}
                      onDoubleClick={() => onSelect(c)}
                      className={[
                        "cursor-pointer border-b border-slate-200",
                        i % 2 ? "bg-[#F6F9FC]" : "bg-white",
                        isSel ? "!bg-[#D6E4F4]" : "hover:bg-[#E8F0F8]/70",
                      ].join(" ")}
                    >
                      <td className="px-2 py-1 border-r border-slate-200 font-mono">{String(c.id).slice(0, 8).toUpperCase()}</td>
                      <td className="px-2 py-1 border-r border-slate-200">{c.name}</td>
                      <td className="px-2 py-1 font-mono">{c.ruc || "-"}</td>
                    </tr>
                  );
                })}
              </tbody>
            </table>
          </div>

          <div className="mt-2 flex items-center justify-between">
            <div className="text-[11px] text-slate-600">
              Total servidor: {total ?? rows.length} · Cargados: {rows.length} · Filtrados: {filtered.length}
            </div>
            <div className="flex gap-2 items-center">
              {total !== null && rows.length < (total ?? 0) && (
                <button className={btn} onClick={loadMore} disabled={loadingMore}>
                  {loadingMore ? "Cargando…" : "Cargar más"}
                </button>
              )}
              <button className={btn} onClick={onClose}><X className="h-3.5 w-3.5" />Cerrar</button>
              <button
                className={btnPrimary}
                onClick={() => selected && onSelect(selected)}
                disabled={!selected}
              >
                <Check className="h-3.5 w-3.5" />Seleccionar
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

// ─────────────────────────────────────────────────────────────────────────────
// TRANSPORTISTA MODAL  (frmGuiaRemision_Transportista)
// ─────────────────────────────────────────────────────────────────────────────
function TransportistaModal({
  idGuia,
  initial,
  onClose,
  onSaved,
}: {
  idGuia: number | string;
  initial?: GuiaRemisionTransportista;
  onClose: () => void;
  onSaved: (t: GuiaRemisionTransportista) => void;
}) {
  const [empresa, setEmpresa] = useState(initial?.empresa ?? "");
  const [direccion, setDireccion] = useState(initial?.direccion ?? "");
  const [ruc, setRuc] = useState(initial?.ruc ?? "");
  const [vehiculo, setVehiculo] = useState(initial?.vehiculo ?? "");
  const [chofer, setChofer] = useState(initial?.chofer ?? "");
  const [codDocChofer, setCodDocChofer] = useState(initial?.cod_doc_chofer ?? "1");
  const [numDocChofer, setNumDocChofer] = useState(initial?.num_doc_chofer ?? "");
  const [licencia, setLicencia] = useState(initial?.licencia ?? "");
  const [placa, setPlaca] = useState(initial?.placa ?? "");
  const [conIns, setConIns] = useState(initial?.con_ins ?? "");
  const [saving, setSaving] = useState(false);

  // Réplica de ValidaCampos() en frmGuiaRemision_Transportista.vb
  const validar = () => {
    const tieneEmpresa = empresa.trim() || ruc.trim();
    const tienePropio = placa.trim() || chofer.trim() || licencia.trim();
    if (tieneEmpresa) {
      if (empresa.trim().length < 5) { toast.error("Debe Ingresar una Razón Social válida."); return false; }
      if (ruc.trim().length < 11) { toast.error("Debe Ingresar un número de RUC válido."); return false; }
    }
    if (tienePropio) {
      if (!placa.trim()) { toast.error("Debe Ingresar la Placa del vehículo"); return false; }
      if (!numDocChofer.trim()) { toast.error("Debe Ingresar el Número de Documento del Transportista."); return false; }
      if (numDocChofer.trim().length < 8) { toast.error("Debe Ingresar un Número de Documento Válido"); return false; }
      if (!chofer.trim()) { toast.error("Debe Ingresar el nombre del chofer."); return false; }
      if (!licencia.trim()) { toast.error("Debe Ingresar el Número de Licencia de conducir."); return false; }
      if (licencia.trim().length < 9) { toast.error("Debe Ingresar un Número de Licencia Válido."); return false; }
    }
    if (!tieneEmpresa && !tienePropio) {
      toast.error("Ingrese los datos de la Empresa Transportista o del vehículo/chofer propio.");
      return false;
    }
    return true;
  };

  const handleSave = async () => {
    if (!validar()) return;
    if (!confirm("¿Está seguro de GUARDAR los datos?")) return;
    setSaving(true);
    try {
      const guiaId = Number(idGuia);
      if (!Number.isFinite(guiaId)) {
        toast.error("Guía inválida");
        return;
      }

      const result = await upsertTransportistaGuia(guiaId, {
        empresa, direccion, ruc, vehiculo, chofer,
        cod_doc_chofer: codDocChofer, num_doc_chofer: numDocChofer,
        licencia, placa, con_ins: conIns,
      });
      toast.success("Transportista guardado correctamente");
      onSaved(result);
      onClose();
    } catch (e: any) {
      toast.error(e.message ?? "Error al guardar transportista");
    } finally {
      setSaving(false);
    }
  };

  return (
    <div className="fixed inset-0 z-[9999] flex items-center justify-center bg-black/40">
      <div className="w-[520px] bg-[#F1F3F8] border border-slate-500 shadow-2xl rounded-sm">
        <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] text-white text-[12px]">
          <span className="font-semibold">Transportista</span>
          <button onClick={onClose} className="hover:bg-white/20 rounded px-1"><X className="h-3.5 w-3.5" /></button>
        </div>
        <div className="p-3 space-y-3 text-[12px]">
          <div className="font-bold text-slate-700 text-center">[ Datos del Transportista ]</div>

          <fieldset className="border border-slate-300 p-2 space-y-1.5">
            <legend className="px-1 text-[11px] font-semibold text-slate-700">Datos de la Empresa</legend>
            <InlineField label="Empresa" labelWidth="w-[80px]">
              <input className={inp} value={empresa} onChange={e => setEmpresa(e.target.value)} />
            </InlineField>
            <InlineField label="Dirección" labelWidth="w-[80px]">
              <input className={inp} value={direccion} onChange={e => setDireccion(e.target.value)} />
            </InlineField>
            <div className="flex gap-3">
              <InlineField label="RUC/DNI" labelWidth="w-[80px]" className="flex-1">
                <input className={inp} value={ruc} onChange={e => setRuc(e.target.value)} />
              </InlineField>
              <InlineField label="Tipo Vehículo" labelWidth="w-[90px]" className="flex-1">
                <input className={inp} value={vehiculo} onChange={e => setVehiculo(e.target.value)} />
              </InlineField>
            </div>
            <InlineField label="Const. Inc." labelWidth="w-[80px]">
              <input className={inp} value={conIns} onChange={e => setConIns(e.target.value)} />
            </InlineField>
          </fieldset>

          <fieldset className="border border-slate-300 p-2 space-y-1.5">
            <legend className="px-1 text-[11px] font-semibold text-slate-700">Datos del Chofer</legend>
            <InlineField label="Chofer" labelWidth="w-[80px]">
              <input className={inp} value={chofer} onChange={e => setChofer(e.target.value)} />
            </InlineField>
            <div className="flex gap-3">
              <InlineField label="Tipo Documento" labelWidth="w-[106px]" className="flex-1">
                <select className={inp} value={codDocChofer} onChange={e => setCodDocChofer(e.target.value)}>
                  <option value="1">DOC. NACIONAL DE IDENTIDAD</option>
                  <option value="4">CARNÉ DE EXTRANJERÍA</option>
                  <option value="7">PASAPORTE</option>
                </select>
              </InlineField>
              <InlineField label="N° Documento" labelWidth="w-[90px]" className="flex-1">
                <input className={inp} value={numDocChofer} onChange={e => setNumDocChofer(e.target.value)} />
              </InlineField>
            </div>
            <div className="flex gap-3">
              <InlineField label="Lic. Conducir" labelWidth="w-[90px]" className="flex-1">
                <input className={inp} value={licencia} onChange={e => setLicencia(e.target.value)} />
              </InlineField>
              <InlineField label="Placa" labelWidth="w-[50px]" className="flex-1">
                <input className={`${inp} font-mono uppercase`} value={placa} onChange={e => setPlaca(e.target.value.toUpperCase())} />
              </InlineField>
            </div>
          </fieldset>

          <div className="text-[10px] text-red-600">* Campos Obligatorios</div>

          <div className="flex justify-end gap-2">
            <button className={btn} onClick={onClose}><X className="h-3.5 w-3.5" />Cancelar</button>
            <button className={btnPrimary} onClick={handleSave} disabled={saving}>
              <Save className="h-3.5 w-3.5" />{saving ? "Guardando…" : "Guardar"}
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

// ─────────────────────────────────────────────────────────────────────────────
// FORMULARIO DE DETALLE (frmGuiaRemision_AgregarDetalle)
// ─────────────────────────────────────────────────────────────────────────────
function DetModal({
  idGuia,
  idLocacion,
  detalle,
  onClose,
  onSaved,
}: {
  idGuia: number | string;
  idLocacion: number;
  detalle?: GuiaRemisionDet;
  onClose: () => void;
  onSaved: () => void;
}) {
  const isNew = !detalle;
  const [codMer, setCodMer] = useState(detalle?.cod_mer ?? "");
  const [desMer, setDesMer] = useState(detalle?.des_mer ?? "");
  const [codUniMed, setCodUniMed] = useState(detalle?.cod_uni_med ?? "NIU");
  const [canMer, setCanMer] = useState(String(detalle?.can_mer ?? 1));
  const [preMer, setPreMer] = useState(String(detalle?.pre_mer ?? 0));
  const [dscMer, setDscMer] = useState(String(detalle?.dsc_mer ?? 0));
  const [regalo, setRegalo] = useState(detalle?.regalo ?? false);
  const [noCore, setNoCore] = useState(detalle?.no_core ?? false);
  const [saving, setSaving] = useState(false);

  const qty = parseFloat(canMer) || 0;
  const price = parseFloat(preMer) || 0;
  const disc = parseFloat(dscMer) || 0;
  const total = qty * price - qty * disc;

  const handleSave = async () => {
    if (!codMer.trim()) { toast.error("Ingrese el código de mercadería"); return; }
    if (qty <= 0) { toast.error("La cantidad debe ser mayor a 0"); return; }
    setSaving(true);
    try {
      const guiaId = Number(idGuia);
      if (!Number.isFinite(guiaId)) {
        toast.error("Guía inválida");
        return;
      }

      if (isNew) {
        await addGuiaRemisionDet(guiaId, {
          cod_mer: codMer.trim(), des_mer: desMer, cod_uni_med: codUniMed,
          can_mer: qty, pre_mer: price, dsc_mer: disc, regalo, no_core: noCore, item: 1,
        });
        toast.success("Ítem agregado");
      } else {
        const detId = Number(detalle!.id);
        if (!Number.isFinite(detId)) {
          toast.error("Ítem inválido");
          return;
        }

        await updateGuiaRemisionDet(guiaId, detId, {
          des_mer: desMer, cod_uni_med: codUniMed,
          can_mer: qty, pre_mer: price, dsc_mer: disc, regalo, no_core: noCore,
        });
        toast.success("Ítem actualizado");
      }
      onSaved();
      onClose();
    } catch (e: any) {
      toast.error(e.message ?? "Error al guardar ítem");
    } finally {
      setSaving(false);
    }
  };

  return (
    <div className="fixed inset-0 z-[9998] flex items-center justify-center bg-black/30">
      <div className="w-[420px] bg-[#F1F3F8] border border-slate-500 shadow-2xl rounded-sm">
        <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] text-white text-[12px]">
          <span className="font-semibold">{isNew ? "Agregar Ítem" : "Modificar Ítem"}</span>
          <button onClick={onClose} className="hover:bg-white/20 rounded px-1"><X className="h-3.5 w-3.5" /></button>
        </div>
        <div className="p-3 space-y-1.5 text-[12px]">
          <InlineField label="Código" labelWidth="w-[80px]">
            <div className="flex gap-1">
              <input className={inp} value={codMer} onChange={e => setCodMer(e.target.value.toUpperCase())} readOnly={!isNew} />
              {isNew && <button className={squareIconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>}
            </div>
          </InlineField>
          <InlineField label="Descripción" labelWidth="w-[80px]">
            <input className={inp} value={desMer} onChange={e => setDesMer(e.target.value)} />
          </InlineField>
          <div className="flex gap-3">
            <InlineField label="U/M" labelWidth="w-[40px]" className="w-32">
              <input className={inp} value={codUniMed} onChange={e => setCodUniMed(e.target.value.toUpperCase())} maxLength={3} />
            </InlineField>
            <InlineField label="Cantidad" labelWidth="w-[64px]" className="flex-1">
              <input className={`${inp} font-mono text-right`} value={canMer} onChange={e => setCanMer(e.target.value)} />
            </InlineField>
          </div>
          <div className="flex gap-3">
            <InlineField label="Precio" labelWidth="w-[50px]" className="flex-1">
              <input className={`${inp} font-mono text-right`} value={preMer} onChange={e => setPreMer(e.target.value)} />
            </InlineField>
            <InlineField label="Descuento" labelWidth="w-[72px]" className="flex-1">
              <input className={`${inp} font-mono text-right`} value={dscMer} onChange={e => setDscMer(e.target.value)} />
            </InlineField>
          </div>
          <InlineField label="Total" labelWidth="w-[50px]">
            <div className="h-7 px-2 text-[12px] bg-slate-100 border border-slate-300 rounded-sm text-right font-mono text-slate-800 flex items-center justify-end">
              {total.toFixed(2)}
            </div>
          </InlineField>
          <div className="flex gap-4 pt-1">
            <label className="flex items-center gap-1.5 text-[11px]">
              <input type="checkbox" checked={regalo} onChange={e => setRegalo(e.target.checked)} /> Regalo
            </label>
            <label className="flex items-center gap-1.5 text-[11px]">
              <input type="checkbox" checked={noCore} onChange={e => setNoCore(e.target.checked)} /> Sin Core
            </label>
          </div>
          <div className="flex justify-end gap-2 pt-1">
            <button className={btn} onClick={onClose}><X className="h-3.5 w-3.5" />Cancelar</button>
            <button className={btnPrimary} onClick={handleSave} disabled={saving}>
              <Save className="h-3.5 w-3.5" />{saving ? "Guardando…" : "Guardar"}
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

function SugerirFactorModal({ onClose }: { onClose: () => void }) {
  const [factor, setFactor] = useState("0.00");
  const [dscto, setDscto] = useState("0.00");

  return (
    <div className="fixed inset-0 z-[9999] flex items-center justify-center bg-black/30">
      <div className="w-[340px] bg-[#F1F3F8] border border-slate-500 shadow-2xl rounded-sm overflow-hidden">
        <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] border-b border-[#1F2E3F] text-[12px] text-white">
          <span className="font-medium">Sugerir Factor - Dscto</span>
          <button onClick={onClose} className="hover:bg-white/20 rounded px-1"><X className="h-3.5 w-3.5" /></button>
        </div>
        <div className="p-6 space-y-3 text-[12px]">
          <div className="grid grid-cols-[110px_1fr] items-center gap-2">
            <span className="text-right font-semibold">Factor Sugerido :</span>
            <input className={`${inp} font-mono text-right`} value={factor} onChange={(e) => setFactor(e.target.value)} />
            <span className="text-right font-semibold">Descuento :</span>
            <input className={`${inp} font-mono text-right`} value={dscto} onChange={(e) => setDscto(e.target.value)} />
          </div>
          <div className="h-[100px] border border-slate-200 bg-white" />
          <div className="flex justify-center gap-2">
            <button className={btnPrimary} onClick={() => { toast.success("Factor sugerido aplicado"); onClose(); }}><Check className="h-3.5 w-3.5" />Aceptar</button>
            <button className={btn} onClick={onClose}><X className="h-3.5 w-3.5" />Cancelar</button>
          </div>
        </div>
      </div>
    </div>
  );
}

type GuiaToolKind = "electronica" | "xcliente" | "factor" | "estados" | "precios" | "imprimirGuia" | "imprimirTicket" | "enviarCreditos" | "generarFactBoleta" | "trasladarGuia" | "enviarB2Mining" | "consumoOT" | "bajarNivel" | "enviarCorreo" | "obsSunat" | "actualizarCDR" | "actProceso";
type GuiaToolWindow = {
  id: string;
  kind: GuiaToolKind;
  title: string;
  x: number;
  y: number;
  w: number;
  h: number;
  z: number;
};

type GuiaFormWindow = {
  id: string;
  idGuia?: number | string;
  idLocacion?: number;
  detailOnly?: boolean;
  title: string;
  x: number;
  y: number;
  w: number;
  h: number;
  z: number;
};

function inferIdLocacionFromSession(): number | undefined {
  try {
    const raw = typeof window !== "undefined" ? window.localStorage.getItem("sigecoom_session") : null;
    if (!raw) return undefined;
    const sess = JSON.parse(raw);

    const explicit = Number(sess?.empresa_actual?.id_locacion ?? sess?.empresa_actual?.locacion ?? sess?.id_locacion ?? NaN);
    if (Number.isFinite(explicit) && explicit > 0) return explicit;

    const codigo = String(sess?.empresa_actual?.codigo ?? "").trim();
    const map: Record<string, number> = {
      "08": 87, "8": 87,
      "05": 72, "5": 72,
      "30": 30, "31": 31,
      "72": 72, "73": 73, "75": 75,
      "80": 80, "81": 81, "83": 83,
      "87": 87,
    };
    return codigo ? map[codigo] : undefined;
  } catch {
    return undefined;
  }
}

const TOOL_WINDOW_META: Record<GuiaToolKind, { title: string; w: number; h: number }> = {
  electronica: { title: "Generar Guia Electronica", w: 430, h: 315 },
  xcliente: { title: "Guia de Remision x Cliente", w: 760, h: 470 },
  factor: { title: "Sugerir Factor - Dscto", w: 340, h: 290 },
  estados: { title: "Estados de Guia", w: 780, h: 390 },
  precios: { title: "Precios Sugeridos", w: 860, h: 410 },
  imprimirGuia: { title: "Imprimir Guía", w: 320, h: 220 },
  imprimirTicket: { title: "Imprimir Ticket", w: 320, h: 220 },
  enviarCreditos: { title: "Enviar a Créditos", w: 360, h: 260 },
  generarFactBoleta: { title: "Generar Factura / Boleta", w: 360, h: 260 },
  trasladarGuia: { title: "Trasladar Guía", w: 410, h: 290 },
  enviarB2Mining: { title: "Enviar a B2Mining", w: 360, h: 260 },
  consumoOT: { title: "Agregar Consumo OT", w: 640, h: 460 },
  bajarNivel: { title: "Bajar de Nivel", w: 320, h: 220 },
  enviarCorreo: { title: "Enviar por Correo", w: 420, h: 320 },
  obsSunat: { title: "Observaciones SUNAT", w: 420, h: 300 },
  actualizarCDR: { title: "Actualizar CDR", w: 380, h: 220 },
  actProceso: { title: "Actualizar Guía Electrónica en Proceso", w: 420, h: 260 },
};

const FLOAT_DESKTOP_STATUS_BAR_H = 56;

function ToolGenerarElectronicaBody({ onClose }: { onClose: () => void }) {
  const [darBaja, setDarBaja] = useState(false);
  const [impresion, setImpresion] = useState<"detalle" | "resumen" | "obs">("detalle");
  const [noMostrarCodigo, setNoMostrarCodigo] = useState(false);
  const [mostrarPrecio, setMostrarPrecio] = useState(false);

  return (
    <div className="p-3 space-y-3 text-[12px] text-slate-800 bg-[#F8FBFF]">
      <fieldset className="border border-slate-300 p-2 bg-[#F4F8FD]">
        <label className="inline-flex items-center gap-2 text-slate-800 font-medium">
          <input type="checkbox" checked={darBaja} onChange={(e) => setDarBaja(e.target.checked)} />
          ¿Dara de baja una Guia preexistente?
        </label>
      </fieldset>

      <fieldset className="border border-slate-300 p-2 bg-[#F4F8FD]">
        <legend className="px-1 text-[11px] font-semibold text-slate-700">Impresion</legend>
        <div className="grid grid-cols-2 gap-2">
          <div className="space-y-1">
            <label className="inline-flex items-center gap-1.5 text-slate-800"><input type="radio" checked={impresion === "detalle"} onChange={() => setImpresion("detalle")} />Generar Detalle</label>
            <label className="inline-flex items-center gap-1.5 text-slate-800"><input type="radio" checked={impresion === "resumen"} onChange={() => setImpresion("resumen")} />Generar Resumen</label>
            <label className="inline-flex items-center gap-1.5 text-slate-800"><input type="radio" checked={impresion === "obs"} onChange={() => setImpresion("obs")} />Generar Observacion</label>
          </div>
          <div className="space-y-1">
            <label className="inline-flex items-center gap-1.5 text-slate-800"><input type="checkbox" checked={noMostrarCodigo} onChange={(e) => setNoMostrarCodigo(e.target.checked)} />No Mostrar Codigo</label>
            <label className="inline-flex items-center gap-1.5 text-slate-800"><input type="checkbox" checked={mostrarPrecio} onChange={(e) => setMostrarPrecio(e.target.checked)} />Mostrar Precio</label>
          </div>
        </div>
      </fieldset>

      <div className="flex items-center justify-between gap-2">
        <button className={btn} onClick={() => toast.info("Pre impresion lista (simulada)")}>
          <Search className="h-3.5 w-3.5" />Pre Impresion
        </button>
        <div className="flex gap-2">
          <button className={btnPrimary} onClick={() => { toast.success("Guia electronica preparada"); onClose(); }}>
            <Check className="h-3.5 w-3.5" />Aceptar
          </button>
          <button className={btn} onClick={onClose}><X className="h-3.5 w-3.5" />Cancelar</button>
        </div>
      </div>
    </div>
  );
}

function ToolGuiaClienteBody({ selected }: { selected: GuiaRemisionRow | null }) {
  const [serie, setSerie] = useState("T001");
  const [numero, setNumero] = useState(selected ? String(selected.num_doc) : "");

  return (
    <div className="h-full p-3 text-[12px] text-slate-800 space-y-2 bg-[#F8FBFF]">
      <div className="grid grid-cols-[60px_1fr_85px_90px_70px_90px_86px] gap-1 items-center">
        <span className="text-right font-semibold">Cliente</span>
        <input className={inp} readOnly value={selected ? `Cliente #${selected.id_cliente}` : ""} />
        <span className="text-right font-semibold">Serie Doc.</span>
        <input className={`${inp} font-mono`} value={serie} onChange={(e) => setSerie(e.target.value.toUpperCase())} />
        <span className="text-right font-semibold">N° Doc</span>
        <input className={`${inp} font-mono`} value={numero} onChange={(e) => setNumero(e.target.value)} />
        <button className={`${btnPrimary} justify-center`}><Search className="h-3.5 w-3.5" />Buscar</button>
      </div>

      <div className="border border-slate-300 bg-white h-[330px] overflow-auto">
        <table className="w-full text-[11px]">
          <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] text-slate-800 sticky top-0">
            <tr>
              {"Serie|N° Doc|Fecha|Moneda|TotBruto|TotDscto|TotVenta|TotIgv|TotNeto".split("|").map((h) => (
                <th key={h} className="px-2 py-1 border-r border-slate-300 text-center font-semibold">{h}</th>
              ))}
            </tr>
          </thead>
          <tbody>
            <tr>
              <td colSpan={9} className="text-center text-slate-400 py-6">Sin datos</td>
            </tr>
          </tbody>
        </table>
      </div>
      <div className="text-center text-[11px] font-semibold text-slate-700">Registros : 0</div>
    </div>
  );
}

function ToolSugerirFactorBody({ onClose }: { onClose: () => void }) {
  const [factor, setFactor] = useState("0.00");
  const [dscto, setDscto] = useState("0.00");

  return (
    <div className="h-full p-6 space-y-3 text-[12px] text-slate-800 bg-[#F8FBFF]">
      <div className="grid grid-cols-[110px_1fr] items-center gap-2">
        <span className="text-right font-semibold">Factor Sugerido :</span>
        <input className={`${inp} font-mono text-right`} value={factor} onChange={(e) => setFactor(e.target.value)} />
        <span className="text-right font-semibold">Descuento :</span>
        <input className={`${inp} font-mono text-right`} value={dscto} onChange={(e) => setDscto(e.target.value)} />
      </div>
      <div className="h-[100px] border border-slate-300 bg-white" />
      <div className="flex justify-center gap-2">
        <button className={btnPrimary} onClick={() => { toast.success("Factor sugerido aplicado"); onClose(); }}><Check className="h-3.5 w-3.5" />Aceptar</button>
        <button className={btn} onClick={onClose}><X className="h-3.5 w-3.5" />Cancelar</button>
      </div>
    </div>
  );
}

function ToolEstadosBody({ selected }: { selected: GuiaRemisionRow | null }) {
  const has = !!selected;
  return (
    <div className="h-full p-3 bg-[#F8FBFF]">
      <div className="border border-slate-300 bg-white h-[320px] overflow-auto">
        <table className="w-full text-[11px]">
          <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] text-slate-800 sticky top-0">
            <tr>
              {"Estado|Fecha|Hora|Observacion|Usuario".split("|").map((h) => (
                <th key={h} className="px-2 py-1 border-r border-slate-300 text-center font-semibold">{h}</th>
              ))}
            </tr>
          </thead>
          <tbody>
            {has ? (
              <tr className="bg-[#F6F9FC]">
                <td className="px-2 py-1 border-r border-b border-slate-200 font-semibold">{selected!.estado}</td>
                <td className="px-2 py-1 border-r border-b border-slate-200">{selected!.fec_doc ? new Date(selected!.fec_doc).toLocaleDateString("es-PE") : ""}</td>
                <td className="px-2 py-1 border-r border-b border-slate-200">12:18:50</td>
                <td className="px-2 py-1 border-r border-b border-slate-200">-</td>
                <td className="px-2 py-1 border-b border-slate-200">system</td>
              </tr>
            ) : (
              <tr><td colSpan={5} className="text-center text-slate-500 py-6">Seleccione una guia</td></tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
}

// Réplica de frmGuiaRemision_Electronica_ObsSunat.vb (solo lectura: Ticket, Estado, Observación, Notas, UrlLink)
function ToolObsSunatBody({ selected }: { selected: GuiaRemisionRow | null }) {
  const [digital, setDigital] = useState<GuiaRemisionDigital | null>(null);
  const [loading, setLoading] = useState(false);
  const [errorMsg, setErrorMsg] = useState<string | null>(null);

  useEffect(() => {
    if (!selected) { setDigital(null); return; }
    setLoading(true);
    setErrorMsg(null);
    fetchGuiaRemisionDigital(selected.id)
      .then(setDigital)
      .catch((e: any) => setErrorMsg(e.message ?? "No se pudo consultar la información SUNAT"))
      .finally(() => setLoading(false));
  }, [selected?.id]);

  if (!selected) {
    return <div className="h-full p-6 text-center text-slate-500 text-[12px] bg-[#F8FBFF]">Seleccione una guía</div>;
  }
  if (loading) {
    return <div className="h-full p-6 text-center text-slate-500 text-[12px] bg-[#F8FBFF]">Cargando…</div>;
  }

  // Ticket/Estado/Observación/Notas/UrlLink vienen de GuiaRemisionDigitalService.Obtener(IdGuia)
  // (fetchGuiaRemisionDigital); si el endpoint aún no está desplegado, se cae a estado_sunat/
  // observacion ya disponibles en el listado.
  const rows: Array<[string, string]> = [
    ["Ticket", digital?.num_ticket ?? "-"],
    ["Estado", digital?.estado ?? selected.estado_sunat ?? "-"],
    ["Observación", digital?.observacion ?? selected.observacion ?? "-"],
    ["Notas", digital?.notas ?? "-"],
    ["Url Link", digital?.url_link ?? "-"],
  ];
  return (
    <div className="h-full p-3 text-[12px] text-slate-800 bg-[#F8FBFF] space-y-2">
      {errorMsg && <div className="text-[11px] text-amber-700">{errorMsg} — mostrando lo disponible del listado.</div>}
      {rows.map(([label, value]) => (
        <InlineField key={label} label={label} labelWidth="w-[90px]">
          <input className={inp} readOnly value={value} />
        </InlineField>
      ))}
    </div>
  );
}

// Réplica de frmGuiaRemision_AgregarConsumoJob.vb
// Columnas del grid: JobConsumoItem (sigecoom-api.ts), tomadas de OrigenDatos/ConsumoJob.xml
function ToolAgregarConsumoJobBody({
  selected,
  locationById,
  onClose,
  onSaved,
}: {
  selected: GuiaRemisionRow | null;
  locationById: Record<number, Location>;
  onClose: () => void;
  onSaved: () => void;
}) {
  const loc = selected ? locationById[Number(selected.id_locacion)] : undefined;
  const [locacion] = useState(loc ? `${loc.code} - ${loc.warehouse}` : "");
  const [almacen] = useState(loc?.warehouse ?? "");
  const [fecDoc, setFecDoc] = useState(() => new Date().toISOString().slice(0, 10));
  const [numDoc, setNumDoc] = useState(selected ? String(selected.num_doc) : "");
  const [numJob, setNumJob] = useState("");
  const [rows, setRows] = useState<JobConsumoItem[]>([]);
  const [loading, setLoading] = useState(false);
  const [saving, setSaving] = useState(false);

  // Réplica de oJobService.Buscar + oTransferenciaService.MostrarAtencionJob
  const buscarJob = async () => {
    const job = numJob.trim();
    if (!job) {
      toast.error("Debe Ingresar el Nº de la OT, Verifique");
      setRows([]);
      return;
    }
    setLoading(true);
    try {
      const data = await fetchAtencionJob(job);
      setRows(data);
    } catch (e: any) {
      toast.error(e.message ?? "Número de OT no existente, Verifique");
      setRows([]);
    } finally {
      setLoading(false);
    }
  };

  const validarData = () => {
    if (!numJob.trim()) { toast.info("Debe ingresar el número de la OT.."); return false; }
    if (!numDoc.trim()) { toast.info("Debe ingresar el número del Documento.."); return false; }
    if (!fecDoc) { toast.info("Debe ingresar la Fecha.."); return false; }
    return true;
  };

  const handleAceptar = async () => {
    if (!validarData()) return;
    if (!selected) return;
    if (!confirm("¿Está seguro de GENERAR las Guías?")) return;
    setSaving(true);
    try {
      // Réplica de oGuiaRemisionService.IngresarConsumoJob(CodAlmacen, NumJob, NumDoc, FecDoc, usuario)
      await ingresarConsumoJob(selected.id, { num_job: numJob.trim(), num_doc: numDoc.trim(), fec_doc: fecDoc });
      toast.success("Se registró el consumo de la OT");
      onSaved();
    } catch (e: any) {
      toast.error(e.message ?? "Error en el proceso, comuníquese con el departamento de sistemas...!");
    } finally {
      setSaving(false);
    }
  };

  return (
    <div className="h-full flex flex-col text-[12px] text-slate-800 bg-[#F8FBFF]">
      <div className="p-3 space-y-1.5">
        <InlineField label="Locación" labelWidth="w-[80px]"><input className={inp} readOnly value={locacion} /></InlineField>
        <InlineField label="Almacén" labelWidth="w-[80px]"><input className={inp} readOnly value={almacen} /></InlineField>
        <div className="grid grid-cols-[80px_1fr_80px_1fr] gap-1 items-center">
          <span className="text-right font-semibold">Fec. Doc :</span>
          <input type="date" className={inp} value={fecDoc} onChange={(e) => setFecDoc(e.target.value)} />
          <span className="text-right font-semibold">N° Doc :</span>
          <input className={`${inp} font-mono`} value={numDoc} onChange={(e) => setNumDoc(e.target.value)} />
        </div>
        <div className="grid grid-cols-[80px_1fr_auto] gap-1 items-center">
          <span className="text-right font-semibold">N° OT :</span>
          <input
            className={`${inp} font-mono`}
            value={numJob}
            onChange={(e) => setNumJob(e.target.value)}
            onKeyDown={(e) => { if (e.key === "Enter") buscarJob(); }}
          />
          <button className={btn} onClick={buscarJob} title="Buscar OT (F12)"><Search className="h-3.5 w-3.5" />Buscar</button>
        </div>
      </div>

      <div className="flex-1 min-h-0 px-3">
        <div className="border border-slate-300 bg-white h-full overflow-auto">
          <table className="w-full text-[11px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] text-slate-800 sticky top-0">
              <tr>
                {"Item|Código|Descripción|Cant.|Marca|Modelo|Importado".split("|").map((h) => (
                  <th key={h} className="px-2 py-1 border-r border-slate-300 text-center font-semibold">{h}</th>
                ))}
              </tr>
            </thead>
            <tbody>
              {rows.length === 0 ? (
                <tr><td colSpan={7} className="text-center text-slate-400 py-6">{loading ? "Cargando…" : "Ingrese un N° de OT y presione Enter"}</td></tr>
              ) : rows.map((r, i) => (
                <tr key={i} className={i % 2 ? "bg-[#F6F9FC]" : "bg-white"}>
                  <td className="px-2 py-1 text-center border-r border-slate-200">{r.item}</td>
                  <td className="px-2 py-1 border-r border-slate-200 font-mono">{r.cod_mer}</td>
                  <td className="px-2 py-1 border-r border-slate-200">{r.des_mer}</td>
                  <td className="px-2 py-1 text-right border-r border-slate-200 font-mono">{r.can_mer}</td>
                  <td className="px-2 py-1 border-r border-slate-200">{r.cod_mar}</td>
                  <td className="px-2 py-1 border-r border-slate-200">{r.modelo}</td>
                  <td className="px-2 py-1 text-center">{r.importado ? "Sí" : "No"}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>

      <div className="p-3 flex items-center justify-between gap-2">
        <button className={btn} disabled={rows.length < 1} onClick={() => toast.info("Reporte pendiente de conectar (MostrarAtencionJob)")}>
          <Printer className="h-3.5 w-3.5" />Imprimir
        </button>
        <div className="flex gap-2">
          <button className={btnPrimary} disabled={saving} onClick={handleAceptar}><Check className="h-3.5 w-3.5" />Aceptar</button>
          <button className={btn} onClick={onClose}><X className="h-3.5 w-3.5" />Cancelar</button>
        </div>
      </div>
    </div>
  );
}

// Réplica de frmGuiaRemision_Transferir.vb
function ToolTransferirGuiaBody({
  selected,
  locations,
  onClose,
  onSaved,
}: {
  selected: GuiaRemisionRow | null;
  locations: Location[];
  onClose: () => void;
  onSaved: () => void;
}) {
  const [idLocacion, setIdLocacion] = useState<string>("");
  const [saving, setSaving] = useState(false);

  if (!selected) {
    return <div className="h-full p-6 text-center text-slate-500 text-[12px] bg-[#F8FBFF]">Seleccione una guía</div>;
  }

  const handleGuardar = async () => {
    // Réplica de ValidaCampos(): exige almacén destino
    if (!idLocacion) {
      toast.error("Debe ingresar el almacén a transferir");
      return;
    }
    if (!confirm(`¿Está seguro de TRANSFERIR la G/R Nº: ${selected.num_doc} ?`)) return;
    setSaving(true);
    try {
      await transferirGuiaRemision(selected.id, Number(idLocacion));
      toast.success(`Se transfirió la Guía de Remisión Nº: ${selected.num_doc}`);
      onSaved();
    } catch (e: any) {
      toast.error(e.message ?? "Error en el proceso, comuníquese con el departamento de sistemas...!");
    } finally {
      setSaving(false);
    }
  };

  return (
    <div className="h-full p-4 space-y-3 text-[12px] text-slate-800 bg-[#F8FBFF]">
      <InlineField label="Guía" labelWidth="w-[90px]"><input className={inp} readOnly value={String(selected.num_doc)} /></InlineField>
      <InlineField label="Almacén" labelWidth="w-[90px]">
        <select className={inp} value={idLocacion} onChange={(e) => setIdLocacion(e.target.value)}>
          <option value="">Seleccione…</option>
          {locations.map((loc) => (
            <option key={String(loc.id)} value={String(loc.id)}>{loc.code} - {loc.warehouse}</option>
          ))}
        </select>
      </InlineField>
      <div className="flex justify-end gap-2 pt-2">
        <button className={btn} onClick={onClose}><X className="h-3.5 w-3.5" />Cancelar</button>
        <button className={btnPrimary} disabled={saving} onClick={handleGuardar}><Save className="h-3.5 w-3.5" />Guardar</button>
      </div>
    </div>
  );
}

function ToolPreciosSugeridosBody() {
  return (
    <div className="h-full p-3 bg-[#F8FBFF]">
      <div className="border border-slate-300 bg-white h-[340px] overflow-auto">
        <table className="w-full text-[11px]">
          <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] text-slate-800 sticky top-0">
            <tr>
              {"Codigo|Descripcion|Precio|Dscto|PrecioSug|DsctoSug|Fec. Apro|Usuario".split("|").map((h) => (
                <th key={h} className="px-2 py-1 border-r border-slate-300 text-center font-semibold">{h}</th>
              ))}
            </tr>
          </thead>
          <tbody>
            <tr>
              <td className="px-2 py-6 text-center text-slate-500" colSpan={8}>Sin datos</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  );
}

function ToolPlaceholderBody({
  title,
  description,
  actionLabel,
  onClose,
}: {
  title: string;
  description: string;
  actionLabel: string;
  onClose: () => void;
}) {
  return (
    <div className="h-full p-4 space-y-4 bg-[#F8FBFF] text-[12px] text-slate-800">
      <div className="text-sm font-semibold text-slate-900">{title}</div>
      <div className="border border-slate-300 bg-white p-3 rounded-sm text-slate-600">{description}</div>
      <div className="flex gap-2 justify-end">
        <button className={btnPrimary} onClick={() => { toast.success(`${actionLabel} ejecutado (simulado)`); onClose(); }}>
          <Check className="h-3.5 w-3.5" /> {actionLabel}
        </button>
        <button className={btn} onClick={onClose}><X className="h-3.5 w-3.5" />Cancelar</button>
      </div>
    </div>
  );
}

function DraggableToolWindow({
  win,
  onFocus,
  onMove,
  onClose,
  children,
}: {
  win: GuiaToolWindow;
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
      className="fixed bg-[#F1F3F8] border border-slate-500 shadow-2xl rounded-sm overflow-hidden pointer-events-auto"
      style={{ left: win.x, top: win.y, width: win.w, height: win.h, zIndex: win.z }}
      onMouseDown={onFocus}
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
        <button onClick={onClose} className="hover:bg-white/20 rounded px-1" title="Cerrar"><X className="h-3.5 w-3.5" /></button>
      </div>
      <div className="h-[calc(100%-31px)] overflow-auto bg-[#F8FBFF] text-slate-800">{children}</div>
    </div>,
    document.body,
  );
}

// ─────────────────────────────────────────────────────────────────────────────
// FORMULARIO CABECERA  (frmGuiaRemision)
// ─────────────────────────────────────────────────────────────────────────────
type FormMode = "view" | "edit" | "new";

export function GuiaRemisionForm({
  idGuia,
  idLocacion = 1,
  onClose,
  onSaved,
  detailOnly = false,
}: {
  idGuia?: number | string;
  idLocacion?: number;
  onClose: () => void;
  onSaved?: () => void;
  detailOnly?: boolean;
}) {
  const isNew = !idGuia;
  const isDetailOnly = detailOnly && !isNew;
  const [mode, setMode] = useState<FormMode>(isNew ? "new" : "view");
  const [guia, setGuia] = useState<GuiaRemisionFull | null>(null);
  const [loading, setLoading] = useState(!isNew);
  const [saving, setSaving] = useState(false);
  const [showTransportista, setShowTransportista] = useState(false);
  const [showClienteLookup, setShowClienteLookup] = useState(false);
  const [showSugerirFactor, setShowSugerirFactor] = useState(false);
  const [showObsModal, setShowObsModal] = useState(false);
  const [detModal, setDetModal] = useState<{ open: boolean; detalle?: GuiaRemisionDet }>({ open: false });

  const pickFirstNonEmpty = (...values: Array<string | number | null | undefined>) => {
    for (const value of values) {
      if (value === null || value === undefined) continue;
      const text = String(value).trim();
      if (text !== "") return value;
    }
    return "";
  };

  // Form fields
  const [numDoc, setNumDoc] = useState(isNew ? "" : "");
  const [fecDoc, setFecDoc] = useState(new Date().toISOString().slice(0, 10));
  const [codMon, setCodMon] = useState("NS");
  const [igv, setIgv] = useState("18.00");
  const [tipCambio, setTipCambio] = useState("3.411");
  const [idCliente, setIdCliente] = useState<number | "">("");
  const [desCliente, setDesCliente] = useState("");
  const [idLocCli, setIdLocCli] = useState<number | "">("");
  const [desLocCli, setDesLocCli] = useState("");
  const [idFiscal, setIdFiscal] = useState<number | "">("");
  const [desFiscal, setDesFiscal] = useState("");
  const [codMot, setCodMot] = useState("1");
  const [numJob, setNumJob] = useState("");
  const [idCotizacion, setIdCotizacion] = useState<number | "">("");
  const [llegada, setLlegada] = useState("");
  const [partida, setPartida] = useState("CAL. ANTONIO ULLOA NRO. 2182 URB. EL FLORES");
  const [numOrden, setNumOrden] = useState("");
  const [pesoTotal, setPesoTotal] = useState("0.000");
  const [codUniMedPeso, setCodUniMedPeso] = useState("KGM");
  const [numBultos, setNumBultos] = useState("1");
  const [modoTraslado, setModoTraslado] = useState("02");
  const [fecTraslado, setFecTraslado] = useState(new Date().toISOString().slice(0, 10));
  const [totFlete, setTotFlete] = useState("0.00");
  const [totEmbarque, setTotEmbarque] = useState("0.00");
  const [observacion, setObservacion] = useState("");

  const editable = mode === "new" || mode === "edit";

  const hydrateLookupTexts = useCallback(async (g: GuiaRemisionFull) => {
    const legacy = resolveLegacyGuideDisplayFields(g as any);
    const locationLookup = await fetchSigecoomLocations().catch(() => [] as Location[]);
    const rawClientId = pickFirstNonEmpty(
      g?.id_cliente,
      (g as any)?.IdCliente,
      (g as any)?.Cliente?.IdCliente,
      (g as any)?.cliente?.IdCliente,
      legacy.localizacion,
      "",
    );
    const rawLocCliId = pickFirstNonEmpty(
      g?.id_loc_cli,
      (g as any)?.IdLocCli,
      (g as any)?.Locacion?.IdLocCli,
      (g as any)?.locacion?.IdLocCli,
      (g as any)?.Cliente?.IdLocCli,
      (g as any)?.cliente?.IdLocCli,
      legacy.localizacion,
      "",
    );
    const rawFiscalId = pickFirstNonEmpty(
      g?.id_fiscal,
      (g as any)?.IdFiscal,
      (g as any)?.DireccionFiscal?.IdFiscal,
      (g as any)?.direccion_fiscal?.IdFiscal,
      (g as any)?.Cliente?.IdFiscal,
      (g as any)?.cliente?.IdFiscal,
      "",
    );
    const location = locationLookup.find((loc) => String(loc.id) === String(rawLocCliId ?? g.id_loc_cli ?? legacy.localizacion ?? ""));
    const locText = location
      ? [location.warehouse, location.aisle, location.shelf, location.row, location.level]
        .filter(Boolean)
        .join(" / ") || location.description || location.code
      : (legacy.localizacion ? String(legacy.localizacion) : "");

    const legacyClientName = pickFirstNonEmpty(
      legacy.clienteNombre,
      (g as any)?.Cliente?.DesCli,
      (g as any)?.cliente?.DesCli,
      (g as any)?.DesCli,
      (g as any)?.des_cli,
      "",
    );
    const legacyFiscal = pickFirstNonEmpty(
      legacy.fiscalAddress,
      (g as any)?.DireccionFiscal?.Direccion,
      (g as any)?.direccion_fiscal?.Direccion,
      (g as any)?.DirFiscal,
      (g as any)?.dir_fiscal,
      (g as any)?.Cliente?.Direccion,
      (g as any)?.cliente?.Direccion,
      "",
    );

    if (rawClientId !== "") {
      setIdCliente(typeof rawClientId === "number" ? rawClientId : Number(rawClientId));
    } else {
      setIdCliente("");
    }

    if (legacyClientName) {
      setDesCliente(String(legacyClientName));
    } else {
      try {
        const client = await getSigecoomClient(String(rawClientId || g.id_cliente || ""));
        setDesCliente(client.name || (rawClientId ? `Cliente #${rawClientId}` : `Cliente #${g.id_cliente ?? ""}`));
      } catch {
        setDesCliente(rawClientId ? `Cliente #${rawClientId}` : `Cliente #${g.id_cliente ?? ""}`);
      }
    }

    const fiscalText = typeof legacyFiscal === "string" || typeof legacyFiscal === "number" ? String(legacyFiscal) : "";

    if (fiscalText) {
      setDesFiscal(fiscalText);
    } else {
      try {
        const client = await getSigecoomClient(String(g.id_cliente));
        setDesFiscal(client.address || "");
      } catch {
        setDesFiscal("");
      }
    }

    const locCliValue = rawLocCliId !== "" ? rawLocCliId : (g.id_loc_cli ?? legacy.localizacion ?? "");
    setDesLocCli(locText || "");
    setIdLocCli(typeof locCliValue === "number" ? locCliValue : (locCliValue && String(locCliValue).trim() !== "" ? Number(locCliValue) : ""));
    setIdFiscal(rawFiscalId !== "" ? (typeof rawFiscalId === "number" ? rawFiscalId : Number(rawFiscalId)) : "");
  }, []);

  useEffect(() => {
    if (!idGuia) return;
    setLoading(true);
    fetchGuiaRemision(idGuia).then(async (g) => {
      setGuia(g);
      const derivedFields = resolveLegacyGuideDisplayFields(g);

      const legacyClientId = pickFirstNonEmpty(
        g?.id_cliente,
        (g as any)?.IdCliente,
        (g as any)?.Cliente?.IdCliente,
        (g as any)?.cliente?.IdCliente,
        "",
      );
      const legacyLocCliId = pickFirstNonEmpty(
        g?.id_loc_cli,
        (g as any)?.IdLocCli,
        (g as any)?.Locacion?.IdLocCli,
        (g as any)?.locacion?.IdLocCli,
        (g as any)?.Cliente?.IdLocCli,
        (g as any)?.cliente?.IdLocCli,
        "",
      );
      const legacyFiscalId = pickFirstNonEmpty(
        g?.id_fiscal,
        (g as any)?.IdFiscal,
        (g as any)?.DireccionFiscal?.IdFiscal,
        (g as any)?.direccion_fiscal?.IdFiscal,
        (g as any)?.Cliente?.IdFiscal,
        (g as any)?.cliente?.IdFiscal,
        "",
      );

      setNumDoc(String(g.num_doc ?? (g as any).NumDoc ?? ""));
      setFecDoc((g.fec_doc ?? (g as any).FecDoc ?? new Date().toISOString().slice(0, 10)).slice(0, 10));
      setCodMon(g.cod_mon ?? (g as any).CodMon ?? "NS");
      setIgv(String(g.igv ?? (g as any).IGV ?? "18.00"));
      setTipCambio(String(g.tip_cambio ?? (g as any).TipCambio ?? 1));
      setIdCliente(legacyClientId !== "" ? Number(legacyClientId) : "");
      setIdLocCli(legacyLocCliId !== "" ? Number(legacyLocCliId) : "");
      setIdFiscal(legacyFiscalId !== "" ? Number(legacyFiscalId) : "");
      setCodMot(
        pickFirstNonEmpty(
          g.cod_mot,
          (g as any).CodMot,
          (g as any)?.Motivos?.CodMot,
          (g as any)?.motivos?.CodMot,
          (g as any)?.Motivo?.CodMot,
          derivedFields.motivo,
          "1",
        ) as string
      );
      setNumJob(derivedFields.referencia || "");
      setIdCotizacion(derivedFields.cotizacion === "" ? "" : Number(derivedFields.cotizacion));
      setLlegada(derivedFields.llegada || g.pto_llegada || (g as any).PtoLlegada || "");
      setPartida(derivedFields.partida || g.pto_partida || (g as any).PtoPartida || "");
      setNumOrden(derivedFields.numOrden || g.num_orden || (g as any).NumOrden || "");
      setPesoTotal(String(g.peso_bruto ?? (g as any).PesoBruto ?? 0));
      setCodUniMedPeso(g.cod_uni_med_peso ?? (g as any).CodUniMedPeso ?? "KGM");
      setNumBultos(String(g.numero_bultos ?? (g as any).NumeroBultos ?? 1));
      setModoTraslado(g.cod_modo ?? (g as any).CodModo ?? "02");
      setFecTraslado(g.fec_traslado ? g.fec_traslado.slice(0, 10) : ((g as any).FecTraslado ? String((g as any).FecTraslado).slice(0, 10) : new Date().toISOString().slice(0, 10)));
      setTotFlete(String(g.tot_flete ?? (g as any).TotFlete ?? 0));
      setTotEmbarque(String(g.tot_embarque ?? (g as any).TotEmbarque ?? 0));
      setObservacion(g.observacion ?? (g as any).Observacion ?? (g as any).ObservacionSunat ?? "");

      const clientName = derivedFields.clienteNombre || (g as any).DesCli || (g as any).des_cli || "";
      if (clientName) {
        setDesCliente(clientName);
      } else {
        setDesCliente(g.id_cliente ? `Cliente #${g.id_cliente}` : "");
      }
      await hydrateLookupTexts(g);
    }).catch(e => toast.error(e.message)).finally(() => setLoading(false));
  }, [idGuia, hydrateLookupTexts]);

  const reloadGuia = useCallback(async () => {
    if (!idGuia) return;
    const g = await fetchGuiaRemision(idGuia);
    setGuia(g);
    await hydrateLookupTexts(g);
  }, [idGuia, hydrateLookupTexts]);

  const handleSave = async () => {
    if (!idCliente) { toast.error("Ingrese el cliente"); return; }
    if (!numDoc) { toast.error("Ingrese el número de documento"); return; }
    if (parseFloat(pesoTotal) <= 0) { toast.error("El peso total no puede ser CERO"); return; }
    if (parseInt(numBultos) <= 0) { toast.error("La cantidad de bultos no puede ser CERO"); return; }

    setSaving(true);
    try {
      const payload = {
        id_locacion: idLocacion,
        fec_doc: fecDoc,
        num_doc: parseInt(numDoc),
        id_cliente: Number(idCliente),
        id_loc_cli: idLocCli !== "" ? Number(idLocCli) : undefined,
        id_fiscal: idFiscal !== "" ? Number(idFiscal) : undefined,
        cod_mot: codMot,
        num_job: numJob || undefined,
        pto_partida: partida || undefined,
        pto_llegada: llegada || undefined,
        cod_mon: codMon,
        igv: parseFloat(igv),
        tip_cambio: parseFloat(tipCambio),
        tot_flete: parseFloat(totFlete),
        tot_embarque: parseFloat(totEmbarque),
        num_orden: numOrden || undefined,
        id_cotizacion: idCotizacion !== "" ? Number(idCotizacion) : undefined,
        observacion: observacion || undefined,
        peso_bruto: parseFloat(pesoTotal),
        cod_uni_med_peso: codUniMedPeso,
        numero_bultos: parseInt(numBultos),
        fec_traslado: fecTraslado,
        cod_modo: modoTraslado,
      };

      if (isNew) {
        const result = await createGuiaRemision(payload);
        toast.success(`Guía N° ${result.num_doc} creada correctamente`);
        setGuia(result);
        setMode("view");
        onSaved?.();
      } else {
        const result = await updateGuiaRemision(idGuia!, payload);
        setGuia(result);
        toast.success("Guía actualizada correctamente");
        setMode("view");
        onSaved?.();
      }
    } catch (e: any) {
      toast.error(e.message ?? "Error al guardar");
    } finally {
      setSaving(false);
    }
  };

  const handleDeleteDet = async (det: GuiaRemisionDet) => {
    if (!confirm(`¿Eliminar el ítem ${det.cod_mer}?`)) return;
    try {
      const guiaId = Number(idGuia);
      const detId = Number(det.id);
      if (!Number.isFinite(guiaId) || !Number.isFinite(detId)) {
        toast.error("Guía o ítem inválido");
        return;
      }

      await deleteGuiaRemisionDet(guiaId, detId);
      toast.success("Ítem eliminado");
      await reloadGuia();
    } catch (e: any) {
      toast.error(e.message);
    }
  };

  const detailles = guia?.detalles ?? [];
  const [sortBy, setSortBy] = useState<{ col: string; asc: boolean } | null>(null);
  const sortedDetails = useMemo(() => {
    const arr = [...detailles];
    if (!sortBy) return arr;
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
  }, [detailles, sortBy]);
  const totals = {
    bruto: detailles.reduce((s, d) => s + d.can_mer * d.pre_mer, 0),
    dscto: detailles.reduce((s, d) => s + d.can_mer * d.dsc_mer, 0),
    venta: guia?.tot_venta ?? 0,
    igv_amt: guia?.tot_igv ?? 0,
    neto: guia?.tot_neto ?? 0,
  };

  if (loading) {
    return (
      <div className="h-full flex items-center justify-center text-[12px] text-slate-500">
        Cargando guía…
      </div>
    );
  }

  const estado = guia?.estado ?? "GENERADO";
  const canEdit = estado === "GENERADO" || estado === "APROBADO";
  const estadoDisplay = getGuideEstadoDisplay(estado);

  const handleEditarCabecera = () => {
    if (isNew) {
      toast.info("La cabecera ya esta en modo edicion");
      return;
    }
    if (!canEdit) {
      toast.warning("La guia no permite editar cabecera en su estado actual");
      return;
    }
    setMode("edit");
  };

  const handleActualizarMoneda = () => {
    if (!editable) {
      toast.info("Active edicion para actualizar moneda");
      return;
    }
    const nextMon = codMon === "NS" ? "US" : "NS";
    setCodMon(nextMon);
    if (nextMon === "US") {
      if (!tipCambio || Number(tipCambio) <= 1) setTipCambio("3.411");
    } else {
      setTipCambio("1.000");
    }
    toast.success(`Moneda actualizada a ${nextMon === "NS" ? "PEN" : "USD"}`);
  };

  const handleTransportistaClick = () => {
    if (!idGuia) {
      toast.warning("Primero guarde la guia para ingresar transportista");
      return;
    }
    setShowTransportista(true);
  };

  return (
    <div className={[isNew ? "w-full" : "h-full", "flex flex-col bg-[#F3F6FA] overflow-hidden"].join(" ")}>
      {/* Toolbar */}
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        {!isNew && (
          <>
            <button className={iconBtn} title="Imprimir Guía"><Printer className="h-4 w-4" /></button>
            <button className={iconBtn} title="Imprimir Ticket"><Receipt className="h-3.5 w-3.5" /></button>
            <button className={iconBtn} title="Imprimir con Precios"><DollarSign className="h-3.5 w-3.5" /></button>
            {tbSep}
          </>
        )}

        {!isDetailOnly && (
          <>
            <button className={iconBtn} title="Editar cabecera" onClick={handleEditarCabecera}>
              <Pencil className="h-4 w-4" />
            </button>
            {tbSep}
            <button className={iconBtn} title="Sugerir factor-descuento" onClick={() => setShowSugerirFactor(true)}>
              <Filter className="h-4 w-4" />
            </button>
            {tbSep}
            <button className={iconBtn} title={saving ? "Grabando cambios..." : "Grabar cambios"} onClick={handleSave} disabled={saving || !editable}>
              <Save className="h-4 w-4" />
            </button>
            {tbSep}
          </>
        )}
        <button className={iconBtn} title="Deshacer cambios" onClick={() => { isNew ? onClose() : setMode("view"); }}>
          <RefreshCw className="h-4 w-4" />
        </button>
        {tbSep}

        <button className={iconBtn} title="Ingresar transportista" onClick={handleTransportistaClick}>
          <Car className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Actualizar moneda de guia" onClick={handleActualizarMoneda}>
          <DollarSign className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Cerrar el formulario" onClick={onClose}><LogOut className="h-4 w-4" /></button>
        <span className="ml-auto text-[11px] text-slate-600 shrink-0">
          {idGuia ? `GUÍAS DE REMISIÓN N° "${numDoc}"` : "Registrar nueva GUÍA DE REMISIÓN"}
        </span>
      </div>

      {/* Sub-header */}
      <div className="text-center text-[11px] font-bold text-slate-800 bg-[#EEF2F7] border-b border-slate-300 py-0.5">
        OFICINA: LIMA {" — "} ALMACÉN: COMERCIAL
      </div>

      <div className={[isNew ? "overflow-auto" : "flex-1 min-h-0 overflow-auto", "p-1.5 space-y-1"].join(" ")}>
        {!isDetailOnly && (
          <>
            {/* ── CABECERA PRINCIPAL ── */}
            <div className="border border-slate-300 bg-[#F8FBFF] p-2 shadow-sm text-[11px]">
              <div className="min-w-[820px] space-y-1">
                <div className="grid grid-cols-[1fr_auto] gap-2 items-start">
                  <div className="space-y-1">
                    {/* FILA 1 */}
                <div className="grid grid-cols-[150px_160px_135px_100px_130px] gap-1 items-center">
                  <InlineField label="Número" labelWidth="w-[55px]">
                    <input 
                      className={`${inp} font-mono`} 
                      value={numDoc || ""} 
                      onChange={e => setNumDoc(e.target.value)} 
                      readOnly={!editable || !isNew} 
                    />
                  </InlineField>
                  <InlineField label="Fecha" labelWidth="w-[45px]">
                    <input 
                      className={inp} 
                      type="date" 
                      value={fecDoc || ""} 
                      onChange={e => setFecDoc(e.target.value)} 
                      readOnly={!editable} 
                    />
                  </InlineField>
                  <InlineField label="Moneda" labelWidth="w-[52px]">
                    <select 
                      className={inp} 
                      value={codMon || "NS"} 
                      onChange={e => setCodMon(e.target.value)} 
                      disabled={!editable}
                    >
                      <option value="NS">PEN (S/)</option>
                      <option value="US">USD ($)</option>
                    </select>
                  </InlineField>
                  <InlineField label="IGV" labelWidth="w-[32px]">
                    <input 
                      className={`${inp} font-mono`} 
                      value={igv || ""} 
                      onChange={e => setIgv(e.target.value)} 
                      readOnly={!editable} 
                    />
                  </InlineField>
                  <InlineField label="Tip.Cam." labelWidth="w-[58px]">
                    <input 
                      className={`${inp} font-mono`} 
                      value={tipCambio || ""} 
                      onChange={e => setTipCambio(e.target.value)} 
                      readOnly={!editable} 
                    />
                  </InlineField>
                </div>

                {/* FILA 2 */}
                <div className="grid grid-cols-[1fr_1.1fr] gap-2 items-center">
                  <InlineField label="Cliente" labelWidth="w-[65px]">
                    <div className="flex gap-1 w-full">
                      <input 
                        className={inp} 
                        value={desCliente || (idCliente ? `ID: ${idCliente}` : "")} 
                        onChange={e => setDesCliente(e.target.value)} 
                        readOnly={!editable} 
                        placeholder="(Buscar cliente…)" 
                      />
                      {editable && (
                        <button 
                          type="button"
                          className={squareIconBtn} 
                          title="Buscar Cliente" 
                          onClick={() => setShowClienteLookup(true)}
                        >
                          <Search className="h-3.5 w-3.5" />
                        </button>
                      )}
                    </div>
                  </InlineField>
                  <InlineField label="Loc.Cliente" labelWidth="w-[75px]">
                    <div className="flex gap-1 w-full">
                      <input 
                        className={inp} 
                        value={desLocCli || (idLocCli ? `ID: ${idLocCli}` : "")} 
                        onChange={e => setDesLocCli(e.target.value)} 
                        readOnly={!editable} 
                        placeholder="(Buscar locación…)" 
                      />
                      {editable && (
                        <>
                          <button 
                            type="button"
                            className={squareIconBtn} 
                            title="Editar Locación"
                          >
                            <Pencil className="h-3 w-3" />
                          </button>
                          <button 
                            type="button"
                            className={squareIconBtn} 
                            title="Buscar Locación"
                          >
                            <Search className="h-3.5 w-3.5" />
                          </button>
                        </>
                      )}
                    </div>
                  </InlineField>
                </div>

                {/* FILA 3 */}
                <div className="grid grid-cols-[1fr_1.1fr] gap-2 items-center">
                  <InlineField label="Dir. Fiscal" labelWidth="w-[65px]">
                    <div className="flex gap-1 w-full">
                      <input 
                        className={inp} 
                        value={desFiscal || (idFiscal ? `ID: ${idFiscal}` : "")} 
                        onChange={e => setDesFiscal(e.target.value)} 
                        readOnly={!editable} 
                        placeholder="(Buscar dirección…)" 
                      />
                      {editable && (
                        <>
                          <button 
                            type="button"
                            className={squareIconBtn} 
                            title="Editar Dirección"
                          >
                            <Pencil className="h-3 w-3" />
                          </button>
                          <button 
                            type="button"
                            className={squareIconBtn} 
                            title="Buscar Dirección"
                          >
                            <Search className="h-3.5 w-3.5" />
                          </button>
                        </>
                      )}
                    </div>
                  </InlineField>
                  <InlineField label="Motivo" labelWidth="w-[75px]">
                    <select 
                      className={inp} 
                      value={codMot || "1"} 
                      onChange={e => setCodMot(e.target.value)} 
                      disabled={!editable}
                    >
                      <option value="1">Venta</option>
                      <option value="2">Transferencia Gratuita</option>
                      <option value="3">Consignación</option>
                      <option value="4">Traslado entre establecimientos</option>
                      <option value="5">Traslado por devolución</option>
                    </select>
                  </InlineField>
                </div>

                {/* FILA 4 */}
                <div className="grid grid-cols-[1fr_1.1fr] gap-2 items-center">
                  <div className="grid grid-cols-[1fr_1.1fr] gap-1 items-center">
                    <InlineField label="# OT" labelWidth="w-[65px]">
                      <div className="flex gap-1 w-full">
                        <input 
                          className={inp} 
                          value={numJob || ""} 
                          onChange={e => setNumJob(e.target.value)} 
                          readOnly={!editable} 
                        />
                        {editable && (
                          <button 
                            type="button"
                            className={squareIconBtn} 
                            title="Buscar OT"
                          >
                            <Search className="h-3.5 w-3.5" />
                          </button>
                        )}
                      </div>
                    </InlineField>
                    <InlineField label="Cotización" labelWidth="w-[70px]">
                      <input 
                        className={inp} 
                        value={idCotizacion ?? ""} 
                        onChange={e => setIdCotizacion(parseInt(e.target.value, 10) || 0)}
                        readOnly={!editable} 
                      />
                    </InlineField>
                  </div>
                  <InlineField label="Partida" labelWidth="w-[75px]">
                    <input 
                      className={inp} 
                      value={partida || ""} 
                      onChange={e => setPartida(e.target.value)} 
                      readOnly={!editable} 
                    />
                  </InlineField>
                </div>

                {/* FILA 5 */}
                <div className="grid grid-cols-[1fr_1.1fr] gap-2 items-center">
                  <InlineField label="Llegada" labelWidth="w-[65px]">
                    <input 
                      className={inp} 
                      value={llegada || ""} 
                      onChange={e => setLlegada(e.target.value)} 
                      readOnly={!editable} 
                    />
                  </InlineField>
                  <InlineField label="Vendedor" labelWidth="w-[75px]">
                    <input 
                      className={inp} 
                      value="" 
                      readOnly 
                      placeholder="(asignado por sistema)" 
                    />
                  </InlineField>
                </div>
              </div>

              {/* Panel Lateral Derecho (Costos + O/C perfectamente alineado a la derecha) */}
              <div className="flex flex-col gap-1">
                <div className="h-6 bg-slate-200/60 border border-slate-300 rounded-sm flex items-center justify-center px-2 text-[11px] font-bold text-slate-800">
                  {isNew ? "" : estadoDisplay || estado}
                </div>
                <div className="border border-slate-300 bg-white p-1.5 shadow-xs">
                  <div className="mb-1 text-[11px] font-bold text-slate-800">Costos</div>
                  <div className="space-y-1">
                    <InlineField label="Flete" labelWidth="w-[70px]">
                      <input 
                        className={`${inp} font-mono text-right`} 
                        value={totFlete || ""} 
                        onChange={e => setTotFlete(e.target.value)} 
                        readOnly={!editable} 
                      />
                    </InlineField>
                    <InlineField label="Embarque" labelWidth="w-[70px]">
                      <input 
                        className={`${inp} font-mono text-right`} 
                        value={totEmbarque || ""} 
                        onChange={e => setTotEmbarque(e.target.value)} 
                        readOnly={!editable} 
                      />
                    </InlineField>
                  </div>
                </div>
                {/* Campo O/C Alineado correctamente debajo del panel Costos */}
                <div className="pt-0.5">
                  <InlineField label="O/C" labelWidth="w-[70px]">
                    <input 
                      className={inp} 
                      value={numOrden || ""} 
                      onChange={e => setNumOrden(e.target.value)} 
                      readOnly={!editable} 
                    />
                  </InlineField>
                </div>
              </div>
            </div>

            {/* FILA 6 */}
            <div className="grid grid-cols-[220px_1fr_210px] gap-2 items-center pt-1">
              <InlineField label="Peso Total" labelWidth="w-[75px]">
                <input 
                  className={`${inp} font-mono text-right`} 
                  value={pesoTotal || ""} 
                  onChange={e => setPesoTotal(e.target.value)} 
                  readOnly={!editable} 
                />
              </InlineField>
              <InlineField label="Unid. Medida Peso" labelWidth="w-[115px]">
                <select 
                  className={`${inp} max-w-[140px]`} 
                  value={codUniMedPeso || "KGM"} 
                  onChange={e => setCodUniMedPeso(e.target.value)} 
                  disabled={!editable}
                >
                  <option value="KGM">Kilogramos</option>
                  <option value="TNE">Toneladas</option>
                  <option value="LBR">Libras</option>
                </select>
              </InlineField>
              <InlineField label="Cant. Bultos / Palets" labelWidth="w-[130px]">
                <input 
                  className={`${inp} font-mono text-right`} 
                  value={numBultos || ""} 
                  onChange={e => setNumBultos(e.target.value)} 
                  readOnly={!editable} 
                />
              </InlineField>
            </div>

            {/* FILA 7 */}
            <div className="grid grid-cols-[1fr_260px] gap-2 items-center">
              <InlineField label="Modo Traslado" labelWidth="w-[95px]">
                <select 
                  className={`${inp} max-w-[220px]`} 
                  value={modoTraslado || "02"} 
                  onChange={e => setModoTraslado(e.target.value)} 
                  disabled={!editable}
                >
                  <option value="01">Transporte Público</option>
                  <option value="02">Transporte Privado</option>
                </select>
              </InlineField>
              <InlineField label="Fecha Inicio Traslado" labelWidth="w-[130px]">
                <input 
                  className={inp} 
                  type="date" 
                  value={fecTraslado || ""} 
                  onChange={e => setFecTraslado(e.target.value)} 
                  readOnly={!editable} 
                />
              </InlineField>
            </div>

            {/* FILA 8: Observación */}
            <div className="pt-0.5">
              <InlineField label="Observación" labelWidth="w-[85px]" className="items-center">
                <div className="flex gap-1 w-full items-center">
                  <input 
                    className={inp} 
                    value={observacion || ""} 
                    onChange={e => setObservacion(e.target.value)} 
                    readOnly={!editable} 
                  />
                  <button 
                    type="button"
                    className={squareIconBtn} 
                    title="Editar Observación"
                    onClick={() => setShowObsModal(true)}
                  >
                    <Pencil className="h-3 w-3" />
                  </button>
                </div>
              </InlineField>
            </div>
          </div>
        </div>
        </>)}

        {isDetailOnly && guia && (
          <div className="border border-slate-300 bg-[#F8FBFF] p-2 shadow-sm text-[11px]">
            <div className="grid grid-cols-[1fr_1fr] gap-2 items-center">
              <div className="text-[12px] font-semibold text-slate-800">Edición compacta - Detalles de Guía</div>
              <div className="text-[11px] text-slate-600">Guía N° {numDoc} · Fecha: {fecDoc} · Cliente: {desCliente}</div>
            </div>
          </div>
        )}

        {/* ── DETALLES ── */}
        {!isNew && (
          <div className="border border-slate-300 bg-white rounded-sm overflow-hidden">
            <div className="flex items-center justify-between px-2 py-1 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-300">
              <span className="text-[11px] font-semibold text-slate-800">[ Detalles ]</span>
              {canEdit && mode === "view" && (
                <button className={`${btn} text-[10.5px] h-6`} onClick={() => setDetModal({ open: true })}>
                  <Plus className="h-3 w-3" /> Nuevo ítem
                </button>
              )}
            </div>
            <div className="overflow-x-auto">
              <table className="w-full text-[11.5px]">
                <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800">
                  <tr>
                    {[
                      { key: 'item', label: 'Ítem' },
                      { key: 'cod_mer', label: 'Código' },
                      { key: 'des_mer', label: 'Descripción' },
                      { key: 'can_mer', label: 'Cant.' },
                      { key: 'pre_mer', label: 'Precio' },
                      { key: 'dsc_mer', label: 'Desc.(%)' },
                      { key: 'total_fila', label: 'Total' },
                      { key: 'total_suger', label: 'Total Suger.' },
                      { key: '__actions', label: '' },
                    ].map(h => (
                      <th
                        key={h.key}
                        className={`px-1.5 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap ${h.key !== '__actions' ? 'cursor-pointer hover:bg-[#E6EEF9]' : ''}`}
                        onClick={() => {
                          if (h.key === '__actions') return;
                          setSortBy(prev => prev?.col === h.key ? { col: h.key, asc: !prev.asc } : { col: h.key, asc: true });
                        }}
                      >
                        <div className="flex items-center justify-center gap-1">
                          <span>{h.label}</span>
                          {sortBy?.col === h.key && <span className="text-[10px] text-slate-500">{sortBy.asc ? '▲' : '▼'}</span>}
                        </div>
                      </th>
                    ))}
                  </tr>
                </thead>
                <tbody>
                  {detailles.length === 0 ? (
                    <tr>
                      <td colSpan={9} className="text-center py-4 text-slate-400 text-[11px]">Sin ítems — use "Nuevo ítem" para agregar</td>
                    </tr>
                  ) : sortedDetails.map((d, i) => (
                    <tr key={d.id} className={`${i % 2 ? "bg-[#F6F9FC]" : "bg-white"} hover:bg-[#D6E4F4]/40`}>
                      <td className="px-1.5 py-1 text-center border-b border-r border-slate-200 font-mono">{d.item}</td>
                      <td className="px-1.5 py-1 border-b border-r border-slate-200 font-mono">{d.cod_mer}</td>
                      <td className="px-1.5 py-1 border-b border-r border-slate-200 max-w-[240px] truncate">{d.des_mer}</td>
                      <td className="px-1.5 py-1 text-right border-b border-r border-slate-200 font-mono">{d.can_mer.toFixed(0)}</td>
                      <td className="px-1.5 py-1 text-right border-b border-r border-slate-200 font-mono">{d.pre_mer.toFixed(2)}</td>
                      <td className="px-1.5 py-1 text-right border-b border-r border-slate-200 font-mono">{d.dsc_mer.toFixed(2)}</td>
                      <td className="px-1.5 py-1 text-right border-b border-r border-slate-200 font-mono font-semibold">{d.total_fila.toFixed(2)}</td>
                      <td className="px-1.5 py-1 text-right border-b border-r border-slate-200 font-mono">{(d as any).total_suger?.toFixed(2) ?? ""}</td>
                      <td className="px-1 py-1 border-b border-slate-200 text-center w-12">
                        {canEdit && (
                          <div className="flex gap-0.5 justify-center">
                            <button className={iconBtn} title="Modificar" onClick={() => setDetModal({ open: true, detalle: d })}>
                              <Pencil className="h-3 w-3" />
                            </button>
                            <button className={`${iconBtn} hover:text-red-600`} title="Eliminar" onClick={() => handleDeleteDet(d)}>
                              <Trash2 className="h-3 w-3" />
                            </button>
                          </div>
                        )}
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>

            {/* Detalles block end */}
          </div>
        )}

        {/* Totales siempre visibles cuando hay una guía */}
        {guia && (
          <div className="flex justify-end gap-4 px-3 py-1.5 bg-[#EEF2F7] border-t border-slate-300 text-[11.5px]">
            <span className="text-slate-600">Sub Totales ==&gt;</span>
            <span className="font-mono w-20 text-right">{totals.bruto.toFixed(2)}</span>
            <span className="text-slate-600">Dscto:</span>
            <span className="font-mono w-20 text-right text-red-600">-{totals.dscto.toFixed(2)}</span>
            <span className="text-slate-600">IGV ==&gt;</span>
            <span className="font-mono w-20 text-right">{totals.igv_amt.toFixed(2)}</span>
            <span className="font-semibold text-slate-800">TOTAL NETO ({codMon === "NS" ? "S/" : "$"}) ==&gt;</span>
            <span className="font-mono font-bold text-[13px] w-24 text-right text-blue-800">{totals.neto.toFixed(2)}</span>
          </div>
        )}
      </div>

      {/* Modales secundarios */}
      {showObsModal && (
        <ObservacionModal
          value={observacion}
          onClose={() => setShowObsModal(false)}
          onSave={(newVal) => setObservacion(newVal)}
        />
      )}

      {showClienteLookup && (
        <ClienteLookupModal
          onClose={() => setShowClienteLookup(false)}
          onSelect={(c) => {
            const parsed = Number(c.id);
            if (!Number.isNaN(parsed)) {
              setIdCliente(parsed);
            } else {
              toast.warning("Este cliente no tiene código numérico compatible para la guía");
            }
            setDesCliente(c.name);
            setDesFiscal(c.address || "");
            setShowClienteLookup(false);
          }}
        />
      )}

      {showSugerirFactor && (
        <SugerirFactorModal onClose={() => setShowSugerirFactor(false)} />
      )}

      {showTransportista && idGuia && (
        <TransportistaModal
          idGuia={idGuia}
          initial={guia?.transportista ?? undefined}
          onClose={() => setShowTransportista(false)}
          onSaved={t => { setGuia(prev => prev ? { ...prev, transportista: t } : prev); }}
        />
      )}

      {detModal.open && idGuia && (
        <DetModal
          idGuia={idGuia}
          idLocacion={idLocacion}
          detalle={detModal.detalle}
          onClose={() => setDetModal({ open: false })}
          onSaved={reloadGuia}
        />
      )}
    </div>
  );
}

// ─────────────────────────────────────────────────────────────────────────────
// LISTADO PRINCIPAL  (frmGuiasRemision)
// ─────────────────────────────────────────────────────────────────────────────
export function GuiaRemisionList() {
  const [rows, setRows] = useState<GuiaRemisionRow[]>([]);
  const [loading, setLoading] = useState(false);
  const [searched, setSearched] = useState(false);

  // Lookup data
  const [clients, setClients] = useState<SigecoomClient[]>([]);
  const [locations, setLocations] = useState<Location[]>([]);
  const [clientById, setClientById] = useState<Record<number, SigecoomClient>>({});
  const [locationById, setLocationById] = useState<Record<number, Location>>({});

  // Filtros
  const [anio, setAnio] = useState(() => getTodayDateParts().year);
  const [mes, setMes] = useState(() => getTodayDateParts().month);
  const [estado, setEstado] = useState("");
  const [numDoc, setNumDoc] = useState("");
  const [clientFilterId, setClientFilterId] = useState<number | "">("");
  const [clientFilterLabel, setClientFilterLabel] = useState("(Todos)");
  const [officeFilter, setOfficeFilter] = useState("");
  const [warehouseFilter, setWarehouseFilter] = useState("");
  const [locationFilterId, setLocationFilterId] = useState<number | "">("");
  const [showClientLookup, setShowClientLookup] = useState(false);
  const [showPrintModal, setShowPrintModal] = useState(false);
  const [motivoBajaRow, setMotivoBajaRow] = useState<GuiaRemisionRow | null>(null);
  const [modificarObsRow, setModificarObsRow] = useState<GuiaRemisionRow | null>(null);
  const [obsSunatRow, setObsSunatRow] = useState<GuiaRemisionRow | null>(null);

  const [selected, setSelected] = useState<GuiaRemisionRow | null>(null);
  const [formWindows, setFormWindows] = useState<GuiaFormWindow[]>([]);
  const [toolWindows, setToolWindows] = useState<GuiaToolWindow[]>([]);
  const zRef = useRef(3000);
  const cascadeRef = useRef(0);

  const load = useCallback(async () => {
    setLoading(true);
    try {
      // If no explicit location filter is set, try to infer id_locacion from
      // the currently selected company in session (legacy mapping). This
      // ensures users on company 08 immediately see guías for id_locacion=87
      // without restarting the app.
      let inferredIdLocacion: number | undefined = undefined;
      if (locationFilterId === "") {
        inferredIdLocacion = inferIdLocacionFromSession();
      }

      const queryParams = {
        anio: anio ? parseInt(anio) : undefined,
        mes: mes ? parseInt(mes) : undefined,
        id_locacion: locationFilterId !== "" ? Number(locationFilterId) : inferredIdLocacion,
        id_cliente: clientFilterId !== "" ? Number(clientFilterId) : undefined,
        estado: estado || undefined,
        num_doc: numDoc ? parseInt(numDoc) : undefined,
        limit: 500,
      };
      try { console.info('[GuiasRemision] fetching with params', queryParams); } catch (_) {}

      const data = await fetchGuiasRemision(queryParams as any);
      try { const d:any = data; console.info('[GuiasRemision] fetched rows count', Array.isArray(d) ? d.length : (d && (d as any).items ? (d as any).items.length : null)); } catch (_) {}
      setRows(data);
      setSearched(true);
    } catch (e: any) {
      toast.error(e.message ?? "Error al cargar guías");
    } finally {
      setLoading(false);
    }
  }, [anio, mes, estado, numDoc, clientFilterId, locationFilterId]);

  useEffect(() => {
    load();
    fetchSigecoomClients(0, 0)
      .then((res) => {
        const data = res.items;
        setClients(data);
        const map: Record<number, SigecoomClient> = {};
        data.forEach((item) => {
          const id = Number(item.id);
          if (!Number.isNaN(id)) map[id] = item;
        });
        setClientById(map);
      })
      .catch((e: any) => console.warn("No se pudo cargar clientes", e));
    fetchSigecoomLocations()
      .then((data) => {
        setLocations(data);
        const map: Record<number, Location> = {};
        data.forEach((item) => {
          const id = Number(item.id);
          if (!Number.isNaN(id)) map[id] = item;
        });
        setLocationById(map);
      })
      .catch((e: any) => console.warn("No se pudo cargar locaciones", e));
  }, []);

  // Reload list when session (empresa) changes so headers/allowed codes are updated
  useEffect(() => {
    const onSessionUpdated = (ev: Event) => {
      try {
        // call load to refresh guías for the newly selected company
        load();
      } catch (_) {}
    };
    window.addEventListener('systeck-session-updated', onSessionUpdated as EventListener);
    return () => window.removeEventListener('systeck-session-updated', onSessionUpdated as EventListener);
  }, [load]);

  const officeOptions = Array.from(new Set(locations.map((loc) => loc.code))).filter(Boolean);
  const warehouseOptions = Array.from(new Set(locations.map((loc) => loc.warehouse))).filter(Boolean);
  // frmGuiasRemision.vb arma cmbIdLocacion con 4 columnas (IdLocacion, DesAlm, AproDoc, CodAlm)
  // desde oMaestroService.MostrarLocaciones(CodEmp, CodOfi, CodUsu). El backend actual (Location,
  // /locations) todavía no expone un cod_alm propio — "code" ya se usa como agrupador de Oficina y
  // "warehouse" es la descripción — así que por ahora se muestra el id interno como referencia hasta
  // que se agregue cod_alm al modelo Location.
  const warehouseCodAlm: Record<string, string> = {};
  locations.forEach((loc) => {
    if (loc.warehouse && !(loc.warehouse in warehouseCodAlm)) warehouseCodAlm[loc.warehouse] = loc.cod_alm ?? String(loc.id);
  });

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

  const openFormWindow = useCallback((idGuia?: number | string, detailOnly = false, defaultIdLocacion?: number) => {
    const maxW = typeof window !== "undefined" ? window.innerWidth : 1280;
    const maxH = typeof window !== "undefined" ? Math.max(320, window.innerHeight - FLOAT_DESKTOP_STATUS_BAR_H) : 720;
    const isNewForm = !idGuia;
    const targetW = isNewForm ? 1060 : detailOnly ? 980 : 1120;
    const targetH = isNewForm ? 420 : detailOnly ? 540 : 690;
    const minW = isNewForm ? 900 : detailOnly ? 900 : 980;
    const minH = isNewForm ? 360 : detailOnly ? 460 : 540;
    const w = Math.min(targetW, Math.max(minW, maxW - 24));
    const h = Math.min(targetH, Math.max(minH, maxH - 24));
    zRef.current += 1;
    cascadeRef.current = (cascadeRef.current + 1) % 9;
    const offset = cascadeRef.current * 22;
    const id = `guia-form-${Date.now()}-${Math.random().toString(36).slice(2, 6)}`;
    const initialX = 55 + offset;
    const initialY = (isNewForm ? 18 : 32) + offset;
    const x = Math.max(0, Math.min(initialX, Math.max(0, maxW - w)));
    const y = Math.max(0, Math.min(initialY, Math.max(0, maxH - h)));
    const resolvedIdLocacion = defaultIdLocacion ?? inferIdLocacionFromSession() ?? 1;
    setFormWindows((prev) => [
      ...prev,
      {
        id,
        idGuia,
        idLocacion: resolvedIdLocacion,
        detailOnly,
        title: idGuia ? detailOnly ? `Editar guía N° ${idGuia}` : `GUIAS DE REMISION N° ${idGuia}` : "Registrar nueva GUIA DE REMISION",
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
    openFormWindow(undefined, false, inferIdLocacionFromSession() ?? 1);
  };

  const handleMostrar = (row: GuiaRemisionRow, detailOnly = true) => {
    setSelected(row);
    openFormWindow(String(row.id), detailOnly, Number(row.id_locacion) || inferIdLocacionFromSession() || 1);
  };

  const handleEliminar = (row: GuiaRemisionRow, detailOnly = true) => {
    if (!confirm(`¿Eliminar la Guía N° ${row.num_doc}? Esta acción borrará la guía definitivamente.`)) return;
    (async () => {
      try {
        await deleteGuiaRemision(row.id);
        toast.success(`Guía N° ${row.num_doc} eliminada`);
        await load();
      } catch (e: any) {
        toast.error(e.message ?? "Error al eliminar la guía");
      }
    })();
  };

  // Réplica de frmGuiaRemision_MotivoBaja.vb: exige una observación antes de anular.
  // La confirmación amistosa ("¿Está seguro de ANULAR...?") vive dentro de MotivoBajaModal.
  const handleAnular = (row: GuiaRemisionRow) => {
    setMotivoBajaRow(row);
  };

  const submitAnular = async (row: GuiaRemisionRow, observacion: string) => {
    try {
      // sigecoom-api.ts: anularGuiaRemision(id) solo cambia el estado a ANULADO
      // (no acepta observación). Se guarda primero la observación con updateGuiaRemision
      // — igual que el motivo que pedía frmGuiaRemision_MotivoBaja.vb — y luego se anula.
      await updateGuiaRemision(row.id, { observacion });
      await anularGuiaRemision(row.id);
      toast.success(`Guía N° ${row.num_doc} anulada`);
      setMotivoBajaRow(null);
      await load();
    } catch (e: any) {
      toast.error(e.message ?? "Error al anular la guía");
    }
  };

  const canAnular = (row: GuiaRemisionRow) => row.estado === "GENERADO" || row.estado === "APROBADO";

  const pickFirstNonEmpty = (...values: Array<string | number | null | undefined>) => {
    for (const value of values) {
      if (value === null || value === undefined) continue;
      const text = String(value).trim();
      if (text !== "") return value;
    }
    return "";
  };

  const getAnyValue = (row: any, ...keys: string[]) => {
    for (const key of keys) {
      const value = row?.[key];
      if (value === null || value === undefined) continue;
      const text = String(value).trim();
      if (text !== "") return value;
    }
    return "";
  };

  const getReferenceValue = (row: Partial<GuiaRemisionRow> | any) => {
    const refValue = pickFirstNonEmpty(
      getAnyValue(row, "NumJob", "num_job", "NumFac", "num_fac", "Referencia", "referencia", "Ref", "ref"),
      row?.pto_llegada,
      row?.PtoLlegada,
      row?.pto_partida,
      row?.PtoPartida,
    );
    return normalizeReferenceDisplay(refValue);
  };

  const resolveReferencia = (r: GuiaRemisionRow) => {
    const raw = getReferenceValue(r);
    return raw === "" ? "-" : raw;
  };

  const resolveCotizacion = (r: GuiaRemisionRow) => {
    const raw = pickFirstNonEmpty(
      getAnyValue(r as any, "IdCotizacion", "id_cotizacion", "NumCot", "num_cot", "Cotizacion", "cotizacion", "Cotiz", "cotiz"),
    );
    return raw === "" ? "-" : String(raw);
  };

  const [sortBy, setSortBy] = useState<{ col: string; asc: boolean } | null>(null);
  const rowsView = useMemo(() => {
    const out = [...rows];
    const getValue = (r: GuiaRemisionRow, col: string) => {
      switch (col) {
        case "num_doc":
          return r.num_doc ?? "";
        case "fec_doc":
          return r.fec_doc ? new Date(r.fec_doc).getTime() : 0;
        case "reference":
          return resolveReferencia(r);
        case "cliente":
          return r.cliente_nombre ?? clientById[r.id_cliente]?.name ?? `Cliente #${r.id_cliente}`;
        case "cod_mon":
          return r.cod_mon ?? "";
        case "tot_venta":
          return r.tot_venta ?? 0;
        case "estado":
          return r.estado ?? "";
        case "estado_sunat":
          return r.estado_sunat ?? (r.estado === "ANULADO" ? "BAJA" : r.estado === "APROBADO" ? "ACEPTADO" : "PENDIENTE");
        case "observacion":
          return r.observacion ?? "";
        case "id_cotizacion":
          return r.id_cotizacion ?? "";
        case "num_orden":
          return r.num_orden ?? "";
        case "tot_neto_sug":
          return r.tot_neto_sug ?? r.tot_neto ?? 0;
        case "cod_serie":
          return r.cod_serie ?? String(r.id_serie_doc ?? "");
        default:
          return "";
      }
    };
    if (!sortBy) return out;
    out.sort((a, b) => {
      const va = getValue(a, sortBy.col);
      const vb = getValue(b, sortBy.col);
      if (va == null && vb == null) return 0;
      if (va == null) return sortBy.asc ? -1 : 1;
      if (vb == null) return sortBy.asc ? 1 : -1;
      if (typeof va === "number" && typeof vb === "number") return sortBy.asc ? va - vb : vb - va;
      return sortBy.asc ? String(va).localeCompare(String(vb)) : String(vb).localeCompare(String(va));
    });
    return out;
  }, [rows, sortBy, clientById]);

  const openToolWindow = useCallback((kind: GuiaToolKind) => {
    const meta = TOOL_WINDOW_META[kind];
    const maxW = typeof window !== "undefined" ? window.innerWidth : 1280;
    const maxH = typeof window !== "undefined" ? Math.max(320, window.innerHeight - FLOAT_DESKTOP_STATUS_BAR_H) : 720;
    const w = Math.min(meta.w, Math.max(260, maxW - 16));
    const h = Math.min(meta.h, Math.max(180, maxH - 16));
    zRef.current += 1;
    cascadeRef.current = (cascadeRef.current + 1) % 9;
    const offset = cascadeRef.current * 22;
    const id = `${kind}-${Date.now()}-${Math.random().toString(36).slice(2, 6)}`;
    const initialX = 90 + offset;
    const initialY = 70 + offset;
    const x = Math.max(0, Math.min(initialX, Math.max(0, maxW - w)));
    const y = Math.max(0, Math.min(initialY, Math.max(0, maxH - h)));
    setToolWindows((prev) => [
      ...prev,
      {
        id,
        kind,
        title: kind === "estados" && selected
          ? `Estados de Guia de Remision N° : ${selected.num_doc}`
          : kind === "precios" && selected
            ? `Precios Sugeridos de Guia de Remision N° : ${selected.num_doc}`
            : meta.title,
        x,
        y,
        w,
        h,
        z: zRef.current,
      },
    ]);
  }, [selected]);

  useEffect(() => {
    const onResize = () => {
      const maxW = window.innerWidth;
      const maxH = Math.max(320, window.innerHeight - FLOAT_DESKTOP_STATUS_BAR_H);
      setToolWindows((prev) => prev.map((w) => {
        const nx = Math.max(0, Math.min(w.x, Math.max(0, maxW - w.w)));
        const ny = Math.max(0, Math.min(w.y, Math.max(0, maxH - w.h)));
        return (nx === w.x && ny === w.y) ? w : { ...w, x: nx, y: ny };
      }));
      setFormWindows((prev) => prev.map((w) => {
        const nx = Math.max(0, Math.min(w.x, Math.max(0, maxW - w.w)));
        const ny = Math.max(0, Math.min(w.y, Math.max(0, maxH - w.h)));
        return (nx === w.x && ny === w.y) ? w : { ...w, x: nx, y: ny };
      }));
    };
    window.addEventListener("resize", onResize);
    return () => window.removeEventListener("resize", onResize);
  }, []);

  const focusToolWindow = useCallback((id: string) => {
    zRef.current += 1;
    setToolWindows((prev) => prev.map((w) => (w.id === id ? { ...w, z: zRef.current } : w)));
  }, []);

  const moveToolWindow = useCallback((id: string, x: number, y: number) => {
    setToolWindows((prev) => prev.map((w) => (w.id === id ? { ...w, x, y } : w)));
  }, []);

  const closeToolWindow = useCallback((id: string) => {
    setToolWindows((prev) => prev.filter((w) => w.id !== id));
  }, []);

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

  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      {/* Toolbar principal */}
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        {/* Imprimir | Ticket */}
        <button className={iconBtn} title="Imprimir Guía" onClick={() => setShowPrintModal(true)}><Printer className="h-4 w-4" /></button>
        <button className={iconBtn} title="Imprimir Ticket" onClick={() => openToolWindow("imprimirTicket")}><Receipt className="h-4 w-4" /></button>
        {tbSep}
        {/* Enviar | Generar | Trasladar | B2Mining */}
        <button className={iconBtn} title="Enviar a Créditos" onClick={() => openToolWindow("enviarCreditos")}><CreditCard className="h-4 w-4" /></button>
        <button className={iconBtn} title="Generar Fac/Bol" onClick={() => openToolWindow("generarFactBoleta")}><FilePlus2 className="h-4 w-4" /></button>
        <button className={iconBtn} title="Trasladar Guía" onClick={() => openToolWindow("trasladarGuia")}><Warehouse className="h-4 w-4" /></button>
        <button className={iconBtn} title="Enviar a B2Mining" onClick={() => openToolWindow("enviarB2Mining")}><UploadCloud className="h-4 w-4" /></button>
        {tbSep}
        {/* Nuevo | Mostrar */}
        <button className={iconBtn} title="Nueva Guía" onClick={handleNuevo}><Plus className="h-4 w-4" /></button>
        <button
          className={iconBtn}
          title="Mostrar Guía"
          disabled={!selected}
          onClick={() => selected && handleMostrar(selected)}
        >
          <FolderOpen className="h-4 w-4" />
        </button>
        {tbSep}
        {/* Eliminar | Anular | Sugerir */}
        <button className={iconBtn} title="Eliminar Guía" onClick={() => selected && handleEliminar(selected)}><Trash className="h-4 w-4" /></button>
        <button
          className={iconBtn}
          title="Anular Guía"
          disabled={!selected || !canAnular(selected)}
          onClick={() => selected && handleAnular(selected)}
        >
          <X className="h-4 w-4" />
        </button>
        <button className={iconBtn} title="Sugerir Factor/Descuento" onClick={() => openToolWindow("factor")}><Percent className="h-4 w-4" /></button>
        <button
          className={iconBtn}
          title="Modificar Observación"
          disabled={!selected}
          onClick={() => selected && setModificarObsRow(selected)}
        >
          <Pencil className="h-4 w-4" />
        </button>
        {tbSep}
        {/* Agregar Consumo OT | Estados | Consultar Sugeridos | Enviar G/R Electrónica | Actualizar */}
        <button className={iconBtn} title="Agregar Consumo OT" onClick={() => openToolWindow("consumoOT")}><Wrench className="h-4 w-4" /></button>
        <button className={iconBtn} title="Estados" onClick={() => openToolWindow("estados")}><Clock className="h-4 w-4" /></button>
        <button className={iconBtn} title="Consultar Sugeridos" onClick={() => openToolWindow("precios")}><DollarSign className="h-4 w-4" /></button>
        <button className={iconBtn} title="Enviar Guía Remisión Electrónica" onClick={() => openToolWindow("enviarCorreo")}><Send className="h-4 w-4" /></button>
        <button className={iconBtn} title="Actualizar" onClick={load}><RefreshCw className="h-4 w-4" /></button>
        {tbSep}
        {/* Generar | Descargar | Listar Guías Electrónicas | Observaciones Sunat | Actualizar CDR | Actualizar en Proceso */}
        <button className={iconBtn} title="Generar Guía Electrónica" onClick={() => openToolWindow("electronica")}><FileSpreadsheet className="h-4 w-4" /></button>
        <button className={iconBtn} title="Descargar Guía Electrónica" onClick={() => openToolWindow("electronica")}><Download className="h-4 w-4" /></button>
        <button className={iconBtn} title="Listar Guías Electrónicas" onClick={() => openToolWindow("electronica")}><List className="h-4 w-4" /></button>
        <button className={iconBtn} title="Observaciones SUNAT" onClick={() => openToolWindow("obsSunat")}><Eye className="h-4 w-4" /></button>
        <button className={iconBtn} title="Actualizar CDR" onClick={() => openToolWindow("actualizarCDR")}><RotateCw className="h-4 w-4" /></button>
        <button className={iconBtn} title="Actualizar Guía Electrónica en Proceso" onClick={() => openToolWindow("actProceso")}><Loader2 className="h-4 w-4" /></button>
        {tbSep}
        {/* Bajar de Nivel (utilidad interna, sin equivalente directo en el menú SUNAT) */}
        <button className={iconBtn} title="Bajar de Nivel" onClick={() => openToolWindow("bajarNivel")}><ArrowDown className="h-4 w-4" /></button>
        {tbSep}
        {/* Salir */}
        <button className={iconBtn} title="Salir" onClick={() => toast.info("Use el botón X de la ventana para cerrar")}><LogOut className="h-4 w-4" /></button>
      </div>

      {/* Filtros */}
      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="Año" className="w-[84px]">
          <YearSpinner value={anio} onChange={setAnio} />
        </Field>
        <Field label="Mes" className="w-32">
          <MonthSelector value={mes} onChange={setMes} />
        </Field>
        <Field label="Oficina" className="w-28">
          <CodeDescSelector
            value={officeFilter}
            onChange={setOfficeFilter}
            allLabel="(Todas)"
            options={officeOptions.map((code) => ({ code, label: code, value: code }))}
          />
        </Field>
        <Field label="Almacén" className="w-32">
          <CodeDescSelector
            value={warehouseFilter}
            onChange={setWarehouseFilter}
            allLabel="(Todos)"
            width="w-[280px]"
            extraHeader="CodAlm"
            options={warehouseOptions.map((warehouse) => ({
              code: warehouse,
              label: warehouse,
              value: warehouse,
              extra: warehouseCodAlm[warehouse],
            }))}
          />
        </Field>
        <Field label="Cliente" className="w-52">
          <div className="flex gap-1">
            <input
              className={inp}
              value={clientFilterLabel}
              placeholder="(Todos)"
              readOnly
            />
            <button
              className={btn}
              title="Buscar cliente"
              type="button"
              onClick={() => setShowClientLookup(true)}
            >
              <Search className="h-3 w-3" />
            </button>
          </div>
        </Field>
        <Field label="Estado" className="w-28">
          <CodeDescSelector
            value={estado}
            onChange={setEstado}
            allLabel="(Todos)"
            options={ESTADO_FILTER_OPTIONS}
          />
        </Field>
        <Field label="N° Doc" className="w-20">
          <input className={`${inp} font-mono`} value={numDoc} onChange={e => setNumDoc(e.target.value)} />
        </Field>
        <button className={btnPrimary} onClick={load} disabled={loading}>
          <Search className="h-3.5 w-3.5" />{loading ? "Buscando…" : "Buscar"}
        </button>
      </div>

      {/* Grid */}
      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full text-[11.5px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
              <tr>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'num_doc' ? { col: 'num_doc', asc: !prev.asc } : { col: 'num_doc', asc: true })}>Número {sortBy?.col === 'num_doc' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'fec_doc' ? { col: 'fec_doc', asc: !prev.asc } : { col: 'fec_doc', asc: true })}>Fecha {sortBy?.col === 'fec_doc' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'reference' ? { col: 'reference', asc: !prev.asc } : { col: 'reference', asc: true })}>Referencia {sortBy?.col === 'reference' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'cliente' ? { col: 'cliente', asc: !prev.asc } : { col: 'cliente', asc: true })}>Cliente {sortBy?.col === 'cliente' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'cod_mon' ? { col: 'cod_mon', asc: !prev.asc } : { col: 'cod_mon', asc: true })}>Mon. {sortBy?.col === 'cod_mon' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'tot_venta' ? { col: 'tot_venta', asc: !prev.asc } : { col: 'tot_venta', asc: false })}>Total {sortBy?.col === 'tot_venta' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'estado' ? { col: 'estado', asc: !prev.asc } : { col: 'estado', asc: true })}>EST {sortBy?.col === 'estado' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'estado_sunat' ? { col: 'estado_sunat', asc: !prev.asc } : { col: 'estado_sunat', asc: true })}>Estados Sunat {sortBy?.col === 'estado_sunat' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'observacion' ? { col: 'observacion', asc: !prev.asc } : { col: 'observacion', asc: true })}>Nota {sortBy?.col === 'observacion' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'id_cotizacion' ? { col: 'id_cotizacion', asc: !prev.asc } : { col: 'id_cotizacion', asc: true })}>Cotiz. {sortBy?.col === 'id_cotizacion' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'num_orden' ? { col: 'num_orden', asc: !prev.asc } : { col: 'num_orden', asc: true })}>Orden de Compra {sortBy?.col === 'num_orden' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'tot_neto_sug' ? { col: 'tot_neto_sug', asc: !prev.asc } : { col: 'tot_neto_sug', asc: false })}>TotNetoSug {sortBy?.col === 'tot_neto_sug' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'cod_serie' ? { col: 'cod_serie', asc: !prev.asc } : { col: 'cod_serie', asc: true })}>CodSerie {sortBy?.col === 'cod_serie' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
              </tr>
            </thead>
            <tbody>
              {rows.length === 0 ? (
                <tr>
                  <td colSpan={14} className="text-center py-8 text-slate-400 text-[11px]">
                    {loading ? "Cargando…" : searched ? "Sin registros para los filtros seleccionados" : "Use los filtros y pulse Buscar"}
                  </td>
                </tr>
              ) : rowsView.map((r, i) => {
                const isSel = selected?.id === r.id;
                const customerName = r.cliente_nombre ?? clientById[r.id_cliente]?.name ?? `Cliente #${r.id_cliente}`;
                const reference = getReferenceValue(r) === "" ? "-" : getReferenceValue(r);
                const estadoSunat = r.estado_sunat ?? (r.estado === "ANULADO" ? "BAJA" : r.estado === "APROBADO" ? "ACEPTADO" : "PENDIENTE");
                const estadoText = r.estado === "GENERADO" && !isSel ? "" : r.estado;
                const codSerie = r.cod_serie ?? (r.id_serie_doc !== undefined ? String(r.id_serie_doc) : "-");
                const cotizacion = resolveCotizacion(r);
                return (
                  <tr
                    key={r.id}
                    onClick={() => setSelected(r)}
                    onDoubleClick={() => handleMostrar(r)}
                    className={[
                      "cursor-pointer border-b border-slate-200",
                      i % 2 ? "bg-[#F6F9FC]" : "bg-white",
                      isSel ? "!bg-[#D6E4F4] outline outline-1 outline-[#3E5B7A]" : "hover:bg-[#E8F0F8]/60",
                    ].join(" ")}
                  >
                    <td className="px-2 py-1 text-center border-r border-slate-200 font-mono font-semibold">{r.num_doc}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200 whitespace-nowrap">{r.fec_doc ? new Date(r.fec_doc).toLocaleDateString("es-PE") : ""}</td>
                    <td className="px-2 py-1 border-r border-slate-200 max-w-[140px] truncate">{reference}</td>
                    <td className="px-2 py-1 border-r border-slate-200 max-w-[180px] truncate">{customerName}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">{r.cod_mon || "-"}</td>
                    <td className="px-2 py-1 text-right border-r border-slate-200 font-mono">{r.tot_venta.toFixed(2)}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200 font-mono">{estadoText}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">{estadoSunat}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">
                      <input
                        type="checkbox"
                        checked={Boolean(r.tiene_notas ?? (r.observacion && String(r.observacion).trim()))}
                        readOnly
                        className="h-3.5 w-3.5 accent-blue-700 cursor-default pointer-events-none rounded-sm border border-slate-400 bg-white"
                        title={r.tiene_notas ? "Tiene nota" : "Sin nota"}
                      />
                    </td>
                    <td className="px-2 py-1 text-center border-r border-slate-200 font-mono">{cotizacion}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">{r.num_orden ?? "-"}</td>
                    <td className="px-2 py-1 text-right border-r border-slate-200 font-mono font-bold text-blue-800">{(r.tot_neto_sug ?? r.tot_neto).toFixed(2)}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">{codSerie}</td>
                    <td className="px-1 py-1 text-center w-8">
                      <button
                        className={`${iconBtn} h-5 w-5`}
                        title="Abrir edición compacta"
                        onClick={e => { e.stopPropagation(); handleMostrar(r, true); }}
                      >
                        <ChevronRight className="h-3 w-3" />
                      </button>
                    </td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      </div>

      {/* Footer */}
      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-[11px] text-slate-700 text-center font-medium flex items-center justify-center whitespace-nowrap overflow-hidden">
        Registros : {rows.length}
      </div>

      {/* Ventanas Flotantes de Herramientas */}
      {toolWindows.map((w) => (
        <DraggableToolWindow
          key={w.id}
          win={w}
          onFocus={() => focusToolWindow(w.id)}
          onMove={moveToolWindow}
          onClose={() => closeToolWindow(w.id)}
        >
          {w.kind === "electronica" && <ToolGenerarElectronicaBody onClose={() => closeToolWindow(w.id)} />}
          {w.kind === "xcliente" && <ToolGuiaClienteBody selected={selected} />}
          {w.kind === "factor" && <ToolSugerirFactorBody onClose={() => closeToolWindow(w.id)} />}
          {w.kind === "estados" && <ToolEstadosBody selected={selected} />}
          {w.kind === "obsSunat" && <ToolObsSunatBody selected={selected} />}
          {w.kind === "precios" && <ToolPreciosSugeridosBody />}
          {w.kind === "imprimirGuia" && <ToolPlaceholderBody title="Imprimir Guía" description="Seleccione el formato y genere la impresión de la guía." actionLabel="Imprimir" onClose={() => closeToolWindow(w.id)} />}
          {w.kind === "actualizarCDR" && <ToolPlaceholderBody title="Actualizar CDR" description="Consulta a SUNAT el CDR (Constancia de Recepción) más reciente de esta guía electrónica." actionLabel="Actualizar" onClose={() => closeToolWindow(w.id)} />}
          {w.kind === "actProceso" && <ToolPlaceholderBody title="Actualizar Guía Electrónica en Proceso" description="Revisa el estado de las guías que quedaron en proceso de envío a SUNAT." actionLabel="Actualizar" onClose={() => closeToolWindow(w.id)} />}
          {w.kind === "imprimirTicket" && <ToolPlaceholderBody title="Imprimir Ticket" description="Seleccione el tipo de ticket y genere la impresión." actionLabel="Imprimir" onClose={() => closeToolWindow(w.id)} />}
          {w.kind === "enviarCreditos" && <ToolPlaceholderBody title="Enviar a Créditos" description="Prepare la guía para ser enviada al módulo de créditos." actionLabel="Enviar" onClose={() => closeToolWindow(w.id)} />}
          {w.kind === "generarFactBoleta" && <ToolPlaceholderBody title="Generar Factura / Boleta" description="Configure la factura o boleta relacionada con esta guía." actionLabel="Generar" onClose={() => closeToolWindow(w.id)} />}
          {w.kind === "trasladarGuia" && (
            <ToolTransferirGuiaBody
              selected={selected}
              locations={locations}
              onClose={() => closeToolWindow(w.id)}
              onSaved={() => { closeToolWindow(w.id); load(); }}
            />
          )}
          {w.kind === "enviarB2Mining" && <ToolPlaceholderBody title="Enviar a B2Mining" description="Envíe esta guía al servicio B2Mining para procesamiento externo." actionLabel="Enviar" onClose={() => closeToolWindow(w.id)} />}
          {w.kind === "consumoOT" && (
            <ToolAgregarConsumoJobBody
              selected={selected}
              locationById={locationById}
              onClose={() => closeToolWindow(w.id)}
              onSaved={() => { closeToolWindow(w.id); load(); }}
            />
          )}
          {w.kind === "bajarNivel" && <ToolPlaceholderBody title="Bajar de Nivel" description="Ajuste el nivel de esta guía en la jerarquía del sistema." actionLabel="Bajar" onClose={() => closeToolWindow(w.id)} />}
          {w.kind === "enviarCorreo" && <ToolPlaceholderBody title="Enviar por Correo" description="Envía la guía por correo electrónico al cliente o al usuario responsable." actionLabel="Enviar" onClose={() => closeToolWindow(w.id)} />}
        </DraggableToolWindow>
      ))}

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

      {showPrintModal && (
        <PrintGuiaModal
          onClose={() => setShowPrintModal(false)}
          onPrint={({ detalle, mostrarPrecio }) => {
            toast.success(
              `Imprimiendo guía (${detalle ? "Detalle" : "Resumen"})${mostrarPrecio ? " — mostrando precios" : ""}`
            );
          }}
        />
      )}

      {motivoBajaRow && (
        <MotivoBajaModal
          row={motivoBajaRow}
          onClose={() => setMotivoBajaRow(null)}
          onConfirm={submitAnular}
        />
      )}

      {modificarObsRow && (
        <ModificarObservacionModal
          row={modificarObsRow}
          onClose={() => setModificarObsRow(null)}
          onSaved={() => { setModificarObsRow(null); load(); }}
        />
      )}

      {/* Ventanas Flotantes de Formularios de Guía */}
      {formWindows.map((w) => (
        <DraggableToolWindow
          key={w.id}
          win={{ id: w.id, kind: "xcliente", title: w.title, x: w.x, y: w.y, w: w.w, h: w.h, z: w.z }}
          onFocus={() => focusFormWindow(w.id)}
          onMove={moveFormWindow}
          onClose={() => closeFormWindow(w.id)}
        >
          <GuiaRemisionForm
            idGuia={w.idGuia}
            idLocacion={w.idLocacion ?? 1}
            onClose={() => closeFormWindow(w.id)}
            onSaved={() => {
              closeFormWindow(w.id);
              load();
            }}
          />
        </DraggableToolWindow>
      ))}
    </div>
  );
}

// Réplica de frmGuiaRemision_MotivoBaja.vb
function MotivoBajaModal({
  row,
  onClose,
  onConfirm,
}: {
  row: GuiaRemisionRow;
  onClose: () => void;
  onConfirm: (row: GuiaRemisionRow, observacion: string) => void;
}) {
  const [observacion, setObservacion] = useState("");

  const handleAnularClick = () => {
    if (!observacion.trim()) {
      toast.error("Debe ingresar la Observación");
      return;
    }
    if (!confirm(`¿Está seguro de ANULAR la Guía Nº ${row.num_doc} ?`)) return;
    onConfirm(row, observacion.trim());
  };

  return (
    <div className="fixed inset-0 z-[10000] flex items-center justify-center bg-black/35">
      <div className="w-[420px] bg-[#F1F3F8] border border-slate-500 shadow-2xl rounded-sm overflow-hidden">
        <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] text-white text-[12px]">
          <span className="font-medium">Anular la Guia de Remision N°: {row.num_doc}</span>
          <button onClick={onClose} className="hover:bg-white/20 rounded px-1"><X className="h-3.5 w-3.5" /></button>
        </div>
        <div className="p-4 text-[12px] text-slate-800 space-y-2">
          <span className="text-[11px] font-semibold text-slate-700">Observación :</span>
          <textarea
            className={`${inp} w-full h-20 resize-none`}
            value={observacion}
            onChange={(e) => setObservacion(e.target.value)}
            autoFocus
          />
          <div className="flex justify-end gap-2 pt-1">
            <button className={btn} onClick={onClose}><X className="h-3.5 w-3.5" />Salir</button>
            <button className={btnPrimary} onClick={handleAnularClick}><Check className="h-3.5 w-3.5" />Anular</button>
          </div>
        </div>
      </div>
    </div>
  );
}

// Réplica de frmGuiaRemision_ModificarObservacion.vb
function ModificarObservacionModal({
  row,
  onClose,
  onSaved,
}: {
  row: GuiaRemisionRow;
  onClose: () => void;
  onSaved: () => void;
}) {
  const [observacion, setObservacion] = useState(String((row as any).observacion ?? ""));
  const [saving, setSaving] = useState(false);
  // Estados que en VB habilitan btnGuardar: GENERADO, APROBADO, CREDITOS.
  const puedeGuardar = ["GENERADO", "APROBADO", "CREDITOS"].includes(row.estado);

  const handleGuardar = async () => {
    setSaving(true);
    try {
      // GuiaRemisionUpdate ya trae "observacion" (equivale a
      // oGuiaRemisionService.ActualizarObservacion(IdGuia, Observacion, Usuario) del VB).
      await updateGuiaRemision(row.id, { observacion });
      toast.success("Observación actualizada");
      onSaved();
    } catch (e: any) {
      toast.error(e.message ?? "Error al actualizar la observación");
    } finally {
      setSaving(false);
    }
  };

  return (
    <div className="fixed inset-0 z-[10000] flex items-center justify-center bg-black/35">
      <div className="w-[420px] bg-[#F1F3F8] border border-slate-500 shadow-2xl rounded-sm overflow-hidden">
        <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] text-white text-[12px]">
          <span className="font-medium">Modificar Observación — Guía N° {row.num_doc}</span>
          <button onClick={onClose} className="hover:bg-white/20 rounded px-1"><X className="h-3.5 w-3.5" /></button>
        </div>
        <div className="p-4 text-[12px] text-slate-800 space-y-2">
          <span className="text-[11px] font-semibold text-slate-700">Observación :</span>
          <textarea
            className={`${inp} w-full h-24 resize-none`}
            value={observacion}
            onChange={(e) => setObservacion(e.target.value)}
            disabled={!puedeGuardar}
            autoFocus
          />
          {!puedeGuardar && (
            <div className="text-[11px] text-amber-700">
              Esta guía está en estado {row.estado}; en SIGECOM solo se puede modificar la observación en GENERADO, APROBADO o CREDITOS.
            </div>
          )}
          <div className="flex justify-end gap-2 pt-1">
            <button className={btn} onClick={onClose}><X className="h-3.5 w-3.5" />Cancelar</button>
            <button className={btnPrimary} disabled={!puedeGuardar || saving} onClick={handleGuardar}>
              <Save className="h-3.5 w-3.5" />Guardar
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

// Fusión de frmGuiaRemision_Imprimir.vb (radio Detalle/Resumen) +
// frmGuiaRemision_ImprimirPrecio.vb (checkbox Mostrar Precio)
function PrintGuiaModal({
  onClose,
  onPrint,
}: {
  onClose: () => void;
  onPrint: (opts: { detalle: boolean; mostrarPrecio: boolean }) => void;
}) {
  const [detalle, setDetalle] = useState(true); // true = Generar Detalle, false = Generar Resumen
  const [mostrarPrecio, setMostrarPrecio] = useState(true);
  return (
    <div className="fixed inset-0 z-[10000] flex items-center justify-center bg-black/35">
      <div className="w-[320px] bg-[#F1F3F8] border border-slate-500 shadow-2xl rounded-sm overflow-hidden">
        <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] text-white text-[12px]">
          <span className="font-medium">Imprimir</span>
          <button onClick={onClose} className="hover:bg-white/20 rounded px-1"><X className="h-3.5 w-3.5" /></button>
        </div>
        <div className="p-4 text-[12px] text-slate-800">
          <div className="mb-2 text-[11px] font-semibold text-slate-700">Impresión</div>
          <div className="space-y-1 mb-3">
            <label className="flex items-center gap-2">
              <input type="radio" checked={detalle} onChange={() => setDetalle(true)} />
              <span className="text-[12px]">Generar Detalle</span>
            </label>
            <label className="flex items-center gap-2">
              <input type="radio" checked={!detalle} onChange={() => setDetalle(false)} />
              <span className="text-[12px]">Generar Resumen</span>
            </label>
          </div>
          <label className="flex items-center gap-2 mb-4">
            <input type="checkbox" checked={mostrarPrecio} onChange={(e) => setMostrarPrecio(e.target.checked)} />
            <span className="text-[12px]">Mostrar Precio</span>
          </label>
          <div className="flex justify-end gap-2">
            <button className={btn} onClick={onClose}><X className="h-3.5 w-3.5" /> Cancelar</button>
            <button className={btnPrimary} onClick={() => { onPrint({ detalle, mostrarPrecio }); onClose(); }}><Check className="h-3.5 w-3.5" /> Aceptar</button>
          </div>
        </div>
      </div>
    </div>
  );
}