import { createPortal } from "react-dom";
import { useEffect, useMemo, useRef, useState, type ReactNode } from "react";
import {
  CalendarDays,
  ChevronDown,
  ChevronUp,
  Clock3,
  FileText,
  LogOut,
  Mail,
  Pencil,
  Plus,
  Printer,
  Receipt,
  RefreshCw,
  Save,
  Search,
  Send,
  Trash2,
  Wrench,
  X,
} from "lucide-react";
import { stdToolbar5 } from "@/features/escritorio/windows/shared/toolbarPresets";
import { actionBtn, btn, btnPrimary, iconBtn, inp, squareIconBtn, tbSep } from "@/features/escritorio/windows/uiStyles";
import { fetchSession, getSessionTipoCambioCompra } from "@/lib/sigecoom-api";

type BoletaRow = {
  id: string;
  numero: string;
  fecha: string;
  cliente: string;
  moneda: string;
  total: string;
  estado: string;
  sunat: string;
  codigo: string;
  observacion: string;
};

const initialRows: BoletaRow[] = [
  { id: "B-1001", numero: "B001-1001", fecha: "2026-09-08", cliente: "LUCY VENTAS S.A.C.", moneda: "PEN", total: "1,248.00", estado: "GENERADO", sunat: "ACEPTADO", codigo: "B001", observacion: "Venta al contado" },
  { id: "B-1002", numero: "B001-1002", fecha: "2026-09-08", cliente: "MERCADOS DEL SUR", moneda: "PEN", total: "2,430.50", estado: "APROBADO", sunat: "PENDIENTE", codigo: "B001", observacion: "Entrega programada" },
  { id: "B-1003", numero: "B001-1003", fecha: "2026-09-07", cliente: "INVERSIONES PUNTO DOC", moneda: "USD", total: "518.25", estado: "CREDITOS", sunat: "ENVIADO", codigo: "B001", observacion: "Facturación con tarjeta" },
  { id: "B-1004", numero: "B001-1004", fecha: "2026-09-06", cliente: "ALMACEN DEL NORTE", moneda: "PEN", total: "3,600.00", estado: "ANULADO", sunat: "BAJA", codigo: "B001", observacion: "Cancelado por solicitud" },
  { id: "B-1005", numero: "B001-1005", fecha: "2026-09-05", cliente: "COSTA BRAVA EIRL", moneda: "PEN", total: "820.00", estado: "GENERADO", sunat: "PENDIENTE", codigo: "B001", observacion: "Venta normal" },
];

const ESTADO_COLORS: Record<string, string> = {
  GENERADO: "text-blue-700 bg-blue-50 border-blue-200",
  APROBADO: "text-green-700 bg-green-50 border-green-200",
  CREDITOS: "text-amber-700 bg-amber-50 border-amber-200",
  ANULADO: "text-red-700 bg-red-50 border-red-200",
};

function Field({ label, className = "", children }: { label: string; className?: string; children: ReactNode }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium leading-tight">{label}</span>
      {children}
    </label>
  );
}

function InlineField({
  label,
  children,
  className = "",
  labelWidth = "w-[74px]",
}: {
  label: string;
  children: ReactNode;
  className?: string;
  labelWidth?: string;
}) {
  return (
    <div className={`flex items-center gap-1 ${className} hover:bg-slate-50 hover:rounded-sm`}>
      <span className={`${labelWidth} shrink-0 text-right text-[11px] font-semibold text-slate-800 leading-tight`}>{label} :</span>
      <div className="min-w-0 flex-1 flex items-center">{children}</div>
    </div>
  );
}

function EstadoBadge({ estado }: { estado: string }) {
  const cls = ESTADO_COLORS[estado] ?? "text-slate-600 bg-slate-50 border-slate-200";
  return <span className={`inline-block px-1.5 py-0 text-[10px] font-bold rounded border ${cls}`}>{estado}</span>;
}

function YearSpinner({ value, onChange }: { value: string; onChange: (next: string) => void }) {
  const currentYear = Number(value || new Date().getFullYear());
  const stepYear = (delta: number) => {
    const next = Math.max(2000, currentYear + delta);
    onChange(String(next));
  };

  return (
    <div className="flex h-7 w-[82px] items-stretch overflow-hidden rounded border border-slate-300 bg-white shadow-xs">
      <input
        type="number"
        min={2000}
        value={value}
        onChange={(e) => {
          const next = e.target.value;
          onChange(next === "" ? String(new Date().getFullYear()) : next);
        }}
        className="w-[58px] border-0 bg-transparent px-2 py-0 text-[11px] font-mono text-slate-800 outline-none [appearance:textfield] [&::-webkit-inner-spin-button]:appearance-none [&::-webkit-outer-spin-button]:appearance-none"
      />
      <div className="flex w-[18px] flex-col border-l border-slate-300">
        <button
          type="button"
          className="flex h-1/2 w-full items-center justify-center bg-slate-100 text-slate-700 transition-colors hover:bg-slate-200"
          title="Subir año"
          onClick={() => stepYear(1)}
        >
          <ChevronUp className="h-3 w-3" />
        </button>
        <button
          type="button"
          className="flex h-1/2 w-full items-center justify-center border-t border-slate-300 bg-slate-100 text-slate-700 transition-colors hover:bg-slate-200"
          title="Bajar año"
          onClick={() => stepYear(-1)}
        >
          <ChevronDown className="h-3 w-3" />
        </button>
      </div>
    </div>
  );
}

type BoletaFormWindow = {
  id: string;
  title: string;
  x: number;
  y: number;
  w: number;
  h: number;
  z: number;
};

function DraggableFormWindow({
  win,
  onFocus,
  onMove,
  onClose,
  children,
}: {
  win: BoletaFormWindow;
  onFocus: () => void;
  onMove: (id: string, x: number, y: number) => void;
  onClose: () => void;
  children: ReactNode;
}) {
  const dragRef = useRef<{ dx: number; dy: number } | null>(null);

  useEffect(() => {
    const handleMouseMove = (event: MouseEvent) => {
      if (!dragRef.current) return;
      const maxW = window.innerWidth;
      const maxH = Math.max(320, window.innerHeight - 56);
      const nextXRaw = event.clientX - dragRef.current.dx;
      const nextYRaw = event.clientY - dragRef.current.dy;
      const nextX = Math.max(0, Math.min(nextXRaw, Math.max(0, maxW - win.w)));
      const nextY = Math.max(0, Math.min(nextYRaw, Math.max(0, maxH - win.h)));
      onMove(win.id, nextX, nextY);
    };

    const handleMouseUp = () => {
      dragRef.current = null;
      document.body.style.userSelect = "";
    };

    window.addEventListener("mousemove", handleMouseMove);
    window.addEventListener("mouseup", handleMouseUp);
    return () => {
      window.removeEventListener("mousemove", handleMouseMove);
      window.removeEventListener("mouseup", handleMouseUp);
      document.body.style.userSelect = "";
    };
  }, [onMove, win.id, win.w, win.h]);

  if (typeof document === "undefined") return null;

  return createPortal(
    <div
      className="fixed bg-[#F1F3F8] border border-slate-500 shadow-2xl rounded-sm overflow-hidden pointer-events-auto"
      style={{ left: win.x, top: win.y, width: win.w, height: win.h, zIndex: win.z }}
      onMouseDown={onFocus}
      role="dialog"
      aria-modal="true"
    >
      <div
        className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] border-b border-[#1F2E3F] text-[12px] text-white cursor-move"
        onMouseDown={(e) => {
          onFocus();
          dragRef.current = { dx: e.clientX - win.x, dy: e.clientY - win.y };
          document.body.style.userSelect = "none";
          e.preventDefault();
        }}
      >
        <span className="font-medium">{win.title}</span>
        <button className="hover:bg-white/20 rounded px-1" onClick={onClose} title="Cerrar ventana">
          <X className="h-3.5 w-3.5 text-white" />
        </button>
      </div>
      <div className="h-[calc(100%-31px)] overflow-hidden bg-[#F8FBFF] text-slate-800">{children}</div>
    </div>,
    document.body
  );
}

function BoletaEditor({
  row,
  onClose,
  mode,
  onSave,
}: {
  row: BoletaRow;
  onClose: () => void;
  mode: "view" | "edit" | "new";
  onSave: (next: BoletaRow) => void;
}) {
  const [form, setForm] = useState<BoletaRow>(row);
  const [tipoCambio, setTipoCambio] = useState<string>(() => String(getSessionTipoCambioCompra() ?? "3.402"));
  const editable = mode === "edit" || mode === "new";

  useEffect(() => {
    const sessionValue = getSessionTipoCambioCompra();
    if (sessionValue != null) {
      setTipoCambio(String(sessionValue));
      return;
    }

    fetchSession()
      .then((session) => {
        if (session.tipo_cambio_compra != null) {
          setTipoCambio(String(session.tipo_cambio_compra));
        }
      })
      .catch(() => {
        setTipoCambio("3.402");
      });
  }, []);

  return (
    <div className="h-full flex flex-col overflow-hidden bg-[#F3F6FA] text-[11px] select-none">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-300 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Editar cabecera">
          <Pencil className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Grabar" onClick={() => { onSave(form); onClose(); }}>
          <Save className="h-4 w-4 text-emerald-700" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Reiniciar" onClick={onClose}>
          <RefreshCw className="h-4 w-4 text-blue-600" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Enviar XML">
          <Send className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Imprimir">
          <Printer className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Salir" onClick={onClose}>
          <LogOut className="h-4 w-4 text-red-600" />
        </button>
      </div>

      <div className="text-center text-[11px] font-semibold text-slate-800 py-1 bg-[#EEF2F7] border-b border-slate-300 shrink-0">
        OFICINA: LIMA &nbsp;-&nbsp; ALMACEN: COMERCIAL
      </div>

      <div className="flex-1 overflow-hidden min-h-0">
        <div className="border border-slate-300 bg-[#F8FBFF] p-2 shadow-sm text-[11px] h-full flex flex-col">
          <div className="space-y-1 flex-1 flex flex-col">
            <div className="grid grid-cols-[110px_130px_120px_110px_130px] gap-2 items-center">
              <InlineField label="Número" labelWidth="w-[55px]">
                <input className={`${inp} font-mono`} value={form.numero} onChange={(e) => setForm((p) => ({ ...p, numero: e.target.value }))} readOnly={!editable} />
              </InlineField>
              <InlineField label="Fecha" labelWidth="w-[45px]">
                <input type="date" className={inp} value={form.fecha} onChange={(e) => setForm((p) => ({ ...p, fecha: e.target.value }))} readOnly={!editable} />
              </InlineField>
              <InlineField label="Moneda" labelWidth="w-[52px]">
                <select className={inp} value={form.moneda} onChange={(e) => setForm((p) => ({ ...p, moneda: e.target.value }))} disabled={!editable}>
                  <option value="PEN">PEN (S/)</option>
                  <option value="USD">USD ($)</option>
                </select>
              </InlineField>
              <InlineField label="Total" labelWidth="w-[38px]">
                <input className={`${inp} font-mono`} value={form.total} onChange={(e) => setForm((p) => ({ ...p, total: e.target.value }))} readOnly={!editable} />
              </InlineField>
              <InlineField label="T.Cambio" labelWidth="w-[60px]">
                <input
                  className={`${inp} font-mono`}
                  value={tipoCambio}
                  readOnly
                  placeholder="Tipo de cambio"
                />
              </InlineField>
            </div>

            <div className="grid grid-cols-[1fr_130px_130px] gap-2 items-center">
              <InlineField label="Cliente" labelWidth="w-[60px]">
                <div className="flex gap-1 items-center w-full">
                  <input className={inp} value={form.cliente} onChange={(e) => setForm((p) => ({ ...p, cliente: e.target.value }))} readOnly={!editable} placeholder="(Buscar cliente…)" />
                  <button type="button" className={iconBtn} title="Buscar Cliente">
                    <Search className="h-3.5 w-3.5" />
                  </button>
                </div>
              </InlineField>
              <InlineField label="Estado" labelWidth="w-[46px]">
                <select className={inp} value={form.estado} onChange={(e) => setForm((p) => ({ ...p, estado: e.target.value }))} disabled={!editable}>
                  <option value="GENERADO">GENERADO</option>
                  <option value="APROBADO">APROBADO</option>
                  <option value="CREDITOS">CREDITOS</option>
                  <option value="ANULADO">ANULADO</option>
                </select>
              </InlineField>
              <InlineField label="Código" labelWidth="w-[42px]">
                <input className={inp} value={form.codigo} onChange={(e) => setForm((p) => ({ ...p, codigo: e.target.value }))} readOnly={!editable} />
              </InlineField>
            </div>

            <div className="grid grid-cols-[1fr_180px] gap-2 items-center">
              <InlineField label="Observación" labelWidth="w-[82px]">
                <div className="flex gap-1 items-center w-full">
                  <input className={inp} value={form.observacion} onChange={(e) => setForm((p) => ({ ...p, observacion: e.target.value }))} readOnly={!editable} />
                  <button type="button" className={iconBtn} title="Editar observación">
                    <FileText className="h-3.5 w-3.5" />
                  </button>
                </div>
              </InlineField>
              <InlineField label="Sunat" labelWidth="w-[40px]">
                <select className={inp} value={form.sunat} onChange={(e) => setForm((p) => ({ ...p, sunat: e.target.value }))} disabled={!editable}>
                  <option value="ACEPTADO">ACEPTADO</option>
                  <option value="PENDIENTE">PENDIENTE</option>
                  <option value="ENVIADO">ENVIADO</option>
                  <option value="BAJA">BAJA</option>
                </select>
              </InlineField>
            </div>

            <div className="rounded border border-slate-300 bg-white px-3 py-2">
              <div className="text-[11px] font-semibold text-slate-700 mb-2">Referencia</div>
              <div className="grid gap-2">
                <div className="grid grid-cols-[150px_150px_1fr] gap-2 items-center">
                  <InlineField label="Tipo Doc" labelWidth="w-[58px]">
                    <select className={inp} defaultValue="FACT">
                      <option value="FACT">FACT</option>
                      <option value="BOL">BOL</option>
                    </select>
                  </InlineField>
                  <InlineField label="Serie" labelWidth="w-[42px]">
                    <input className={inp} defaultValue={form.codigo} readOnly />
                  </InlineField>
                  <InlineField label="N° Doc" labelWidth="w-[42px]">
                    <input className={inp} value={form.numero} readOnly />
                  </InlineField>
                </div>
                <div className="grid grid-cols-[180px_1fr] gap-2 items-center">
                  <InlineField label="Tipo Afectación" labelWidth="w-[86px]">
                    <select className={inp} defaultValue="Gravado - Operación One">
                      <option value="Gravado - Operación One">Gravado - Operación One</option>
                      <option value="Exonerado">Exonerado</option>
                      <option value="Inafecto">Inafecto</option>
                    </select>
                  </InlineField>
                  <InlineField label="Motivo" labelWidth="w-[42px]">
                    <input className={inp} value={form.observacion} readOnly={!editable} />
                  </InlineField>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div className="shrink-0 border-t border-slate-300 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-1.5 flex items-center justify-end gap-2">
        <button className={btn} onClick={onClose}><X className="h-3.5 w-3.5" />Cerrar</button>
        <button className={btnPrimary} onClick={() => { onSave(form); onClose(); }}><Save className="h-3.5 w-3.5" />Guardar</button>
      </div>
    </div>
  );
}

export function BoletaList() {
  const [rows, setRows] = useState<BoletaRow[]>(initialRows);
  const [selectedId, setSelectedId] = useState(initialRows[0].id);
  const [showEditor, setShowEditor] = useState(false);
  const [mode, setMode] = useState<"view" | "edit" | "new">("view");
  const [window, setWindow] = useState<BoletaFormWindow>({ id: "boleta-editor", title: "Boleta", x: 170, y: 110, w: 920, h: 560, z: 35 });

  const selectedRow = useMemo(
    () => rows.find((row) => row.id === selectedId) ?? rows[0],
    [rows, selectedId]
  );

  const openNew = () => {
    const next: BoletaRow = {
      id: `B-${Date.now().toString().slice(-4)}`,
      numero: "B001-2001",
      fecha: new Date().toISOString().slice(0, 10),
      cliente: "CLIENTE NUEVO",
      moneda: "PEN",
      total: "0.00",
      estado: "GENERADO",
      sunat: "PENDIENTE",
      codigo: "B001",
      observacion: "Nuevo registro",
    };
    setMode("new");
    setShowEditor(true);
    setSelectedId(next.id);
    setRows((prev) => [next, ...prev]);
  };

  const openEdit = () => {
    if (!selectedRow) return;
    setMode("edit");
    setShowEditor(true);
  };

  const saveRow = (next: BoletaRow) => {
    setRows((prev) => {
      const idx = prev.findIndex((row) => row.id === next.id);
      if (idx >= 0) {
        const copy = [...prev];
        copy[idx] = next;
        return copy;
      }
      return [next, ...prev];
    });
    setSelectedId(next.id);
  };

  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Imprimir Boleta"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Imprimir Ticket"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Enviar a Credito y cobranzas para aprobacion de precios"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Crear un nuevo registro"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Eliminar el registro seleccionado"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Mostrar los Estados de la Boleta"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Anular Boleta"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Facturar OT"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Sugerir Factor / Descuento"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Mostrar Precios Sugeridos"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Enviar Boleta Electronica" onClick={openNew}><Plus className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Refrescar Datos" onClick={openEdit} disabled={!selectedRow}><Search className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Generar Boleta Electronica" disabled={!selectedRow}><Trash2 className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Comunicacion de Baja Boleta Electronica" disabled={!selectedRow}><Send className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Descargar Boleta Electronica" onClick={() => setRows((prev) => [...prev])}><RefreshCw className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Listar Boleta Electronica"><Wrench className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Listar Comunicados Baja"><Mail className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Cerrar la ventana actual"><LogOut className="h-4 w-4" /></button>
      </div>

      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="Año" className="w-[84px]">
          <YearSpinner value="2026" onChange={() => {}} />
        </Field>
        <Field label="Mes" className="w-24"><select className={inp} defaultValue="SEPTIEMBRE"><option>SEPTIEMBRE</option><option>AGOSTO</option><option>JULIO</option></select></Field>
        <Field label="Oficina" className="w-28"><select className={inp} defaultValue="LIMA"><option>LIMA</option><option>AREQUIPA</option></select></Field>
        <Field label="Cliente" className="w-52"><div className="flex gap-1"><input className={inp} defaultValue="(Todos)" /><button className={btn} type="button" title="Buscar cliente"><Search className="h-3 w-3" /></button></div></Field>
        <Field label="Estado" className="w-28"><select className={inp} defaultValue="(Todos)"><option>(Todos)</option><option>GENERADO</option><option>APROBADO</option><option>ANULADO</option></select></Field>
        <Field label="Número" className="w-20"><input className={`${inp} font-mono`} /></Field>
        <button className={btnPrimary}><Search className="h-3.5 w-3.5" />Buscar</button>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <div className="overflow-auto flex-1">
            <table className="w-full text-[11.5px]">
              <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
                <tr>
                  {[
                    "Número",
                    "Fecha",
                    "Cliente",
                    "Mon.",
                    "Total",
                    "EST",
                    "Estado Sunat",
                    "C",
                    "Tot. Neto Sug.",
                    "Observación",
                  ].map((header) => (
                    <th key={header} className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">
                      {header}
                    </th>
                  ))}
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {rows.map((row, index) => (
                  <tr
                    key={row.id}
                    onClick={() => setSelectedId(row.id)}
                    onDoubleClick={() => {
                      setMode("view");
                      setShowEditor(true);
                    }}
                    className={[
                      "cursor-pointer transition-colors",
                      index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]",
                      row.id === selectedId ? "!bg-[#D6E4F4] font-medium" : "hover:bg-[#E8F0F8]/70",
                    ].join(" ")}
                  >
                    <td className="px-3 py-2 border-r border-slate-100 font-mono font-medium">{row.numero}</td>
                    <td className="px-3 py-2 border-r border-slate-100 whitespace-nowrap">{row.fecha}</td>
                    <td className="px-3 py-2 border-r border-slate-100 max-w-[200px] truncate">{row.cliente}</td>
                    <td className="px-3 py-2 border-r border-slate-100">{row.moneda}</td>
                    <td className="px-3 py-2 border-r border-slate-100 font-mono text-right">{row.total}</td>
                    <td className="px-3 py-2 border-r border-slate-100 font-semibold"><EstadoBadge estado={row.estado} /></td>
                    <td className="px-3 py-2 border-r border-slate-100">{row.sunat}</td>
                    <td className="px-3 py-2 border-r border-slate-100">{row.codigo}</td>
                    <td className="px-3 py-2 border-r border-slate-100">-</td>
                    <td className="px-3 py-2">{row.observacion}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      </div>

      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-[11px] text-slate-700 text-center font-medium flex items-center justify-center whitespace-nowrap overflow-hidden">
        Registros : {rows.length}
      </div>

      {showEditor && selectedRow && (
        <DraggableFormWindow
          win={window}
          onFocus={() => setWindow((prev) => ({ ...prev, z: prev.z + 1 }))}
          onMove={(id, x, y) => setWindow((prev) => ({ ...prev, id, x, y }))}
          onClose={() => setShowEditor(false)}
        >
          <BoletaEditor
            row={selectedRow}
            mode={mode}
            onClose={() => setShowEditor(false)}
            onSave={saveRow}
          />
        </DraggableFormWindow>
      )}
    </div>
  );
}
