import { useState } from "react";
import {
  CheckCircle,
  FileText,
  FolderOpen,
  LogOut,
  Mail,
  Pencil,
  Plus,
  Printer,
  RefreshCw,
  Search,
  Send,
  Trash2,
  XCircle,
} from "lucide-react";
import { btn, btnPrimary, iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";
import {
  CodeDescSelector,
  MonthSelector,
  YearSpinner,
  type CodeDescOption,
} from "@/features/escritorio/windows/shared/SearchFieldControls";

const OFFICE_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "LIMA", value: "LIMA" },
  { code: "02", label: "AREQUIPA", value: "AREQUIPA" },
];

const WAREHOUSE_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "COMERCIAL", value: "COMERCIAL" },
  { code: "02", label: "PRINCIPAL", value: "PRINCIPAL" },
];

const STATUS_OPTIONS: CodeDescOption[] = [
  { code: "GN", label: "GENERADO", value: "GENERADO" },
  { code: "VE", label: "VENCIDO", value: "VENCIDO" },
  { code: "AT", label: "ATENDIDO", value: "ATENDIDO" },
  { code: "RE", label: "RECHAZADO", value: "RECHAZADO" },
];

const SELLER_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "CRIOS", value: "CRIOS" },
  { code: "02", label: "J. PEREZ", value: "J. PEREZ" },
  { code: "03", label: "M. RUIZ", value: "M. RUIZ" },
];

type CotizacionRow = {
  numero: string;
  fecha: string;
  cliente: string;
  moneda: string;
  total: string;
  estado: string;
  vendedor: string;
  totalNetoSugerido: string;
};

const rows: CotizacionRow[] = [
  { numero: "88", fecha: "2026-07-20", cliente: "REMAN CENTER PERU S.A.C.", moneda: "S/.", total: "2,847.10", estado: "GENERADO", vendedor: "CRIOS", totalNetoSugerido: "0.00" },
  { numero: "87", fecha: "2026-07-19", cliente: "COMERCIAL DEL NORTE S.A.C.", moneda: "S/.", total: "1,560.00", estado: "ATENDIDO", vendedor: "J. PEREZ", totalNetoSugerido: "1,320.00" },
  { numero: "86", fecha: "2026-07-18", cliente: "SERVICIOS INDUSTRIALES LIMA", moneda: "US$", total: "980.50", estado: "RECHAZADO", vendedor: "M. RUIZ", totalNetoSugerido: "0.00" },
];

const ESTADO_COLORS: Record<string, string> = {
  GENERADO: "text-blue-700 bg-blue-50 border-blue-200",
  ATENDIDO: "text-emerald-700 bg-emerald-50 border-emerald-200",
  VENCIDO: "text-amber-700 bg-amber-50 border-amber-200",
  RECHAZADO: "text-red-700 bg-red-50 border-red-200",
};

export function CotizacionesList() {
  const [selectedNumero, setSelectedNumero] = useState<string | null>(null);
  const [year, setYear] = useState("2026");
  const [month, setMonth] = useState("7");
  const [office, setOffice] = useState("LIMA");
  const [warehouse, setWarehouse] = useState("COMERCIAL");
  const [status, setStatus] = useState("");
  const [seller, setSeller] = useState("");

  return (
    <div className="relative h-full min-h-0 flex flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex items-center gap-1 px-2 py-1.5 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] border-b border-slate-400/50 shrink-0 overflow-x-auto">
        <button type="button" className={iconBtn} title="Imprimir cotización"><Printer className="h-4 w-4" /></button>
        {tbSep}
        <button type="button" className={iconBtn} title="Nueva cotización"><Plus className="h-4 w-4" /></button>
        {tbSep}
        <button type="button" className={iconBtn} title="Mostrar cotización"><FileText className="h-4 w-4" /></button>
        {tbSep}
        <button type="button" className={iconBtn} title="Editar cotización"><Pencil className="h-4 w-4" /></button>
        {tbSep}
        <button type="button" className={iconBtn} title="Eliminar cotización"><Trash2 className="h-4 w-4" /></button>
        {tbSep}
        <button type="button" className={iconBtn} title="Generar documento"><CheckCircle className="h-4 w-4" /></button>
        {tbSep}
        <button type="button" className={iconBtn} title="Rechazar cotización"><XCircle className="h-4 w-4" /></button>
        {tbSep}
        <button type="button" className={iconBtn} title="Enviar cotización"><Send className="h-4 w-4" /></button>
        {tbSep}
        <button type="button" className={iconBtn} title="Archivos"><FolderOpen className="h-4 w-4" /></button>
        {tbSep}
        <button type="button" className={iconBtn} title="Actualizar"><RefreshCw className="h-4 w-4" /></button>
        {tbSep}
        <button type="button" className={iconBtn} title="Mensajería"><Mail className="h-4 w-4" /></button>
        {tbSep}
        <button type="button" className={iconBtn} title="Cerrar ventana"><LogOut className="h-4 w-4" /></button>
      </div>

      <fieldset className="mx-1.5 mt-1.5 border border-[#7A96B4] bg-[#ECF1F7] px-2 pb-1.5 pt-0 shrink-0">
        <legend className="px-1 text-[10.5px] font-bold text-slate-700">Datos de Búsqueda</legend>
        <div className="flex flex-wrap items-end gap-2 px-2 py-1.5 bg-[#F0F4F8] border-b border-slate-300">
          <label className="flex flex-col gap-0.5 w-[84px]">
            <span className="text-[10.5px] text-slate-600 font-medium">Año</span>
            <YearSpinner value={year} onChange={setYear} />
          </label>
          <label className="flex flex-col gap-0.5 w-32">
            <span className="text-[10.5px] text-slate-600 font-medium">Mes</span>
            <MonthSelector value={month} onChange={setMonth} />
          </label>
          <label className="flex flex-col gap-0.5 w-28">
            <span className="text-[10.5px] text-slate-600 font-medium">Oficina</span>
            <CodeDescSelector value={office} onChange={setOffice} options={OFFICE_OPTIONS} allLabel="(Todas)" />
          </label>
          <label className="flex flex-col gap-0.5 w-32">
            <span className="text-[10.5px] text-slate-600 font-medium">Almacén</span>
            <CodeDescSelector value={warehouse} onChange={setWarehouse} options={WAREHOUSE_OPTIONS} />
          </label>
          <label className="flex flex-col gap-0.5 w-48">
            <span className="text-[10.5px] text-slate-600 font-medium">Cliente</span>
            <span className="flex gap-1"><input className={inp} defaultValue="(Todos)" /><button type="button" className={btn} title="Buscar cliente"><Search className="h-3 w-3" /></button></span>
          </label>
          <label className="flex flex-col gap-0.5 w-28">
            <span className="text-[10.5px] text-slate-600 font-medium">Estado</span>
            <CodeDescSelector value={status} onChange={setStatus} options={STATUS_OPTIONS} allLabel="(Todos)" />
          </label>
          <label className="flex flex-col gap-0.5 w-32">
            <span className="text-[10.5px] text-slate-600 font-medium">Vendedor</span>
            <CodeDescSelector value={seller} onChange={setSeller} options={SELLER_OPTIONS} allLabel="(Todos)" />
          </label>
          <label className="flex flex-col gap-0.5 w-20">
            <span className="text-[10.5px] text-slate-600 font-medium">Número</span>
            <input className={`${inp} font-mono`} />
          </label>
          <button type="button" className={btnPrimary}><Search className="h-3.5 w-3.5" />Buscar</button>
        </div>
      </fieldset>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full text-[11.5px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
              <tr>
                {["Número", "Fecha", "Cliente", "Mon.", "Total", "Estado", "Vendedor", "TotNetoSug."].map((header) => (
                  <th key={header} className="border-r border-slate-300/70 px-2 py-1 text-center font-semibold whitespace-nowrap">{header}</th>
                ))}
              </tr>
            </thead>
            <tbody>
              {rows.map((row, index) => {
                const selected = row.numero === selectedNumero;
                const estadoColor = ESTADO_COLORS[row.estado] ?? "text-slate-600 bg-slate-50 border-slate-200";
                return (
                  <tr
                    key={row.numero}
                    onClick={() => setSelectedNumero(row.numero)}
                    onDoubleClick={() => setSelectedNumero(row.numero)}
                    className={`cursor-pointer border-b border-slate-200 ${selected ? "bg-[#D6E4F4] outline outline-1 outline-[#3E5B7A]" : index % 2 ? "bg-[#F6F9FC] hover:bg-[#E8F0F8]/60" : "bg-white hover:bg-[#E8F0F8]/60"}`}
                  >
                    <td className="border-r border-slate-200 px-2 py-1 text-center font-mono font-semibold">{row.numero}</td>
                    <td className="border-r border-slate-200 px-2 py-1 text-center whitespace-nowrap">{row.fecha}</td>
                    <td className="border-r border-slate-200 px-2 py-1 max-w-[220px] truncate">{row.cliente}</td>
                    <td className="border-r border-slate-200 px-2 py-1 text-center">{row.moneda}</td>
                    <td className="border-r border-slate-200 px-2 py-1 text-right font-mono">{row.total}</td>
                    <td className="border-r border-slate-200 px-2 py-1 text-center"><span className={`inline-block rounded border px-1.5 text-[10px] font-bold ${estadoColor}`}>{row.estado}</span></td>
                    <td className="border-r border-slate-200 px-2 py-1">{row.vendedor}</td>
                    <td className="px-2 py-1 text-right font-mono">{row.totalNetoSugerido}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      </div>

      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-center text-[11px] font-medium text-slate-700">
        Registros : {rows.length}
      </div>
    </div>
  );
}

export function Cotizaciones() {
  return <CotizacionesList />;
}
