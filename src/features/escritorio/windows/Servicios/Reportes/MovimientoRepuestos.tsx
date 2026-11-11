import { useState } from "react";
import { Search } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  iconBtn,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

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
      <div className="flex h-full min-h-0 items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[430px] space-y-2 px-1 py-2">
          <Fs legend="Reporte" className="px-2 pb-2 pt-0">
            <div className="flex flex-wrap items-center justify-center gap-x-6 gap-y-1">
              <label className="inline-flex items-center gap-1.5 whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="spare-part-report"
                  checked={reportType === "movement"}
                  onChange={() => {
                    setReportType("movement");
                    setMovementKind("all");
                    setDataType("costs");
                  }}
                  className="m-0 h-[13px] w-[13px] accent-[#2A5590]"
                />
                Movimiento Repuestos
              </label>
              <label className="inline-flex items-center gap-1.5 whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="spare-part-report"
                  checked={reportType === "not-returned"}
                  onChange={() => {
                    setReportType("not-returned");
                    setMovementKind(null);
                    setDataType(null);
                  }}
                  className="m-0 h-[13px] w-[13px] accent-[#2A5590]"
                />
                Repuestos no Devueltos
              </label>
            </div>
          </Fs>

          <div className="mx-auto grid w-full max-w-[390px] grid-cols-[100px_minmax(0,1fr)_minmax(0,1fr)] items-end gap-x-3">
            <label className="flex min-w-0 flex-col gap-1 whitespace-nowrap">
              <span className="text-center font-bold"># OT :</span>
              <span className="flex items-center gap-1">
                <input
                  aria-label="Número de OT"
                  value={jobNumber}
                  onChange={(event) => setJobNumber(event.target.value.toUpperCase())}
                  className={`${inp} h-6 min-w-0 w-full px-1 text-center font-bold uppercase`}
                />
                <button type="button" className={iconBtn} aria-label="Buscar OT">
                  <Search className="h-3.5 w-3.5" />
                </button>
              </span>
            </label>

            <label className="flex min-w-0 flex-col gap-1 whitespace-nowrap">
              <span className="text-center font-bold">Fecha Inicial :</span>
              <input
                aria-label="Fecha Inicial"
                type="date"
                value={startDate}
                disabled={!isMovement}
                onChange={(event) => setStartDate(event.target.value)}
                className={`${inp} h-6 min-w-0 w-full px-1 font-bold text-[#164b91] disabled:bg-slate-100 disabled:text-slate-500`}
              />
            </label>

            <label className="flex min-w-0 flex-col gap-1 whitespace-nowrap">
              <span className="text-center font-bold">Fecha Final :</span>
              <input
                aria-label="Fecha Final"
                type="date"
                value={endDate}
                disabled={!isMovement}
                onChange={(event) => setEndDate(event.target.value)}
                className={`${inp} h-6 min-w-0 w-full px-1 font-bold text-[#164b91] disabled:bg-slate-100 disabled:text-slate-500`}
              />
            </label>
          </div>

          <div className="mx-auto grid w-fit grid-cols-2 gap-4">
            <Fs legend="Tipo" className="h-[122px] w-[120px] px-2 pb-2 pt-0">
              <div className="flex h-[76px] flex-col items-center justify-center gap-1">
                <label className="inline-flex items-center gap-1.5">
                  <input
                    type="radio"
                    name="spare-part-movement-kind"
                    checked={movementKind === "all"}
                    disabled={!isMovement}
                    onChange={() => setMovementKind("all")}
                    className="m-0 h-[13px] w-[13px] accent-[#2A5590]"
                  />
                  Todos
                </label>
                <label className="inline-flex items-center gap-1.5">
                  <input
                    type="radio"
                    name="spare-part-movement-kind"
                    checked={movementKind === "outgoing"}
                    disabled={!isMovement}
                    onChange={() => setMovementKind("outgoing")}
                    className="m-0 h-[13px] w-[13px] accent-[#2A5590]"
                  />
                  Egresos
                </label>
                <label className="inline-flex items-center gap-1.5">
                  <input
                    type="radio"
                    name="spare-part-movement-kind"
                    checked={movementKind === "incoming"}
                    disabled={!isMovement}
                    onChange={() => setMovementKind("incoming")}
                    className="m-0 h-[13px] w-[13px] accent-[#2A5590]"
                  />
                  Ingresos
                </label>
              </div>
            </Fs>

            <Fs legend="Dato" className="h-[122px] w-[120px] px-2 pb-2 pt-0">
              <div className="flex h-[76px] flex-col items-center justify-center gap-1">
                <label className="inline-flex items-center gap-1.5">
                  <input
                    type="radio"
                    name="spare-part-data-type"
                    checked={dataType === "costs"}
                    disabled={!isMovement}
                    onChange={() => setDataType("costs")}
                    className="m-0 h-[13px] w-[13px] accent-[#2A5590]"
                  />
                  Costos
                </label>
                <label className="inline-flex items-center gap-1.5">
                  <input
                    type="radio"
                    name="spare-part-data-type"
                    checked={dataType === "prices"}
                    disabled={!isMovement}
                    onChange={() => setDataType("prices")}
                    className="m-0 h-[13px] w-[13px] accent-[#2A5590]"
                  />
                  Precios
                </label>
              </div>
            </Fs>
          </div>

          <div className="flex justify-center gap-2 pt-1">
            <button type="button" className={btnPrimary}>
              Aceptar
            </button>
            <button type="button" className={btn}>
              Cancelar
            </button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}
