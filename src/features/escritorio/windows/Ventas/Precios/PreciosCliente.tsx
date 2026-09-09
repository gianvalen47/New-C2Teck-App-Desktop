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
} from "lucide-react";
import { btn, btnPrimary, iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";

const columns = ["Cód.", "Cliente", "N° Contrato", "Lista", "Mon.", "Observación", "Estado", "Fec. Inicio", "Fec. Venc."];

function Field({ label, className = "", children }: { label: string; className?: string; children: ReactNode }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium leading-tight">{label}</span>
      {children}
    </label>
  );
}

export function PrecioClienteList() {
  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Imprimir"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Nuevo"><Plus className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Editar"><Pencil className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Guardar"><Save className="h-4 w-4" /></button>
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
        <button className={iconBtn} title="Cerrar"><LogOut className="h-4 w-4" /></button>
      </div>

      <div className="mx-1.5 mt-1.5 grid grid-cols-3 gap-2 text-[11px]">
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Vigentes:</span> <b className="font-mono text-slate-900">0</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Por vencer:</span> <b className="font-mono text-slate-900">0</b></div>
        <div className="rounded-sm border border-slate-300 bg-white px-2 py-1"><span className="text-slate-600">Vencidos:</span> <b className="font-mono text-slate-900">0</b></div>
      </div>

      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="Cliente" className="w-64">
          <div className="flex gap-1">
            <input className={`${inp} flex-1`} defaultValue="(Todos)" />
            <button className={btn} type="button" title="Buscar"><Search className="h-3.5 w-3.5" /></button>
          </div>
        </Field>
        <Field label="Estado" className="w-36"><select className={inp} defaultValue="(Todos)"><option>(Todos)</option><option>Generado</option><option>Vigente</option><option>Vencido</option></select></Field>
        <Field label="N° Contrato" className="w-40"><input className={inp} /></Field>
        <Field label="Moneda" className="w-24"><select className={inp} defaultValue="(Todos)"><option>(Todos)</option><option>PEN</option><option>USD</option></select></Field>
        <button className={btnPrimary}><Search className="h-3.5 w-3.5" />Buscar</button>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full text-[11.5px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
              <tr>
                {columns.map((header) => (
                  <th key={header} className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">
                    {header}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              <tr className="bg-white text-slate-500 text-center">
                <td colSpan={columns.length} className="px-3 py-8 text-[11px]">Sin registros</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>

      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-[11px] text-slate-700 text-center font-medium flex items-center justify-center whitespace-nowrap overflow-hidden">
        Registros : 0
      </div>
    </div>
  );
}