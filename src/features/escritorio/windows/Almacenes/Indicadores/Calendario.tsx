import type { ReactNode } from "react";
import { ArrowUpDown, Calendar, FileSpreadsheet, LogOut, RefreshCw, Search, X } from "lucide-react";
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
  { fecha: "2026-09-08", evento: "Inventario", almacen: "Central Lima", documento: "INV-0908", responsable: "M. Paredes", estado: "PENDIENTE" },
  { fecha: "2026-09-09", evento: "Traslado", almacen: "Norte", documento: "TR-018", responsable: "J. Rojas", estado: "PROCESO" },
  { fecha: "2026-09-11", evento: "Conteo", almacen: "Sur", documento: "CT-004", responsable: "A. Flores", estado: "CERRADO" },
  { fecha: "2026-09-12", evento: "Inventario", almacen: "Central Lima", documento: "INV-0912", responsable: "R. Torres", estado: "PENDIENTE" },
];

export function CalendarioList() {
  return (
    <div className="h-full flex flex-col bg-[#EEF3F8] text-slate-800">
      <div className="flex items-center justify-between px-3 py-1.5 bg-gradient-to-b from-[#3E5B7A] to-[#2A3F55] border-b border-[#1F2E3F] text-[12px] text-white">
        <span className="font-medium">Calendario de Almacén</span>
        <div className="flex items-center gap-1">
          <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Ver mes"><Calendar className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Excel"><FileSpreadsheet className="h-4 w-4 text-white" /></button>
          {tbSep}
          <button className={iconBtn} title="Salir"><LogOut className="h-4 w-4 text-white" /></button>
        </div>
      </div>

      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EDF2F7] to-[#D9E2EC] border-b border-slate-300 text-slate-700 overflow-x-auto">
        <button className={squareIconBtn} title="Actualizar"><RefreshCw className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Ver mes"><Calendar className="h-3.5 w-3.5" /></button>
        <button className={squareIconBtn} title="Excel"><FileSpreadsheet className="h-3.5 w-3.5" /></button>
        {tbSep}
        <button className={squareIconBtn} title="Cerrar"><X className="h-3.5 w-3.5" /></button>
      </div>

      <div className="px-2 py-2 border-b border-slate-300 bg-[#F7FAFC]">
        <div className="grid grid-cols-2 xl:grid-cols-6 gap-2">
          <Field label="Año" className="min-w-[90px]"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
          <Field label="Mes" className="min-w-[120px]"><select className={inp}><option>ENERO</option><option>FEBRERO</option><option>MARZO</option><option>ABRIL</option><option>MAYO</option><option>JUNIO</option><option>JULIO</option><option>AGOSTO</option><option>SETIEMBRE</option><option>OCTUBRE</option><option>NOVIEMBRE</option><option>DICIEMBRE</option></select></Field>
          <Field label="Almacén" className="min-w-[160px]"><select className={inp}><option>Central Lima</option><option>Norte</option><option>Sur</option></select></Field>
          <Field label="Tipo Evento" className="min-w-[180px]"><select className={inp}><option>(Todos)</option><option>Inventario</option><option>Traslado</option><option>Conteo</option></select></Field>
          <Field label="Responsable" className="min-w-[180px]"><input className={inp} defaultValue="(Todos)" /></Field>
          <div className="flex items-end"><button className={`${btnPrimary} h-7 w-full`}><Search className="h-3.5 w-3.5" />Buscar</button></div>
        </div>
      </div>

      <div className="px-2 py-2">
        <div className="grid grid-cols-2 xl:grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Eventos:</span> <b className="font-mono text-slate-900">4</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Inventarios:</span> <b className="font-mono text-emerald-700">2</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Traslados:</span> <b className="font-mono text-slate-900">1</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Conteos:</span> <b className="font-mono text-amber-700">1</b></div>
        </div>
      </div>

      <div className="flex-1 min-h-0 overflow-hidden px-2 pb-2">
        <div className="h-full overflow-auto rounded-sm border border-slate-300 bg-white shadow-sm">
          <table className="w-full border-collapse text-[11px]">
            <thead className="sticky top-0 z-10 bg-slate-100 text-slate-700">
              <tr>
                {[
                  "Fecha",
                  "Evento",
                  "Almacén",
                  "Documento",
                  "Responsable",
                  "Estado",
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
                <tr key={`${row.fecha}-${row.documento}`} className="hover:bg-slate-50">
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.fecha}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.evento}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.almacen}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5 font-mono">{row.documento}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5">{row.responsable}</td>
                  <td className="border-b border-slate-200 px-2 py-1.5"><span className="inline-flex items-center justify-center rounded border border-slate-200 bg-slate-50 px-1.5 py-0.5 text-[10px] font-bold text-slate-700">{row.estado}</span></td>
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

