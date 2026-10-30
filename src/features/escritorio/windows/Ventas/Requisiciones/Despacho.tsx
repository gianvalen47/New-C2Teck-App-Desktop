import { useMemo, useState } from "react";
import { Eraser, FileText, LogOut, Printer, RefreshCw, Search } from "lucide-react";
import { btn, iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";
import {
  CodeDescSelector,
  MonthSelector,
  YearSpinner,
  type CodeDescOption,
} from "@/features/escritorio/windows/shared/SearchFieldControls";

type DespachoRow = {
  requisicion: string;
  numero: string;
  fecha: string;
  cliente: string;
  moneda: string;
  total: string;
  estado: string;
  oficina: string;
  almacen: string;
};

const rows: DespachoRow[] = [
  { requisicion: "1052", numero: "421", fecha: "2026-10-29", cliente: "REMAN CENTER PERU S.A.C.", moneda: "S/.", total: "2,847.10", estado: "GENERADO", oficina: "IQUITOS", almacen: "COMERCIAL" },
  { requisicion: "1051", numero: "420", fecha: "2026-10-28", cliente: "COMERCIAL DEL NORTE S.A.C.", moneda: "S/.", total: "1,560.00", estado: "ATENDIDO", oficina: "IQUITOS", almacen: "COMERCIAL" },
  { requisicion: "1049", numero: "419", fecha: "2026-10-17", cliente: "SERVICIOS INDUSTRIALES LIMA", moneda: "US$", total: "980.50", estado: "PENDIENTE", oficina: "LIMA", almacen: "PRINCIPAL" },
  { requisicion: "1038", numero: "418", fecha: "2026-09-30", cliente: "MERCADOS DEL SUR", moneda: "S/.", total: "4,250.00", estado: "ATENDIDO", oficina: "IQUITOS", almacen: "COMERCIAL" },
  { requisicion: "1012", numero: "417", fecha: "2026-08-14", cliente: "ALMACEN DEL NORTE", moneda: "S/.", total: "735.90", estado: "PENDIENTE", oficina: "LIMA", almacen: "PRINCIPAL" },
];

const OFFICE_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "IQUITOS", value: "IQUITOS" },
  { code: "02", label: "LIMA", value: "LIMA" },
];

const WAREHOUSE_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "COMERCIAL", value: "COMERCIAL" },
  { code: "02", label: "PRINCIPAL", value: "PRINCIPAL" },
];

const STATUS_OPTIONS: CodeDescOption[] = [
  { code: "GE", label: "GENERADO", value: "GENERADO" },
  { code: "AT", label: "ATENDIDO", value: "ATENDIDO" },
  { code: "PE", label: "PENDIENTE", value: "PENDIENTE" },
  { code: "AN", label: "ANULADO", value: "ANULADO" },
];

export function DespachoList() {
  const [year, setYear] = useState("2026");
  const [month, setMonth] = useState("10");
  const [office, setOffice] = useState("IQUITOS");
  const [warehouse, setWarehouse] = useState("COMERCIAL");
  const [client, setClient] = useState("");
  const [appliedClient, setAppliedClient] = useState("");
  const [status, setStatus] = useState("");
  const [orderNumber, setOrderNumber] = useState("");
  const [appliedOrderNumber, setAppliedOrderNumber] = useState("");
  const [selectedRequisition, setSelectedRequisition] = useState<string | null>(null);

  const visibleRows = useMemo(() => rows.filter((row) => {
    const date = new Date(`${row.fecha}T00:00:00`);
    if (year && date.getFullYear() !== Number(year)) return false;
    if (month && date.getMonth() + 1 !== Number(month)) return false;
    if (office && row.oficina !== office) return false;
    if (warehouse && row.almacen !== warehouse) return false;
    if (appliedClient && !row.cliente.toLowerCase().includes(appliedClient.toLowerCase())) return false;
    if (status && row.estado !== status) return false;
    if (appliedOrderNumber && !row.numero.includes(appliedOrderNumber.trim())) return false;
    return true;
  }), [year, month, office, warehouse, appliedClient, status, appliedOrderNumber]);

  const searchByOrderNumber = () => setAppliedOrderNumber(orderNumber.trim());
  const applyClientSearch = () => setAppliedClient(client.trim().toLowerCase());
  const clearClient = () => {
    setClient("");
    setAppliedClient("");
  };

  return (
    <div className="relative flex h-full min-h-0 flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex shrink-0 items-center gap-1 overflow-x-auto border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-2 py-1.5">
        <button type="button" className={iconBtn} title="Imprimir despachos">
          <Printer className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Reporte de despachos">
          <FileText className="h-4 w-4" />
        </button>
        {tbSep}
        <button
          type="button"
          className={iconBtn}
          title="Actualizar"
          onClick={() => {
            setAppliedOrderNumber("");
            setOrderNumber("");
          }}
        >
          <RefreshCw className="h-4 w-4" />
        </button>
        {tbSep}
        <button type="button" className={iconBtn} title="Cerrar ventana">
          <LogOut className="h-4 w-4" />
        </button>
      </div>

      <fieldset className="mx-1.5 mt-1.5 shrink-0 border border-[#7A96B4] bg-[#ECF1F7] px-2 pb-1.5 pt-0">
        <legend className="px-1 text-[10.5px] font-bold text-slate-700">Datos de Búsqueda</legend>
        <div className="flex flex-wrap items-end gap-x-2 gap-y-1">
          <label className="flex w-[82px] flex-col gap-0.5">
            <span className="text-[10.5px] font-semibold text-slate-700">Año</span>
            <YearSpinner value={year} onChange={setYear} />
          </label>
          <label className="flex w-[100px] flex-col gap-0.5">
            <span className="text-[10.5px] font-semibold text-slate-700">Mes</span>
            <MonthSelector value={month} onChange={setMonth} />
          </label>
          <label className="flex w-[92px] flex-col gap-0.5">
            <span className="text-[10.5px] font-semibold text-slate-700">Oficina</span>
            <CodeDescSelector value={office} onChange={setOffice} options={OFFICE_OPTIONS} allLabel="(Todas)" />
          </label>
          <label className="flex w-[124px] flex-col gap-0.5">
            <span className="text-[10.5px] font-semibold text-slate-700">Almacén</span>
            <CodeDescSelector value={warehouse} onChange={setWarehouse} options={WAREHOUSE_OPTIONS} allLabel="(Todos)" />
          </label>
          <div className="flex w-[172px] flex-col gap-0.5">
            <span className="text-[10.5px] font-semibold text-slate-700">Cliente</span>
            <div className="flex items-center gap-1">
              <input
                className={inp}
                value={client}
                placeholder="(Todos)"
                onChange={(event) => setClient(event.target.value)}
                onKeyDown={(event) => {
                  if (event.key === "Enter") applyClientSearch();
                }}
              />
              <button type="button" className={iconBtn} title="Buscar cliente" onClick={applyClientSearch}>
                <Search className="h-3.5 w-3.5" />
              </button>
              <button type="button" className={iconBtn} title="Limpiar cliente" onClick={clearClient}>
                <Eraser className="h-3.5 w-3.5" />
              </button>
            </div>
          </div>
          <label className="flex w-[100px] flex-col gap-0.5">
            <span className="text-[10.5px] font-semibold text-slate-700">Estado</span>
            <CodeDescSelector value={status} onChange={setStatus} options={STATUS_OPTIONS} allLabel="(Todos)" />
          </label>
          <div className="flex w-[112px] flex-col gap-0.5">
            <label htmlFor="despacho-order-number" className="text-[10.5px] font-semibold text-slate-700">
              Número O.C.
            </label>
            <div className="flex items-center gap-1">
              <input
                id="despacho-order-number"
                className={`${inp} min-w-0 text-center font-mono`}
                value={orderNumber}
                onChange={(event) => setOrderNumber(event.target.value)}
                onKeyDown={(event) => {
                  if (event.key === "Enter") searchByOrderNumber();
                }}
              />
              <button type="button" className={`${btn} shrink-0`} title="Buscar número de orden" onClick={searchByOrderNumber}>
                <Search className="h-3.5 w-3.5" />
                Buscar
              </button>
            </div>
          </div>
        </div>
      </fieldset>

      <div className="min-h-0 flex-1 overflow-auto p-1.5">
        <div className="h-full overflow-auto rounded-sm border border-slate-400/60 bg-white">
          <table className="w-full min-w-[790px] border-collapse text-[11px]">
            <colgroup>
              <col className="w-[8%]" />
              <col className="w-[10%]" />
              <col className="w-[12%]" />
              <col className="w-[35%]" />
              <col className="w-[6%]" />
              <col className="w-[13%]" />
              <col className="w-[16%]" />
            </colgroup>
            <thead className="sticky top-0 z-10 bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800">
              <tr>
                {["Nº Req", "Número", "Fecha", "Cliente", "Mon.", "Total", "Estado"].map((header) => (
                  <th key={header} className="border border-slate-300/70 px-2 py-1 text-center font-semibold whitespace-nowrap">
                    {header}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {Array.from({ length: Math.max(14, visibleRows.length) }, (_, index) => {
                const row = visibleRows[index];
                const selected = row?.requisicion === selectedRequisition;
                const rowClass = selected
                  ? "bg-[#D6E4F4] outline outline-1 outline-[#3E5B7A]"
                  : index % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]";
                return (
                  <tr
                    key={row?.requisicion ?? `empty-${index}`}
                    onClick={() => row && setSelectedRequisition(row.requisicion)}
                    className={`${row ? "cursor-pointer hover:bg-[#E8F0F8]/60" : ""} ${rowClass}`}
                  >
                    <td className="h-[20px] border border-blue-200 px-2 text-center font-mono">{row?.requisicion}</td>
                    <td className="h-[20px] border border-blue-200 px-2 text-center font-mono">{row?.numero}</td>
                    <td className="h-[20px] border border-blue-200 px-2 text-center">{row?.fecha}</td>
                    <td className="h-[20px] border border-blue-200 px-2">{row?.cliente}</td>
                    <td className="h-[20px] border border-blue-200 px-2 text-center">{row?.moneda}</td>
                    <td className="h-[20px] border border-blue-200 px-2 text-right font-mono">{row?.total}</td>
                    <td className="h-[20px] border border-blue-200 px-2">{row?.estado}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      </div>

      <div className="flex shrink-0 items-center justify-between border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-1 text-[11px] text-slate-700">
        <span aria-hidden="true" className="h-4 w-px bg-slate-400/70" />
        <span className="font-semibold">Registros: {visibleRows.length}</span>
      </div>
    </div>
  );
}

export function Despacho() {
  return <DespachoList />;
}
