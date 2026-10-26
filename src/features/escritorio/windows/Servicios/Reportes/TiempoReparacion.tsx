import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function toLocalDateString(date: Date) {
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const day = String(date.getDate()).padStart(2, "0");
  return `${date.getFullYear()}-${month}-${day}`;
}

function getYearStart() {
  return toLocalDateString(new Date(new Date().getFullYear(), 0, 1));
}

function getToday() {
  return toLocalDateString(new Date());
}

export function TiempoReparacion({
  title = "OT Tiempo de Reparación",
}: {
  title?: string;
}) {
  return <TiempoReparacionList title={title} />;
}

export function TiempoReparacionList({
  title = "OT Tiempo de Reparación",
}: {
  title?: string;
}) {
  const [status, setStatus] = useState("(Todos)");
  const [startDate, setStartDate] = useState(getYearStart);
  const [endDate, setEndDate] = useState(getToday);

  const labelClass = "absolute whitespace-nowrap font-bold";
  const fieldClass =
    "absolute h-[20px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[175px] w-[250px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[8px] top-[6px] h-[116px] w-[215px] border border-[#7799c5] px-0">
            <legend className="ml-[5px] px-[3px] font-bold text-[#164b91]">
              Datos de Reporte
            </legend>
            <label className={`${labelClass} left-[37px] top-[22px]`}>Estado :</label>
            <select
              aria-label="Estado"
              value={status}
              onChange={(event) => setStatus(event.target.value)}
              className={`${fieldClass} left-[96px] top-[18px] w-[87px]`}
            >
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[6px] top-[52px]`}>Fecha Inicio :</label>
            <input
              aria-label="Fecha Inicio"
              type="date"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className={`${fieldClass} left-[96px] top-[48px] w-[92px]`}
            />

            <label className={`${labelClass} left-[24px] top-[82px]`}>Fecha Fin:</label>
            <input
              aria-label="Fecha Fin"
              type="date"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className={`${fieldClass} left-[96px] top-[78px] w-[92px]`}
            />
          </fieldset>

          <button
            type="button"
            className="absolute left-[36px] top-[128px] flex h-[25px] w-[77px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[119px] top-[128px] flex h-[25px] w-[77px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[15px] w-[15px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
