import { useState } from "react";
import { CheckCircle2, LogOut, Search } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  iconBtn,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

type RadioOption = {
  value: string;
  label: string;
};

function RadioGroup({
  name,
  value,
  options,
  onChange,
}: {
  name: string;
  value: string;
  options: RadioOption[];
  onChange: (value: string) => void;
}) {
  return (
    <div className="flex flex-col gap-1">
      {options.map((option) => (
        <label key={option.value} className="inline-flex items-center gap-1 font-bold">
          <input
            type="radio"
            name={name}
            checked={value === option.value}
            onChange={() => onChange(option.value)}
            className="accent-[#0874c9]"
          />
          {option.label}
        </label>
      ))}
    </div>
  );
}

export function CostoVentaCostosReport({
  title = "Reporte de Costo de Venta",
}: {
  title?: string;
}) {
  const [formato, setFormato] = useState("acumulado");
  const [todasMercaderias, setTodasMercaderias] = useState(true);
  const [todoCliente, setTodoCliente] = useState(true);
  const [reporte, setReporte] = useState("inventario");
  const [exportar, setExportar] = useState("pantalla");
  const [seleccionarRubros, setSeleccionarRubros] = useState(false);

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-start justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <Fs legend="Datos del Reporte" className="w-full max-w-[525px] px-3 pb-3 pt-1">
          <div className="space-y-2">
            <div className="grid grid-cols-[minmax(0,1fr)_126px] items-start gap-3">
              <div className="space-y-1.5">
                <div className="flex items-center justify-between gap-2">
                  <label className="flex items-center gap-1">
                    <span className="font-bold">Fechas Del :</span>
                    <input
                      aria-label="Fecha desde"
                      className={`${inp} h-6 w-[98px] px-1`}
                      type="date"
                      defaultValue="2026-09-01"
                    />
                  </label>
                  <label className="flex items-center gap-1">
                    <span className="font-bold">Al :</span>
                    <input
                      aria-label="Fecha hasta"
                      className={`${inp} h-6 w-[98px] px-1`}
                      type="date"
                      defaultValue="2026-09-30"
                    />
                  </label>
                </div>

                <label className="grid grid-cols-[64px_minmax(0,1fr)] items-center gap-1">
                  <span className="font-bold">Oficina:</span>
                  <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                    <option value="all">(Todos)</option>
                  </select>
                </label>

                <label className="grid grid-cols-[64px_minmax(0,1fr)] items-center gap-1">
                  <span className={`font-bold ${formato === "detalle" ? "" : "text-slate-400"}`}>
                    Almacén:
                  </span>
                  <select
                    className={`${inp} h-6 min-w-0 px-1`}
                    defaultValue="all"
                    disabled={formato !== "detalle"}
                  >
                    <option value="all">(Todos)</option>
                  </select>
                </label>

                <label className="grid grid-cols-[64px_minmax(0,1fr)] items-center gap-1">
                  <span className="font-bold">Rubro:</span>
                  <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                    <option value="all">(Todos)</option>
                  </select>
                </label>

                <label className="ml-[68px] inline-flex items-center gap-1 font-bold">
                  <input
                    type="checkbox"
                    checked={seleccionarRubros}
                    onChange={(event) => setSeleccionarRubros(event.target.checked)}
                    className="accent-[#0874c9]"
                  />
                  Seleccionar Rubros
                </label>
              </div>

              <Fs legend="Formato" className="px-2 pb-2 pt-0">
                <RadioGroup
                  name="costo-venta-formato"
                  value={formato}
                  options={[
                    { value: "acumulado", label: "Acumulado" },
                    { value: "detalle", label: "Detalle" },
                  ]}
                  onChange={setFormato}
                />
              </Fs>
            </div>

            <div className="flex items-center justify-end gap-2 pr-[155px]">
              <span className="font-bold">Moneda :</span>
              <select
                aria-label="Moneda"
                className={`${inp} h-6 w-[60px] px-1`}
                defaultValue="PEN"
              >
                <option value="PEN">S/</option>
                <option value="USD">US$</option>
              </select>
            </div>

            <div className="grid grid-cols-[minmax(0,1fr)_178px] items-start gap-2">
              <div className="space-y-1.5">
                <Fs legend="Motivo" className="px-2 pb-2 pt-0">
                  <label className="grid grid-cols-[52px_minmax(0,1fr)] items-center gap-1">
                    <span className="font-bold">Motivo :</span>
                    <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                      <option value="all">(Todos)</option>
                    </select>
                  </label>
                </Fs>

                <Fs legend="Buscar Cliente" className="px-2 pb-2 pt-0">
                  <label className="flex items-center justify-center gap-1.5 font-bold">
                    <input
                      type="checkbox"
                      checked={todoCliente}
                      onChange={(event) => setTodoCliente(event.target.checked)}
                      className="accent-[#0874c9]"
                    />
                    Todo Cliente
                  </label>
                  <div className="grid grid-cols-[56px_minmax(0,1fr)_26px] items-center gap-1">
                    <span className={`font-bold ${todoCliente ? "text-slate-400" : ""}`}>
                      Cliente:
                    </span>
                    <input
                      aria-label="Cliente"
                      className={`${inp} h-6 min-w-0 px-1`}
                      disabled={todoCliente}
                    />
                    <button
                      type="button"
                      className={`${iconBtn} border border-slate-400/70`}
                      aria-label="Buscar cliente"
                      disabled={todoCliente}
                    >
                      <Search className="h-4 w-4" />
                    </button>
                  </div>
                </Fs>

                <Fs legend="Vendedor" className="px-2 pb-2 pt-0 opacity-60">
                  <label className="grid grid-cols-[72px_minmax(0,1fr)] items-center gap-1">
                    <span className="font-bold">Vendedor :</span>
                    <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all" disabled>
                      <option value="all">(Todos)</option>
                    </select>
                  </label>
                </Fs>
              </div>

              <div className="space-y-1.5">
                <Fs legend="Buscar Mercadería" className="px-2 pb-2 pt-0">
                  <label className="flex items-center justify-center gap-1.5 font-bold">
                    <input
                      type="checkbox"
                      checked={todasMercaderias}
                      onChange={(event) => setTodasMercaderias(event.target.checked)}
                      className="accent-[#0874c9]"
                    />
                    Toda Mercadería
                  </label>
                  <div className="grid grid-cols-[minmax(0,1fr)_26px] items-center gap-1">
                    <input
                      aria-label="Mercadería"
                      className={`${inp} h-6 min-w-0 px-1`}
                      disabled={todasMercaderias}
                    />
                    <button
                      type="button"
                      className={`${iconBtn} border border-slate-400/70`}
                      aria-label="Buscar mercadería"
                      disabled={todasMercaderias}
                    >
                      <Search className="h-4 w-4" />
                    </button>
                  </div>
                </Fs>

                <Fs legend="Reporte" className="px-2 pb-2 pt-0">
                  <RadioGroup
                    name="costo-venta-reporte"
                    value={reporte}
                    options={[
                      { value: "inventario", label: "Costo Venta de Inventario" },
                      { value: "valorizado", label: "Cos. Venta vs Val. Venta" },
                      { value: "gerencial", label: "Costo Venta Gerencial" },
                    ]}
                    onChange={setReporte}
                  />
                </Fs>

                <Fs legend="Exportar" className="mx-auto w-[116px] px-2 pb-2 pt-0">
                  <RadioGroup
                    name="costo-venta-exportar"
                    value={exportar}
                    options={[
                      { value: "pantalla", label: "Pantalla" },
                      { value: "excel", label: "Excel" },
                    ]}
                    onChange={setExportar}
                  />
                </Fs>
              </div>
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
        </Fs>
      </div>
    </WindowShell>
  );
}
