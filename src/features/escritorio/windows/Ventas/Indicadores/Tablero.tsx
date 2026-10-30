import { useState } from "react";
import { ChevronLeft, ChevronRight, Search } from "lucide-react";
import { toast } from "sonner";
import { btnPrimary, inp, squareIconBtn } from "@/features/escritorio/windows/uiStyles";

const COLUMNS = ["INDICADOR", "U/M", "FRECUENCIA", "PB", "OBJ.", "REAL", "🚦", "G"];
const EMPTY_ROWS = Array.from({ length: 10 }, (_, index) => index);

function IndicatorGrid({ label }: { label: string }) {
  return (
    <div
      role="grid"
      aria-label={`Indicadores ${label}`}
      className="min-h-0 flex-1 overflow-auto border border-slate-400/60 bg-white"
    >
      <table className="h-full w-full min-w-[560px] border-collapse text-[11px]">
        <colgroup>
          <col className="w-[48%]" />
          <col className="w-[6%]" />
          <col className="w-[15%]" />
          <col className="w-[7%]" />
          <col className="w-[7%]" />
          <col className="w-[7%]" />
          <col className="w-[4%]" />
          <col className="w-[4%]" />
        </colgroup>
        <thead className="sticky top-0 z-10 bg-gradient-to-b from-[#EEF2F7] to-[#C9D3DF] text-slate-800">
          <tr>
            {COLUMNS.map((column) => (
              <th
                key={column}
                className="h-[21px] border border-slate-300/80 px-1 text-center font-semibold whitespace-nowrap"
              >
                {column}
              </th>
            ))}
          </tr>
        </thead>
        <tbody>
          {EMPTY_ROWS.map((row) => (
            <tr key={row} className={row % 2 === 0 ? "bg-white" : "bg-[#F6F9FC]"}>
              {COLUMNS.map((column) => (
                <td key={column} className="h-[19px] border border-slate-200 px-1" />
              ))}
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export function TableroIndicadorList({ title = "Tablero Indicador " }: { title?: string }) {
  const [monthlyDate, setMonthlyDate] = useState("2026-10");
  const [dailyDate, setDailyDate] = useState("2026-10-29");

  const changeDay = (amount: number) => {
    const date = new Date(`${dailyDate}T00:00:00`);
    date.setDate(date.getDate() + amount);
    setDailyDate([
      date.getFullYear(),
      String(date.getMonth() + 1).padStart(2, "0"),
      String(date.getDate()).padStart(2, "0"),
    ].join("-"));
  };

  return (
    <div aria-label={title} className="flex h-full min-h-0 flex-col gap-2 overflow-hidden bg-[#F3F6FA] p-2 text-[11px]">
      <section className="flex min-h-0 flex-1 flex-col gap-1.5">
        <div className="flex h-[76px] shrink-0 items-center justify-center border border-[#7A96B4] bg-[#ECF1F7]">
          <div className="flex w-fit items-center justify-center gap-2">
            <label htmlFor="sales-indicator-month" className="whitespace-nowrap font-bold text-slate-800">
              Fecha Mensual :
            </label>
            <input
              id="sales-indicator-month"
              className={`${inp} w-[98px] shrink-0`}
              type="month"
              value={monthlyDate}
              onChange={(event) => setMonthlyDate(event.target.value)}
            />
            <button
              type="button"
              className={`${btnPrimary} shrink-0`}
              title="Buscar indicadores mensuales"
              onClick={() => toast.info("La consulta requiere conexión al servicio de indicadores.")}
            >
              <Search className="h-3.5 w-3.5" />
              Buscar
            </button>
          </div>
        </div>
        <IndicatorGrid label="mensuales" />
      </section>

      <section className="flex min-h-0 flex-1 flex-col gap-1.5">
        <div className="flex min-h-[54px] shrink-0 items-center justify-center border border-[#7A96B4] bg-[#ECF1F7] py-1">
          <div className="grid w-fit grid-cols-[max-content_104px_max-content] items-center gap-x-2">
            <label htmlFor="sales-indicator-day" className="whitespace-nowrap font-bold text-slate-800">
              Fecha Diaria :
            </label>
            <input
              id="sales-indicator-day"
              className={`${inp} w-[104px]`}
              type="date"
              value={dailyDate}
              onChange={(event) => setDailyDate(event.target.value)}
            />
            <button
              type="button"
              className={`${btnPrimary} shrink-0`}
              title="Buscar indicadores diarios"
              onClick={() => toast.info("La consulta requiere conexión al servicio de indicadores.")}
            >
              <Search className="h-3.5 w-3.5" />
              Buscar
            </button>
            <div className="col-start-2 flex justify-center gap-1">
              <button type="button" className={`${squareIconBtn} w-10`} title="Día anterior" onClick={() => changeDay(-1)}>
                <ChevronLeft className="h-3.5 w-3.5" />
              </button>
              <button type="button" className={`${squareIconBtn} w-10`} title="Día siguiente" onClick={() => changeDay(1)}>
                <ChevronRight className="h-3.5 w-3.5" />
              </button>
            </div>
          </div>
        </div>
        <IndicatorGrid label="diarios" />
      </section>
    </div>
  );
}

export function TableroIndicador({ title = "Tablero Indicador" }: { title?: string }) {
  return <TableroIndicadorList title={title} />;
}
