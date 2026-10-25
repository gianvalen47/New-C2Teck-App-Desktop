import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

type PurchaseType = "local" | "foreign";
type ReportType = "detailed" | "summary";
type Condition = "pending" | "cancelled" | "all";
type SortBy = "total" | "provider";
type SortOrder = "descending" | "ascending";
type Currency = "soles" | "dollars";

const labelClass = "absolute whitespace-nowrap text-[12px] font-bold leading-[16px] text-slate-900";
const inputClass =
  "absolute h-[21px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800";
const groupClass = "absolute rounded-sm border border-blue-400 font-bold";

function AccountsPayableReportForm({ title }: { title: string }) {
  const today = new Date();
  const [dateFrom, setDateFrom] = useState("2020-01-01");
  const [dateTo, setDateTo] = useState(
    `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, "0")}-${String(today.getDate()).padStart(2, "0")}`,
  );
  const [allProviders, setAllProviders] = useState(true);
  const [provider, setProvider] = useState("(TODOS)");
  const [documentType, setDocumentType] = useState("(Todos)");
  const [purchaseType, setPurchaseType] = useState<PurchaseType>("local");
  const [reportType, setReportType] = useState<ReportType>("detailed");
  const [condition, setCondition] = useState<Condition>("pending");
  const [sortBy, setSortBy] = useState<SortBy>("total");
  const [sortOrder, setSortOrder] = useState<SortOrder>("descending");
  const [currency, setCurrency] = useState<Currency>("soles");

  const radio = <T extends string>(
    name: string,
    value: T,
    selected: T,
    onChange: (value: T) => void,
    disabled = false,
    accessibleLabel = value,
  ) => (
    <input
      aria-label={accessibleLabel}
      type="radio"
      name={name}
      checked={selected === value}
      onChange={() => onChange(value)}
      disabled={disabled}
      className="m-0 h-[13px] w-[13px] accent-[#0067b8] disabled:accent-slate-400"
    />
  );

  return (
    <WindowShell title={title}>
      <div className="h-full min-h-0 overflow-auto bg-[#F3F3F3]">
        <div className="relative h-[449px] w-[426px] min-w-[426px] text-[12px] text-slate-900">
          <div className="absolute left-[10px] top-[5px] h-[389px] w-[390px] rounded-sm border border-slate-300">
            <label className={`${labelClass} left-[17px] top-[21px]`} htmlFor="ap-report-date-from">
              Fechas&nbsp;&nbsp; Del :
            </label>
            <input
              id="ap-report-date-from"
              aria-label="Fecha desde"
              type="date"
              value={dateFrom}
              onChange={(event) => setDateFrom(event.target.value)}
              className="absolute left-[115px] top-[17px] h-[21px] w-[97px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
            />
            <label className={`${labelClass} left-[222px] top-[21px]`} htmlFor="ap-report-date-to">
              Al :
            </label>
            <input
              id="ap-report-date-to"
              aria-label="Fecha hasta"
              type="date"
              value={dateTo}
              onChange={(event) => setDateTo(event.target.value)}
              className="absolute left-[265px] top-[17px] h-[21px] w-[94px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
            />

            <fieldset className={`${groupClass} left-[14px] top-[49px] h-[56px] w-[362px]`}>
              <legend className="px-1 text-blue-800">Buscar Proveedor</legend>
              <label className="absolute left-[144px] top-[10px] flex cursor-pointer items-center gap-1">
                <input
                  aria-label="Todo Proveedor"
                  type="checkbox"
                  checked={allProviders}
                  onChange={(event) => {
                    setAllProviders(event.target.checked);
                    setProvider(event.target.checked ? "(TODOS)" : "");
                  }}
                  className="m-0 h-[13px] w-[13px] accent-[#0067b8]"
                />
                Todo Proveedor
              </label>
              <label className={`${labelClass} left-[9px] top-[32px]`} htmlFor="ap-report-provider">
                Proveedor
              </label>
              <input
                id="ap-report-provider"
                aria-label="Proveedor"
                value={provider}
                readOnly={allProviders}
                onChange={(event) => setProvider(event.target.value)}
                className={`${inputClass} left-[75px] top-[29px] w-[251px]`}
              />
              <button
                type="button"
                title="Buscar Proveedor"
                aria-label="Buscar Proveedor"
                onClick={() => {
                  setAllProviders(false);
                  setProvider("");
                }}
                className="absolute left-[327px] top-[27px] flex h-[22px] w-[25px] items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-blue-800 hover:bg-[#CFE0F4]"
              >
                <Search size={15} />
              </button>
            </fieldset>

            <fieldset className={`${groupClass} left-[14px] top-[162px] h-[43px] w-[360px]`}>
              <legend className="px-1 text-blue-800">Documento</legend>
              <label
                className={`${labelClass} left-[7px] top-[19px]`}
                htmlFor="ap-report-document-type"
              >
                Tipo Documento
              </label>
              <select
                id="ap-report-document-type"
                aria-label="Tipo Documento"
                value={documentType}
                onChange={(event) => setDocumentType(event.target.value)}
                className="absolute left-[113px] top-[15px] h-[21px] w-[237px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
              >
                <option>(Todos)</option>
              </select>
            </fieldset>

            <fieldset className={`${groupClass} left-[11px] top-[213px] h-[79px] w-[144px]`}>
              <legend className="px-1 text-blue-800">Tipo de Compra</legend>
              <label className="absolute left-[5px] top-[22px] flex cursor-pointer items-center gap-1">
                {radio(
                  "ap-report-purchase-type",
                  "local",
                  purchaseType,
                  setPurchaseType,
                  false,
                  "Compras Locales",
                )}
                Compras Locales
              </label>
              <label className="absolute left-[5px] top-[45px] flex cursor-pointer items-center gap-1">
                {radio(
                  "ap-report-purchase-type",
                  "foreign",
                  purchaseType,
                  setPurchaseType,
                  false,
                  "Compras al Exterior",
                )}
                Compras al Exterior
              </label>
            </fieldset>

            <fieldset className={`${groupClass} left-[164px] top-[213px] h-[79px] w-[96px]`}>
              <legend className="px-1 text-blue-800">Tipo</legend>
              <label className="absolute left-[6px] top-[22px] flex cursor-pointer items-center gap-1">
                {radio("ap-report-type", "detailed", reportType, setReportType, false, "Detallado")}
                Detallado
              </label>
              <label className="absolute left-[6px] top-[45px] flex cursor-pointer items-center gap-1">
                {radio("ap-report-type", "summary", reportType, setReportType, false, "Resumido")}
                Resumido
              </label>
            </fieldset>

            <fieldset className={`${groupClass} left-[269px] top-[213px] h-[79px] w-[109px]`}>
              <legend className="px-1 text-blue-800">Condición</legend>
              <label className="absolute left-[9px] top-[17px] flex cursor-pointer items-center gap-1">
                {radio(
                  "ap-report-condition",
                  "pending",
                  condition,
                  setCondition,
                  false,
                  "Pendientes",
                )}
                Pendientes
              </label>
              <label className="absolute left-[9px] top-[35px] flex cursor-pointer items-center gap-1">
                {radio(
                  "ap-report-condition",
                  "cancelled",
                  condition,
                  setCondition,
                  false,
                  "Cancelados",
                )}
                Cancelados
              </label>
              <label className="absolute left-[9px] top-[53px] flex cursor-pointer items-center gap-1">
                {radio("ap-report-condition", "all", condition, setCondition, false, "Todos")}
                Todos
              </label>
            </fieldset>

            <fieldset
              disabled
              className={`${groupClass} left-[48px] top-[298px] h-[79px] w-[90px] text-slate-400 disabled:border-slate-400`}
            >
              <legend className="px-1">Ordenado X</legend>
              <label className="absolute left-[7px] top-[22px] flex items-center gap-1">
                {radio("ap-report-sort-by", "total", sortBy, setSortBy, true, "Total")}
                Total
              </label>
              <label className="absolute left-[6px] top-[45px] flex items-center gap-1">
                {radio("ap-report-sort-by", "provider", sortBy, setSortBy, true, "Proveedor")}
                Proveedor
              </label>
            </fieldset>

            <fieldset
              disabled
              className={`${groupClass} left-[146px] top-[298px] h-[79px] w-[109px] text-slate-400 disabled:border-slate-400`}
            >
              <legend className="px-1">Orden</legend>
              <label className="absolute left-[7px] top-[22px] flex items-center gap-1">
                {radio(
                  "ap-report-sort-order",
                  "descending",
                  sortOrder,
                  setSortOrder,
                  true,
                  "Descendente",
                )}
                Descendente
              </label>
              <label className="absolute left-[7px] top-[45px] flex items-center gap-1">
                {radio(
                  "ap-report-sort-order",
                  "ascending",
                  sortOrder,
                  setSortOrder,
                  true,
                  "Ascendente",
                )}
                Ascendente
              </label>
            </fieldset>

            <fieldset
              disabled
              className={`${groupClass} left-[263px] top-[298px] h-[79px] w-[78px] text-slate-400 disabled:border-slate-400`}
            >
              <legend className="px-1">Moneda</legend>
              <label className="absolute left-[7px] top-[22px] flex items-center gap-1">
                {radio("ap-report-currency", "soles", currency, setCurrency, true, "Soles")}
                Soles
              </label>
              <label className="absolute left-[7px] top-[45px] flex items-center gap-1">
                {radio("ap-report-currency", "dollars", currency, setCurrency, true, "Dolares")}
                Dolares
              </label>
            </fieldset>
          </div>

          <button
            type="button"
            className="absolute left-[115px] top-[401px] flex h-[27px] w-[78px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold hover:bg-[#CFE0F4]"
          >
            <CheckCircle2 aria-hidden="true" size={16} className="text-green-600" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[199px] top-[401px] flex h-[27px] w-[78px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold hover:bg-[#CFE0F4]"
          >
            <LogOut aria-hidden="true" size={15} className="text-blue-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}

export function ReportCtasXPagar({
  title = "Reporte de Cuentas x Pagar Contable",
}: {
  title?: string;
}) {
  return <ReportCtasXPagarList title={title} />;
}

export function ReportCtasXPagarList({
  title = "Reporte de Cuentas x Pagar Contable",
}: {
  title?: string;
}) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <AccountsPayableReportForm title={title} />
    </div>
  );
}
