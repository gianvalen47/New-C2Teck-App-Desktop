import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function getToday() {
  const today = new Date();
  const month = String(today.getMonth() + 1).padStart(2, "0");
  const day = String(today.getDate()).padStart(2, "0");
  return `${today.getFullYear()}-${month}-${day}`;
}

export function FaltasList() {
  return <Faltas />;
}

export function Faltas() {
  const [startDate, setStartDate] = useState(getToday);
  const [endDate, setEndDate] = useState(getToday);
  const [area, setArea] = useState("(Todos)");
  const [costCenter, setCostCenter] = useState("(Todos)");
  const [classCode, setClassCode] = useState("(Todos)");
  const [reason, setReason] = useState("(Todos)");
  const [authorizedBy, setAuthorizedBy] = useState("(Ninguno)");
  const [reportType, setReportType] = useState("detallado");

  return (
    <WindowShell title="Reporte de Faltas de Personal">
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[301px] w-[487px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <fieldset className="absolute left-[8px] top-[4px] h-[260px] w-[471px] border border-[#7799c5] px-0">
            <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
              Datos de Reporte
            </legend>

            <label className="absolute left-[67px] top-[18px] whitespace-nowrap font-bold">
              Fechas&nbsp;&nbsp; Del :
            </label>
            <input
              aria-label="Fecha desde"
              type="date"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className="absolute left-[164px] top-[15px] h-[20px] w-[97px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />
            <label className="absolute left-[278px] top-[18px] whitespace-nowrap font-bold">
              Al :
            </label>
            <input
              aria-label="Fecha hasta"
              type="date"
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className="absolute left-[310px] top-[15px] h-[20px] w-[94px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            />

            <fieldset className="absolute left-[34px] top-[46px] h-[57px] w-[404px] border border-[#7799c5] px-0">
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
              <label className="absolute left-[134px] top-[12px] flex items-center gap-[4px] whitespace-nowrap font-bold text-gray-400">
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

            <label className="absolute left-[28px] top-[114px] whitespace-nowrap font-bold">
              Área
            </label>
            <select
              aria-label="Área"
              value={area}
              onChange={(event) => setArea(event.target.value)}
              className="absolute left-[64px] top-[111px] h-[20px] w-[114px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>
            <label className="absolute left-[188px] top-[114px] whitespace-nowrap font-bold">
              Centro Costo
            </label>
            <select
              aria-label="Centro Costo"
              value={costCenter}
              onChange={(event) => setCostCenter(event.target.value)}
              className="absolute left-[269px] top-[111px] h-[20px] w-[189px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>

            <label className="absolute left-[23px] top-[148px] whitespace-nowrap font-bold">
              Clase
            </label>
            <select
              aria-label="Clase"
              value={classCode}
              onChange={(event) => setClassCode(event.target.value)}
              className="absolute left-[64px] top-[145px] h-[20px] w-[105px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>
            <label className="absolute left-[218px] top-[148px] whitespace-nowrap font-bold">
              Motivo
            </label>
            <select
              aria-label="Motivo"
              value={reason}
              onChange={(event) => setReason(event.target.value)}
              className="absolute left-[269px] top-[145px] h-[20px] w-[189px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
            >
              <option>(Todos)</option>
            </select>

            <label className="absolute left-[8px] top-[185px] whitespace-nowrap font-bold">
              Autoriza
            </label>
            <select
              aria-label="Autoriza"
              value={authorizedBy}
              onChange={(event) => setAuthorizedBy(event.target.value)}
              className="absolute left-[64px] top-[179px] h-[20px] w-[313px] border border-[#7799c5] bg-white px-[3px] text-center text-[12px] font-bold"
            >
              <option>(Ninguno)</option>
            </select>

            <fieldset className="absolute left-[12px] top-[207px] h-[38px] w-[446px] border border-[#7799c5] px-0">
              <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                Tipo
              </legend>
              <label className="absolute left-[42px] top-[12px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="absence-report-type"
                  checked={reportType === "detallado"}
                  onChange={() => setReportType("detallado")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Detallado
              </label>
              <label className="absolute left-[165px] top-[12px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="absence-report-type"
                  checked={reportType === "status"}
                  onChange={() => setReportType("status")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Status
              </label>
              <label className="absolute left-[270px] top-[11px] flex items-center gap-[4px] whitespace-nowrap font-bold">
                <input
                  type="radio"
                  name="absence-report-type"
                  checked={reportType === "deduct"}
                  onChange={() => setReportType("deduct")}
                  className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                />
                Permisos a Descontar
              </label>
            </fieldset>
          </fieldset>

          <button
            type="button"
            className="absolute left-[161px] top-[270px] flex h-[25px] w-[76px] items-center justify-center gap-[4px] rounded-[3px] border border-[#85a9d1] bg-gradient-to-b from-white to-[#e7eef7] text-[12px] font-bold hover:to-[#dce8f5]"
          >
            <CheckCircle2 className="h-[17px] w-[17px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[243px] top-[270px] flex h-[25px] w-[80px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[16px] w-[16px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
