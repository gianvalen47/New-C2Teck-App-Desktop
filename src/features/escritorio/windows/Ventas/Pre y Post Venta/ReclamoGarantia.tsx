import type { ReactNode } from "react";
import {
  FileText,
  LogOut,
  Mail,
  Pencil,
  Plus,
  Printer,
  RefreshCw,
  Save,
  Search,
  Send,
  Trash2,
  Wrench,
  X,
} from "lucide-react";
import { actionBtn, btn, btnPrimary, iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";

type ReclamoRow = {
  id: string;
  fecha: string;
  control: string;
  cliente: string;
  documento: string;
  equipo: string;
  falla: string;
  estado: string;
  resultado: string;
};

const rows: ReclamoRow[] = [
  { id: "RC-0001", fecha: "2026-09-08", control: "CTR-0100", cliente: "LUCY VENTAS S.A.C.", documento: "F001-1001", equipo: "BOMBA 2000", falla: "No arranca", estado: "REGISTRADO", resultado: "PENDIENTE" },
  { id: "RC-0002", fecha: "2026-09-07", control: "CTR-0101", cliente: "MERCADOS DEL SUR", documento: "F001-1002", equipo: "MOTOR ELÉCTRICO", falla: "Fuga de aceite", estado: "EN EVALUACIÓN", resultado: "PROCEDE" },
  { id: "RC-0003", fecha: "2026-09-06", control: "CTR-0102", cliente: "ALMACEN DEL NORTE", documento: "B001-1001", equipo: "CARGADOR", falla: "Falla electrónica", estado: "CERRADO", resultado: "NO PROCEDE" },
];

const ESTADO_COLORS: Record<string, string> = {
  REGISTRADO: "text-blue-700 bg-blue-50 border-blue-200",
  "EN EVALUACIÓN": "text-amber-700 bg-amber-50 border-amber-200",
  CERRADO: "text-emerald-700 bg-emerald-50 border-emerald-200",
  ANULADO: "text-red-700 bg-red-50 border-red-200",
  PENDIENTE: "text-slate-600 bg-slate-100 border-slate-200",
  PROCEDE: "text-emerald-700 bg-emerald-50 border-emerald-200",
  "NO PROCEDE": "text-red-700 bg-red-50 border-red-200",
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

export function ReclamoGarantiaList() {
  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Imprimir reclamo"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Nuevo reclamo"><Plus className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Editar reclamo"><Pencil className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Guardar"><Save className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Enviar"><Send className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Documento"><FileText className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Mensajería"><Mail className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Cerrar ventana"><LogOut className="h-4 w-4" /></button>
      </div>

      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="N° Reclamo" className="w-24"><input className={`${inp} font-mono`} defaultValue="" /></Field>
        <Field label="Fecha" className="w-28"><input className={inp} type="date" defaultValue="2026-09-08" /></Field>
        <Field label="Control" className="w-28"><input className={inp} defaultValue="" /></Field>
        <Field label="Cliente" className="w-52"><div className="flex gap-1"><input className={inp} defaultValue="(Todos)" /><button className={btn} type="button" title="Buscar cliente"><Search className="h-3 w-3" /></button></div></Field>
        <Field label="Estado" className="w-28"><select className={inp} defaultValue="(Todos)"><option>(Todos)</option><option>REGISTRADO</option><option>EN EVALUACIÓN</option><option>CERRADO</option><option>ANULADO</option></select></Field>
        <Field label="Resultado" className="w-28"><select className={inp} defaultValue="(Todos)"><option>(Todos)</option><option>PENDIENTE</option><option>PROCEDE</option><option>NO PROCEDE</option></select></Field>
        <button className={btnPrimary}><Search className="h-3.5 w-3.5" />Buscar</button>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full text-[11.5px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
              <tr>
                {[
                  "N°",
                  "Fecha",
                  "Control",
                  "Cliente",
                  "Documento",
                  "Equipo",
                  "Falla",
                  "Estado",
                  "Resultado",
                ].map((header) => (
                  <th key={header} className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">
                    {header}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody className="divide-y divide-slate-100">
              {rows.map((row, index) => (
                <tr key={row.id} className={index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}>
                  <td className="px-3 py-2 border-r border-slate-100 font-mono font-medium">{row.id}</td>
                  <td className="px-3 py-2 border-r border-slate-100 whitespace-nowrap">{row.fecha}</td>
                  <td className="px-3 py-2 border-r border-slate-100 font-mono">{row.control}</td>
                  <td className="px-3 py-2 border-r border-slate-100 max-w-[220px] truncate">{row.cliente}</td>
                  <td className="px-3 py-2 border-r border-slate-100 font-mono">{row.documento}</td>
                  <td className="px-3 py-2 border-r border-slate-100">{row.equipo}</td>
                  <td className="px-3 py-2 border-r border-slate-100 max-w-[180px] truncate">{row.falla}</td>
                  <td className="px-3 py-2 border-r border-slate-100"><EstadoBadge value={row.estado} /></td>
                  <td className="px-3 py-2"><EstadoBadge value={row.resultado} /></td>
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
