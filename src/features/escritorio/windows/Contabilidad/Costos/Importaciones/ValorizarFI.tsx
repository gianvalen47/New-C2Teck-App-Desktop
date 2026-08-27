// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState, useEffect } from "react";
import {
  inp,
  Field,
  WindowShell
} from "@/components/ui/desktop-primitives";
import {
  fetchInventory,
  updateInventoryItem,
  type InventoryItem
} from "@/lib/sigecoom-api";

export function ValorizarFIList() {
  const [items, setItems] = useState<InventoryItem[]>([]);
  const [search, setSearch] = useState("");
  const [oiNumber, setOiNumber] = useState("OI-2026-0001");
  const [currency, setCurrency] = useState("USD");
  const [exchangeRate, setExchangeRate] = useState("3.411");
  const [freight, setFreight] = useState(0);
  const [insurance, setInsurance] = useState(0);
  const [customs, setCustoms] = useState(0);
  const [otherCosts, setOtherCosts] = useState(0);
  const [baseProrrateo, setBaseProrrateo] = useState("Valor FOB");
  const [selectedIds, setSelectedIds] = useState<string[]>([]);
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const loadItems = async (query?: string) => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchInventory(query?.trim() ? query : undefined);
      setItems(data);
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando inventario");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadItems();
  }, []);

  const computedCosts = items.map((item) => {
    const stock = item.stock ?? 1;
    const baseValue = (item.cost_price ?? 0) * stock;
    return {
      ...item,
      stock,
      baseValue,
    };
  });

  const totalBase = computedCosts.reduce((sum, item) => sum + item.baseValue, 0);
  const totalExtras = freight + insurance + customs + otherCosts;

  const previewItems = computedCosts.map((item) => {
    const ratio = totalBase > 0 ? item.baseValue / totalBase : 1 / Math.max(items.length, 1);
    const proratedCost = totalExtras * ratio;
    const costPerUnit = item.stock > 0 ? proratedCost / item.stock : proratedCost;
    const netCost = (item.cost_price ?? 0) + costPerUnit;
    return {
      ...item,
      ratio,
      proratedCost,
      costPerUnit,
      netCost,
    };
  });

  const visibleItems = previewItems.filter((item) => {
    const needle = search.trim().toLowerCase();
    if (!needle) return true;
    return [item.sku, item.name, item.category, item.description].some((value) =>
      value?.toLowerCase().includes(needle)
    );
  });

  const toggleSelect = (itemId: string) => {
    setSelectedIds((current) =>
      current.includes(itemId) ? current.filter((id) => id !== itemId) : [...current, itemId]
    );
  };

  const handleApplyProrrateo = async () => {
    if (selectedIds.length === 0) {
      setMessage("Seleccione al menos un artículo para aplicar el prorrateo.");
      return;
    }
    setSaving(true);
    setMessage(null);
    try {
      const selected = previewItems.filter((item) => selectedIds.includes(item.id));
      const selectedTotalBase = selected.reduce((sum, item) => sum + item.baseValue, 0);
      await Promise.all(selected.map((item) => {
        const ratio = selectedTotalBase > 0 ? item.baseValue / selectedTotalBase : 1 / selected.length;
        const proratedCost = totalExtras * ratio;
        const priceIncrease = item.stock > 0 ? proratedCost / item.stock : proratedCost;
        const newCost = (item.cost_price ?? 0) + priceIncrease;
        return updateInventoryItem(item.id, {
          cost_price: Number(newCost.toFixed(2)),
        });
      }));
      await loadItems(search);
      setMessage("Prorrateo aplicado correctamente a los artículos seleccionados.");
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo aplicar el prorrateo");
    } finally {
      setSaving(false);
    }
  };

  return (
    <WindowShell title="Valorizar F/I — Prorrateo de Costos de Importación"
    >
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="grid grid-cols-4 gap-3 mb-3">
        <Field label="OI / Embarque" className="col-span-2"><input className={inp} value={oiNumber} onChange={(e) => setOiNumber(e.target.value)} placeholder="OI-2026-0001" /></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>USD</option><option>PEN</option></select></Field>
        <Field label="T/C"><input className={inp} value={exchangeRate} onChange={(e) => setExchangeRate(e.target.value)} /></Field>
        <Field label="Flete Internacional"><input className={inp} type="number" value={freight} onChange={(e) => setFreight(Number(e.target.value))} /></Field>
        <Field label="Seguro"><input className={inp} type="number" value={insurance} onChange={(e) => setInsurance(Number(e.target.value))} /></Field>
        <Field label="Aduana / DUA"><input className={inp} type="number" value={customs} onChange={(e) => setCustoms(Number(e.target.value))} /></Field>
        <Field label="Otros Gastos"><input className={inp} type="number" value={otherCosts} onChange={(e) => setOtherCosts(Number(e.target.value))} /></Field>
        <Field label="Base Prorrateo"><select className={inp} value={baseProrrateo} onChange={(e) => setBaseProrrateo(e.target.value)}><option>Valor FOB</option><option>Peso</option><option>Volumen</option></select></Field>
      </div>
      <div className="grid grid-cols-4 gap-3 mb-4">
        <Field label="Buscar artículo" className="col-span-2"><input className={inp} value={search} onChange={(e) => setSearch(e.target.value)} placeholder="SKU, nombre, categoría" /></Field>
        <Field label="Total Base"><input className={inp} value={totalBase.toFixed(2)} readOnly /></Field>
        <Field label="Total Gastos"><input className={inp} value={totalExtras.toFixed(2)} readOnly /></Field>
      </div>
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr>
            <th className="px-2 py-2 text-left border-b border-slate-300">Sel</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">SKU</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Producto</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Cant.</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">FOB Unit.</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Prorrateo</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Costo Neto</th>
          </tr></thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={7} className="px-2 py-4 text-sm text-slate-500">Cargando artículos...</td></tr>
            ) : visibleItems.length === 0 ? (
              <tr><td colSpan={7} className="px-2 py-4 text-sm text-slate-500">No se encontraron artículos.</td></tr>
            ) : visibleItems.map((item) => (
              <tr key={item.id} className={`hover:bg-slate-50 ${selectedIds.includes(item.id) ? "bg-slate-100" : ""}`}>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><input type="checkbox" checked={selectedIds.includes(item.id)} onChange={() => toggleSelect(item.id)} /></td>
                <td className="px-2 py-2 border-b border-slate-200">{item.sku}</td>
                <td className="px-2 py-2 border-b border-slate-200">{item.name}</td>
                <td className="px-2 py-2 border-b border-slate-200">{item.stock}</td>
                <td className="px-2 py-2 border-b border-slate-200">{(item.cost_price ?? 0).toFixed(2)}</td>
                <td className="px-2 py-2 border-b border-slate-200">{item.proratedCost?.toFixed(2) ?? "0.00"}</td>
                <td className="px-2 py-2 border-b border-slate-200">{item.netCost?.toFixed(2) ?? (item.cost_price ?? 0).toFixed(2)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}
