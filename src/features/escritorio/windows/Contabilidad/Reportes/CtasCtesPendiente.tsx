import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

type ReportType = "detail" | "summary";
type SummaryBy = "provider" | "document";

const labelClass = "absolute whitespace-nowrap text-[12px] font-bold leading-[16px] text-slate-900";
const inputClass =
  "absolute h-[21px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800";
const searchButtonClass =
  "absolute flex h-[22px] w-[25px] items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-blue-800 hover:bg-[#CFE0F4]";

function PendingCurrentAccountsForm({ title }: { title: string }) {
  const [cutoffDate, setCutoffDate] = useState(() => {
    const now = new Date();
    return `${now.getFullYear()}-${String(now.getMonth() + 1).padStart(2, "0")}-${String(now.getDate()).padStart(2, "0")}`;
  });
  const [allProviders, setAllProviders] = useState(true);
  const [provider, setProvider] = useState("(TODOS)");
  const [allEmployees, setAllEmployees] = useState(true);
  const [employee, setEmployee] = useState("(TODOS)");
  const [businessUnit, setBusinessUnit] = useState("(Todos)");
  const [area, setArea] = useState("(Todos)");
  const [costCenter, setCostCenter] = useState("(Todos)");
  const [accountFrom, setAccountFrom] = useState("");
  const [accountTo, setAccountTo] = useState("");
  const [reportType, setReportType] = useState<ReportType>("detail");
  const [summaryBy, setSummaryBy] = useState<SummaryBy>("provider");

  const radio = (name: string, value: string, checked: boolean, onChange: () => void, disabled = false) => (
    <input
      aria-label={value}
      className="m-0 h-[13px] w-[13px] accent-[#0067b8] disabled:accent-slate-400"
      type="radio"
      name={name}
      checked={checked}
      onChange={onChange}
      disabled={disabled}
    />
  );

  return (
    <WindowShell title={title}>
      <div className="h-full min-h-0 overflow-auto bg-[#F3F3F3]">
        <div className="relative h-[511px] w-[500px] min-w-[500px] text-[12px] text-slate-900">
          <div className="absolute left-[6px] top-[1px] h-[467px] w-[488px] rounded-sm border border-blue-300">
            <fieldset className="absolute left-[76px] top-[8px] h-[54px] w-[327px] rounded-sm border border-blue-400">
              <label className={`${labelClass} left-[67px] top-[17px]`} htmlFor="pending-accounts-date">
                Hasta el :
              </label>
              <input
                id="pending-accounts-date"
                aria-label="Hasta el"
                type="date"
                value={cutoffDate}
                onChange={(event) => setCutoffDate(event.target.value)}
                className="absolute left-[135px] top-[13px] h-[21px] w-[94px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
              />
            </fieldset>

            <fieldset className="absolute left-[3px] top-[68px] h-[54px] w-[470px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Proveedor</legend>
              <label className="absolute left-[190px] top-[-1px] flex cursor-pointer items-center gap-1 font-bold">
                <input
                  aria-label="Todo Proveedor"
                  type="checkbox"
                  checked={allProviders}
                  onChange={(event) => {
                    setAllProviders(event.target.checked);
                    if (event.target.checked) setProvider("(TODOS)");
                    else setProvider("");
                  }}
                  className="m-0 h-[13px] w-[13px] accent-[#0067b8]"
                />
                Todo Proveedor
              </label>
              <label className={`${labelClass} left-[38px] top-[24px]`} htmlFor="pending-accounts-provider">
                Proveedor
              </label>
              <input
                id="pending-accounts-provider"
                aria-label="Proveedor"
                value={provider}
                readOnly={allProviders}
                onChange={(event) => setProvider(event.target.value)}
                className={`${inputClass} left-[107px] top-[21px] w-[299px]`}
              />
              <button
                type="button"
                title="Buscar Proveedor"
                aria-label="Buscar Proveedor"
                onClick={() => {
                  setAllProviders(false);
                  setProvider("");
                  document.getElementById("pending-accounts-provider")?.focus();
                }}
                className={`${searchButtonClass} left-[411px] top-[19px]`}
              >
                <Search size={15} />
              </button>
            </fieldset>

            <fieldset className="absolute left-[3px] top-[128px] h-[54px] w-[470px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Colaborador</legend>
              <label className="absolute left-[190px] top-[-1px] flex cursor-pointer items-center gap-1 font-bold">
                <input
                  aria-label="Todo Colaborador"
                  type="checkbox"
                  checked={allEmployees}
                  onChange={(event) => {
                    setAllEmployees(event.target.checked);
                    if (event.target.checked) setEmployee("(TODOS)");
                    else setEmployee("");
                  }}
                  className="m-0 h-[13px] w-[13px] accent-[#0067b8]"
                />
                Todo Colaborador
              </label>
              <label className={`${labelClass} left-[26px] top-[24px]`} htmlFor="pending-accounts-employee">
                Colaborador
              </label>
              <input
                id="pending-accounts-employee"
                aria-label="Colaborador"
                value={employee}
                readOnly={allEmployees}
                onChange={(event) => setEmployee(event.target.value)}
                className={`${inputClass} left-[107px] top-[21px] w-[299px]`}
              />
              <button
                type="button"
                title="Buscar Colaborador"
                aria-label="Buscar Colaborador"
                onClick={() => {
                  setAllEmployees(false);
                  setEmployee("");
                  document.getElementById("pending-accounts-employee")?.focus();
                }}
                className={`${searchButtonClass} left-[411px] top-[19px]`}
              >
                <Search size={15} />
              </button>
            </fieldset>

            <fieldset className="absolute left-[3px] top-[189px] h-[75px] w-[470px] rounded-sm border border-blue-400">
              <label className={`${labelClass} left-[9px] top-[16px]`} htmlFor="pending-accounts-unit">
                Unidad de Negocio
              </label>
              <select
                id="pending-accounts-unit"
                aria-label="Unidad de Negocio"
                value={businessUnit}
                onChange={(event) => {
                  setBusinessUnit(event.target.value);
                  setArea("(Todos)");
                  setCostCenter("(Todos)");
                }}
                className="absolute left-[124px] top-[10px] h-[21px] w-[120px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold"
              >
                <option>(Todos)</option>
              </select>
              <label className={`${labelClass} left-[270px] top-[16px]`} htmlFor="pending-accounts-area">
                Area
              </label>
              <select
                id="pending-accounts-area"
                aria-label="Area"
                value={area}
                onChange={(event) => {
                  setArea(event.target.value);
                  setCostCenter("(Todos)");
                }}
                className="absolute left-[304px] top-[10px] h-[21px] w-[156px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold"
              >
                <option>(Todos)</option>
              </select>
              <label className={`${labelClass} left-[9px] top-[43px]`} htmlFor="pending-accounts-cost-center">
                Centro de Costo
              </label>
              <select
                id="pending-accounts-cost-center"
                aria-label="Centro de Costo"
                value={costCenter}
                onChange={(event) => setCostCenter(event.target.value)}
                className="absolute left-[124px] top-[37px] h-[21px] w-[171px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold"
              >
                <option>(Todos)</option>
              </select>
            </fieldset>

            <fieldset className="absolute left-[3px] top-[270px] h-[60px] w-[470px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Cuenta Contable</legend>
              <label className={`${labelClass} left-[45px] top-[24px]`} htmlFor="pending-accounts-from">
                De :
              </label>
              <input
                id="pending-accounts-from"
                aria-label="Cuenta contable desde"
                value={accountFrom}
                onChange={(event) => {
                  const value = event.target.value.toUpperCase();
                  setAccountFrom(value);
                  setAccountTo(value);
                }}
                className={`${inputClass} left-[83px] top-[21px] w-[70px] text-center uppercase`}
              />
              <button
                type="button"
                title="Buscar cuenta desde"
                aria-label="Buscar cuenta desde"
                onClick={() => document.getElementById("pending-accounts-from")?.focus()}
                className={`${searchButtonClass} left-[155px] top-[20px]`}
              >
                <Search size={15} />
              </button>
              <label className={`${labelClass} left-[256px] top-[24px]`} htmlFor="pending-accounts-to">
                Hasta :
              </label>
              <input
                id="pending-accounts-to"
                aria-label="Cuenta contable hasta"
                value={accountTo}
                onChange={(event) => setAccountTo(event.target.value.toUpperCase())}
                className={`${inputClass} left-[312px] top-[21px] w-[70px] text-center uppercase`}
              />
              <button
                type="button"
                title="Buscar cuenta hasta"
                aria-label="Buscar cuenta hasta"
                onClick={() => document.getElementById("pending-accounts-to")?.focus()}
                className={`${searchButtonClass} left-[384px] top-[20px]`}
              >
                <Search size={15} />
              </button>
            </fieldset>

            <fieldset className="absolute left-[173px] top-[336px] h-[120px] w-[175px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Tipo</legend>
              <label className="absolute left-[13px] top-[10px] flex cursor-pointer items-center gap-1 font-bold">
                {radio("pending-accounts-type", "Detallado", reportType === "detail", () => setReportType("detail"))}
                Detallado
              </label>
              <label className="absolute left-[13px] top-[30px] flex cursor-pointer items-center gap-1 font-bold">
                {radio("pending-accounts-type", "Resumido", reportType === "summary", () => setReportType("summary"))}
                Resumido
              </label>
              <fieldset
                disabled={reportType !== "summary"}
                className="absolute left-[56px] top-[47px] h-[60px] w-[104px] rounded-sm border border-blue-400 disabled:opacity-60"
              >
                <label className="absolute left-[8px] top-[8px] flex cursor-pointer items-center gap-1 font-bold">
                  {radio("pending-accounts-summary-by", "Proveedor", summaryBy === "provider", () => setSummaryBy("provider"), reportType !== "summary")}
                  Proveedor
                </label>
                <label className="absolute left-[8px] top-[28px] flex cursor-pointer items-center gap-1 font-bold">
                  {radio("pending-accounts-summary-by", "Documento", summaryBy === "document", () => setSummaryBy("document"), reportType !== "summary")}
                  Documento
                </label>
              </fieldset>
            </fieldset>
          </div>

          <button
            type="button"
            className="absolute left-[169px] top-[476px] flex h-[27px] w-[78px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold hover:bg-[#CFE0F4]"
          >
            <CheckCircle2 aria-hidden="true" size={16} className="text-green-600" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[253px] top-[476px] flex h-[27px] w-[80px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold hover:bg-[#CFE0F4]"
          >
            <LogOut aria-hidden="true" size={15} className="text-blue-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}

export function CtasCtesPendiente({ title = "Reporte Cuentas Corrientes Pendientes" }: { title?: string }) {
  return <CtasCtesPendienteList title={title} />;
}

export function CtasCtesPendienteList({ title = "Reporte Cuentas Corrientes Pendientes" }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <PendingCurrentAccountsForm title={title} />
    </div>
  );
}
