import type { ReactNode } from "react";
import { iconBtn, inp, btn, btnPrimary, tbSep } from "@/features/escritorio/windows/uiStyles";
import {
  FileSearch,
  LogOut,
  Mail,
  Package,
  Plus,
  Printer,
  RefreshCw,
  Save,
  Search,
  Send,
  Trash2,
  Wrench,
} from "lucide-react";
import { TicketPrinterIcon } from "@/components/ui/icons";

export const stdToolbar14 = (
  <>
    <button className={iconBtn} title="Imprimir Documento"><Printer className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Imprimir Ticket"><TicketPrinterIcon className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mostrar Guía"><Send className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Actualizar Guías"><Package className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Ver Estados"><Plus className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Buscar"><Search className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Documentos"><FileSearch className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Mensajería"><Mail className="h-4 w-4" /></button>
    {tbSep}
    <button className={iconBtn} title="Cerrar Formulario"><LogOut className="h-4 w-4" /></button>
  </>
);

type DocumentoRow = {
  codigo: string;
  fecha: string;
  cliente: string;
  documento: string;
  serie: string;
  numero: string;
  total: string;
  estado: string;
};

const rows: DocumentoRow[] = [
  { codigo: "F001", fecha: "2026-09-08", cliente: "LUCY VENTAS S.A.C.", documento: "Factura", serie: "F001", numero: "1001", total: "S/ 1,248.00", estado: "ACEPTADO" },
  { codigo: "B001", fecha: "2026-09-08", cliente: "MERCADOS DEL SUR", documento: "Boleta", serie: "B001", numero: "1002", total: "S/ 2,430.50", estado: "PENDIENTE" },
  { codigo: "G001", fecha: "2026-09-07", cliente: "ALMACEN DEL NORTE", documento: "Guía de Remisión", serie: "G001", numero: "420", total: "S/ 0.00", estado: "ENVIADO" },
];

const ESTADO_COLORS: Record<string, string> = {
  ACEPTADO: "text-emerald-700 bg-emerald-50 border-emerald-200",
  PENDIENTE: "text-amber-700 bg-amber-50 border-amber-200",
  ENVIADO: "text-blue-700 bg-blue-50 border-blue-200",
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

export function DocumentosList() {
  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        {stdToolbar14}
      </div>

      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="Periodo" className="w-20"><input className={`${inp} font-mono`} defaultValue="2026" /></Field>
        <Field label="Mes" className="w-28"><select className={inp} defaultValue="SEPTIEMBRE"><option>SEPTIEMBRE</option><option>AGOSTO</option><option>JULIO</option></select></Field>
        <Field label="Oficina" className="w-28"><select className={inp} defaultValue="LIMA"><option>LIMA</option><option>AREQUIPA</option></select></Field>
        <Field label="Almacén" className="w-32"><select className={inp} defaultValue="COMERCIAL"><option>COMERCIAL</option><option>PRINCIPAL</option></select></Field>
        <Field label="Cliente" className="w-52"><div className="flex gap-1"><input className={inp} defaultValue="(Todos)" /><button className={btn} type="button" title="Buscar cliente"><Search className="h-3 w-3" /></button></div></Field>
        <Field label="Documento" className="w-28"><select className={inp} defaultValue="(Todos)"><option>(Todos)</option><option>FACTURA</option><option>BOLETA</option><option>GUIA</option></select></Field>
        <Field label="Número" className="w-24"><input className={`${inp} font-mono`} defaultValue="" /></Field>
        <button className={btnPrimary}><Search className="h-3.5 w-3.5" />Buscar</button>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full text-[11.5px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
              <tr>
                {[
                  "Código",
                  "Fecha",
                  "Cliente",
                  "Documento",
                  "Serie",
                  "Número",
                  "Total",
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
                <tr key={`${row.codigo}-${row.numero}`} className={index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}>
                  <td className="px-3 py-2 border-r border-slate-100 font-mono font-medium">{row.codigo}</td>
                  <td className="px-3 py-2 border-r border-slate-100">{row.fecha}</td>
                  <td className="px-3 py-2 border-r border-slate-100 max-w-[220px] truncate">{row.cliente}</td>
                  <td className="px-3 py-2 border-r border-slate-100">{row.documento}</td>
                  <td className="px-3 py-2 border-r border-slate-100 font-mono">{row.serie}</td>
                  <td className="px-3 py-2 border-r border-slate-100 font-mono">{row.numero}</td>
                  <td className="px-3 py-2 border-r border-slate-100 font-mono text-right">{row.total}</td>
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
