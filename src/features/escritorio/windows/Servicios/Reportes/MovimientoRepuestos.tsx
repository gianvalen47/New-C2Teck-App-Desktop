import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function getTodayString() {
  const today = new Date();
  const month = String(today.getMonth() + 1).padStart(2, "0");
  const day = String(today.getDate()).padStart(2, "0");
  return `${today.getFullYear()}-${month}-${day}`;
}

function getMonthStartString() {
  const today = new Date();
  const month = String(today.getMonth() + 1).padStart(2, "0");
  return `${today.getFullYear()}-${month}-01`;
}

export function MovimientoRepuestos({
  title = "Reporte de Movimiento de Repuestos",
}: {
  title?: string;
}) {
  return <MovimientoRepuestosList title={title} />;
}

export function MovimientoRepuestosList({
  title = "Reporte de Movimiento de Repuestos",
}: {
  title?: string;
}) {
  const [reportType, setReportType] = useState<"movement" | "not-returned">("movement");
  const [movementKind, setMovementKind] = useState<"all" | "outgoing" | "incoming" | null>("all");
  const [dataType, setDataType] = useState<"costs" | "prices" | null>("costs");
  const [jobNumber, setJobNumber] = useState("");
  const [startDate, setStartDate] = useState(getMonthStartString);
  const [endDate, setEndDate] = useState(getTodayString);
  const isMovement = reportType === "movement";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[271px] w-[402px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[8px] top-[6px] h-[227px] w-[384px] border border-[#7799c5] px-0">
            <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
              Reporte
            </legend>

            <fieldset className="absolute left-[7px] top-[14px] h-[43px] w-[369px] border border-[#7799c5] px-0">
              <label className="absolute left-[16px] top-[16px] flex items-center gap-[5px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="spare-part-report"
                  checked={reportType === "movement"}
                  onChange={() => {
                    setReportType("movement");
                    setMovementKind("all");
                    setDataType("costs");
                  }}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Movimiento Repuestos
              </label>
              <label className="absolute left-[189px] top-[16px] flex items-center gap-[5px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="spare-part-report"
                  checked={reportType === "not-returned"}
                  onChange={() => {
                    setReportType("not-returned");
                    setMovementKind(null);
                    setDataType(null);
                  }}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Repuestos no Devueltos
              </label>
            </fieldset>

            <label className="absolute left-[33px] top-[69px] whitespace-nowrap font-bold">
              # OT :
            </label>
            <input
              aria-label="Número de OT"
              value={jobNumber}
              onChange={(event) => setJobNumber(event.target.value.toUpperCase())}
              className="absolute left-[23px] top-[87px] h-[20px] w-[65px] border border-[#d5d5d5] bg-white px-[3px] text-center font-bold uppercase"
            />
            <button
              type="button"
              aria-label="Buscar OT"
              className="absolute left-[92px] top-[86px] flex h-[22px] w-[25px] items-center justify-center rounded-[2px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed]"
            >
              <Search className="h-[15px] w-[15px] text-[#234878]" />
            </button>

            <label className="absolute left-[138px] top-[69px] whitespace-nowrap font-bold">
              Fecha Inicial :
            </label>
            <input
              aria-label="Fecha Inicial"
              type="date"
              value={startDate}
              disabled={!isMovement}
              onChange={(event) => setStartDate(event.target.value)}
              className="absolute left-[136px] top-[87px] h-[20px] w-[92px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold disabled:bg-[#e8e8e8] disabled:text-gray-500"
            />
            <label className="absolute left-[264px] top-[69px] whitespace-nowrap font-bold">
              Fecha Final :
            </label>
            <input
              aria-label="Fecha Final"
              type="date"
              value={endDate}
              disabled={!isMovement}
              onChange={(event) => setEndDate(event.target.value)}
              className="absolute left-[258px] top-[87px] h-[20px] w-[92px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold disabled:bg-[#e8e8e8] disabled:text-gray-500"
            />

            <fieldset className="absolute left-[47px] top-[119px] h-[94px] w-[125px] border border-[#b5b5b5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold">Tipo</legend>
              <label className="absolute left-[28px] top-[18px] flex items-center gap-[5px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="spare-part-movement-kind"
                  checked={movementKind === "all"}
                  disabled={!isMovement}
                  onChange={() => setMovementKind("all")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Todos
              </label>
              <label className="absolute left-[28px] top-[42px] flex items-center gap-[5px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="spare-part-movement-kind"
                  checked={movementKind === "outgoing"}
                  disabled={!isMovement}
                  onChange={() => setMovementKind("outgoing")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Egresos
              </label>
              <label className="absolute left-[28px] top-[66px] flex items-center gap-[5px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="spare-part-movement-kind"
                  checked={movementKind === "incoming"}
                  disabled={!isMovement}
                  onChange={() => setMovementKind("incoming")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Ingresos
              </label>
            </fieldset>

            <fieldset className="absolute left-[210px] top-[120px] h-[93px] w-[125px] border border-[#b5b5b5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold">Dato</legend>
              <label className="absolute left-[29px] top-[29px] flex items-center gap-[5px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="spare-part-data-type"
                  checked={dataType === "costs"}
                  disabled={!isMovement}
                  onChange={() => setDataType("costs")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Costos
              </label>
              <label className="absolute left-[29px] top-[53px] flex items-center gap-[5px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="spare-part-data-type"
                  checked={dataType === "prices"}
                  disabled={!isMovement}
                  onChange={() => setDataType("prices")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Precios
              </label>
            </fieldset>
          </fieldset>

          <button
            type="button"
            className="absolute left-[108px] top-[239px] flex h-[25px] w-[76px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <CheckCircle2 className="h-[17px] w-[17px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[199px] top-[239px] flex h-[25px] w-[80px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[16px] w-[16px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
