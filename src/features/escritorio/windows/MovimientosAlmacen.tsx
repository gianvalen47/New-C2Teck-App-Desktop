import { useCallback, useEffect, useMemo, useState } from "react";
import {
  ArrowRightLeft,
  ArrowDownToLine,
  ArrowUpFromLine,
  LogOut,
  Package,
  RefreshCw,
  Save,
  Search,
  Warehouse,
} from "lucide-react";
import { toast } from "sonner";
import { fetchInventory, type InventoryItem, updateInventoryItem } from "@/lib/sigecoom-api";

import { inp, btn, btnPrimary, iconBtn, actionBtn, squareIconBtn, tbSep } from "./uiStyles";

type MovimientoTipo = "ingreso" | "salida" | "transferencia";

const MOV_LABEL: Record<MovimientoTipo, string> = {
  ingreso: "Ingreso",
  salida: "Salida",
  transferencia: "Transferencia",
};

function Field({ label, className = "", children }: { label: string; className?: string; children: React.ReactNode }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium">{label}</span>
      {children}
    </label>
  );
}

export function MovimientosAlmacenList({ initialTipo = "ingreso" as MovimientoTipo }) {
  const [rows, setRows] = useState<InventoryItem[]>([]);
  const [loading, setLoading] = useState(false);
  const [searched, setSearched] = useState(false);

  const [search, setSearch] = useState("");
  const [tipo, setTipo] = useState<MovimientoTipo>(initialTipo);
  const [cantidad, setCantidad] = useState("1");
  const [motivo, setMotivo] = useState("");
  const [selected, setSelected] = useState<InventoryItem | null>(null);

  const load = useCallback(async () => {
    setLoading(true);
    try {
      const data = await fetchInventory();
      setRows(data.filter((r) => Boolean(r.active)));
      setSearched(true);
    } catch (e: any) {
      toast.error(e.message ?? "Error al cargar inventario");
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    load();
  }, [load]);

  useEffect(() => {
    setTipo(initialTipo);
  }, [initialTipo]);

  const [sortBy, setSortBy] = useState<{ col: string; asc: boolean }>({ col: "sku", asc: true });
  const rowsView = useMemo(() => {
    const q = search.trim().toLowerCase();
    let out = q
      ? rows.filter((r) =>
          [r.sku, r.name, r.category, r.supplier]
            .filter(Boolean)
            .some((v) => String(v).toLowerCase().includes(q))
        )
      : [...rows];
    const col = sortBy.col;
    if (col) {
      out.sort((a: any, b: any) => {
        const va = a[col];
        const vb = b[col];
        if (va == null && vb == null) return 0;
        if (va == null) return sortBy.asc ? -1 : 1;
        if (vb == null) return sortBy.asc ? 1 : -1;
        if (typeof va === "number" && typeof vb === "number") return sortBy.asc ? va - vb : vb - va;
        return sortBy.asc ? String(va).localeCompare(String(vb)) : String(vb).localeCompare(String(va));
      });
    }
    return out;
  }, [rows, search, sortBy]);

  const ajustePreview = useMemo(() => {
    if (!selected) return 0;
    const qty = Number(cantidad) || 0;
    if (tipo === "ingreso") return selected.stock + qty;
    if (tipo === "salida") return selected.stock - qty;
    return selected.stock;
  }, [selected, cantidad, tipo]);

  const aplicarMovimiento = async () => {
    if (!selected) {
      toast.error("Seleccione un producto");
      return;
    }
    const qty = Number(cantidad) || 0;
    if (qty <= 0) {
      toast.error("La cantidad debe ser mayor a cero");
      return;
    }

    const stockActual = selected.stock;
    let nuevoStock = stockActual;
    if (tipo === "ingreso") nuevoStock = stockActual + qty;
    if (tipo === "salida") nuevoStock = stockActual - qty;

    if (tipo === "salida" && nuevoStock < 0) {
      toast.error("No puede generar stock negativo");
      return;
    }

    try {
      await updateInventoryItem(selected.id, {
        stock: nuevoStock,
        description: [selected.description, `${new Date().toLocaleDateString("es-PE")}: ${MOV_LABEL[tipo]} x${qty}${motivo.trim() ? ` (${motivo.trim()})` : ""}`]
          .filter(Boolean)
          .join(" | "),
      });
      toast.success(`${MOV_LABEL[tipo]} aplicado al producto`);
      setMotivo("");
      setCantidad("1");
      await load();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo aplicar el movimiento");
    }
  };

  return (
    <div className="h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        <button className={btnPrimary} onClick={aplicarMovimiento} disabled={!selected}><Save className="h-3.5 w-3.5" />Aplicar {MOV_LABEL[tipo]}</button>
        <button className={iconBtn} title="Actualizar" onClick={load}><RefreshCw className="h-4 w-4" /></button>
        <button className={iconBtn} title="Salir" onClick={() => toast.info("Use la X superior para cerrar la ventana")}><LogOut className="h-4 w-4" /></button>
      </div>

      <div className="grid grid-cols-12 gap-2 px-2 py-2 border-b border-slate-300 bg-[#F0F4F8]">
        <Field label="Tipo de Movimiento" className="col-span-2">
          <select className={inp} value={tipo} onChange={(e) => setTipo(e.target.value as MovimientoTipo)}>
            <option value="ingreso">Ingreso</option>
            <option value="salida">Salida</option>
            <option value="transferencia">Transferencia</option>
          </select>
        </Field>
        <Field label="Buscar Producto" className="col-span-4">
          <input className={inp} value={search} onChange={(e) => setSearch(e.target.value)} placeholder="SKU, nombre, categoría" />
        </Field>
        <Field label="Cantidad" className="col-span-2">
          <input className={`${inp} font-mono`} value={cantidad} onChange={(e) => setCantidad(e.target.value)} />
        </Field>
        <Field label="Motivo" className="col-span-4">
          <input className={inp} value={motivo} onChange={(e) => setMotivo(e.target.value)} placeholder="Observación del movimiento" />
        </Field>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full text-[11.5px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
              <tr>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'sku' ? { col: 'sku', asc: !prev.asc } : { col: 'sku', asc: true })}>SKU {sortBy.col === 'sku' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'name' ? { col: 'name', asc: !prev.asc } : { col: 'name', asc: true })}>Producto {sortBy.col === 'name' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Categoría</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'stock' ? { col: 'stock', asc: !prev.asc } : { col: 'stock', asc: false })}>Stock Actual {sortBy.col === 'stock' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Min</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Unidad</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Proveedor</th>
              </tr>
            </thead>
            <tbody>
              {rowsView.length === 0 ? (
                <tr>
                  <td colSpan={7} className="text-center py-8 text-slate-400 text-[11px]">
                    {loading ? "Cargando..." : searched ? "Sin resultados" : "Cargando inventario"}
                  </td>
                </tr>
              ) : rowsView.map((r, i) => {
                const isSel = selected?.id === r.id;
                return (
                  <tr
                    key={r.id}
                    onClick={() => setSelected(r)}
                    className={[
                      "cursor-pointer border-b border-slate-200",
                      i % 2 ? "bg-[#F6F9FC]" : "bg-white",
                      isSel ? "!bg-[#D6E4F4] outline outline-1 outline-[#3E5B7A]" : "hover:bg-[#E8F0F8]/60",
                    ].join(" ")}
                  >
                    <td className="px-2 py-1 text-center border-r border-slate-200 font-mono font-semibold">{r.sku}</td>
                    <td className="px-2 py-1 border-r border-slate-200 max-w-[300px] truncate">{r.name}</td>
                    <td className="px-2 py-1 border-r border-slate-200">{r.category || "-"}</td>
                    <td className="px-2 py-1 text-right border-r border-slate-200 font-mono">{r.stock}</td>
                    <td className="px-2 py-1 text-right border-r border-slate-200 font-mono">{r.min_stock ?? 0}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">{r.unit}</td>
                    <td className="px-2 py-1 border-r border-slate-200 max-w-[220px] truncate">{r.supplier || "-"}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      </div>

      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-1 text-[11px] text-slate-700 font-medium flex items-center justify-between gap-3 overflow-hidden">
        <span className="whitespace-nowrap">Registros : {rowsView.length}</span>
        <span className="whitespace-nowrap text-right truncate">
          {selected
            ? `Seleccionado: ${selected.sku} | Stock ${selected.stock} -> ${ajustePreview}`
            : "Seleccione un producto para aplicar el movimiento"}
        </span>
      </div>
    </div>
  );
}

export function DocIngresosList() {
  return <MovimientosAlmacenList initialTipo="ingreso" />;
}

export function DocSalidasList() {
  return <MovimientosAlmacenList initialTipo="salida" />;
}

export function DocSalidasList2() {
  return <DocSalidasList />;
}

export function TransferenciasList() {
  return <MovimientosAlmacenList initialTipo="transferencia" />;
}
