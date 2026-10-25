import { useState } from "react";
import { Plus, Search } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

function ReporteGerencialContabilidad() {
  const today = new Date();
  const [startDate, setStartDate] = useState(
    `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, "0")}-01`,
  );
  const [endDate, setEndDate] = useState(
    `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, "0")}-${String(today.getDate()).padStart(2, "0")}`,
  );
  const [selectedReport, setSelectedReport] = useState<"ventas" | "gastos">("ventas");
  const [currency, setCurrency] = useState<"soles" | "dolares">("soles");
  const [allClients, setAllClients] = useState(true);
  const [client, setClient] = useState("");
  const [watermark, setWatermark] = useState(false);

  const clientGroupEnabled = selectedReport === "ventas";

  return (
    <WindowShell title="Reporte Gerencial de Contabilidad">
      <div className="mx-auto flex h-full w-full max-w-[610px] flex-col overflow-auto bg-[#F8FBFF] px-4 py-3 text-[12px] text-slate-800">
        <div className="grid grid-cols-[auto_1fr_auto_1fr] items-center justify-center gap-2 whitespace-nowrap px-5">
          <label htmlFor="gerencia-contabilidad-start" className="font-semibold">
            Fechas Del :
          </label>
          <input
            id="gerencia-contabilidad-start"
            type="date"
            value={startDate}
            onChange={(event) => setStartDate(event.target.value)}
            className="h-7 min-w-0 rounded-sm border border-slate-400 bg-white px-1 font-semibold"
          />
          <label htmlFor="gerencia-contabilidad-end" className="font-semibold">
            Al :
          </label>
          <input
            id="gerencia-contabilidad-end"
            type="date"
            value={endDate}
            onChange={(event) => setEndDate(event.target.value)}
            className="h-7 min-w-0 rounded-sm border border-slate-400 bg-white px-1 font-semibold"
          />
        </div>

        <div className="relative mt-2 flex flex-1 flex-col">
          {clientGroupEnabled && (
            <label className="absolute right-2 top-1 flex cursor-pointer items-center gap-1 font-semibold">
              <input
                type="checkbox"
                checked={watermark}
                onChange={(event) => setWatermark(event.target.checked)}
              />
              Marca de Agua
            </label>
          )}

          <h1 className="mb-1 mt-4 text-center text-lg font-bold tracking-wide text-red-800">
            CONTABILIDAD
          </h1>

          <div className="grid grid-cols-[1fr_1fr] gap-x-5">
            <section>
              <h2 className="mb-1 text-[13px] font-bold">Reporte Gerencial 032</h2>
              <div className="flex min-h-6 items-center gap-1">
                <label className="flex cursor-pointer items-center gap-2">
                  <input
                    type="radio"
                    name="gerencia-contabilidad-report"
                    checked={selectedReport === "ventas"}
                    onChange={() => setSelectedReport("ventas")}
                  />
                  Cuadro de Ventas
                </label>
                <button
                  type="button"
                  title="Agregar a Reporte Consolidado Horizontal"
                  aria-label="Agregar Cuadro de Ventas al Reporte Consolidado Horizontal"
                  onClick={() => setSelectedReport("ventas")}
                  className="ml-1 flex h-6 w-7 shrink-0 items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-emerald-700 hover:bg-[#CFE0F4]"
                >
                  <Plus size={15} />
                </button>
              </div>
            </section>
            <section>
              <h2 className="mb-1 text-[13px] font-bold">Reporte Gerencial 033</h2>
              <label className="flex min-h-6 cursor-pointer items-center gap-2">
                <input
                  type="radio"
                  name="gerencia-contabilidad-report"
                  checked={selectedReport === "gastos"}
                  onChange={() => setSelectedReport("gastos")}
                />
                Gastos OT
              </label>
            </section>
          </div>

          <div className="mt-2 grid grid-cols-[1fr_auto] gap-2">
            <fieldset
              disabled={!clientGroupEnabled}
              className="min-w-0 rounded-sm border border-blue-400 px-2 pb-2 pt-1 disabled:opacity-60"
            >
              <legend className="px-1 font-semibold text-blue-800">Buscar Cliente</legend>
              <label className="flex cursor-pointer items-center gap-1 font-semibold">
                <input
                  type="checkbox"
                  checked={allClients}
                  onChange={(event) => setAllClients(event.target.checked)}
                />
                Todo Cliente
              </label>
              <div className="mt-1 grid grid-cols-[auto_1fr_auto] items-center gap-1">
                <label htmlFor="gerencia-contabilidad-client" className="font-semibold">
                  Cliente:
                </label>
                <input
                  id="gerencia-contabilidad-client"
                  value={client}
                  disabled={allClients || !clientGroupEnabled}
                  onChange={(event) => setClient(event.target.value)}
                  className="h-6 min-w-0 rounded-sm border border-slate-400 bg-white px-1 disabled:bg-slate-100"
                />
                <button
                  type="button"
                  disabled={allClients || !clientGroupEnabled}
                  title="Buscar Cliente"
                  aria-label="Buscar Cliente"
                  onClick={() => document.getElementById("gerencia-contabilidad-client")?.focus()}
                  className="flex h-6 w-7 items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-blue-800 hover:bg-[#CFE0F4] disabled:opacity-50"
                >
                  <Search size={15} />
                </button>
              </div>
            </fieldset>

            <fieldset className="w-[112px] rounded-sm border border-blue-400 px-2 pb-1 pt-1">
              <legend className="px-1 font-semibold text-blue-800">Moneda</legend>
              <label className="flex h-5 cursor-pointer items-center gap-1.5 font-semibold">
                <input
                  type="radio"
                  name="gerencia-contabilidad-currency"
                  checked={currency === "soles"}
                  onChange={() => setCurrency("soles")}
                />
                En Soles
              </label>
              <label className="flex h-5 cursor-pointer items-center gap-1.5 font-semibold">
                <input
                  type="radio"
                  name="gerencia-contabilidad-currency"
                  checked={currency === "dolares"}
                  onChange={() => setCurrency("dolares")}
                />
                En Dólares
              </label>
            </fieldset>
          </div>
        </div>

        <div className="flex justify-center gap-3 pt-3">
          <button
            type="button"
            className="h-8 min-w-[86px] rounded-sm border border-blue-500 bg-gradient-to-b from-white to-slate-100 px-3 font-semibold hover:bg-[#CFE0F4]"
          >
            <span aria-hidden="true" className="mr-1 text-emerald-600">✓</span>
            Aceptar
          </button>
          <button
            type="button"
            onClick={() => {
              setSelectedReport("ventas");
              setCurrency("soles");
              setAllClients(true);
              setClient("");
              setWatermark(false);
            }}
            className="h-8 min-w-[86px] rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 px-3 font-semibold hover:bg-[#CFE0F4]"
          >
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}

export function Rpt030Contabilidad() {
  return <ReporteGerencialContabilidad />;
}

export function GerenciaContabilidadWindow() {
  return <Rpt030Contabilidad />;
}

export function ReporteContabilidad({ title = "Reporte Gerencial de Contabilidad" }: { title?: string }) {
  return <ReporteContabilidadList title={title} />;
}

export function ReporteContabilidadList({ title = "Reporte Gerencial de Contabilidad" }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <GerenciaContabilidadWindow />
    </div>
  );
}
