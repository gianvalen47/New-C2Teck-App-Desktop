import type { ReactNode } from "react";
import { ArrowLeft, ArrowRight, ArrowUpDown, LogOut, Search, X } from "lucide-react";
import { btn, btnPrimary, iconBtn, inp, squareIconBtn, tbSep } from "@/features/escritorio/windows/uiStyles";

function Panel({ title, children }: { title: string; children: ReactNode }) {
  return (
    <div className="rounded-sm border border-slate-300 bg-white shadow-sm">
      <div className="flex items-center justify-between border-b border-slate-300 bg-slate-100 px-2 py-1.5 text-[11px] font-semibold text-slate-700">
        <span>{title}</span>
      </div>
      <div className="p-2">{children}</div>
    </div>
  );
}

const rows = [
  { indicador: "ROTACION ALMACEN", um: "%", frecuencia: "MENSUAL", pb: "72", obj: "78", real: "81", trafico: "OK", g: "A" },
  { indicador: "COSTO INVENTARIO", um: "S/", frecuencia: "MENSUAL", pb: "245k", obj: "270k", real: "263k", trafico: "OK", g: "A" },
  { indicador: "STOCK CRITICO", um: "UND", frecuencia: "DIARIA", pb: "18", obj: "12", real: "14", trafico: "WARN", g: "B" },
  { indicador: "GASTO LOGISTICO", um: "%", frecuencia: "SEMANAL", pb: "11.2", obj: "10.0", real: "9.8", trafico: "OK", g: "A" },
];

export function IndicadoresVentaDialogList() {
  return (
    <div className="h-full flex flex-col bg-[#EEF3F8] text-slate-800">
      <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] border-b border-[#1F2E3F] text-[12px] text-white">
        <span className="font-medium">Tablero de Indicadores</span>
        <div className="flex items-center gap-1">
          <button className={iconBtn} title="Buscar"><Search className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4 text-white" /></button>
        </div>
      </div>

      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EDF2F7] to-[#D9E2EC] border-b border-slate-300 text-slate-700 overflow-x-auto">
        <button className={squareIconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Anterior"><ArrowLeft className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Siguiente"><ArrowRight className="h-3.5 w-3.5" /></button>
        {tbSep}
        <button className={squareIconBtn} title="Cerrar"><X className="h-3.5 w-3.5" /></button>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-3">
        <div className="mx-auto max-w-4xl space-y-3 text-[11.5px]">
          <Panel title="Mensual">
            <div className="flex items-center justify-center gap-2">
              <span className="font-bold text-slate-800">Fecha Mensual :</span>
              <input className={`${inp} w-28`} defaultValue="09-2024" />
              <button className={`${btnPrimary} h-7`}><Search className="h-3.5 w-3.5" />Buscar</button>
            </div>
            <div className="mt-2 overflow-hidden rounded-sm border border-slate-300">
              <table className="w-full border-collapse text-[11px]">
                <thead className="bg-slate-100 text-slate-700">
                  <tr>
                    {[
                      "INDICADOR",
                      "U/M",
                      "FRECUENCIA",
                      "PB",
                      "OBJ.",
                      "REAL",
                      "🚦",
                      "G",
                    ].map((h) => (
                      <th key={h} className="border-b border-slate-300 px-2 py-1.5 text-left font-semibold whitespace-nowrap">
                        <span className="inline-flex items-center gap-1"><ArrowUpDown className="h-3 w-3 opacity-60" />{h}</span>
                      </th>
                    ))}
                  </tr>
                </thead>
                <tbody>
                  {rows.map((row) => (
                    <tr key={row.indicador} className="hover:bg-slate-50">
                      <td className="border-b border-slate-200 px-2 py-1.5 font-semibold">{row.indicador}</td>
                      <td className="border-b border-slate-200 px-2 py-1.5">{row.um}</td>
                      <td className="border-b border-slate-200 px-2 py-1.5">{row.frecuencia}</td>
                      <td className="border-b border-slate-200 px-2 py-1.5 font-mono">{row.pb}</td>
                      <td className="border-b border-slate-200 px-2 py-1.5 font-mono">{row.obj}</td>
                      <td className="border-b border-slate-200 px-2 py-1.5 font-mono">{row.real}</td>
                      <td className="border-b border-slate-200 px-2 py-1.5"><span className="inline-flex items-center justify-center rounded border border-slate-200 bg-slate-50 px-1.5 py-0.5 text-[10px] font-bold text-slate-700">{row.trafico}</span></td>
                      <td className="border-b border-slate-200 px-2 py-1.5">{row.g}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </Panel>

          <Panel title="Diario">
            <div className="flex items-center justify-center gap-2">
              <span className="font-bold text-slate-800">Fecha Diaria :</span>
              <input className={`${inp} w-32`} type="date" defaultValue="2026-07-16" />
              <button className={`${btn} h-7`}><Search className="h-3.5 w-3.5" />Buscar</button>
              <button className={iconBtn} title="Anterior"><ArrowLeft className="h-4 w-4" /></button>
              <button className={iconBtn} title="Siguiente"><ArrowRight className="h-4 w-4" /></button>
            </div>
            <div className="mt-2 overflow-hidden rounded-sm border border-slate-300">
              <table className="w-full border-collapse text-[11px]">
                <thead className="bg-slate-100 text-slate-700">
                  <tr>
                    {[
                      "INDICADOR",
                      "U/M",
                      "FRECUENCIA",
                      "PB",
                      "OBJ.",
                      "REAL",
                      "🚦",
                      "G",
                    ].map((h) => (
                      <th key={h} className="border-b border-slate-300 px-2 py-1.5 text-left font-semibold whitespace-nowrap">
                        <span className="inline-flex items-center gap-1"><ArrowUpDown className="h-3 w-3 opacity-60" />{h}</span>
                      </th>
                    ))}
                  </tr>
                </thead>
                <tbody>
                  {rows.map((row) => (
                    <tr key={`${row.indicador}-daily`} className="hover:bg-slate-50">
                      <td className="border-b border-slate-200 px-2 py-1.5 font-semibold">{row.indicador}</td>
                      <td className="border-b border-slate-200 px-2 py-1.5">{row.um}</td>
                      <td className="border-b border-slate-200 px-2 py-1.5">{row.frecuencia}</td>
                      <td className="border-b border-slate-200 px-2 py-1.5 font-mono">{row.pb}</td>
                      <td className="border-b border-slate-200 px-2 py-1.5 font-mono">{row.obj}</td>
                      <td className="border-b border-slate-200 px-2 py-1.5 font-mono">{row.real}</td>
                      <td className="border-b border-slate-200 px-2 py-1.5"><span className="inline-flex items-center justify-center rounded border border-slate-200 bg-slate-50 px-1.5 py-0.5 text-[10px] font-bold text-slate-700">{row.trafico}</span></td>
                      <td className="border-b border-slate-200 px-2 py-1.5">{row.g}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </Panel>
        </div>
      </div>
    </div>
  );
}
