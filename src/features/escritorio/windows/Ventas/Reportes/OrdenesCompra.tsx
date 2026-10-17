// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { CircleCheck, LogOut, Search } from "lucide-react";
import { useState } from "react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  WindowShell,
  Fs,
  Radio,
} from "@/components/ui/desktop-primitives";

export function ReporteOrdenCompra() {
  return <ReporteOrdenCompraList />;
}

export function ReporteOrdenCompraList() {
  const [tipoReporte, setTipoReporte] = useState<"totalizado" | "detallado" | "atendidos">("totalizado");
  const isDetallado = tipoReporte === "detallado";

  return (
    <WindowShell title="Reporte de Orden de Compra">
      <div className="h-full overflow-auto">
        <div className="flex min-h-full items-center justify-center p-2">
          <div className="w-full max-w-[540px] space-y-2 text-[11.5px] text-slate-800">
            <div className="grid grid-cols-[minmax(0,1fr)_185px] gap-x-3">
              <div className="space-y-1.5">
                <div className="grid grid-cols-[54px_30px_minmax(0,1fr)_25px_minmax(0,1fr)] items-center gap-x-1">
                  <span className="text-right text-[13px] font-semibold">Fechas</span>
                  <label htmlFor="orden-fecha-desde" className="text-right font-semibold">Del :</label>
                  <input id="orden-fecha-desde" aria-label="Fecha desde" className={`${inp} min-w-0 w-full px-1`} type="date" defaultValue="2026-10-01" />
                  <label htmlFor="orden-fecha-hasta" className="text-right font-semibold">Al :</label>
                  <input id="orden-fecha-hasta" className={`${inp} min-w-0 w-full px-1`} type="date" defaultValue="2026-10-10" />
                </div>

                <div className="grid grid-cols-[70px_minmax(0,1fr)] items-center gap-x-2 gap-y-2">
                  <label htmlFor="orden-oficina" className="text-right font-semibold">Oficina:</label>
                  <select id="orden-oficina" className={`${inp} w-full`} defaultValue="LIMA">
                    <option>LIMA</option>
                  </select>
                  <label htmlFor="orden-almacen" className="text-right font-semibold">Almacén:</label>
                  <select id="orden-almacen" className={`${inp} w-full`} defaultValue="0">
                    <option>0</option>
                    <option>COMERCIAL</option>
                  </select>
                  <label htmlFor="orden-estados" className="text-right font-semibold">Estados:</label>
                  <select id="orden-estados" className={`${inp} w-full`} defaultValue="(Todos)">
                    <option>(Todos)</option>
                  </select>
                  <label htmlFor="orden-rubros" className="text-right font-semibold">Rubros:</label>
                  <select id="orden-rubros" className={`${inp} w-full`} defaultValue="(Todos)">
                    <option>(Todos)</option>
                  </select>
                </div>
              </div>

              <Fs legend="Tipo" className="!px-2 !pb-1.5 !pt-0">
                <div className="!mt-1 space-y-1.5">
                  <div className="flex flex-col items-start gap-1">
                    <label className="inline-flex items-center gap-1 text-[11.5px] text-slate-800">
                      <input
                        type="radio"
                        name="tipo"
                        checked={tipoReporte === "totalizado"}
                        onChange={() => setTipoReporte("totalizado")}
                        className="accent-[#2A5590]"
                      />
                      Totalizado
                    </label>
                    <label className="inline-flex items-center gap-1 text-[11.5px] text-slate-800">
                      <input
                        type="radio"
                        name="tipo"
                        checked={isDetallado}
                        onChange={() => setTipoReporte("detallado")}
                        className="accent-[#2A5590]"
                      />
                      Detallado
                    </label>
                  </div>
                  <fieldset disabled={!isDetallado} className="ml-3 rounded-sm border border-[#7A96B4] px-2 pb-1 pt-0 disabled:opacity-50">
                    <legend className="px-1 text-[10.5px] font-bold text-slate-700">Condición</legend>
                    <div className="flex flex-col gap-0.5">
                      <label className="inline-flex items-center gap-1 text-[11.5px] text-slate-800">
                        <input type="radio" name="cond" className="accent-[#2A5590]" />
                        Separado
                      </label>
                      <label className="inline-flex items-center gap-1 text-[11.5px] text-slate-800">
                        <input type="radio" name="cond" className="accent-[#2A5590]" />
                        Todos
                      </label>
                    </div>
                  </fieldset>
                  <label className="inline-flex items-center gap-1 text-[11.5px] text-slate-800">
                    <input
                      type="radio"
                      name="tipo"
                      checked={tipoReporte === "atendidos"}
                      onChange={() => setTipoReporte("atendidos")}
                      className="accent-[#2A5590]"
                    />
                    Atendidos
                  </label>
                </div>
              </Fs>
            </div>

            <Fs legend="Buscar Mercadería" className={`!px-2 !pb-1.5 !pt-0 ${isDetallado ? "" : "opacity-60"}`}>
              <div className="!mt-1 space-y-1">
                <label className="flex items-center gap-1.5">
                  <input type="checkbox" defaultChecked disabled={!isDetallado} className="accent-[#2A5590]" />
                  Todo Mercadería
                </label>
                <div className="grid grid-cols-[110px_minmax(0,1fr)_26px] items-center gap-1">
                  <label htmlFor="orden-mercaderia" className="text-[13px] font-medium">Mercadería :</label>
                  <input id="orden-mercaderia" className={`${inp} w-full`} disabled={!isDetallado} />
                  <button type="button" aria-label="Buscar mercadería" className={iconBtn} disabled={!isDetallado}>
                    <Search className="h-3.5 w-3.5" />
                  </button>
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
                  <label htmlFor="orden-cliente" className="text-[13px] font-semibold">Cliente:</label>
                  <input id="orden-cliente" className={`${inp} w-full`} />
                  <button type="button" aria-label="Buscar cliente" className={iconBtn}>
                    <Search className="h-3.5 w-3.5" />
                  </button>
                </div>
              </div>
            </Fs>

            <Fs legend="Buscar Vendedor" className="!px-2 !pb-1.5 !pt-0">
              <div className="!mt-1 space-y-1">
                <label className="flex items-center gap-1.5 font-semibold">
                  <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                  Todo Vendedor
                </label>
                <div className="grid grid-cols-[84px_minmax(0,1fr)] items-center gap-2">
                  <label htmlFor="orden-vendedor" className="text-[13px] font-semibold">Vendedor:</label>
                  <select id="orden-vendedor" className={inp} defaultValue="">
                    <option value=""></option>
                    <option>(Todos)</option>
                  </select>
                </div>
              </div>
            </Fs>

            <Fs legend="Exportar" className="!px-2 !pb-1 !pt-0">
              <div className="!mt-0 flex min-h-[28px] items-center justify-center gap-8">
                <Radio name="exp" label="Pantalla" defaultChecked />
                <Radio name="exp" label="Excel" />
              </div>
            </Fs>

            <div className="flex justify-center gap-2 pt-1">
              <button type="button" className={btnPrimary}><CircleCheck className="h-3.5 w-3.5 text-emerald-400" />Aceptar</button>
              <button type="button" className={btn}><LogOut className="h-3.5 w-3.5" />Cancelar</button>
            </div>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}
