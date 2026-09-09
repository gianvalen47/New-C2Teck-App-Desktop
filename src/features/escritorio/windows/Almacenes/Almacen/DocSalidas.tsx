import type { ReactNode } from "react";
import {
  ArrowUpDown,
  FileDown,
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
    ANULADO: "text-red-700 bg-red-50 border-red-200",
    ENTREGADO: "text-emerald-700 bg-emerald-50 border-emerald-200",
    PENDIENTE: "text-amber-700 bg-amber-50 border-amber-200",
  };
  const cls = map[estado] ?? "text-slate-600 bg-slate-50 border-slate-200";
  return <span className={`inline-flex items-center justify-center px-1.5 py-0.5 text-[10px] font-bold rounded border ${cls}`}>{estado}</span>;
}

const rows = [
  { numero: "S-1048", tipo: "FV", fecha: "2026-09-08", ot: "OT-2458", cliente: "LUCY VENTAS S.A.C.", moneda: "PEN", total: "1,248.00", estado: "GENERADO" },
  { numero: "S-1049", tipo: "GI", fecha: "2026-09-08", ot: "OT-2141", cliente: "MERCADOS DEL SUR", moneda: "PEN", total: "2,430.50", estado: "ENTREGADO" },
  { numero: "S-1050", tipo: "NS", fecha: "2026-09-07", ot: "OT-1889", cliente: "INVERSIONES PUNTO DOC", moneda: "USD", total: "518.25", estado: "PENDIENTE" },
  { numero: "S-1051", tipo: "FV", fecha: "2026-09-06", ot: "OT-1733", cliente: "ALMACEN DEL NORTE", moneda: "PEN", total: "3,600.00", estado: "ANULADO" },
];

export function DocSalidasList() {
  return (
    <div className="h-full flex flex-col bg-[#EEF3F8] text-slate-800">
      <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] border-b border-[#1F2E3F] text-[12px] text-white">
        <span className="font-medium">Movimiento de Salidas Almacén</span>
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
          <Field label="Año" className="min-w-[80px]"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
          <Field label="Mes" className="min-w-[120px]"><select className={inp} defaultValue="JULIO"><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
          <Field label="Oficina" className="min-w-[120px]"><select className={inp}><option>LIMA</option><option>AREQUIPA</option><option>TRUJILLO</option></select></Field>
          <Field label="Almacén" className="min-w-[140px]"><select className={inp}><option>COMERCIAL</option><option>REPUESTOS</option><option>SERVICIOS</option></select></Field>
          <Field label="Tipo Documento" className="min-w-[160px]"><select className={inp}><option>(Todos)</option><option>Factura Venta</option><option>Guía Interna</option><option>Nota de Salida</option></select></Field>
          <Field label="Cliente" className="min-w-[180px]"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Estado" className="min-w-[120px]"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>ANULADO</option><option>ENTREGADO</option></select></Field>
          <Field label="Número" className="min-w-[100px]"><input className={`${inp} font-mono`} defaultValue="" /></Field>
        </div>
        <div className="mt-2 flex justify-end"><button className={`${btnPrimary} h-7`}><Search className="h-3.5 w-3.5" />Buscar</button></div>
      </div>

      <div className="px-2 py-2">
        <div className="grid grid-cols-2 xl:grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Generados:</span> <b className="font-mono text-slate-900">4</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Entregados:</span> <b className="font-mono text-emerald-700">1</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Anulados:</span> <b className="font-mono text-red-700">1</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Total S/:</span> <b className="font-mono text-slate-900">7,797.75</b></div>
        </div>
      </div>

      <div className="flex-1 min-h-0 overflow-hidden px-2 pb-2">
        <div className="h-full overflow-auto rounded-sm border border-slate-300 bg-white shadow-sm">
          <table className="w-full border-collapse text-[11px]">
            <thead className="sticky top-0 z-10 bg-slate-100 text-slate-700">
              <tr>
                {[
                  "Número",
                  "T.Doc.",
                  "Fecha",
                  "# OT",
                  "Cliente",
                  "Mon.",
                  "Total",
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
                  <td className="border-b border-slate-200 px-2 py-1.5 font-semibold text-slate-700">{row.tipo}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.fecha}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono">{row.ot}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 whitespace-nowrap">{row.cliente}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.moneda}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right">{row.total}</td>
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
