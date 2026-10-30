import { useState } from "react";
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
} from "lucide-react";
import { btn, btnPrimary, iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";
import {
  CodeDescSelector,
  type CodeDescOption,
} from "@/features/escritorio/windows/shared/SearchFieldControls";

type ReclamoRow = {
  numero: string;
  fecha: string;
  control: string;
  cliente: string;
  estado: string;
  resultado: string;
};

const rows: ReclamoRow[] = [
  { numero: "88", fecha: "2026-10-29", control: "CTR-0100", cliente: "LUCY VENTAS S.A.C.", estado: "REGISTRADO", resultado: "PENDIENTE" },
  { numero: "87", fecha: "2026-10-28", control: "CTR-0101", cliente: "MERCADOS DEL SUR", estado: "EN EVALUACIÓN", resultado: "PROCEDE" },
  { numero: "86", fecha: "2026-10-27", control: "CTR-0102", cliente: "ALMACEN DEL NORTE", estado: "CERRADO", resultado: "NO PROCEDE" },
];

const OFFICE_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "LIMA", value: "LIMA" },
  { code: "02", label: "AREQUIPA", value: "AREQUIPA" },
];

const WAREHOUSE_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "COMERCIAL", value: "COMERCIAL" },
  { code: "02", label: "PRINCIPAL", value: "PRINCIPAL" },
];

const STATUS_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "REGISTRADO", value: "REGISTRADO" },
  { code: "02", label: "EN EVALUACIÓN", value: "EN EVALUACIÓN" },
  { code: "03", label: "CERRADO", value: "CERRADO" },
  { code: "04", label: "ANULADO", value: "ANULADO" },
];

export function ReclamoGarantiaList() {
  const [selectedNumero, setSelectedNumero] = useState<string | null>(null);
  const [fechaDesde, setFechaDesde] = useState("2026-01-01");
  const [fechaHasta, setFechaHasta] = useState("2026-10-29");
  const [office, setOffice] = useState("LIMA");
  const [warehouse, setWarehouse] = useState("");
  const [estado, setEstado] = useState("");

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

      <fieldset className="mx-1.5 mt-1.5 shrink-0 border border-[#7A96B4] bg-[#ECF1F7] px-2 pb-1.5 pt-0">
        <legend className="px-1 text-[10.5px] font-bold text-slate-700">RECLAMOS</legend>
        <div className="flex flex-col gap-1">
          <div className="flex flex-wrap items-center gap-x-3 gap-y-1">
            <label className="flex items-center gap-1">
              <span className="text-[11px] font-semibold text-slate-800 whitespace-nowrap">Fecha Del :</span>
              <input className={`${inp} w-[138px]`} type="date" value={fechaDesde} onChange={(event) => setFechaDesde(event.target.value)} />
            </label>
            <label className="flex items-center gap-1">
              <span className="text-[11px] font-semibold text-slate-800 whitespace-nowrap">Al :</span>
              <input className={`${inp} w-[138px]`} type="date" value={fechaHasta} onChange={(event) => setFechaHasta(event.target.value)} />
            </label>
          </div>
          <div className="flex flex-wrap items-end gap-x-2 gap-y-1">
            <label className="flex flex-col gap-0.5 w-56">
              <span className="text-[10.5px] font-semibold text-slate-700">Cliente:</span>
              <span className="flex gap-1">
                <input className={inp} />
                <button className={btn} type="button" title="Buscar cliente"><Search className="h-3 w-3" /></button>
              </span>
            </label>
            <label className="flex flex-col gap-0.5 w-28">
              <span className="text-[10.5px] font-semibold text-slate-700">Oficina:</span>
              <CodeDescSelector value={office} onChange={setOffice} options={OFFICE_OPTIONS} allLabel="(Todas)" />
            </label>
            <label className="flex flex-col gap-0.5 w-32">
              <span className="text-[10.5px] font-semibold text-slate-700">Almacén:</span>
              <CodeDescSelector value={warehouse} onChange={setWarehouse} options={WAREHOUSE_OPTIONS} allLabel="(Todos)" />
            </label>
            <label className="flex flex-col gap-0.5 w-28">
              <span className="text-[10.5px] font-semibold text-slate-700">Estado:</span>
              <CodeDescSelector value={estado} onChange={setEstado} options={STATUS_OPTIONS} allLabel="(Todos)" />
            </label>
            <label className="flex flex-col gap-0.5 w-20">
              <span className="text-[10.5px] font-semibold text-slate-700">Número:</span>
              <input className={`${inp} font-mono`} />
            </label>
            <button type="button" className={`${btnPrimary} h-7`}><Search className="h-3.5 w-3.5" />Buscar</button>
          </div>
        </div>
      </fieldset>

      <div className="flex-1 min-h-0 overflow-auto p-1.5">
        <div className="border border-slate-400/60 bg-white rounded-sm h-full overflow-auto">
          <table className="w-full min-w-[700px] text-[11.5px]">
            <thead className="bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800 sticky top-0 z-10">
              <tr>
                {["Número", "Fecha", "Control", "Cliente", "Estado", "Resultado"].map((header) => (
                  <th key={header} className="px-2 py-1 text-center border-r border-slate-300/70 font-semibold whitespace-nowrap">
                    {header}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {Array.from({ length: 10 }, (_, index) => {
                const row = rows[index];
                const selected = row?.numero === selectedNumero;
                const rowClass = selected
                  ? "bg-[#D6E4F4] outline outline-1 outline-[#3E5B7A]"
                  : index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]";
                return (
                  <tr
                    key={row?.numero ?? `empty-${index}`}
                    onClick={() => row && setSelectedNumero(row.numero)}
                    className={`${row ? "cursor-pointer hover:bg-[#E8F0F8]/60" : ""} border-b border-slate-200 ${rowClass}`}
                  >
                    <td className="h-[23px] border-r border-slate-200 px-2 py-0.5 text-center font-mono font-medium">{row?.numero}</td>
                    <td className="border-r border-slate-200 px-2 py-0.5 text-center whitespace-nowrap">{row?.fecha}</td>
                    <td className="border-r border-slate-200 px-2 py-0.5 text-center font-mono">{row?.control}</td>
                    <td className="border-r border-slate-200 px-2 py-0.5">{row?.cliente}</td>
                    <td className="border-r border-slate-200 px-2 py-0.5 text-center">{row?.estado}</td>
                    <td className="px-2 py-0.5 text-center">{row?.resultado}</td>
                  </tr>
                );
              })}
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

export function ReclamoGarantia() {
  return (
    <ReclamoGarantiaList />
  );
}
