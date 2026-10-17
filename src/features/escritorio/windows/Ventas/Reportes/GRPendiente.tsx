import { useState } from "react";
import { Search } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  WindowShell,
  Fs,
  Radio,
} from "@/components/ui/desktop-primitives";

export function ReporteGRPendiente() {
  return <ReporteGRPendienteList />;
}

export function ReporteGRPendienteList() {
  const [locacion, setLocacion] = useState<"todos" | "uno">("todos");

  return (
    <WindowShell title="Reporte de Guías de Venta y Guías no Facturadas">
      <div className="flex h-full items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[560px] space-y-2 px-1 py-2">
          <div className="flex items-center justify-center gap-4">
            <span className="font-bold">Fechas</span>
            <div className="flex items-center gap-2">
              <label htmlFor="gr-pendiente-desde" className="font-bold">Del :</label>
              <input
                id="gr-pendiente-desde"
                className={`${inp} h-6 w-[100px] px-1`}
                type="date"
                defaultValue="2026-10-01"
              />
            </div>
            <div className="flex items-center gap-2">
              <label htmlFor="gr-pendiente-hasta" className="font-bold">Al :</label>
              <input
                id="gr-pendiente-hasta"
                className={`${inp} h-6 w-[100px] px-1`}
                type="date"
                defaultValue="2026-10-15"
              />
            </div>
          </div>

          <div className="grid grid-cols-2 gap-x-8">
            <Fs legend="Locación" className="px-2 pb-1 pt-0">
              <div className="flex flex-col gap-1">
                <label className="inline-flex items-center gap-1 text-[11.5px] text-slate-800">
                  <input
                    type="radio"
                    name="gr-pendiente-locacion"
                    checked={locacion === "todos"}
                    onChange={() => setLocacion("todos")}
                    className="accent-[#2A5590]"
                  />
                  Todos
                </label>
                <label className="inline-flex items-center gap-1 text-[11.5px] text-slate-800">
                  <input
                    type="radio"
                    name="gr-pendiente-locacion"
                    checked={locacion === "uno"}
                    onChange={() => setLocacion("uno")}
                    className="accent-[#2A5590]"
                  />
                  Uno
                </label>
              </div>
              <label className="grid grid-cols-[64px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold text-slate-500">Oficina:</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="LIMA" disabled={locacion === "todos"}>
                  <option value="LIMA">LIMA</option>
                </select>
              </label>
              <label className="grid grid-cols-[64px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold text-slate-500">Almacén:</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="0" disabled={locacion === "todos"}>
                  <option value="0">0</option>
                </select>
              </label>
            </Fs>

            <div className="space-y-2">
              <label className="grid grid-cols-[54px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Motivo:</span>
                <select className={`${inp} h-6 min-w-0 px-1`}>
                  <option>(Todos)</option>
                </select>
              </label>
              <Fs legend="Facturado" className="px-2 pb-1 pt-0">
                <div className="flex flex-col gap-1">
                  <Radio name="gr-pendiente-facturado" label="Pendientes de Facturación" defaultChecked />
                  <Radio name="gr-pendiente-facturado" label="Todos" />
                </div>
              </Fs>
            </div>
          </div>

          <Fs legend="Buscar Cliente" className="px-2 pb-1 pt-0">
            <label className="inline-flex items-center gap-1.5 font-bold">
              <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
              Todo Cliente
            </label>
            <label className="grid grid-cols-[62px_minmax(0,1fr)_28px] items-center gap-1">
              <span className="font-bold">Cliente:</span>
              <input className={`${inp} h-6 min-w-0 px-1`} />
              <button type="button" className={iconBtn} aria-label="Buscar cliente">
                <Search className="h-3.5 w-3.5" />
              </button>
            </label>
          </Fs>

          <div className="grid grid-cols-2 gap-3">
            <Fs legend="Buscar Por Vendedor" className="px-2 pb-1 pt-0">
              <label className="inline-flex items-center gap-1.5 font-bold">
                <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                Todo Vendedor
              </label>
              <label className="grid grid-cols-[68px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Vendedor:</span>
                <select className={`${inp} h-6 min-w-0 px-1`}>
                  <option></option>
                  <option>(Todos)</option>
                </select>
              </label>
            </Fs>

            <Fs legend="Tipo Reporte" className="px-2 pb-1 pt-0">
              <div className="flex flex-col gap-1">
                <Radio name="gr-pendiente-tipo" label="Reporte de Guías" defaultChecked />
                <Radio name="gr-pendiente-tipo" label="Reporte de G/R Por Fecha de Proceso" />
              </div>
            </Fs>
          </div>

          <div className="flex justify-center gap-2 pt-1">
            <button type="button" className={btnPrimary}>Aceptar</button>
            <button type="button" className={btn}>Cancelar</button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}
