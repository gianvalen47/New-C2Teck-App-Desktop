import { useCallback, useEffect, useMemo, useState } from "react";
import {
  LogOut,
  Pencil,
  Plane,
  Plus,
  RefreshCw,
  Save,
  Search,
  Send,
  Trash2,
} from "lucide-react";
import { toast } from "sonner";
import {
  createGasto,
  deleteGasto,
  fetchCajaChica,
  fetchGastos,
  reimburseGastos,
  submitGastos,
  type CajaChica,
  type Gasto,
  updateGasto,
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
  if (status === "pending") return "PENDIENTE";
  if (status === "submitted") return "PRESENTADO";
  if (status === "reimbursed") return "LIQUIDADO";
  if (status === "archived") return "ANULADO";
  return status.toUpperCase();
}

function estadoClass(status: string) {
  if (status === "pending") return "text-amber-700 bg-amber-50";
  if (status === "submitted") return "text-sky-700 bg-sky-50";
  if (status === "reimbursed") return "text-emerald-700 bg-emerald-50";
  if (status === "archived") return "text-red-700 bg-red-50";
  return "text-slate-700 bg-slate-50";
}

type ViaticoFormProps = {
  cajaId: string;
  gasto?: Gasto;
  onClose: () => void;
  onSaved: () => void;
};

function ViaticoForm({ cajaId, gasto, onClose, onSaved }: ViaticoFormProps) {
  const isNew = !gasto;
  const [saving, setSaving] = useState(false);

  const [fecha, setFecha] = useState((gasto?.date ?? new Date().toISOString()).slice(0, 10));
  const [personal, setPersonal] = useState("");
  const [destino, setDestino] = useState("");
  const [motivo, setMotivo] = useState(gasto?.concept ?? "VISITA TÉCNICA");
  const [tipoComprobante, setTipoComprobante] = useState(gasto?.voucher_type ?? "FACTURA");
  const [nroComprobante, setNroComprobante] = useState(gasto?.voucher_number ?? "");
  const [monto, setMonto] = useState(String(gasto?.amount ?? 0));
  const [descripcion, setDescripcion] = useState(gasto?.description ?? "");

  const handleSave = async () => {
    if (!motivo.trim()) {
      toast.error("Motivo es obligatorio");
      return;
    }

    const concept = [motivo.trim(), personal.trim(), destino.trim()].filter(Boolean).join(" | ");

    const payload = {
      date: fecha,
      concept,
      voucher_type: tipoComprobante || undefined,
      voucher_number: nroComprobante || undefined,
      amount: Number(monto) || 0,
      category: "VIATICO",
      description: descripcion.trim() || undefined,
    };

    setSaving(true);
    try {
      if (isNew) {
        await createGasto(cajaId, payload);
        toast.success("Viático registrado");
      } else {
        await updateGasto(gasto!.id, payload);
        toast.success("Viático actualizado");
      }
      onSaved();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo guardar el viático");
    } finally {
      setSaving(false);
    }
  };

  return (
    <div className="h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0">
        <button className={btnPrimary} onClick={handleSave} disabled={saving}><Save className="h-3.5 w-3.5" />{saving ? "Guardando..." : "Liquidar"}</button>
        <button className={btn} onClick={onClose}>Deshacer</button>
        <button className={iconBtn} title="Salir" onClick={onClose}><LogOut className="h-4 w-4" /></button>
        <div className="ml-2 text-[11.5px] font-semibold text-slate-700">{isNew ? "NUEVO VIÁTICO" : "EDITAR VIÁTICO"}</div>
      </div>

      <div className="p-3 overflow-auto min-h-0">
        <div className="grid grid-cols-12 gap-2 max-w-5xl">
          <Field label="Personal" className="col-span-4"><input className={inp} value={personal} onChange={(e) => setPersonal(e.target.value)} /></Field>
          <Field label="Destino" className="col-span-4"><input className={inp} value={destino} onChange={(e) => setDestino(e.target.value)} /></Field>
          <Field label="Motivo" className="col-span-4"><input className={inp} value={motivo} onChange={(e) => setMotivo(e.target.value)} /></Field>

          <Field label="Fecha" className="col-span-3"><input className={inp} type="date" value={fecha} onChange={(e) => setFecha(e.target.value)} /></Field>
          <Field label="Comprobante" className="col-span-3"><input className={inp} value={tipoComprobante} onChange={(e) => setTipoComprobante(e.target.value)} /></Field>
          <Field label="Nro Comp." className="col-span-3"><input className={inp} value={nroComprobante} onChange={(e) => setNroComprobante(e.target.value)} /></Field>
          <Field label="Monto" className="col-span-3"><input className={`${inp} font-mono`} value={monto} onChange={(e) => setMonto(e.target.value)} /></Field>

          <Field label="Descripción" className="col-span-12"><input className={inp} value={descripcion} onChange={(e) => setDescripcion(e.target.value)} /></Field>
        </div>
      </div>
    </div>
  );
}

export function PlanillaViaticosList() {
  const [cajas, setCajas] = useState<CajaChica[]>([]);
  const [cajaId, setCajaId] = useState("");
  const [rows, setRows] = useState<Gasto[]>([]);
  const [loading, setLoading] = useState(false);
  const [searched, setSearched] = useState(false);
  const [statusFilter, setStatusFilter] = useState("");
  const [search, setSearch] = useState("");
  const [adelanto, setAdelanto] = useState("0");

  const [selected, setSelected] = useState<Gasto | null>(null);
  const [showForm, setShowForm] = useState(false);
  const [isNew, setIsNew] = useState(false);
  const [sortBy, setSortBy] = useState<{ col: string; asc: boolean } | null>(null);

  const loadCajas = useCallback(async () => {
    try {
      const data = await fetchCajaChica();
      setCajas(data);
      if (!cajaId && data.length > 0) setCajaId(data[0].id);
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo cargar cajas chicas");
    }
  }, [cajaId]);

  const load = useCallback(async () => {
    if (!cajaId) return;
    setLoading(true);
    try {
      const gastos = await fetchGastos(cajaId, statusFilter || undefined);
      const viaticos = gastos.filter((g) => String(g.category || "").toUpperCase() === "VIATICO");
      setRows(viaticos);
      setSearched(true);
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo cargar viáticos");
    } finally {
      setLoading(false);
    }
  }, [cajaId, statusFilter]);

  useEffect(() => {
    loadCajas();
  }, [loadCajas]);

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
        if (cajaId) {
          setIsNew(true);
          setShowForm(true);
        }
      }
    };

    window.addEventListener("keydown", onKeyDown);
    return () => window.removeEventListener("keydown", onKeyDown);
  }, [load, cajaId]);

  const rowsView = useMemo(() => {
    const q = search.trim().toLowerCase();
    const filtered = !q
      ? rows
      : rows.filter((r) =>
          [r.concept, r.voucher_type, r.voucher_number, r.description]
            .filter(Boolean)
            .some((v) => String(v).toLowerCase().includes(q))
        );
    const sorted = [...filtered];
    if (!sortBy) return sorted;
    sorted.sort((a, b) => {
      const getValue = (row: Gasto, col: string) => {
        switch (col) {
          case "date":
            return row.date ? new Date(row.date).getTime() : 0;
          case "concept":
            return row.concept ?? "";
          case "voucher":
            return [row.voucher_type, row.voucher_number].filter(Boolean).join("-") || "";
          case "amount":
            return row.amount ?? 0;
          case "status":
            return row.status ?? "";
          case "description":
            return row.description ?? "";
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

  const totalGastado = useMemo(() => rowsView.reduce((acc, r) => acc + r.amount, 0), [rowsView]);
  const saldo = useMemo(() => (Number(adelanto) || 0) - totalGastado, [adelanto, totalGastado]);

  const selectedIds = useMemo(() => (selected ? [selected.id] : []), [selected]);

  const handleSubmit = async () => {
    if (!cajaId || selectedIds.length === 0) return;
    try {
      await submitGastos(cajaId, selectedIds);
      toast.success("Viático presentado");
      await load();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo presentar el viático");
    }
  };

  const handleReimburse = async () => {
    if (!cajaId || selectedIds.length === 0) return;
    try {
      await reimburseGastos(cajaId, selectedIds);
      toast.success("Viático liquidado");
      await load();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo liquidar el viático");
    }
  };

  const handleDelete = async () => {
    if (!selected) return;
    if (!confirm("¿Eliminar este viático?")) return;
    try {
      await deleteGasto(selected.id);
      toast.success("Viático eliminado");
      setSelected(null);
      await load();
    } catch (e: any) {
      toast.error(e.message ?? "No se pudo eliminar el viático");
    }
  };

  if (showForm && cajaId) {
    return (
      <ViaticoForm
        cajaId={cajaId}
        gasto={isNew ? undefined : selected ?? undefined}
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
        <button className={iconBtn} title="Nuevo viático" disabled={!cajaId} onClick={() => { setIsNew(true); setShowForm(true); }}><Plus className="h-4 w-4" /></button>
        <button className={iconBtn} title="Editar viático" disabled={!selected} onClick={() => { setIsNew(false); setShowForm(true); }}><Pencil className="h-4 w-4" /></button>
        <button className={iconBtn} title="Eliminar viático" disabled={!selected} onClick={handleDelete}><Trash2 className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Presentar" disabled={!selected} onClick={handleSubmit}><Send className="h-4 w-4" /></button>
        <button className={iconBtn} title="Liquidar" disabled={!selected} onClick={handleReimburse}><Save className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar" onClick={load}><RefreshCw className="h-4 w-4" /></button>
        <button className={iconBtn} title="Salir" onClick={() => toast.info("Use la X superior para cerrar la ventana")}><LogOut className="h-4 w-4" /></button>
      </div>

      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="Caja Chica" className="w-60">
          <select className={inp} value={cajaId} onChange={(e) => setCajaId(e.target.value)}>
            {cajas.map((c) => (
              <option key={c.id} value={c.id}>{c.name}</option>
            ))}
          </select>
        </Field>
        <Field label="Estado" className="w-36">
          <select className={inp} value={statusFilter} onChange={(e) => setStatusFilter(e.target.value)}>
            <option value="">(Todos)</option>
            <option value="pending">PENDIENTE</option>
            <option value="submitted">PRESENTADO</option>
            <option value="reimbursed">LIQUIDADO</option>
          </select>
        </Field>
        <Field label="Adelanto" className="w-32">
          <input className={`${inp} font-mono`} value={adelanto} onChange={(e) => setAdelanto(e.target.value)} />
        </Field>
        <Field label="Buscar" className="w-72">
          <input className={inp} value={search} onChange={(e) => setSearch(e.target.value)} placeholder="Concepto, comp. o descripción" />
        </Field>
        <button className={btnPrimary} onClick={load} disabled={loading}><Search className="h-3.5 w-3.5" />{loading ? "Buscando..." : "Buscar"}</button>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full text-[11.5px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
              <tr>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'date' ? { col: 'date', asc: !prev.asc } : { col: 'date', asc: true })}>Fecha {sortBy?.col === 'date' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'concept' ? { col: 'concept', asc: !prev.asc } : { col: 'concept', asc: true })}>Concepto {sortBy?.col === 'concept' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'voucher' ? { col: 'voucher', asc: !prev.asc } : { col: 'voucher', asc: true })}>Comp. {sortBy?.col === 'voucher' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-right border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'amount' ? { col: 'amount', asc: !prev.asc } : { col: 'amount', asc: false })}>Monto {sortBy?.col === 'amount' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'status' ? { col: 'status', asc: !prev.asc } : { col: 'status', asc: true })}>Estado {sortBy?.col === 'status' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
                <th className="px-2 py-1 text-center border-slate-300/70 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => setSortBy(prev => prev?.col === 'description' ? { col: 'description', asc: !prev.asc } : { col: 'description', asc: true })}>Descripción {sortBy?.col === 'description' ? (sortBy.asc ? '▲' : '▼') : ''}</th>
              </tr>
            </thead>
            <tbody>
              {rowsView.length === 0 ? (
                <tr>
                  <td colSpan={6} className="text-center py-8 text-slate-400 text-[11px]">
                    {loading ? "Cargando..." : searched ? "Sin viáticos" : "Seleccione caja y pulse Buscar"}
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
                    <td className="px-2 py-1 text-center border-r border-slate-200 whitespace-nowrap">{r.date ? new Date(r.date).toLocaleDateString("es-PE") : ""}</td>
                    <td className="px-2 py-1 border-r border-slate-200 max-w-[280px] truncate">{r.concept}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200 font-mono">{[r.voucher_type, r.voucher_number].filter(Boolean).join("-") || "-"}</td>
                    <td className="px-2 py-1 text-right border-r border-slate-200 font-mono font-semibold">{r.amount.toFixed(2)}</td>
                    <td className="px-2 py-1 text-center border-r border-slate-200"><span className={`inline-block px-1.5 py-0.5 rounded text-[10px] font-bold ${estadoClass(r.status)}`}>{estadoText(r.status)}</span></td>
                    <td className="px-2 py-1 border-r border-slate-200 max-w-[240px] truncate">{r.description || "-"}</td>
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
          Total gastado: {totalGastado.toFixed(2)} | Adelanto: {(Number(adelanto) || 0).toFixed(2)} | Saldo: {saldo.toFixed(2)}
        </span>
      </div>
    </div>
  );
}
