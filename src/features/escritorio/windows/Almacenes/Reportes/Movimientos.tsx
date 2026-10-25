import { useState } from "react";
import { Search } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  iconBtn,
  inp,
} from "@/components/ui/desktop-primitives";
import { Radio, WindowShell } from "@/components/ui/desktop-primitives";

export function MovimientosAlmacenReportList() {
  const [tipoReporte, setTipoReporte] = useState<"resumen" | "detallado">("resumen");
  const [seleccionarRubros, setSeleccionarRubros] = useState(false);
  const [todaMarca, setTodaMarca] = useState(true);
  const [bajoMaximo, setBajoMaximo] = useState(false);
  const [ordenarUbicacion, setOrdenarUbicacion] = useState(false);

  return (
    <WindowShell title="Reporte de Movimientos de Almacén">
      <div className="flex h-full items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[510px] space-y-2 px-1 py-1">
          <Fs legend="Tipo Reporte" className="max-w-[325px] px-2 pb-1 pt-0">
            <div className="flex gap-8">
              <label className="inline-flex items-center gap-1 font-bold">
                <input
                  type="radio"
                  name="movimientos-tipo-reporte"
                  checked={tipoReporte === "resumen"}
                  onChange={() => setTipoReporte("resumen")}
                  className="accent-[#2A5590]"
                />
                Resumen
              </label>
              <label className="inline-flex items-center gap-1 font-bold">
                <input
                  type="radio"
                  name="movimientos-tipo-reporte"
                  checked={tipoReporte === "detallado"}
                  onChange={() => setTipoReporte("detallado")}
                  className="accent-[#2A5590]"
                />
                Detallado
              </label>
            </div>
          </Fs>

          <Fs legend="Movimientos de Almacén" className="px-2 pb-2 pt-0">
            <div className="flex items-center gap-4">
              <span className="font-bold">Fechas</span>
              <label className="flex items-center gap-2">
                <span className="font-bold">Del :</span>
                <input
                  aria-label="Fecha desde"
                  className={`${inp} h-6 w-[98px] px-1`}
                  type="date"
                  defaultValue="2026-10-01"
                />
              </label>
              <label className="flex items-center gap-2">
                <span className="font-bold">Al</span>
                <input
                  aria-label="Fecha hasta"
                  className={`${inp} h-6 w-[98px] px-1`}
                  type="date"
                  defaultValue="2026-10-24"
                />
              </label>
            </div>

            <div className="grid grid-cols-[minmax(0,1fr)_minmax(0,1fr)] gap-x-4 gap-y-2">
              <label className="grid grid-cols-[76px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Oficina:</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="LIMA">
                  <option value="LIMA">LIMA</option>
                </select>
              </label>
              <label className="grid grid-cols-[98px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">{"{ Movimiento }"}</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                  <option value="all">(Todos)</option>
                </select>
              </label>

              <label className="grid grid-cols-[76px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Almacén:</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="">
                  <option value=""></option>
                  <option value="all">(Todos)</option>
                </select>
              </label>
              <label className="grid grid-cols-[98px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">{"{ Ubicación }"}</span>
                <input className={`${inp} h-6 min-w-0 px-1`} />
              </label>

              <label className="grid grid-cols-[76px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Rubro:</span>
                <select
                  className={`${inp} h-6 min-w-0 px-1`}
                  defaultValue="all"
                  disabled={seleccionarRubros}
                >
                  <option value="all">(Todos)</option>
                </select>
              </label>
              <label className="flex items-center gap-1.5 font-bold">
                <input
                  type="checkbox"
                  checked={seleccionarRubros}
                  onChange={(event) => setSeleccionarRubros(event.target.checked)}
                  className="accent-[#2A5590]"
                />
                Seleccionar Rubros
              </label>
            </div>

            <div className="grid grid-cols-[minmax(0,1fr)_minmax(0,1fr)] gap-x-4 gap-y-2">
              <label className="grid grid-cols-[76px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">{"{ TipMov }"}</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="ingresos">
                  <option value="ingresos">INGRESOS</option>
                  <option value="salidas">SALIDAS</option>
                </select>
              </label>
              <Fs legend="Reporte" className="w-[160px] px-2 pb-1 pt-0">
                <div className="flex flex-col gap-0.5">
                  <Radio
                    name="movimientos-formato"
                    label="Formato 1"
                    defaultChecked
                  />
                  <Radio name="movimientos-formato" label="Formato 2" />
                </div>
              </Fs>
              <label className="col-span-2 flex items-center gap-1.5 pl-7 font-bold">
                <input
                  type="checkbox"
                  checked={bajoMaximo}
                  onChange={(event) => setBajoMaximo(event.target.checked)}
                  className="accent-[#2A5590]"
                />
                Bajo el Máximo
              </label>
            </div>

            <div className="grid grid-cols-[1fr_165px] items-end gap-2">
              <div className="font-bold text-right">{"{ Marca }"}</div>
              <Fs legend="Buscar Marca" className="px-2 pb-1 pt-0">
                <label className="flex items-center gap-1.5 font-bold">
                  <input
                    type="checkbox"
                    checked={todaMarca}
                    onChange={(event) => setTodaMarca(event.target.checked)}
                    className="accent-[#2A5590]"
                  />
                  Toda Marca
                </label>
                <div className="grid grid-cols-[minmax(0,1fr)_26px] items-center gap-1">
                  <input
                    className={`${inp} h-6 min-w-0 px-1`}
                    aria-label="Marca"
                    disabled={todaMarca}
                  />
                  <button
                    type="button"
                    className={`${iconBtn} border border-slate-400/70`}
                    aria-label="Buscar marca"
                    disabled={todaMarca}
                  >
                    <Search className="h-3.5 w-3.5" />
                  </button>
                </div>
              </Fs>
            </div>

            <div className="flex justify-end">
              <Fs legend="Ordenar" className="w-[160px] px-2 pb-1 pt-0">
                <label className="flex items-center justify-center gap-1.5 font-bold">
                  <input
                    type="checkbox"
                    checked={ordenarUbicacion}
                    onChange={(event) => setOrdenarUbicacion(event.target.checked)}
                    className="accent-[#2A5590]"
                  />
                  Por Ubicación
                </label>
              </Fs>
            </div>
          </Fs>

          <div className="flex justify-center gap-2 pt-1">
            <button type="button" className={btnPrimary}>Aceptar</button>
            <button type="button" className={btn}>Cancelar</button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}

export function MovimientosAlmacenReport() {
  return <MovimientosAlmacenReportList />;
}
