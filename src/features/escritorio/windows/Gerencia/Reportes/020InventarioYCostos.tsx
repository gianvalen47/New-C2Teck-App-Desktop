import { useState } from "react";
import { Plus } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

type GerenciaInventarioReport =
  | "motores"
  | "baterias"
  | "filtros"
  | "repuestos"
  | "resumen"
  | "stock-valorizado-01"
  | "stock-valorizado-02"
  | "sin-movimiento";

const stockOptions: { id: GerenciaInventarioReport; label: string }[] = [
  { id: "motores", label: "Motores en Stock" },
  { id: "baterias", label: "Baterias en Stock" },
  { id: "filtros", label: "Filtros en Stock" },
  { id: "repuestos", label: "Repuestos en Stock" },
];

function ReporteGerencialInventarioCostos() {
  const today = new Date();
  const [selectedReport, setSelectedReport] = useState<GerenciaInventarioReport>("motores");
  const [cycle, setCycle] = useState("todos");
  const [startDate, setStartDate] = useState(
    `${today.getFullYear()}-01-01`,
  );
  const [endDate, setEndDate] = useState(
    `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, "0")}-${String(today.getDate()).padStart(2, "0")}`,
  );
  const [watermark, setWatermark] = useState(false);

  const cyclesEnabled = selectedReport === "repuestos";
  const movementDatesEnabled = selectedReport === "sin-movimiento";
  const watermarkVisible = selectedReport === "stock-valorizado-01";

  const selectReport = (report: GerenciaInventarioReport) => {
    setSelectedReport(report);
    if (report !== "stock-valorizado-01") setWatermark(false);
  };

  return (
    <WindowShell title="Reporte Gerencial de Inventarios y Costos">
      <div className="mx-auto flex h-full w-full max-w-[460px] flex-col overflow-auto bg-[#F8FBFF] px-4 py-3 text-[12px] text-slate-800">
        <h1 className="mb-2 text-center text-lg font-bold tracking-wide text-red-800">
          INVENTARIO Y COSTOS
        </h1>

        <div className="flex min-h-0 flex-1 flex-col rounded-sm border border-blue-400 bg-[#F8FBFF] px-3 py-2">
          <h2 className="mb-1 text-center text-[13px] font-bold">Reporte Gerencial 021</h2>
          <div className="flex flex-col gap-1 pl-14">
            {stockOptions.map((option) => (
              <label key={option.id} className="flex min-h-5 cursor-pointer items-center gap-2 font-semibold">
                <input
                  type="radio"
                  name="gerencia-inventarios-report"
                  checked={selectedReport === option.id}
                  onChange={() => selectReport(option.id)}
                />
                {option.label}
              </label>
            ))}

            <fieldset
              disabled={!cyclesEnabled}
              className="ml-5 mt-0.5 w-[112px] rounded-sm border border-slate-300 px-2 pb-1"
            >
              <legend className="px-1 font-semibold text-slate-600">Ciclos</legend>
              {[
                ["todos", "Todos"],
                ["4-ciclos", "4 Ciclos"],
                ["2-ciclos", "2 Ciclos"],
                ["sin-ciclos", "No tienen"],
              ].map(([id, label]) => (
                <label
                  key={id}
                  className="flex h-5 cursor-pointer items-center gap-1.5 font-semibold disabled:cursor-default"
                >
                  <input
                    type="radio"
                    name="gerencia-inventarios-cycle"
                    value={id}
                    checked={cycle === id}
                    onChange={() => setCycle(id)}
                  />
                  {label}
                </label>
              ))}
            </fieldset>
          </div>

          <label className="mt-1 flex min-h-6 cursor-pointer items-center gap-2 pl-10 font-semibold">
            <input
              type="radio"
              name="gerencia-inventarios-report"
              checked={selectedReport === "resumen"}
              onChange={() => selectReport("resumen")}
            />
            Resumen Motores - Baterias - Filtros
          </label>

          <h2 className="mb-1 mt-1 text-center text-[13px] font-bold">Reporte Gerencial 022</h2>
          <div className="flex flex-col gap-1 pl-14">
            {(
              [
                ["stock-valorizado-01", "Stock Valorizado 01"],
                ["stock-valorizado-02", "Stock Valorizado 02"],
              ] as const
            ).map(([id, label]) => (
              <div key={id} className="flex min-h-5 items-center gap-2 font-semibold">
                <label className="flex cursor-pointer items-center gap-2">
                  <input
                    type="radio"
                    name="gerencia-inventarios-report"
                    checked={selectedReport === id}
                    onChange={() => selectReport(id)}
                  />
                  {label}
                </label>
                {id === "stock-valorizado-01" && (
                  <button
                    type="button"
                    title="Agregar a Reporte Consolidado Vertical"
                    aria-label="Agregar Stock Valorizado 01 al Reporte Consolidado Vertical"
                    onClick={() => selectReport(id)}
                    className="ml-1 flex h-6 w-7 shrink-0 items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-emerald-700 hover:bg-[#CFE0F4]"
                  >
                    <Plus size={15} />
                  </button>
                )}
              </div>
            ))}
          </div>

          <h2 className="mb-1 mt-2 text-center text-[13px] font-bold">Reporte Gerencial 023</h2>
          <label className="flex min-h-5 cursor-pointer items-center gap-2 pl-14 font-semibold">
            <input
              type="radio"
              name="gerencia-inventarios-report"
              checked={selectedReport === "sin-movimiento"}
              onChange={() => selectReport("sin-movimiento")}
            />
            Inventario Sin movimiento
          </label>

          <div className="mt-auto grid grid-cols-[auto_1fr] items-center gap-x-2 gap-y-1 rounded-sm border border-blue-400 px-3 py-2 text-slate-600">
            <label htmlFor="gerencia-inventarios-start" className="text-right font-semibold">
              Desde :
            </label>
            <input
              id="gerencia-inventarios-start"
              type="date"
              disabled={!movementDatesEnabled}
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className="h-7 w-full max-w-[150px] rounded-sm border border-slate-400 bg-white px-1 disabled:bg-slate-100 disabled:text-slate-500"
            />
            <label htmlFor="gerencia-inventarios-end" className="text-right font-semibold">
              Hasta :
            </label>
            <input
              id="gerencia-inventarios-end"
              type="date"
              disabled={!movementDatesEnabled}
              value={endDate}
              onChange={(event) => setEndDate(event.target.value)}
              className="h-7 w-full max-w-[150px] rounded-sm border border-slate-400 bg-white px-1 disabled:bg-slate-100 disabled:text-slate-500"
            />
          </div>

          {watermarkVisible && (
            <label className="mt-1 flex cursor-pointer items-center gap-1 font-semibold">
              <input
                type="checkbox"
                checked={watermark}
                onChange={(event) => setWatermark(event.target.checked)}
              />
              Marca de Agua
            </label>
          )}
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
              selectReport("motores");
              setCycle("todos");
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

export function Rpt020InventarioYCostos() {
  return <ReporteGerencialInventarioCostos />;
}

export function GerenciaInventarioCostosWindow() {
  return <Rpt020InventarioYCostos />;
}

export function ReporteInvencos({ title = "Reporte Gerencial de Inventarios y Costos" }: { title?: string }) {
  return <ReporteInvencosList title={title} />;
}

export function ReporteInvencosList({ title = "Reporte Gerencial de Inventarios y Costos" }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <GerenciaInventarioCostosWindow />
    </div>
  );
}
