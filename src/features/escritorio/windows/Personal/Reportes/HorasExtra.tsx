import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function getToday() {
  const today = new Date();
  const month = String(today.getMonth() + 1).padStart(2, "0");
  const day = String(today.getDate()).padStart(2, "0");
  return `${today.getFullYear()}-${month}-${day}`;
}

export function HorasExtraList() {
  return <HorasExtra />;
}

export function HorasExtra() {
  const [startDate, setStartDate] = useState(getToday);
  const [endDate, setEndDate] = useState(getToday);
  const [area, setArea] = useState("(Todos)");
  const [costCenter, setCostCenter] = useState("(Todos)");
  const [classCode, setClassCode] = useState("(Todos)");
  const [jobNumber, setJobNumber] = useState("");
  const [location, setLocation] = useState("(Todos)");
  const [authorizer, setAuthorizer] = useState("(Ninguno)");
  const [reportType, setReportType] = useState("detailed");

  return (
    <WindowShell title="Reporte de Horas Extra">
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[300px] w-[498px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[7px] top-[4px] h-[257px] w-[483px] border border-[#7799c5] px-0">
            <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
              Datos de Reporte
            </legend>

            <label className="absolute left-[70px] top-[23px] whitespace-nowrap font-bold">
              Fechas&nbsp;&nbsp; Del :
            </label>
            <input
              aria-label="Fecha desde"
              type="date"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className="absolute left-[167px] top-[20px] h-[20px] w-[97px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />
            <label className="absolute left-[283px] top-[23px] whitespace-nowrap font-bold">
              Al :
            </label>
            <input
              aria-label="Fecha hasta"
              type="date"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className="absolute left-[315px] top-[20px] h-[20px] w-[94px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />

            <fieldset className="absolute left-[36px] top-[48px] h-[57px] w-[411px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Buscar Persona
              </legend>
              <label className="absolute left-[20px] top-[34px] whitespace-nowrap font-bold">
                Colaborador
              </label>
              <input
                aria-label="Colaborador"
                value="(Todos)"
                readOnly
                className="absolute left-[101px] top-[31px] h-[20px] w-[264px] border border-[#7799c5] bg-white px-[4px] font-bold text-gray-600"
              />
              <button
                type="button"
                aria-label="Buscar colaborador"
                className="absolute left-[368px] top-[29px] flex h-[22px] w-[25px] items-center justify-center rounded-[2px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7]"
              >
                <Search className="h-[15px] w-[15px] text-[#234878]" />
              </button>
              <label className="absolute left-[157px] top-[12px] flex items-center gap-[4px] whitespace-nowrap font-bold text-gray-400">
                <input
                  type="checkbox"
                  checked
                  disabled
                  readOnly
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Todos los Colaboradores
              </label>
            </fieldset>

            <label className="absolute left-[27px] top-[118px] whitespace-nowrap font-bold">
              Área
            </label>
            <select
              aria-label="Área"
              value={area}
              onChange={(event) => setArea(event.target.value)}
              className="absolute left-[63px] top-[115px] h-[20px] w-[121px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>
            <label className="absolute left-[201px] top-[118px] whitespace-nowrap font-bold">
              Centro Costo
            </label>
            <select
              aria-label="Centro Costo"
              value={costCenter}
              onChange={(event) => setCostCenter(event.target.value)}
              className="absolute left-[283px] top-[115px] h-[20px] w-[189px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>

            <label className="absolute left-[22px] top-[151px] whitespace-nowrap font-bold">
              Clase
            </label>
            <select
              aria-label="Clase"
              value={classCode}
              onChange={(event) => setClassCode(event.target.value)}
              className="absolute left-[63px] top-[148px] h-[20px] w-[89px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>
            <label className="absolute left-[166px] top-[151px] whitespace-nowrap font-bold">
              Nº Job
            </label>
            <input
              aria-label="Número de Job"
              value={jobNumber}
              onChange={(event) => setJobNumber(event.target.value.toUpperCase())}
              className="absolute left-[215px] top-[148px] h-[20px] w-[55px] border border-[#7799c5] bg-white px-[4px] text-center font-bold uppercase"
            />
            <button
              type="button"
              aria-label="Buscar Job"
              className="absolute left-[269px] top-[147px] flex h-[22px] w-[25px] items-center justify-center rounded-[2px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7]"
            >
              <Search className="h-[15px] w-[15px] text-[#234878]" />
            </button>
            <label className="absolute left-[302px] top-[151px] whitespace-nowrap font-bold">
              Ubicación
            </label>
            <select
              aria-label="Ubicación"
              value={location}
              onChange={(event) => setLocation(event.target.value)}
              className="absolute left-[369px] top-[148px] h-[20px] w-[102px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>

            <label className="absolute left-[7px] top-[185px] whitespace-nowrap font-bold">
              Autoriza
            </label>
            <select
              aria-label="Autoriza"
              value={authorizer}
              onChange={(event) => setAuthorizer(event.target.value)}
              className="absolute left-[63px] top-[182px] h-[20px] w-[314px] border border-[#7799c5] bg-white px-[3px] text-center text-[12px] font-bold"
            >
              <option>(Ninguno)</option>
            </select>

            <fieldset className="absolute left-[36px] top-[208px] h-[38px] w-[411px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Tipo
              </legend>
              <label className="absolute left-[15px] top-[13px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="overtime-report-type"
                  checked={reportType === "detailed"}
                  onChange={() => setReportType("detailed")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Detallado
              </label>
              <label className="absolute left-[103px] top-[13px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="overtime-report-type"
                  checked={reportType === "summary"}
                  onChange={() => setReportType("summary")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Resumen
              </label>
              <label className="absolute left-[190px] top-[13px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="overtime-report-type"
                  checked={reportType === "compensated"}
                  onChange={() => setReportType("compensated")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Hrs. Compensadas
              </label>
              <label className="absolute left-[329px] top-[13px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="overtime-report-type"
                  checked={reportType === "export"}
                  onChange={() => setReportType("export")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Exportar
              </label>
            </fieldset>
          </fieldset>

          <button
            type="button"
            className="absolute left-[169px] top-[267px] flex h-[27px] w-[77px] items-center justify-center gap-[4px] rounded-[3px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7] text-[12px] font-bold hover:to-[#dce8f5]"
          >
            <CheckCircle2 className="h-[17px] w-[17px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[252px] top-[267px] flex h-[27px] w-[80px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[16px] w-[16px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
