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

export function ReporteVisCo({ title = "Reporte de Visitas del Cobrador" }: { title?: string }) {
  return <ReporteViscoList title={title} />;
}

export function ReporteViscoList({
  title = "Reporte de Visitas del Cobrador",
}: {
  title?: string;
}) {
  const [todosClientes, setTodosClientes] = useState(true);

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[410px] space-y-2 px-1 py-1">
          <Fs legend="Intervalo de Fechas" className="px-2 pb-1 pt-0">
            <div className="flex items-center justify-center gap-6">
              <label className="flex items-center gap-1.5">
                <span className="bg-white px-1 font-bold">Fecha Del :</span>
                <input
                  aria-label="Fecha desde"
                  className={`${inp} h-6 w-[98px] px-1`}
                  type="date"
                  defaultValue="2026-10-01"
                />
              </label>
              <label className="flex items-center gap-1.5">
                <span className="bg-white px-1 font-bold">Al :</span>
                <input
                  aria-label="Fecha hasta"
                  className={`${inp} h-6 w-[98px] px-1`}
                  type="date"
                  defaultValue="2026-10-24"
                />
              </label>
            </div>
          </Fs>

          <Fs legend="Cliente" className="px-2 pb-1 pt-0">
            <label className="flex items-center justify-center gap-1.5 font-bold">
              <input
                type="checkbox"
                checked={todosClientes}
                onChange={(event) => setTodosClientes(event.target.checked)}
                className="accent-[#2A5590]"
              />
              Todos
            </label>
            <label className="grid grid-cols-[58px_minmax(0,1fr)_26px] items-center gap-1">
              <span className={`font-bold ${todosClientes ? "text-slate-400" : ""}`}>
                Cliente
              </span>
              <input
                className={`${inp} h-6 min-w-0 px-1`}
                disabled={todosClientes}
              />
              <button
                type="button"
                className={`${iconBtn} border border-slate-400/70`}
                aria-label="Buscar cliente"
                disabled={todosClientes}
              >
                <Search className="h-3.5 w-3.5" />
              </button>
            </label>
          </Fs>

          <div className="grid grid-cols-[minmax(0,1fr)_112px] gap-3">
            <div className="space-y-1.5">
              <label className="grid grid-cols-[72px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Cobrador :</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                  <option value="all">(Todos)</option>
                </select>
              </label>
              <label className="grid grid-cols-[72px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Resultado :</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                  <option value="all">(Todos)</option>
                </select>
              </label>
              <label className="grid grid-cols-[72px_minmax(0,1fr)] items-center gap-1">
                <span className="font-bold">Actividad :</span>
                <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                  <option value="all">(Todos)</option>
                </select>
              </label>
            </div>

            <Fs legend="Ordenar Por" className="px-2 pb-1 pt-0">
              <div className="flex flex-col gap-0.5">
                <Radio
                  name="visita-cobrador-orden"
                  label="Fecha"
                  defaultChecked
                />
                <Radio name="visita-cobrador-orden" label="Cliente" />
                <Radio name="visita-cobrador-orden" label="Actividad" />
              </div>
            </Fs>
          </div>

          <div className="grid grid-cols-[112px_minmax(0,1fr)] items-end gap-3">
            <label className="flex flex-col gap-1">
              <span className="font-bold">Moneda :</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
            <fieldset className="flex items-end gap-2 border-0 p-0">
              <legend className="mb-1 font-bold">Importe :</legend>
              <label className="flex items-center gap-1">
                <span className="font-bold">Entre :</span>
                <input
                  className={`${inp} h-6 w-[76px] px-1 text-right`}
                  type="number"
                  defaultValue="0.00"
                  step="0.01"
                />
              </label>
              <span className="pb-1 font-bold">—</span>
              <input
                aria-label="Importe máximo"
                className={`${inp} h-6 w-[76px] px-1 text-right`}
                type="number"
                defaultValue="0.00"
                step="0.01"
              />
            </fieldset>
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
