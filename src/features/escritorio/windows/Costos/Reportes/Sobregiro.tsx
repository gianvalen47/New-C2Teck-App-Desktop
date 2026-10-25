import { useMemo, useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function getPreviousMonthRange(date: Date) {
  const start = new Date(date.getFullYear(), date.getMonth() - 1, 1);
  const end = new Date(date.getFullYear(), date.getMonth(), 0);
  const toInputValue = (value: Date) =>
    `${value.getFullYear()}-${String(value.getMonth() + 1).padStart(2, "0")}-${String(value.getDate()).padStart(2, "0")}`;

  return { start: toInputValue(start), end: toInputValue(end) };
}

export function SobregiroCostosReport() {
  const initialRange = useMemo(() => getPreviousMonthRange(new Date()), []);
  const [startDate, setStartDate] = useState(initialRange.start);
  const [endDate, setEndDate] = useState(initialRange.end);
  const [office, setOffice] = useState("");
  const [warehouse, setWarehouse] = useState("");

  return (
    <WindowShell title="Sobregiro">
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto p-2">
        <div className="relative h-[178px] w-[311px] shrink-0 bg-[#F3F6FA] font-[Arial,sans-serif] text-[11px] text-gray-900">
          <fieldset className="absolute left-[9px] top-[8px] h-[57px] w-[261px] border border-[#7e9fca] px-0">
            <legend className="ml-[4px] px-[2px] text-[11px] font-bold text-[#1f4e79]">
              Fechas
            </legend>
            <label className="absolute left-[6px] top-[18px] h-[17px] whitespace-nowrap">
              <span>Del :</span>
            </label>
            <input
              aria-label="Fecha de inicio"
              type="date"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className="absolute left-[39px] top-[23px] h-[20px] w-[90px] border border-[#7e9fca] bg-white px-[3px] text-[11px] font-bold"
            />
            <label className="absolute left-[133px] top-[18px] h-[17px] whitespace-nowrap">
              <span>Al :</span>
            </label>
            <input
              aria-label="Fecha final"
              type="date"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className="absolute left-[160px] top-[24px] h-[20px] w-[88px] border border-[#7e9fca] bg-white px-[3px] text-[11px] font-bold"
            />
          </fieldset>

          <fieldset className="absolute left-[9px] top-[71px] h-[62px] w-[292px] border border-[#7e9fca] px-0">
            <legend className="ml-[4px] px-[2px] text-[11px] font-bold text-[#1f4e79]">
              Almacenes
            </legend>
            <label className="absolute left-[10px] top-[19px] whitespace-nowrap font-bold">
              Oficina :
            </label>
            <select
              aria-label="Oficina"
              value={office}
              onChange={(event) => {
                setOffice(event.target.value);
                setWarehouse("");
              }}
              className="absolute left-[67px] top-[15px] h-[20px] w-[161px] border border-[#7e9fca] bg-white px-[3px] text-[11px] font-bold"
            >
              <option value="">(Todos)</option>
            </select>
            <label className="absolute left-[2px] top-[41px] whitespace-nowrap font-bold">
              Almacen :
            </label>
            <select
              aria-label="Almacén"
              value={warehouse}
              onChange={(event) => setWarehouse(event.target.value)}
              className="absolute left-[67px] top-[37px] h-[20px] w-[210px] border border-[#7e9fca] bg-white px-[3px] text-[11px] font-bold"
            >
              <option value="">(Todos)</option>
            </select>
          </fieldset>

          <button
            type="button"
            className="absolute left-[134px] top-[141px] flex h-[27px] w-[75px] items-center justify-center gap-[5px] rounded-[4px] border border-[#2875c7] bg-gradient-to-b from-white to-[#e8f0fa] text-[11px] font-bold shadow-sm hover:from-[#f7fbff] hover:to-[#dbe8f7]"
          >
            <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[221px] top-[141px] flex h-[27px] w-[75px] items-center justify-center gap-[4px] rounded-[4px] border border-[#a8a8a8] bg-gradient-to-b from-white to-[#ededed] text-[11px] font-bold shadow-sm hover:from-white hover:to-[#e2e2e2]"
          >
            <LogOut className="h-[15px] w-[15px] text-[#353535]" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}