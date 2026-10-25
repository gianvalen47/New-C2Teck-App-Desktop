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

export function ReportePlanillas({ title = "Reporte de Planilla" }: { title?: string }) {
  return <ReportePlanillasList title={title} />;
}

export function ReportePlanillasList({
  title = "Reporte de Planilla",
}: {
  title?: string;
}) {
  const [todosClientes, setTodosClientes] = useState(true);
  const [tipo, setTipo] = useState<"resumido" | "detallado">("resumido");
  const [agrupado, setAgrupado] = useState<"unidad" | "banco">("unidad");

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <Fs legend="Datos de Reporte" className="w-full max-w-[395px] px-3 pb-3 pt-1">
          <Fs legend="Rango de Fechas" className="px-2 pb-1 pt-0">
            <div className="flex items-center justify-center gap-6">
              <label className="flex items-center gap-1.5">
                <span className="font-bold">Fecha Del :</span>
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

          <div className="space-y-1">
            <label className="grid grid-cols-[108px_minmax(0,1fr)] items-center gap-1">
              <span className="text-right font-bold">Cobrador :</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
            <label className="grid grid-cols-[108px_minmax(0,1fr)] items-center gap-1">
              <span className="text-right font-bold">Unidad Negocio :</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
            <label className="grid grid-cols-[108px_minmax(0,1fr)] items-center gap-1">
              <span className="text-right font-bold">Banco :</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
          </div>

          <Fs legend="Cliente" className="px-2 pb-1 pt-0">
            <label className="flex items-center justify-center gap-1.5 font-bold text-slate-400">
              <input
                type="checkbox"
                checked={todosClientes}
                onChange={(event) => setTodosClientes(event.target.checked)}
                className="accent-[#2A5590]"
              />
              Todos
            </label>
            <label className="grid grid-cols-[52px_minmax(0,1fr)_26px] items-center gap-1">
              <span className={`font-bold ${todosClientes ? "text-slate-400" : ""}`}>
                Cliente
              </span>
              <input
                className={`${inp} h-6 min-w-0 px-1`}
                defaultValue="(Todos)"
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

          <div className="grid grid-cols-2 gap-3 px-3">
            <Fs legend="Tipo" className="px-2 pb-1 pt-0">
              <div className="flex flex-col gap-0.5">
                <label className="inline-flex items-center gap-1 font-bold">
                  <input
                    type="radio"
                    name="reporte-planillas-tipo"
                    checked={tipo === "resumido"}
                    onChange={() => setTipo("resumido")}
                    className="accent-[#2A5590]"
                  />
                  Resumido
                </label>
                <label className="inline-flex items-center gap-1 font-bold">
                  <input
                    type="radio"
                    name="reporte-planillas-tipo"
                    checked={tipo === "detallado"}
                    onChange={() => setTipo("detallado")}
                    className="accent-[#2A5590]"
                  />
                  Detallado
                </label>
              </div>
            </Fs>

            <Fs
              legend="Agrupado X"
              className={`px-2 pb-1 pt-0 ${tipo !== "resumido" ? "opacity-50" : ""}`}
            >
              <div className="flex flex-col gap-0.5">
                <label className="inline-flex items-center gap-1">
                  <input
                    type="radio"
                    name="reporte-planillas-agrupado"
                    checked={agrupado === "unidad"}
                    onChange={() => setAgrupado("unidad")}
                    disabled={tipo !== "resumido"}
                    className="accent-[#2A5590]"
                  />
                  Unidad de Negocio
                </label>
                <label className="inline-flex items-center gap-1">
                  <input
                    type="radio"
                    name="reporte-planillas-agrupado"
                    checked={agrupado === "banco"}
                    onChange={() => setAgrupado("banco")}
                    disabled={tipo !== "resumido"}
                    className="accent-[#2A5590]"
                  />
                  Banco
                </label>
              </div>
            </Fs>
          </div>

          <div className="flex justify-center gap-2 pt-1">
            <button type="button" className={btnPrimary}>Aceptar</button>
            <button type="button" className={btn}>Cancelar</button>
          </div>
        </Fs>
      </div>
    </WindowShell>
  );
}
