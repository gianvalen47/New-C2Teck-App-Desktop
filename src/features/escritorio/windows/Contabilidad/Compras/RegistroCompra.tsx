// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState, useEffect } from "react";
import { Save, RefreshCw } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  WindowShell
} from "@/components/ui/desktop-primitives";
import {
  fetchPurchaseRegisters,
  createPurchaseRegister,
  type PurchaseRegister
} from "@/lib/sigecoom-api";
import { Boleta } from "@/features/escritorio/windows/Ventas/Documentos/Boletas";
import { Factura } from "@/features/escritorio/windows/Ventas/Documentos/Facturas";

export function RegistroCompraList() {
  const [registers, setRegisters] = useState<PurchaseRegister[]>([]);
  const [loading, setLoading] = useState(false);
  const [filter, setFilter] = useState<"all" | "draft" | "registered">("all");

  // Form state
  const [docType, setDocType] = useState("Factura");
  const [series, setSeries] = useState("");
  const [number, setNumber] = useState("");
  const [docDate, setDocDate] = useState(new Date().toISOString().split('T')[0]);
  const [supplierRuc, setSupplierRuc] = useState("");
  const [supplierName, setSupplierName] = useState("");
  const [currency, setCurrency] = useState("PEN");
  const [taxableBase, setTaxableBase] = useState(0);
  const [igv, setIgv] = useState(0);
  const [nonTaxable, setNonTaxable] = useState(0);
  const [retention, setRetention] = useState(0);
  const [costCenter, setCostCenter] = useState("");

  // Load registers on mount
  useEffect(() => {
    loadRegisters();
  }, [filter]);

  const loadRegisters = async () => {
    try {
      setLoading(true);
      const statusFilter = filter === "all" ? undefined : filter;
      const data = await fetchPurchaseRegisters(statusFilter);
      setRegisters(data);
    } catch (error) {
      console.error("Error loading purchase registers:", error);
    } finally {
      setLoading(false);
    }
  };

  const handleSave = async () => {
    if (!supplierRuc || !supplierName || taxableBase + nonTaxable === 0) {
      alert("Ingrese datos requeridos: RUC, Razón Social y montos");
      return;
    }

    try {
      const total = taxableBase + igv + nonTaxable - retention;
      await createPurchaseRegister({
        document_type: docType,
        series: series || undefined,
        number: number || undefined,
        document_date: new Date(docDate).toISOString(),
        supplier_ruc: supplierRuc,
        supplier_name: supplierName,
        currency,
        taxable_base: taxableBase,
        igv,
        non_taxable: nonTaxable,
        total,
        retention: retention || undefined,
        cost_center: costCenter || undefined,
      });

      alert("Registro de compra creado exitosamente");
      // Clear form
      setSupplierRuc("");
      setSupplierName("");
      setSeries("");
      setNumber("");
      setTaxableBase(0);
      setIgv(0);
      setNonTaxable(0);
      setRetention(0);
      setCostCenter("");
      // Reload
      loadRegisters();
    } catch (error) {
      alert(`Error: ${(error as Error).message}`);
    }
  };

  const total = taxableBase + igv + nonTaxable - retention;

  return (
    <WindowShell title="Registro de Compras / Recibo por Honorarios"
      toolbar={<>
        <button className={btnPrimary} onClick={handleSave}><Save className="h-3.5 w-3.5" />Registrar</button>
        <button className={btn} onClick={loadRegisters}><RefreshCw className="h-3.5 w-3.5" />Recargar</button>
        <select className={inp} value={filter} onChange={(e) => setFilter(e.target.value as any)} style={{ maxWidth: "120px" }}>
          <option value="all">Todos</option>
          <option value="draft">Borrador</option>
          <option value="registered">Registrado</option>
        </select>
      </>}>
      
      {/* Input Section */}
      <div className="grid grid-cols-4 gap-3 mb-4 p-3 bg-slate-50 rounded">
        <Field label="Tipo Doc.">
          <select className={inp} value={docType} onChange={(e) => setDocType(e.target.value)}>
            <option>Factura</option>
            <option>Boleta</option>
            <option>Recibo x Honorarios</option>
            <option>Nota Crédito</option>
          </select>
        </Field>
        <Field label="Serie"><input className={inp} value={series} onChange={(e) => setSeries(e.target.value)} /></Field>
        <Field label="Número"><input className={inp} value={number} onChange={(e) => setNumber(e.target.value)} /></Field>
        <Field label="Fecha Emisión"><input className={inp} type="date" value={docDate} onChange={(e) => setDocDate(e.target.value)} /></Field>
        <Field label="Proveedor RUC/DNI"><input className={inp} value={supplierRuc} onChange={(e) => setSupplierRuc(e.target.value)} placeholder="12345678901" /></Field>
        <Field label="Razón Social" className="col-span-2"><input className={inp} value={supplierName} onChange={(e) => setSupplierName(e.target.value)} /></Field>
        <Field label="Moneda"><select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}>
          <option value="PEN">PEN</option>
          <option value="USD">USD</option>
        </select></Field>

        <Field label="Base Imponible"><input className={inp} type="number" value={taxableBase} onChange={(e) => setTaxableBase(parseFloat(e.target.value) || 0)} /></Field>
        <Field label="IGV"><input className={inp} type="number" value={igv} onChange={(e) => setIgv(parseFloat(e.target.value) || 0)} /></Field>
        <Field label="No Gravado"><input className={inp} type="number" value={nonTaxable} onChange={(e) => setNonTaxable(parseFloat(e.target.value) || 0)} /></Field>
        <Field label="Retención 4ta / Detracción"><input className={inp} type="number" value={retention} onChange={(e) => setRetention(parseFloat(e.target.value) || 0)} /></Field>
        <Field label="Centro Costo" className="col-span-2"><select className={inp} value={costCenter} onChange={(e) => setCostCenter(e.target.value)}>
          <option value="">-- Seleccionar --</option>
          <option value="Administración">Administración</option>
          <option value="Ventas">Ventas</option>
          <option value="Servicios">Servicios</option>
          <option value="Operaciones">Operaciones</option>
        </select></Field>

        <div className="col-span-4 text-right font-semibold text-slate-700">
          Total: <span className="text-lg font-mono">{total.toFixed(2)}</span>
        </div>
      </div>

      {/* Registers List */}
      <div className="mt-4">
        <div className="overflow-auto max-h-96 border border-slate-200 rounded">
          <table className="w-full text-sm">
            <thead className="sticky top-0 bg-slate-100 border-b">
              <tr>
                <th className="px-3 py-2 text-left">Tipo</th>
                <th className="px-3 py-2 text-left">Series</th>
                <th className="px-3 py-2 text-left">RUC</th>
                <th className="px-3 py-2 text-left">Proveedor</th>
                <th className="px-3 py-2 text-right">Base</th>
                <th className="px-3 py-2 text-right">IGV</th>
                <th className="px-3 py-2 text-right">Total</th>
                <th className="px-3 py-2 text-center">Estado</th>
              </tr>
            </thead>
            <tbody>
              {loading ? (
                <tr><td colSpan={8} className="px-3 py-2 text-center text-slate-500">Cargando...</td></tr>
              ) : registers.length === 0 ? (
                <tr><td colSpan={8} className="px-3 py-2 text-center text-slate-500">Sin registros</td></tr>
              ) : (
                registers.map((reg) => (
                  <tr key={reg.id} className="border-b hover:bg-slate-50 cursor-pointer">
                    <td className="px-3 py-2 text-xs">{reg.document_type}</td>
                    <td className="px-3 py-2 text-xs">{reg.series || "-"}</td>
                    <td className="px-3 py-2 text-xs font-mono">{reg.supplier_ruc}</td>
                    <td className="px-3 py-2 text-xs">{reg.supplier_name}</td>
                    <td className="px-3 py-2 text-right text-xs font-mono">{reg.taxable_base.toFixed(2)}</td>
                    <td className="px-3 py-2 text-right text-xs font-mono">{reg.igv.toFixed(2)}</td>
                    <td className="px-3 py-2 text-right text-xs font-mono font-semibold">{reg.total.toFixed(2)}</td>
                    <td className="px-3 py-2 text-center">
                      <span className={`text-xs px-2 py-1 rounded ${reg.status === 'registered' ? 'bg-green-100 text-green-700' : 'bg-blue-100 text-blue-700'}`}>
                        {reg.status === 'registered' ? 'Registrado' : 'Borrador'}
                      </span>
                    </td>
                  </tr>
                ))
              )}
            </tbody>
          </table>
        </div>
      </div>
    </WindowShell>
  );
}
