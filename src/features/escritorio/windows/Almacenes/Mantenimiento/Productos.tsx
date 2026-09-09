import { useEffect, useRef, useState } from "react";
import { FileDown, FileSpreadsheet, LogOut, Plus, Printer, RefreshCw, Save, Search, X } from "lucide-react";
import { btn, btnPrimary, iconBtn, inp, squareIconBtn, tbSep } from "@/features/escritorio/windows/uiStyles";
import {
  createInventoryItem,
  exportSigecoomInventory,
  fetchInventory,
  importSigecoomInventory,
  type InventoryItem,
  updateInventoryItem,
} from "@/lib/sigecoom-api";
import { downloadBlob } from "@/features/escritorio/windows/shared/LegacySupport";

function Field({ label, className = "", children }: { label: string; className?: string; children: React.ReactNode }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium leading-tight">{label}</span>
      {children}
    </label>
  );
}

export function ProductosList() {
  const [items, setItems] = useState<InventoryItem[]>([]);
  const [selectedItemId, setSelectedItemId] = useState<string>("");
  const [sku, setSku] = useState("");
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [category, setCategory] = useState("Repuestos");
  const [unit, setUnit] = useState("UND");
  const [supplier, setSupplier] = useState("");
  const [stock, setStock] = useState(0);
  const [minStock, setMinStock] = useState(10);
  const [costPrice, setCostPrice] = useState(0);
  const [salePrice, setSalePrice] = useState(0);
  const [search, setSearch] = useState("");
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);
  const [importing, setImporting] = useState(false);
  const fileInputRef = useRef<HTMLInputElement | null>(null);

  const loadItems = async (query?: string) => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchInventory(query?.trim() ? query : undefined);
      setItems(data);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando productos");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadItems();
  }, []);

  const clearForm = () => {
    setSelectedItemId("");
    setSku("");
    setName("");
    setDescription("");
    setCategory("Repuestos");
    setUnit("UND");
    setSupplier("");
    setStock(0);
    setMinStock(10);
    setCostPrice(0);
    setSalePrice(0);
    setMessage(null);
  };

  const handleSelect = (item: InventoryItem) => {
    setSelectedItemId(item.id);
    setSku(item.sku);
    setName(item.name);
    setDescription(item.description ?? "");
    setCategory(item.category ?? "Repuestos");
    setUnit(item.unit ?? "UND");
    setSupplier(item.supplier ?? "");
    setStock(item.stock ?? 0);
    setMinStock(item.min_stock ?? 0);
    setCostPrice(item.cost_price ?? 0);
    setSalePrice(item.sale_price ?? 0);
    setMessage(null);
  };

  const handleSave = async () => {
    if (!sku.trim() || !name.trim()) {
      setMessage("SKU y nombre son obligatorios.");
      return;
    }

    setSaving(true);
    try {
      if (selectedItemId) {
        const updated = await updateInventoryItem(selectedItemId, {
          name,
          description,
          category,
          unit,
          supplier,
          stock,
          min_stock: minStock,
          cost_price: costPrice,
          sale_price: salePrice,
        });
        setItems((current) => current.map((item) => (item.id === updated.id ? updated : item)));
        setMessage(`Producto actualizado: ${updated.sku}`);
      } else {
        const created = await createInventoryItem({
          sku,
          name,
          description,
          category,
          unit,
          supplier,
          stock,
          min_stock: minStock,
          cost_price: costPrice,
          sale_price: salePrice,
        });
        setItems((current) => [created, ...current]);
        setSelectedItemId(created.id);
        setMessage(`Producto creado: ${created.sku}`);
      }
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo guardar el producto");
    } finally {
      setSaving(false);
    }
  };

  const handleSearch = async () => {
    await loadItems(search);
  };

  const handleExport = async () => {
    try {
      const blob = await exportSigecoomInventory("csv");
      downloadBlob(blob, "inventario_export.csv");
      setMessage("Exportación de inventario iniciada.");
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo exportar el inventario");
    }
  };

  const handleImportClick = () => {
    fileInputRef.current?.click();
  };

  const handleImport = async (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (!file) return;

    setImporting(true);
    setMessage(null);
    try {
      const result = await importSigecoomInventory(file);
      setMessage(`Importados ${result.created} nuevos / actualizados ${result.updated}`);
      await loadItems();
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo importar el inventario");
    } finally {
      setImporting(false);
      event.target.value = "";
    }
  };

  const handleLabel = () => {
    if (!selectedItemId) {
      setMessage("Seleccione un producto para generar etiqueta.");
      return;
    }
    setMessage(`Etiqueta generada para ${sku}`);
  };

  return (
    <div className="h-full flex flex-col bg-[#EEF3F8] text-slate-800">
      <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] border-b border-[#1F2E3F] text-[12px] text-white">
        <span className="font-medium">Maestro de Productos — Ficha SKU</span>
        <div className="flex items-center gap-1">
          <button className={iconBtn} title="Guardar" onClick={handleSave} disabled={saving}><Save className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Nuevo" onClick={clearForm}><Plus className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Buscar" onClick={handleSearch}><Search className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Etiqueta" onClick={handleLabel}><Printer className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Importar Excel" onClick={handleImportClick} disabled={importing}><FileSpreadsheet className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Exportar CSV" onClick={handleExport}><FileDown className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4 text-white" /></button>
        </div>
      </div>

      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EDF2F7] to-[#D9E2EC] border-b border-slate-300 text-slate-700 overflow-x-auto">
        <button className={squareIconBtn} title="Guardar" onClick={handleSave}><Save className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Nuevo" onClick={clearForm}><Plus className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Buscar" onClick={handleSearch}><Search className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Etiqueta" onClick={handleLabel}><Printer className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Importar Excel" onClick={handleImportClick}><FileSpreadsheet className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Exportar CSV" onClick={handleExport}><FileDown className="h-3.5 w-3.5" /></button>
        {tbSep}
        <button className={squareIconBtn} title="Actualizar" onClick={() => loadItems(search)}><RefreshCw className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Cerrar"><X className="h-3.5 w-3.5" /></button>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-3">
        {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
        <div className="grid grid-cols-2 gap-4 mb-4">
          <div className="border border-slate-300 rounded-sm p-3 bg-white shadow-sm">
            <div className="text-[11px] font-semibold text-[#2A3F55] mb-2 uppercase">Identificación</div>
            <div className="grid grid-cols-2 gap-2">
              <Field label="Código SKU"><input className={inp} value={sku} onChange={(e) => setSku(e.target.value)} /></Field>
              <Field label="Descripción" className="col-span-2"><input className={inp} value={name} onChange={(e) => setName(e.target.value)} /></Field>
              <Field label="Código de Barras"><input className={inp} value={description} onChange={(e) => setDescription(e.target.value)} /></Field>
              <Field label="Categoría"><select className={inp} value={category} onChange={(e) => setCategory(e.target.value)}><option>Repuestos</option><option>Herramientas</option><option>Consumibles</option></select></Field>
              <Field label="Unidad Medida"><select className={inp} value={unit} onChange={(e) => setUnit(e.target.value)}><option>UND</option><option>KG</option><option>MT</option></select></Field>
              <Field label="Marca"><input className={inp} value={supplier} onChange={(e) => setSupplier(e.target.value)} /></Field>
            </div>
          </div>

          <div className="border border-slate-300 rounded-sm p-3 bg-white shadow-sm">
            <div className="text-[11px] font-semibold text-[#2A3F55] mb-2 uppercase">Stocks y Precios</div>
            <div className="grid grid-cols-2 gap-2">
              <Field label="Stock Actual"><input className={inp} type="number" value={stock} onChange={(e) => setStock(Number(e.target.value))} /></Field>
              <Field label="Stock Mínimo"><input className={inp} type="number" value={minStock} onChange={(e) => setMinStock(Number(e.target.value))} /></Field>
              <Field label="Costo"><input className={inp} type="number" value={costPrice} onChange={(e) => setCostPrice(Number(e.target.value))} /></Field>
              <Field label="Precio Venta"><input className={inp} type="number" value={salePrice} onChange={(e) => setSalePrice(Number(e.target.value))} /></Field>
              <Field label="Proveedor"><input className={inp} value={supplier} onChange={(e) => setSupplier(e.target.value)} /></Field>
              <Field label="Moneda"><select className={inp}><option>PEN</option><option>USD</option></select></Field>
            </div>
          </div>
        </div>

        <div className="mb-2 flex items-center justify-between gap-2 rounded-sm border border-slate-300 bg-white px-2 py-1.5 shadow-sm">
          <div className="flex items-center gap-2">
            <Search className="h-3.5 w-3.5 text-slate-500" />
            <input className={`${inp} w-72`} placeholder="Buscar por SKU o nombre" value={search} onChange={(e) => setSearch(e.target.value)} onKeyDown={(e) => { if (e.key === "Enter") void handleSearch(); }} />
          </div>
          <button className={`${btnPrimary} h-7`} onClick={() => void handleSearch()}><Search className="h-3.5 w-3.5" />Buscar</button>
        </div>

        <div className="border border-slate-300 rounded-sm bg-white overflow-auto shadow-sm">
          <table className="w-full text-[11px] border-collapse">
            <thead className="bg-[#F3F6FA]"><tr>
              <th className="px-2 py-2 text-left border-b border-slate-300">SKU</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Descripción</th>
              <th className="px-2 py-2 text-left border-b border-slate-300">Categoría</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Stock</th>
              <th className="px-2 py-2 text-right border-b border-slate-300">Precio</th>
            </tr></thead>
            <tbody>
              {loading ? (
                <tr><td colSpan={5} className="px-2 py-4 text-sm text-slate-500">Cargando productos...</td></tr>
              ) : items.length === 0 ? (
                <tr><td colSpan={5} className="px-2 py-4 text-sm text-slate-500">No hay productos registrados.</td></tr>
              ) : items.map((item) => (
                <tr key={item.id} className={`hover:bg-slate-50 ${selectedItemId === item.id ? "bg-slate-100" : ""}`} onClick={() => handleSelect(item)}>
                  <td className="px-2 py-2 border-b border-slate-200">{item.sku}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{item.name}</td>
                  <td className="px-2 py-2 border-b border-slate-200">{item.category || "—"}</td>
                  <td className="px-2 py-2 text-right border-b border-slate-200">{item.stock ?? 0}</td>
                  <td className="px-2 py-2 text-right border-b border-slate-200">{item.sale_price?.toFixed(2) ?? "0.00"}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
      <input ref={fileInputRef} type="file" accept=".csv" className="hidden" onChange={handleImport} />
    </div>
  );
}

