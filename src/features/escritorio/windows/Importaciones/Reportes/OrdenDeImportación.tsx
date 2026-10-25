import { useState } from "react";
import { CheckCircle2, LogOut } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

export function ReporteOrdenImportacion({
  title = "Reporte de Pedidos",
}: {
  title?: string;
}) {
  return <ReporteOrdenImportacionList title={title} />;
}

export function ReporteOrdenImportacionList({
  title = "Reporte de Pedidos",
}: {
  title?: string;
}) {
  const [todoPedidos, setTodoPedidos] = useState(true);
  const [todasCantidades, setTodasCantidades] = useState(true);

  return (
    <WindowShell title={title}>
      <div className="flex h-full items-start justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[335px] space-y-2">
          <div className="space-y-2 px-1">
            <label className="grid grid-cols-[84px_minmax(0,1fr)] items-center gap-1">
              <span className="text-right font-bold">Oficina:</span>
              <select
                aria-label="Oficina"
                className={`${inp} h-6 w-[155px] max-w-full px-1`}
                defaultValue="lima"
              >
                <option value="lima">LIMA</option>
              </select>
            </label>
            <label className="grid grid-cols-[84px_minmax(0,1fr)] items-center gap-1">
              <span className="text-right font-bold">Almacén:</span>
              <select
                aria-label="Almacén"
                className={`${inp} h-6 w-[155px] max-w-full px-1`}
                defaultValue="all"
              >
                <option value="all">(Todos)</option>
              </select>
            </label>
            <label className="grid grid-cols-[84px_minmax(0,1fr)] items-center gap-1">
              <span className="text-right font-bold">Proveedor:</span>
              <select
                aria-label="Proveedor"
                className={`${inp} h-6 w-full px-1`}
                defaultValue="all"
              >
                <option value="all">(Todos)</option>
              </select>
            </label>
          </div>

          <Fs legend="Buscar Pedido" className="px-2 pb-2 pt-0">
            <label className="flex items-center justify-center gap-1.5 font-bold">
              <input
                type="checkbox"
                checked={todoPedidos}
                onChange={(event) => setTodoPedidos(event.target.checked)}
                className="accent-[#0874c9]"
              />
              Todo Pedidos
            </label>
            <label className="grid grid-cols-[118px_minmax(0,1fr)] items-center gap-1">
              <span className={`text-right font-bold ${todoPedidos ? "text-slate-400" : ""}`}>
                Pedido :
              </span>
              <input
                aria-label="Pedido"
                className={`${inp} h-6 w-[115px] max-w-full px-1`}
                disabled={todoPedidos}
              />
            </label>
          </Fs>

          <Fs legend="Buscar Cantidades" className="px-2 pb-2 pt-0">
            <label className="flex items-center justify-center gap-1.5 font-bold">
              <input
                type="checkbox"
                checked={todasCantidades}
                onChange={(event) => setTodasCantidades(event.target.checked)}
                className="accent-[#0874c9]"
              />
              Toda Cantidades
            </label>
            <label className="grid grid-cols-[118px_minmax(0,1fr)] items-center gap-1">
              <span className={`text-right font-bold ${todasCantidades ? "text-slate-400" : ""}`}>
                Pendientes:
              </span>
              <input
                aria-label="Cantidades pendientes desde"
                className={`${inp} h-6 w-[112px] max-w-full px-1`}
                type="date"
                defaultValue="2026-10-24"
                disabled={todasCantidades}
              />
            </label>
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
