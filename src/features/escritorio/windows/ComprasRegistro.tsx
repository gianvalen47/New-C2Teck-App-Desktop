import { useCallback, useEffect, useMemo, useState } from "react";
import {
  Calendar,
  FileText,
  LogOut,
  Pencil,
  Plus,
  RefreshCw,
  Save,
  Search,
  Trash2,
} from "lucide-react";
import { toast } from "sonner";
import {
  createPurchaseRegister,
  deletePurchaseRegister,
  fetchPurchaseRegisters,
  type PurchaseRegister,
  updatePurchaseRegister,
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

type RegistroFormProps = {
  row?: PurchaseRegister;
  onClose: () => void;
  onSaved: () => void;
};

function RegistroForm({ row, onClose, onSaved }: RegistroFormProps) {
  const isNew = !row;
  const [saving, setSaving] = useState(false);

  const [documentType, setDocumentType] = useState(row?.document_type ?? "FACTURA");
  const [series, setSeries] = useState(row?.series ?? "");
  const [number, setNumber] = useState(row?.number ?? "");
  const [documentDate, setDocumentDate] = useState((row?.document_date ?? new Date().toISOString()).slice(0, 10));
  const [receiptDate, setReceiptDate] = useState((row?.receipt_date ?? row?.document_date ?? new Date().toISOString()).slice(0, 10));
  const [supplierRuc, setSupplierRuc] = useState(row?.supplier_ruc ?? "");
  const [supplierName, setSupplierName] = useState(row?.supplier_name ?? "");
  const [currency, setCurrency] = useState(row?.currency ?? "PEN");
  const [taxableBase, setTaxableBase] = useState(String(row?.taxable_base ?? 0));
  const [igv, setIgv] = useState(String(row?.igv ?? 0));
  const [nonTaxable, setNonTaxable] = useState(String(row?.non_taxable ?? 0));
  const [retention, setRetention] = useState(String(row?.retention ?? 0));
  const [costCenter, setCostCenter] = useState(row?.cost_center ?? "");
  const [reference, setReference] = useState(row?.reference ?? "");
  const [description, setDescription] = useState(row?.description ?? "");

  const total = useMemo(() => {
    const base = Number(taxableBase) || 0;
    const tax = Number(igv) || 0;
    const non = Number(nonTaxable) || 0;
    const ret = Number(retention) || 0;
    return Number((base + tax + non - ret).toFixed(2));
  }, [taxableBase, igv, nonTaxable, retention]);

  const handleSave = async () => {
    if (!supplierName.trim() || !supplierRuc.trim()) {
      toast.error("Proveedor y RUC son obligatorios");
      return;
    }

    const payload = {
      document_type: documentType,
      series: series.trim() || undefined,
      number: number.trim() || undefined,
      document_date: documentDate,
      receipt_date: receiptDate,
      supplier_ruc: supplierRuc.trim(),
      supplier_name: supplierName.trim(),
      currency,
      taxable_base: Number(taxableBase) || 0,
      igv: Number(igv) || 0,
      non_taxable: Number(nonTaxable) || 0,
      total,
      retention: Number(retention) || 0,
      cost_center: costCenter.trim() || undefined,
      reference: reference.trim() || undefined,
      description: description.trim() || undefined,
    };

    setSaving(true);
    try {
      if (isNew) {
        await createPurchaseRegister(payload);
        toast.success("Registro de compra creado");
      } else {
        await updatePurchaseRegister(row!.id, payload);
        toast.success("Registro de compra actualizado");
      }
      onSaved();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo guardar el registro");
    } finally {
      setSaving(false);
    }
  };

  return (
    <div className="h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0">
        <button className={btnPrimary} onClick={handleSave} disabled={saving}><Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Grabar"}</button>
        <button className={btn} onClick={onClose}>Deshacer</button>
        <button className={iconBtn} title="Salir" onClick={onClose}><LogOut className="h-4 w-4" /></button>
        <div className="ml-2 text-[11.5px] font-semibold text-slate-700">{isNew ? "REGISTRAR COMPRA" : "ACTUALIZAR COMPRA"}</div>
      </div>

      <div className="p-3 overflow-auto min-h-0">
        <div className="grid grid-cols-12 gap-2 max-w-5xl">
          <Field label="Tipo Doc" className="col-span-3">
            <select className={inp} value={documentType} onChange={(e) => setDocumentType(e.target.value)}>
              <option value="FACTURA">FACTURA</option>
              <option value="BOLETA">BOLETA</option>
              <option value="R.HONORARIO">R.HONORARIO</option>
              <option value="NC">NOTA CRÉDITO</option>
            </select>
          </Field>
          <Field label="Serie" className="col-span-2"><input className={inp} value={series} onChange={(e) => setSeries(e.target.value)} /></Field>
          <Field label="Número" className="col-span-2"><input className={`${inp} font-mono`} value={number} onChange={(e) => setNumber(e.target.value)} /></Field>
          <Field label="F. Documento" className="col-span-2"><input className={inp} type="date" value={documentDate} onChange={(e) => setDocumentDate(e.target.value)} /></Field>
          <Field label="F. Recepción" className="col-span-3"><input className={inp} type="date" value={receiptDate} onChange={(e) => setReceiptDate(e.target.value)} /></Field>

          <Field label="RUC Proveedor" className="col-span-3"><input className={`${inp} font-mono`} value={supplierRuc} onChange={(e) => setSupplierRuc(e.target.value)} /></Field>
          <Field label="Proveedor" className="col-span-6"><input className={inp} value={supplierName} onChange={(e) => setSupplierName(e.target.value)} /></Field>
          <Field label="Moneda" className="col-span-3">
            <select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}>
              <option value="PEN">PEN</option>
              <option value="USD">USD</option>
            </select>
          </Field>

          <Field label="Base Imponible" className="col-span-2"><input className={`${inp} font-mono`} value={taxableBase} onChange={(e) => setTaxableBase(e.target.value)} /></Field>
          <Field label="IGV" className="col-span-2"><input className={`${inp} font-mono`} value={igv} onChange={(e) => setIgv(e.target.value)} /></Field>
          <Field label="No Gravado" className="col-span-2"><input className={`${inp} font-mono`} value={nonTaxable} onChange={(e) => setNonTaxable(e.target.value)} /></Field>
          <Field label="Retención" className="col-span-2"><input className={`${inp} font-mono`} value={retention} onChange={(e) => setRetention(e.target.value)} /></Field>
          <Field label="Centro Costo" className="col-span-2"><input className={inp} value={costCenter} onChange={(e) => setCostCenter(e.target.value)} /></Field>
          <Field label="Total" className="col-span-2"><input className={`${inp} font-mono bg-slate-100 font-semibold`} value={total.toFixed(2)} readOnly /></Field>

          <Field label="Referencia" className="col-span-4"><input className={inp} value={reference} onChange={(e) => setReference(e.target.value)} /></Field>
          <Field label="Descripción" className="col-span-8"><input className={inp} value={description} onChange={(e) => setDescription(e.target.value)} /></Field>
        </div>
      </div>
    </div>
  );
}

export function RegistroComprasList() {
  const [rows, setRows] = useState<PurchaseRegister[]>([]);
  const [loading, setLoading] = useState(false);
  const [searched, setSearched] = useState(false);

  const [status, setStatus] = useState("");
  const [documentType, setDocumentType] = useState("");
  const [search, setSearch] = useState("");

  const [selected, setSelected] = useState<PurchaseRegister | null>(null);
  const [showForm, setShowForm] = useState(false);
  const [isNew, setIsNew] = useState(false);

  const load = useCallback(async () => {
    setLoading(true);
    try {
      const data = await fetchPurchaseRegisters(status || undefined, documentType || undefined);
      setRows(data);
      setSearched(true);
    } catch (e: any) {
      toast.error(e.message ?? "Error al cargar registros de compra");
    } finally {
      setLoading(false);
    }
  }, [status, documentType]);

  useEffect(() => {
    load();
  }, [load]);

  useEffect(() => {
    const onKeyDown = (e: KeyboardEvent) => {
      const target = e.target as HTMLElement | null;
      if (target && ["INPUT", "TEXTAREA", "SELECT"].includes(target.tagName)) return;

      if (e.key === "F5") {
        e.preventDefault();
        load();
      }
      if ((e.ctrlKey || e.metaKey) && e.key.toLowerCase() === "n") {
        e.preventDefault();
        setIsNew(true);
        setShowForm(true);
      }
    };

    window.addEventListener("keydown", onKeyDown);
    return () => window.removeEventListener("keydown", onKeyDown);
  }, [load]);

  const [sortBy, setSortBy] = useState<{ col: string; asc: boolean }>({ col: "document_date", asc: false });
  const rowsView = useMemo(() => {
    const q = search.trim().toLowerCase();
    let out = q
      ? rows.filter((r) =>
          [r.supplier_name, r.supplier_ruc, r.series, r.number, r.reference, r.description]
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
    if (!confirm(`¿Eliminar registro ${selected.series || ""}-${selected.number || ""}?`)) return;
    try {
      await deletePurchaseRegister(selected.id);
      toast.success("Registro eliminado");
      setSelected(null);
      await load();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo eliminar el registro");
    }
  };

  if (showForm) {
    return (
      <RegistroForm
        row={isNew ? undefined : selected ?? undefined}
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
        <button className={iconBtn} title="Nuevo registro" onClick={() => { setIsNew(true); setShowForm(true); }}><Plus className="h-4 w-4" /></button>
        <button className={iconBtn} title="Editar registro" disabled={!selected} onClick={() => { setIsNew(false); setShowForm(true); }}><Pencil className="h-4 w-4" /></button>
        <button className={iconBtn} title="Eliminar registro" disabled={!selected} onClick={handleDelete}><Trash2 className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar" onClick={load}><RefreshCw className="h-4 w-4" /></button>
        <button className={iconBtn} title="Salir" onClick={() => toast.info("Use la X superior para cerrar la ventana")}><LogOut className="h-4 w-4" /></button>
      </div>

      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="Estado" className="w-28">
          <select className={inp} value={status} onChange={(e) => setStatus(e.target.value)}>
            <option value="">(Todos)</option>
            <option value="draft">GENERADO</option>
            <option value="approved">APROBADO</option>
            <option value="cancelled">ANULADO</option>
          </select>
        </Field>
        <Field label="Tipo Doc" className="w-36">
          <select className={inp} value={documentType} onChange={(e) => setDocumentType(e.target.value)}>
            <option value="">(Todos)</option>
            <option value="FACTURA">FACTURA</option>
            <option value="BOLETA">BOLETA</option>
            <option value="R.HONORARIO">R.HONORARIO</option>
            <option value="NC">NOTA CRÉDITO</option>
          </select>
        </Field>
        <Field label="Buscar" className="w-72">
          <input className={inp} value={search} onChange={(e) => setSearch(e.target.value)} placeholder="Proveedor, RUC, serie o referencia" />
        </Field>
        <button className={btnPrimary} onClick={load} disabled={loading}><Search className="h-3.5 w-3.5" />{loading ? "Buscando..." : "Buscar"}</button>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full text-[11.5px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
              <tr>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'series' ? { col: 'series', asc: !prev.asc } : { col: 'series', asc: true })}>Documento {sortBy.col === 'series' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'document_date' ? { col: 'document_date', asc: !prev.asc } : { col: 'document_date', asc: true })}>F. Doc {sortBy.col === 'document_date' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">F. Recepción</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">RUC</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'supplier_name' ? { col: 'supplier_name', asc: !prev.asc } : { col: 'supplier_name', asc: true })}>Proveedor {sortBy.col === 'supplier_name' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Mon.</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'total' ? { col: 'total', asc: !prev.asc } : { col: 'total', asc: false })}>Total {sortBy.col === 'total' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Estado</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Referencia</th>
              </tr>
            </thead>
            <tbody>
              {rowsView.length === 0 ? (
                <tr>
                  <td colSpan={9} className="text-center py-8 text-slate-400 text-[11px]">
                    {loading ? "Cargando..." : searched ? "Sin registros para los filtros" : "Use los filtros y pulse Buscar"}
                  </td>
                </tr>
              ) : rowsView.map((r, i) => {
                const isSel = selected?.id === r.id;
                return (
                  <tr
                    key={r.id}
                    onClick={() => setSelected(r)}
                    onDoubleClick={() => { setSelected(r); setIsNew(false); setShowForm(true); }}
                    className={[
                      "cursor-pointer border-b border-slate-200",
                      i % 2 ? "bg-[#F6F9FC]" : "bg-white",
                      isSel ? "!bg-[#D6E4F4] outline outline-1 outline-[#3E5B7A]" : "hover:bg-[#E8F0F8]/60",
                    ].join(" ")}
                  >
                    <td className="px-2 py-1 text-center border-r border-slate-200 font-mono font-semibold">{`${r.document_type}${r.series ? ` ${r.series}` : ""}${r.number ? `-${r.number}` : ""}`}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200 whitespace-nowrap">{r.document_date ? new Date(r.document_date).toLocaleDateString("es-PE") : ""}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200 whitespace-nowrap">{r.receipt_date ? new Date(r.receipt_date).toLocaleDateString("es-PE") : ""}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200 font-mono">{r.supplier_ruc}</td>
                    <td className="px-2 py-1 border-r border-slate-200 max-w-[260px] truncate">{r.supplier_name}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">{r.currency}</td>
                    <td className="px-2 py-1 text-right border-r border-slate-200 font-mono font-semibold">{r.total.toFixed(2)}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200 uppercase">{r.status}</td>
                    <td className="px-2 py-1 border-r border-slate-200 max-w-[220px] truncate">{r.reference || "-"}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      </div>

      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-[11px] text-slate-700 text-center font-medium flex items-center justify-center whitespace-nowrap overflow-hidden">
        Registros : {rowsView.length}
      </div>
    </div>
  );
}
