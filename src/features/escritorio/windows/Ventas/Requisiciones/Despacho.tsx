import type { ReactNode } from "react";
import {
  FileText,
  LogOut,
  Mail,
  Package,
  Pencil,
  Plus,
  Printer,
  RefreshCw,
  Save,
  Search,
  Send,
  Truck,
  Wrench,
} from "lucide-react";
import { btn, btnPrimary, iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";

type DespachoRow = {
  numero: string;
  fecha: string;
  salida: string;
  retorno: string;
  chofer: string;
  placa: string;
  destino: string;
  observacion: string;
  estado: string;
};

const rows: DespachoRow[] = [
  { numero: "D-0001", fecha: "2026-09-08", salida: "08:00", retorno: "11:30", chofer: "JUAN PEREZ", placa: "ABC-123", destino: "LIMA SUR", observacion: "Entrega programada", estado: "EN RUTA" },
  { numero: "D-0002", fecha: "2026-09-08", salida: "09:15", retorno: "12:50", chofer: "CARLOS RUIZ", placa: "XYZ-987", destino: "CALLAO", observacion: "Reposición de stock", estado: "FINALIZADO" },
  { numero: "D-0003", fecha: "2026-09-07", salida: "07:40", retorno: "09:10", chofer: "PEDRO GARCÍA", placa: "QWE-456", destino: "AREQUIPA", observacion: "Pedido de cliente", estado: "PENDIENTE" },
];

const ESTADO_COLORS: Record<string, string> = {
  PENDIENTE: "text-amber-700 bg-amber-50 border-amber-200",
  "EN RUTA": "text-blue-700 bg-blue-50 border-blue-200",
  FINALIZADO: "text-emerald-700 bg-emerald-50 border-emerald-200",
  ANULADO: "text-red-700 bg-red-50 border-red-200",
};

function Field({ label, className = "", children }: { label: string; className?: string; children: ReactNode }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium leading-tight">{label}</span>
      {children}
    </label>
  );
}

function EstadoBadge({ value }: { value: string }) {
  const cls = ESTADO_COLORS[value] ?? "text-slate-600 bg-slate-50 border-slate-200";
  return <span className={`inline-block px-1.5 py-0 text-[10px] font-bold rounded border ${cls}`}>{value}</span>;
}

export function DespachoList() {
  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Imprimir despacho"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Nuevo despacho"><Plus className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Editar despacho"><Pencil className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Guardar"><Save className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Envío"><Send className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Paquete"><Package className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Vehículo"><Truck className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Mensajería"><Mail className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Cerrar ventana"><LogOut className="h-4 w-4" /></button>
      </div>

      <div className="px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <div className="grid grid-cols-4 gap-2 text-[11px]">
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Pendientes:</span> <b className="font-mono text-slate-900">3</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">En ruta:</span> <b className="font-mono text-slate-900">5</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Finalizados:</span> <b className="font-mono text-slate-900">12</b></div>
          <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Anulados:</span> <b className="font-mono text-slate-900">1</b></div>
        </div>
      </div>

      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="Fecha Inicio" className="w-28"><input className={inp} type="date" defaultValue="2026-09-01" /></Field>
        <Field label="Fecha Fin" className="w-28"><input className={inp} type="date" defaultValue="2026-09-08" /></Field>
        <Field label="Chofer" className="w-52"><div className="flex gap-1"><input className={inp} defaultValue="(Todos)" /><button className={btn} type="button" title="Buscar chofer"><Search className="h-3 w-3" /></button></div></Field>
        <Field label="Placa" className="w-28"><input className={`${inp} font-mono`} defaultValue="" /></Field>
        <Field label="Estado" className="w-28"><select className={inp} defaultValue="(Todos)"><option>(Todos)</option><option>GENERADO</option><option>EN RUTA</option><option>FINALIZADO</option><option>ANULADO</option></select></Field>
        <button className={btnPrimary}><Search className="h-3.5 w-3.5" />Buscar</button>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full text-[11.5px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
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
                ].map((header) => (
                  <th key={header} className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">
                    {header}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody className="divide-y divide-slate-100">
              {rows.map((row, index) => (
                <tr key={row.numero} className={index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}>
                  <td className="px-3 py-2 border-r border-slate-100 font-mono font-medium">{row.numero}</td>
                  <td className="px-3 py-2 border-r border-slate-100">{row.fecha}</td>
                  <td className="px-3 py-2 border-r border-slate-100">{row.salida}</td>
                  <td className="px-3 py-2 border-r border-slate-100">{row.retorno}</td>
                  <td className="px-3 py-2 border-r border-slate-100">{row.chofer}</td>
                  <td className="px-3 py-2 border-r border-slate-100 font-mono">{row.placa}</td>
                  <td className="px-3 py-2 border-r border-slate-100">{row.destino}</td>
                  <td className="px-3 py-2 border-r border-slate-100 max-w-[220px] truncate">{row.observacion}</td>
                  <td className="px-3 py-2"><EstadoBadge value={row.estado} /></td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>

      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-[11px] text-slate-700 text-center font-medium flex items-center justify-center whitespace-nowrap overflow-hidden">
        Registros : {rows.length}
      </div>
    </div>
  );
}
