import { useState } from "react";
import { CheckCircle2, Search } from "lucide-react";
import {
  btn,
  btnPrimary,
  iconBtn,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

type ReportKind =
  | "kardex"
  | "motores-vendidos"
  | "costo-adicional"
  | "accesorios-vendidos"
  | "kardex-motor-vendido";

type SaleFilter = "todos" | "vendidos" | "vendido-antes";

const reportOptions: { value: ReportKind; label: string }[] = [
  { value: "kardex", label: "Kardex" },
  { value: "motores-vendidos", label: "Motores Vendidos" },
  { value: "costo-adicional", label: "Costo Adicional" },
  { value: "accesorios-vendidos", label: "Accesorios Vendidos" },
  { value: "kardex-motor-vendido", label: "Kardex Motor Vendido" },
];

const salesFilterOptions: { value: SaleFilter; label: string }[] = [
  { value: "todos", label: "Todos" },
  { value: "vendidos", label: "Vendidos" },
  { value: "vendido-antes", label: "Vendido Antes" },
];

export function MotoresCostosReport({
  title = "Reporte de Motores",
}: {
  title?: string;
}) {
  const [reportKind, setReportKind] = useState<ReportKind>("kardex");
  const [saleFilter, setSaleFilter] = useState<SaleFilter>("todos");
  const salesFilterEnabled =
    reportKind === "motores-vendidos" ||
    reportKind === "accesorios-vendidos" ||
    reportKind === "kardex-motor-vendido";

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-start justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[415px] space-y-2 px-1">
          <label className="grid grid-cols-[68px_minmax(0,1fr)] items-center gap-1">
            <span className="font-bold">Oficina :</span>
            <select
              aria-label="Oficina"
              className={`${inp} h-6 w-[188px] max-w-full px-1`}
              defaultValue="iquitos"
            >
              <option value="iquitos">IQUITOS</option>
            </select>
          </label>

          <label className="grid grid-cols-[68px_minmax(0,1fr)] items-center gap-1">
            <span className="font-bold">Almacén :</span>
            <select
              aria-label="Almacén"
              className={`${inp} h-6 w-full px-1`}
              defaultValue="comercial"
            >
              <option value="comercial">COMERCIAL</option>
            </select>
          </label>

          <div className="grid grid-cols-[minmax(0,1fr)_140px] items-start gap-2 pt-2">
            <fieldset className="border-0 p-0">
              <legend className="sr-only">Tipo de reporte</legend>
              <div className="flex flex-col gap-1">
                {reportOptions.map(({ value, label }) => (
                  <label key={value} className="inline-flex items-center gap-1">
                    <input
                      type="radio"
                      name="motores-tipo-reporte"
                      checked={reportKind === value}
                      onChange={() => setReportKind(value)}
                      className="accent-[#0874c9]"
                    />
                    {label}
                  </label>
                ))}
              </div>
            </fieldset>

            <div className="space-y-2">
              <label className="grid grid-cols-[74px_minmax(0,1fr)_26px] items-center gap-1">
                <span className={`text-right font-bold ${reportKind === "kardex" ? "text-slate-400" : ""}`}>
                  S/N Motor:
                </span>
                <input
                  aria-label="Número de serie del motor"
                  className={`${inp} h-6 min-w-0 px-1`}
                  disabled={reportKind === "kardex"}
                />
                <button
                  type="button"
                  className={`${iconBtn} border border-slate-400/70`}
                  aria-label="Buscar número de serie del motor"
                  disabled={reportKind === "kardex"}
                >
                  <Search className="h-4 w-4" />
                </button>
              </label>

              <fieldset
                className={`border border-slate-400/60 px-2 pb-1 pt-1 ${
                  salesFilterEnabled ? "bg-[#ECF1F7]" : "bg-[#F2F2F2] opacity-50"
                }`}
                disabled={!salesFilterEnabled}
              >
                <legend className="sr-only">Filtro de venta</legend>
                <div className="flex flex-col gap-0.5">
                  {salesFilterOptions.map(({ value, label }) => (
                    <label key={value} className="inline-flex items-center gap-1">
                      <input
                        type="radio"
                        name="motores-filtro-venta"
                        checked={saleFilter === value}
                        onChange={() => setSaleFilter(value)}
                        className="accent-[#0874c9]"
                      />
                      {label}
                    </label>
                  ))}
                </div>
              </fieldset>
            </div>
          </div>

          <div className="flex items-center justify-start gap-2 pt-1">
            <label className="flex items-center gap-1.5">
              <span className="font-bold">Del :</span>
              <input
                aria-label="Fecha desde"
                className={`${inp} h-6 w-[98px] px-1`}
                type="date"
                defaultValue="2026-09-01"
              />
            </label>
            <label className="flex items-center gap-1.5">
              <span className="font-bold">Al :</span>
              <input
                aria-label="Fecha hasta"
                className={`${inp} h-6 w-[98px] px-1`}
                type="date"
                defaultValue="2026-09-30"
              />
            </label>
          </div>

          <div className="flex justify-end gap-2 pt-1">
            <button type="button" className={btnPrimary}>
              <CheckCircle2 className="h-4 w-4 text-green-300" />
              Aceptar
            </button>
            <button type="button" className={btn}>
              <span className="text-sky-700" aria-hidden="true">↶</span>
              Cancelar
            </button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}