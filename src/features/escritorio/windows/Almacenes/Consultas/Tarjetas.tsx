import type { ReactNode } from "react";
import { ArrowUpDown, FileSpreadsheet, LogOut, Plus, RefreshCw, Search, X } from "lucide-react";
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
  { codigo: "A-1001", producto: "BOMBA HIDRAULICA X90", almacen: "Central Lima", stockInicio: "120", entradas: "15", salidas: "8", stockFinal: "127" },
  { codigo: "A-1020", producto: "FILTRO DE AIRE 250", almacen: "Norte", stockInicio: "85", entradas: "20", salidas: "12", stockFinal: "93" },
  { codigo: "A-1085", producto: "ACEITE LUBRIFICANTE 4L", almacen: "Sur", stockInicio: "64", entradas: "9", salidas: "17", stockFinal: "56" },
  { codigo: "A-1204", producto: "RODAMIENTO 6205", almacen: "Central Lima", stockInicio: "40", entradas: "0", salidas: "5", stockFinal: "35" },
];

export function TarjetasList() {
  return (
    <div className="h-full flex flex-col bg-[#EEF3F8] text-slate-800">
      <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] border-b border-[#1F2E3F] text-[12px] text-white">
        <span className="font-medium">Tarjetas de Inventario</span>
        <div className="flex items-center gap-1">
          <button className={iconBtn} title="Buscar tarjeta"><Search className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Refrescar"><RefreshCw className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Exportar"><FileSpreadsheet className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4 text-white" /></button>
        </div>
      </div>

      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EDF2F7] to-[#D9E2EC] border-b border-slate-300 text-slate-700 overflow-x-auto">
        <button className={squareIconBtn} title="Buscar"><Search className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Refrescar"><RefreshCw className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Excel"><FileSpreadsheet className="h-3.5 w-3.5" /></button>
        {tbSep}
        <button className={squareIconBtn} title="Abrir"><Plus className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Cerrar"><X className="h-3.5 w-3.5" /></button>
      </div>

      <div className="px-2 py-2 border-b border-slate-300 bg-[#F7FAFC]">
        <div className="grid grid-cols-2 xl:grid-cols-6 gap-2">
          <Field label="Producto" className="min-w-[220px]"><input className={inp} placeholder="Código o descripción" /></Field>
          <Field label="Almacén" className="min-w-[150px]"><select className={inp}><option>Central Lima</option><option>Norte</option><option>Sur</option></select></Field>
          <Field label="Fecha Desde" className="min-w-[140px]"><input className={inp} type="date" /></Field>
          <Field label="Fecha Hasta" className="min-w-[140px]"><input className={inp} type="date" /></Field>
          <Field label="Tipo" className="min-w-[140px]"><select className={inp}><option>(Todos)</option><option>Ingreso</option><option>Salida</option><option>Ajuste</option></select></Field>
          <div className="flex items-end"><button className={`${btnPrimary} h-7 w-full`}><Search className="h-3.5 w-3.5" />Buscar</button></div>
        </div>
      </div>

      <div className="px-2 py-2">
        <div className="grid grid-cols-2 xl:grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Tarjetas:</span> <b className="font-mono text-slate-900">4</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Movimientos:</span> <b className="font-mono text-slate-900">18</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Entradas:</span> <b className="font-mono text-emerald-700">44</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Salidas:</span> <b className="font-mono text-red-700">42</b></div>
        </div>
      </div>

      <div className="flex-1 min-h-0 overflow-hidden px-2 pb-2">
        <div className="h-full overflow-auto rounded-sm border border-slate-300 bg-white shadow-sm">
          <table className="w-full border-collapse text-[11px]">
            <thead className="sticky top-0 z-10 bg-slate-100 text-slate-700">
              <tr>
                {[
                  "Código",
                  "Producto",
                  "Almacén",
                  "Stock Inicio",
                  "Entradas",
                  "Salidas",
                  "Stock Final",
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
                <tr key={row.codigo} className="hover:bg-slate-50">
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-slate-700">{row.codigo}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 whitespace-nowrap">{row.producto}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.almacen}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right">{row.stockInicio}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right text-emerald-700">{row.entradas}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right text-red-700">{row.salidas}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono text-right">{row.stockFinal}</td>
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
