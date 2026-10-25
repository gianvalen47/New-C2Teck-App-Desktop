import { useState } from "react";
import { CheckCircle2, Plus, X } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

const gerenciaImportacionOptions = [
  { id: "011-1", title: "Reporte Gerencial 011-1", label: "Resumen de Importaciones" },
  { id: "011-2", title: "Reporte Gerencial 011-2", label: "Detalle de Importaciones" },
  { id: "011-3", title: "Reporte Gerencial 011-3", label: "Pedidos de Importación" },
  {
    id: "011-4",
    title: "Reporte Gerencial 011-4",
    label: "Resumen de Importaciones por Proveedor",
  },
];

function ReporteGerencialImportaciones() {
  const today = new Date();
  const [startDate, setStartDate] = useState(() => {
    const firstDay = new Date(today.getFullYear(), today.getMonth(), 1);
    return `${firstDay.getFullYear()}-${String(firstDay.getMonth() + 1).padStart(2, "0")}-01`;
  });
  const [endDate, setEndDate] = useState(() => {
    return `${today.getFullYear()}-${String(today.getMonth() + 1).padStart(2, "0")}-${String(today.getDate()).padStart(2, "0")}`;
  });
  const [selectedReport, setSelectedReport] = useState("011-1");
  const [watermark, setWatermark] = useState(false);

  return (
    <WindowShell title="Reporte Gerencial de Importaciones">
      <div className="mx-auto flex h-full w-full max-w-[460px] flex-col overflow-auto bg-[#F8FBFF] px-4 py-3 text-[12px] text-slate-800">
        <div className="grid grid-cols-[auto_1fr_auto_1fr] items-center gap-2 whitespace-nowrap">
          <label htmlFor="gerencia-importaciones-start" className="font-semibold">
            Fechas Del :
          </label>
          <input
            id="gerencia-importaciones-start"
            type="date"
            value={startDate}
            onChange={(event) => setStartDate(event.target.value)}
            className="h-7 min-w-0 rounded-sm border border-slate-400 bg-white px-1 font-semibold"
          />
          <label htmlFor="gerencia-importaciones-end" className="font-semibold">
            Al :
          </label>
          <input
            id="gerencia-importaciones-end"
            type="date"
            value={endDate}
            onChange={(event) => setEndDate(event.target.value)}
            className="h-7 min-w-0 rounded-sm border border-slate-400 bg-white px-1 font-semibold"
          />
        </div>

        <div className="relative mt-4 flex flex-1 flex-col">
          <label className="absolute right-0 top-0 flex cursor-pointer items-center gap-1 font-semibold">
            <input
              type="checkbox"
              checked={watermark}
              onChange={(event) => setWatermark(event.target.checked)}
            />
            Marca de Agua
          </label>

          <h1 className="mb-2 mt-1 text-center text-lg font-bold tracking-wide text-red-800">
            IMPORTACIONES
          </h1>

          <div className="flex flex-1 flex-col gap-1">
            {gerenciaImportacionOptions.map((report, index) => (
              <section
                key={report.id}
                className={index === gerenciaImportacionOptions.length - 1 ? "mt-1" : ""}
              >
                <div className="flex min-h-6 items-center gap-1 pl-14">
                  <h2 className="whitespace-nowrap text-[13px] font-bold">{report.title}</h2>
                  {index < 3 && (
                    <button
                      type="button"
                      title="Agregar a Reporte Consolidado Vertical"
                      aria-label={`Agregar ${report.title} al Reporte Consolidado Vertical`}
                      onClick={() => setSelectedReport(report.id)}
                      className="ml-auto flex h-6 w-7 shrink-0 items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-emerald-700 hover:bg-[#CFE0F4]"
                    >
                      <Plus size={15} />
                    </button>
                  )}
                </div>
                <label
                  className={`flex min-h-6 cursor-pointer items-center gap-2 ${
                    index === 3 ? "pl-12" : "pl-14"
                  }`}
                >
                  <input
                    type="radio"
                    name="gerencia-importaciones-report"
                    value={report.id}
                    checked={selectedReport === report.id}
                    onChange={() => setSelectedReport(report.id)}
                  />
                  <span>{report.label}</span>
                </label>
              </section>
            ))}
          </div>
        </div>

        <div className="flex justify-center gap-5 pt-2">
          <button
            type="button"
            className="flex h-8 min-w-[80px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 px-2 font-semibold hover:bg-[#CFE0F4]"
          >
            <CheckCircle2 size={16} className="text-emerald-600" />
            Aceptar
          </button>
          <button
            type="button"
            onClick={() => setSelectedReport("011-1")}
            className="flex h-8 min-w-[80px] items-center justify-center gap-1 rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 px-2 font-semibold hover:bg-[#CFE0F4]"
          >
            <X size={14} className="text-slate-700" />
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}

export function Rpt010Importaciones() {
  return <ReporteGerencialImportaciones />;
}

export function GerenciaImportacionesWindow() {
  return <Rpt010Importaciones />;
}

export function ReporteImportacion({ title = "Reporte Gerencial de Importaciones" }: { title?: string }) {
  return <ReporteImportacionList title={title} />;
}

export function ReporteImportacionList({ title = "Reporte Gerencial de Importaciones" }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <GerenciaImportacionesWindow />
    </div>
  );
}
