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

export function RepuestosAImportar({
  title = "Reporte Proyección de Repuestos a Consumir",
}: {
  title?: string;
}) {
  return <RepuestosAImportarList title={title} />;
}

export function RepuestosAImportarList({
  title = "Reporte Proyección de Repuestos a Consumir",
}: {
  title?: string;
}) {
  const [startDate, setStartDate] = useState(getToday);
  const [endDate, setEndDate] = useState(getToday);
  const [location, setLocation] = useState("(Todos)");
  const [excludeW4, setExcludeW4] = useState(false);

  const labelClass = "absolute whitespace-nowrap font-bold";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[196px] w-[417px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[12px] top-[12px] h-[114px] w-[372px] border border-[#7799c5] px-0">
            <legend className="ml-[5px] px-[3px] font-bold text-[#164b91]">
              Fecha
            </legend>
            <label className={`${labelClass} left-[24px] top-[18px]`}>Del :</label>
            <input
              aria-label="Fecha desde"
              type="date"
              min="2010-01-01"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className="absolute left-[68px] top-[14px] h-[20px] w-[97px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />
            <label className={`${labelClass} left-[190px] top-[18px]`}>Al :</label>
            <input
              aria-label="Fecha hasta"
              type="date"
              min="2010-01-01"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className="absolute left-[230px] top-[14px] h-[20px] w-[94px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />

            <label className={`${labelClass} left-[6px] top-[49px]`}>
              Ubicación :
            </label>
            <select
              aria-label="Ubicación"
              value={location}
              onChange={(event) => setLocation(event.target.value)}
              className="absolute left-[78px] top-[45px] h-[20px] w-[168px] border border-[#7799c5] bg-white px-[3px] text-center text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>

            <label className="absolute left-[78px] top-[74px] flex items-center gap-[5px] whitespace-nowrap font-bold">
              <input
                type="checkbox"
                checked={excludeW4}
                onChange={(event) => setExcludeW4(event.target.checked)}
                className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
              />
              No incluir W4
            </label>
          </fieldset>

          <button
            type="button"
            className="absolute left-[113px] top-[141px] flex h-[27px] w-[79px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[206px] top-[141px] flex h-[27px] w-[79px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[15px] w-[15px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
