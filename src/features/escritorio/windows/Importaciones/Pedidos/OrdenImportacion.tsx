// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState, useEffect } from "react";
import {
  inp,
  Field,
  WindowShell
} from "@/components/ui/desktop-primitives";
import {
  fetchSigecoomSales,
  createSigecoomSale,
  updateSigecoomSale,
  type SigecoomSale
} from "@/lib/sigecoom-api";

export function OrdenImportacionList() {
  const [orders, setOrders] = useState<SigecoomSale[]>([]);
  const [selectedOrderId, setSelectedOrderId] = useState("");
  const [oiNumber, setOiNumber] = useState("");
  const [date, setDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [foreignSupplier, setForeignSupplier] = useState("");
  const [country, setCountry] = useState("");
  const [incoterm, setIncoterm] = useState("FOB");
  const [currency, setCurrency] = useState("USD");
  const [container, setContainer] = useState("");
  const [customsAgency, setCustomsAgency] = useState("");
  const [dua, setDua] = useState("");
  const [freight, setFreight] = useState<number | "">("");
  const [etaPort, setEtaPort] = useState("");
  const [etaWarehouse, setEtaWarehouse] = useState("");
  const [shippingLine, setShippingLine] = useState("");
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  const loadOrders = async () => {
    setLoading(true);
    setMessage(null);
    try {
      const data = await fetchSigecoomSales();
      setOrders(data.filter((sale) => sale.type.toLowerCase().includes("orden import")));
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "Error cargando órdenes de importación");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadOrders();
  }, []);

  const resetForm = () => {
    setSelectedOrderId("");
    setOiNumber("");
    setDate(new Date().toISOString().slice(0, 10));
    setForeignSupplier("");
    setCountry("");
    setIncoterm("FOB");
    setCurrency("USD");
    setContainer("");
    setCustomsAgency("");
    setDua("");
    setFreight("");
    setEtaPort("");
    setEtaWarehouse("");
    setShippingLine("");
    setMessage(null);
  };

  const handleSave = async () => {
    if (!oiNumber.trim() || !foreignSupplier.trim()) {
      setMessage("Complete el Nº de OI y el proveedor extranjero.");
      return;
    }

    setSaving(true);
    setMessage(null);
    try {
      const extra_data = {
        oi_number: oiNumber.trim(),
        country: country.trim(),
        incoterm,
        currency,
        container: container.trim(),
        customs_agency: customsAgency.trim(),
        dua: dua.trim(),
        freight: freight === "" ? 0 : Number(freight),
        eta_port: etaPort,
        eta_warehouse: etaWarehouse,
        shipping_line: shippingLine.trim(),
      };

      if (selectedOrderId) {
        await updateSigecoomSale(selectedOrderId, {
          client_id: foreignSupplier.trim(),
          date,
          extra_data,
          subtotal: freight === "" ? 0 : Number(freight),
          total: freight === "" ? 0 : Number(freight),
        });
        setMessage("Orden de importación actualizada correctamente.");
      } else {
        await createSigecoomSale({
          type: "Orden Importación",
          series: "OI",
          number: parseInt(oiNumber.replace(/\D/g, "")) || Math.floor(Math.random() * 1000) + 1,
          date,
          client_id: foreignSupplier.trim(),
          items: [{ description: `Orden de importación ${oiNumber}`, unit: "unidad", quantity: 1, price: freight === "" ? 0 : Number(freight) }],
          subtotal: freight === "" ? 0 : Number(freight),
          tax: 0,
          total: freight === "" ? 0 : Number(freight),
          extra_data,
        });
        setMessage("Orden de importación registrada correctamente.");
      }
      await loadOrders();
      resetForm();
    } catch (error) {
      setMessage(error instanceof Error ? error.message : "No se pudo guardar la orden de importación");
    } finally {
      setSaving(false);
    }
  };

  const handleSelect = (order: SigecoomSale) => {
    setSelectedOrderId(order.id);
    setOiNumber(order.extra_data?.oi_number ?? order.series ?? "");
    setDate(order.date.slice(0, 10));
    setForeignSupplier(order.client_id ?? "");
    setCountry(order.extra_data?.country ?? "");
    setIncoterm(order.extra_data?.incoterm ?? "FOB");
    setCurrency(order.extra_data?.currency ?? "USD");
    setContainer(order.extra_data?.container ?? "");
    setCustomsAgency(order.extra_data?.customs_agency ?? "");
    setDua(order.extra_data?.dua ?? "");
    setFreight(order.extra_data?.freight ?? "");
    setEtaPort(order.extra_data?.eta_port ?? "");
    setEtaWarehouse(order.extra_data?.eta_warehouse ?? "");
    setShippingLine(order.extra_data?.shipping_line ?? "");
    setMessage(null);
  };

  return (
    <WindowShell title="Orden de Importación"
    >
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="grid grid-cols-4 gap-3">
        <Field label="OI Nº"><input className={inp} placeholder="OI-2026-0001" value={oiNumber} onChange={(e) => setOiNumber(e.target.value)} /></Field>
        <Field label="Fecha"><input className={inp} type="date" value={date} onChange={(e) => setDate(e.target.value)} /></Field>
        <Field label="Proveedor Extranjero" className="col-span-2"><input className={inp} value={foreignSupplier} onChange={(e) => setForeignSupplier(e.target.value)} /></Field>
        <Field label="País"><input className={inp} value={country} onChange={(e) => setCountry(e.target.value)} /></Field>
        <Field label="Incoterm"><select className={inp} value={incoterm} onChange={(e) => setIncoterm(e.target.value)}><option>FOB</option><option>CIF</option><option>EXW</option><option>DDP</option></select></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}><option>USD</option><option>EUR</option></select></Field>
        <Field label="Nº Contenedor"><input className={inp} value={container} onChange={(e) => setContainer(e.target.value)} /></Field>
        <Field label="Agencia Aduana" className="col-span-2"><input className={inp} value={customsAgency} onChange={(e) => setCustomsAgency(e.target.value)} /></Field>
        <Field label="Dua / Dami"><input className={inp} value={dua} onChange={(e) => setDua(e.target.value)} /></Field>
        <Field label="Flete Internacional"><input className={inp} type="number" value={freight} onChange={(e) => setFreight(e.target.value === "" ? "" : Number(e.target.value))} /></Field>
        <Field label="ETA Puerto"><input className={inp} type="date" value={etaPort} onChange={(e) => setEtaPort(e.target.value)} /></Field>
        <Field label="ETA Almacén"><input className={inp} type="date" value={etaWarehouse} onChange={(e) => setEtaWarehouse(e.target.value)} /></Field>
        <Field label="Naviera"><input className={inp} value={shippingLine} onChange={(e) => setShippingLine(e.target.value)} /></Field>
      </div>
      <div className="mt-3 border border-slate-300 rounded-sm bg-white overflow-auto">
        <table className="w-full text-[11px] border-collapse">
          <thead className="bg-[#F3F6FA]"><tr>
            <th className="px-2 py-2 text-left border-b border-slate-300">Sel</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">OI Nº</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Proveedor</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Incoterm</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">País</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Flete</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">ETA Puerto</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">ETA Almacén</th>
            <th className="px-2 py-2 text-left border-b border-slate-300">Estado</th>
          </tr></thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">Cargando órdenes de importación...</td></tr>
            ) : orders.length === 0 ? (
              <tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">No hay órdenes de importación registradas.</td></tr>
            ) : orders.map((order) => (
              <tr key={order.id} className={`hover:bg-slate-50 ${selectedOrderId === order.id ? "bg-slate-100" : ""}`} onClick={() => handleSelect(order)}>
                <td className="px-2 py-2 border-b border-slate-200 text-center"><input type="radio" name="selectedOrder" checked={selectedOrderId === order.id} readOnly /></td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.oi_number ?? order.series}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.client_id}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.incoterm}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.country}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.freight ?? 0}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.eta_port}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.extra_data?.eta_warehouse}</td>
                <td className="px-2 py-2 border-b border-slate-200">{order.status}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </WindowShell>
  );
}
