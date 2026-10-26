import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function toLocalDateString(date: Date) {
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const day = String(date.getDate()).padStart(2, "0");
  return `${date.getFullYear()}-${month}-${day}`;
}

function getMonthStart() {
  const today = new Date();
  return toLocalDateString(new Date(today.getFullYear(), today.getMonth(), 1));
}

function getToday() {
  return toLocalDateString(new Date());
}

export function TardanzasList() {
  return <Tardanzas />;
}

export function Tardanzas() {
  const [startDate, setStartDate] = useState(getMonthStart);
  const [endDate, setEndDate] = useState(getToday);
  const [area, setArea] = useState("(Todos)");
  const [costCenter, setCostCenter] = useState("(Todos)");
  const [classCode, setClassCode] = useState("(Todos)");
  const [attendanceMarkersOnly, setAttendanceMarkersOnly] = useState(true);
  const [reportType, setReportType] = useState("entry");

  return (
    <WindowShell title="Reporte de Tardanzas">
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[268px] w-[666px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[19px] top-[4px] h-[224px] w-[631px] border border-[#7799c5] px-0">
            <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
              Datos de Reporte
            </legend>

            <label className="absolute left-[122px] top-[21px] whitespace-nowrap font-bold">
              Fechas&nbsp;&nbsp; Del :
            </label>
            <input
              aria-label="Fecha desde"
              type="date"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className="absolute left-[219px] top-[18px] h-[20px] w-[97px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />
            <label className="absolute left-[359px] top-[21px] whitespace-nowrap font-bold">
              Al :
            </label>
            <input
              aria-label="Fecha hasta"
              type="date"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className="absolute left-[391px] top-[18px] h-[20px] w-[94px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />

            <fieldset className="absolute left-[28px] top-[49px] h-[57px] w-[576px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Buscar Persona
              </legend>
              <label className="absolute left-[63px] top-[34px] whitespace-nowrap font-bold">
                Colaborador
              </label>
              <input
                aria-label="Colaborador"
                value="(Todos)"
                readOnly
                className="absolute left-[144px] top-[31px] h-[20px] w-[315px] border border-[#7799c5] bg-white px-[4px] font-bold text-gray-600"
              />
              <button
                type="button"
                aria-label="Buscar colaborador"
                className="absolute left-[465px] top-[31px] flex h-[22px] w-[25px] items-center justify-center rounded-[2px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7]"
              >
                <Search className="h-[15px] w-[15px] text-[#234878]" />
              </button>
              <label className="absolute left-[187px] top-[12px] flex items-center gap-[4px] whitespace-nowrap font-bold text-gray-400">
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

            <label className="absolute left-[40px] top-[118px] whitespace-nowrap font-bold">
              Área
            </label>
            <select
              aria-label="Área"
              value={area}
              onChange={(event) => setArea(event.target.value)}
              className="absolute left-[79px] top-[115px] h-[20px] w-[135px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>
            <label className="absolute left-[268px] top-[118px] whitespace-nowrap font-bold">
              Centro Costo
            </label>
            <select
              aria-label="Centro Costo"
              value={costCenter}
              onChange={(event) => setCostCenter(event.target.value)}
              className="absolute left-[333px] top-[115px] h-[20px] w-[229px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>

            <label className="absolute left-[35px] top-[148px] whitespace-nowrap font-bold">
              Clase
            </label>
            <select
              aria-label="Clase"
              value={classCode}
              onChange={(event) => setClassCode(event.target.value)}
              className="absolute left-[79px] top-[145px] h-[20px] w-[105px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>
            <label className="absolute left-[343px] top-[148px] flex items-center gap-[5px] whitespace-nowrap font-bold">
              <input
                type="checkbox"
                checked={attendanceMarkersOnly}
                onChange={(event) =>
                  setAttendanceMarkersOnly(event.target.checked)
                }
                className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
              />
              Colaboradores que marcan asistencia
            </label>

            <fieldset className="absolute left-[12px] top-[174px] h-[38px] w-[609px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Tipo
              </legend>
              <label className="absolute left-[15px] top-[14px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="tardiness-report-type"
                  checked={reportType === "entry"}
                  onChange={() => setReportType("entry")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Tardanzas de Entrada
              </label>
              <label className="absolute left-[173px] top-[14px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="tardiness-report-type"
                  checked={reportType === "break"}
                  onChange={() => setReportType("break")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Tardanzas de Refrigerio
              </label>
              <label className="absolute left-[340px] top-[14px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="tardiness-report-type"
                  checked={reportType === "consolidated"}
                  onChange={() => setReportType("consolidated")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Consolidado
              </label>
              <label className="absolute left-[440px] top-[14px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="tardiness-report-type"
                  checked={reportType === "record"}
                  onChange={() => setReportType("record")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Record
              </label>
              <label className="absolute left-[510px] top-[14px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="tardiness-report-type"
                  checked={reportType === "punctuality"}
                  onChange={() => setReportType("punctuality")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Puntualidad
              </label>
            </fieldset>
          </fieldset>

          <button
            type="button"
            className="absolute left-[256px] top-[234px] flex h-[25px] w-[76px] items-center justify-center gap-[4px] rounded-[3px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7] text-[12px] font-bold hover:to-[#dce8f5]"
          >
            <CheckCircle2 className="h-[17px] w-[17px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[338px] top-[234px] flex h-[25px] w-[80px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[16px] w-[16px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
