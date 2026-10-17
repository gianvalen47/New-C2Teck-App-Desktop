// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { CircleCheck, LogOut, Search } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  WindowShell,
  Fs,
  Radio,
} from "@/components/ui/desktop-primitives";

export function ReporteDetalleDescuentoList() {
  return (
    <WindowShell title="Reporte de Venta Detallado con Descuento">
      <div className="h-full overflow-auto">
        <div className="flex min-h-full items-center justify-center p-3">
          <div className="w-full max-w-[470px] space-y-2 text-[11.5px] text-slate-800">
            <div className="grid grid-cols-[46px_30px_minmax(0,1fr)_24px_minmax(0,1fr)] items-center gap-x-1.5">
              <span className="text-right text-[13px] font-semibold">Fechas</span>
              <label htmlFor="descuento-fecha-desde" className="text-right font-semibold">Del :</label>
              <input
                id="descuento-fecha-desde"
                className={`${inp} min-w-0 w-full px-1`}
                type="date"
                defaultValue="2026-10-01"
              />
              <label htmlFor="descuento-fecha-hasta" className="text-right font-semibold">Al</label>
              <input
                id="descuento-fecha-hasta"
                className={`${inp} min-w-0 w-full px-1`}
                type="date"
                defaultValue="2026-10-10"
              />
            </div>

            <div className="grid grid-cols-[1fr_1fr] gap-x-5">
              <label className="grid grid-cols-[58px_minmax(0,1fr)] items-center gap-1.5 font-semibold">
                Oficina:
                <select className={`${inp} w-full`} defaultValue="(Todos)">
                  <option>(Todos)</option>
                </select>
              </label>
              <label className="grid grid-cols-[58px_minmax(0,1fr)] items-center gap-1.5 font-semibold">
                Almacén:
                <select className={`${inp} w-full`} defaultValue="(Todos)">
                  <option>(Todos)</option>
                </select>
              </label>
            </div>

            <Fs legend="Buscar Por Vendedor" className="!px-2 !pb-1.5 !pt-0">
              <div className="!mt-1 space-y-1">
                <label className="flex items-center gap-1.5 font-semibold">
                  <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                  Todo Vendedor
                </label>
                <div className="grid grid-cols-[76px_minmax(0,1fr)] items-center gap-1.5">
                  <label htmlFor="descuento-vendedor" className="text-[13px] font-medium text-slate-500">Vendedor:</label>
                  <select id="descuento-vendedor" className={`${inp} w-full`} defaultValue="(Todos)">
                    <option>(Todos)</option>
                  </select>
                </div>
              </div>
            </Fs>

            <Fs legend="Buscar Cliente" className="!px-2 !pb-1.5 !pt-0">
              <div className="!mt-1 space-y-1">
                <label className="flex items-center gap-1.5 font-semibold">
                  <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                  Todo Cliente
                </label>
                <div className="grid grid-cols-[76px_minmax(0,1fr)_26px] items-center gap-1">
                  <label htmlFor="descuento-cliente" className="text-[13px] font-semibold">Cliente:</label>
                  <input id="descuento-cliente" className={`${inp} w-full`} />
                  <button type="button" aria-label="Buscar cliente" className={iconBtn}>
                    <Search className="h-3.5 w-3.5" />
                  </button>
                </div>
              </div>
            </Fs>

            <div className="grid grid-cols-[1fr_145px] gap-3">
              <Fs legend="Buscar Mercadería" className="!px-2 !pb-1.5 !pt-0">
                <div className="!mt-1 space-y-1">
                  <label className="flex items-center gap-1.5 font-semibold">
                    <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                    Toda Mercadería
                  </label>
                  <div className="flex items-center gap-1">
                    <input aria-label="Mercadería" className={`${inp} min-w-0 flex-1`} />
                    <button type="button" aria-label="Buscar mercadería" className={iconBtn}>
                      <Search className="h-3.5 w-3.5" />
                    </button>
                  </div>
                </div>
              </Fs>

              <Fs legend="Imprimir" className="!px-2 !pb-1.5 !pt-0">
                <div className="!mt-1 flex flex-col gap-1">
                  <Radio name="imp" label="Pantalla" defaultChecked />
                  <Radio name="imp" label="Exportar" />
                </div>
              </Fs>
            </div>

            <div className="flex justify-center gap-2 pt-1">
              <button type="button" className={btnPrimary}>
                <CircleCheck className="h-3.5 w-3.5 text-emerald-400" />
                Aceptar
              </button>
              <button type="button" className={btn}>
                <LogOut className="h-3.5 w-3.5" />
                Cancelar
              </button>
            </div>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}

export function ReporteDetalleDescuento() {
  return <ReporteDetalleDescuentoList />;
}
