import { useState } from "react";
import { CheckCircle2, Search, X } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function formatDateInput(date: Date) {
  return `${date.getFullYear()}-${String(date.getMonth() + 1).padStart(2, "0")}-${String(date.getDate()).padStart(2, "0")}`;
}

export function ReporteCronogramaMinaList() {
  return <ReporteCronogramaMina />;
}

export function ReporteCronogramaMina() {
  const today = new Date();
  const [startDate, setStartDate] = useState(
    formatDateInput(new Date(today.getFullYear(), today.getMonth(), 1)),
  );
  const [endDate, setEndDate] = useState(formatDateInput(today));
  const collaborator = "(Todos)";
  const [location, setLocation] = useState("");
  const [type, setType] = useState("");
  const [groupBy, setGroupBy] = useState<"collaborator" | "date">("collaborator");

  return (
    <WindowShell title="Reporte de Cronograma Minas">
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[241px] w-[440px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[8px] top-[4px] h-[197px] w-[424px] border border-[#7799c5] px-0">
            <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
              Datos de Reporte
            </legend>

            <label className="absolute left-[31px] top-[17px] whitespace-nowrap font-bold">
              Fec. Inicio
            </label>
            <input
              aria-label="Fecha de inicio"
              type="date"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className="absolute left-[109px] top-[15px] h-[20px] w-[91px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />
            <label className="absolute left-[216px] top-[17px] whitespace-nowrap font-bold">
              Fec. Final
            </label>
            <input
              aria-label="Fecha final"
              type="date"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className="absolute left-[285px] top-[15px] h-[20px] w-[91px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />

            <fieldset className="absolute left-[11px] top-[48px] h-[57px] w-[404px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Buscar Persona
              </legend>
              <label className="absolute left-[126px] top-[3px] flex items-center gap-[5px] whitespace-nowrap font-bold text-gray-400">
                <input
                  type="checkbox"
                  checked
                  disabled
                  className="m-0 h-[13px] w-[13px] accent-[#1671c5]"
                />
                Todos los Colaboradores
              </label>
              <label className="absolute left-[10px] top-[24px] whitespace-nowrap font-bold">
                Colaborador
              </label>
              <input
                aria-label="Colaborador"
                readOnly
                value={collaborator}
                className="absolute left-[91px] top-[23px] h-[20px] w-[278px] border border-[#b5b5b5] bg-[#f2f2f2] px-[4px] text-[12px] font-bold text-gray-700"
              />
              <button
                type="button"
                aria-label="Buscar colaborador"
                className="absolute left-[371px] top-[21px] flex h-[22px] w-[25px] items-center justify-center rounded-[2px] border border-[#a5a5a5] bg-gradient-to-b from-white to-[#e8e8e8]"
              >
                <Search className="h-[15px] w-[15px] text-[#234878]" />
              </button>
            </fieldset>

            <label className="absolute left-[8px] top-[112px] whitespace-nowrap font-bold">
              Ubicacion
            </label>
            <select
              aria-label="Ubicación"
              value={location}
              onChange={(event) => setLocation(event.target.value)}
              className="absolute left-[70px] top-[112px] h-[20px] w-[107px] border border-[#7799c5] bg-[#0875c9] px-[3px] text-[12px] font-bold text-white"
            >
              <option value="">(Todos)</option>
            </select>
            <label className="absolute left-[203px] top-[112px] whitespace-nowrap font-bold">
              Tipo
            </label>
            <select
              aria-label="Tipo"
              value={type}
              onChange={(event) => setType(event.target.value)}
              className="absolute left-[233px] top-[112px] h-[20px] w-[173px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option value="">(Todos)</option>
            </select>

            <fieldset className="absolute left-[11px] top-[147px] h-[40px] w-[224px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Agrupado X
              </legend>
              <label className="absolute left-[19px] top-[10px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="cronograma-group"
                  checked={groupBy === "collaborator"}
                  onChange={() => setGroupBy("collaborator")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Colaborador
              </label>
              <label className="absolute left-[137px] top-[10px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="cronograma-group"
                  checked={groupBy === "date"}
                  onChange={() => setGroupBy("date")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Fecha
              </label>
            </fieldset>
          </fieldset>

          <button
            type="button"
            className="absolute left-[134px] top-[207px] flex h-[25px] w-[76px] items-center justify-center gap-[4px] rounded-[3px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7] text-[12px] font-bold hover:to-[#dce8f5]"
          >
            <CheckCircle2 className="h-[17px] w-[17px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[216px] top-[207px] flex h-[25px] w-[80px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <X className="h-[16px] w-[16px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
