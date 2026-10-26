import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function getToday() {
  const today = new Date();
  const month = String(today.getMonth() + 1).padStart(2, "0");
  const day = String(today.getDate()).padStart(2, "0");
  return `${today.getFullYear()}-${month}-${day}`;
}

export function ReporteNotDebCred({
  title = "Reporte de Notas Débito/Crédito",
}: {
  title?: string;
}) {
  return <ReporteNotDebCredList title={title} />;
}

export function ReporteNotDebCredList({
  title = "Reporte de Notas Débito/Crédito",
}: {
  title?: string;
}) {
  const [date, setDate] = useState(getToday);

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[174px] w-[358px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[12px] top-[12px] h-[76px] w-[331px] border border-[#d7d7d7] px-0">
            <legend className="ml-[5px] px-[3px] font-bold">A LA FECHA</legend>
            <input
              aria-label="Fecha"
              type="date"
              min="1992-01-01"
              value={date}
              onChange={(event) => setDate(event.target.value)}
              className="absolute left-[117px] top-[28px] h-[20px] w-[97px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />
          </fieldset>

          <button
            type="button"
            className="absolute left-[89px] top-[135px] flex h-[27px] w-[78px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[173px] top-[135px] flex h-[27px] w-[78px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[15px] w-[15px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
