import { useState } from "react";
import { Search } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  iconBtn,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

export function DocumentoReporte({ title = "Reporte de Documentos" }: { title?: string }) {
  return <DocumentoReporteList title={title} />;
}

export function DocumentoReporteList({
  title = "Reporte de Documentos",
}: {
  title?: string;
}) {
  const [todoCliente, setTodoCliente] = useState(true);

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <Fs legend="Datos de Reporte" className="w-full max-w-[455px] px-3 pb-3 pt-1">
          <Fs legend="Rango de Fechas" className="px-2 pb-1 pt-0">
            <div className="flex items-center justify-center gap-6">
              <label className="flex items-center gap-1.5">
                <span className="font-bold">Fechas Del :</span>
                <input
                  aria-label="Fecha desde"
                  className={`${inp} h-6 w-[98px] px-1`}
                  type="date"
                  defaultValue="2026-10-01"
                />
              </label>
              <label className="flex items-center gap-1.5">
                <span className="font-bold">Al :</span>
                <input
                  aria-label="Fecha hasta"
                  className={`${inp} h-6 w-[98px] px-1`}
                  type="date"
                  defaultValue="2026-10-24"
                />
              </label>
            </div>
          </Fs>

          <div className="grid grid-cols-[minmax(0,1fr)_minmax(0,0.9fr)] items-center gap-x-3 gap-y-1">
            <label className="grid grid-cols-[60px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Moneda</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="NS">
                <option value="NS">NS</option>
              </select>
            </label>
            <label className="grid grid-cols-[44px_minmax(0,1fr)_26px] items-center gap-1">
              <span className="font-bold">N° OT</span>
              <input className={`${inp} h-6 min-w-0 px-1`} aria-label="Número de OT" />
              <button
                type="button"
                className={`${iconBtn} border border-slate-400/70`}
                aria-label="Buscar orden de trabajo"
              >
                <Search className="h-3.5 w-3.5" />
              </button>
            </label>

            <label className="grid grid-cols-[60px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Oficina</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="LIMA">
                <option value="LIMA">LIMA</option>
              </select>
            </label>
            <label className="grid grid-cols-[58px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Almacén</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="">
                <option value=""></option>
                <option value="all">(Todos)</option>
              </select>
            </label>

            <label className="col-span-2 grid grid-cols-[60px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Tipo Doc.</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="">
                <option value=""></option>
              </select>
            </label>
          </div>

          <Fs legend="Datos de Cliente" className="px-2 pb-1 pt-0">
            <label className="flex items-center justify-center gap-1.5 font-bold">
              <span>Todo Cliente</span>
              <input
                type="checkbox"
                checked={todoCliente}
                onChange={(event) => setTodoCliente(event.target.checked)}
                className="accent-[#2A5590]"
              />
            </label>
            <label className="grid grid-cols-[48px_minmax(0,1fr)_26px] items-center gap-1">
              <span className="font-bold">Cliente</span>
              <input
                className={`${inp} h-6 min-w-0 px-1`}
                defaultValue="(TODOS)"
                disabled={todoCliente}
              />
              <button
                type="button"
                className={`${iconBtn} border border-slate-400/70`}
                aria-label="Buscar cliente"
                disabled={todoCliente}
              >
                <Search className="h-3.5 w-3.5" />
              </button>
            </label>
            <label className="grid grid-cols-[48px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Loc.Cli</span>
              <select
                className={`${inp} h-6 min-w-0 px-1`}
                defaultValue="0"
                disabled={todoCliente}
              >
                <option value="0">0</option>
              </select>
            </label>
          </Fs>

          <div className="flex justify-center gap-2 pt-1">
            <button type="button" className={btnPrimary}>Aceptar</button>
            <button type="button" className={btn}>Cancelar</button>
          </div>
        </Fs>
      </div>
    </WindowShell>
  );
}
