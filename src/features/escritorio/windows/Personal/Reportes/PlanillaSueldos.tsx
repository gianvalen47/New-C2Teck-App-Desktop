import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

export function ReportePlanillaSueldosList() {
  return <ReportePlanillaSueldos />;
}

export function ReportePlanillaSueldos() {
  const today = new Date();
  const [reportType, setReportType] = useState<"detail" | "summary">("detail");
  const [searchBy, setSearchBy] = useState<"payroll" | "period">("payroll");
  const [unit, setUnit] = useState("(Todos)");
  const [payrollNumber, setPayrollNumber] = useState("");
  const [month, setMonth] = useState(String(today.getMonth() + 1).padStart(2, "0"));
  const [year, setYear] = useState(today.getFullYear());

  return (
    <WindowShell title="Planilla Oficial de Sueldos">
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[276px] w-[297px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[7px] top-[3px] h-[219px] w-[264px] border border-[#7799c5] px-0">
            <fieldset className="absolute left-[9px] top-[7px] h-[50px] w-[246px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Tipo
              </legend>
              <label className="absolute left-[27px] top-[21px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="official-payroll-type"
                  checked={reportType === "detail"}
                  onChange={() => setReportType("detail")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Detalle
              </label>
              <label className="absolute left-[110px] top-[21px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="official-payroll-type"
                  checked={reportType === "summary"}
                  onChange={() => setReportType("summary")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Resumen
              </label>
            </fieldset>

            <label className="absolute left-[11px] top-[68px] whitespace-nowrap font-bold">
              Unidad de Negocio
            </label>
            <select
              aria-label="Unidad de Negocio"
              value={unit}
              onChange={(event) => setUnit(event.target.value)}
              className="absolute left-[133px] top-[65px] h-[20px] w-[120px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>

            <fieldset className="absolute left-[9px] top-[92px] h-[115px] w-[244px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Busqueda X
              </legend>
              <label className="absolute left-[25px] top-[21px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="official-payroll-search"
                  checked={searchBy === "payroll"}
                  onChange={() => setSearchBy("payroll")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Nro de Planilla
              </label>
              <input
                aria-label="Número de Planilla"
                value={payrollNumber}
                onChange={(event) => setPayrollNumber(event.target.value.replace(/\D/g, "").slice(0, 9))}
                className="absolute left-[87px] top-[40px] h-[20px] w-[64px] border border-[#aeb6c2] bg-white px-[3px] text-center"
              />
              <button
                type="button"
                aria-label="Buscar planilla"
                className="absolute left-[154px] top-[39px] flex h-[22px] w-[25px] items-center justify-center rounded-[2px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7]"
              >
                <Search className="h-[15px] w-[15px] text-[#234878]" />
              </button>
              <label className="absolute left-[25px] top-[66px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="official-payroll-search"
                  checked={searchBy === "period"}
                  onChange={() => setSearchBy("period")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Periodo
              </label>
              <label className="absolute left-[51px] top-[90px] whitespace-nowrap font-bold">
                Mes
              </label>
              <input
                aria-label="Mes"
                value={month}
                onChange={(event) => setMonth(event.target.value.replace(/\D/g, "").slice(0, 2))}
                className="absolute left-[87px] top-[86px] h-[20px] w-[47px] border border-[#aeb6c2] bg-white px-[3px] text-center"
              />
              <input
                aria-label="Año"
                type="number"
                min={2006}
                max={2059}
                value={year}
                onChange={(event) => setYear(Number(event.target.value))}
                className="absolute left-[148px] top-[86px] h-[20px] w-[65px] border border-[#7799c5] bg-white px-[3px] text-center"
              />
            </fieldset>
          </fieldset>

          <button
            type="button"
            className="absolute left-[50px] top-[228px] flex h-[25px] w-[79px] items-center justify-center gap-[4px] rounded-[3px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7] text-[12px] font-bold hover:to-[#dce8f5]"
          >
            <CheckCircle2 className="h-[17px] w-[17px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[135px] top-[228px] flex h-[25px] w-[79px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[16px] w-[16px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
