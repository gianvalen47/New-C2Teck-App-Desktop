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

export function KardexCostosReport({
  title = "Kardex de Almacén",
}: {
  title?: string;
}) {
  const [todaClase, setTodaClase] = useState(true);
  const [todoCliente, setTodoCliente] = useState(true);

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-start justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[390px] space-y-2">
          <div className="flex items-center justify-between gap-2 px-1">
            <label className="flex items-center gap-1.5">
              <span className="font-bold">Del :</span>
              <input
                aria-label="Fecha desde"
                className={`${inp} h-6 w-[98px] px-1`}
                type="date"
                defaultValue="2026-09-01"
              />
            </label>
            <label className="flex items-center gap-1.5">
              <span className="font-bold">Al :</span>
              <input
                aria-label="Fecha hasta"
                className={`${inp} h-6 w-[98px] px-1`}
                type="date"
                defaultValue="2026-09-30"
              />
            </label>
          </div>

          <div className="space-y-1 px-1">
            <label className="grid grid-cols-[74px_minmax(0,1fr)] items-center gap-1">
              <span className="text-right font-bold">Oficina</span>
              <select
                aria-label="Oficina"
                className={`${inp} h-6 w-[150px] max-w-full px-1`}
                defaultValue="iquitos"
              >
                <option value="iquitos">IQUITOS</option>
              </select>
            </label>
            <label className="grid grid-cols-[74px_minmax(0,1fr)] items-center gap-1">
              <span className="text-right font-bold">Almacén</span>
              <select
                aria-label="Almacén"
                className={`${inp} h-6 w-full px-1`}
                defaultValue="comercial"
              >
                <option value="comercial">COMERCIAL</option>
              </select>
            </label>
            <label className="grid grid-cols-[74px_minmax(0,1fr)_26px] items-center gap-1">
              <span className="text-right font-bold">Artículo</span>
              <input
                aria-label="Artículo"
                className={`${inp} h-6 min-w-0 px-1`}
              />
              <button
                type="button"
                className={`${iconBtn} border border-slate-400/70`}
                aria-label="Buscar artículo"
              >
                <Search className="h-4 w-4" />
              </button>
            </label>
            <label className="grid grid-cols-[74px_minmax(0,1fr)] items-center gap-1">
              <span className="text-right font-bold">Moneda</span>
              <select
                aria-label="Moneda"
                className={`${inp} h-6 w-[60px] px-1`}
                defaultValue="USD"
              >
                <option value="USD">USD</option>
                <option value="PEN">S/</option>
              </select>
            </label>
          </div>

          <Fs legend="Buscar Clase" className="px-2 pb-2 pt-0">
            <label className="flex items-center justify-center gap-1.5 font-bold">
              <input
                type="checkbox"
                checked={todaClase}
                onChange={(event) => setTodaClase(event.target.checked)}
                className="accent-[#0874c9]"
              />
              Toda Clase
            </label>
            <div className="grid grid-cols-[54px_minmax(0,1fr)_26px] items-center gap-1">
              <span className={`text-right font-bold ${todaClase ? "text-slate-400" : ""}`}>
                Clase :
              </span>
              <input
                aria-label="Clase"
                className={`${inp} h-6 min-w-0 px-1`}
                disabled={todaClase}
              />
              <button
                type="button"
                className={`${iconBtn} border border-slate-400/70`}
                aria-label="Buscar clase"
                disabled={todaClase}
              >
                <Search className="h-4 w-4" />
              </button>
            </div>
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
            <div className="grid grid-cols-[54px_minmax(0,1fr)_26px] items-center gap-1">
              <span className={`text-right font-bold ${todoCliente ? "text-slate-400" : ""}`}>
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