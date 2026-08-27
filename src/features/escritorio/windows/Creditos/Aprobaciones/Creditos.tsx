// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { useState } from "react";
import { FileSpreadsheet, User } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function AprobacionCreditosList() {
  const [type, setType] = useState("Extensión de línea");
  const [status, setStatus] = useState("Pendiente");
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [message, setMessage] = useState<string | null>(null);

  const handleAprobar = () => setMessage("Solicitud aprobada correctamente.");
  const handleRechazar = () => setMessage("Solicitud rechazada.");

  return (
    <WindowShell title="Aprobación de Créditos y Extensiones"
      toolbar={<>
        <button className={btnPrimary} onClick={handleAprobar}>Aprobar</button>
        <button className={btn} onClick={handleRechazar}>Rechazar</button>
        <button className={btn}><User className="h-3.5 w-3.5" />Ver Historial</button>
        <button className={btn}><FileSpreadsheet className="h-3.5 w-3.5" />Excel</button>
      </>}>
      <div className="grid grid-cols-4 gap-2 mb-2 text-[11px]">
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pendientes:</span> <b className="font-mono text-amber-700">0</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Aprobadas:</span> <b className="font-mono text-emerald-700">0</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Rechazadas:</span> <b className="font-mono text-red-700">0</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Monto Solicitado:</span> <b className="font-mono text-slate-900">0.00</b></div>
      </div>
      <div className="grid grid-cols-6 gap-2 mb-3">
        <Field label="Tipo"><select className={inp} value={type} onChange={(e) => setType(e.target.value)}><option>Extensión de línea</option><option>Cotización especial</option><option>Documento recibido</option></select></Field>
        <Field label="Estado"><select className={inp} value={status} onChange={(e) => setStatus(e.target.value)}><option>Pendiente</option><option>Aprobado</option><option>Rechazado</option></select></Field>
        <Field label="Desde"><input className={inp} type="date" value={fromDate} onChange={(e) => setFromDate(e.target.value)} /></Field>
        <Field label="Hasta"><input className={inp} type="date" value={toDate} onChange={(e) => setToDate(e.target.value)} /></Field>
        <Field label="Analista"><select className={inp}><option>(Todos)</option><option>ANALISTA 01</option><option>ANALISTA 02</option></select></Field>
        <Field label="Cliente"><input className={inp} defaultValue="" /></Field>
      </div>
      {message && <div className="mb-3 rounded-sm border border-slate-300 bg-slate-50 px-3 py-2 text-sm text-slate-700">{message}</div>}
      <div className="border border-slate-300 rounded-sm bg-white overflow-auto"><table className="w-full text-[11px] border-collapse"><thead className="bg-[#F3F6FA]"><tr><th className="px-2 py-2 text-left border-b border-slate-300">#</th><th className="px-2 py-2 text-left border-b border-slate-300">Cliente</th><th className="px-2 py-2 text-left border-b border-slate-300">Solicita</th><th className="px-2 py-2 text-left border-b border-slate-300">Vendedor</th><th className="px-2 py-2 text-right border-b border-slate-300">Monto</th><th className="px-2 py-2 text-left border-b border-slate-300">Línea Actual</th><th className="px-2 py-2 text-left border-b border-slate-300">Línea Solicitada</th><th className="px-2 py-2 text-left border-b border-slate-300">Estado</th><th className="px-2 py-2 text-left border-b border-slate-300">Acción</th></tr></thead><tbody><tr><td colSpan={9} className="px-2 py-4 text-sm text-slate-500">No hay solicitudes de crédito.</td></tr></tbody></table></div>
    </WindowShell>
  );
}
