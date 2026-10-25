import { useState } from "react";
import { Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function ReporteSolicitudGarantiaForm({ title }: { title: string }) {
  const today = new Date();
  const [reportType, setReportType] = useState<"gerencial" | "detallado">("gerencial");
  const [startDate, setStartDate] = useState(
    `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, "0")}-01`,
  );
  const [endDate, setEndDate] = useState(
    `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, "0")}-${String(today.getDate()).padStart(2, "0")}`,
  );
  const [allClients, setAllClients] = useState(true);
  const [client, setClient] = useState("(Todos)");
  const [supervisor, setSupervisor] = useState("");
  const [status, setStatus] = useState("");
  const [manufacturer, setManufacturer] = useState("");
  const [application, setApplication] = useState("");
  const [creditState, setCreditState] = useState("");
  const [series, setSeries] = useState("");
  const [claimNumber, setClaimNumber] = useState("");
  const [correctionDescription, setCorrectionDescription] = useState("");
  const [primaryPartCode, setPrimaryPartCode] = useState("");
  const detailed = reportType === "detallado";

  return (
    <WindowShell title={title}>
      <div className="mx-auto flex h-full w-full max-w-[640px] flex-col overflow-auto bg-[#F3F3F3] p-3 text-[12px] text-slate-900">
        <div className="flex flex-1 flex-col gap-3 border border-slate-300 px-4 py-3">
          <fieldset className="mx-auto flex w-[230px] items-center justify-center gap-6 rounded-sm border border-blue-400 px-3 pb-1 pt-0.5">
            <legend className="px-1 font-semibold text-blue-800">Tipo</legend>
            <label className="flex cursor-pointer items-center gap-1 font-semibold">
              <input
                type="radio"
                name="solicitud-garantia-tipo"
                checked={reportType === "gerencial"}
                onChange={() => setReportType("gerencial")}
              />
              Gerencial
            </label>
            <label className="flex cursor-pointer items-center gap-1 font-semibold">
              <input
                type="radio"
                name="solicitud-garantia-tipo"
                checked={detailed}
                onChange={() => setReportType("detallado")}
              />
              Detallado
            </label>
          </fieldset>

          <div className="flex items-center justify-center gap-7">
            <label className="flex items-center gap-2 whitespace-nowrap font-bold">
              Fechas&nbsp; Del :
              <input
                type="date"
                aria-label="Fecha inicial"
                value={startDate}
                onChange={(event) => setStartDate(event.target.value)}
                className="h-6 w-[112px] rounded-sm border border-slate-400 bg-white px-1 font-semibold"
              />
            </label>
            <label className="flex items-center gap-2 whitespace-nowrap font-bold">
              Al :
              <input
                type="date"
                aria-label="Fecha final"
                value={endDate}
                onChange={(event) => setEndDate(event.target.value)}
                className="h-6 w-[112px] rounded-sm border border-slate-400 bg-white px-1 font-semibold"
              />
            </label>
          </div>

          <fieldset className="rounded-sm border border-blue-400 px-3 pb-2 pt-1">
            <legend className="px-1 font-semibold text-blue-800">Buscar Cliente</legend>
            <label className="flex cursor-pointer items-center justify-center gap-1 font-semibold text-slate-600">
              <input
                type="checkbox"
                checked={allClients}
                onChange={(event) => {
                  setAllClients(event.target.checked);
                  if (event.target.checked) setClient("(Todos)");
                  else setClient("");
                }}
              />
              Todo Cliente
            </label>
            <div className="mt-1 grid grid-cols-[auto_1fr_auto] items-center gap-2">
              <label htmlFor="solicitud-garantia-cliente" className="whitespace-nowrap font-semibold">
                Cliente :
              </label>
              <input
                id="solicitud-garantia-cliente"
                value={client}
                disabled={allClients}
                onChange={(event) => {
                  setClient(event.target.value);
                  if (event.target.value !== "(Todos)") setAllClients(false);
                }}
                className="h-6 min-w-0 rounded-sm border border-slate-400 bg-white px-1 disabled:bg-slate-100"
              />
              <button
                type="button"
                title="Buscar Cliente"
                aria-label="Buscar Cliente"
                onClick={() => {
                  setAllClients(false);
                  setClient("");
                  document.getElementById("solicitud-garantia-cliente")?.focus();
                }}
                className="flex h-6 w-7 items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-blue-800 hover:bg-[#CFE0F4] disabled:opacity-50"
              >
                <Search size={15} />
              </button>
            </div>
          </fieldset>

          <div className="grid grid-cols-2 gap-x-5 gap-y-1 px-1">
            <label className="flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold">
              Supervisor :
              <select
                aria-label="Supervisor"
                value={supervisor}
                onChange={(event) => setSupervisor(event.target.value)}
                className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1"
              >
                <option value="">(Todos)</option>
              </select>
            </label>
            <label className="flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold">
              Estado :
              <select
                aria-label="Estado"
                disabled={!detailed}
                value={status}
                onChange={(event) => setStatus(event.target.value)}
                className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1 disabled:bg-slate-100 disabled:text-slate-500"
              >
                <option value="">(Todos)</option>
              </select>
            </label>
            <label className="flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold">
              Fabricante :
              <select
                aria-label="Fabricante"
                value={manufacturer}
                onChange={(event) => setManufacturer(event.target.value)}
                className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1"
              >
                <option value="">(Todos)</option>
              </select>
            </label>
            <label className="flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold">
              Aplicación :
              <select
                aria-label="Aplicación"
                disabled={!detailed}
                value={application}
                onChange={(event) => setApplication(event.target.value)}
                className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1 disabled:bg-slate-100 disabled:text-slate-500"
              >
                <option value="">(Todos)</option>
              </select>
            </label>
            <label className="flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold">
              Credit State :
              <input
                aria-label="Credit State"
                value={creditState}
                onChange={(event) => setCreditState(event.target.value)}
                className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1"
              />
            </label>
            <label className="flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold">
              Serie :
              <input
                aria-label="Serie"
                disabled={!detailed}
                value={series}
                onChange={(event) => setSeries(event.target.value)}
                className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1 disabled:bg-slate-100"
              />
              <button
                type="button"
                title="Buscar Serie"
                aria-label="Buscar Serie"
                disabled={!detailed}
                onClick={() => document.querySelector<HTMLInputElement>('input[aria-label="Serie"]')?.focus()}
                className="flex h-6 w-7 shrink-0 items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-blue-800 hover:bg-[#CFE0F4] disabled:opacity-50"
              >
                <Search size={15} />
              </button>
            </label>
            <label className="flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold">
              Num. Claim :
              <input
                aria-label="Num. Claim"
                value={claimNumber}
                onChange={(event) => setClaimNumber(event.target.value)}
                className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1"
              />
            </label>
            <label className="flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold">
              Desc. Corrección :
              <input
                aria-label="Desc. Corrección"
                disabled={!detailed}
                value={correctionDescription}
                onChange={(event) => setCorrectionDescription(event.target.value)}
                className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1 disabled:bg-slate-100"
              />
            </label>
            <span />
            <label className="flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold">
              Cod. Pieza Prim. :
              <input
                aria-label="Cod. Pieza Prim."
                disabled={!detailed}
                value={primaryPartCode}
                onChange={(event) => setPrimaryPartCode(event.target.value)}
                className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1 disabled:bg-slate-100"
              />
            </label>
          </div>

          <div className="mt-auto flex justify-center gap-3 pt-1">
            <button
              type="button"
              className="h-8 min-w-[82px] rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 px-2 font-bold hover:bg-[#CFE0F4]"
            >
              <span aria-hidden="true" className="mr-1 text-emerald-600">✓</span>
              Aceptar
            </button>
            <button
              type="button"
              onClick={() => {
                setReportType("gerencial");
                setAllClients(true);
                setClient("(Todos)");
              }}
              className="h-8 min-w-[82px] rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 px-2 font-bold hover:bg-[#CFE0F4]"
            >
              Cancelar
            </button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}

export function SolicitudGarantia({ title = "Reporte de Solicitud de Garantía" }: { title?: string }) {
  return <SolicitudGarantiaList title={title} />;
}

export function SolicitudGarantiaList({ title = "Reporte de Solicitud de Garantía" }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <ReporteSolicitudGarantiaForm title={title} />
    </div>
  );
}
