import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

export function ReporteDocEmi({
  title = "Reporte de Documentos Emitidos",
}: {
  title?: string;
}) {
  return <ReporteDocEmiList title={title} />;
}

export function ReporteDocEmiList({
  title = "Reporte de Documentos Emitidos",
}: {
  title?: string;
}) {
  const [exportar, setExportar] = useState("pantalla");
  const [mantenerDolares, setMantenerDolares] = useState(true);

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-start justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <Fs
          legend="Documentos"
          className="w-full max-w-[490px] px-3 pb-3 pt-1"
        >
          <div className="grid grid-cols-[minmax(0,1fr)_112px] gap-x-4 gap-y-2">
            <label className="col-span-2 flex items-center gap-2">
              <span className="w-[82px] shrink-0 text-right font-bold">Fecha Del :</span>
              <input
                aria-label="Fecha desde"
                className={`${inp} h-6 w-[98px] px-1`}
                type="date"
                defaultValue="2026-10-01"
              />
              <span className="ml-4 font-bold">Al :</span>
              <input
                aria-label="Fecha hasta"
                className={`${inp} h-6 w-[98px] px-1`}
                type="date"
                defaultValue="2026-10-24"
              />
            </label>

            <label className="col-span-2 grid grid-cols-[122px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Unidad Negocio:</span>
              <select className={`${inp} h-6 w-[160px] max-w-full px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>

            <label className="grid grid-cols-[86px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Oficina:</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
            <Fs legend="EXPORTAR" className="row-span-3 px-2 pb-2 pt-0">
              <div className="flex flex-col gap-1">
                <label className="inline-flex items-center gap-1 font-bold">
                  <input
                    type="radio"
                    name="documentos-emitidos-exportar"
                    checked={exportar === "pantalla"}
                    onChange={() => setExportar("pantalla")}
                    className="accent-[#0874c9]"
                  />
                  Pantalla
                </label>
                <label className="inline-flex items-center gap-1">
                  <input
                    type="radio"
                    name="documentos-emitidos-exportar"
                    checked={exportar === "excel"}
                    onChange={() => setExportar("excel")}
                    className="accent-[#0874c9]"
                  />
                  Excel
                </label>
              </div>
            </Fs>

            <label className="grid grid-cols-[86px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Almacén:</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>

            <label className="col-span-2 grid grid-cols-[106px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Documentos :</span>
              <select className={`${inp} h-6 w-full max-w-[195px] px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>

            <Fs legend="MONEDA" className="col-span-2 w-[220px] px-2 pb-2 pt-0">
              <label className="flex items-center gap-1.5 pl-2 font-bold">
                <input
                  type="checkbox"
                  checked={mantenerDolares}
                  onChange={(event) => setMantenerDolares(event.target.checked)}
                  className="accent-[#0874c9]"
                />
                Mantener Moneda Dolares
              </label>
            </Fs>
          </div>

          <div className="flex justify-center gap-2 pt-2">
            <button type="button" className={btnPrimary}>
              <CheckCircle2 className="h-4 w-4 text-green-300" />
              Aceptar
            </button>
            <button type="button" className={btn}>
              <LogOut className="h-4 w-4 text-slate-700" />
              Cancelar
            </button>
          </div>
        </Fs>
      </div>
    </WindowShell>
  );
}
