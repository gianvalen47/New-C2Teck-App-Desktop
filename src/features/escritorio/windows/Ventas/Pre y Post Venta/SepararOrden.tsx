import { useMemo, useState } from "react";
import { Check, LogOut, Search, TableProperties } from "lucide-react";
import { btn, btnPrimary, iconBtn, inp, tbSep } from "@/features/escritorio/windows/uiStyles";
import {
  CodeDescSelector,
  MonthSelector,
  YearSpinner,
  type CodeDescOption,
} from "@/features/escritorio/windows/shared/SearchFieldControls";

type OrdenRow = {
  numero: string;
  fecha: string;
  cliente: string;
  moneda: string;
  total: string;
  estado: string;
  oficina: string;
  almacen: string;
};

const rows: OrdenRow[] = [
  { numero: "421", fecha: "2026-10-29", cliente: "REMAN CENTER PERU S.A.C.", moneda: "S/.", total: "2,847.10", estado: "GENERADO", oficina: "LIMA", almacen: "COMERCIAL" },
  { numero: "420", fecha: "2026-10-28", cliente: "COMERCIAL DEL NORTE S.A.C.", moneda: "S/.", total: "1,560.00", estado: "SEPARADO", oficina: "LIMA", almacen: "PRINCIPAL" },
  { numero: "419", fecha: "2026-10-17", cliente: "SERVICIOS INDUSTRIALES LIMA", moneda: "US$", total: "980.50", estado: "PARCIAL", oficina: "AREQUIPA", almacen: "COMERCIAL" },
  { numero: "418", fecha: "2026-09-30", cliente: "MERCADOS DEL SUR", moneda: "S/.", total: "4,250.00", estado: "SEPARADO", oficina: "LIMA", almacen: "COMERCIAL" },
  { numero: "417", fecha: "2026-08-14", cliente: "ALMACEN DEL NORTE", moneda: "S/.", total: "735.90", estado: "GENERADO", oficina: "AREQUIPA", almacen: "PRINCIPAL" },
];

const OFFICE_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "LIMA", value: "LIMA" },
  { code: "02", label: "AREQUIPA", value: "AREQUIPA" },
];

const WAREHOUSE_OPTIONS: CodeDescOption[] = [
  { code: "01", label: "COMERCIAL", value: "COMERCIAL" },
  { code: "02", label: "PRINCIPAL", value: "PRINCIPAL" },
];

export function SepararOrdenList() {
  const today = new Date();
  const [year, setYear] = useState(String(today.getFullYear()));
  const [month, setMonth] = useState(String(today.getMonth() + 1));
  const [office, setOffice] = useState("LIMA");
  const [warehouse, setWarehouse] = useState("");
  const [client, setClient] = useState("");
  const [number, setNumber] = useState("");
  const [appliedNumber, setAppliedNumber] = useState("");
  const [separatedOnly, setSeparatedOnly] = useState(false);
  const [selectedNumero, setSelectedNumero] = useState<string | null>(null);

  const visibleRows = useMemo(() => rows.filter((row) => {
    const date = new Date(`${row.fecha}T00:00:00`);
    if (year && date.getFullYear() !== Number(year)) return false;
    if (month && date.getMonth() + 1 !== Number(month)) return false;
    if (office && row.oficina !== office) return false;
    if (warehouse && row.almacen !== warehouse) return false;
    if (client.trim() && !row.cliente.toLowerCase().includes(client.trim().toLowerCase())) return false;
    if (appliedNumber && !row.numero.includes(appliedNumber.trim())) return false;
    if (separatedOnly && row.estado !== "SEPARADO") return false;
    return true;
  }), [year, month, office, warehouse, client, appliedNumber, separatedOnly]);

  const searchByNumber = () => setAppliedNumber(number);

  return (
    <div className="relative flex h-full min-h-0 flex-col overflow-hidden bg-[#F3F6FA]">
      <div className="flex shrink-0 items-center gap-1 overflow-x-auto border-b border-slate-400/50 bg-gradient-to-b from-[#EEF2F7] to-[#D6DEE8] px-2 py-1.5">
        <button type="button" className={iconBtn} title="Mostrar órdenes"><TableProperties className="h-4 w-4" /></button>
        {tbSep}
        <button type="button" className={iconBtn} title="Separar orden"><Check className="h-4 w-4" /></button>
        {tbSep}
        <button type="button" className={iconBtn} title="Salir"><LogOut className="h-4 w-4" /></button>
      </div>

      <fieldset className="mx-1.5 mt-1.5 shrink-0 border border-[#7A96B4] bg-[#ECF1F7] px-2 pb-1.5 pt-0">
        <legend className="px-1 text-[10.5px] font-bold text-slate-700">Datos de Búsqueda</legend>
        <div className="flex flex-wrap items-end gap-x-2 gap-y-1">
          <label className="flex flex-col gap-0.5 w-[84px]">
            <span className="text-[10.5px] font-semibold text-slate-700">Año</span>
            <YearSpinner value={year} onChange={setYear} />
          </label>
          <label className="flex flex-col gap-0.5 w-32">
            <span className="text-[10.5px] font-semibold text-slate-700">Mes</span>
            <MonthSelector value={month} onChange={setMonth} />
          </label>
          <label className="flex flex-col gap-0.5 w-28">
            <span className="text-[10.5px] font-semibold text-slate-700">Oficina</span>
            <CodeDescSelector value={office} onChange={setOffice} options={OFFICE_OPTIONS} allLabel="(Todas)" />
          </label>
          <label className="flex flex-col gap-0.5 w-32">
            <span className="text-[10.5px] font-semibold text-slate-700">Almacén</span>
            <CodeDescSelector value={warehouse} onChange={setWarehouse} options={WAREHOUSE_OPTIONS} allLabel="(Todos)" />
          </label>
          <label className="flex flex-col gap-0.5 w-48">
            <span className="text-[10.5px] font-semibold text-slate-700">Cliente</span>
            <span className="flex gap-1">
              <input className={inp} value={client} onChange={(event) => setClient(event.target.value)} />
              <button type="button" className={btn} title="Buscar cliente"><Search className="h-3 w-3" /></button>
            </span>
          </label>
          <label className="flex flex-col gap-0.5 w-20">
            <span className="text-[10.5px] font-semibold text-slate-700">Número</span>
            <input
              className={`${inp} text-center font-mono`}
              value={number}
              onChange={(event) => setNumber(event.target.value)}
              onKeyDown={(event) => {
                if (event.key === "Enter") searchByNumber();
              }}
            />
          </label>
          <button type="button" className={btnPrimary} onClick={searchByNumber}>
            <Search className="h-3.5 w-3.5" />Buscar
          </button>
          <label className="inline-flex h-7 items-center gap-1.5 whitespace-nowrap text-[11px] font-medium text-slate-800">
            <input
              type="checkbox"
              checked={separatedOnly}
              onChange={(event) => setSeparatedOnly(event.target.checked)}
              className="h-3.5 w-3.5 accent-[#2A5590]"
            />
            Separados
          </label>
        </div>
      </fieldset>

      <div className="min-h-0 flex-1 overflow-auto p-1.5">
        <div className="h-full overflow-auto rounded-sm border border-slate-400/60 bg-white">
          <table className="w-full min-w-[700px] text-[11.5px]">
            <thead className="sticky top-0 z-10 bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800">
              <tr>
                {["Número", "Fecha", "Cliente", "Mon.", "Total", "Estado"].map((header) => (
                  <th key={header} className="border-r border-slate-300/70 px-2 py-1 text-center font-semibold whitespace-nowrap">
                    {header}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {Array.from({ length: Math.max(14, visibleRows.length) }, (_, index) => {
                const row = visibleRows[index];
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
                    <td className="h-[20px] border-r border-slate-200 px-2 py-0.5 text-center font-mono font-semibold">{row?.numero}</td>
                    <td className="border-r border-slate-200 px-2 py-0.5 text-center whitespace-nowrap">{row?.fecha}</td>
                    <td className="border-r border-slate-200 px-2 py-0.5">{row?.cliente}</td>
                    <td className="border-r border-slate-200 px-2 py-0.5 text-center">{row?.moneda}</td>
                    <td className="border-r border-slate-200 px-2 py-0.5 text-right font-mono">{row?.total}</td>
                    <td className="px-2 py-0.5 text-center">{row?.estado}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      </div>

      <div className="shrink-0 border-t border-slate-400/50 bg-gradient-to-b from-[#D6DEE8] to-[#C0CCDB] px-3 py-0.5 text-center text-[11px] font-medium text-slate-700">
        Registros : {visibleRows.length}
      </div>
    </div>
  );
}

export function SepararOrden() {
  return <SepararOrdenList />;
}
