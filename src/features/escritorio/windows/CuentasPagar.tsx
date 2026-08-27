import { useCallback, useEffect, useMemo, useState } from "react";
import {
  BadgeDollarSign,
  Check,
  Clock3,
  LogOut,
  RefreshCw,
  Search,
  WalletCards,
  X,
} from "lucide-react";
import { toast } from "sonner";
import { fetchPurchaseRegisters, type PurchaseRegister, updatePurchaseRegister } from "@/lib/sigecoom-api";

import { inp, btn, btnPrimary, iconBtn, actionBtn, squareIconBtn, tbSep } from "./uiStyles";

function Field({ label, className = "", children }: { label: string; className?: string; children: React.ReactNode }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium">{label}</span>
      {children}
    </label>
  );
}

function statusText(status: string) {
  if (status === "draft") return "PENDIENTE";
  if (status === "submitted") return "PROGRAMADO";
  if (status === "approved") return "PAGADO";
  if (status === "cancelled") return "ANULADO";
  return status.toUpperCase();
}

function statusClass(status: string) {
  if (status === "draft") return "text-amber-700 bg-amber-50";
  if (status === "submitted") return "text-sky-700 bg-sky-50";
  if (status === "approved") return "text-emerald-700 bg-emerald-50";
  if (status === "cancelled") return "text-red-700 bg-red-50";
  return "text-slate-700 bg-slate-50";
}

export function CuentasPagarList() {
  const [rows, setRows] = useState<PurchaseRegister[]>([]);
  const [loading, setLoading] = useState(false);
  const [searched, setSearched] = useState(false);
  const [search, setSearch] = useState("");
  const [statusFilter, setStatusFilter] = useState("");
  const [selected, setSelected] = useState<PurchaseRegister | null>(null);
  const [showDetail, setShowDetail] = useState(false);

  const load = useCallback(async () => {
    setLoading(true);
    try {
      const data = await fetchPurchaseRegisters();
      const payables = data.filter((r) => r.status !== "cancelled");
      setRows(payables);
      setSearched(true);
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo cargar cuentas por pagar");
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    load();
  }, [load]);

  const [sortBy, setSortBy] = useState<{ col: string; asc: boolean }>({ col: 'document', asc: true });

  const rowsView = useMemo(() => {
    const q = search.trim().toLowerCase();
    let out = rows
      .filter((r) => (statusFilter ? r.status === statusFilter : true))
      .filter((r) => {
        if (!q) return true;
        return [r.series, r.number, r.supplier_name, r.supplier_ruc, r.reference]
          .filter(Boolean)
          .some((v) => String(v).toLowerCase().includes(q));
      });
    const col = sortBy.col;
    if (col) {
      out = [...out];
      out.sort((a: any, b: any) => {
        let va: any = null;
        let vb: any = null;
        if (col === 'document') {
          va = `${a.document_type} ${a.series || ''}-${a.number || ''}`;
          vb = `${b.document_type} ${b.series || ''}-${b.number || ''}`;
        } else if (col === 'date') {
          va = new Date(a.document_date).getTime();
          vb = new Date(b.document_date).getTime();
        } else {
          va = a[col];
          vb = b[col];
        }
        if (va == null && vb == null) return 0;
        if (va == null) return sortBy.asc ? -1 : 1;
        if (vb == null) return sortBy.asc ? 1 : -1;
        if (typeof va === 'number' && typeof vb === 'number') return sortBy.asc ? va - vb : vb - va;
        return sortBy.asc ? String(va).localeCompare(String(vb)) : String(vb).localeCompare(String(va));
      });
    }
    return out;
  }, [rows, search, statusFilter, sortBy]);

  const totalPendiente = useMemo(
    () => rowsView.filter((r) => r.status !== "approved").reduce((acc, r) => acc + r.total, 0),
    [rowsView]
  );

  const markStatus = async (status: "submitted" | "approved" | "cancelled") => {
    if (!selected) return;
    try {
      await updatePurchaseRegister(selected.id, { status });
      toast.success(`Documento ${statusText(status).toLowerCase()}`);
      await load();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo actualizar estado");
    }
  };

  if (showDetail && selected) {
    return (
      <div className="h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
        <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0">
          <button className={btnPrimary} onClick={() => setShowDetail(false)}><Search className="h-3.5 w-3.5" />Volver</button>
          <button className={iconBtn} title="Salir" onClick={() => toast.info("Use la X superior para cerrar la ventana")}><LogOut className="h-4 w-4" /></button>
          <div className="ml-2 text-[11.5px] font-semibold text-slate-700">Detalle de Cuenta por Pagar</div>
        </div>
        <div className="p-3 overflow-auto min-h-0">
          <div className="grid grid-cols-12 gap-2 max-w-5xl text-[12px]">
            <Field label="Documento" className="col-span-4"><input className={`${inp} bg-slate-100`} readOnly value={`${selected.document_type} ${selected.series || ""}-${selected.number || ""}`} /></Field>
            <Field label="Fecha" className="col-span-2"><input className={`${inp} bg-slate-100`} readOnly value={new Date(selected.document_date).toLocaleDateString("es-PE")} /></Field>
            <Field label="Proveedor" className="col-span-4"><input className={`${inp} bg-slate-100`} readOnly value={selected.supplier_name} /></Field>
            <Field label="RUC" className="col-span-2"><input className={`${inp} bg-slate-100 font-mono`} readOnly value={selected.supplier_ruc} /></Field>
            <Field label="Moneda" className="col-span-2"><input className={`${inp} bg-slate-100`} readOnly value={selected.currency} /></Field>
            <Field label="Total" className="col-span-2"><input className={`${inp} bg-slate-100 font-mono`} readOnly value={selected.total.toFixed(2)} /></Field>
            <Field label="Estado" className="col-span-2"><input className={`${inp} bg-slate-100`} readOnly value={statusText(selected.status)} /></Field>
            <Field label="Referencia" className="col-span-6"><input className={`${inp} bg-slate-100`} readOnly value={selected.reference || "-"} /></Field>
            <Field label="Descripción" className="col-span-12"><input className={`${inp} bg-slate-100`} readOnly value={selected.description || "-"} /></Field>
          </div>
        </div>
      </div>
    );
  }

  return (
    <div className="h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Programar pago" disabled={!selected} onClick={() => markStatus("submitted")}><Clock3 className="h-4 w-4" /></button>
        <button className={iconBtn} title="Marcar como pagado" disabled={!selected} onClick={() => markStatus("approved")}><Check className="h-4 w-4" /></button>
        <button className={iconBtn} title="Anular" disabled={!selected} onClick={() => markStatus("cancelled")}><X className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar" onClick={load}><RefreshCw className="h-4 w-4" /></button>
        <button className={iconBtn} title="Salir" onClick={() => toast.info("Use la X superior para cerrar la ventana")}><LogOut className="h-4 w-4" /></button>
      </div>

      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="Estado" className="w-32">
          <select className={inp} value={statusFilter} onChange={(e) => setStatusFilter(e.target.value)}>
            <option value="">(Todos)</option>
            <option value="draft">PENDIENTE</option>
            <option value="submitted">PROGRAMADO</option>
            <option value="approved">PAGADO</option>
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
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'document' ? { col: 'document', asc: !prev.asc } : { col: 'document', asc: true })}>Doc {sortBy.col === 'document' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'date' ? { col: 'date', asc: !prev.asc } : { col: 'date', asc: false })}>Fecha {sortBy.col === 'date' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 border-r border-slate-300/70 font-semibold whitespace-nowrap">Proveedor</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">RUC</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Mon.</th>
                <th className="px-2 py-1 text-right border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev.col === 'total' ? { col: 'total', asc: !prev.asc } : { col: 'total', asc: false })}>Total {sortBy.col === 'total' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">Estado</th>
                <th className="px-2 py-1 border-r border-slate-300/70 font-semibold whitespace-nowrap">Referencia</th>
              </tr>
            </thead>
            <tbody>
              {rowsView.length === 0 ? (
                <tr>
                  <td colSpan={8} className="text-center py-8 text-slate-400 text-[11px]">
                    {loading ? "Cargando..." : searched ? "Sin cuentas por pagar" : "Cargando..."}
                  </td>
                </tr>
              ) : rowsView.map((r, i) => {
                const isSel = selected?.id === r.id;
                return (
                  <tr
                    key={r.id}
                    onClick={() => setSelected(r)}
                    onDoubleClick={() => { setSelected(r); setShowDetail(true); }}
                    className={[
                      "cursor-pointer border-b border-slate-200",
                      i % 2 ? "bg-[#F6F9FC]" : "bg-white",
                      isSel ? "!bg-[#D6E4F4] outline outline-1 outline-[#3E5B7A]" : "hover:bg-[#E8F0F8]/60",
                    ].join(" ")}
                  >
                    <td className="px-2 py-1 text-center border-r border-slate-200 font-mono font-semibold">{`${r.document_type} ${r.series || ""}-${r.number || ""}`}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200 whitespace-nowrap">{new Date(r.document_date).toLocaleDateString("es-PE")}</td>
                    <td className="px-2 py-1 border-r border-slate-200 max-w-[260px] truncate">{r.supplier_name}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200 font-mono">{r.supplier_ruc}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">{r.currency}</td>
                    <td className="px-2 py-1 text-right border-r border-slate-200 font-mono font-semibold">{r.total.toFixed(2)}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200">
                      <span className={`inline-block px-1.5 py-0.5 rounded text-[10px] font-bold ${statusClass(r.status)}`}>
                        {statusText(r.status)}
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

      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-1 text-[11px] text-slate-700 font-medium flex items-center justify-between gap-3 overflow-hidden">
        <span className="whitespace-nowrap">Registros : {rowsView.length}</span>
        <span className="whitespace-nowrap text-right truncate">Pendiente total: {totalPendiente.toFixed(2)}</span>
      </div>
    </div>
  );
}
