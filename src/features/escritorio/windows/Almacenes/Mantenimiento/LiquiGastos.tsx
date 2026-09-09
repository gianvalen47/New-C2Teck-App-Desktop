import type { ReactNode } from "react";
import { ArrowUpDown, LogOut, Plus, RefreshCw, Search, X } from "lucide-react";
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
  { documento: "LG-2026-001", fecha: "2026-09-08", proveedor: "MOBIL PERU", tipo: "Gastos de Almacén", importe: "1,240.00", estado: "PENDIENTE" },
  { documento: "LG-2026-002", fecha: "2026-09-08", proveedor: "TRANSPORTES NORTE", tipo: "Transporte", importe: "940.50", estado: "APROBADO" },
  { documento: "LG-2026-003", fecha: "2026-09-07", proveedor: "SERV. ENERGIA", tipo: "Servicios", importe: "1,680.00", estado: "PENDIENTE" },
  { documento: "LG-2026-004", fecha: "2026-09-05", proveedor: "LIMACORP", tipo: "Gastos de Almacén", importe: "760.00", estado: "CERRADO" },
];

export function LiquiGastosList() {
  return (
    <div className="h-full flex flex-col bg-[#EEF3F8] text-slate-800">
      <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] border-b border-[#1F2E3F] text-[12px] text-white">
        <span className="font-medium">Liquidación de Gastos</span>
        <div className="flex items-center gap-1">
          <button className={iconBtn} title="Nuevo"><Plus className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Buscar"><Search className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Refrescar"><RefreshCw className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4 text-white" /></button>
        </div>
      </div>

      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EDF2F7] to-[#D9E2EC] border-b border-slate-300 text-slate-700 overflow-x-auto">
        <button className={squareIconBtn} title="Nuevo"><Plus className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Refrescar"><RefreshCw className="h-3.5 w-3.5" /></button>
        {tbSep}
        <button className={squareIconBtn} title="Cerrar"><X className="h-3.5 w-3.5" /></button>
      </div>

      <div className="px-2 py-2 border-b border-slate-300 bg-[#F7FAFC]">
        <div className="grid grid-cols-2 xl:grid-cols-5 gap-2">
          <Field label="Año" className="min-w-[90px]"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
          <Field label="Mes" className="min-w-[120px]"><select className={inp}><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
          <Field label="Tipo" className="min-w-[180px]"><select className={inp}><option>Gastos de Almacén</option><option>Servicios</option><option>Transporte</option></select></Field>
          <Field label="Número" className="min-w-[140px]"><input className={`${inp} font-mono`} /></Field>
          <div className="flex items-end"><button className={`${btnPrimary} h-7 w-full`}><Search className="h-3.5 w-3.5" />Buscar</button></div>
        </div>
      </div>

      <div className="flex-1 min-h-0 overflow-hidden px-2 pb-2 pt-2">
        <div className="h-full overflow-auto rounded-sm border border-slate-300 bg-white shadow-sm">
          <table className="w-full border-collapse text-[11px]">
            <thead className="sticky top-0 z-10 bg-slate-100 text-slate-700">
              <tr>
                {[
                  "Documento",
                  "Fecha",
                  "Proveedor",
                  "Tipo",
                  "Importe",
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
                <tr key={row.documento} className="hover:bg-slate-50">
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-slate-700">{row.documento}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.fecha}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 whitespace-nowrap">{row.proveedor}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.tipo}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right">{row.importe}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5"><span className="inline-flex items-center justify-center rounded border border-slate-200 bg-slate-50 px-1.5 py-0.5 text-[10px] font-bold text-slate-700">{row.estado}</span></td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}
