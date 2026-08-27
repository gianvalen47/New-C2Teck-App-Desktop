// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState, useEffect } from "react";
import {
  inp,
  Field,
  WindowShell
} from "@/components/ui/desktop-primitives";
import {
  fetchInventory,
  createInventoryItem,
  updateInventoryItem,
  type InventoryItem
} from "@/lib/sigecoom-api";

export function ActivosFijosList() {
  const [assets, setAssets] = useState<InventoryItem[]>([]);
  const [selectedAssetId, setSelectedAssetId] = useState("");
  const [sku, setSku] = useState("");
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [category, setCategory] = useState("Activo Fijo");
  const [unit, setUnit] = useState("UND");
  const [acquisitionDate, setAcquisitionDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [costPrice, setCostPrice] = useState(0);
  const [bookValue, setBookValue] = useState(0);
  const [responsible, setResponsible] = useState("");
  const [location, setLocation] = useState("");
  const [status, setStatus] = useState("Óptimo");
  const [search, setSearch] = useState("");
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const loadAssets = async (query?: string) => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchInventory(query?.trim() ? query : undefined);
      setAssets(data.filter((item) =>
        item.category?.toLowerCase().includes("activo") ||
        item.description?.toLowerCase().includes("activo") ||
        item.name.toLowerCase().includes("activo")
      ));
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando activos fijos");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadAssets();
  }, []);

  const clearForm = () => {
    setSelectedAssetId("");
    setSku("");
    setName("");
    setDescription("");
    setCategory("Activo Fijo");
    setUnit("UND");
    setAcquisitionDate(new Date().toISOString().slice(0, 10));
    setCostPrice(0);
    setBookValue(0);
    setResponsible("");
    setLocation("");
    setStatus("Óptimo");
    setMessage(null);
  };

  const handleSelectAsset = (item: InventoryItem) => {
    setSelectedAssetId(item.id);
    setSku(item.sku);
    setName(item.name);
    setDescription(item.description ?? "");
    setCategory(item.category ?? "Activo Fijo");
    setUnit(item.unit ?? "UND");
    setCostPrice(item.cost_price ?? 0);
    setBookValue(item.sale_price ?? 0);
    setResponsible(item.supplier ?? "");
    setLocation(item.category ?? "");
    setStatus(item.active === 1 ? "Activo" : "Inactivo");
    setMessage(null);
  };

  const handleSave = async () => {
    if (!sku.trim() || !name.trim()) {
      setMessage("SKU y descripción son obligatorios.");
      return;
    }

    setSaving(true);
    setMessage(null);

    try {
      if (selectedAssetId) {
        const updated = await updateInventoryItem(selectedAssetId, {
          name,
          description,
          category,
          unit,
          supplier: responsible,
          cost_price: costPrice,
          sale_price: bookValue,
          active: status === "Activo" ? 1 : 0,
        });
        setAssets((current) => current.map((item) => item.id === updated.id ? updated : item));
        setMessage(`Activo fijo actualizado: ${updated.sku}`);
      } else {
        const created = await createInventoryItem({
          sku,
          name,
          description,
          category,
          unit,
          supplier: responsible,
          cost_price: costPrice,
          sale_price: bookValue,
          stock: 1,
          min_stock: 0,
        });
        setAssets((current) => [created, ...current]);
        setSelectedAssetId(created.id);
        setMessage(`Activo fijo creado: ${created.sku}`);
      }
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo guardar el activo fijo");
    } finally {
      setSaving(false);
    }
  };

  const visibleAssets = assets.filter((item) => {
    const query = search.trim().toLowerCase();
    if (!query) return true;
    return [item.sku, item.name, item.category, item.description, item.supplier]
      .some((value) => value?.toLowerCase().includes(query));
  });

  return (
    <WindowShell title="Activos Fijos — Inventario"
    >
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="grid grid-cols-4 gap-3 mb-3">
        <Field label="Buscar Activo" className="col-span-2"><input className={inp} value={search} onChange={(e) => setSearch(e.target.value)} placeholder="Código, nombre o categoría" /></Field>
        <Field label="SKU"><input className={inp} value={sku} onChange={(e) => setSku(e.target.value)} placeholder="AF-0001" /></Field>
        <Field label="Categoría"><input className={inp} value={category} onChange={(e) => setCategory(e.target.value)} /></Field>
        <Field label="Descripción" className="col-span-2"><input className={inp} value={name} onChange={(e) => setName(e.target.value)} /></Field>
        <Field label="Fecha Adquisición"><input className={inp} type="date" value={acquisitionDate} onChange={(e) => setAcquisitionDate(e.target.value)} /></Field>
        <Field label="Costo Adquisición"><input className={inp} type="number" value={costPrice} onChange={(e) => setCostPrice(Number(e.target.value))} /></Field>
        <Field label="Valor en Libros"><input className={inp} type="number" value={bookValue} onChange={(e) => setBookValue(Number(e.target.value))} /></Field>
        <Field label="Responsable"><input className={inp} value={responsible} onChange={(e) => setResponsible(e.target.value)} /></Field>
        <Field label="Ubicación / Área"><input className={inp} value={location} onChange={(e) => setLocation(e.target.value)} /></Field>
        <Field label="Estado"><select className={inp} value={status} onChange={(e) => setStatus(e.target.value)}><option>Óptimo</option><option>Bueno</option><option>Regular</option><option>Baja</option><option>Inactivo</option></select></Field>
        <Field label="Departamento" className="col-span-2"><input className={inp} placeholder="Área interna" /></Field>
      </div>

      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr>
            <th className="px-2 py-2 text-left border-b border-slate-300">SKU</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Activo</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Categoría</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Costo</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Valor Libros</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Responsable</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Estado</th>
          </tr></thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={7} className="px-2 py-4 text-sm text-slate-500">Cargando activos fijos...</td></tr>
            ) : visibleAssets.length === 0 ? (
              <tr><td colSpan={7} className="px-2 py-4 text-sm text-slate-500">No se encontraron activos fijos.</td></tr>
            ) : visibleAssets.map((asset) => (
              <tr key={asset.id} className={`hover:bg-slate-50 ${selectedAssetId === asset.id ? "bg-slate-100" : ""}`} onClick={() => handleSelectAsset(asset)}>
                <td className="px-2 py-2 border-b border-slate-200">{asset.sku}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.name}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.category}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.cost_price?.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.sale_price?.toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.supplier}</td>
                <td className="px-2 py-2 border-b border-slate-200">{asset.active === 1 ? "Activo" : "Inactivo"}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}
