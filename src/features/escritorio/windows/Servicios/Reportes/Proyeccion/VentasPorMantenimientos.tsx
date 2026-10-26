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

function getYearEnd() {
  return toLocalDateString(new Date(new Date().getFullYear(), 11, 31));
}

export function VentasPorMantenimientos({
  title = "Reporte Ventas Proyectadas por Mantenimiento",
}: {
  title?: string;
}) {
  return <VentasPorMantenimientosList title={title} />;
}

export function VentasPorMantenimientosList({
  title = "Reporte Ventas Proyectadas por Mantenimiento",
}: {
  title?: string;
}) {
  const [startDate, setStartDate] = useState(getYearStart);
  const [endDate, setEndDate] = useState(getYearEnd);

  const dateInputClass =
    "absolute h-[20px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[108px] w-[389px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[9px] top-[5px] h-[50px] w-[372px] border border-[#7799c5] px-0">
            <legend className="ml-[5px] px-[3px] font-bold text-[#164b91]">Fecha</legend>
            <label className="absolute left-[39px] top-[26px] whitespace-nowrap font-bold">
              Del :
            </label>
            <input
              aria-label="Fecha desde"
              type="date"
              min="2010-01-01"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className={`${dateInputClass} left-[86px] top-[24px] w-[97px]`}
            />
            <label className="absolute left-[211px] top-[26px] whitespace-nowrap font-bold">
              Al  :
            </label>
            <input
              aria-label="Fecha hasta"
              type="date"
              min="2010-01-01"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className={`${dateInputClass} left-[251px] top-[24px] w-[94px]`}
            />
          </fieldset>

          <button
            type="button"
            className="absolute left-[107px] top-[70px] flex h-[27px] w-[79px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[200px] top-[70px] flex h-[27px] w-[79px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[15px] w-[15px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
