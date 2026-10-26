import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function formatDateInput(date: Date) {
  return `${date.getFullYear()}-${String(date.getMonth() + 1).padStart(2, "0")}-${String(date.getDate()).padStart(2, "0")}`;
}

export function CapacitacionesList() {
  return <Capacitaciones />;
}

export function Capacitaciones() {
  const today = new Date();
  const [startDate, setStartDate] = useState(
    formatDateInput(new Date(today.getFullYear(), today.getMonth(), 1)),
  );
  const [endDate, setEndDate] = useState(formatDateInput(today));
  const collaborator = "(Todos)";
  const provider = "(Todos)";
  const [area, setArea] = useState("");
  const [costCenter, setCostCenter] = useState("");
  const [position, setPosition] = useState("");
  const [trainingType, setTrainingType] = useState("");
  const [course, setCourse] = useState("");
  const [exportMode, setExportMode] = useState<"screen" | "excel">("screen");

  return (
    <WindowShell title="Reporte de Capacitación">
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[352px] w-[521px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[8px] top-[4px] h-[258px] w-[501px] border border-[#7799c5] px-0">
            <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
              Datos de Reporte
            </legend>

            <label className="absolute left-[70px] top-[17px] whitespace-nowrap font-bold">
              Fechas&nbsp;&nbsp; Del :
            </label>
            <input
              aria-label="Fecha de inicio"
              type="date"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className="absolute left-[167px] top-[15px] h-[20px] w-[97px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />
            <label className="absolute left-[281px] top-[17px] whitespace-nowrap font-bold">
              Al :
            </label>
            <input
              aria-label="Fecha final"
              type="date"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className="absolute left-[313px] top-[15px] h-[20px] w-[94px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />

            <fieldset className="absolute left-[27px] top-[46px] h-[54px] w-[448px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Buscar Persona
              </legend>
              <label className="absolute left-[133px] top-[1px] flex items-center gap-[5px] whitespace-nowrap font-bold text-gray-400">
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
                className="absolute left-[91px] top-[22px] h-[20px] w-[298px] border border-[#b5b5b5] bg-[#f2f2f2] px-[4px] text-[12px] font-bold text-gray-700"
              />
              <button
                type="button"
                aria-label="Buscar colaborador"
                className="absolute left-[400px] top-[20px] flex h-[22px] w-[25px] items-center justify-center rounded-[2px] border border-[#a5a5a5] bg-gradient-to-b from-white to-[#e8e8e8]"
              >
                <Search className="h-[15px] w-[15px] text-[#234878]" />
              </button>
            </fieldset>

            <fieldset className="absolute left-[27px] top-[107px] h-[54px] w-[448px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Buscar Proveedor
              </legend>
              <label className="absolute left-[138px] top-[1px] flex items-center gap-[5px] whitespace-nowrap font-bold text-gray-400">
                <input
                  type="checkbox"
                  checked
                  disabled
                  className="m-0 h-[13px] w-[13px] accent-[#1671c5]"
                />
                Todos los Proveedores
              </label>
              <label className="absolute left-[19px] top-[24px] whitespace-nowrap font-bold">
                Proveedor
              </label>
              <input
                aria-label="Proveedor"
                readOnly
                value={provider}
                className="absolute left-[91px] top-[22px] h-[20px] w-[298px] border border-[#b5b5b5] bg-[#f2f2f2] px-[4px] text-[12px] font-bold text-gray-700"
              />
              <button
                type="button"
                aria-label="Buscar proveedor"
                className="absolute left-[400px] top-[20px] flex h-[22px] w-[25px] items-center justify-center rounded-[2px] border border-[#a5a5a5] bg-gradient-to-b from-white to-[#e8e8e8]"
              >
                <Search className="h-[15px] w-[15px] text-[#234878]" />
              </button>
            </fieldset>

            <label className="absolute left-[8px] top-[166px] whitespace-nowrap font-bold">
              Área
            </label>
            <select
              aria-label="Área"
              value={area}
              onChange={(event) => setArea(event.target.value)}
              className="absolute left-[47px] top-[166px] h-[20px] w-[124px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option value="">(Todos)</option>
            </select>
            <label className="absolute left-[212px] top-[166px] whitespace-nowrap font-bold">
              Centro Costo
            </label>
            <select
              aria-label="Centro Costo"
              value={costCenter}
              onChange={(event) => setCostCenter(event.target.value)}
              className="absolute left-[298px] top-[167px] h-[20px] w-[184px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option value="">(Todos)</option>
            </select>

            <label className="absolute left-[9px] top-[195px] whitespace-nowrap font-bold">
              Cargo
            </label>
            <select
              aria-label="Cargo"
              value={position}
              onChange={(event) => setPosition(event.target.value)}
              className="absolute left-[47px] top-[195px] h-[20px] w-[260px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option value="">(Todos)</option>
            </select>
            <label className="absolute left-[353px] top-[195px] whitespace-nowrap font-bold">
              Tipo
            </label>
            <select
              aria-label="Tipo de capacitación"
              value={trainingType}
              onChange={(event) => setTrainingType(event.target.value)}
              className="absolute left-[391px] top-[195px] h-[20px] w-[91px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option value="">(Todos)</option>
            </select>

            <label className="absolute left-[2px] top-[225px] whitespace-nowrap font-bold">
              Curso
            </label>
            <input
              aria-label="Curso"
              value={course}
              onChange={(event) => setCourse(event.target.value.toUpperCase())}
              className="absolute left-[47px] top-[225px] h-[20px] w-[435px] border border-[#b5b5b5] bg-white px-[4px] text-[12px] font-bold uppercase"
            />
          </fieldset>

          <fieldset className="absolute left-[142px] top-[267px] h-[40px] w-[238px] border border-[#7799c5] px-0">
            <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
              Exportar
            </legend>
            <label className="absolute left-[38px] top-[13px] flex items-center gap-[4px] whitespace-nowrap font-bold">
              <input
                type="radio"
                name="training-export-mode"
                checked={exportMode === "screen"}
                onChange={() => setExportMode("screen")}
                className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
              />
              Pantalla
            </label>
            <label className="absolute left-[143px] top-[13px] flex items-center gap-[4px] whitespace-nowrap font-bold">
              <input
                type="radio"
                name="training-export-mode"
                checked={exportMode === "excel"}
                onChange={() => setExportMode("excel")}
                className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
              />
              Excel
            </label>
          </fieldset>

          <button
            type="button"
            className="absolute left-[174px] top-[317px] flex h-[25px] w-[76px] items-center justify-center gap-[4px] rounded-[3px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7] text-[12px] font-bold hover:to-[#dce8f5]"
          >
            <CheckCircle2 className="h-[17px] w-[17px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[256px] top-[317px] flex h-[25px] w-[80px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[16px] w-[16px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
