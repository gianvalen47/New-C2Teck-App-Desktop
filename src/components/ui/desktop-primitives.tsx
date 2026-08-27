import {
  useState,
  useEffect,
  useRef,
  Children,
  isValidElement,
  type ReactNode,
} from "react";
import { createPortal } from "react-dom";
import { Search } from "lucide-react";

// ---------- Estilos base para Inputs y Botones ERP ----------
export const inp = "h-7 px-2 text-[12px] bg-white border border-slate-400/70 rounded-sm outline-none focus:border-[#3E5B7A] focus:ring-1 focus:ring-[#3E5B7A]/30";
export const btn = "inline-flex items-center gap-1 h-7 px-2.5 text-[11.5px] rounded-sm border border-slate-400/70 bg-gradient-to-b from-[#F6F9FC] to-[#DDE4EC] hover:from-[#EEF2F7] hover:to-[#C9D3DF] text-slate-800";
export const btnPrimary = "inline-flex items-center gap-1 h-7 px-3 text-[11.5px] rounded-sm border border-[#2A3F55] bg-gradient-to-b from-[#4C6E93] to-[#2A3F55] hover:from-[#5A80A9] text-white font-medium";
export const iconBtn = "inline-flex items-center justify-center h-[24px] w-[26px] rounded-none border border-transparent hover:border-[#7A96B4] hover:bg-gradient-to-b hover:from-[#FDFEFF] hover:to-[#B6C9DE] active:from-[#B6C9DE] active:to-[#EAF0F7] text-slate-700";
export const tbSep = <span className="mx-0.5 h-4 w-px bg-[#7A96B4]/60 inline-block" />;

// ---------- Reusable primitives ----------
export function Field({ label, children, className = "" }: { label: string; children: ReactNode; className?: string }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium">{label}</span>
      {children}
    </label>
  );
}

export function Toolbar({ children }: { children: ReactNode }) {
  return (
    <div className="flex items-center gap-1.5 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
      {children}
    </div>
  );
}

export function SearchBar({ children }: { children: ReactNode }) {
  return (
    <fieldset className="border border-[#7A96B4] px-2 pb-1.5 pt-0 mx-1.5 mt-1.5 bg-[#ECF1F7]">
      <legend className="px-1 text-[10.5px] font-bold text-slate-700">Datos de Búsqueda</legend>
      <div className="flex items-end flex-wrap gap-x-2 gap-y-1">{children}</div>
    </fieldset>
  );
}

export function SearchBar2({ children }: { children: ReactNode }) {
  return (
    <fieldset className="border border-[#7A96B4] px-2 pb-1.5 pt-0 mx-1.5 mt-1.5 bg-[#ECF1F7]">
      <legend className="px-1 text-[10.5px] font-bold text-slate-700">Datos de Búsqueda</legend>
      <div className="flex items-end flex-wrap gap-x-2 gap-y-1">{children}</div>
    </fieldset>
  );
}

export function SearchBar3({ children }: { children: ReactNode }) {
  return (
    <fieldset className="border border-[#7A96B4] px-2 pb-1.5 pt-0 mx-1.5 mt-1.5 bg-[#ECF1F7]">
      <legend className="px-1 text-[10.5px] font-bold text-slate-700">Datos de Búsqueda</legend>
      <div className="flex items-end flex-wrap gap-x-2 gap-y-1">{children}</div>
    </fieldset>
  );
}

export function SearchBar4({ children }: { children: ReactNode }) {
  return (
    <fieldset className="border border-[#7A96B4] px-2 pb-1.5 pt-0 mx-1.5 mt-1.5 bg-[#ECF1F7]">
      <legend className="px-1 text-[10.5px] font-bold text-slate-700">Datos de Búsqueda</legend>
      <div className="flex items-end flex-wrap gap-x-2 gap-y-1">{children}</div>
    </fieldset>
  );
}

export function SearchBar5({ children }: { children: ReactNode }) {
  return (
    <fieldset className="border border-[#7A96B4] px-2 pb-1.5 pt-0 mx-1.5 mt-1.5 bg-[#ECF1F7]">
      <legend className="px-1 text-[10.5px] font-bold text-slate-700">Datos de Búsqueda</legend>
      <div className="flex items-end flex-wrap gap-x-2 gap-y-1">{children}</div>
    </fieldset>
  );
}

export function SearchBar6({ children }: { children: ReactNode }) {
  return (
    <fieldset className="border border-[#7A96B4] px-2 pb-1.5 pt-0 mx-1.5 mt-1.5 bg-[#ECF1F7]">
      <legend className="px-1 text-[10.5px] font-bold text-slate-700">Datos de Búsqueda</legend>
      <div className="flex items-end flex-wrap gap-x-2 gap-y-1">{children}</div>
    </fieldset>
  );
}

export function Fs({ legend, children }: { legend: string; children: ReactNode }) {
  return (
    <fieldset className="border border-[#7A96B4] px-2 pb-2 pt-1 bg-[#ECF1F7] rounded-sm">
      <legend className="px-1 text-[10.5px] font-bold text-slate-700">{legend}</legend>
      <div className="mt-2 space-y-2">{children}</div>
    </fieldset>
  );
}

export function Radio({ name, label, defaultChecked }: { name: string; label: string; defaultChecked?: boolean }) {
  return (
    <label className="inline-flex items-center gap-1 text-[11.5px] text-slate-800">
      <input type="radio" name={name} defaultChecked={defaultChecked} className="accent-[#2A5590]" />
      {label}
    </label>
  );
}

// ---------- Tablas y Resúmenes ----------
export function DataTable({ columns, rows = 0, className = "" }: { columns: string[]; rows?: number; className?: string }) {
  const [sortBy, setSortBy] = useState<{ col: string; asc: boolean } | null>(null);
  const visibleRows = rows === 0 ? 100 : rows;

  return (
    <div className={`border border-slate-400/60 bg-white rounded-sm ${className || "overflow-y-auto max-h-[600px]"}`}>
      <table className="w-full text-[11.5px]">
        <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0">
          <tr>
            {columns.map((c) => (
              <th
                key={c}
                className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold cursor-pointer hover:bg-[#E6EEF9]"
                onClick={() => setSortBy((prev) => (prev?.col === c ? { col: c, asc: !prev.asc } : { col: c, asc: true }))}
              >
                {c} {sortBy?.col === c ? (sortBy.asc ? "▲" : "▼") : ""}
              </th>
            ))}
          </tr>
        </thead>
        <tbody>
          {Array.from({ length: visibleRows }).map((_, i) => (
            <tr key={i} className={i % 2 ? "bg-[#F6F9FC]" : "bg-white"}>
              {columns.map((c) => (
                <td key={c} className="px-2 py-1 text-center border-b border-r border-slate-200 text-slate-700">&nbsp;</td>
              ))}
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

type CalculationSummaryValues = {
  subtotal?: number;
  discount?: number;
  igv?: number;
  total?: number;
};

export function CalculationSummaryBlock({
  values,
  className = "",
}: {
  values?: CalculationSummaryValues;
  className?: string;
}) {
  const subtotal = values?.subtotal ?? 0;
  const discount = values?.discount ?? 0;
  const igv = values?.igv ?? 0;
  const total = values?.total ?? subtotal - discount + igv;

  return (
    <div className={`grid grid-cols-[1fr_120px] gap-x-2 gap-y-1 border border-slate-300 bg-[#F7FAFE] px-2 py-1.5 ${className}`}>
      <div className="text-right text-[11px] text-slate-700">Subtotal:</div>
      <div className="text-right text-[11px] font-mono text-slate-900">{subtotal.toFixed(2)}</div>
      <div className="text-right text-[11px] text-slate-700">Descuento:</div>
      <div className="text-right text-[11px] font-mono text-slate-900">{discount.toFixed(2)}</div>
      <div className="text-right text-[11px] text-slate-700">IGV:</div>
      <div className="text-right text-[11px] font-mono text-slate-900">{igv.toFixed(2)}</div>
      <div className="text-right text-[11px] font-semibold text-slate-800">Total:</div>
      <div className="text-right text-[11px] font-mono font-semibold text-slate-900">{total.toFixed(2)}</div>
    </div>
  );
}

// ---------- Contenedor de Ventana (WindowShell) y Menú Contextual ----------
type ToolbarMenuItem = {
  key: string;
  label?: string;
  icon?: ReactNode;
  onClick?: () => void;
  disabled?: boolean;
  separator?: boolean;
};

export function extractToolbarMenuItems(toolbar: ReactNode): ToolbarMenuItem[] {
  const items: ToolbarMenuItem[] = [];
  let keyIndex = 0;

  const addSeparator = () => {
    const last = items[items.length - 1];
    if (!last || last.separator) return;
    items.push({ key: `sep-${keyIndex++}`, separator: true });
  };

  const walk = (node: ReactNode) => {
    Children.forEach(node, (child) => {
      if (!isValidElement(child)) return;

      const props = child.props as any;
      const tag = typeof child.type === "string" ? child.type : "";
      const className = typeof props?.className === "string" ? props.className : "";

      const isSeparator =
        tag === "span" &&
        (className.includes("w-px") || className.includes("h-4") || className.includes("bg-[#7A96B4]/60"));

      if (isSeparator) {
        addSeparator();
        return;
      }

      if (tag === "button") {
        const parts = Children.toArray(props.children);
        const icon = parts.find((part) => isValidElement(part));
        const textNode = parts.find((part) => typeof part === "string");
        const label =
          (typeof props.title === "string" && props.title.trim()) ||
          (typeof props["aria-label"] === "string" && props["aria-label"].trim()) ||
          (typeof textNode === "string" && textNode.trim()) ||
          "Acción";

        const rawOnClick = typeof props.onClick === "function" ? props.onClick : undefined;
        const onClick = rawOnClick
          ? () => {
              const mockEvent = {
                preventDefault: () => {},
                stopPropagation: () => {},
                currentTarget: null,
                target: null,
              } as any;
              rawOnClick(mockEvent);
            }
          : undefined;

        items.push({
          key: `item-${keyIndex++}`,
          label,
          icon,
          onClick,
          disabled: Boolean(props.disabled),
        });
        return;
      }

      if (props?.children) {
        walk(props.children);
      }
    });
  };

  walk(toolbar);

  while (items[0]?.separator) items.shift();
  while (items[items.length - 1]?.separator) items.pop();
  return items;
}

export function WindowShell({ title, toolbar, children, footer }: { title?: string; toolbar?: ReactNode; children: ReactNode; footer?: ReactNode }) {
  const [menu, setMenu] = useState<{ x: number; y: number } | null>(null);
  const menuRef = useRef<HTMLDivElement | null>(null);
  const menuItems = toolbar ? extractToolbarMenuItems(toolbar) : [];
  useEffect(() => {
    if (!menu) return;
    const close = (e: MouseEvent) => {
      if (menuRef.current && !menuRef.current.contains(e.target as Node)) setMenu(null);
    };
    const esc = (e: KeyboardEvent) => e.key === "Escape" && setMenu(null);
    window.addEventListener("mousedown", close);
    window.addEventListener("keydown", esc);
    return () => {
      window.removeEventListener("mousedown", close);
      window.removeEventListener("keydown", esc);
    };
  }, [menu]);
  const openMenu = (e: React.MouseEvent) => {
    if (!toolbar) return;
    e.preventDefault();
    setMenu({ x: e.clientX, y: e.clientY });
  };

  return (
    <div className="h-full flex flex-col bg-[#F3F6FA]">
      {toolbar && <Toolbar>{toolbar}</Toolbar>}
      <div className="flex-1 min-h-0 overflow-hidden p-2">
        <div className="h-full min-h-0 rounded-sm border border-slate-300 bg-[#F8FBFF] shadow-[inset_0_1px_0_rgba(255,255,255,0.8)] overflow-hidden" onContextMenu={openMenu}>
          <div className="h-full min-h-0 overflow-hidden">{children}</div>
        </div>
      </div>
      {menu && menuItems.length > 0 && createPortal(
        <div
          ref={menuRef}
          style={{ left: menu.x, top: menu.y }}
          className="fixed z-[9999] min-w-[260px] py-1 bg-gradient-to-b from-white to-[#EEF2F7] border border-slate-500/60 shadow-[0_6px_18px_rgba(0,0,0,0.35)] rounded-sm text-slate-800"
        >
          {menuItems.map((item) => {
            if (item.separator) {
              return <div key={item.key} className="my-1 border-t border-slate-300" />;
            }

            return (
              <button
                key={item.key}
                type="button"
                disabled={item.disabled}
                onClick={() => {
                  item.onClick?.();
                  setMenu(null);
                }}
                className="w-full h-8 px-3 flex items-center gap-2 text-[12px] text-left text-slate-800 hover:bg-[#CFE0F4] disabled:opacity-50"
              >
                <span className="shrink-0 text-slate-700">{item.icon}</span>
                <span className="truncate">{item.label}</span>
              </button>
            );
          })}
        </div>,
        document.body,
      )}
      {footer}
    </div>
  );
}


export function MasterDetailForm({
  title,
  toolbar,
  header,
  filters,
  columns,
  rows = 10,
  summary,
  footer,
}: {
  title: string;
  toolbar?: ReactNode;
  header?: ReactNode;
  filters?: ReactNode;
  columns: string[];
  rows?: number;
  summary?: ReactNode;
  footer?: ReactNode;
}) {
  return (
    <WindowShell title={title} toolbar={toolbar}>
      <div className="h-full min-h-0 flex flex-col">
        {header ? <div className="px-1.5 pt-1.5">{header}</div> : null}
        {filters ? <div className="px-1.5 pt-1">{filters}</div> : null}
        <div className="p-1.5 flex-1 min-h-0">
          <DataTable columns={columns} rows={rows} className="h-full overflow-auto" />
        </div>
        {summary ? <div className="px-1.5 pb-1.5">{summary}</div> : null}
        {footer}
      </div>
    </WindowShell>
  );
}

export function ListQueryForm({
  title,
  toolbar,
  filters,
  columns,
  rows = 12,
  extraTop,
}: {
  title: string;
  toolbar?: ReactNode;
  filters?: ReactNode;
  columns: string[];
  rows?: number;
  extraTop?: ReactNode;
}) {
  return (
    <WindowShell title={title} toolbar={toolbar}>
      <div className="h-full min-h-0 flex flex-col">
        {extraTop}
        {filters ? <div className="px-1.5 pt-1">{filters}</div> : null}
        <div className="p-1.5 flex-1 min-h-0">
          <DataTable columns={columns} rows={rows} className="h-full overflow-auto" />
        </div>
      </div>
    </WindowShell>
  );
}

export function LookupDialog({
  title,
  toolbar,
  searchPlaceholder = "Buscar...",
  columns,
  rows = 10,
}: {
  title: string;
  toolbar?: ReactNode;
  searchPlaceholder?: string;
  columns: string[];
  rows?: number;
}) {
  return (
    <WindowShell title={title} toolbar={toolbar}>
      <div className="h-full min-h-0 flex flex-col">
        <div className="mx-1.5 mt-1.5 flex items-center gap-1.5 rounded-sm border border-slate-300 bg-[#ECF1F7] px-2 py-1.5">
          <Search className="h-3.5 w-3.5 text-slate-600" />
          <input className={`${inp} h-6 flex-1`} placeholder={searchPlaceholder} />
          <button className={`${btn} h-6 px-2`}><Search className="h-3.5 w-3.5" />Buscar</button>
        </div>
        <div className="p-1.5 flex-1 min-h-0">
          <DataTable columns={columns} rows={rows} className="h-full overflow-auto" />
        </div>
      </div>
    </WindowShell>
  );
}
