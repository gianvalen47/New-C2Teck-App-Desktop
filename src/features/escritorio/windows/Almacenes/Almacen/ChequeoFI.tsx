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
import { btnPrimary, iconBtn, inp, squareIconBtn, tbSep } from "@/features/escritorio/windows/uiStyles";

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
    RECHAZADO: "text-red-700 bg-red-50 border-red-200",
    APROBADO: "text-emerald-700 bg-emerald-50 border-emerald-200",
    PENDIENTE: "text-amber-700 bg-amber-50 border-amber-200",
  };
  const cls = map[estado] ?? "text-slate-600 bg-slate-50 border-slate-200";
  return <span className={`inline-flex items-center justify-center px-1.5 py-0.5 text-[10px] font-bold rounded border ${cls}`}>{estado}</span>;
}

const rows = [
  { numero: "FI-1024", fecha: "2026-09-08", proveedor: "IMPORTACIONES DEL SUR", embarque: "EMB-4451", total: "12,540.00", estado: "GENERADO", resultado: "OK" },
  { numero: "FI-1025", fecha: "2026-09-08", proveedor: "MEXA TRADING", embarque: "EMB-4452", total: "8,960.00", estado: "PENDIENTE", resultado: "REVISION" },
  { numero: "FI-1026", fecha: "2026-09-07", proveedor: "RUTAS GLOBAL S.A.", embarque: "EMB-4450", total: "15,120.50", estado: "APROBADO", resultado: "ACEPTADO" },
  { numero: "FI-1027", fecha: "2026-09-06", proveedor: "LOGISTICA FALCON", embarque: "EMB-4449", total: "9,120.00", estado: "RECHAZADO", resultado: "ERROR DOC." },
];

export function ChequeoFIList() {
  return (
    <div className="h-full flex flex-col bg-[#EEF3F8] text-slate-800">
      <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] border-b border-[#1F2E3F] text-[12px] text-white">
        <span className="font-medium">Chequeo de Facturas de Importación</span>
        <div className="flex items-center gap-1">
          <button className={iconBtn} title="Nuevo"><Plus className="h-4 w-4 text-white" /></button>
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
        <div className="grid grid-cols-2 xl:grid-cols-8 gap-2">
          <Field label="Oficina" className="min-w-[120px]"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
          <Field label="Almacén" className="min-w-[130px]"><select className={inp}><option>SERVICIOS</option><option>COMERCIAL</option><option>REPUESTOS</option></select></Field>
          <Field label="Proveedor" className="min-w-[180px]"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Fecha Inicio" className="min-w-[130px]"><input className={inp} type="date" defaultValue="2026-07-01" /></Field>
          <Field label="Fecha Fin" className="min-w-[130px]"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
          <Field label="Estado" className="min-w-[120px]"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>RECHAZADO</option></select></Field>
          <Field label="Embarque" className="min-w-[100px]"><input className={inp} defaultValue="" /></Field>
          <Field label="Número" className="min-w-[100px]"><input className={`${inp} font-mono`} defaultValue="" /></Field>
        </div>
        <div className="mt-2 flex justify-end"><button className={`${btnPrimary} h-7`}><Search className="h-3.5 w-3.5" />Buscar</button></div>
      </div>

      <div className="flex-1 min-h-0 overflow-hidden px-2 pb-2 pt-2">
        <div className="h-full overflow-auto rounded-sm border border-slate-300 bg-white shadow-sm">
          <table className="w-full border-collapse text-[11px]">
            <thead className="sticky top-0 z-10 bg-slate-100 text-slate-700">
              <tr>
                {[
                  "Número",
                  "Fecha",
                  "Proveedor",
                  "Embarque",
                  "Total ($)",
                  "Estado",
                  "Resultado",
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
                  <td className="border-b border-slate-200 px-2 py-1.5 whitespace-nowrap">{row.proveedor}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono">{row.embarque}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right">{row.total}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5"><EstadoBadge estado={row.estado} /></td>
                  <td className="border-b border-slate-200 px-2 py-1.5 text-slate-600">{row.resultado}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}
