import type { ReactNode } from "react";
import { ArrowUpDown, FileDown, LogOut, Pencil, Plus, Printer, RefreshCw, Search, Send, Trash2, X } from "lucide-react";
import { btn, btnPrimary, iconBtn, inp, squareIconBtn, tbSep } from "@/features/escritorio/windows/uiStyles";

function Field({ label, className = "", children }: { label: string; className?: string; children: ReactNode }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium leading-tight">{label}</span>
      {children}
    </label>
  );
}

const rows = [
  { numero: "TR-017", fecha: "2026-09-08", ot: "OT-2458", cliente: "LUCY VENTAS S.A.C.", moneda: "PEN", total: "1,248.00", est: "EN PROCESO", origen: "COMERCIAL", destino: "SERVICIOS" },
  { numero: "TR-018", fecha: "2026-09-08", ot: "OT-2141", cliente: "MERCADOS DEL SUR", moneda: "PEN", total: "2,430.50", est: "CERRADO", origen: "NORTE", destino: "CENTRAL" },
  { numero: "TR-019", fecha: "2026-09-07", ot: "OT-1889", cliente: "INVERSIONES PUNTO DOC", moneda: "USD", total: "518.25", est: "ANULADO", origen: "SERVICIOS", destino: "SUR" },
];

export function TransitoDocsList() {
  return (
    <div className="h-full flex flex-col bg-[#EEF3F8] text-slate-800">
      <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] border-b border-[#1F2E3F] text-[12px] text-white">
        <span className="font-medium">Transferencias Internas</span>
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
          <Field label="Cliente" className="min-w-[180px]"><input className={inp} defaultValue="(Todos)" /></Field>
          <Field label="Estado" className="min-w-[120px]"><select className={inp}><option>(Todos)</option><option>GENERADO</option><option>EN PROCESO</option><option>CERRADO</option></select></Field>
          <Field label="# OT" className="min-w-[100px]"><input className={`${inp} font-mono`} defaultValue="" /></Field>
          <Field label="Número" className="min-w-[100px]"><input className={`${inp} font-mono`} defaultValue="" /></Field>
        </div>
        <div className="mt-2 flex justify-end"><button className={`${btnPrimary} h-7`}><Search className="h-3.5 w-3.5" />Buscar</button></div>
      </div>

      <div className="px-2 py-2">
        <div className="grid grid-cols-2 xl:grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">En proceso:</span> <b className="font-mono text-amber-700">1</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Cerradas:</span> <b className="font-mono text-emerald-700">1</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Anuladas:</span> <b className="font-mono text-red-700">1</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Monto:</span> <b className="font-mono text-slate-900">4,197.00</b></div>
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
                  "# OT",
                  "Cliente",
                  "Mon.",
                  "Total",
                  "Est.",
                  "Origen",
                  "Destino",
                  "Acción",
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
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono">{row.ot}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 whitespace-nowrap">{row.cliente}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.moneda}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right">{row.total}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5"><span className="inline-flex items-center justify-center rounded border border-slate-200 bg-slate-50 px-1.5 py-0.5 text-[10px] font-bold text-slate-700">{row.est}</span></td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.origen}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.destino}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5"><button className={btn}>Ver</button></td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}
