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
  Wrench,
} from "lucide-react";
import { btn, btnPrimary, iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";

type ClienteRow = {
  codigo: string;
  ruc: string;
  razonSocial: string;
  grupo: string;
  vendedor: string;
  condicion: string;
  limite: string;
  estado: string;
  fActualizacion: string;
};

const rows: ClienteRow[] = [
  { codigo: "C-0001", ruc: "20100012345", razonSocial: "LUCY VENTAS S.A.C.", grupo: "COMERCIAL", vendedor: "VENDEDOR 01", condicion: "CONTADO", limite: "S/ 80,000", estado: "ACTIVO", fActualizacion: "2026-09-08" },
  { codigo: "C-0002", ruc: "20100023456", razonSocial: "MERCADOS DEL SUR", grupo: "MINERÍA", vendedor: "VENDEDOR 02", condicion: "CREDITO 30D", limite: "S/ 150,000", estado: "ACTIVO", fActualizacion: "2026-09-07" },
  { codigo: "C-0003", ruc: "20100034567", razonSocial: "ALMACEN DEL NORTE", grupo: "SERVICIOS", vendedor: "VENDEDOR 03", condicion: "CREDITO 45D", limite: "S/ 120,000", estado: "INACTIVO", fActualizacion: "2026-08-22" },
];

const ESTADO_COLORS: Record<string, string> = {
  ACTIVO: "text-emerald-700 bg-emerald-50 border-emerald-200",
  INACTIVO: "text-red-700 bg-red-50 border-red-200",
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

export function CarteraList() {
  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Imprimir cartera"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Nuevo cliente"><Plus className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Editar cliente"><Pencil className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Guardar cambios"><Save className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Enviar"><Send className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Reporte"><FileText className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Gestión"><Wrench className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Mensajería"><Mail className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Cerrar ventana"><LogOut className="h-4 w-4" /></button>
      </div>

      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="Código" className="w-24"><input className={`${inp} font-mono`} defaultValue="" /></Field>
        <Field label="Cliente" className="w-52"><div className="flex gap-1"><input className={inp} defaultValue="(Todos)" /><button className={btn} type="button" title="Buscar cliente"><Search className="h-3 w-3" /></button></div></Field>
        <Field label="Grupo" className="w-40"><select className={inp} defaultValue="(Todos)"><option>(Todos)</option><option>MINERÍA</option><option>COMERCIAL</option><option>SERVICIOS</option></select></Field>
        <Field label="Vendedor" className="w-44"><select className={inp} defaultValue="(Todos)"><option>(Todos)</option><option>VENDEDOR 01</option><option>VENDEDOR 02</option><option>VENDEDOR 03</option></select></Field>
        <Field label="Estado" className="w-28"><select className={inp} defaultValue="ACTIVO"><option>ACTIVO</option><option>INACTIVO</option><option>(Todos)</option></select></Field>
        <button className={btnPrimary}><Search className="h-3.5 w-3.5" />Buscar</button>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full text-[11.5px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
              <tr>
                {[
                  "Código",
                  "RUC",
                  "Razón Social",
                  "Grupo Ventas",
                  "Vendedor",
                  "Cond. Pago",
                  "Límite Crédito",
                  "Estado",
                  "F.Actualización",
                ].map((header) => (
                  <th key={header} className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">
                    {header}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody className="divide-y divide-slate-100">
              {rows.map((row, index) => (
                <tr key={row.codigo} className={index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}>
                  <td className="px-3 py-2 border-r border-slate-100 font-mono font-medium">{row.codigo}</td>
                  <td className="px-3 py-2 border-r border-slate-100 font-mono">{row.ruc}</td>
                  <td className="px-3 py-2 border-r border-slate-100 max-w-[220px] truncate">{row.razonSocial}</td>
                  <td className="px-3 py-2 border-r border-slate-100">{row.grupo}</td>
                  <td className="px-3 py-2 border-r border-slate-100">{row.vendedor}</td>
                  <td className="px-3 py-2 border-r border-slate-100">{row.condicion}</td>
                  <td className="px-3 py-2 border-r border-slate-100 font-mono text-right">{row.limite}</td>
                  <td className="px-3 py-2 border-r border-slate-100"><EstadoBadge value={row.estado} /></td>
                  <td className="px-3 py-2">{row.fActualizacion}</td>
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
