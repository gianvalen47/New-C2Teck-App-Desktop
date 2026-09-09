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

const columns = ["Cód.", "Nombre", "Moneda", "Observación", "Fec. Inicio", "Fec. Venc.", "Vigente"];

function Field({ label, className = "", children }: { label: string; className?: string; children: ReactNode }) {
  return (
    <label className={`flex flex-col gap-0.5 ${className}`}>
      <span className="text-[10.5px] text-slate-600 font-medium leading-tight">{label}</span>
      {children}
    </label>
  );
}

export function PrecioListaList() {
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

      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="Lista Precio" className="w-56"><select className={inp} defaultValue="(Todos)"><option>(Todos)</option><option>LISTA GENERAL</option><option>LISTA MAYORISTA</option></select></Field>
        <Field label="Estado" className="w-36"><select className={inp} defaultValue="(Todos)"><option>(Todos)</option><option>Vigente</option><option>No vigente</option></select></Field>
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