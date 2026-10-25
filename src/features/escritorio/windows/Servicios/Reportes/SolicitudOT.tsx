import { useState } from "react";
import { Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function ReporteSolicitudOrdenTrabajo() {
  const today = new Date();
  const [startDate, setStartDate] = useState(
    `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, "0")}-01`,
  );
  const [endDate, setEndDate] = useState(
    `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, "0")}-${String(today.getDate()).padStart(2, "0")}`,
  );
  const [allClients, setAllClients] = useState(true);
  const [client, setClient] = useState("(Todos)");
  const [area, setArea] = useState("");
  const [type, setType] = useState("");
  const [status, setStatus] = useState("");
  const [vendor, setVendor] = useState("");
  const [location, setLocation] = useState("");
  const [exportMode, setExportMode] = useState<"pantalla" | "excel">("pantalla");

  return (
    <WindowShell title="Reporte de Solicitud de OT">
      <div className="mx-auto flex h-full w-full max-w-[640px] flex-col overflow-auto bg-[#F3F3F3] p-3 text-[12px] text-slate-900">
        <div className="flex flex-1 flex-col gap-3 border border-slate-300 px-3 py-4">
          <div className="flex items-center justify-center gap-6">
            <label className="flex items-center justify-center gap-2 whitespace-nowrap font-bold">
              Fechas&nbsp; Del :
              <input
                type="date"
                aria-label="Fecha inicial"
                value={startDate}
                onChange={(event) => setStartDate(event.target.value)}
                className="h-6 min-w-0 rounded-sm border border-slate-400 bg-white px-1 font-semibold"
              />
            </label>
            <label className="flex items-center gap-2 whitespace-nowrap font-bold">
              Al :
              <input
                type="date"
                aria-label="Fecha final"
                value={endDate}
                onChange={(event) => setEndDate(event.target.value)}
                className="h-6 min-w-0 rounded-sm border border-slate-400 bg-white px-1 font-semibold"
              />
            </label>
          </div>

          <fieldset className="rounded-sm border border-blue-400 px-3 pb-2 pt-1">
            <legend className="px-1 font-semibold text-blue-800">Buscar Cliente</legend>
            <label className="flex cursor-pointer items-center justify-center gap-1 font-semibold">
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
              <label htmlFor="solicitud-ot-cliente" className="font-semibold">Cliente :</label>
              <input
                id="solicitud-ot-cliente"
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
                disabled={allClients}
                onClick={() => {
                  setAllClients(false);
                  setClient("");
                  document.getElementById("solicitud-ot-cliente")?.focus();
                }}
                className="flex h-6 w-7 items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-blue-800 hover:bg-[#CFE0F4] disabled:opacity-50"
              >
                <Search size={15} />
              </button>
            </div>
          </fieldset>

          <div className="grid grid-cols-2 gap-x-5 gap-y-1 rounded-sm border border-blue-400 px-3 py-2">
            <label className="flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold">
              Area :
              <select
                aria-label="Area"
                value={area}
                onChange={(event) => setArea(event.target.value)}
                className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1"
              >
                <option value="">(Todos)</option>
              </select>
            </label>
            <label className="flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold">
              Tipo :
              <select
                aria-label="Tipo"
                value={type}
                onChange={(event) => setType(event.target.value)}
                className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1"
              >
                <option value="">(Todos)</option>
              </select>
            </label>
            <label className="flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold">
              Estado :
              <select
                aria-label="Estado"
                value={status}
                onChange={(event) => setStatus(event.target.value)}
                className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1"
              >
                <option value="">(Todos)</option>
              </select>
            </label>
            <label className="flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold">
              Vendedor :
              <select
                aria-label="Vendedor"
                value={vendor}
                onChange={(event) => setVendor(event.target.value)}
                className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1"
              >
                <option value="">(Todos)</option>
              </select>
            </label>
            <label className="flex min-w-0 items-center gap-1.5 whitespace-nowrap font-semibold">
              Ubicación :
              <select
                aria-label="Ubicación"
                value={location}
                onChange={(event) => setLocation(event.target.value)}
                className="h-6 min-w-0 flex-1 rounded-sm border border-slate-400 bg-white px-1"
              >
                <option value="">(Todos)</option>
              </select>
            </label>
            <fieldset className="mx-auto w-full max-w-[270px] rounded-sm border border-blue-400 px-3 pb-1 pt-0.5">
              <legend className="px-1 font-semibold text-blue-800">Exportar</legend>
              <div className="flex items-center justify-center gap-5">
                <label className="flex cursor-pointer items-center gap-1">
                  <input
                    type="radio"
                    name="solicitud-ot-export"
                    checked={exportMode === "pantalla"}
                    onChange={() => setExportMode("pantalla")}
                  />
                  Pantalla
                </label>
                <label className="flex cursor-pointer items-center gap-1">
                  <input
                    type="radio"
                    name="solicitud-ot-export"
                    checked={exportMode === "excel"}
                    onChange={() => setExportMode("excel")}
                  />
                  Excel
                </label>
              </div>
            </fieldset>
          </div>

          <div className="flex justify-center gap-3 pt-1">
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
                setAllClients(true);
                setClient("(Todos)");
                setExportMode("pantalla");
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

export function ReporteSolicitudOT({ title = "Reporte de Solicitud de OT" }: { title?: string }) {
  return <ReporteSolicitudOTList title={title} />;
}

export function ReporteSolicitudOTList({ title = "Reporte de Solicitud de OT" }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <ReporteSolicitudOrdenTrabajo />
    </div>
  );
}
