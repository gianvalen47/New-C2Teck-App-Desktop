import { useState } from "react";
import { Brush, CheckCircle2, LogOut, Search } from "lucide-react";
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

export function HorasDeTrabajo({ title = "Horas Generales" }: { title?: string }) {
  return <HorasDeTrabajoList title={title} />;
}

export function HorasDeTrabajoList({ title = "Horas Generales" }: { title?: string }) {
  const [location, setLocation] = useState("(Todos)");
  const [jobType, setJobType] = useState("(Todos)");
  const [jobNumber, setJobNumber] = useState("");
  const [personIsAll, setPersonIsAll] = useState(true);
  const [person, setPerson] = useState("(Todos)");
  const [startDate, setStartDate] = useState(getMonthStartString);
  const [endDate, setEndDate] = useState(getTodayString);

  const labelClass = "absolute whitespace-nowrap font-bold";
  const selectClass =
    "absolute h-[20px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[200px] w-[575px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <label className={`${labelClass} left-[12px] top-[17px]`}>Locación:</label>
          <select
            aria-label="Locación"
            value={location}
            onChange={(event) => setLocation(event.target.value)}
            className={`${selectClass} left-[93px] top-[15px] w-[108px]`}
          >
            <option>(Todos)</option>
          </select>

          <label className={`${labelClass} left-[221px] top-[17px]`}>Tipo:</label>
          <select
            aria-label="Tipo"
            value={jobType}
            onChange={(event) => setJobType(event.target.value)}
            className={`${selectClass} left-[271px] top-[15px] w-[95px]`}
          >
            <option>(Todos)</option>
          </select>

          <label className={`${labelClass} left-[395px] top-[17px]`}>Nº OT:</label>
          <input
            aria-label="Número de OT"
            value={jobNumber}
            onChange={(event) => setJobNumber(event.target.value)}
            className="absolute left-[450px] top-[15px] h-[20px] w-[93px] border border-[#d5d5d5] bg-white px-[3px] font-bold"
          />

          <label className={`${labelClass} left-[15px] top-[62px]`}>Colaborador:</label>
          <input
            aria-label="Todos los colaboradores"
            type="checkbox"
            checked={personIsAll}
            disabled={personIsAll}
            onChange={(event) => {
              setPersonIsAll(event.target.checked);
              if (event.target.checked) setPerson("(Todos)");
            }}
            className="absolute left-[120px] top-[66px] m-0 h-[14px] w-[15px] accent-[#0875c9] disabled:opacity-70"
          />
          <button
            type="button"
            aria-label="Limpiar colaborador"
            disabled
            className="absolute left-[137px] top-[62px] flex h-[18px] w-[24px] items-center justify-center text-[#a97816] disabled:opacity-50"
          >
            <Brush className="h-[16px] w-[16px]" />
          </button>
          <input
            aria-label="Colaborador"
            value={person}
            readOnly
            className="absolute left-[167px] top-[61px] h-[20px] w-[340px] border border-[#d5d5d5] bg-white px-[4px] font-bold"
          />
          <button
            type="button"
            aria-label="Buscar colaborador"
            className="absolute left-[509px] top-[59px] flex h-[22px] w-[24px] items-center justify-center rounded-[2px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed]"
          >
            <Search className="h-[15px] w-[15px] text-[#234878]" />
          </button>

          <label className={`${labelClass} left-[64px] top-[108px]`}>Fecha Inicio:</label>
          <input
            aria-label="Fecha Inicio"
            type="date"
            value={startDate}
            onChange={(event) => setStartDate(event.target.value)}
            className="absolute left-[166px] top-[106px] h-[20px] w-[92px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
          />
          <label className={`${labelClass} left-[290px] top-[108px]`}>Fecha Fin:</label>
          <input
            aria-label="Fecha Fin"
            type="date"
            value={endDate}
            onChange={(event) => setEndDate(event.target.value)}
            className="absolute left-[376px] top-[106px] h-[20px] w-[92px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
          />

          <button
            type="button"
            className="absolute left-[194px] top-[152px] flex h-[27px] w-[80px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[283px] top-[152px] flex h-[27px] w-[80px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[15px] w-[15px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
