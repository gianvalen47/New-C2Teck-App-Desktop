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

export function TomaInventarioReportList() {
  const [ordenarPorUbicacion, setOrdenarPorUbicacion] = useState(false);
  const [todaAplicacion, setTodaAplicacion] = useState(true);
  const [todaMarca, setTodaMarca] = useState(true);
  const [modoMercaderia, setModoMercaderia] = useState<"todos" | "remanufacturado">("todos");
  const [ubicacion, setUbicacion] = useState<"todos" | "sin" | "por">("todos");

  return (
    <WindowShell title="Reporte Toma de Inventario">
      <div className="flex h-full items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <Fs
          legend="INVENTARIO"
          className="w-full max-w-[590px] px-3 pb-3 pt-1"
        >
          <div className="grid grid-cols-[1.25fr_0.9fr_0.9fr] gap-3">
            <div className="space-y-1.5">
              <label className="grid grid-cols-[112px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Stock a la Fecha:</span>
                <input
                  aria-label="Stock a la Fecha"
                  className={`${inp} h-6 min-w-0 px-1`}
                  type="date"
                  defaultValue="2026-10-24"
                />
              </label>
              <label className="grid grid-cols-[78px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Oficina:</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="LIMA">
                  <option value="LIMA">LIMA</option>
                </select>
              </label>
              <label className="grid grid-cols-[78px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Almacén:</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="">
                  <option value=""></option>
                  <option value="all">(Todos)</option>
                </select>
              </label>
              <label className="grid grid-cols-[78px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Tipo Motor:</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                  <option value="all">(Todos)</option>
                </select>
              </label>
              <label className="grid grid-cols-[78px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Modelo:</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                  <option value="all">(Todos)</option>
                </select>
              </label>
              <label className="grid grid-cols-[78px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Rubro:</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                  <option value="all">(Todos)</option>
                </select>
              </label>
              <label className="grid grid-cols-[78px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Clase:</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="">
                  <option value=""></option>
                  <option value="all">(Todos)</option>
                </select>
              </label>

              <Fs legend="Exportar" className="px-2 pb-1 pt-0">
                <div className="flex flex-col gap-0.5">
                  <Radio
                    name="toma-inventario-exportar"
                    label="Pantalla"
                    defaultChecked
                  />
                  <Radio name="toma-inventario-exportar" label="Excel" />
                  <Radio
                    name="toma-inventario-exportar"
                    label="Exportar Código de Barras"
                  />
                </div>
              </Fs>
            </div>

            <div className="space-y-1.5">
              <label className="flex items-center gap-1.5 px-2 font-bold">
                <input
                  type="checkbox"
                  checked={ordenarPorUbicacion}
                  onChange={(event) => setOrdenarPorUbicacion(event.target.checked)}
                  className="accent-[#2A5590]"
                />
                Ordenar por Ubicación
              </label>

              <Fs legend="Mostrar Stock" className="px-2 pb-1 pt-0">
                <div className="flex flex-col gap-0.5">
                  <Radio
                    name="toma-inventario-mostrar-stock"
                    label="Con Stock"
                    defaultChecked
                  />
                  <Radio name="toma-inventario-mostrar-stock" label="Sin Stock" />
                  <Radio name="toma-inventario-mostrar-stock" label="Físico" />
                  <Radio
                    name="toma-inventario-mostrar-stock"
                    label="Con Disponible"
                  />
                  <Radio
                    name="toma-inventario-mostrar-stock"
                    label="Sin Disponible"
                  />
                </div>
              </Fs>

              <Fs legend="Buscar Aplicación" className="px-2 pb-1 pt-0">
                <label className="flex items-center gap-1.5 font-bold">
                  <input
                    type="checkbox"
                    checked={todaAplicacion}
                    onChange={(event) => setTodaAplicacion(event.target.checked)}
                    className="accent-[#2A5590]"
                  />
                  Toda Aplicación
                </label>
                <div className="grid grid-cols-[minmax(0,1fr)_26px] items-center gap-1">
                  <input
                    className={`${inp} h-6 min-w-0 px-1`}
                    aria-label="Aplicación"
                    disabled={todaAplicacion}
                  />
                  <button
                    type="button"
                    className={`${iconBtn} border border-slate-400/70`}
                    aria-label="Buscar aplicación"
                    disabled={todaAplicacion}
                  >
                    <Search className="h-3.5 w-3.5" />
                  </button>
                </div>
              </Fs>

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

              <Fs legend="Buscar Mercadería" className="px-2 pb-1 pt-0">
                <div className="flex flex-col gap-0.5">
                  <label className="inline-flex items-center gap-1">
                    <input
                      type="radio"
                      name="toma-inventario-mercaderia"
                      checked={modoMercaderia === "todos"}
                      onChange={() => setModoMercaderia("todos")}
                      className="accent-[#2A5590]"
                    />
                    Todos
                  </label>
                  <label className="inline-flex items-center gap-1">
                    <input
                      type="radio"
                      name="toma-inventario-mercaderia"
                      checked={modoMercaderia === "remanufacturado"}
                      onChange={() => setModoMercaderia("remanufacturado")}
                      className="accent-[#2A5590]"
                    />
                    Remanufacturado
                  </label>
                </div>
              </Fs>
            </div>

            <div className="space-y-1.5">
              <Fs legend="{ Tipo de Stock }" className="px-2 pb-1 pt-0">
                <div className="flex flex-col gap-0.5">
                  {[
                    "Todos",
                    "Todos sin Ceros",
                    "Ceros",
                    "Positivos",
                    "Negativos",
                    "Bajo el Mínimo",
                    "Bajo el Máximo",
                    "Sobra y Falta",
                  ].map((label, index) => (
                    <Radio
                      key={label}
                      name="toma-inventario-tipo-stock"
                      label={label}
                      defaultChecked={index === 0}
                    />
                  ))}
                </div>
              </Fs>

              <Fs legend="Ubicación" className="px-2 pb-1 pt-0">
                <div className="flex flex-col gap-0.5">
                  {([
                    ["todos", "Todos"],
                    ["sin", "Sin Ubicación"],
                    ["por", "Por Ubicación"],
                  ] as const).map(([value, label]) => (
                    <label key={value} className="inline-flex items-center gap-1">
                      <input
                        type="radio"
                        name="toma-inventario-ubicacion"
                        checked={ubicacion === value}
                        onChange={() => setUbicacion(value)}
                        className="accent-[#2A5590]"
                      />
                      {label}
                    </label>
                  ))}
                </div>
                <input
                  className={`${inp} h-6 w-full px-1`}
                  aria-label="Ubicación"
                  disabled={ubicacion !== "por"}
                />
              </Fs>
            </div>
          </div>

          <div className="flex flex-wrap items-center justify-center gap-2 pt-1">
            <button type="button" className={btnPrimary}>Aceptar</button>
            <button type="button" className={btn}>Cancelar</button>
            <button type="button" className={btn}>Unificado Com. y Serv.</button>
          </div>
        </Fs>
      </div>
    </WindowShell>
  );
}

export function TomaInventarioReport() {
  return <TomaInventarioReportList />;
}
