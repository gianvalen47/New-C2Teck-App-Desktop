import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

export function ReporteVacacionesList() {
  return <ReporteVacaciones />;
}

export function ReporteVacaciones() {
  const [collaborator, setCollaborator] = useState("(Todos)");
  const [area, setArea] = useState("");
  const [costCenter, setCostCenter] = useState("");
  const [classCode, setClassCode] = useState("");
  const [status, setStatus] = useState("");
  const [period, setPeriod] = useState("");
  const [month, setMonth] = useState("");
  const [reportType, setReportType] = useState<"totals" | "details">("totals");
  const [personnelCurrent, setPersonnelCurrent] = useState(true);
  const [exportMode, setExportMode] = useState<"screen" | "excel">("screen");

  return (
    <WindowShell title="Reporte de Vacaciones">
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[295px] w-[592px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[10px] top-[5px] h-[245px] w-[574px] border border-[#7799c5] px-0">
            <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
              Datos de Reporte
            </legend>

            <fieldset className="absolute left-[75px] top-[22px] h-[57px] w-[414px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Buscar Persona
              </legend>
              <label className="absolute left-[144px] top-[12px] flex items-center gap-[5px] whitespace-nowrap font-bold text-gray-400">
                <input
                  type="checkbox"
                  checked
                  disabled
                  className="m-0 h-[13px] w-[13px] accent-[#1671c5]"
                />
                Todos los Colaboradores
              </label>
              <label className="absolute left-[10px] top-[32px] whitespace-nowrap font-bold">
                Colaborador
              </label>
              <input
                aria-label="Colaborador"
                readOnly
                value={collaborator}
                className="absolute left-[91px] top-[31px] h-[20px] w-[285px] border border-[#b5b5b5] bg-[#f2f2f2] px-[4px] text-[12px] font-bold text-gray-700"
              />
              <button
                type="button"
                aria-label="Buscar colaborador"
                onClick={() => setCollaborator("(Todos)")}
                className="absolute left-[377px] top-[29px] flex h-[22px] w-[25px] items-center justify-center rounded-[2px] border border-[#a5a5a5] bg-gradient-to-b from-white to-[#e8e8e8]"
              >
                <Search className="h-[15px] w-[15px] text-[#234878]" />
              </button>
            </fieldset>

            <label className="absolute left-[16px] top-[89px] whitespace-nowrap font-bold">
              Área
            </label>
            <select
              aria-label="Área"
              value={area}
              onChange={(event) => setArea(event.target.value)}
              className="absolute left-[50px] top-[89px] h-[20px] w-[122px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option value="">(Todos)</option>
            </select>
            <label className="absolute left-[183px] top-[89px] whitespace-nowrap font-bold">
              Centro Costo
            </label>
            <select
              aria-label="Centro Costo"
              value={costCenter}
              onChange={(event) => setCostCenter(event.target.value)}
              className="absolute left-[264px] top-[89px] h-[20px] w-[205px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option value="">(Todos)</option>
            </select>

            <label className="absolute left-[11px] top-[120px] whitespace-nowrap font-bold">
              Clase
            </label>
            <select
              aria-label="Clase"
              value={classCode}
              onChange={(event) => setClassCode(event.target.value)}
              className="absolute left-[50px] top-[120px] h-[20px] w-[100px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option value="">(Todos)</option>
            </select>
            <label className="absolute left-[161px] top-[120px] whitespace-nowrap font-bold">
              Estado
            </label>
            <select
              aria-label="Estado"
              value={status}
              onChange={(event) => setStatus(event.target.value)}
              className="absolute left-[198px] top-[120px] h-[20px] w-[85px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option value="">(Todos)</option>
            </select>
            <label className="absolute left-[309px] top-[120px] whitespace-nowrap font-bold">
              Periodo
            </label>
            <select
              aria-label="Periodo"
              value={period}
              onChange={(event) => setPeriod(event.target.value)}
              className="absolute left-[361px] top-[120px] h-[20px] w-[70px] border border-[#7799c5] bg-white px-[3px] text-center text-[12px] font-bold"
            >
              <option value="">(Todos)</option>
            </select>
            <label className="absolute left-[438px] top-[120px] whitespace-nowrap font-bold">
              Mes
            </label>
            <select
              aria-label="Mes"
              value={month}
              onChange={(event) => setMonth(event.target.value)}
              className="absolute left-[470px] top-[120px] h-[20px] w-[89px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option value="">(Todos)</option>
            </select>

            <fieldset className="absolute left-[19px] top-[146px] h-[37px] w-[281px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Tipo
              </legend>
              <label className="absolute left-[61px] top-[13px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="vacation-report-type"
                  checked={reportType === "totals"}
                  onChange={() => setReportType("totals")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Totales
              </label>
              <label className="absolute left-[175px] top-[13px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="vacation-report-type"
                  checked={reportType === "details"}
                  onChange={() => setReportType("details")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Detalles
              </label>
            </fieldset>

            <label className="absolute left-[346px] top-[160px] flex items-center gap-[4px] whitespace-nowrap font-bold">
              <input
                type="checkbox"
                checked={personnelCurrent}
                onChange={(event) => setPersonnelCurrent(event.target.checked)}
                className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
              />
              Personal Vigente
            </label>

            <fieldset className="absolute left-[167px] top-[191px] h-[40px] w-[238px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Exportar
              </legend>
              <label className="absolute left-[54px] top-[13px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="vacation-export-mode"
                  checked={exportMode === "screen"}
                  onChange={() => setExportMode("screen")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Pantalla
              </label>
              <label className="absolute left-[136px] top-[13px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="vacation-export-mode"
                  checked={exportMode === "excel"}
                  onChange={() => setExportMode("excel")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Excel
              </label>
            </fieldset>
          </fieldset>

          <button
            type="button"
            className="absolute left-[207px] top-[259px] flex h-[25px] w-[76px] items-center justify-center gap-[4px] rounded-[3px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7] text-[12px] font-bold hover:to-[#dce8f5]"
          >
            <CheckCircle2 className="h-[17px] w-[17px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[289px] top-[259px] flex h-[25px] w-[80px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[16px] w-[16px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
