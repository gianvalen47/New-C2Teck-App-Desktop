import type { ReactNode } from "react";
import { ArrowUpDown, LogOut, RefreshCw, Search, X } from "lucide-react";
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
  { producto: "BOMBA HIDRAULICA X90", stockActual: "120", stockCritico: "26", cobertura: "38 días", sugerido: "55" },
  { producto: "FILTRO DE AIRE 250", stockActual: "85", stockCritico: "18", cobertura: "29 días", sugerido: "42" },
  { producto: "ACEITE LUBRIFICANTE 4L", stockActual: "64", stockCritico: "22", cobertura: "31 días", sugerido: "48" },
  { producto: "RODAMIENTO 6205", stockActual: "40", stockCritico: "12", cobertura: "18 días", sugerido: "22" },
];

export function ProcesarCoberturaList() {
  return (
    <div className="h-full flex flex-col bg-[#EEF3F8] text-slate-800">
      <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] border-b border-[#1F2E3F] text-[12px] text-white">
        <span className="font-medium">Procesar Cobertura</span>
        <div className="flex items-center gap-1">
          <button className={iconBtn} title="Procesar"><RefreshCw className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Ver resultados"><Search className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4 text-white" /></button>
        </div>
      </div>

      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EDF2F7] to-[#D9E2EC] border-b border-slate-300 text-slate-700 overflow-x-auto">
        <button className={squareIconBtn} title="Procesar"><RefreshCw className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Ver resultados"><Search className="h-3.5 w-3.5" /></button>
        {tbSep}
        <button className={squareIconBtn} title="Cerrar"><X className="h-3.5 w-3.5" /></button>
      </div>

      <div className="px-2 py-2 border-b border-slate-300 bg-[#F7FAFC]">
        <div className="grid grid-cols-1 md:grid-cols-3 gap-2">
          <Field label="Año" className="min-w-[90px]"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
          <Field label="Mes" className="min-w-[120px]"><select className={inp}><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
          <Field label="Almacén" className="min-w-[160px]"><select className={inp}><option>Central Lima</option><option>Norte</option><option>Sur</option></select></Field>
        </div>
        <div className="mt-2 flex justify-end"><button className={`${btnPrimary} h-7`}><RefreshCw className="h-3.5 w-3.5" />Procesar</button></div>
      </div>

      <div className="flex-1 min-h-0 overflow-hidden px-2 pb-2 pt-2">
        <div className="h-full overflow-auto rounded-sm border border-slate-300 bg-white shadow-sm">
          <table className="w-full border-collapse text-[11px]">
            <thead className="sticky top-0 z-10 bg-slate-100 text-slate-700">
              <tr>
                {[
                  "Producto",
                  "Stock Actual",
                  "Stock Crítico",
                  "Cobertura Días",
                  "Sugerido",
                ].map((h) => (
                  <th key={h} className="border-b border-slate-300 px-2 py-1.5 text-left font-semibold whitespace-nowrap">
                    <span className="inline-flex items-center gap-1"><ArrowUpDown className="h-3 w-3 opacity-60" />{h}</span>
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {rows.map((row) => (
                <tr key={row.producto} className="hover:bg-slate-50">
                  <td className="border-b border-slate-200 px-2 py-1.5 whitespace-nowrap">{row.producto}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right">{row.stockActual}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right">{row.stockCritico}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right">{row.cobertura}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right text-emerald-700">{row.sugerido}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}

