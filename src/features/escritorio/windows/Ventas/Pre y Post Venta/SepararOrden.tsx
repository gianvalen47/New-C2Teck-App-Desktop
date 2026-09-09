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

type OrdenRow = {
  id: string;
  codigo: string;
  descripcion: string;
  stock: string;
  cantSolicitada: string;
  cantSeparada: string;
  moneda: string;
  precio: string;
  total: string;
  estado: string;
};

const rows: OrdenRow[] = [
  { id: "SO-0001", codigo: "BOM-2000", descripcion: "Bomba centrífuga modelo 2000", stock: "12", cantSolicitada: "5", cantSeparada: "2", moneda: "PEN", precio: "780.00", total: "1,560.00", estado: "PENDIENTE" },
  { id: "SO-0002", codigo: "MTR-4100", descripcion: "Motor eléctrico 5HP", stock: "9", cantSolicitada: "4", cantSeparada: "4", moneda: "PEN", precio: "2,550.00", total: "10,200.00", estado: "SEPARADO" },
  { id: "SO-0003", codigo: "VAL-1200", descripcion: "Válvula de control", stock: "28", cantSolicitada: "10", cantSeparada: "8", moneda: "USD", precio: "84.50", total: "676.00", estado: "ATENDIDO" },
];

const ESTADO_COLORS: Record<string, string> = {
  PENDIENTE: "text-amber-700 bg-amber-50 border-amber-200",
  SEPARADO: "text-blue-700 bg-blue-50 border-blue-200",
  ATENDIDO: "text-emerald-700 bg-emerald-50 border-emerald-200",
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

export function SepararOrdenList() {
  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        <button className={iconBtn} title="Imprimir orden"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Nueva separación"><Plus className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Editar registro"><Pencil className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Guardar"><Save className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Enviar"><Send className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Reporte"><FileText className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Mensajería"><Mail className="h-4 w-4" /></button>
        {tbSep}
        <button className={iconBtn} title="Cerrar ventana"><LogOut className="h-4 w-4" /></button>
      </div>

      <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
        <Field label="N° Orden" className="w-24"><input className={`${inp} font-mono`} defaultValue="" /></Field>
        <Field label="Fecha" className="w-28"><input className={inp} type="date" defaultValue="2026-09-08" /></Field>
        <Field label="Cliente" className="w-52"><div className="flex gap-1"><input className={inp} defaultValue="(Todos)" /><button className={btn} type="button" title="Buscar cliente"><Search className="h-3 w-3" /></button></div></Field>
        <Field label="Moneda" className="w-24"><select className={inp} defaultValue="PEN"><option>PEN</option><option>USD</option></select></Field>
        <Field label="Estado" className="w-28"><select className={inp} defaultValue="(Todos)"><option>(Todos)</option><option>PENDIENTE</option><option>SEPARADO</option><option>ATENDIDO</option><option>ANULADO</option></select></Field>
        <Field label="Vendedor" className="w-40"><input className={inp} defaultValue="" /></Field>
        <button className={btnPrimary}><Search className="h-3.5 w-3.5" />Buscar</button>
      </div>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full text-[11.5px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
              <tr>
                {[
                  "Ítem",
                  "Código",
                  "Descripción",
                  "Stock",
                  "Cant. Sol.",
                  "Cant. Sep.",
                  "Mon.",
                  "P.Unit",
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
                <tr key={row.id} className={index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}>
                  <td className="px-3 py-2 border-r border-slate-100 font-mono font-medium">{row.id}</td>
                  <td className="px-3 py-2 border-r border-slate-100 font-mono">{row.codigo}</td>
                  <td className="px-3 py-2 border-r border-slate-100 max-w-[220px] truncate">{row.descripcion}</td>
                  <td className="px-3 py-2 border-r border-slate-100 text-center">{row.stock}</td>
                  <td className="px-3 py-2 border-r border-slate-100 text-center">{row.cantSolicitada}</td>
                  <td className="px-3 py-2 border-r border-slate-100 text-center">{row.cantSeparada}</td>
                  <td className="px-3 py-2 border-r border-slate-100">{row.moneda}</td>
                  <td className="px-3 py-2 border-r border-slate-100 font-mono text-right">{row.precio}</td>
                  <td className="px-3 py-2 border-r border-slate-100 font-mono text-right">{row.total}</td>
                  <td className="px-3 py-2"><EstadoBadge value={row.estado} /></td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>

      <div className="border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-1.5 text-[11px] text-slate-700">
        <div className="flex items-center justify-end gap-6">
          <span>Subtotal: <b className="font-mono">S/ 12,436.00</b></span>
          <span>IGV: <b className="font-mono">S/ 2,238.48</b></span>
          <span>Total: <b className="font-mono">S/ 14,674.48</b></span>
        </div>
      </div>
    </div>
  );
}
