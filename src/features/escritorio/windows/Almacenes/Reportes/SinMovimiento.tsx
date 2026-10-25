import { useState } from "react";
import { Search } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  iconBtn,
  inp,
  Radio,
  WindowShell,
} from "@/components/ui/desktop-primitives";

export function SinMovimientoReportList() {
  const [tipo, setTipo] = useState<"todos" | "aplicacion">("todos");

  return (
    <WindowShell title="Inventario sin Movimiento">
      <div className="flex h-full items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[460px] space-y-2 border border-slate-300 bg-[#F4F4F4] px-3 py-2">
          <div className="flex items-center justify-center gap-4">
            <span className="font-bold">Fechas</span>
            <label className="flex items-center gap-1.5">
              <span className="font-bold">Del :</span>
              <input
                aria-label="Fecha desde"
                className={`${inp} h-6 w-[98px] px-1`}
                type="date"
                defaultValue="2026-10-01"
              />
            </label>
            <label className="flex items-center gap-1.5">
              <span className="font-bold">Al</span>
              <input
                aria-label="Fecha hasta"
                className={`${inp} h-6 w-[98px] px-1`}
                type="date"
                defaultValue="2026-10-24"
              />
            </label>
          </div>

          <div className="grid grid-cols-[1.1fr_1fr] gap-x-4 gap-y-1">
            <label className="grid grid-cols-[54px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Oficina:</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="LIMA">
                <option value="LIMA">LIMA</option>
              </select>
            </label>
            <label className="grid grid-cols-[62px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Almacén:</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="">
                <option value=""></option>
                <option value="all">(Todos)</option>
              </select>
            </label>
            <label className="grid grid-cols-[54px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Rubro:</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
            <Fs legend="Tipo" className="px-2 pb-1 pt-0">
              <div className="flex justify-center gap-4">
                <label className="inline-flex items-center gap-1">
                  <input
                    type="radio"
                    name="sin-movimiento-tipo"
                    checked={tipo === "todos"}
                    onChange={() => setTipo("todos")}
                    className="accent-[#2A5590]"
                  />
                  Todos
                </label>
                <label className="inline-flex items-center gap-1">
                  <input
                    type="radio"
                    name="sin-movimiento-tipo"
                    checked={tipo === "aplicacion"}
                    onChange={() => setTipo("aplicacion")}
                    className="accent-[#2A5590]"
                  />
                  Por Aplicación
                </label>
              </div>
            </Fs>
          </div>

          <Fs legend="Aplicación" className="px-2 pb-1 pt-0">
            <div className="grid grid-cols-[48px_minmax(0,1fr)_26px_20px_minmax(0,1fr)_26px] items-center gap-1">
              <label className={`font-bold ${tipo === "todos" ? "text-slate-400" : ""}`} htmlFor="sin-movimiento-aplicacion-desde">
                Desde :
              </label>
              <input
                id="sin-movimiento-aplicacion-desde"
                className={`${inp} h-6 min-w-0 px-1`}
                disabled={tipo === "todos"}
              />
              <button
                type="button"
                className={`${iconBtn} border border-slate-400/70`}
                aria-label="Buscar aplicación inicial"
                disabled={tipo === "todos"}
              >
                <Search className="h-3.5 w-3.5" />
              </button>
              <label className={`text-center font-bold ${tipo === "todos" ? "text-slate-400" : ""}`} htmlFor="sin-movimiento-aplicacion-hasta">
                A :
              </label>
              <input
                id="sin-movimiento-aplicacion-hasta"
                className={`${inp} h-6 min-w-0 px-1`}
                disabled={tipo === "todos"}
              />
              <button
                type="button"
                className={`${iconBtn} border border-slate-400/70`}
                aria-label="Buscar aplicación final"
                disabled={tipo === "todos"}
              >
                <Search className="h-3.5 w-3.5" />
              </button>
            </div>
          </Fs>

          <Fs legend="Exportar" className="mx-auto w-[205px] px-2 pb-1 pt-0">
            <div className="flex justify-center gap-5">
              <Radio
                name="sin-movimiento-exportar"
                label="Pantalla"
                defaultChecked
              />
              <Radio name="sin-movimiento-exportar" label="Excel" />
            </div>
          </Fs>

          <div className="flex justify-center gap-2">
            <button type="button" className={btnPrimary}>Aceptar</button>
            <button type="button" className={btn}>Cancelar</button>
          </div>
          <p className="text-[11px] font-bold text-blue-800">
            Nota : Considerar que el tiempo de respuesta es lento
          </p>
        </div>
      </div>
    </WindowShell>
  );
}

export function SinMovimientoReport() {
  return <SinMovimientoReportList />;
}
