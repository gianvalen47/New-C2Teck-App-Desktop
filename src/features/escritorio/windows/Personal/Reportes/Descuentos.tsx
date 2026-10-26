import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

export function ReporteDescuentosList() {
  return <ReporteDescuentos />;
}

export function ReporteDescuentos() {
  const [startDate, setStartDate] = useState("2026-10-25");
  const [endDate, setEndDate] = useState("2026-10-25");
  const [area, setArea] = useState("(Todos)");
  const [costCenter, setCostCenter] = useState("(Todos)");
  const [classCode, setClassCode] = useState("(Todos)");
  const [category, setCategory] = useState("(Todos)");

  return (
    <WindowShell title="Reporte de Descuentos">
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[222px] w-[479px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[8px] top-[4px] h-[180px] w-[463px] border border-[#7799c5] px-0">
            <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
              Datos de Reporte
            </legend>

            <label className="absolute left-[65px] top-[22px] whitespace-nowrap font-bold">
              Fechas&nbsp;&nbsp; Del :
            </label>
            <input
              aria-label="Fecha desde"
              type="date"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className="absolute left-[162px] top-[19px] h-[20px] w-[97px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />
            <label className="absolute left-[276px] top-[22px] whitespace-nowrap font-bold">
              Al :
            </label>
            <input
              aria-label="Fecha hasta"
              type="date"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className="absolute left-[308px] top-[19px] h-[20px] w-[94px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />

            <fieldset className="absolute left-[31px] top-[46px] h-[57px] w-[404px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Buscar Persona
              </legend>
              <label className="absolute left-[10px] top-[34px] whitespace-nowrap font-bold">
                Colaborador
              </label>
              <input
                aria-label="Colaborador"
                value="(Todos)"
                readOnly
                className="absolute left-[91px] top-[31px] h-[20px] w-[278px] border border-[#7799c5] bg-white px-[4px] font-bold text-gray-600"
              />
              <button
                type="button"
                aria-label="Buscar colaborador"
                className="absolute left-[371px] top-[29px] flex h-[22px] w-[25px] items-center justify-center rounded-[2px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7]"
              >
                <Search className="h-[15px] w-[15px] text-[#234878]" />
              </button>
              <label className="absolute left-[134px] top-[12px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="checkbox"
                  checked
                  disabled
                  readOnly
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Todos los Colaboradores
              </label>
            </fieldset>

            <label className="absolute left-[15px] top-[117px] whitespace-nowrap font-bold">
              Área
            </label>
            <select
              aria-label="Área"
              value={area}
              onChange={(event) => setArea(event.target.value)}
              className="absolute left-[54px] top-[114px] h-[20px] w-[114px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>
            <label className="absolute left-[182px] top-[117px] whitespace-nowrap font-bold">
              Centro Costo
            </label>
            <select
              aria-label="Centro Costo"
              value={costCenter}
              onChange={(event) => setCostCenter(event.target.value)}
              className="absolute left-[263px] top-[114px] h-[20px] w-[189px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>

            <label className="absolute left-[10px] top-[152px] whitespace-nowrap font-bold">
              Clase
            </label>
            <select
              aria-label="Clase"
              value={classCode}
              onChange={(event) => setClassCode(event.target.value)}
              className="absolute left-[54px] top-[148px] h-[20px] w-[105px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>
            <label className="absolute left-[212px] top-[152px] whitespace-nowrap font-bold">
              Rubro
            </label>
            <select
              aria-label="Rubro"
              value={category}
              onChange={(event) => setCategory(event.target.value)}
              className="absolute left-[263px] top-[148px] h-[20px] w-[189px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>
          </fieldset>

          <button
            type="button"
            className="absolute left-[160px] top-[191px] flex h-[25px] w-[76px] items-center justify-center gap-[4px] rounded-[3px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7] text-[12px] font-bold hover:to-[#dce8f5]"
          >
            <CheckCircle2 className="h-[17px] w-[17px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[242px] top-[191px] flex h-[25px] w-[80px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[16px] w-[16px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
