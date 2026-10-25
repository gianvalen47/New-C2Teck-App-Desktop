import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

type BalanceType = "balance" | "funcion" | "naturaleza" | "trabajo";

const monthNames = [
  "ENERO",
  "FEBRERO",
  "MARZO",
  "ABRIL",
  "MAYO",
  "JUNIO",
  "JULIO",
  "AGOSTO",
  "SETIEMBRE",
  "OCTUBRE",
  "NOVIEMBRE",
  "DICIEMBRE",
];

const labelClass = "absolute whitespace-nowrap text-[12px] font-bold leading-[16px] text-slate-900";
const comboClass =
  "absolute h-[21px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800";

function BalanceReportForm({ title }: { title: string }) {
  const now = new Date();
  const previousPeriod = new Date(now.getFullYear(), now.getMonth() - 1, 1);
  const [year, setYear] = useState(String(previousPeriod.getFullYear()));
  const [month, setMonth] = useState(String(previousPeriod.getMonth() + 1));
  const [currency, setCurrency] = useState("S/");
  const [businessUnit, setBusinessUnit] = useState("(Todos)");
  const [area, setArea] = useState("(Todos)");
  const [costCenter, setCostCenter] = useState("(Todos)");
  const [balanceType, setBalanceType] = useState<BalanceType>("balance");
  const [level, setLevel] = useState("1");
  const [pagination, setPagination] = useState(true);

  const radio = (name: string, value: string, checked: boolean, onChange: () => void) => (
    <input
      aria-label={value}
      className="m-0 h-[13px] w-[13px] accent-[#0067b8]"
      type="radio"
      name={name}
      checked={checked}
      onChange={onChange}
    />
  );

  return (
    <WindowShell title={title}>
      <div className="h-full min-h-0 overflow-auto bg-[#F3F3F3]">
        <div className="relative h-[298px] w-[496px] min-w-[496px] text-[12px] text-slate-900">
          <fieldset className="absolute left-[12px] top-[10px] h-[249px] w-[470px] border border-blue-400">
            <fieldset className="absolute left-[8px] top-[-1px] h-[54px] w-[330px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Período</legend>
              <label className={`${labelClass} left-[18px] top-[18px]`} htmlFor="balance-year">
                Año
              </label>
              <input
                id="balance-year"
                aria-label="Año"
                type="number"
                min="1900"
                max="10000"
                value={year}
                onChange={(event) => setYear(event.target.value)}
                className="absolute left-[41px] top-[14px] h-[21px] w-[62px] rounded-sm border border-slate-400 bg-white px-1 text-center text-[12px] font-semibold text-slate-800"
              />
              <label className={`${labelClass} left-[138px] top-[18px]`} htmlFor="balance-month">
                Mes
              </label>
              <select
                id="balance-month"
                aria-label="Mes"
                value={month}
                onChange={(event) => setMonth(event.target.value)}
                className={`${comboClass} left-[174px] top-[14px] w-[120px]`}
              >
                {monthNames.map((name, index) => (
                  <option key={name} value={String(index + 1)}>
                    {name}
                  </option>
                ))}
              </select>
            </fieldset>

            <fieldset className="absolute left-[360px] top-[-1px] h-[54px] w-[118px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Moneda</legend>
              <select
                aria-label="Moneda"
                value={currency}
                onChange={(event) => setCurrency(event.target.value)}
                className={`${comboClass} left-[29px] top-[13px] w-[65px] text-center`}
              >
                <option>S/</option>
                <option>US$</option>
              </select>
            </fieldset>

            <fieldset className="absolute left-0 top-[62px] h-[75px] w-[470px] rounded-sm border border-blue-400">
              <label className={`${labelClass} left-[4px] top-[16px]`} htmlFor="balance-unit">
                Unidad de Negocio
              </label>
              <select
                id="balance-unit"
                aria-label="Unidad de Negocio"
                value={businessUnit}
                onChange={(event) => {
                  setBusinessUnit(event.target.value);
                  setArea("(Todos)");
                  setCostCenter("(Todos)");
                }}
                className={`${comboClass} left-[114px] top-[10px] w-[120px]`}
              >
                <option>(Todos)</option>
              </select>
              <label className={`${labelClass} left-[256px] top-[16px]`} htmlFor="balance-area">
                Area
              </label>
              <select
                id="balance-area"
                aria-label="Area"
                value={area}
                onChange={(event) => {
                  setArea(event.target.value);
                  setCostCenter("(Todos)");
                }}
                className={`${comboClass} left-[291px] top-[10px] w-[159px]`}
              >
                <option>(Todos)</option>
              </select>
              <label className={`${labelClass} left-[4px] top-[43px]`} htmlFor="balance-cost-center">
                Centro de Costo
              </label>
              <select
                id="balance-cost-center"
                aria-label="Centro de Costo"
                value={costCenter}
                onChange={(event) => setCostCenter(event.target.value)}
                className={`${comboClass} left-[114px] top-[37px] w-[171px]`}
              >
                <option>(Todos)</option>
              </select>
            </fieldset>

            <fieldset className="absolute left-0 top-[145px] h-[76px] w-[330px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Tipo</legend>
              <div className="absolute left-[9px] top-[10px] flex flex-col gap-[3px] font-bold">
                <label className="flex cursor-pointer items-center gap-1">
                  {radio("balance-report-type", "Balance General", balanceType === "balance", () => setBalanceType("balance"))}
                  Balance General
                </label>
                <label className="flex cursor-pointer items-center gap-1">
                  {radio("balance-report-type", "GG.PP. por Naturaleza", balanceType === "naturaleza", () => setBalanceType("naturaleza"))}
                  GG.PP. por Naturaleza
                </label>
              </div>
              <div className="absolute left-[175px] top-[10px] flex flex-col gap-[3px] font-bold">
                <label className="flex cursor-pointer items-center gap-1">
                  {radio("balance-report-type", "GG.PP. por Función", balanceType === "funcion", () => setBalanceType("funcion"))}
                  GG.PP. por Función
                </label>
                <label className="flex cursor-pointer items-center gap-1">
                  {radio("balance-report-type", "Hoja de Trabajo", balanceType === "trabajo", () => setBalanceType("trabajo"))}
                  Hoja de Trabajo
                </label>
              </div>
            </fieldset>

            <fieldset className="absolute left-[336px] top-[143px] h-[50px] w-[134px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Nivel</legend>
              <select
                aria-label="Nivel"
                value={level}
                onChange={(event) => setLevel(event.target.value)}
                className={`${comboClass} left-[13px] top-[12px] w-[106px]`}
              >
                <option value="1">Nivel 1</option>
                <option value="2">Nivel 2</option>
                <option value="3">Nivel 3</option>
              </select>
            </fieldset>

            <fieldset className="absolute left-[336px] top-[199px] h-[50px] w-[134px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Paginación</legend>
              <label className="absolute left-[9px] top-[14px] flex cursor-pointer items-center gap-1 font-bold">
                <input
                  aria-label="Con Paginación"
                  type="checkbox"
                  checked={pagination}
                  onChange={(event) => setPagination(event.target.checked)}
                  className="m-0 h-[13px] w-[13px] accent-[#0067b8]"
                />
                Con Paginación
              </label>
            </fieldset>
          </fieldset>

          <button
            type="button"
            className="absolute left-[173px] top-[263px] flex h-[27px] w-[82px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold text-slate-900 hover:bg-[#CFE0F4]"
          >
            <CheckCircle2 aria-hidden="true" size={16} className="text-green-600" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[261px] top-[263px] flex h-[27px] w-[82px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold text-slate-900 hover:bg-[#CFE0F4]"
          >
            <LogOut aria-hidden="true" size={15} className="text-blue-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}

export function EstadoFinanciero({ title = "Reporte Balances" }: { title?: string }) {
  return <EstadoFinancieroList title={title} />;
}

export function EstadoFinancieroList({ title = "Reporte Balances" }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <BalanceReportForm title={title} />
    </div>
  );
}
