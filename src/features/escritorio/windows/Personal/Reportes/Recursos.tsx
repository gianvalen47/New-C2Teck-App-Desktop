import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function getToday() {
  const today = new Date();
  const month = String(today.getMonth() + 1).padStart(2, "0");
  const day = String(today.getDate()).padStart(2, "0");
  return `${today.getFullYear()}-${month}-${day}`;
}

export function ReporteRecursosList() {
  return <ReporteRecursos />;
}

export function ReporteRecursos() {
  const [startDate, setStartDate] = useState(getToday);
  const [endDate, setEndDate] = useState(getToday);
  const [area, setArea] = useState("(Todos)");
  const [costCenter, setCostCenter] = useState("(Todos)");
  const [status, setStatus] = useState("(Todos)");
  const [category, setCategory] = useState("(Todos)");

  return (
    <WindowShell title="Reporte de Asignación de Recursos">
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[284px] w-[545px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[8px] top-[5px] h-[238px] w-[528px] border border-[#7799c5] px-0">
            <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
              Datos de Reporte
            </legend>

            <label className="absolute left-[84px] top-[23px] whitespace-nowrap font-bold">
              Fechas&nbsp;&nbsp; Del :
            </label>
            <input
              aria-label="Fecha desde"
              type="date"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className="absolute left-[181px] top-[20px] h-[20px] w-[97px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />
            <label className="absolute left-[314px] top-[23px] whitespace-nowrap font-bold">
              Al :
            </label>
            <input
              aria-label="Fecha hasta"
              type="date"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className="absolute left-[346px] top-[20px] h-[20px] w-[94px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />

            <fieldset className="absolute left-[26px] top-[48px] h-[57px] w-[481px] border border-[#7799c5] px-0">
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
                className="absolute left-[91px] top-[31px] h-[20px] w-[328px] border border-[#7799c5] bg-white px-[4px] font-bold text-gray-600"
              />
              <button
                type="button"
                aria-label="Buscar colaborador"
                className="absolute left-[422px] top-[29px] flex h-[22px] w-[25px] items-center justify-center rounded-[2px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7]"
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

            <fieldset className="absolute left-[26px] top-[115px] h-[50px] w-[481px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Área Emisor
              </legend>
              <label className="absolute left-[9px] top-[17px] whitespace-nowrap font-bold">
                Área
              </label>
              <select
                aria-label="Área"
                value={area}
                onChange={(event) => setArea(event.target.value)}
                className="absolute left-[48px] top-[19px] h-[20px] w-[126px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
              >
                <option>(Todos)</option>
              </select>
              <label className="absolute left-[193px] top-[22px] whitespace-nowrap font-bold">
                Centro Costo
              </label>
              <select
                aria-label="Centro Costo"
                value={costCenter}
                onChange={(event) => setCostCenter(event.target.value)}
                className="absolute left-[279px] top-[19px] h-[20px] w-[189px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
              >
                <option>(Todos)</option>
              </select>
            </fieldset>

            <label className="absolute left-[22px] top-[178px] whitespace-nowrap font-bold">
              Estado
            </label>
            <select
              aria-label="Estado"
              value={status}
              onChange={(event) => setStatus(event.target.value)}
              className="absolute left-[74px] top-[174px] h-[20px] w-[114px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>
            <label className="absolute left-[258px] top-[178px] whitespace-nowrap font-bold">
              Rubro
            </label>
            <select
              aria-label="Rubro"
              value={category}
              onChange={(event) => setCategory(event.target.value)}
              className="absolute left-[305px] top-[174px] h-[20px] w-[166px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>

            <label className="absolute left-[22px] top-[209px] whitespace-nowrap font-bold">
              Código
            </label>
            <input className="absolute left-[74px] top-[206px] h-[20px] w-[101px] border border-[#7799c5] bg-white px-[4px] uppercase" />
            <label className="absolute left-[195px] top-[209px] whitespace-nowrap font-bold">
              Serie
            </label>
            <input className="absolute left-[232px] top-[206px] h-[20px] w-[111px] border border-[#7799c5] bg-white px-[4px] uppercase" />
            <label className="absolute left-[363px] top-[209px] whitespace-nowrap font-bold">
              # Celular
            </label>
            <input className="absolute left-[423px] top-[206px] h-[20px] w-[84px] border border-[#7799c5] bg-white px-[4px]" />
          </fieldset>

          <button
            type="button"
            className="absolute left-[186px] top-[250px] flex h-[27px] w-[76px] items-center justify-center gap-[4px] rounded-[3px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7] text-[12px] font-bold hover:to-[#dce8f5]"
          >
            <CheckCircle2 className="h-[17px] w-[17px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[268px] top-[250px] flex h-[27px] w-[80px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[16px] w-[16px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
