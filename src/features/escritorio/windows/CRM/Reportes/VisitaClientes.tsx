import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

const labelClass = "absolute whitespace-nowrap text-[12px] font-bold leading-[16px] text-slate-900";
const inputClass =
  "absolute h-[21px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800";
const searchButtonClass =
  "absolute flex h-[22px] w-[25px] items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-blue-800 hover:bg-[#CFE0F4]";

function ClientVisitReportForm({ title }: { title: string }) {
  const today = new Date();
  const month = String(today.getMonth() + 1).padStart(2, "0");
  const day = String(today.getDate()).padStart(2, "0");
  const [dateFrom, setDateFrom] = useState(`${today.getFullYear()}-${month}-01`);
  const [dateTo, setDateTo] = useState(`${today.getFullYear()}-${month}-${day}`);
  const [allClients, setAllClients] = useState(true);
  const [client, setClient] = useState("(Todos)");
  const [allCollaborators, setAllCollaborators] = useState(true);
  const [collaborator, setCollaborator] = useState("RIOS ROSALES CARLOS");
  const [businessUnit, setBusinessUnit] = useState("COMERCIAL");
  const [status, setStatus] = useState("(Todos)");
  const [visitType, setVisitType] = useState("(Todos)");

  return (
    <WindowShell title={title}>
      <div className="h-full min-h-0 overflow-auto bg-[#F3F3F3]">
        <div className="relative h-[276px] w-[515px] min-w-[515px] text-[12px] text-slate-900">
          <fieldset className="absolute left-[7px] top-[3px] h-[235px] w-[499px] rounded-sm border border-blue-400">
            <legend className="px-1 font-bold text-blue-800">Datos de Reporte</legend>

            <label
              className={`${labelClass} left-[79px] top-[22px]`}
              htmlFor="client-visit-date-from"
            >
              Fechas&nbsp;&nbsp; Del :
            </label>
            <input
              id="client-visit-date-from"
              aria-label="Fecha desde"
              type="date"
              value={dateFrom}
              onChange={(event) => setDateFrom(event.target.value)}
              className="absolute left-[176px] top-[19px] h-[21px] w-[97px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
            />
            <label
              className={`${labelClass} left-[296px] top-[22px]`}
              htmlFor="client-visit-date-to"
            >
              Al :
            </label>
            <input
              id="client-visit-date-to"
              aria-label="Fecha hasta"
              type="date"
              value={dateTo}
              onChange={(event) => setDateTo(event.target.value)}
              className="absolute left-[328px] top-[19px] h-[21px] w-[94px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
            />

            <fieldset className="absolute left-[9px] top-[44px] h-[63px] w-[481px] rounded-sm border border-blue-400">
              <legend className="px-1 font-bold text-blue-800">Buscar Cliente</legend>
              <label className="absolute left-[193px] top-[15px] flex cursor-default items-center gap-1 font-bold text-slate-400">
                <input
                  aria-label="Todos los Clientes"
                  type="checkbox"
                  checked={allClients}
                  disabled
                  onChange={(event) => setAllClients(event.target.checked)}
                  className="m-0 h-[13px] w-[13px] accent-[#0067b8]"
                />
                Todos los Clientes
              </label>
              <label
                className={`${labelClass} left-[19px] top-[37px]`}
                htmlFor="client-visit-client"
              >
                Cliente
              </label>
              <input
                id="client-visit-client"
                aria-label="Cliente"
                value={client}
                readOnly={allClients}
                onChange={(event) => setClient(event.target.value)}
                className={`${inputClass} left-[100px] top-[34px] w-[313px]`}
              />
              <button
                type="button"
                title="Buscar Cliente"
                aria-label="Buscar Cliente"
                onClick={() => {
                  setAllClients(false);
                  setClient("");
                }}
                className={`${searchButtonClass} left-[417px] top-[33px]`}
              >
                <Search size={15} />
              </button>
            </fieldset>

            <fieldset className="absolute left-[9px] top-[112px] h-[57px] w-[481px] rounded-sm border border-blue-400">
              <legend className="px-1 font-bold text-blue-800">Buscar Persona</legend>
              <label className="absolute left-[177px] top-[12px] flex cursor-pointer items-center gap-1 font-bold">
                <input
                  aria-label="Todos los Colaboradores"
                  type="checkbox"
                  checked={allCollaborators}
                  onChange={(event) => {
                    setAllCollaborators(event.target.checked);
                    setCollaborator(event.target.checked ? "(Todos)" : "RIOS ROSALES CARLOS");
                  }}
                  className="m-0 h-[13px] w-[13px] accent-[#0067b8]"
                />
                Todos los Colaboradores
              </label>
              <label
                className={`${labelClass} left-[19px] top-[34px]`}
                htmlFor="client-visit-collaborator"
              >
                Colaborador
              </label>
              <input
                id="client-visit-collaborator"
                aria-label="Colaborador"
                value={collaborator}
                readOnly={allCollaborators}
                onChange={(event) => setCollaborator(event.target.value)}
                className={`${inputClass} left-[100px] top-[31px] w-[313px]`}
              />
              <button
                type="button"
                title="Buscar Colaborador"
                aria-label="Buscar Colaborador"
                onClick={() => {
                  setAllCollaborators(false);
                  setCollaborator("");
                }}
                className={`${searchButtonClass} left-[416px] top-[29px]`}
              >
                <Search size={15} />
              </button>
            </fieldset>

            <label
              className={`${labelClass} left-[16px] top-[181px]`}
              htmlFor="client-visit-business-unit"
            >
              Unidad Negocio
            </label>
            <select
              id="client-visit-business-unit"
              aria-label="Unidad Negocio"
              value={businessUnit}
              onChange={(event) => setBusinessUnit(event.target.value)}
              className="absolute left-[116px] top-[177px] h-[21px] w-[189px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
            >
              <option>COMERCIAL</option>
            </select>

            <label
              className={`${labelClass} left-[329px] top-[180px]`}
              htmlFor="client-visit-status"
            >
              Estado
            </label>
            <select
              id="client-visit-status"
              aria-label="Estado"
              value={status}
              onChange={(event) => setStatus(event.target.value)}
              className="absolute left-[377px] top-[177px] h-[21px] w-[113px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
            >
              <option>(Todos)</option>
            </select>

            <label className={`${labelClass} left-[47px] top-[210px]`} htmlFor="client-visit-type">
              Tipo Visita
            </label>
            <select
              id="client-visit-type"
              aria-label="Tipo Visita"
              value={visitType}
              onChange={(event) => setVisitType(event.target.value)}
              className="absolute left-[116px] top-[206px] h-[21px] w-[137px] rounded-sm border border-slate-400 bg-white px-1 text-[12px] font-semibold text-slate-800"
            >
              <option>(Todos)</option>
            </select>
          </fieldset>

          <button
            type="button"
            className="absolute left-[178px] top-[242px] flex h-[28px] w-[76px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold hover:bg-[#CFE0F4]"
          >
            <CheckCircle2 aria-hidden="true" size={16} className="text-green-600" />
            Aceptar
          </button>
          <button
            type="button"
            className="absolute left-[260px] top-[242px] flex h-[28px] w-[80px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-white text-[12px] font-bold hover:bg-[#CFE0F4]"
          >
            <LogOut aria-hidden="true" size={15} className="text-blue-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}

export function ReporteVisitaClientes({
  title = "Reporte de Visita de Cliente",
}: {
  title?: string;
}) {
  return <ReporteVisitaClientesList title={title} />;
}

export function ReporteVisitaClientesList({
  title = "Reporte de Visita de Cliente",
}: {
  title?: string;
}) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <ClientVisitReportForm title={title} />
    </div>
  );
}
