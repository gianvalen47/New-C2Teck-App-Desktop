import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function toLocalDateString(date: Date) {
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const day = String(date.getDate()).padStart(2, "0");
  return `${date.getFullYear()}-${month}-${day}`;
}

function getToday() {
  return toLocalDateString(new Date());
}

export function DisponibilidadDelMotor({
  title = "Reporte de Disponibilidad Motor",
}: {
  title?: string;
}) {
  return <DisponibilidadDelMotorList title={title} />;
}

export function DisponibilidadDelMotorList({
  title = "Reporte de Disponibilidad Motor",
}: {
  title?: string;
}) {
  const [detailLevel, setDetailLevel] = useState<"summary" | "detailed">("summary");
  const [reportType, setReportType] = useState<
    "operational" | "mtbf" | "mttr" | "inherent"
  >("operational");
  const [startDate, setStartDate] = useState(getToday);
  const [endDate, setEndDate] = useState(getToday);
  const [office, setOffice] = useState("LIMA");
  const [serialNumber, setSerialNumber] = useState("");
  const [equipment, setEquipment] = useState("");
  const [model, setModel] = useState("(Todos)");

  const labelClass = "absolute whitespace-nowrap font-bold";
  const selectClass =
    "absolute h-[20px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[319px] w-[571px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[183px] top-[20px] h-[49px] w-[207px] border border-[#7799c5] px-0">
            <legend className="mx-auto px-[3px] font-bold text-[#164b91]">Tipo</legend>
            <label className="absolute left-[17px] top-[19px] flex items-center gap-[5px] whitespace-nowrap font-bold">
              <input
                type="radio"
                name="motor-availability-detail"
                checked={detailLevel === "summary"}
                onChange={() => setDetailLevel("summary")}
                className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
              />
              Resumen
            </label>
            <label className="absolute left-[112px] top-[19px] flex items-center gap-[5px] whitespace-nowrap font-bold">
              <input
                type="radio"
                name="motor-availability-detail"
                checked={detailLevel === "detailed"}
                onChange={() => setDetailLevel("detailed")}
                className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
              />
              Detallado
            </label>
          </fieldset>

          <fieldset className="absolute left-[21px] top-[77px] h-[49px] w-[522px] border border-[#7799c5] px-0">
            <legend className="mx-auto px-[3px] font-bold text-[#164b91]">
              Tipo Reporte
            </legend>
            <label className="absolute left-[12px] top-[21px] flex items-center gap-[5px] whitespace-nowrap font-bold">
              <input
                type="radio"
                name="motor-availability-report-type"
                checked={reportType === "operational"}
                onChange={() => setReportType("operational")}
                className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
              />
              Disponibilidad Operativa
            </label>
            <label className="absolute left-[195px] top-[21px] flex items-center gap-[5px] whitespace-nowrap font-bold">
              <input
                type="radio"
                name="motor-availability-report-type"
                checked={reportType === "mtbf"}
                onChange={() => setReportType("mtbf")}
                className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
              />
              MTBF
            </label>
            <label className="absolute left-[272px] top-[21px] flex items-center gap-[5px] whitespace-nowrap font-bold">
              <input
                type="radio"
                name="motor-availability-report-type"
                checked={reportType === "mttr"}
                onChange={() => setReportType("mttr")}
                className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
              />
              MTTR
            </label>
            <label className="absolute left-[352px] top-[21px] flex items-center gap-[5px] whitespace-nowrap font-bold">
              <input
                type="radio"
                name="motor-availability-report-type"
                checked={reportType === "inherent"}
                onChange={() => setReportType("inherent")}
                className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
              />
              Disponibilidad Inherente
            </label>
          </fieldset>

          <label className={`${labelClass} left-[95px] top-[155px]`}>
            Fechas&nbsp;&nbsp; Del :
          </label>
          <input
            aria-label="Fecha desde"
            type="date"
            min="2010-01-01"
            value={startDate}
            onChange={(event) => setStartDate(event.target.value)}
            className="absolute left-[192px] top-[151px] h-[20px] w-[97px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
          />
          <label className={`${labelClass} left-[305px] top-[155px]`}>Al :</label>
          <input
            aria-label="Fecha hasta"
            type="date"
            min="2010-01-01"
            value={endDate}
            onChange={(event) => setEndDate(event.target.value)}
            className="absolute left-[349px] top-[151px] h-[20px] w-[94px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
          />

          <label className={`${labelClass} left-[78px] top-[195px]`}>Oficina :</label>
          <select
            aria-label="Oficina"
            value={office}
            onChange={(event) => setOffice(event.target.value)}
            className={`${selectClass} left-[127px] top-[191px] w-[109px]`}
          >
            <option>LIMA</option>
            <option>(Todos)</option>
          </select>

          <label className={`${labelClass} left-[284px] top-[195px]`}>N/S Motor :</label>
          <input
            aria-label="Número de serie del motor"
            value={serialNumber}
            onChange={(event) => setSerialNumber(event.target.value)}
            className="absolute left-[353px] top-[192px] h-[20px] w-[100px] border border-[#d5d5d5] bg-white px-[3px] font-bold"
          />

          <label className={`${labelClass} left-[79px] top-[234px]`}>Equipo :</label>
          <input
            aria-label="Equipo"
            value={equipment}
            onChange={(event) => setEquipment(event.target.value)}
            className="absolute left-[127px] top-[231px] h-[20px] w-[84px] border border-[#d5d5d5] bg-white px-[3px] font-bold"
          />

          <label className={`${labelClass} left-[262px] top-[235px]`}>
            Modelo Equipo :
          </label>
          <select
            aria-label="Modelo Equipo"
            value={model}
            onChange={(event) => setModel(event.target.value)}
            className={`${selectClass} left-[355px] top-[230px] w-[138px]`}
          >
            <option>(Todos)</option>
          </select>

          <button
            type="button"
            className="absolute left-[203px] top-[271px] flex h-[27px] w-[76px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[287px] top-[271px] flex h-[27px] w-[80px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[15px] w-[15px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
