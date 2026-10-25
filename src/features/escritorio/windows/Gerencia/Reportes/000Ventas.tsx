import { useState } from "react";
import { Plus, Printer } from "lucide-react";
import { WindowShell } from "@/components/ui/desktop-primitives";

const today = new Date();
const toDateInput = (date: Date) => {
  const year = date.getFullYear();
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const day = String(date.getDate()).padStart(2, "0");
  return `${year}-${month}-${day}`;
};

const reportColumns = [
  [
    {
      id: "001-0",
      title: "Reporte Gerencial 001 - 0",
      options: [{ id: "ventas-consolidado", label: "Consolidado Reg. Ventas" }],
      addTitle: "Agregar a Reporte Consolidado Horizontal",
    },
    {
      id: "001-4",
      title: "Reporte Gerencial 001 - 4",
      options: [{ id: "garantias", label: "Resumen Garantías" }],
      addTitle: "Agregar a Reporte Consolidado Horizontal",
    },
    {
      id: "001-5",
      title: "Reporte Gerencial 001 - 5",
      options: [{ id: "adelantos", label: "Factura por Adelantos" }],
      addTitle: "Agregar a Reporte Consolidado Vertical",
    },
    {
      id: "002",
      title: "Reporte Gerencial 002",
      options: [{ id: "servicios-sin-igv", label: "Detalle de Servicios sin IGV" }],
      addTitle: "Agregar a Reporte Consolidado Horizontal",
    },
    {
      id: "003",
      title: "Reporte Gerencial 003",
      options: [{ id: "ventas-consolidadas", label: "Consolidado de Ventas" }],
      addTitle: "Agregar a Reporte Consolidado Horizontal",
    },
  ],
  [
    {
      id: "004",
      title: "Reporte Gerencial 004",
      options: [{ id: "ventas-cliente", label: "Record de Ventas por Cliente" }],
      addTitle: "Agregar a Reporte Consolidado Horizontal",
    },
    {
      id: "005",
      title: "Reporte Gerencial 005",
      options: [{ id: "motores-vendidos", label: "Motores Vendidos" }],
      addTitle: "Agregar a Reporte Consolidado Vertical",
    },
    {
      id: "006",
      title: "Reporte Gerencial 006",
      options: [
        { id: "consolidado-ots", label: "Consolidado de OTs" },
        { id: "ots-facturados", label: "OT Facturados" },
      ],
      addTitle: "Agregar a Reporte Consolidado Vertical",
    },
    {
      id: "007",
      title: "Reporte Gerencial 007",
      options: [{ id: "ventas-presupuesto", label: "Ventas vs Presupuesto" }],
      addTitle: "Agregar a Reporte Consolidado Vertical",
      print: true,
    },
    {
      id: "008",
      title: "Reporte Gerencial 008",
      options: [{ id: "guias-pendientes", label: "Guias Pendientes de Facturación" }],
      addTitle: "Agregar a Reporte Consolidado Vertical",
    },
  ],
];

function ReporteGerencialVentas() {
  const [startDate, setStartDate] = useState(() => {
    const start = new Date(today.getFullYear(), today.getMonth(), 1);
    return toDateInput(start);
  });
  const [endDate, setEndDate] = useState(() => toDateInput(today));
  const [selectedReport, setSelectedReport] = useState("ventas-consolidado");

  return (
    <WindowShell title="Reporte Gerencial de Ventas">
      <div className="mx-auto flex h-full w-full max-w-[560px] flex-col overflow-auto bg-[#F8FBFF] px-5 py-4 text-[12px] text-slate-800">
        <div className="grid grid-cols-[1fr_auto_1fr] items-center gap-3">
          <label className="flex items-center gap-2 font-semibold">
            Fecha del
            <input
              aria-label="Fecha inicial"
              type="date"
              value={startDate}
              onChange={(event) => setStartDate(event.target.value)}
              className="h-7 min-w-0 rounded-sm border border-slate-400 bg-white px-1 font-normal"
            />
          </label>
          <span className="font-semibold">Al:</span>
          <input
            aria-label="Fecha final"
            type="date"
            value={endDate}
            onChange={(event) => setEndDate(event.target.value)}
            className="h-7 min-w-0 rounded-sm border border-slate-400 bg-white px-1"
          />
        </div>

        <div className="relative mt-3 flex min-h-0 flex-1 flex-col">
          <div className="absolute inset-x-0 top-0 text-center text-lg font-bold tracking-wide text-red-800">
            VENTAS
          </div>
          <div className="ml-auto flex h-9 items-center gap-2 rounded-sm border border-slate-300 bg-[#F3F6FA] px-2">
            <input type="checkbox" defaultChecked={false} disabled aria-label="Moneda" />
            <span className="font-semibold">Moneda:</span>
            <select
              value="USD"
              disabled
              aria-label="Moneda"
              className="h-6 w-[58px] rounded-sm border border-slate-300 bg-slate-100 px-1 text-slate-500"
            >
              <option value="USD">USD</option>
            </select>
          </div>

          <div className="grid min-h-0 flex-1 grid-cols-2 gap-x-5 gap-y-1 pt-3">
            {reportColumns.map((column, columnIndex) => (
              <div key={columnIndex} className="space-y-2">
                {column.map((report) => (
                  <section key={report.id} className="min-w-0">
                    <div className="flex min-h-6 items-center gap-1">
                      <h2 className="whitespace-nowrap text-[12px] font-bold">{report.title}</h2>
                      <button
                        type="button"
                        title={report.addTitle}
                        aria-label={report.addTitle}
                        onClick={() => setSelectedReport(report.options[0].id)}
                        className="ml-auto flex h-6 w-7 shrink-0 items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-slate-700 hover:bg-[#CFE0F4]"
                      >
                        <Plus size={14} />
                      </button>
                    </div>
                    <div className="flex flex-col gap-1 pl-1">
                      {report.options.map((option) => (
                        <label key={option.id} className="flex min-h-5 cursor-pointer items-center gap-2">
                          <input
                            type="radio"
                            name="gerencia-ventas-report"
                            value={option.id}
                            checked={selectedReport === option.id}
                            onChange={() => setSelectedReport(option.id)}
                          />
                          <span className="truncate">{option.label}</span>
                        </label>
                      ))}
                    </div>
                    {report.print && (
                      <button
                        type="button"
                        title="Imprimir Presupuesto Anual"
                        aria-label="Imprimir Presupuesto Anual"
                        onClick={() => setSelectedReport("ventas-presupuesto")}
                        className="ml-auto flex h-6 w-7 items-center justify-center rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 text-slate-700 hover:bg-[#CFE0F4]"
                      >
                        <Printer size={14} />
                      </button>
                    )}
                  </section>
                ))}
              </div>
            ))}
          </div>
        </div>

        <div className="flex justify-center gap-3 border-t border-slate-300 pt-3">
          <button
            type="button"
            className="h-8 min-w-[86px] rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 px-3 font-semibold hover:bg-[#CFE0F4]"
          >
            Aceptar
          </button>
          <button
            type="button"
            onClick={() => setSelectedReport("ventas-consolidado")}
            className="h-8 min-w-[86px] rounded-sm border border-slate-400 bg-gradient-to-b from-white to-slate-100 px-3 font-semibold hover:bg-[#CFE0F4]"
          >
            Cancelar
          </button>
        </div>
      </div>
    </WindowShell>
  );
}

export function Rpt000Ventas() {
  return <ReporteGerencialVentas />;
}

export function GerenciaVentasWindow() {
  return <Rpt000Ventas />;
}

export function ReporteVentas({ title = "Reporte Gerencial de Ventas" }: { title?: string }) {
  return <ReporteVentasList title={title} />;
}

export function ReporteVentasList({ title = "Reporte Gerencial de Ventas" }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <GerenciaVentasWindow />
    </div>
  );
}
