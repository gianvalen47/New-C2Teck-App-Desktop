import { useCallback, useEffect, useMemo, useState } from "react";
import {
  Barcode,
  LogOut,
  Package,
  Pencil,
  Plus,
  RefreshCw,
  Save,
  Search,
  Trash2,
} from "lucide-react";
import { toast } from "sonner";
import {
  createInventoryItem,
  deleteInventoryItem,
  fetchInventory,
  type InventoryItem,
  updateInventoryItem,
} from "@/lib/sigecoom-api";

import { inp, btn, btnPrimary, iconBtn, actionBtn, squareIconBtn, tbSep } from "./uiStyles";

function Field({ label, className = "", children }: { label: string; className?: string; children: React.ReactNode }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium">{label}</span>
      {children}
    </label>
  );
}

type ProductoFormProps = {
  item?: InventoryItem;
  onClose: () => void;
  onSaved: () => void;
};

function ProductoForm({ item, onClose, onSaved }: ProductoFormProps) {
  const isNew = !item;
  const [saving, setSaving] = useState(false);

  const [sku, setSku] = useState(item?.sku ?? "");
  const [name, setName] = useState(item?.name ?? "");
  const [description, setDescription] = useState(item?.description ?? "");
  const [category, setCategory] = useState(item?.category ?? "");
  const [unit, setUnit] = useState(item?.unit ?? "UND");
  const [supplier, setSupplier] = useState(item?.supplier ?? "");
  const [stock, setStock] = useState(String(item?.stock ?? 0));
  const [minStock, setMinStock] = useState(String(item?.min_stock ?? 0));
  const [costPrice, setCostPrice] = useState(String(item?.cost_price ?? 0));
  const [salePrice, setSalePrice] = useState(String(item?.sale_price ?? 0));

  const handleSave = async () => {
    if (!name.trim()) {
      toast.error("El nombre del producto es obligatorio");
      return;
    }
    if (isNew && !sku.trim()) {
      toast.error("El código SKU es obligatorio");
      return;
    }

    setSaving(true);
    try {
      if (isNew) {
        await createInventoryItem({
          sku: sku.trim(),
          name: name.trim(),
          description: description.trim() || undefined,
          category: category.trim() || undefined,
          unit: unit.trim() || "UND",
          supplier: supplier.trim() || undefined,
          stock: Number(stock) || 0,
          min_stock: Number(minStock) || 0,
          cost_price: Number(costPrice) || 0,
          sale_price: Number(salePrice) || 0,
        });
        toast.success("Producto registrado");
      } else {
        await updateInventoryItem(item!.id, {
          name: name.trim(),
          description: description.trim() || undefined,
          category: category.trim() || undefined,
          unit: unit.trim() || "UND",
          supplier: supplier.trim() || undefined,
          stock: Number(stock) || 0,
          min_stock: Number(minStock) || 0,
          cost_price: Number(costPrice) || 0,
          sale_price: Number(salePrice) || 0,
        });
        toast.success("Producto actualizado");
      }
      onSaved();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo guardar el producto");
    } finally {
      setSaving(false);
    }
  };

  return (
    <div className="h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0">
        <button className={btnPrimary} onClick={handleSave} disabled={saving}>
          <Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Grabar"}
        </button>
        <button className={btn} onClick={onClose}>Deshacer</button>
        <button className={iconBtn} title="Salir" onClick={onClose}><LogOut className="h-4 w-4" /></button>
        <div className="ml-2 text-[11.5px] font-semibold text-slate-700">{isNew ? "REGISTRAR PRODUCTO" : "ACTUALIZAR PRODUCTO"}</div>
      </div>

      <div className="p-3 overflow-auto min-h-0">
        <div className="grid grid-cols-12 gap-2 max-w-4xl">
          <Field label="SKU" className="col-span-3">
            <input
              className={`${inp} font-mono ${isNew ? "" : "bg-slate-100"}`}
              value={sku}
              onChange={(e) => setSku(e.target.value)}
              disabled={!isNew}
              placeholder="SKU-001"
            />
          </Field>
          <Field label="Nombre" className="col-span-6">
            <input className={inp} value={name} onChange={(e) => setName(e.target.value)} placeholder="Nombre del producto" />
          </Field>
          <Field label="Unidad" className="col-span-3">
            <input className={inp} value={unit} onChange={(e) => setUnit(e.target.value)} placeholder="UND" />
          </Field>

          <Field label="Categoría" className="col-span-4">
            <input className={inp} value={category} onChange={(e) => setCategory(e.target.value)} placeholder="Categoría" />
          </Field>
          <Field label="Proveedor" className="col-span-4">
            <input className={inp} value={supplier} onChange={(e) => setSupplier(e.target.value)} placeholder="Proveedor" />
          </Field>
          <Field label="Stock" className="col-span-2">
            <input className={`${inp} font-mono`} value={stock} onChange={(e) => setStock(e.target.value)} />
          </Field>
          <Field label="Stock Mín." className="col-span-2">
            <input className={`${inp} font-mono`} value={minStock} onChange={(e) => setMinStock(e.target.value)} />
          </Field>

          <Field label="Costo" className="col-span-3">
            <input className={`${inp} font-mono`} value={costPrice} onChange={(e) => setCostPrice(e.target.value)} />
          </Field>
          <Field label="Precio Venta" className="col-span-3">
            <input className={`${inp} font-mono`} value={salePrice} onChange={(e) => setSalePrice(e.target.value)} />
          </Field>
          <Field label="Descripción" className="col-span-6">
            <input className={inp} value={description} onChange={(e) => setDescription(e.target.value)} placeholder="Detalle del artículo" />
          </Field>
        </div>
      </div>
    </div>
  );
}

export function ProductosList() {
  const [rows, setRows] = useState<InventoryItem[]>([]);
  const [loading, setLoading] = useState(false);
  const [searched, setSearched] = useState(false);
  const [search, setSearch] = useState("");
  const [selected, setSelected] = useState<InventoryItem | null>(null);
  const [showForm, setShowForm] = useState(false);
  const [isNew, setIsNew] = useState(false);

  const load = useCallback(async () => {
    setLoading(true);
    try {
      const data = await fetchInventory();
      setRows(data);
      setSearched(true);
    } catch (e: any) {
      toast.error(e.message ?? "Error al cargar productos");
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    load();
  }, [load]);

  const [sortBy, setSortBy] = useState<{ col: string; asc: boolean }>({ col: "name", asc: true });
  const filteredRows = useMemo(() => {
    const q = search.trim().toLowerCase();
    let out = q
      ? rows.filter((r) =>
          [r.sku, r.name, r.category, r.description, r.supplier]
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

  const handleDelete = async () => {
    if (!selected) return;
    if (!confirm(`¿Eliminar el producto ${selected.sku} - ${selected.name}?`)) return;
    try {
      await deleteInventoryItem(selected.id);
      toast.success("Producto eliminado");
      setSelected(null);
      await load();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo eliminar el producto");
    }
  };

  if (showForm) {
    return (
      <ProductoForm
        item={isNew ? undefined : selected ?? undefined}
        onClose={() => {
          setShowForm(false);
          setIsNew(false);
        }}
        onSaved={() => {
          setShowForm(false);
          setIsNew(false);
          load();
        }}
      />
    );
  }

  return (
    <div className="h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Nuevo producto" onClick={() => { setIsNew(true); setShowForm(true); }}><Plus className="h-4 w-4" /></button>
        <button className={iconBtn} title="Editar producto" disabled={!selected} onClick={() => { setIsNew(false); setShowForm(true); }}><Pencil className="h-4 w-4" /></button>
        <button className={iconBtn} title="Eliminar producto" disabled={!selected} onClick={handleDelete}><Trash2 className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar" onClick={load}><RefreshCw className="h-4 w-4" /></button>
        <button className={iconBtn} title="Salir" onClick={() => toast.info("Use la X superior para cerrar la ventana")}><LogOut className="h-4 w-4" /></button>
      </div>

      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="Buscar" className="w-72">
          <input className={inp} value={search} onChange={(e) => setSearch(e.target.value)} placeholder="SKU, nombre, categoría o proveedor" />
        </Field>
        <button className={btnPrimary} onClick={load} disabled={loading}>
          <Search className="h-3.5 w-3.5" />{loading ? "Buscando..." : "Buscar"}
        </button>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full text-[11.5px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
              <tr>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'sku' ? { col: 'sku', asc: !prev.asc } : { col: 'sku', asc: true })}>SKU {sortBy.col === 'sku' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'name' ? { col: 'name', asc: !prev.asc } : { col: 'name', asc: true })}>Nombre {sortBy.col === 'name' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Categoría</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Und</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'stock' ? { col: 'stock', asc: !prev.asc } : { col: 'stock', asc: false })}>Stock {sortBy.col === 'stock' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Stock Min</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Costo</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'sale_price' ? { col: 'sale_price', asc: !prev.asc } : { col: 'sale_price', asc: false })}>Precio {sortBy.col === 'sale_price' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Proveedor</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Estado</th>
              </tr>
            </thead>
            <tbody>
              {filteredRows.length === 0 ? (
                <tr>
                  <td colSpan={10} className="text-center py-8 text-slate-400 text-[11px]">
                    {loading ? "Cargando..." : searched ? "Sin resultados" : "Use la búsqueda y pulse Buscar"}
                  </td>
                </tr>
              ) : filteredRows.map((p, i) => {
                const isSel = selected?.id === p.id;
                return (
                  <tr
                    key={p.id}
                    onClick={() => setSelected(p)}
                    onDoubleClick={() => { setSelected(p); setIsNew(false); setShowForm(true); }}
                    className={[
                      "cursor-pointer border-b border-slate-200",
                      i % 2 ? "bg-[#F6F9FC]" : "bg-white",
                      isSel ? "!bg-[#D6E4F4] outline outline-1 outline-[#3E5B7A]" : "hover:bg-[#E8F0F8]/60",
                    ].join(" ")}
                  >
                    <td className="px-2 py-1 text-center border-r border-slate-200 font-mono font-semibold">{p.sku}</td>
                    <td className="px-2 py-1 border-r border-slate-200 max-w-[280px] truncate">{p.name}</td>
                    <td className="px-2 py-1 border-r border-slate-200">{p.category || "-"}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">{p.unit}</td>
                    <td className="px-2 py-1 text-right border-r border-slate-200 font-mono">{p.stock}</td>
                    <td className="px-2 py-1 text-right border-r border-slate-200 font-mono">{p.min_stock ?? 0}</td>
                    <td className="px-2 py-1 text-right border-r border-slate-200 font-mono">{(p.cost_price ?? 0).toFixed(2)}</td>
                    <td className="px-2 py-1 text-right border-r border-slate-200 font-mono font-semibold">{(p.sale_price ?? 0).toFixed(2)}</td>
                    <td className="px-2 py-1 border-r border-slate-200 max-w-[200px] truncate">{p.supplier || "-"}</td>
                    <td className="px-2 py-1 text-center">{p.active ? "ACTIVO" : "INACTIVO"}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      </div>

      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-[11px] text-slate-700 text-center font-medium flex items-center justify-center whitespace-nowrap overflow-hidden">
        Registros : {filteredRows.length}
      </div>
    </div>
  );
}
