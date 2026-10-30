import { useCallback, useEffect, useMemo, useRef, useState } from "react";
import { createPortal } from "react-dom";
import { ChevronDown, ChevronUp } from "lucide-react";
import { inp } from "@/features/escritorio/windows/uiStyles";

export type CodeDescOption = {
  code: string;
  label: string;
  value: string;
  extra?: string;
};

export const GUIA_MESES = [
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

export function CodeDescSelector({
  value,
  onChange,
  options,
  allLabel = "Todos",
  width = "w-[220px]",
  extraHeader,
  disabled = false,
}: {
  value: string;
  onChange: (next: string) => void;
  options: CodeDescOption[];
  allLabel?: string;
  width?: string;
  extraHeader?: string;
  disabled?: boolean;
}) {
  const gridCols = extraHeader ? "grid-cols-[46px_1fr_64px]" : "grid-cols-[58px_1fr]";
  const [open, setOpen] = useState(false);
  const [sortMode, setSortMode] = useState<"code" | "label">("code");
  const [sortDirection, setSortDirection] = useState<"asc" | "desc">("asc");
  const ref = useRef<HTMLDivElement | null>(null);
  const panelRef = useRef<HTMLDivElement | null>(null);
  const [panelPos, setPanelPos] = useState({ top: 0, left: 0 });

  const updatePanelPos = useCallback(() => {
    const element = ref.current;
    if (!element) return;
    const rect = element.getBoundingClientRect();
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
      if (ref.current?.contains(target) || panelRef.current?.contains(target)) return;
      setOpen(false);
    };
    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, []);

  const selected = options.find((option) => option.value === value);
  const selectedLabel = value ? selected?.label ?? value : allLabel;
  const sortedOptions = useMemo(() => {
    return [...options].sort((a, b) => {
      const diff = sortMode === "code"
        ? a.code.localeCompare(b.code, "es")
        : a.label.localeCompare(b.label, "es");
      return sortDirection === "asc" ? diff : -diff;
    });
  }, [options, sortMode, sortDirection]);

  const toggleSort = (mode: "code" | "label") => {
    if (sortMode === mode) {
      setSortDirection((previous) => previous === "asc" ? "desc" : "asc");
      return;
    }
    setSortMode(mode);
    setSortDirection("asc");
  };

  return (
    <div ref={ref} className="relative w-full">
      <button
        type="button"
        disabled={disabled}
        className={`${inp} flex w-full items-center justify-between gap-2 px-2 text-left disabled:cursor-not-allowed disabled:bg-slate-100 disabled:text-slate-500`}
        onClick={() => setOpen((previous) => !previous)}
      >
        <span className="truncate text-[11px] text-slate-700">{selectedLabel}</span>
        <ChevronDown className="h-3.5 w-3.5 text-slate-500" />
      </button>

      {open && !disabled && createPortal(
        <div
          ref={panelRef}
          style={{ position: "fixed", top: panelPos.top, left: panelPos.left }}
          className={`z-[10050] ${width} overflow-hidden rounded-sm border border-slate-300 bg-white shadow-2xl`}
        >
          <div className="max-h-64 overflow-auto">
            <div className={`grid ${gridCols} items-center border-b border-slate-200 bg-slate-100 px-2 py-1 text-[10px] font-semibold uppercase tracking-wide text-slate-600`}>
              <button
                type="button"
                onClick={() => toggleSort("code")}
                className="flex items-center justify-center gap-1 rounded-sm px-1 text-center transition-colors duration-150 hover:bg-slate-200/80 focus:outline-none"
              >
                <span>Código</span>
                {sortMode === "code" && <span className="text-[9px]">{sortDirection === "asc" ? "▲" : "▼"}</span>}
              </button>
              <button
                type="button"
                onClick={() => toggleSort("label")}
                className="flex items-center justify-center gap-1 rounded-sm border-l border-slate-300 px-1 pl-2 text-center transition-colors duration-150 hover:bg-slate-200/80 focus:outline-none"
              >
                <span>Descripción</span>
                {sortMode === "label" && <span className="text-[9px]">{sortDirection === "asc" ? "▲" : "▼"}</span>}
              </button>
              {extraHeader && <span className="border-l border-slate-300 pl-2 text-center">{extraHeader}</span>}
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
            {sortedOptions.map((option) => {
              const active = value === option.value;
              return (
                <button
                  key={option.value}
                  type="button"
                  className={`grid w-full ${gridCols} items-center border-b border-slate-200 px-2 py-1 text-[11px] transition-colors duration-150 ${active ? "bg-[#EAF2FF] font-semibold text-[#1F3E68]" : "text-slate-700 hover:bg-slate-200/80"}`}
                  onClick={() => { onChange(option.value); setOpen(false); }}
                >
                  <span className="text-center font-mono text-slate-600">{option.code}</span>
                  <span className="border-l border-slate-300 pl-2 text-center">{option.label}</span>
                  {extraHeader && <span className="border-l border-slate-300 pl-2 text-center font-mono text-slate-600">{option.extra ?? "-"}</span>}
                </button>
              );
            })}
          </div>
        </div>,
        document.body,
      )}
    </div>
  );
}

export function MonthSelector({ value, onChange }: { value: string; onChange: (next: string) => void }) {
  const options = useMemo<CodeDescOption[]>(
    () => GUIA_MESES.map((month, index) => ({
      code: String(index + 1).padStart(2, "0"),
      label: month,
      value: String(index + 1),
    })),
    [],
  );
  return <CodeDescSelector value={value} onChange={onChange} options={options} allLabel="Todos" width="w-[220px]" />;
}

export function YearSpinner({ value, onChange }: { value: string; onChange: (next: string) => void }) {
  const currentYear = Number(value || new Date().getFullYear());
  const stepYear = (delta: number) => onChange(String(Math.max(2000, currentYear + delta)));

  return (
    <div className="flex h-7 w-[82px] items-stretch overflow-hidden rounded border border-slate-300 bg-white shadow-xs">
      <input
        type="number"
        min={2000}
        value={value}
        onChange={(event) => {
          const next = event.target.value;
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
