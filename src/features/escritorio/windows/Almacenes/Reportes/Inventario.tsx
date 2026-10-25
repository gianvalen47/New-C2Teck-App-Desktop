import { useState } from "react";
import { Search, ShoppingCart } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  iconBtn,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

const stockTypes = [
  "Todos",
  "Todos sin Ceros",
  "Ceros",
  "Positivos",
  "Negativos",
  "Bajo el Mínimo",
  "Bajo el Máximo",
];

function LookupField({
  label,
  checked,
  onCheckedChange,
}: {
  label: string;
  checked: boolean;
  onCheckedChange: (checked: boolean) => void;
}) {
  return (
    <Fs legend={label} className="px-2 pb-1 pt-0">
      <label className="flex items-center gap-1.5 font-bold">
        <input
          type="checkbox"
          checked={checked}
          onChange={(event) => onCheckedChange(event.target.checked)}
          className="accent-[#2A5590]"
        />
        {label === "Buscar Marca"
          ? "Toda Marca"
          : label === "Buscar Aplicación"
            ? "Toda Aplicación"
            : "Todos"}
      </label>
      <div className="grid grid-cols-[minmax(0,1fr)_26px] items-center gap-1">
        <input className={`${inp} h-6 min-w-0 px-1`} disabled={checked} aria-label={label} />
        <button
          type="button"
          className={`${iconBtn} border border-slate-400/70`}
          aria-label={`Buscar ${label.replace("Buscar ", "").toLowerCase()}`}
          disabled={checked}
        >
          <Search className="h-3.5 w-3.5" />
        </button>
      </div>
    </Fs>
  );
}

export function ReporteInventario({ title = "Reporte de Inventario" }: { title?: string }) {
  return <ReporteInventarioList title={title} />;
}

export function ReporteInventarioList({
  title = "Reporte de Inventario",
}: {
  title?: string;
}) {
  const [tipoReporte, setTipoReporte] = useState("Detallado");
  const [seleccionarRubros, setSeleccionarRubros] = useState(false);
  const [ordenarPorUbicacion, setOrdenarPorUbicacion] = useState(false);
  const [todaMarca, setTodaMarca] = useState(true);
  const [todaAplicacion, setTodaAplicacion] = useState(true);
  const [tipoStock, setTipoStock] = useState("Todos");
  const [mostrarStock, setMostrarStock] = useState("Físico");
  const [ubicacion, setUbicacion] = useState("Todos");

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[700px] space-y-2 px-1 py-1">
          <Fs legend="Tipo" className="mx-auto w-[320px] px-2 pb-1 pt-0">
            <div className="flex justify-center gap-5">
              {["Detallado", "Resumen", "Comprometidos"].map((option) => (
                <label key={option} className="inline-flex items-center gap-1 font-bold">
                  <input
                    type="radio"
                    name="reporte-inventario-tipo"
                    checked={tipoReporte === option}
                    onChange={() => setTipoReporte(option)}
                    className="accent-[#2A5590]"
                  />
                  {option}
                </label>
              ))}
            </div>
          </Fs>

          <Fs legend="Inventario" className="px-2 pb-2 pt-0">
            <div className="grid grid-cols-[1.25fr_0.95fr_0.9fr] items-start gap-3">
              <div className="space-y-1.5">
                <label className="grid grid-cols-[102px_minmax(0,1fr)] items-center gap-1">
                  <span className="font-bold">Stock a la Fecha:</span>
                  <input
                    aria-label="Stock a la Fecha"
                    className={`${inp} h-6 min-w-0 px-1`}
                    type="date"
                    defaultValue="2026-10-24"
                  />
                </label>
                <label className="grid grid-cols-[102px_minmax(0,1fr)] items-center gap-1">
                  <span className="font-bold">Unidad:</span>
                  <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="COMERCIAL">
                    <option value="COMERCIAL">COMERCIAL</option>
                  </select>
                </label>
                <label className="grid grid-cols-[102px_minmax(0,1fr)] items-center gap-1">
                  <span className="font-bold">Oficina:</span>
                  <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="IQUITOS">
                    <option value="IQUITOS">IQUITOS</option>
                  </select>
                </label>
                <label className="grid grid-cols-[102px_minmax(0,1fr)] items-center gap-1">
                  <span className="font-bold">Almacén:</span>
                  <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="COMERCIAL">
                    <option value="COMERCIAL">COMERCIAL</option>
                  </select>
                </label>
                <label className="grid grid-cols-[102px_minmax(0,1fr)] items-center gap-1">
                  <span className="font-bold">Rubro:</span>
                  <select
                    className={`${inp} h-6 min-w-0 px-1`}
                    defaultValue="all"
                    disabled={seleccionarRubros}
                  >
                    <option value="all">(Todos)</option>
                  </select>
                </label>
                <label className="col-start-2 flex items-center gap-1.5 font-bold">
                  <input
                    type="checkbox"
                    checked={seleccionarRubros}
                    onChange={(event) => setSeleccionarRubros(event.target.checked)}
                    className="accent-[#2A5590]"
                  />
                  Seleccionar Rubros
                </label>
                <label className="grid grid-cols-[102px_minmax(0,1fr)] items-center gap-1">
                  <span className="font-bold">Ubicación:</span>
                  <input className={`${inp} h-6 min-w-0 px-1`} />
                </label>
                <label className="grid grid-cols-[102px_minmax(0,1fr)] items-center gap-1">
                  <span className="font-bold">Clase:</span>
                  <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="">
                    <option value=""></option>
                    <option value="all">(Todos)</option>
                  </select>
                </label>
                <label className="grid grid-cols-[102px_minmax(0,1fr)] items-center gap-1">
                  <span className="font-bold">{"{ Tipo Mov }"}</span>
                  <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                    <option value="all">(Todos)</option>
                  </select>
                </label>
                <label className="grid grid-cols-[102px_minmax(0,1fr)] items-center gap-1">
                  <span className="font-bold">{"{ Ciclos }"}</span>
                  <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                    <option value="all">(Todos)</option>
                  </select>
                </label>
                <label className="grid grid-cols-[102px_minmax(0,1fr)] items-center gap-1">
                  <span className="font-bold">{"{ Tipo Motor }"}</span>
                  <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                    <option value="all">(Todos)</option>
                  </select>
                </label>
              </div>

              <div className="space-y-1.5">
                <label className="flex items-center gap-1.5 px-2 font-bold">
                  <input
                    type="checkbox"
                    checked={ordenarPorUbicacion}
                    onChange={(event) => setOrdenarPorUbicacion(event.target.checked)}
                    className="accent-[#2A5590]"
                  />
                  Por Ubicación
                </label>

                <Fs legend="Mostrar Stock" className="px-2 pb-1 pt-0">
                  <div className="flex flex-col gap-0.5">
                    {["Con Stock", "Sin Stock", "Físico", "Con Disponible", "Sin Disponible"].map((option) => (
                      <label key={option} className="inline-flex items-center gap-1">
                        <input
                          type="radio"
                          name="reporte-inventario-mostrar-stock"
                          checked={mostrarStock === option}
                          onChange={() => setMostrarStock(option)}
                          className="accent-[#2A5590]"
                        />
                        {option}
                      </label>
                    ))}
                  </div>
                </Fs>

                <LookupField
                  label="Buscar Aplicación"
                  checked={todaAplicacion}
                  onCheckedChange={setTodaAplicacion}
                />
                <LookupField
                  label="Buscar Marca"
                  checked={todaMarca}
                  onCheckedChange={setTodaMarca}
                />
                <Fs legend="Buscar Mercadería" className="px-2 pb-1 pt-0">
                  <div className="flex flex-col gap-0.5">
                    <Radio
                      name="reporte-inventario-mercaderia"
                      label="Todos"
                      defaultChecked
                    />
                    <Radio
                      name="reporte-inventario-mercaderia"
                      label="Remanufacturado"
                    />
                  </div>
                </Fs>
              </div>

              <div className="space-y-1.5">
                <Fs legend="{ Tipo de Stock }" className="px-2 pb-1 pt-0">
                  <div className="flex flex-col gap-0.5">
                    {stockTypes.map((option) => (
                      <label key={option} className="inline-flex items-center gap-1">
                        <input
                          type="radio"
                          name="reporte-inventario-tipo-stock"
                          checked={tipoStock === option}
                          onChange={() => setTipoStock(option)}
                          className="accent-[#2A5590]"
                        />
                        {option}
                      </label>
                    ))}
                  </div>
                </Fs>
                <Fs legend="Ubicación" className="px-2 pb-1 pt-0">
                  <div className="flex flex-col gap-0.5">
                    {["Todos", "Sin Ubicación", "Por Ubicación"].map((option) => (
                      <label key={option} className="inline-flex items-center gap-1">
                        <input
                          type="radio"
                          name="reporte-inventario-ubicacion"
                          checked={ubicacion === option}
                          onChange={() => setUbicacion(option)}
                          className="accent-[#2A5590]"
                        />
                        {option}
                      </label>
                    ))}
                  </div>
                  <input
                    className={`${inp} h-6 w-full px-1`}
                    aria-label="Ubicación"
                    disabled={ubicacion !== "Por Ubicación"}
                  />
                </Fs>
              </div>
            </div>

            <div className="mt-2 grid grid-cols-[1.2fr_0.8fr_1.2fr] items-center gap-2">
              <Fs legend="Buscar Proveedor" className="px-2 pb-1 pt-0">
                <label className="flex items-center justify-center gap-1.5 font-bold">
                  <input
                    type="checkbox"
                    checked={todoProveedor}
                    onChange={(event) => setTodoProveedor(event.target.checked)}
                    className="accent-[#2A5590]"
                  />
                  Todo Proveedor
                </label>
                <div className="grid grid-cols-[minmax(0,1fr)_26px] items-center gap-1">
                  <input
                    className={`${inp} h-6 min-w-0 px-1`}
                    defaultValue="(Todos)"
                    disabled={todoProveedor}
                    aria-label="Proveedor"
                  />
                  <button
                    type="button"
                    className={`${iconBtn} border border-slate-400/70`}
                    aria-label="Buscar proveedor"
                    disabled={todoProveedor}
                  >
                    <Search className="h-3.5 w-3.5" />
                  </button>
                </div>
              </Fs>

              <div className="flex justify-center">
                <button type="button" className={btn}>
                  <ShoppingCart className="h-3.5 w-3.5" />
                  Compras Anuales
                </button>
              </div>

              <Fs legend="Exportar" className="px-2 pb-1 pt-0">
                <div className="grid grid-cols-2 gap-x-2 gap-y-0.5">
                  <Radio
                    name="reporte-inventario-exportar"
                    label="Pantalla"
                    defaultChecked
                  />
                  <Radio name="reporte-inventario-exportar" label="Excel" />
                  <div className="col-span-2">
                    <Radio
                      name="reporte-inventario-exportar"
                      label="Inventario General Excel"
                    />
                  </div>
                </div>
              </Fs>
            </div>
          </Fs>

          <div className="flex justify-center gap-2">
            <button type="button" className={btnPrimary}>Aceptar</button>
            <button type="button" className={btn}>Cancelar</button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}
