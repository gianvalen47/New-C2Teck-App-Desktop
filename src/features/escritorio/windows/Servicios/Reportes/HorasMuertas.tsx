import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
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

export function HorasMuertas({
  title = "Reporte de Horas Muertas",
}: {
  title?: string;
}) {
  return <HorasMuertasList title={title} />;
}

export function HorasMuertasList({
  title = "Reporte de Horas Muertas",
}: {
  title?: string;
}) {
  const [reportType, setReportType] = useState<"detailed" | "summary" | "job">(
    "detailed",
  );
  const [startDate, setStartDate] = useState(getMonthStart);
  const [endDate, setEndDate] = useState(getToday);
  const [classType, setClassType] = useState("Técnico");
  const [position, setPosition] = useState("(Todos)");

  const labelClass = "absolute whitespace-nowrap font-bold";
  const selectClass =
    "absolute h-[20px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[204px] w-[465px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <div className="absolute left-[10px] top-[7px] h-[185px] w-[443px] border border-[#d7d7d7]">
            <fieldset className="absolute left-[50px] top-[13px] h-[40px] w-[342px] border border-[#7799c5] px-0">
              <label className="absolute left-[12px] top-[12px] flex items-center gap-[5px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="dead-hours-report-type"
                  checked={reportType === "detailed"}
                  onChange={() => setReportType("detailed")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Detallado
              </label>
              <label className="absolute left-[113px] top-[12px] flex items-center gap-[5px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="dead-hours-report-type"
                  checked={reportType === "summary"}
                  onChange={() => setReportType("summary")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Resumido
              </label>
              <label className="absolute left-[217px] top-[12px] flex items-center gap-[5px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="dead-hours-report-type"
                  checked={reportType === "job"}
                  onChange={() => setReportType("job")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Agrupado x OT
              </label>
            </fieldset>

            <label className={`${labelClass} left-[23px] top-[69px]`}>
              Fecha Inicio :
            </label>
            <input
              aria-label="Fecha Inicio"
              type="date"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className="absolute left-[104px] top-[65px] h-[20px] w-[92px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />
            <label className={`${labelClass} left-[240px] top-[69px]`}>
              Fecha Fin :
            </label>
            <input
              aria-label="Fecha Fin"
              type="date"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className="absolute left-[302px] top-[65px] h-[20px] w-[92px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />

            <label className={`${labelClass} left-[24px] top-[105px]`}>Clase :</label>
            <select
              aria-label="Clase"
              value={classType}
              onChange={(event) => setClassType(event.target.value)}
              className={`${selectClass} left-[63px] top-[101px] w-[103px]`}
            >
              <option>Técnico</option>
              <option>(Todos)</option>
            </select>
            <label className={`${labelClass} left-[193px] top-[105px]`}>Cargo :</label>
            <select
              aria-label="Cargo"
              value={position}
              onChange={(event) => setPosition(event.target.value)}
              className={`${selectClass} left-[233px] top-[101px] w-[179px]`}
            >
              <option>(Todos)</option>
            </select>

            <button
              type="button"
              className="absolute left-[136px] top-[146px] flex h-[28px] w-[74px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
            >
              <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
              Aceptar
            </button>
            <button
              type="button"
              className="absolute left-[218px] top-[146px] flex h-[28px] w-[80px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
            >
              <LogOut className="h-[15px] w-[15px] text-gray-700" />
              Cancelar
            </button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}
