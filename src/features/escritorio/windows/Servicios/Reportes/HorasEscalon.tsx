import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

export function HorasEscalon({
  title = "Reporte Consolidado de Horas",
}: {
  title?: string;
}) {
  return <HorasEscalonList title={title} />;
}

export function HorasEscalonList({
  title = "Reporte Consolidado de Horas",
}: {
  title?: string;
}) {
  const [year, setYear] = useState(2006);
  const [escalon, setEscalon] = useState("(Todos)");
  const [jobNumber, setJobNumber] = useState("");
  const [process, setProcess] = useState("(Todos)");
  const [status, setStatus] = useState("(Todos)");
  const [allClients, setAllClients] = useState(true);
  const [client, setClient] = useState("(TODOS)");

  const labelClass = "absolute whitespace-nowrap font-bold";
  const selectClass =
    "absolute h-[20px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[229px] w-[456px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <div className="absolute left-[5px] top-[5px] h-[211px] w-[441px] border border-[#d7d7d7]">
            <label className={`${labelClass} left-[15px] top-[24px]`}>Año:</label>
            <input
              aria-label="Año"
              type="number"
              min={2006}
              max={2020}
              value={year}
              onChange={(event) => {
                const value = Number(event.target.value);
                if (Number.isInteger(value) && value >= 2006 && value <= 2020) {
                  setYear(value);
                }
              }}
              className="absolute left-[49px] top-[20px] h-[20px] w-[53px] border border-[#7799c5] bg-white px-[2px] text-center font-bold"
            />

            <label className={`${labelClass} left-[126px] top-[24px]`}>Escalón:</label>
            <select
              aria-label="Escalón"
              value={escalon}
              onChange={(event) => setEscalon(event.target.value)}
              className={`${selectClass} left-[184px] top-[20px] w-[95px]`}
            >
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[304px] top-[23px]`}>OT :</label>
            <input
              aria-label="OT"
              value={jobNumber}
              onChange={(event) => setJobNumber(event.target.value)}
              className="absolute left-[341px] top-[20px] h-[20px] w-[63px] border border-[#d5d5d5] bg-white px-[3px] font-bold"
            />
            <button
              type="button"
              aria-label="Buscar OT"
              className="absolute left-[407px] top-[19px] flex h-[22px] w-[25px] items-center justify-center rounded-[2px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed]"
            >
              <Search className="h-[15px] w-[15px] text-[#234878]" />
            </button>

            <label className={`${labelClass} left-[16px] top-[61px]`}>Proceso:</label>
            <select
              aria-label="Proceso"
              value={process}
              onChange={(event) => setProcess(event.target.value)}
              className={`${selectClass} left-[87px] top-[57px] w-[95px]`}
            >
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[208px] top-[61px]`}>Estado :</label>
            <select
              aria-label="Estado"
              value={status}
              onChange={(event) => setStatus(event.target.value)}
              className={`${selectClass} left-[264px] top-[57px] w-[103px]`}
            >
              <option>(Todos)</option>
            </select>

            <fieldset className="absolute left-[10px] top-[94px] h-[61px] w-[422px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] font-bold text-[#164b91]">
                Buscar Cliente
              </legend>
              <label className="absolute left-[160px] top-[17px] flex items-center gap-[5px] whitespace-nowrap font-bold">
                <input
                  aria-label="Todo Cliente"
                  type="checkbox"
                  checked={allClients}
                  onChange={(event) => {
                    const checked = event.target.checked;
                    setAllClients(checked);
                    if (checked) setClient("(TODOS)");
                    else if (client === "(TODOS)") setClient("");
                  }}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Todo Cliente
              </label>
              <label className={`${labelClass} left-[9px] top-[38px]`}>Cliente</label>
              <input
                aria-label="Cliente"
                value={client}
                readOnly
                className="absolute left-[61px] top-[35px] h-[20px] w-[303px] border border-[#d5d5d5] bg-white px-[4px] font-bold uppercase text-gray-700"
              />
              <button
                type="button"
                aria-label="Buscar cliente"
                className="absolute left-[370px] top-[35px] flex h-[22px] w-[25px] items-center justify-center rounded-[2px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed]"
              >
                <Search className="h-[15px] w-[15px] text-[#234878]" />
              </button>
            </fieldset>

            <button
              type="button"
              className="absolute left-[146px] top-[172px] flex h-[27px] w-[74px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
            >
              <CheckCircle2 className="h-[16px] w-[16px] fill-green-600 text-white" />
              Aceptar
            </button>
            <button
              type="button"
              className="absolute left-[228px] top-[172px] flex h-[27px] w-[80px] items-center justify-center gap-[3px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
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
