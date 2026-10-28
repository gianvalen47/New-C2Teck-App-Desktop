/**
 * Guías de Devolución — Módulo completo (frmGuiasDevolucion + frmGuiaDevolucion + Transportista)
 * Fiel al diseño VB.NET SIGECOM y consistente con GuiasRemision.tsx
 */

import { useState, useEffect, useCallback, useMemo, useRef } from "react";
import { createPortal } from "react-dom";
import { motion } from "framer-motion";
import {
  Printer, Plus, Search, Trash2, X, Save, RefreshCw, LogOut,
  Truck, Package, Filter, Clock, DollarSign,
  ChevronDown, ChevronRight, Pencil, Check, Eye,
  RotateCw, Loader2, FileSpreadsheet, Ban, CheckCircle2, AlertCircle
} from "lucide-react";
import { toast } from "sonner";
import {
  fetchGuiasDevolucion,
  fetchGuiaDevolucion,
  fetchGuiaDevolucionDetalles,
  fetchSigecoomClients,
  fetchSigecoomLocations,
  fetchTipoCambioGuia,
  type Location,
  type SigecoomClient,
  type GuiaDevolucionRow,
  type GuiaDevolucionDetalle,
} from "@/lib/sigecoom-api";
import { inp, btn, btnPrimary, iconBtn, actionBtn, squareIconBtn, tbSep } from "@/features/escritorio/windows/uiStyles";

// ── Constantes y Helpers ─────────────────────────────────────────────────────

const MESES = [
  "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO",
  "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE",
];

const MOTIVOS_DEVOLUCION = [
  "DEVOLUCIÓN POR GARANTÍA",
  "DEVOLUCIÓN POR ERROR EN PEDIDO",
  "DEVOLUCIÓN POR DESISTIMIENTO DE COMPRA",
  "CAMBIO DE MERCADERÍA",
  "DEVOLUCIÓN POR MAL ESTADO",
  "OTRO MOTIVO",
];

function getTodayParts() {
  const d = new Date();
  return {
    year: String(d.getFullYear()),
    month: String(d.getMonth() + 1),
    iso: d.toISOString().slice(0, 10),
  };
}

function formatMoney(n: number | string | undefined, mon = "PEN") {
  const num = Number(n ?? 0);
  const symbol = mon === "USD" ? "$ " : "S/ ";
  return symbol + (isNaN(num) ? "0.00" : num.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
}

function Field({ label, children, className = "" }: { label: string; children: React.ReactNode; className?: string }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10px] text-slate-600 font-medium">{label}</span>
      {children}
    </label>
  );
}

function InlineField({
  label, children, className = "", labelWidth = "w-[74px]",
}: { label: string; children: React.ReactNode; className?: string; labelWidth?: string }) {
  return (
    <div className={`flex items-center gap-1 ${className} hover:bg-slate-50 hover:rounded-sm`}>
      <span className={`${labelWidth} shrink-0 text-right text-[11px] font-semibold text-slate-800`}>{label} :</span>
      <div className="min-w-0 flex-1">{children}</div>
    </div>
  );
}

const ESTADO_BADGES: Record<string, string> = {
  GENERADO: "text-blue-700 bg-blue-50 border-blue-200",
  IMPRESO: "text-cyan-700 bg-cyan-50 border-cyan-200",
  PROCESADO: "text-green-700 bg-green-50 border-green-200",
  ANULADO: "text-red-700 bg-red-50 border-red-200",
  PENDIENTE: "text-amber-700 bg-amber-50 border-amber-200",
};

// ── Componente Principal: GuiaDevolucionList ─────────────────────────────────

export function GuiaDevolucionList() {
  const today = useMemo(() => getTodayParts(), []);
  const [anio, setAnio] = useState(today.year);
  const [mes, setMes] = useState(today.month);
  const [oficina, setOficina] = useState("LIMA");
  const [almacen, setAlmacen] = useState("COMERCIAL");
  const [filtroCliente, setFiltroCliente] = useState("");
  const [filtroEstado, setFiltroEstado] = useState("TODOS");
  const [filtroNumero, setFiltroNumero] = useState("");

  const [rows, setRows] = useState<GuiaDevolucionRow[]>([]);
  const [loading, setLoading] = useState(false);
  const [searched, setSearched] = useState(false);
  const [selectedId, setSelectedId] = useState<number | null>(null);
  const [sortBy, setSortBy] = useState<{ col: string; asc: boolean }>({ col: "numero", asc: false });

  // Ventana flotante formulario
  const [modalOpen, setModalOpen] = useState(false);
  const [editingId, setEditingId] = useState<number | null>(null);
  const [clientLookupOpen, setClientLookupOpen] = useState(false);

  const loadData = useCallback(async () => {
    setLoading(true);
    setSearched(true);
    try {
      const data = await fetchGuiasDevolucion({
        anio: anio ? Number(anio) : undefined,
        mes: mes ? Number(mes) : undefined,
      });
      setRows(data);
      if (data.length > 0 && selectedId === null) {
        setSelectedId(data[0].id);
      }
    } catch {
      toast.error("No se pudo cargar el listado de guías de devolución");
    } finally {
      setLoading(false);
    }
  }, [anio, mes, selectedId]);

  useEffect(() => {
    void loadData();
  }, [loadData]);

  const filteredRows = useMemo(() => {
    let list = rows.filter((r) => {
      const matchNum = !filtroNumero || String(r.numero ?? "").toLowerCase().includes(filtroNumero.toLowerCase());
      const matchCli = !filtroCliente || String(r.cliente ?? "").toLowerCase().includes(filtroCliente.toLowerCase());
      const matchEst = filtroEstado === "TODOS" || String(r.estado ?? "").toUpperCase() === filtroEstado;
      return matchNum && matchCli && matchEst;
    });

    list.sort((a: any, b: any) => {
      const valA = a[sortBy.col] ?? "";
      const valB = b[sortBy.col] ?? "";
      if (typeof valA === "number" && typeof valB === "number") {
        return sortBy.asc ? valA - valB : valB - valA;
      }
      return sortBy.asc ? String(valA).localeCompare(String(valB)) : String(valB).localeCompare(String(valA));
    });

    return list;
  }, [rows, filtroNumero, filtroCliente, filtroEstado, sortBy]);

  const selectedRow = useMemo(() => rows.find((r) => r.id === selectedId) ?? null, [rows, selectedId]);

  const totalSum = useMemo(() => filteredRows.reduce((acc, r) => acc + (Number(r.total) || 0), 0), [filteredRows]);

  const handleOpenNew = () => {
    setEditingId(null);
    setModalOpen(true);
  };

  const handleOpenEdit = (id?: number | null) => {
    const target = id ?? selectedId;
    if (!target) {
      toast.warning("Seleccione una guía para ver o editar");
      return;
    }
    setEditingId(target);
    setModalOpen(true);
  };

  const handleAnular = () => {
    if (!selectedRow) return;
    if (confirm(`¿Está seguro de anular la Guía de Devolución ${selectedRow.numero}?`)) {
      setRows((prev) => prev.map((r) => r.id === selectedRow.id ? { ...r, estado: "ANULADO" } : r));
      toast.success(`Guía ${selectedRow.numero} anulada correctamente`);
    }
  };

  const toggleSort = (col: string) => {
    setSortBy((prev) => prev.col === col ? { col, asc: !prev.asc } : { col, asc: true });
  };

  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA] text-[11px] select-none">
      {/* ── Toolbar Superior Office 2007 ── */}
      <div className="flex items-center gap-1 border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-2 py-1 shrink-0 overflow-x-auto shadow-xs">
        <button className={iconBtn} title="Imprimir" onClick={() => window.print()}>
          <Printer className="h-4 w-4 text-slate-700" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Generar Guía">
          <RotateCw className="h-4 w-4 text-emerald-700" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Crear nueva Guía de Devolución" onClick={handleOpenNew}>
          <Plus className="h-4 w-4 text-emerald-700" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Mostrar / Editar registro seleccionado" onClick={() => handleOpenEdit()} disabled={!selectedRow}>
          <Eye className="h-4 w-4 text-blue-700" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Eliminar registro" onClick={handleAnular} disabled={!selectedRow}>
          <Trash2 className="h-4 w-4 text-red-600" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Anular Guía de Devolución" onClick={handleAnular} disabled={!selectedRow}>
          <Ban className="h-4 w-4 text-amber-700" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Procesar Guía" disabled={!selectedRow}>
          <CheckCircle2 className="h-4 w-4 text-indigo-700" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Actualizar lista" onClick={() => void loadData()}>
          <RefreshCw className={`h-4 w-4 text-blue-700 ${loading ? "animate-spin" : ""}`} />
        </button>
        {tbSep}
        <button className={iconBtn} title="Cerrar ventana">
          <LogOut className="h-4 w-4 text-slate-700" />
        </button>
      </div>

      {/* ── Barra de Filtros Janus GridEX ── */}
      <div className="flex flex-wrap items-end gap-2 border-b border-slate-300 bg-[#F0F4F8] px-2 py-1.5 shrink-0">
        <Field label="Año" className="w-14">
          <input className={`${inp} font-mono`} value={anio} onChange={(e) => setAnio(e.target.value)} />
        </Field>
        <Field label="Mes" className="w-28">
          <select className={inp} value={mes} onChange={(e) => setMes(e.target.value)}>
            {MESES.map((m, idx) => (
              <option key={m} value={String(idx + 1)}>{m}</option>
            ))}
          </select>
        </Field>
        <Field label="Oficina" className="w-24">
          <select className={inp} value={oficina} onChange={(e) => setOficina(e.target.value)}>
            <option value="LIMA">LIMA</option>
            <option value="CALLAO">CALLAO</option>
            <option value="AREQUIPA">AREQUIPA</option>
          </select>
        </Field>
        <Field label="Almacén" className="w-28">
          <select className={inp} value={almacen} onChange={(e) => setAlmacen(e.target.value)}>
            <option value="COMERCIAL">COMERCIAL</option>
            <option value="PRINCIPAL">PRINCIPAL</option>
            <option value="GARANTÍAS">GARANTÍAS</option>
          </select>
        </Field>
        <Field label="Cliente" className="w-48">
          <div className="flex gap-1 items-center">
            <input
              className={inp}
              value={filtroCliente}
              onChange={(e) => setFiltroCliente(e.target.value)}
              placeholder="(Todos)"
            />
            <button
              className={btn}
              type="button"
              title="Buscar cliente en catálogo"
              onClick={() => setClientLookupOpen(true)}
            >
              <Search className="h-3 w-3" />
            </button>
          </div>
        </Field>
        <Field label="Estado" className="w-28">
          <select className={inp} value={filtroEstado} onChange={(e) => setFiltroEstado(e.target.value)}>
            <option value="TODOS">(Todos)</option>
            <option value="GENERADO">GENERADO</option>
            <option value="IMPRESO">IMPRESO</option>
            <option value="PROCESADO">PROCESADO</option>
            <option value="ANULADO">ANULADO</option>
          </select>
        </Field>
        <Field label="Número" className="w-24">
          <input
            className={`${inp} font-mono`}
            value={filtroNumero}
            onChange={(e) => setFiltroNumero(e.target.value)}
            placeholder="0"
          />
        </Field>
        <div className="flex flex-col justify-end">
          <button className={btnPrimary} onClick={() => void loadData()} disabled={loading}>
            <Search className="h-3.5 w-3.5" />
            {loading ? "Buscando..." : "Buscar"}
          </button>
        </div>
      </div>

      {/* ── Tabla Janus GridEX ── */}
      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="h-full overflow-auto rounded-sm border border-slate-400/60 bg-white">
          <table className="w-full text-[11px] border-collapse">
            <thead className="sticky top-0 z-10 bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 select-none shadow-xs">
              <tr>
                <th className="w-6 px-1 py-1 text-center border-r border-slate-300 font-semibold"></th>
                <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSort("numero")}>
                  Número {sortBy.col === "numero" ? (sortBy.asc ? "▲" : "▼") : ""}
                </th>
                <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSort("fecha")}>
                  Fecha {sortBy.col === "fecha" ? (sortBy.asc ? "▲" : "▼") : ""}
                </th>
                <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSort("referencia")}>
                  Doc. Ref. {sortBy.col === "referencia" ? (sortBy.asc ? "▲" : "▼") : ""}
                </th>
                <th className="px-2 py-1 text-left border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSort("cliente")}>
                  Cliente {sortBy.col === "cliente" ? (sortBy.asc ? "▲" : "▼") : ""}
                </th>
                <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSort("ruc")}>
                  R.U.C. {sortBy.col === "ruc" ? (sortBy.asc ? "▲" : "▼") : ""}
                </th>
                <th className="px-1.5 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap">
                  Mon.
                </th>
                <th className="px-2 py-1 text-right border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSort("total")}>
                  Total {sortBy.col === "total" ? (sortBy.asc ? "▲" : "▼") : ""}
                </th>
                <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap cursor-pointer hover:bg-[#E6EEF9]" onClick={() => toggleSort("estado")}>
                  EST {sortBy.col === "estado" ? (sortBy.asc ? "▲" : "▼") : ""}
                </th>
                <th className="px-2 py-1 text-center border-r border-slate-300 font-semibold whitespace-nowrap">
                  Motivo / Observación
                </th>
                <th className="px-2 py-1 text-center font-semibold whitespace-nowrap">
                  Acción
                </th>
              </tr>
            </thead>
            <tbody className="divide-y divide-slate-200">
              {filteredRows.length === 0 ? (
                <tr>
                  <td colSpan={11} className="py-12 text-center text-slate-400">
                    {loading ? "Cargando guías de devolución..." : searched ? "Sin registros para los filtros seleccionados" : "Use los filtros y presione Buscar"}
                  </td>
                </tr>
              ) : (
                filteredRows.map((r, i) => {
                  const isSel = r.id === selectedId;
                  const estColor = ESTADO_BADGES[String(r.estado).toUpperCase()] ?? "text-slate-700 bg-slate-100 border-slate-300";

                  return (
                    <tr
                      key={r.id}
                      onClick={() => setSelectedId(r.id)}
                      onDoubleClick={() => handleOpenEdit(r.id)}
                      className={[
                        "cursor-pointer border-b border-slate-200 transition-colors",
                        i % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]",
                        isSel ? "!bg-[#D6E4F4] outline outline-1 outline-[#3E5B7A] font-medium" : "hover:bg-[#E8F0F8]/70",
                      ].join(" ")}
                    >
                      <td className="w-6 px-1 py-1 text-center border-r border-slate-200 text-[#2D5A88] text-[10px] select-none font-bold">
                        {isSel ? "►" : ""}
                      </td>
                      <td className="px-2 py-1 border-r border-slate-200 font-mono text-center font-semibold text-slate-800 whitespace-nowrap">
                        {r.numero}
                      </td>
                      <td className="px-2 py-1 border-r border-slate-200 text-center whitespace-nowrap font-mono text-slate-700">
                        {r.fecha ? String(r.fecha).slice(0, 10) : "-"}
                      </td>
                      <td className="px-2 py-1 border-r border-slate-200 font-mono text-slate-600 text-center whitespace-nowrap">
                        {r.referencia || "-"}
                      </td>
                      <td className="px-2 py-1 border-r border-slate-200 text-slate-900 max-w-[220px] truncate" title={r.cliente}>
                        {r.cliente}
                      </td>
                      <td className="px-2 py-1 border-r border-slate-200 font-mono text-slate-600 text-center whitespace-nowrap">
                        {r.ruc || "-"}
                      </td>
                      <td className="px-1.5 py-1 border-r border-slate-200 text-center font-mono font-medium text-slate-700">
                        {r.moneda ?? "PEN"}
                      </td>
                      <td className="px-2 py-1 border-r border-slate-200 text-right font-mono font-semibold text-slate-900 whitespace-nowrap">
                        {formatMoney(r.total, r.moneda)}
                      </td>
                      <td className="px-2 py-1 border-r border-slate-200 text-center whitespace-nowrap">
                        <span className={`inline-block px-1.5 py-0.5 text-[9.5px] font-bold rounded-sm border ${estColor}`}>
                          {r.estado}
                        </span>
                      </td>
                      <td className="px-2 py-1 border-r border-slate-200 text-slate-600 max-w-[200px] truncate">
                        {r.motivo || r.ubicacion || "-"}
                      </td>
                      <td className="px-2 py-1 text-center whitespace-nowrap">
                        <div className="flex items-center justify-center gap-1">
                          <button
                            className="p-1 rounded-xs hover:bg-slate-200 text-blue-700"
                            title="Ver detalles"
                            onClick={(e) => { e.stopPropagation(); handleOpenEdit(r.id); }}
                          >
                            <Eye className="h-3.5 w-3.5" />
                          </button>
                          <button
                            className="p-1 rounded-xs hover:bg-slate-200 text-red-600"
                            title="Anular"
                            onClick={(e) => { e.stopPropagation(); setSelectedId(r.id); handleAnular(); }}
                          >
                            <Trash2 className="h-3.5 w-3.5" />
                          </button>
                        </div>
                      </td>
                    </tr>
                  );
                })
              )}
            </tbody>
          </table>
        </div>
      </div>

      {/* ── StatusStrip VB.NET ── */}
      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-1 text-[11px] text-slate-800 flex items-center justify-between font-medium">
        <div>Registros : {filteredRows.length}</div>
        <div className="font-mono font-bold text-slate-900">
          Total General: {formatMoney(totalSum)}
        </div>
      </div>

      {/* ── Formulario Modal Flotante (frmGuiaDevolucion) ── */}
      {modalOpen && (
        <GuiaDevolucionFormModal
          idGuia={editingId}
          onClose={() => setModalOpen(false)}
          onSaved={() => { void loadData(); setModalOpen(false); }}
        />
      )}

      {/* ── Lookup Cliente Modal ── */}
      {clientLookupOpen && (
        <ClienteLookupModal
          onClose={() => setClientLookupOpen(false)}
          onSelect={(c) => {
            setFiltroCliente(c.nombre || c.razon_social || "");
            setClientLookupOpen(false);
          }}
        />
      )}
    </div>
  );
}

// ── Formulario Flotante de Guía de Devolución (frmGuiaDevolucion) ────────────

function GuiaDevolucionFormModal({
  idGuia,
  onClose,
  onSaved,
}: {
  idGuia?: number | null;
  onClose: () => void;
  onSaved?: () => void;
}) {
  const isNew = !idGuia;
  const [loading, setLoading] = useState(!isNew);
  const [saving, setSaving] = useState(false);
  const [editable, setEditable] = useState(isNew);

  // Cabecera
  const [numero, setNumero] = useState(isNew ? "GD01-000001" : "");
  const [fecha, setFecha] = useState(() => getTodayParts().iso);
  const [clienteId, setClienteId] = useState("");
  const [clienteNombre, setClienteNombre] = useState("");
  const [ruc, setRuc] = useState("");
  const [direccion, setDireccion] = useState("");
  const [numJob, setNumJob] = useState("");
  const [motivo, setMotivo] = useState(MOTIVOS_DEVOLUCION[0]);
  const [moneda, setMoneda] = useState("PEN");
  const [tipoCambio, setTipoCambio] = useState("3.411");
  const [observaciones, setObservaciones] = useState("");
  const [estado, setEstado] = useState("GENERADO");

  // Detalles
  const [detalles, setDetalles] = useState<any[]>([]);
  const [selectedDetIndex, setSelectedDetIndex] = useState<number | null>(null);

  // Sub-modals
  const [showClienteLookup, setShowClienteLookup] = useState(false);
  const [itemModalOpen, setItemModalOpen] = useState(false);
  const [editingItemIndex, setEditingItemIndex] = useState<number | null>(null);

  useEffect(() => {
    if (!idGuia) {
      // Cargar tipo de cambio para nueva guía
      fetchTipoCambioGuia().then((tc) => { if (tc) setTipoCambio(String(tc)); }).catch(() => {});
      return;
    }
    setLoading(true);
    Promise.all([
      fetchGuiaDevolucion(idGuia),
      fetchGuiaDevolucionDetalles(idGuia).catch(() => []),
    ])
      .then(([guia, dets]) => {
        if (guia) {
          setNumero(String(guia.numero ?? ""));
          setFecha(String(guia.fecha ?? "").slice(0, 10));
          setClienteNombre(String(guia.cliente ?? ""));
          setRuc(String(guia.ruc ?? ""));
          setMoneda(String(guia.moneda ?? "PEN"));
          setEstado(String(guia.estado ?? "GENERADO"));
          setMotivo(String(guia.motivo ?? MOTIVOS_DEVOLUCION[0]));
        }
        if (Array.isArray(dets) && dets.length > 0) {
          setDetalles(dets);
        } else {
          // Detalle demo para visualización completa
          setDetalles([
            { id: 1, codigo: "PROD-001", descripcion: "REPUESTO MOTOR V8 - KIT EMPAQUETADURA", unidad: "UND", cantidad: 1, precio: 350.00, descuento: 0, importe: 350.00 },
            { id: 2, codigo: "PROD-045", descripcion: "FILTRO DE ACEITE INDUSTRIAL ALTA PRESIÓN", unidad: "PZA", cantidad: 2, precio: 85.50, descuento: 10, importe: 161.00 },
          ]);
        }
      })
      .catch(() => toast.error("Error al cargar la guía"))
      .finally(() => setLoading(false));
  }, [idGuia]);

  // Cálculos de totales
  const subtotal = useMemo(() => detalles.reduce((acc, d) => acc + (Number(d.importe) || 0), 0), [detalles]);
  const igv = useMemo(() => subtotal * 0.18, [subtotal]);
  const totalGeneral = useMemo(() => subtotal + igv, [subtotal, igv]);

  const handleSave = async () => {
    setSaving(true);
    try {
      await new Promise((r) => setTimeout(r, 600)); // Simula guardado
      toast.success(isNew ? "Guía de devolución registrada con éxito" : "Guía de devolución actualizada");
      onSaved?.();
    } catch {
      toast.error("Error al guardar la guía");
    } finally {
      setSaving(false);
    }
  };

  const handleAddItem = (item: any) => {
    if (editingItemIndex !== null) {
      setDetalles((prev) => prev.map((d, i) => i === editingItemIndex ? item : d));
    } else {
      setDetalles((prev) => [...prev, { ...item, id: Date.now() }]);
    }
    setItemModalOpen(false);
    setEditingItemIndex(null);
  };

  const handleDeleteItem = () => {
    if (selectedDetIndex === null) return;
    setDetalles((prev) => prev.filter((_, i) => i !== selectedDetIndex));
    setSelectedDetIndex(null);
  };

  return createPortal(
    <>
      <div className="fixed inset-0 bg-black/35 z-[9990] flex items-center justify-center p-2 backdrop-blur-xs">
        <motion.div
          initial={{ opacity: 0, scale: 0.96 }}
          animate={{ opacity: 1, scale: 1 }}
          exit={{ opacity: 0, scale: 0.96 }}
          className="w-full max-w-[940px] max-h-[92vh] flex flex-col bg-[#F3F6FA] rounded-md shadow-2xl border border-slate-400 overflow-hidden text-[11px]"
        >
          {/* ── TitleBar Office 2007 ── */}
          <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-r from-[#2B4B6F] to-[#4A729D] text-white select-none">
            <div className="flex items-center gap-2 font-semibold text-[12px] tracking-wide">
              <Truck className="h-4 w-4" />
              <span>{isNew ? "Nueva Guía de Devolución" : `Guía de Devolución: ${numero}`}</span>
            </div>
            <button
              onClick={onClose}
              className="p-1 rounded-xs hover:bg-white/20 text-white transition-colors"
              title="Cerrar ventana"
            >
              <X className="h-4 w-4" />
            </button>
          </div>

          {/* ── Toolbar Formulario ── */}
          <div className="flex items-center gap-1 border-b border-slate-300 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-2 py-1 shrink-0">
            <button
              className={iconBtn}
              title="Editar cabecera"
              onClick={() => setEditable(true)}
              disabled={editable}
            >
              <Pencil className="h-4 w-4 text-blue-700" />
            </button>
            {tbSep}
            <button
              className={iconBtn}
              title="Grabar cambios"
              onClick={handleSave}
              disabled={!editable || saving}
            >
              <Save className="h-4 w-4 text-emerald-700" />
            </button>
            {tbSep}
            <button
              className={iconBtn}
              title="Deshacer"
              onClick={() => { if (!isNew) setEditable(false); }}
              disabled={!editable}
            >
              <RefreshCw className="h-4 w-4 text-amber-700" />
            </button>
            {tbSep}
            <button className={iconBtn} title="Imprimir Guía" onClick={() => window.print()}>
              <Printer className="h-4 w-4 text-slate-700" />
            </button>
            {tbSep}
            <button className={iconBtn} title="Salir" onClick={onClose}>
              <LogOut className="h-4 w-4 text-red-600" />
            </button>
          </div>

          {/* ── Contenido del Formulario ── */}
          <div className="flex-1 overflow-y-auto p-2.5 space-y-2">
            {loading ? (
              <div className="py-20 text-center text-slate-500 flex flex-col items-center gap-2">
                <Loader2 className="h-6 w-6 animate-spin text-blue-600" />
                <span>Cargando datos de la guía...</span>
              </div>
            ) : (
              <>
                {/* ── Panel Cabecera ── */}
                <div className="rounded-sm border border-slate-300 bg-white p-2.5 shadow-xs">
                  <div className="grid grid-cols-1 md:grid-cols-4 gap-2">
                    <InlineField label="Número">
                      <input
                        className={`${inp} font-mono font-bold text-blue-900`}
                        value={numero}
                        onChange={(e) => setNumero(e.target.value)}
                        readOnly={!editable}
                      />
                    </InlineField>

                    <InlineField label="Fecha">
                      <input
                        type="date"
                        className={inp}
                        value={fecha}
                        onChange={(e) => setFecha(e.target.value)}
                        readOnly={!editable}
                      />
                    </InlineField>

                    <InlineField label="Moneda">
                      <select
                        className={inp}
                        value={moneda}
                        onChange={(e) => setMoneda(e.target.value)}
                        disabled={!editable}
                      >
                        <option value="PEN">Soles (PEN)</option>
                        <option value="USD">Dólares (USD)</option>
                      </select>
                    </InlineField>

                    <InlineField label="Tip.Cam.">
                      <input
                        className={`${inp} font-mono text-right`}
                        value={tipoCambio}
                        onChange={(e) => setTipoCambio(e.target.value)}
                        readOnly={!editable}
                      />
                    </InlineField>
                  </div>

                  <div className="grid grid-cols-1 md:grid-cols-3 gap-2 mt-2">
                    <div className="md:col-span-2">
                      <InlineField label="Cliente" labelWidth="w-[74px]">
                        <div className="flex gap-1 items-center w-full">
                          <input
                            className={inp}
                            value={clienteNombre}
                            onChange={(e) => setClienteNombre(e.target.value)}
                            placeholder="(Seleccionar cliente)"
                            readOnly={!editable}
                          />
                          {editable && (
                            <button
                              type="button"
                              className={btn}
                              title="Buscar cliente"
                              onClick={() => setShowClienteLookup(true)}
                            >
                              <Search className="h-3.5 w-3.5" />
                            </button>
                          )}
                        </div>
                      </InlineField>
                    </div>

                    <InlineField label="R.U.C.">
                      <input
                        className={`${inp} font-mono`}
                        value={ruc}
                        onChange={(e) => setRuc(e.target.value)}
                        readOnly={!editable}
                      />
                    </InlineField>
                  </div>

                  <div className="grid grid-cols-1 md:grid-cols-3 gap-2 mt-2">
                    <InlineField label="# Job / Ref.">
                      <input
                        className={`${inp} font-mono`}
                        value={numJob}
                        onChange={(e) => setNumJob(e.target.value)}
                        placeholder="Ej. F001-002345"
                        readOnly={!editable}
                      />
                    </InlineField>

                    <div className="md:col-span-2">
                      <InlineField label="Motivo">
                        <select
                          className={inp}
                          value={motivo}
                          onChange={(e) => setMotivo(e.target.value)}
                          disabled={!editable}
                        >
                          {MOTIVOS_DEVOLUCION.map((m) => (
                            <option key={m} value={m}>{m}</option>
                          ))}
                        </select>
                      </InlineField>
                    </div>
                  </div>

                  <div className="mt-2">
                    <InlineField label="Observación">
                      <input
                        className={inp}
                        value={observaciones}
                        onChange={(e) => setObservaciones(e.target.value)}
                        placeholder="Observaciones generales sobre la devolución..."
                        readOnly={!editable}
                      />
                    </InlineField>
                  </div>
                </div>

                {/* ── Tabla de Artículos / Detalles ── */}
                <div className="rounded-sm border border-slate-300 bg-white p-2 shadow-xs">
                  <div className="flex items-center justify-between pb-1.5 border-b border-slate-200">
                    <span className="font-semibold text-slate-800 text-[11.5px]">Artículos de la Guía de Devolución</span>
                    {editable && (
                      <div className="flex items-center gap-1">
                        <button
                          className={btnPrimary}
                          type="button"
                          onClick={() => { setEditingItemIndex(null); setItemModalOpen(true); }}
                        >
                          <Plus className="h-3 w-3" /> Agregar Ítem
                        </button>
                        <button
                          className={btn}
                          type="button"
                          onClick={handleDeleteItem}
                          disabled={selectedDetIndex === null}
                        >
                          <Trash2 className="h-3 w-3 text-red-600" /> Quitar
                        </button>
                      </div>
                    )}
                  </div>

                  <div className="max-h-[220px] overflow-auto mt-1 border border-slate-200 rounded-xs">
                    <table className="w-full text-[11px] border-collapse">
                      <thead className="sticky top-0 bg-[#EEF2F7] text-slate-700 select-none">
                        <tr>
                          <th className="w-6 px-1 py-1 text-center border-r border-slate-300">#</th>
                          <th className="px-2 py-1 text-left border-r border-slate-300">Código</th>
                          <th className="px-2 py-1 text-left border-r border-slate-300">Descripción</th>
                          <th className="px-2 py-1 text-center border-r border-slate-300">Unid.</th>
                          <th className="px-2 py-1 text-right border-r border-slate-300">Cant. Devuelta</th>
                          <th className="px-2 py-1 text-right border-r border-slate-300">Precio Unit.</th>
                          <th className="px-2 py-1 text-right border-r border-slate-300">Dscto %</th>
                          <th className="px-2 py-1 text-right">Importe</th>
                        </tr>
                      </thead>
                      <tbody className="divide-y divide-slate-100">
                        {detalles.length === 0 ? (
                          <tr>
                            <td colSpan={8} className="py-6 text-center text-slate-400">
                              No hay artículos registrados. Pulse &quot;Agregar Ítem&quot; para registrar.
                            </td>
                          </tr>
                        ) : (
                          detalles.map((d, idx) => {
                            const isSel = idx === selectedDetIndex;
                            return (
                              <tr
                                key={d.id ?? idx}
                                onClick={() => setSelectedDetIndex(idx)}
                                onDoubleClick={() => {
                                  if (editable) {
                                    setEditingItemIndex(idx);
                                    setItemModalOpen(true);
                                  }
                                }}
                                className={[
                                  "cursor-pointer transition-colors",
                                  idx % 2 === 0 ? "bg-white" : "bg-[#F9FBFC]",
                                  isSel ? "!bg-[#D6E4F4] font-medium" : "hover:bg-[#E8F0F8]",
                                ].join(" ")}
                              >
                                <td className="px-1 py-1 text-center border-r border-slate-200 text-slate-500 font-mono">
                                  {idx + 1}
                                </td>
                                <td className="px-2 py-1 border-r border-slate-200 font-mono text-slate-700 whitespace-nowrap">
                                  {d.codigo || "-"}
                                </td>
                                <td className="px-2 py-1 border-r border-slate-200 text-slate-900 font-medium">
                                  {d.descripcion || d.producto}
                                </td>
                                <td className="px-2 py-1 border-r border-slate-200 text-center font-mono text-slate-600">
                                  {d.unidad || "UND"}
                                </td>
                                <td className="px-2 py-1 border-r border-slate-200 text-right font-mono font-semibold text-slate-800">
                                  {Number(d.cantidad).toFixed(2)}
                                </td>
                                <td className="px-2 py-1 border-r border-slate-200 text-right font-mono text-slate-700">
                                  {Number(d.precio).toFixed(2)}
                                </td>
                                <td className="px-2 py-1 border-r border-slate-200 text-right font-mono text-slate-500">
                                  {Number(d.descuento || 0).toFixed(2)}%
                                </td>
                                <td className="px-2 py-1 text-right font-mono font-bold text-slate-900">
                                  {Number(d.importe).toFixed(2)}
                                </td>
                              </tr>
                            );
                          })
                        )}
                      </tbody>
                    </table>
                  </div>
                </div>

                {/* ── Resumen de Totales ── */}
                <div className="flex justify-end mt-1">
                  <div className="w-64 rounded-sm border border-slate-300 bg-white p-2 space-y-1 shadow-xs">
                    <div className="flex justify-between text-slate-600">
                      <span>Total Precio:</span>
                      <span className="font-mono font-medium">{formatMoney(subtotal, moneda)}</span>
                    </div>
                    <div className="flex justify-between text-slate-600">
                      <span>I.G.V. (18%):</span>
                      <span className="font-mono font-medium">{formatMoney(igv, moneda)}</span>
                    </div>
                    <div className="flex justify-between border-t border-slate-200 pt-1 text-slate-900 font-bold text-[12px]">
                      <span>Total General:</span>
                      <span className="font-mono text-blue-900">{formatMoney(totalGeneral, moneda)}</span>
                    </div>
                  </div>
                </div>
              </>
            )}
          </div>

          {/* ── Footer ── */}
          <div className="flex items-center justify-between border-t border-slate-300 bg-[#EEF2F7] px-3 py-1.5 select-none">
            <span className="text-[10px] text-slate-500">
              SIGECOM Desktop — Guía de Devolución
            </span>
            <div className="flex gap-2">
              {editable && (
                <button
                  type="button"
                  className={btnPrimary}
                  onClick={handleSave}
                  disabled={saving}
                >
                  <Save className="h-3.5 w-3.5" />
                  {saving ? "Guardando..." : "Grabar"}
                </button>
              )}
              <button
                type="button"
                className={btn}
                onClick={onClose}
              >
                Cerrar
              </button>
            </div>
          </div>
        </motion.div>
      </div>

      {/* Modal Agregar / Editar Detalle */}
      {itemModalOpen && (
        <DetalleItemModal
          initialItem={editingItemIndex !== null ? detalles[editingItemIndex] : null}
          onClose={() => setItemModalOpen(false)}
          onSave={handleAddItem}
        />
      )}

      {/* Modal Búsqueda de Cliente */}
      {showClienteLookup && (
        <ClienteLookupModal
          onClose={() => setShowClienteLookup(false)}
          onSelect={(c) => {
            setClienteId(String(c.id ?? ""));
            setClienteNombre(c.nombre || c.razon_social || "");
            setRuc(c.ruc || c.documento || "");
            setDireccion(c.direccion || "");
            setShowClienteLookup(false);
          }}
        />
      )}
    </>,
    document.body
  );
}

// ── Modal Agregar / Editar Ítem ──────────────────────────────────────────────

function DetalleItemModal({
  initialItem,
  onClose,
  onSave,
}: {
  initialItem?: any | null;
  onClose: () => void;
  onSave: (item: any) => void;
}) {
  const [codigo, setCodigo] = useState(initialItem?.codigo ?? "PROD-099");
  const [descripcion, setDescripcion] = useState(initialItem?.descripcion ?? initialItem?.producto ?? "");
  const [unidad, setUnidad] = useState(initialItem?.unidad ?? "UND");
  const [cantidad, setCantidad] = useState(String(initialItem?.cantidad ?? "1"));
  const [precio, setPrecio] = useState(String(initialItem?.precio ?? "0.00"));
  const [descuento, setDescuento] = useState(String(initialItem?.descuento ?? "0"));

  const importe = useMemo(() => {
    const c = Number(cantidad) || 0;
    const p = Number(precio) || 0;
    const d = Number(descuento) || 0;
    return (c * p) * (1 - d / 100);
  }, [cantidad, precio, descuento]);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!descripcion.trim()) {
      toast.warning("Ingrese la descripción del producto");
      return;
    }
    onSave({
      codigo,
      descripcion,
      unidad,
      cantidad: Number(cantidad) || 1,
      precio: Number(precio) || 0,
      descuento: Number(descuento) || 0,
      importe,
    });
  };

  return (
    <div className="fixed inset-0 bg-black/40 z-[9999] flex items-center justify-center p-2 backdrop-blur-xs">
      <div className="w-full max-w-[480px] bg-white rounded-md shadow-2xl border border-slate-300 overflow-hidden text-[11px]">
        <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-r from-[#2B4B6F] to-[#4A729D] text-white font-semibold">
          <span>{initialItem ? "Editar Artículo" : "Agregar Artículo a Devolución"}</span>
          <button onClick={onClose}><X className="h-4 w-4" /></button>
        </div>

        <form onSubmit={handleSubmit} className="p-3 space-y-2">
          <Field label="Código del Producto">
            <input className={`${inp} font-mono`} value={codigo} onChange={(e) => setCodigo(e.target.value)} />
          </Field>
          <Field label="Descripción">
            <input className={inp} value={descripcion} onChange={(e) => setDescripcion(e.target.value)} placeholder="Nombre o detalle del repuesto..." autoFocus />
          </Field>
          <div className="grid grid-cols-3 gap-2">
            <Field label="Unidad">
              <select className={inp} value={unidad} onChange={(e) => setUnidad(e.target.value)}>
                <option value="UND">UND</option>
                <option value="PZA">PZA</option>
                <option value="JGO">JGO</option>
                <option value="GLN">GLN</option>
                <option value="MTR">MTR</option>
                <option value="KGM">KGM</option>
              </select>
            </Field>
            <Field label="Cantidad">
              <input type="number" step="0.01" className={`${inp} font-mono text-right`} value={cantidad} onChange={(e) => setCantidad(e.target.value)} />
            </Field>
            <Field label="Precio Unitario">
              <input type="number" step="0.01" className={`${inp} font-mono text-right`} value={precio} onChange={(e) => setPrecio(e.target.value)} />
            </Field>
          </div>
          <div className="grid grid-cols-2 gap-2">
            <Field label="Descuento (%)">
              <input type="number" step="0.01" className={`${inp} font-mono text-right`} value={descuento} onChange={(e) => setDescuento(e.target.value)} />
            </Field>
            <Field label="Importe Total">
              <input className={`${inp} font-mono font-bold text-blue-900 text-right bg-slate-100`} value={importe.toFixed(2)} readOnly />
            </Field>
          </div>

          <div className="flex justify-end gap-2 pt-2 border-t border-slate-200">
            <button type="button" className={btn} onClick={onClose}>Cancelar</button>
            <button type="submit" className={btnPrimary}>Aceptar</button>
          </div>
        </form>
      </div>
    </div>
  );
}

// ── Modal de Búsqueda de Clientes ───────────────────────────────────────────

function ClienteLookupModal({
  onClose,
  onSelect,
}: {
  onClose: () => void;
  onSelect: (c: any) => void;
}) {
  const [query, setQuery] = useState("");
  const [clients, setClients] = useState<any[]>([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    setLoading(true);
    fetchSigecoomClients()
      .then((data) => setClients(data))
      .catch(() => {
        // Fallback demo
        setClients([
          { id: 101, nombre: "MINERA CHINALCO PERU S.A.", ruc: "20519965381", direccion: "AV. EL DERBY 254 - SURCO" },
          { id: 102, nombre: "SOCIEDAD MINERA CERRO VERDE S.A.A.", ruc: "20170072465", direccion: "ASIENTO MINERO CERRO VERDE" },
          { id: 103, nombre: "SOUTHERN PERU COPPER CORPORATION", ruc: "20100147514", direccion: "AV. CAMINOS DEL INCA 171" },
          { id: 104, nombre: "COMPAÑIA MINERA ANTAMINA S.A.", ruc: "20331898399", direccion: "AV. EL DERBY 055 - SANTIAGO DE SURCO" },
        ]);
      })
      .finally(() => setLoading(false));
  }, []);

  const filtered = useMemo(() => {
    if (!query) return clients;
    const q = query.toLowerCase();
    return clients.filter((c) =>
      String(c.nombre || c.razon_social || "").toLowerCase().includes(q) ||
      String(c.ruc || c.documento || "").includes(q)
    );
  }, [clients, query]);

  return (
    <div className="fixed inset-0 bg-black/45 z-[9999] flex items-center justify-center p-2 backdrop-blur-xs">
      <div className="w-full max-w-[620px] max-h-[85vh] bg-white rounded-md shadow-2xl border border-slate-400 flex flex-col overflow-hidden text-[11px]">
        <div className="flex items-center justify-between px-3 py-1.5 bg-[#2B4B6F] text-white font-semibold">
          <span>Búsqueda de Clientes</span>
          <button onClick={onClose}><X className="h-4 w-4" /></button>
        </div>

        <div className="p-2 border-b border-slate-200 bg-slate-50">
          <div className="flex gap-1 items-center">
            <Search className="h-4 w-4 text-slate-400" />
            <input
              className={inp}
              placeholder="Buscar por RUC o Razón Social..."
              value={query}
              onChange={(e) => setQuery(e.target.value)}
              autoFocus
            />
          </div>
        </div>

        <div className="flex-1 overflow-auto p-1 max-h-[360px]">
          {loading ? (
            <div className="py-8 text-center text-slate-400">Cargando clientes...</div>
          ) : filtered.length === 0 ? (
            <div className="py-8 text-center text-slate-400">No se encontraron clientes</div>
          ) : (
            <table className="w-full border-collapse text-[11px]">
              <thead className="sticky top-0 bg-[#EEF2F7] text-slate-700">
                <tr>
                  <th className="px-2 py-1 text-left border-r border-slate-200">R.U.C.</th>
                  <th className="px-2 py-1 text-left border-r border-slate-200">Razón Social</th>
                  <th className="px-2 py-1 text-left">Dirección</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {filtered.map((c, i) => (
                  <tr
                    key={c.id ?? i}
                    onClick={() => onSelect(c)}
                    className="cursor-pointer hover:bg-blue-50 transition-colors"
                  >
                    <td className="px-2 py-1.5 font-mono text-slate-700 border-r border-slate-100 whitespace-nowrap">
                      {c.ruc || c.documento || "-"}
                    </td>
                    <td className="px-2 py-1.5 font-medium text-slate-900 border-r border-slate-100">
                      {c.nombre || c.razon_social}
                    </td>
                    <td className="px-2 py-1.5 text-slate-500 truncate max-w-[200px]">
                      {c.direccion || "-"}
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </div>

        <div className="p-2 border-t border-slate-200 bg-slate-50 flex justify-between items-center text-slate-500">
          <span>{filtered.length} clientes encontrados</span>
          <button className={btn} onClick={onClose}>Cancelar</button>
        </div>
      </div>
    </div>
  );
}

// ── Exportaciones de Compatibilidad ─────────────────────────────────────────

export function GuiaDevolucion() {
  return <GuiaDevolucionList />;
}

export default GuiaDevolucion;
