import { createPortal } from "react-dom";
import { useEffect, useRef, type ReactNode } from "react";
import { ChevronDown, ChevronUp, Search, X } from "lucide-react";
import { useState, useMemo } from "react";
import { inp, btn, btnPrimary } from "@/features/escritorio/windows/uiStyles";
import { fetchSigecoomLocations } from "@/lib/sigecoom-api";

export const ESTADO_COLORS: Record<string, string> = {
  GENERADO: "text-blue-700 bg-blue-50 border-blue-200",
  APROBADO: "text-green-700 bg-green-50 border-green-200",
  CREDITOS: "text-amber-700 bg-amber-50 border-amber-200",
  ANULADO: "text-red-700 bg-red-50 border-red-200",
};

export function Field({ label, className = "", children }: { label: string; className?: string; children: ReactNode }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium leading-tight">{label}</span>
      {children}
    </label>
  );
}

export function InlineField({
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
    <div className={`flex items-center gap-1 ${className} hover:bg-slate-50 hover:rounded-sm`}>
      <span className={`${labelWidth} shrink-0 text-right text-[11px] font-semibold text-slate-800 leading-tight`}>{label} :</span>
      <div className="min-w-0 flex-1 flex items-center">{children}</div>
    </div>
  );
}

export function EstadoBadge({ estado }: { estado: string }) {
  const cls = ESTADO_COLORS[estado] ?? "text-slate-600 bg-slate-50 border-slate-200";
  return <span className={`inline-block px-1.5 py-0 text-[10px] font-bold rounded border ${cls}`}>{estado}</span>;
}

export function YearSpinner({ value, onChange }: { value: string; onChange: (next: string) => void }) {
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

export type CodeDescOption = { code: string; label: string; value: string; extra?: string };

export function CodeDescSelector({
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
  extraHeader?: string;
}) {
  const gridCols = extraHeader ? "grid-cols-[46px_1fr_64px]" : "grid-cols-[58px_1fr]";
  const [open, setOpen] = useState(false);
  const [sortMode, setSortMode] = useState<"code" | "label">("code");
  const [sortDirection, setSortDirection] = useState<"asc" | "desc">("asc");
  const ref = useRef<HTMLDivElement | null>(null);
  const panelRef = useRef<HTMLDivElement | null>(null);
  const [panelPos, setPanelPos] = useState({ top: 0, left: 0 });

  const updatePanelPos = () => {
    const el = ref.current;
    if (!el) return;
    const rect = el.getBoundingClientRect();
    setPanelPos({ top: rect.bottom + 2, left: rect.left });
  };

  useEffect(() => {
    if (!open) return;
    updatePanelPos();
    window.addEventListener("scroll", updatePanelPos, true);
    window.addEventListener("resize", updatePanelPos);
    return () => {
      window.removeEventListener("scroll", updatePanelPos, true);
      window.removeEventListener("resize", updatePanelPos);
    };
  }, [open]);

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
      const diff = sortMode === "code" ? a.code.localeCompare(b.code, "es") : a.label.localeCompare(b.label, "es");
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
              <button type="button" onClick={() => handleSortToggle("code")} className="flex items-center justify-center gap-1 text-center transition-colors duration-150 hover:bg-slate-200/80 rounded-sm px-1 focus:outline-none">
                <span>Código</span>
                {sortMode === "code" && <span className="text-[9px]">{sortDirection === "asc" ? "▲" : "▼"}</span>}
              </button>
              <button type="button" onClick={() => handleSortToggle("label")} className="flex items-center justify-center gap-1 border-l border-slate-300 pl-2 text-center transition-colors duration-150 hover:bg-slate-200/80 rounded-sm px-1 focus:outline-none">
                <span>Descripción</span>
                {sortMode === "label" && <span className="text-[9px]">{sortDirection === "asc" ? "▲" : "▼"}</span>}
              </button>
              {extraHeader && <span className="border-l border-slate-300 pl-2 text-center">{extraHeader}</span>}
            </div>
            <button type="button" className={`grid w-full ${gridCols} items-center border-b border-slate-200 px-2 py-1 text-[11px] text-slate-700 transition-colors duration-150 hover:bg-slate-200/80`} onClick={() => { onChange(""); setOpen(false); }}>
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
                  {extraHeader && <span className="border-l border-slate-300 pl-2 text-center font-mono text-slate-600">{row.extra ?? "-"}</span>}
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

export function MonthSelector({ value, onChange }: { value: string; onChange: (next: string) => void }) {
  const MESES = ["ENERO","FEBRERO","MARZO","ABRIL","MAYO","JUNIO","JULIO","AGOSTO","SETIEMBRE","OCTUBRE","NOVIEMBRE","DICIEMBRE"];
  const options = useMemo<CodeDescOption[]>(() => MESES.map((month, index) => ({ code: String(index + 1).padStart(2, "0"), label: month, value: String(index + 1) })), []);
  return <CodeDescSelector value={value} onChange={onChange} options={options} allLabel="Todos" width="w-[220px]" />;
}

export function YearMonthFields({
  anio,
  setAnio,
  mes,
  setMes,
  className = "",
}: {
  anio: string;
  setAnio: (next: string) => void;
  mes: string;
  setMes: (next: string) => void;
  className?: string;
}) {
  return (
    <div className={`flex flex-wrap items-end gap-2 ${className}`}>
      <Field label="Año" className="w-[84px]">
        <YearSpinner value={anio} onChange={setAnio} />
      </Field>
      <Field label="Mes" className="w-32">
        <MonthSelector value={mes} onChange={setMes} />
      </Field>
    </div>
  );
}

export const ESTADO_FILTER_OPTIONS: CodeDescOption[] = [
  { code: "GN", label: "GENERADO", value: "GENERADO" },
  { code: "AP", label: "APROBADO", value: "APROBADO" },
  { code: "CR", label: "CREDITOS", value: "CREDITOS" },
  { code: "AN", label: "ANULADO", value: "ANULADO" },
  { code: "FC", label: "FACTURADO", value: "FACTURADO" },
  { code: "TR", label: "TRANSFERIDO", value: "TRANSFERIDO" },
];

export function FiltersPanel({
  anio: anioProp,
  setAnio: setAnioProp,
  mes: mesProp,
  setMes: setMesProp,
  officeFilter: officeFilterProp,
  setOfficeFilter: setOfficeFilterProp,
  officeOptions = [],
  warehouseFilter: warehouseFilterProp,
  setWarehouseFilter: setWarehouseFilterProp,
  warehouseOptions = [],
  warehouseCodAlm = {},
  clientFilterLabel: clientFilterLabelProp,
  onShowClientLookup,
  estado: estadoProp,
  setEstado: setEstadoProp,
  estadoOptions = ESTADO_FILTER_OPTIONS,
  numDoc: numDocProp,
  setNumDoc: setNumDocProp,
  onSearch,
  loading = false,
}: {
  anio?: string; setAnio?: (s: string) => void;
  mes?: string; setMes?: (s: string) => void;
  officeFilter?: string; setOfficeFilter?: (s: string) => void; officeOptions?: string[];
  warehouseFilter?: string; setWarehouseFilter?: (s: string) => void; warehouseOptions?: string[]; warehouseCodAlm?: Record<string,string>;
  clientFilterLabel?: string; onShowClientLookup?: () => void;
  estado?: string; setEstado?: (s: string) => void; estadoOptions?: CodeDescOption[];
  numDoc?: string; setNumDoc?: (s: string) => void;
  onSearch?: () => void; loading?: boolean;
}) {
  const [anio, setAnio] = useState(anioProp ?? String(new Date().getFullYear()));
  const [mes, setMes] = useState(mesProp ?? String(new Date().getMonth() + 1));
  const [officeFilter, setOfficeFilter] = useState(officeFilterProp ?? "");
  const [warehouseFilter, setWarehouseFilter] = useState(warehouseFilterProp ?? "");
  const [clientFilterLabel, setClientFilterLabel] = useState(clientFilterLabelProp ?? "(Todos)");
  const [estado, setEstado] = useState(estadoProp ?? "");
  const [numDoc, setNumDoc] = useState(numDocProp ?? "");

  useEffect(() => { if (anioProp !== undefined && setAnioProp) setAnioProp(anioProp); }, [anioProp, setAnioProp]);
  useEffect(() => { if (mesProp !== undefined && setMesProp) setMesProp(mesProp); }, [mesProp, setMesProp]);

  useEffect(() => { if (officeFilterProp !== undefined && setOfficeFilterProp) setOfficeFilterProp(officeFilterProp); }, [officeFilterProp, setOfficeFilterProp]);
  useEffect(() => { if (warehouseFilterProp !== undefined && setWarehouseFilterProp) setWarehouseFilterProp(warehouseFilterProp); }, [warehouseFilterProp, setWarehouseFilterProp]);
  useEffect(() => { if (clientFilterLabelProp !== undefined) setClientFilterLabel(clientFilterLabelProp); }, [clientFilterLabelProp]);
  useEffect(() => { if (estadoProp !== undefined && setEstadoProp) setEstadoProp(estadoProp); }, [estadoProp, setEstadoProp]);
  useEffect(() => { if (numDocProp !== undefined && setNumDocProp) setNumDocProp(numDocProp); }, [numDocProp, setNumDocProp]);

  // If consumer didn't provide office/warehouse options, try fetching locations once
  const [fetchedOfficeOptions, setFetchedOfficeOptions] = useState<string[] | null>(null);
  useEffect(() => {
    if ((officeOptions && officeOptions.length > 0) || fetchedOfficeOptions !== null) return;
    let mounted = true;
    fetchSigecoomLocations()
      .then((locs) => {
        if (!mounted) return;
        const offices = Array.from(new Set(locs.map((l:any) => l.code))).filter(Boolean);
        setFetchedOfficeOptions(offices);
      })
      .catch(() => setFetchedOfficeOptions([]));
    return () => { mounted = false; };
  }, [officeOptions, fetchedOfficeOptions]);

  const effectiveOfficeOptions = officeOptions.length ? officeOptions : (fetchedOfficeOptions ?? []);

  return (
    <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
      <YearMonthFields
        anio={anio}
        setAnio={(v) => { setAnio(v); if (setAnioProp) setAnioProp(v); }}
        mes={mes}
        setMes={(v) => { setMes(v); if (setMesProp) setMesProp(v); }}
      />
      <Field label="Oficina" className="w-28">
        <CodeDescSelector value={officeFilter} onChange={(v) => { setOfficeFilter(v); if (setOfficeFilterProp) setOfficeFilterProp(v); }} allLabel="(Todas)" options={effectiveOfficeOptions.map((code) => ({ code, label: code, value: code }))} />
      </Field>
      <Field label="Almacén" className="w-32">
        <CodeDescSelector value={warehouseFilter} onChange={(v) => { setWarehouseFilter(v); if (setWarehouseFilterProp) setWarehouseFilterProp(v); }} allLabel="(Todos)" width="w-[280px]" extraHeader="CodAlm" options={(warehouseOptions || []).map((warehouse) => ({ code: warehouse, label: warehouse, value: warehouse, extra: warehouseCodAlm[warehouse] }))} />
      </Field>
      <Field label="Cliente" className="w-52">
        <div className="flex gap-1">
          <input className={inp} value={clientFilterLabel} placeholder="(Todos)" readOnly />
          <button className={btn} title="Buscar cliente" type="button" onClick={() => { if (onShowClientLookup) onShowClientLookup(); }}><SearchIconMock /></button>
        </div>
      </Field>
      <Field label="Estado" className="w-28">
        <CodeDescSelector value={estado} onChange={(v) => { setEstado(v); if (setEstadoProp) setEstadoProp(v); }} allLabel="(Todos)" options={estadoOptions} />
      </Field>
      <Field label="N° Doc" className="w-20">
        <input className={`${inp} font-mono`} value={numDoc} onChange={(e) => { setNumDoc(e.target.value); if (setNumDocProp) setNumDocProp(e.target.value); }} />
      </Field>
      <button className={btnPrimary} onClick={() => onSearch && onSearch()} disabled={loading}><SearchIconMock />{loading ? "Buscando…" : "Buscar"}</button>
    </div>
  );
}

function SearchIconMock() {
  return <Search className="h-3.5 w-3.5" />;
}

export type BoletaFormWindow = {
  id: string;
  title: string;
  x: number;
  y: number;
  w: number;
  h: number;
  z: number;
};

export function DraggableFormWindow({
  win,
  onFocus,
  onMove,
  onClose,
  children,
}: {
  win: BoletaFormWindow;
  onFocus: () => void;
  onMove: (id: string, x: number, y: number) => void;
  onClose: () => void;
  children: ReactNode;
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
