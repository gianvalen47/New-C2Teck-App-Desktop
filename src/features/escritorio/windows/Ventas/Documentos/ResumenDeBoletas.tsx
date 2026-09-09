import { createPortal } from "react-dom";
import { useEffect, useMemo, useRef, useState, type ReactNode } from "react";
import {
  CalendarDays,
  FileText,
  LogOut,
  Mail,
  Pencil,
  Plus,
  Printer,
  RefreshCw,
  Save,
  Search,
  Send,
  Trash2,
  Wrench,
  X,
} from "lucide-react";
import { actionBtn, btn, btnPrimary, iconBtn, inp, squareIconBtn, tbSep } from "@/features/escritorio/windows/uiStyles";

type ResumenBoletaRow = {
  id: string;
  codigo: string;
  fecha: string;
  ticket: string;
  cliente: string;
  observacion: string;
  notas: string;
  sunat: string;
  estado: string;
  oficina: string;
  almacen: string;
};

const initialRows: ResumenBoletaRow[] = [
  { id: "RB-1001", codigo: "R001-1001", fecha: "2026-09-08", ticket: "TKT-0001", cliente: "LUCY VENTAS S.A.C.", observacion: "Venta al contado", notas: "Entrega programada", sunat: "ACEPTADO", estado: "GENERADO", oficina: "LIMA", almacen: "COMERCIAL" },
  { id: "RB-1002", codigo: "R001-1002", fecha: "2026-09-08", ticket: "TKT-0002", cliente: "MERCADOS DEL SUR", observacion: "Recarga de stock", notas: "Con ticket adjunto", sunat: "PENDIENTE", estado: "ENVIADO", oficina: "LIMA", almacen: "BODEGA 01" },
  { id: "RB-1003", codigo: "R001-1003", fecha: "2026-09-07", ticket: "TKT-0003", cliente: "INVERSIONES PUNTO DOC", observacion: "Venta con tarjeta", notas: "No requiere seguimiento", sunat: "ENVIADO", estado: "APROBADO", oficina: "AREQUIPA", almacen: "PRINCIPAL" },
  { id: "RB-1004", codigo: "R001-1004", fecha: "2026-09-06", ticket: "TKT-0004", cliente: "ALMACEN DEL NORTE", observacion: "Cargo por devolucion", notas: "Atender con cobranza", sunat: "BAJA", estado: "ANULADO", oficina: "TRUJILLO", almacen: "ALMACÉN" },
  { id: "RB-1005", codigo: "R001-1005", fecha: "2026-09-05", ticket: "TKT-0005", cliente: "COSTA BRAVA EIRL", observacion: "Venta normal", notas: "Sin observación", sunat: "PENDIENTE", estado: "GENERADO", oficina: "LIMA", almacen: "COMERCIAL" },
];

const ESTADO_COLORS: Record<string, string> = {
  ACEPTADO: "text-green-700 bg-green-50 border-green-200",
  PENDIENTE: "text-amber-700 bg-amber-50 border-amber-200",
  ENVIADO: "text-blue-700 bg-blue-50 border-blue-200",
  BAJA: "text-red-700 bg-red-50 border-red-200",
  GENERADO: "text-sky-700 bg-sky-50 border-sky-200",
  APROBADO: "text-emerald-700 bg-emerald-50 border-emerald-200",
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

type ResumenBoletaFormWindow = {
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
  win: ResumenBoletaFormWindow;
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

function ResumenEditor({
  row,
  onClose,
  mode,
  onSave,
}: {
  row: ResumenBoletaRow;
  onClose: () => void;
  mode: "view" | "edit" | "new";
  onSave: (next: ResumenBoletaRow) => void;
}) {
  const [form, setForm] = useState<ResumenBoletaRow>(row);
  const editable = mode === "edit" || mode === "new";

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
        <button className={iconBtn} title="Imprimir documento">
          <Printer className="h-4 w-4" />
        </button>
        {tbSep}
        <button className={iconBtn} title="Salir" onClick={onClose}>
          <LogOut className="h-4 w-4 text-red-600" />
        </button>
      </div>

      <div className="text-center text-[11px] font-semibold text-slate-800 py-1 bg-[#EEF2F7] border-b border-slate-300 shrink-0">
        OFICINA: {form.oficina} &nbsp;-&nbsp; ALMACEN: {form.almacen}
      </div>

      <div className="flex-1 overflow-hidden min-h-0">
        <div className="border border-slate-300 bg-[#F8FBFF] p-2 shadow-sm text-[11px] h-full flex flex-col">
          <div className="space-y-1 flex-1 flex flex-col">
            <div className="grid grid-cols-[160px_150px_150px_150px] gap-2 items-center">
              <InlineField label="Código" labelWidth="w-[55px]">
                <input className={`${inp} font-mono`} value={form.codigo} onChange={(e) => setForm((p) => ({ ...p, codigo: e.target.value }))} readOnly={!editable} />
              </InlineField>
              <InlineField label="Fecha" labelWidth="w-[45px]">
                <input type="date" className={inp} value={form.fecha} onChange={(e) => setForm((p) => ({ ...p, fecha: e.target.value }))} readOnly={!editable} />
              </InlineField>
              <InlineField label="Ticket" labelWidth="w-[48px]">
                <input className={`${inp} font-mono`} value={form.ticket} onChange={(e) => setForm((p) => ({ ...p, ticket: e.target.value }))} readOnly={!editable} />
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

            <div className="grid grid-cols-[1fr_150px_140px] gap-2 items-center">
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
                  <option value="ENVIADO">ENVIADO</option>
                  <option value="ANULADO">ANULADO</option>
                </select>
              </InlineField>
              <InlineField label="Oficina" labelWidth="w-[52px]">
                <input className={inp} value={form.oficina} onChange={(e) => setForm((p) => ({ ...p, oficina: e.target.value }))} readOnly={!editable} />
              </InlineField>
            </div>

            <div className="grid grid-cols-[1fr_160px] gap-2 items-center">
              <InlineField label="Observación" labelWidth="w-[82px]">
                <div className="flex gap-1 items-center w-full">
                  <input className={inp} value={form.observacion} onChange={(e) => setForm((p) => ({ ...p, observacion: e.target.value }))} readOnly={!editable} />
                  <button type="button" className={iconBtn} title="Editar observación">
                    <FileText className="h-3.5 w-3.5" />
                  </button>
                </div>
              </InlineField>
              <InlineField label="Almacén" labelWidth="w-[64px]">
                <input className={inp} value={form.almacen} onChange={(e) => setForm((p) => ({ ...p, almacen: e.target.value }))} readOnly={!editable} />
              </InlineField>
            </div>

            <div className="rounded border border-slate-300 bg-white px-3 py-2">
              <div className="text-[11px] font-semibold text-slate-700 mb-2">Notas / Referencia</div>
              <div className="grid gap-2">
                <InlineField label="Notas" labelWidth="w-[56px]">
                  <input className={inp} value={form.notas} onChange={(e) => setForm((p) => ({ ...p, notas: e.target.value }))} readOnly={!editable} />
                </InlineField>
                <InlineField label="Motivo" labelWidth="w-[46px]">
                  <input className={inp} value={form.observacion} onChange={(e) => setForm((p) => ({ ...p, observacion: e.target.value }))} readOnly={!editable} />
                </InlineField>
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

export function ResumenDeBoletasList() {
  const [rows, setRows] = useState<ResumenBoletaRow[]>(initialRows);
  const [selectedId, setSelectedId] = useState(initialRows[0].id);
  const [showEditor, setShowEditor] = useState(false);
  const [mode, setMode] = useState<"view" | "edit" | "new">("view");
  const [window, setWindow] = useState<ResumenBoletaFormWindow>({ id: "resumen-boletas-editor", title: "Resumen de Boleta", x: 180, y: 120, w: 920, h: 480, z: 35 });

  const selectedRow = useMemo(
    () => rows.find((row) => row.id === selectedId) ?? rows[0],
    [rows, selectedId]
  );

  const openNew = () => {
    const next: ResumenBoletaRow = {
      id: `RB-${Date.now().toString().slice(-4)}`,
      codigo: `R001-${Date.now().toString().slice(-4)}`,
      fecha: new Date().toISOString().slice(0, 10),
      ticket: `TKT-${Date.now().toString().slice(-4)}`,
      cliente: "CLIENTE NUEVO",
      observacion: "Nuevo registro",
      notas: "Sin notas",
      sunat: "PENDIENTE",
      estado: "GENERADO",
      oficina: "LIMA",
      almacen: "COMERCIAL",
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

  const saveRow = (next: ResumenBoletaRow) => {
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
        <button className={iconBtn} title="Imprimir resumen"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Crear nuevo registro" onClick={openNew}><Plus className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Ver registro seleccionado" onClick={openEdit} disabled={!selectedRow}><Search className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Eliminar registro seleccionado" disabled={!selectedRow}><Trash2 className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Enviar resumen"><Send className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar" onClick={() => setRows((prev) => [...prev])}><RefreshCw className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Gestión"><Wrench className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Mensajería"><Mail className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Cerrar ventana"><LogOut className="h-4 w-4" /></button>
      </div>

      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="Año" className="w-14"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
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
                    "Cod. Resumen",
                    "Fecha",
                    "N° Ticket",
                    "Cliente",
                    "Observación",
                    "Notas",
                    "Estado Sunat",
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
                    <td className="px-3 py-2 border-r border-slate-100 font-mono font-medium">{row.codigo}</td>
                    <td className="px-3 py-2 border-r border-slate-100 whitespace-nowrap">{row.fecha}</td>
                    <td className="px-3 py-2 border-r border-slate-100 font-mono text-center">{row.ticket}</td>
                    <td className="px-3 py-2 border-r border-slate-100 max-w-[220px] truncate">{row.cliente}</td>
                    <td className="px-3 py-2 border-r border-slate-100 max-w-[180px] truncate">{row.observacion}</td>
                    <td className="px-3 py-2 border-r border-slate-100 max-w-[180px] truncate">{row.notas}</td>
                    <td className="px-3 py-2 text-center"><EstadoBadge estado={row.sunat} /></td>
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
          <ResumenEditor
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

export function ResumenBoletas() {
  return <ResumenDeBoletasList />;
}
