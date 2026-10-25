import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

export function EmbarqueImportacion({
  title = "Reporte de Embarques",
}: {
  title?: string;
}) {
  return <EmbarqueImportacionList title={title} />;
}

export function EmbarqueImportacionList({
  title = "Reporte de Embarques",
}: {
  title?: string;
}) {
  const [tipoFecha, setTipoFecha] = useState("emision");

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-start justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[390px] space-y-2">
          <Fs legend="Rango de Fechas" className="px-2 pb-2 pt-0">
            <div className="flex items-center justify-between gap-3">
              <label className="flex items-center gap-1">
                <span className="font-bold">Fecha Inicio</span>
                <input
                  aria-label="Fecha inicio"
                  className={`${inp} h-6 w-[98px] px-1`}
                  type="date"
                  defaultValue="2026-09-01"
                />
              </label>
              <label className="flex items-center gap-1">
                <span className="font-bold">Fecha Fin</span>
                <input
                  aria-label="Fecha fin"
                  className={`${inp} h-6 w-[98px] px-1`}
                  type="date"
                  defaultValue="2026-09-30"
                />
              </label>
            </div>
          </Fs>

          <Fs legend="Tipo de Fecha" className="px-2 pb-2 pt-0">
            <div className="flex items-center justify-around gap-3">
              <label className="inline-flex items-center gap-1 font-bold">
                <input
                  type="radio"
                  name="embarques-tipo-fecha"
                  checked={tipoFecha === "emision"}
                  onChange={() => setTipoFecha("emision")}
                  className="accent-[#0874c9]"
                />
                Fecha de Emisión
              </label>
              <label className="inline-flex items-center gap-1 font-bold">
                <input
                  type="radio"
                  name="embarques-tipo-fecha"
                  checked={tipoFecha === "llegada"}
                  onChange={() => setTipoFecha("llegada")}
                  className="accent-[#0874c9]"
                />
                Fecha de Llegada
              </label>
            </div>
          </Fs>

          <div className="grid grid-cols-[minmax(0,1fr)_minmax(0,1.35fr)] items-center gap-3 border border-[#7A96B4] bg-[#ECF1F7] px-2 py-2">
            <label className="grid grid-cols-[42px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Medio</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
            <label className="grid grid-cols-[86px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Cod Embarque</span>
              <input
                aria-label="Código de embarque"
                className={`${inp} h-6 min-w-0 px-1`}
              />
            </label>
          </div>

          <Fs legend="Proveedor" className="px-2 pb-2 pt-0">
            <label className="grid grid-cols-[64px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Proveedor</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
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
