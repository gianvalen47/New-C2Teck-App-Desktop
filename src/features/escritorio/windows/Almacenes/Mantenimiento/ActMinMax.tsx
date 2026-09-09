import type { ReactNode } from "react";
import { ArrowUpDown, FileSpreadsheet, Filter, LogOut, Save, Search, X } from "lucide-react";
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
  { codigo: "A-1001", producto: "BOMBA HIDRAULICA X90", categoria: "Repuestos", stockActual: "120", minActual: "80", maxActual: "180", minNuevo: "90", maxNuevo: "200" },
  { codigo: "A-1020", producto: "FILTRO DE AIRE 250", categoria: "Consumibles", stockActual: "85", minActual: "60", maxActual: "140", minNuevo: "70", maxNuevo: "170" },
  { codigo: "A-1085", producto: "ACEITE LUBRIFICANTE 4L", categoria: "Lubricantes", stockActual: "64", minActual: "50", maxActual: "100", minNuevo: "55", maxNuevo: "110" },
  { codigo: "A-1204", producto: "RODAMIENTO 6205", categoria: "Repuestos", stockActual: "40", minActual: "30", maxActual: "90", minNuevo: "35", maxNuevo: "100" },
];

export function ActMinMaxList() {
  return (
    <div className="h-full flex flex-col bg-[#EEF3F8] text-slate-800">
      <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] border-b border-[#1F2E3F] text-[12px] text-white">
        <span className="font-medium">Actualización masiva de Stock Min / Max</span>
        <div className="flex items-center gap-1">
          <button className={iconBtn} title="Aplicar cambios"><Save className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Importar Excel"><FileSpreadsheet className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Filtrar categoría"><Filter className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4 text-white" /></button>
        </div>
      </div>

      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EDF2F7] to-[#D9E2EC] border-b border-slate-300 text-slate-700 overflow-x-auto">
        <button className={squareIconBtn} title="Guardar"><Save className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Importar"><FileSpreadsheet className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Filtrar"><Filter className="h-3.5 w-3.5" /></button>
        {tbSep}
        <button className={squareIconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Cerrar"><X className="h-3.5 w-3.5" /></button>
      </div>

      <div className="px-2 py-2 border-b border-slate-300 bg-[#F7FAFC]">
        <div className="grid grid-cols-2 xl:grid-cols-4 gap-2">
          <Field label="Categoría" className="min-w-[180px]"><select className={inp}><option>(Todas)</option><option>Repuestos</option><option>Consumibles</option><option>Lubricantes</option></select></Field>
          <Field label="Almacén" className="min-w-[180px]"><select className={inp}><option>Central Lima</option><option>Norte</option><option>Sur</option></select></Field>
          <Field label="Producto" className="min-w-[220px]"><input className={inp} placeholder="Código o descripción" /></Field>
          <div className="flex items-end"><button className={`${btnPrimary} h-7 w-full`}><Search className="h-3.5 w-3.5" />Filtrar</button></div>
        </div>
      </div>

      <div className="flex-1 min-h-0 overflow-hidden px-2 pb-2 pt-2">
        <div className="h-full overflow-auto rounded-sm border border-slate-300 bg-white shadow-sm">
          <table className="w-full border-collapse text-[11px]">
            <thead className="sticky top-0 z-10 bg-slate-100 text-slate-700">
              <tr>
                {[
                  "Código",
                  "Producto",
                  "Categoría",
                  "Stock Actual",
                  "Min Actual",
                  "Max Actual",
                  "Min Nuevo",
                  "Max Nuevo",
                ].map((h) => (
                  <th key={h} className="border-b border-slate-300 px-2 py-1.5 text-left font-semibold whitespace-nowrap">
                    <span className="inline-flex items-center gap-1"><ArrowUpDown className="h-3 w-3 opacity-60" />{h}</span>
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {rows.map((row) => (
                <tr key={row.codigo} className="hover:bg-slate-50">
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-slate-700">{row.codigo}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 whitespace-nowrap">{row.producto}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.categoria}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right">{row.stockActual}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right">{row.minActual}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right">{row.maxActual}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right text-amber-700">{row.minNuevo}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right text-emerald-700">{row.maxNuevo}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}
