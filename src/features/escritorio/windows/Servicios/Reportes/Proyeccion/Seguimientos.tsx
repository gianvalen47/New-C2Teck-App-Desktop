import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function toLocalDateString(date: Date) {
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const day = String(date.getDate()).padStart(2, "0");
  return `${date.getFullYear()}-${month}-${day}`;
}

function getMonthStart() {
  const today = new Date();
  return toLocalDateString(new Date(today.getFullYear(), today.getMonth(), 1));
}

function getToday() {
  return toLocalDateString(new Date());
}

export function Seguimientos({
  title = "Reporte de Seguimiento",
}: {
  title?: string;
}) {
  return <SeguimientosList title={title} />;
}

export function SeguimientosList({
  title = "Reporte de Seguimiento",
}: {
  title?: string;
}) {
  const [startDate, setStartDate] = useState(getMonthStart);
  const [endDate, setEndDate] = useState(getToday);
  const [office, setOffice] = useState("LIMA");
  const [followUpType, setFollowUpType] = useState("(Todos)");
  const [motorSystem, setMotorSystem] = useState("(Todos)");
  const [jobNumber, setJobNumber] = useState("");
  const [supervisor, setSupervisor] = useState("");
  const [process, setProcess] = useState("(Todos)");
  const [serialNumber, setSerialNumber] = useState("");
  const [equipment, setEquipment] = useState("");

  const labelClass = "absolute whitespace-nowrap font-bold";
  const selectClass =
    "absolute h-[20px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[298px] w-[558px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <div className="absolute left-[9px] top-[8px] h-[264px] w-[520px] border border-[#7799c5]">
            <label className={`${labelClass} left-[102px] top-[19px]`}>Del :</label>
            <input
              aria-label="Fecha desde"
              type="date"
              min="2010-01-01"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className="absolute left-[142px] top-[15px] h-[20px] w-[97px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />
            <label className={`${labelClass} left-[262px] top-[19px]`}>Al :</label>
            <input
              aria-label="Fecha hasta"
              type="date"
              min="2010-01-01"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className="absolute left-[290px] top-[15px] h-[20px] w-[94px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />

            <label className={`${labelClass} left-[10px] top-[60px]`}>Oficina</label>
            <select
              aria-label="Oficina"
              value={office}
              onChange={(event) => setOffice(event.target.value)}
              className={`${selectClass} left-[65px] top-[56px] w-[123px]`}
            >
              <option>LIMA</option>
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[212px] top-[60px]`}>
              Tipo Seguimiento
            </label>
            <select
              aria-label="Tipo Seguimiento"
              value={followUpType}
              onChange={(event) => setFollowUpType(event.target.value)}
              className={`${selectClass} left-[321px] top-[56px] w-[150px]`}
            >
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[10px] top-[98px]`}>
              Sistemas Motor
            </label>
            <select
              aria-label="Sistemas Motor"
              value={motorSystem}
              onChange={(event) => setMotorSystem(event.target.value)}
              className={`${selectClass} left-[105px] top-[95px] w-[100px]`}
            >
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[292px] top-[98px]`}>OT</label>
            <input
              aria-label="OT"
              value={jobNumber}
              onChange={(event) => setJobNumber(event.target.value)}
              className="absolute left-[321px] top-[95px] h-[20px] w-[79px] border border-[#d5d5d5] bg-white px-[3px] font-bold"
            />
            <button
              type="button"
              aria-label="Buscar OT"
              className="absolute left-[405px] top-[93px] flex h-[22px] w-[25px] items-center justify-center rounded-[2px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed]"
            >
              <Search className="h-[15px] w-[15px] text-[#234878]" />
            </button>

            <label className={`${labelClass} left-[10px] top-[136px]`}>
              Supervisor
            </label>
            <select
              aria-label="Supervisor"
              value={supervisor}
              onChange={(event) => setSupervisor(event.target.value)}
              className={`${selectClass} left-[79px] top-[132px] w-[175px]`}
            >
              <option value=""></option>
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[270px] top-[136px]`}>
              Proceso Seguimiento
            </label>
            <select
              aria-label="Proceso Seguimiento"
              value={process}
              onChange={(event) => setProcess(event.target.value)}
              className={`${selectClass} left-[399px] top-[132px] w-[99px]`}
            >
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[10px] top-[172px]`}>N° Serie</label>
            <input
              aria-label="Número de serie"
              value={serialNumber}
              onChange={(event) => setSerialNumber(event.target.value)}
              className="absolute left-[65px] top-[169px] h-[20px] w-[123px] border border-[#d5d5d5] bg-white px-[3px] font-bold"
            />
            <label className={`${labelClass} left-[206px] top-[172px]`}>Equipo</label>
            <input
              aria-label="Equipo"
              value={equipment}
              onChange={(event) => setEquipment(event.target.value)}
              className="absolute left-[252px] top-[169px] h-[20px] w-[100px] border border-[#d5d5d5] bg-white px-[3px] font-bold"
            />

            <button
              type="button"
              className="absolute left-[165px] top-[214px] flex h-[27px] w-[76px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
            >
              <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
              Aceptar
            </button>
            <button
              type="button"
              className="absolute left-[247px] top-[214px] flex h-[27px] w-[80px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
            >
              <LogOut className="h-[15px] w-[15px] text-gray-700" />
              Cancelar
            </button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}
