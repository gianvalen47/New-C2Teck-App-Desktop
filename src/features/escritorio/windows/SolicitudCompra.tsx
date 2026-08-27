import { useCallback, useEffect, useMemo, useState } from "react";
import {
  Check,
  ClipboardList,
  LogOut,
  Pencil,
  Plus,
  RefreshCw,
  Save,
  Search,
  Send,
  Trash2,
  X,
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

function estadoText(status: string) {
  if (status === "draft") return "BORRADOR";
  if (status === "submitted") return "ENVIADO";
  if (status === "approved") return "APROBADO";
  if (status === "cancelled") return "ANULADO";
  return status.toUpperCase();
}

function estadoClass(status: string) {
  if (status === "draft") return "text-blue-700 bg-blue-50";
  if (status === "submitted") return "text-amber-700 bg-amber-50";
  if (status === "approved") return "text-emerald-700 bg-emerald-50";
  if (status === "cancelled") return "text-red-700 bg-red-50";
  return "text-slate-700 bg-slate-50";
}

type SolicitudFormProps = {
  row?: PurchaseRegister;
  onClose: () => void;
  onSaved: () => void;
};

function SolicitudForm({ row, onClose, onSaved }: SolicitudFormProps) {
  const isNew = !row;
  const [saving, setSaving] = useState(false);

  const [series, setSeries] = useState(row?.series ?? "SC");
  const [number, setNumber] = useState(row?.number ?? "");
  const [documentDate, setDocumentDate] = useState((row?.document_date ?? new Date().toISOString()).slice(0, 10));
  const [supplierRuc, setSupplierRuc] = useState(row?.supplier_ruc ?? "");
  const [supplierName, setSupplierName] = useState(row?.supplier_name ?? "");
  const [currency, setCurrency] = useState(row?.currency ?? "PEN");
  const [reference, setReference] = useState(row?.reference ?? "");
  const [description, setDescription] = useState(row?.description ?? "");
  const [amount, setAmount] = useState(String(row?.total ?? 0));

  const handleSave = async () => {
    if (!supplierName.trim()) {
      toast.error("Proveedor es obligatorio");
      return;
    }

    const payload = {
      document_type: "SOLICITUD",
      series: series.trim() || "SC",
      number: number.trim() || undefined,
      document_date: documentDate,
      receipt_date: documentDate,
      supplier_ruc: supplierRuc.trim() || "00000000000",
      supplier_name: supplierName.trim(),
      currency,
      taxable_base: Number(amount) || 0,
      igv: 0,
      non_taxable: 0,
      total: Number(amount) || 0,
      retention: 0,
      reference: reference.trim() || undefined,
      description: description.trim() || undefined,
    };

    setSaving(true);
    try {
      if (isNew) {
        await createPurchaseRegister(payload);
        toast.success("Solicitud creada");
      } else {
        await updatePurchaseRegister(row!.id, payload);
        toast.success("Solicitud actualizada");
      }
      onSaved();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo guardar la solicitud");
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
        <div className="ml-2 text-[11.5px] font-semibold text-slate-700">{isNew ? "NUEVA SOLICITUD DE COMPRA" : "EDITAR SOLICITUD DE COMPRA"}</div>
      </div>

      <div className="p-3 overflow-auto min-h-0">
        <div className="grid grid-cols-12 gap-2 max-w-5xl">
          <Field label="Serie" className="col-span-2"><input className={inp} value={series} onChange={(e) => setSeries(e.target.value)} /></Field>
          <Field label="Número" className="col-span-2"><input className={`${inp} font-mono`} value={number} onChange={(e) => setNumber(e.target.value)} /></Field>
          <Field label="Fecha" className="col-span-3"><input className={inp} type="date" value={documentDate} onChange={(e) => setDocumentDate(e.target.value)} /></Field>
          <Field label="Moneda" className="col-span-2">
            <select className={inp} value={currency} onChange={(e) => setCurrency(e.target.value)}>
              <option value="PEN">PEN</option>
              <option value="USD">USD</option>
            </select>
          </Field>
          <Field label="Monto" className="col-span-3"><input className={`${inp} font-mono`} value={amount} onChange={(e) => setAmount(e.target.value)} /></Field>

          <Field label="RUC Proveedor" className="col-span-3"><input className={`${inp} font-mono`} value={supplierRuc} onChange={(e) => setSupplierRuc(e.target.value)} /></Field>
          <Field label="Proveedor" className="col-span-5"><input className={inp} value={supplierName} onChange={(e) => setSupplierName(e.target.value)} /></Field>
          <Field label="Referencia" className="col-span-4"><input className={inp} value={reference} onChange={(e) => setReference(e.target.value)} /></Field>

          <Field label="Descripción" className="col-span-12"><input className={inp} value={description} onChange={(e) => setDescription(e.target.value)} /></Field>
        </div>
      </div>
    </div>
  );
}

export function SolicitudCompraList() {
  const [rows, setRows] = useState<PurchaseRegister[]>([]);
  const [loading, setLoading] = useState(false);
  const [searched, setSearched] = useState(false);
  const [statusFilter, setStatusFilter] = useState("");
  const [search, setSearch] = useState("");

  const [selected, setSelected] = useState<PurchaseRegister | null>(null);
  const [showForm, setShowForm] = useState(false);
  const [isNew, setIsNew] = useState(false);
  const [sortBy, setSortBy] = useState<{ col: string; asc: boolean } | null>(null);

  const load = useCallback(async () => {
    setLoading(true);
    try {
      const data = await fetchPurchaseRegisters(statusFilter || undefined, "SOLICITUD");
      setRows(data);
      setSearched(true);
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo cargar solicitudes");
    } finally {
      setLoading(false);
    }
  }, [statusFilter]);

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

  const rowsView = useMemo(() => {
    const q = search.trim().toLowerCase();
    const filtered = !q
      ? rows
      : rows.filter((r) =>
          [r.series, r.number, r.supplier_name, r.supplier_ruc, r.reference, r.description]
            .filter(Boolean)
            .some((v) => String(v).toLowerCase().includes(q))
        );
    const sorted = [...filtered];
    if (!sortBy) return sorted;
    sorted.sort((a, b) => {
      const getValue = (row: PurchaseRegister, col: string) => {
        switch (col) {
          case "document":
            return `${row.series || "SC"}-${row.number || ""}`;
          case "date":
            return row.document_date ? new Date(row.document_date).getTime() : 0;
          case "supplier_name":
            return row.supplier_name ?? "";
          case "supplier_ruc":
            return row.supplier_ruc ?? "";
          case "currency":
            return row.currency ?? "";
          case "total":
            return row.total ?? 0;
          case "status":
            return row.status ?? "";
          case "reference":
            return row.reference ?? "";
          default:
            return "";
        }
      };
      const va = getValue(a, sortBy.col);
      const vb = getValue(b, sortBy.col);
      if (typeof va === "number" && typeof vb === "number") return sortBy.asc ? va - vb : vb - va;
      return sortBy.asc ? String(va).localeCompare(String(vb)) : String(vb).localeCompare(String(va));
    });
    return sorted;
  }, [rows, search, sortBy]);

  const changeStatus = async (nextStatus: "submitted" | "approved" | "cancelled") => {
    if (!selected) return;
    try {
      await updatePurchaseRegister(selected.id, { status: nextStatus });
      toast.success(`Solicitud ${estadoText(nextStatus).toLowerCase()}`);
      await load();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo actualizar estado");
    }
  };

  const handleDelete = async () => {
    if (!selected) return;
    if (!confirm("¿Eliminar esta solicitud?")) return;
    try {
      await deletePurchaseRegister(selected.id);
      toast.success("Solicitud eliminada");
      setSelected(null);
      await load();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo eliminar la solicitud");
    }
  };

  if (showForm) {
    return (
      <SolicitudForm
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
        <button className={iconBtn} title="Nueva solicitud" onClick={() => { setIsNew(true); setShowForm(true); }}><Plus className="h-4 w-4" /></button>
        <button className={iconBtn} title="Editar solicitud" disabled={!selected} onClick={() => { setIsNew(false); setShowForm(true); }}><Pencil className="h-4 w-4" /></button>
        <button className={iconBtn} title="Eliminar solicitud" disabled={!selected} onClick={handleDelete}><Trash2 className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Enviar solicitud" disabled={!selected} onClick={() => changeStatus("submitted")}><Send className="h-4 w-4" /></button>
        <button className={iconBtn} title="Aprobar solicitud" disabled={!selected} onClick={() => changeStatus("approved")}><Check className="h-4 w-4" /></button>
        <button className={iconBtn} title="Anular solicitud" disabled={!selected} onClick={() => changeStatus("cancelled")}><X className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar" onClick={load}><RefreshCw className="h-4 w-4" /></button>
        <button className={iconBtn} title="Salir" onClick={() => toast.info("Use la X superior para cerrar la ventana")}><LogOut className="h-4 w-4" /></button>
      </div>

      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="Estado" className="w-32">
          <select className={inp} value={statusFilter} onChange={(e) => setStatusFilter(e.target.value)}>
            <option value="">(Todos)</option>
            <option value="draft">BORRADOR</option>
            <option value="submitted">ENVIADO</option>
            <option value="approved">APROBADO</option>
            <option value="cancelled">ANULADO</option>
          </select>
        </Field>
        <Field label="Buscar" className="w-72">
          <input className={inp} value={search} onChange={(e) => setSearch(e.target.value)} placeholder="Serie, proveedor o referencia" />
        </Field>
        <button className={btnPrimary} onClick={load} disabled={loading}><Search className="h-3.5 w-3.5" />{loading ? "Buscando..." : "Buscar"}</button>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full text-[11.5px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
              <tr>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'document' ? { col: 'document', asc: !prev.asc } : { col: 'document', asc: true })}>Solicitud {sortBy?.col === 'document' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'date' ? { col: 'date', asc: !prev.asc } : { col: 'date', asc: true })}>Fecha {sortBy?.col === 'date' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'supplier_name' ? { col: 'supplier_name', asc: !prev.asc } : { col: 'supplier_name', asc: true })}>Proveedor {sortBy?.col === 'supplier_name' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'supplier_ruc' ? { col: 'supplier_ruc', asc: !prev.asc } : { col: 'supplier_ruc', asc: true })}>RUC {sortBy?.col === 'supplier_ruc' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'currency' ? { col: 'currency', asc: !prev.asc } : { col: 'currency', asc: true })}>Mon. {sortBy?.col === 'currency' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-right border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'total' ? { col: 'total', asc: !prev.asc } : { col: 'total', asc: false })}>Monto {sortBy?.col === 'total' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'status' ? { col: 'status', asc: !prev.asc } : { col: 'status', asc: true })}>Estado {sortBy?.col === 'status' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'reference' ? { col: 'reference', asc: !prev.asc } : { col: 'reference', asc: true })}>Referencia {sortBy?.col === 'reference' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
              </tr>
            </thead>
            <tbody>
              {rowsView.length === 0 ? (
                <tr>
                  <td colSpan={8} className="text-center py-8 text-slate-400 text-[11px]">
                    {loading ? "Cargando..." : searched ? "Sin solicitudes" : "Use filtros y pulse Buscar"}
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
                    <td className="px-2 py-1 text-center border-r border-slate-200 font-mono font-semibold">{`${r.series || "SC"}-${r.number || ""}`}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200 whitespace-nowrap">{r.document_date ? new Date(r.document_date).toLocaleDateString("es-PE") : ""}</td>
                    <td className="px-2 py-1 border-r border-slate-200 max-w-[260px] truncate">{r.supplier_name}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200 font-mono">{r.supplier_ruc}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">{r.currency}</td>
                    <td className="px-2 py-1 text-right border-r border-slate-200 font-mono font-semibold">{r.total.toFixed(2)}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">
                      <span className={`inline-block px-1.5 py-0.5 rounded text-[10px] font-bold ${estadoClass(r.status)}`}>
                        {estadoText(r.status)}
                      </span>
                    </td>
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
