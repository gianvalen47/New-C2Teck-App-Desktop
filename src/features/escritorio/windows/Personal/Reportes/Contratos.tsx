import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

export function ContratosList() {
  return <Contratos />;
}

export function Contratos() {
  const [reportType, setReportType] = useState<"main" | "dynamic">("main");
  const [area, setArea] = useState("");
  const [costCenter, setCostCenter] = useState("");
  const [classCode, setClassCode] = useState("");
  const [personnelCurrent, setPersonnelCurrent] = useState(true);

  return (
    <WindowShell title="Reporte de Contratos">
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[214px] w-[466px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[7px] top-[4px] h-[173px] w-[453px] border border-[#7799c5] px-0">
            <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
              Datos de Reporte
            </legend>

            <fieldset className="absolute left-[66px] top-[27px] h-[38px] w-[329px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Tipo
              </legend>
              <label className="absolute left-[31px] top-[14px] flex items-center gap-[5px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="contract-report-type"
                  checked={reportType === "main"}
                  onChange={() => setReportType("main")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Reporte Principal
              </label>
              <label className="absolute left-[178px] top-[14px] flex items-center gap-[5px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="contract-report-type"
                  checked={reportType === "dynamic"}
                  onChange={() => setReportType("dynamic")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Reporte Dinámico
              </label>
            </fieldset>

            <label className="absolute left-[13px] top-[85px] whitespace-nowrap font-bold">
              Área
            </label>
            <select
              aria-label="Área"
              value={area}
              onChange={(event) => setArea(event.target.value)}
              className="absolute left-[52px] top-[82px] h-[20px] w-[114px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option value="">(Todos)</option>
            </select>

            <label className="absolute left-[179px] top-[85px] whitespace-nowrap font-bold">
              Centro Costo
            </label>
            <select
              aria-label="Centro Costo"
              value={costCenter}
              onChange={(event) => setCostCenter(event.target.value)}
              className="absolute left-[260px] top-[83px] h-[20px] w-[189px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option value="">(Todos)</option>
            </select>

            <label className="absolute left-[8px] top-[127px] whitespace-nowrap font-bold">
              Clase
            </label>
            <select
              aria-label="Clase"
              value={classCode}
              onChange={(event) => setClassCode(event.target.value)}
              className="absolute left-[52px] top-[124px] h-[20px] w-[105px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option value="">(Todos)</option>
            </select>

            <label className="absolute left-[273px] top-[127px] flex items-center gap-[4px] whitespace-nowrap font-bold">
              <span>Personal Vigente</span>
              <input
                type="checkbox"
                checked={personnelCurrent}
                onChange={(event) => setPersonnelCurrent(event.target.checked)}
                className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
              />
            </label>
          </fieldset>

          <button
            type="button"
            className="absolute left-[147px] top-[185px] flex h-[25px] w-[76px] items-center justify-center gap-[4px] rounded-[3px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7] text-[12px] font-bold hover:to-[#dce8f5]"
          >
            <CheckCircle2 className="h-[17px] w-[17px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[229px] top-[185px] flex h-[25px] w-[80px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[16px] w-[16px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
