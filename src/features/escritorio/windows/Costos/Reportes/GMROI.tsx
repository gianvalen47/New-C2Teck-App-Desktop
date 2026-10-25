import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

type ReportType = "rubro" | "unidad" | "mercaderia";
type ExportType = "pantalla" | "excel";

export function GmroiCostosReportList({
  title = "Reporte de GMROI",
}: {
  title?: string;
}) {
  const [reportType, setReportType] = useState<ReportType>("rubro");
  const [exportType, setExportType] = useState<ExportType>("pantalla");

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-start justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[490px] space-y-2">
          <Fs legend="Tipo" className="px-2 pb-2 pt-0">
            <div className="flex items-center justify-between gap-2">
              <label className="inline-flex items-center gap-1 font-bold">
                <input
                  type="radio"
                  name="gmroi-tipo"
                  checked={reportType === "rubro"}
                  onChange={() => setReportType("rubro")}
                  className="accent-[#0874c9]"
                />
                Resumen x Rubro
              </label>
              <label className="inline-flex items-center gap-1 font-bold">
                <input
                  type="radio"
                  name="gmroi-tipo"
                  checked={reportType === "unidad"}
                  onChange={() => setReportType("unidad")}
                  className="accent-[#0874c9]"
                />
                Resumen x Unidad Negocio
              </label>
              <label className="inline-flex items-center gap-1 font-bold">
                <input
                  type="radio"
                  name="gmroi-tipo"
                  checked={reportType === "mercaderia"}
                  onChange={() => setReportType("mercaderia")}
                  className="accent-[#0874c9]"
                />
                Detallado x Mercadería
              </label>
            </div>
          </Fs>

          <Fs legend="Rango de Fechas" className="px-3 pb-2 pt-0">
            <div className="flex items-center justify-center gap-10">
              <label className="flex items-center gap-1.5">
                <span className="font-bold">Fechas Del :</span>
                <input
                  aria-label="Fecha desde"
                  className={`${inp} h-6 w-[98px] px-1`}
                  type="date"
                  defaultValue="2026-01-01"
                />
              </label>
              <label className="flex items-center gap-1.5">
                <span className="font-bold">A :</span>
                <input
                  aria-label="Fecha hasta"
                  className={`${inp} h-6 w-[98px] px-1`}
                  type="date"
                  defaultValue="2026-09-30"
                />
              </label>
            </div>
          </Fs>

          <div className="grid grid-cols-2 gap-x-6 gap-y-1 px-2">
            <label className="grid grid-cols-[52px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Oficina:</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
            <label className="grid grid-cols-[58px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Almacén:</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
            <label className="col-span-2 grid grid-cols-[52px_132px] items-center gap-1">
              <span className="font-bold">Rubro:</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
          </div>

          <Fs legend="Exportar" className="mx-auto w-[245px] px-2 pb-2 pt-0">
            <div className="flex items-center justify-center gap-8">
              <label className="inline-flex items-center gap-1 font-bold">
                <input
                  type="radio"
                  name="gmroi-exportar"
                  checked={exportType === "pantalla"}
                  onChange={() => setExportType("pantalla")}
                  className="accent-[#0874c9]"
                />
                Pantalla
              </label>
              <label className="inline-flex items-center gap-1">
                <input
                  type="radio"
                  name="gmroi-exportar"
                  checked={exportType === "excel"}
                  onChange={() => setExportType("excel")}
                  className="accent-[#0874c9]"
                />
                Excel
              </label>
            </div>
          </Fs>

          <div className="flex justify-center gap-2 pt-1">
            <button type="button" className={btnPrimary}>
              <CheckCircle2 className="h-4 w-4 text-green-300" />
              Aceptar
            </button>
            <button type="button" className={btn}>
              <LogOut className="h-4 w-4 text-slate-700" />
              Cancelar
            </button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}

export function GmroiCostosReport({
  title = "Reporte de GMROI",
}: {
  title?: string;
}) {
  return <GmroiCostosReportList title={title} />;
}
