import type { ReactNode } from "react";
import {
  ArrowUpDown,
  FileDown,
  FileSearch,
  LogOut,
  Pencil,
  Plus,
  Printer,
  RefreshCw,
  Search,
  Send,
  Trash2,
  X,
} from "lucide-react";
import { btn, btnPrimary, iconBtn, inp, squareIconBtn, tbSep } from "@/features/escritorio/windows/uiStyles";

function Field({ label, className = "", children }: { label: string; className?: string; children: ReactNode }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium leading-tight">{label}</span>
      {children}
    </label>
  );
}

function EstadoBadge({ estado }: { estado: string }) {
  const map: Record<string, string> = {
    GENERADO: "text-blue-700 bg-blue-50 border-blue-200",
    "EN RUTA": "text-amber-700 bg-amber-50 border-amber-200",
    FINALIZADO: "text-emerald-700 bg-emerald-50 border-emerald-200",
    ANULADO: "text-red-700 bg-red-50 border-red-200",
  };

  const cls = map[estado] ?? "text-slate-600 bg-slate-50 border-slate-200";
  return <span className={`inline-flex items-center justify-center px-1.5 py-0.5 text-[10px] font-bold rounded border ${cls}`}>{estado}</span>;
}

const rows = [
  { numero: "D-0001", fecha: "2026-09-08", salida: "07:30", retorno: "12:15", chofer: "MARCO RUIZ", placa: "ABC-123", destino: "LIMA - SURCO", observacion: "Ruta normal", estado: "GENERADO" },
  { numero: "D-0002", fecha: "2026-09-08", salida: "08:10", retorno: "13:40", chofer: "JORGE SANTOS", placa: "DEF-456", destino: "CALLAO", observacion: "Entrega parcial", estado: "EN RUTA" },
  { numero: "D-0003", fecha: "2026-09-07", salida: "06:50", retorno: "11:00", chofer: "LUIS TORRES", placa: "GHI-789", destino: "TRUJILLO", observacion: "Sin incidencias", estado: "FINALIZADO" },
  { numero: "D-0004", fecha: "2026-09-07", salida: "09:00", retorno: "14:20", chofer: "PEDRO MORALES", placa: "JKL-012", destino: "AREQUIPA", observacion: "Cancelado por cliente", estado: "ANULADO" },
];

export function DespachoList2() {
  return (
    <div className="h-full flex flex-col bg-[#EEF3F8] text-slate-800">
      <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] border-b border-[#1F2E3F] text-[12px] text-white">
        <span className="font-medium">Despachos</span>
        <div className="flex items-center gap-1">
          <button className={iconBtn} title="Nuevo despacho"><Plus className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Buscar"><Search className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4 text-white" /></button>
        </div>
      </div>

      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EDF2F7] to-[#D9E2EC] border-b border-slate-300 text-slate-700 overflow-x-auto">
        <button className={squareIconBtn} title="Nuevo"><Plus className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Editar"><Pencil className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Eliminar"><Trash2 className="h-3.5 w-3.5" /></button>
        {tbSep}
        <button className={squareIconBtn} title="Imprimir"><Printer className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Enviar"><Send className="h-3.5 w-3.5" /></button>
        {tbSep}
        <button className={squareIconBtn} title="Actualizar"><RefreshCw className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Exportar"><FileDown className="h-3.5 w-3.5" /></button>
        {tbSep}
        <button className={squareIconBtn} title="Cerrar"><X className="h-3.5 w-3.5" /></button>
      </div>

      <div className="px-2 py-2 border-b border-slate-300 bg-[#F7FAFC]">
        <div className="grid grid-cols-2 xl:grid-cols-6 gap-2">
          <Field label="Fecha Inicio" className="min-w-[120px]"><input type="date" className={inp} defaultValue="2026-07-01" /></Field>
          <Field label="Fecha Fin" className="min-w-[120px]"><input type="date" className={inp} defaultValue="2026-07-21" /></Field>
          <Field label="Chofer" className="min-w-[180px]"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Placa" className="min-w-[110px]"><input className={`${inp} font-mono`} defaultValue="" /></Field>
          <Field label="Estado" className="min-w-[120px]"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>EN RUTA</option><option>FINALIZADO</option><option>ANULADO</option></select></Field>
          <div className="flex items-end"><button className={`${btnPrimary} h-7 w-full`}><Search className="h-3.5 w-3.5" />Buscar</button></div>
        </div>
      </div>

      <div className="px-2 py-2">
        <div className="grid grid-cols-2 xl:grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pendientes:</span> <b className="font-mono text-slate-900">1</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">En ruta:</span> <b className="font-mono text-amber-700">1</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Finalizados:</span> <b className="font-mono text-emerald-700">1</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Anulados:</span> <b className="font-mono text-red-700">1</b></div>
        </div>
      </div>

      <div className="flex-1 min-h-0 overflow-hidden px-2 pb-2">
        <div className="h-full overflow-auto rounded-sm border border-slate-300 bg-white shadow-sm">
          <table className="w-full border-collapse text-[11px]">
            <thead className="sticky top-0 z-10 bg-slate-100 text-slate-700">
              <tr>
                {[
                  "Número",
                  "Fecha",
                  "Hora Salida",
                  "Hora Retorno",
                  "Chofer",
                  "Placa",
                  "Destino",
                  "Observación",
                  "Estado",
                ].map((h) => (
                  <th key={h} className="border-b border-slate-300 px-2 py-1.5 text-left font-semibold whitespace-nowrap">
                    <span className="inline-flex items-center gap-1"><ArrowUpDown className="h-3 w-3 opacity-60" />{h}</span>
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {rows.map((row) => (
                <tr key={row.numero} className="hover:bg-slate-50">
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-slate-700">{row.numero}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.fecha}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.salida}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.retorno}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 whitespace-nowrap">{row.chofer}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono">{row.placa}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.destino}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.observacion}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5"><EstadoBadge estado={row.estado} /></td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}
