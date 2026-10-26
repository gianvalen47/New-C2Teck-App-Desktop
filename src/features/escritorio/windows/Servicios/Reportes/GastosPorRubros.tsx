import { useState } from "react";
import { Brush, CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function formatDate(date: Date) {
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const day = String(date.getDate()).padStart(2, "0");
  return `${date.getFullYear()}-${month}-${day}`;
}

function getStartOfYear() {
  return formatDate(new Date(new Date().getFullYear(), 0, 1));
}

function getToday() {
  return formatDate(new Date());
}

export function GastosPorRubros({ title = "Total x Rubro" }: { title?: string }) {
  return <GastosPorRubrosList title={title} />;
}

export function GastosPorRubrosList({ title = "Total x Rubro" }: { title?: string }) {
  const [startDate, setStartDate] = useState(getStartOfYear);
  const [endDate, setEndDate] = useState(getToday);
  const [location, setLocation] = useState("Todos");
  const [type, setType] = useState("Todos");
  const [rubro, setRubro] = useState("Cable TV");
  const [status, setStatus] = useState("Todos");
  const [allClients, setAllClients] = useState(true);
  const [client, setClient] = useState("");
  const [businessUnit, setBusinessUnit] = useState("Todos");
  const [area, setArea] = useState("Todos");
  const [costCenter, setCostCenter] = useState("Todos");
  const [exportType, setExportType] = useState<"screen" | "excel">("screen");

  const selectClass =
    "absolute h-[20px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold";
  const labelClass = "absolute whitespace-nowrap font-bold";

  return (
    <WindowShell title={title}>
      <div className="flex h-full min-h-0 items-start justify-center overflow-auto bg-[#f0f0f0] p-2">
        <div className="relative h-[364px] w-[531px] shrink-0 bg-[#f0f0f0] font-[Arial,sans-serif] text-[12px] text-gray-900">
          <div className="absolute left-[7px] top-[2px] h-[322px] w-[518px]">
            <div className="relative h-full w-full">
              <fieldset className="absolute left-[44px] top-[17px] h-[53px] w-[422px] border border-[#7799c5] px-0">
                <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                  FECHAS
                </legend>
                <label className={`${labelClass} left-[20px] top-[21px]`}>
                  Fecha Inicio
                </label>
                <input
                  aria-label="Fecha Inicio"
                  type="date"
                  value={startDate}
                  onChange={(event) => setStartDate(event.target.value)}
                  className="absolute left-[111px] top-[19px] h-[20px] w-[92px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
                />
                <label className={`${labelClass} left-[235px] top-[21px]`}>
                  Fecha Fin
                </label>
                <input
                  aria-label="Fecha Fin"
                  type="date"
                  value={endDate}
                  onChange={(event) => setEndDate(event.target.value)}
                  className="absolute left-[311px] top-[19px] h-[20px] w-[92px] border border-[#7799c5] bg-white px-[3px] text-[12px] font-bold"
                />
              </fieldset>

              <label className={`${labelClass} left-[22px] top-[84px]`}>
                Locación
              </label>
              <select
                aria-label="Locación"
                value={location}
                onChange={(event) => setLocation(event.target.value)}
                className={`${selectClass} left-[93px] top-[82px] w-[147px]`}
              >
                <option>Todos</option>
              </select>
              <label className={`${labelClass} left-[312px] top-[84px]`}>Tipo</label>
              <select
                aria-label="Tipo"
                value={type}
                onChange={(event) => setType(event.target.value)}
                className={`${selectClass} left-[353px] top-[82px] w-[99px]`}
              >
                <option>Todos</option>
              </select>
              <label className={`${labelClass} left-[41px] top-[112px]`}>Rubro</label>
              <select
                aria-label="Rubro"
                value={rubro}
                onChange={(event) => setRubro(event.target.value)}
                className={`${selectClass} left-[93px] top-[110px] w-[164px]`}
              >
                <option>Cable TV</option>
              </select>
              <label className={`${labelClass} left-[296px] top-[112px]`}>
                Estado
              </label>
              <select
                aria-label="Estado"
                value={status}
                onChange={(event) => setStatus(event.target.value)}
                className={`${selectClass} left-[353px] top-[110px] w-[117px]`}
              >
                <option>Todos</option>
              </select>

              <fieldset className="absolute left-[44px] top-[135px] h-[57px] w-[422px] border border-[#7799c5] px-0">
                <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                  Buscar Cliente
                </legend>
                <label className={`${labelClass} left-[200px] top-[14px]`}>
                  <input
                    type="checkbox"
                    aria-label="Todos los clientes"
                    checked={allClients}
                    onChange={(event) => {
                      const checked = event.target.checked;
                      setAllClients(checked);
                      if (checked) setClient("");
                    }}
                    className="absolute left-[-1px] top-[-1px] m-0 h-[14px] w-[14px] accent-[#0875c9]"
                  />
                </label>
                <button
                  type="button"
                  aria-label="Limpiar cliente"
                  disabled={allClients}
                  onClick={() => setClient("")}
                  className="absolute left-[221px] top-[10px] flex h-[18px] w-[24px] items-center justify-center text-[#a97816] disabled:opacity-80"
                >
                  <Brush className="h-[17px] w-[17px]" />
                </button>
                <label className={`${labelClass} left-[22px] top-[32px]`}>
                  Cliente
                </label>
                <input
                  aria-label="Cliente"
                  value={allClients ? "" : client}
                  readOnly
                  className="absolute left-[80px] top-[31px] h-[20px] w-[293px] border border-[#d5d5d5] bg-white px-[4px] font-bold"
                />
                <button
                  type="button"
                  aria-label="Buscar cliente"
                  disabled={allClients}
                  className="absolute left-[375px] top-[29px] flex h-[22px] w-[24px] items-center justify-center rounded-[2px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] disabled:opacity-70"
                >
                  <Search className="h-[15px] w-[15px] text-[#234878]" />
                </button>
              </fieldset>

              <fieldset className="absolute left-[8px] top-[199px] h-[68px] w-[500px] border border-[#7799c5] px-0">
                <label className={`${labelClass} left-[6px] top-[15px]`}>
                  Unidad Negocio
                </label>
                <select
                  aria-label="Unidad Negocio"
                  value={businessUnit}
                  onChange={(event) => setBusinessUnit(event.target.value)}
                  className={`${selectClass} left-[122px] top-[13px] w-[170px]`}
                >
                  <option>Todos</option>
                </select>
                <label className={`${labelClass} left-[310px] top-[15px]`}>Area</label>
                <select
                  aria-label="Área"
                  value={area}
                  onChange={(event) => setArea(event.target.value)}
                  className={`${selectClass} left-[352px] top-[13px] w-[142px]`}
                >
                  <option>Todos</option>
                </select>
                <label className={`${labelClass} left-[7px] top-[44px]`}>
                  Centro de Costo
                </label>
                <select
                  aria-label="Centro de Costo"
                  value={costCenter}
                  onChange={(event) => setCostCenter(event.target.value)}
                  className={`${selectClass} left-[122px] top-[42px] w-[192px]`}
                >
                  <option>Todos</option>
                </select>
              </fieldset>

              <fieldset className="absolute left-[130px] top-[274px] h-[40px] w-[238px] border border-[#7799c5] px-0">
                <legend className="ml-[5px] px-[3px] text-[12px] font-bold text-[#164b91]">
                  Exportar
                </legend>
                <label className={`${labelClass} left-[54px] top-[13px] flex items-center gap-[4px]`}>
                  <input
                    type="radio"
                    name="total-rubro-export"
                    checked={exportType === "screen"}
                    onChange={() => setExportType("screen")}
                    className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                  />
                  Pantalla
                </label>
                <label className={`${labelClass} left-[136px] top-[13px] flex items-center gap-[4px]`}>
                  <input
                    type="radio"
                    name="total-rubro-export"
                    checked={exportType === "excel"}
                    onChange={() => setExportType("excel")}
                    className="m-0 h-[13px] w-[13px] accent-[#0875c9]"
                  />
                  Excel
                </label>
              </fieldset>
            </div>
          </div>

          <button
            type="button"
            className="absolute left-[188px] top-[330px] flex h-[27px] w-[80px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <CheckCircle2 className="h-[17px] w-[17px] fill-green-600 text-white" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[274px] top-[330px] flex h-[27px] w-[80px] items-center justify-center gap-[4px] rounded-[3px] border border-[#b0b0b0] bg-gradient-to-b from-white to-[#ededed] text-[12px] font-bold hover:to-[#e3e3e3]"
          >
            <LogOut className="h-[16px] w-[16px] text-gray-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}
