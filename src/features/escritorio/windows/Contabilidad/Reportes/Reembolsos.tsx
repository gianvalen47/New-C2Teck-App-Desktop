import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

type ReportType = "detailed" | "totalized";

const labelClass = "absolute whitespace-nowrap text-[12px] font-bold leading-[16px] text-slate-900";
const comboClass =
  "absolute h-[21px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800";
const inputClass =
  "absolute h-[21px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800";

function ReimbursementReportForm({ title }: { title: string }) {
  const now = new Date();
  const month = String(now.getMonth() + 1).padStart(2, "0");
  const day = String(now.getDate()).padStart(2, "0");
  const [reportType, setReportType] = useState<ReportType>("detailed");
  const [dateFrom, setDateFrom] = useState(`${now.getFullYear()}-${month}-01`);
  const [dateTo, setDateTo] = useState(`${now.getFullYear()}-${month}-${day}`);
  const [expenseType, setExpenseType] = useState("(Todos)");
  const [licensePlate, setLicensePlate] = useState("(Todos)");
  const [businessUnit, setBusinessUnit] = useState("(Todos)");
  const [area, setArea] = useState("(Todos)");
  const [cashLocation, setCashLocation] = useState("");
  const [reimbursementNumber, setReimbursementNumber] = useState("");

  const radio = (value: ReportType, label: string) => (
    <label className="flex cursor-pointer items-center gap-1 font-bold">
      <input
        aria-label={label}
        type="radio"
        name="reimbursement-report-type"
        checked={reportType === value}
        onChange={() => setReportType(value)}
        className="m-0 h-[13px] w-[13px] accent-[#0067b8]"
      />
      {label}
    </label>
  );

  return (
    <WindowShell title={title}>
      <div className="h-full min-h-0 overflow-auto bg-[#F3F3F3]">
        <div className="relative h-[253px] w-[493px] min-w-[493px] text-[12px] text-slate-900">
          <fieldset className="absolute left-[9px] top-[7px] h-[239px] w-[476px] rounded-sm border border-blue-400">
            <legend className="px-1 font-semibold text-blue-800">Datos de Reporte</legend>

            <fieldset className="absolute left-[129px] top-[3px] h-[40px] w-[199px] rounded-sm border border-blue-400">
              <legend className="px-1 text-center font-semibold text-blue-800">Tipo</legend>
              <div className="absolute left-[11px] top-[8px] flex items-center gap-[12px]">
                {radio("detailed", "Detallado")}
                {radio("totalized", "Totalizado")}
              </div>
            </fieldset>

            <fieldset className="absolute left-[3px] top-[49px] h-[47px] w-[453px] rounded-sm border border-blue-400">
              <legend className="px-1 font-semibold text-blue-800">Rango de Fechas</legend>
              <label className={`${labelClass} left-[28px] top-[15px]`} htmlFor="reimbursement-date-from">
                Fecha del :
              </label>
              <input
                id="reimbursement-date-from"
                aria-label="Fecha desde"
                type="date"
                value={dateFrom}
                onChange={(event) => setDateFrom(event.target.value)}
                className="absolute left-[113px] top-[11px] h-[21px] w-[97px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
              />
              <label className={`${labelClass} left-[264px] top-[15px]`} htmlFor="reimbursement-date-to">
                Al :
              </label>
              <input
                id="reimbursement-date-to"
                aria-label="Fecha hasta"
                type="date"
                value={dateTo}
                onChange={(event) => setDateTo(event.target.value)}
                className="absolute left-[300px] top-[11px] h-[21px] w-[94px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
              />
            </fieldset>

            <label className={`${labelClass} left-[5px] top-[110px]`} htmlFor="reimbursement-expense-type">
              Tipo de Gasto :
            </label>
            <select
              id="reimbursement-expense-type"
              aria-label="Tipo de Gasto"
              value={expenseType}
              onChange={(event) => setExpenseType(event.target.value)}
              className={`${comboClass} left-[107px] top-[106px] w-[186px]`}
            >
              <option>(Todos)</option>
            </select>
            <label className={`${labelClass} left-[308px] top-[110px]`} htmlFor="reimbursement-license-plate">
              Placa :
            </label>
            <select
              id="reimbursement-license-plate"
              aria-label="Placa"
              value={licensePlate}
              onChange={(event) => setLicensePlate(event.target.value)}
              className={`${comboClass} left-[361px] top-[106px] w-[95px]`}
            >
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[5px] top-[138px]`} htmlFor="reimbursement-business-unit">
              Unidad de Negocio
            </label>
            <select
              id="reimbursement-business-unit"
              aria-label="Unidad de Negocio"
              value={businessUnit}
              onChange={(event) => {
                setBusinessUnit(event.target.value);
                setArea("(Todos)");
              }}
              className={`${comboClass} left-[126px] top-[134px] w-[120px]`}
            >
              <option>(Todos)</option>
            </select>
            <label className={`${labelClass} left-[263px] top-[138px]`} htmlFor="reimbursement-area">
              Area :
            </label>
            <select
              id="reimbursement-area"
              aria-label="Area"
              value={area}
              onChange={(event) => setArea(event.target.value)}
              className={`${comboClass} left-[306px] top-[134px] w-[146px]`}
            >
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[5px] top-[166px]`} htmlFor="reimbursement-cash-location">
              Ubicación Caja :
            </label>
            <select
              id="reimbursement-cash-location"
              aria-label="Ubicación Caja"
              value={cashLocation}
              onChange={(event) => setCashLocation(event.target.value)}
              className={`${comboClass} left-[112px] top-[162px] w-[134px]`}
            >
              <option value=""></option>
              <option>(Todos)</option>
            </select>
            <label className={`${labelClass} left-[268px] top-[166px]`} htmlFor="reimbursement-number">
              N° Reembolso :
            </label>
            <input
              id="reimbursement-number"
              aria-label="N° Reembolso"
              inputMode="numeric"
              value={reimbursementNumber}
              onChange={(event) => setReimbursementNumber(event.target.value.replace(/\D/g, ""))}
              className={`${inputClass} left-[369px] top-[162px] w-[86px] text-center`}
            />

            <button
              type="button"
              className="absolute left-[144px] top-[188px] flex h-[28px] w-[80px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold hover:bg-[#CFE0F4]"
            >
              <CheckCircle2 aria-hidden="true" size={16} className="text-green-600" />
              Aceptar
            </button>
            <button
              type="button"
              className="absolute left-[235px] top-[188px] flex h-[28px] w-[80px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold hover:bg-[#CFE0F4]"
            >
              <LogOut aria-hidden="true" size={15} className="text-blue-700" />
              Cancelar
            </button>
          </fieldset>
        </div>
      </div>
    </WindowShell>
  );
}

export function ReporteReembolso({ title = "Reporte de Reembolso x Tipo de Gasto" }: { title?: string }) {
  return <ReporteReembolsoList title={title} />;
}

export function ReporteReembolsoList({ title = "Reporte de Reembolso x Tipo de Gasto" }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <ReimbursementReportForm title={title} />
    </div>
  );
}
