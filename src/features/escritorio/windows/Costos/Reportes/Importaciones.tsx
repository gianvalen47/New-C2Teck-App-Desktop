import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

type ReportType =
  | "registro-importaciones"
  | "registro-proveedor"
  | "registro-unidad"
  | "registro-embarque"
  | "resumen"
  | "precio-costo"
  | "comparacion";

function ReportTypeOption({
  name,
  value,
  selected,
  label,
  onChange,
}: {
  name: string;
  value: ReportType;
  selected: ReportType;
  label: string;
  onChange: (value: ReportType) => void;
}) {
  return (
    <label className="inline-flex items-center gap-1 font-bold">
      <input
        type="radio"
        name={name}
        checked={selected === value}
        onChange={() => onChange(value)}
        className="accent-[#0874c9]"
      />
      {label}
    </label>
  );
}

export function ImportacionesCostosReport({
  title = "Importaciones",
}: {
  title?: string;
}) {
  const [reportType, setReportType] = useState<ReportType>("registro-importaciones");
  const [sortBy, setSortBy] = useState("numero");

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-start justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[300px] space-y-2">
          <Fs legend="Tipo de Reporte" className="px-2 pb-2 pt-0">
            <div className="grid grid-cols-2 gap-x-2 gap-y-1">
              <ReportTypeOption
                name="importaciones-tipo-reporte"
                value="registro-importaciones"
                selected={reportType}
                label="Registro de Importaciones"
                onChange={setReportType}
              />
              <ReportTypeOption
                name="importaciones-tipo-reporte"
                value="registro-proveedor"
                selected={reportType}
                label="Registro por Proveedor"
                onChange={setReportType}
              />
              <ReportTypeOption
                name="importaciones-tipo-reporte"
                value="registro-unidad"
                selected={reportType}
                label="Registro por Unid. Negocio"
                onChange={setReportType}
              />
              <ReportTypeOption
                name="importaciones-tipo-reporte"
                value="registro-embarque"
                selected={reportType}
                label="Registro por Embarque"
                onChange={setReportType}
              />
              <ReportTypeOption
                name="importaciones-tipo-reporte"
                value="resumen"
                selected={reportType}
                label="Resumen"
                onChange={setReportType}
              />
              <ReportTypeOption
                name="importaciones-tipo-reporte"
                value="precio-costo"
                selected={reportType}
                label="Precio vs Costo"
                onChange={setReportType}
              />
              <div className="col-span-2">
                <ReportTypeOption
                  name="importaciones-tipo-reporte"
                  value="comparacion"
                  selected={reportType}
                  label="Comparación Cabecera - Detalle"
                  onChange={setReportType}
                />
              </div>
            </div>
          </Fs>

          <div className="grid grid-cols-[minmax(0,1fr)_80px] gap-1.5">
            <Fs legend="" className="px-1.5 pb-1.5 pt-0">
              <div className="flex items-center justify-between gap-1">
                <label className="flex items-center gap-1">
                  <span className="font-bold">Fecha Inicio</span>
                  <input
                    aria-label="Fecha inicio"
                    className={`${inp} h-6 w-[105px] px-1`}
                    type="date"
                    defaultValue="2026-10-01"
                  />
                </label>
                <label className="flex items-center gap-1">
                  <span className="font-bold">Fecha Fin</span>
                  <input
                    aria-label="Fecha fin"
                    className={`${inp} h-6 w-[105px] px-1`}
                    type="date"
                    defaultValue="2026-10-24"
                  />
                </label>
              </div>
            </Fs>
            <label className="flex flex-col gap-1 font-bold">
              <span>Moneda</span>
              <select
                aria-label="Moneda"
                className={`${inp} h-6 w-full px-1`}
                defaultValue="PEN"
              >
                <option value="PEN">S/</option>
                <option value="USD">US$</option>
              </select>
            </label>
          </div>

          <Fs legend="Almacenes" className="px-2 pb-2 pt-0">
            <label className="grid grid-cols-[62px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Oficina :</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
            <label className="grid grid-cols-[62px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Almacen :</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
          </Fs>

          <div className="grid grid-cols-[124px_minmax(0,1fr)] items-end gap-2">
            <label className="flex flex-col gap-1 border border-[#7A96B4] bg-[#ECF1F7] px-2 pb-2 pt-1">
              <span className="font-bold">Nro Ing.</span>
              <input
                aria-label="Número de ingreso"
                className={`${inp} h-6 w-full px-1`}
              />
            </label>
            <Fs legend=" " className="px-2 pb-2 pt-0">
              <div className="flex items-center justify-center gap-4">
                <label className="inline-flex items-center gap-1 font-bold">
                  <input
                    type="radio"
                    name="importaciones-ordenar"
                    checked={sortBy === "numero"}
                    onChange={() => setSortBy("numero")}
                    className="accent-[#0874c9]"
                  />
                  Nro Ingreso
                </label>
                <label className="inline-flex items-center gap-1 font-bold">
                  <input
                    type="radio"
                    name="importaciones-ordenar"
                    checked={sortBy === "fecha"}
                    onChange={() => setSortBy("fecha")}
                    className="accent-[#0874c9]"
                  />
                  Fecha Ingreso
                </label>
              </div>
            </Fs>
          </div>

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