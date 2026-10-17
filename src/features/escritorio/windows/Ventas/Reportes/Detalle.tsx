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

export function ReporteVentasDetalladoList() {
  const [todoVendedor, setTodoVendedor] = useState(true);
  const [todoCliente, setTodoCliente] = useState(true);
  const [todaMercaderia, setTodaMercaderia] = useState(true);
  const [agrupadoPor, setAgrupadoPor] = useState<"cliente" | "mercaderia">("cliente");
  const [exportar, setExportar] = useState(false);

  return (
    <WindowShell title="Reporte de Ventas Detallado">
      <div className="flex h-full items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="flex w-full max-w-[510px] flex-col gap-1.5 px-1 py-1">
          <div className="flex items-center justify-center gap-5">
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
                defaultValue="2026-10-15"
              />
            </label>
          </div>

          <div className="grid grid-cols-2 gap-x-5 gap-y-1">
            <label className="grid grid-cols-[80px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Oficina:</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
            <label className="grid grid-cols-[75px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Almacén:</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
            <label className="grid grid-cols-[80px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Rubro:</span>
              <select className={`${inp} h-6 min-w-0 px-1`} defaultValue="all">
                <option value="all">(Todos)</option>
              </select>
            </label>
          </div>

          <Fs legend="Buscar Por Vendedor" className="px-2 pb-1 pt-0">
            <label className="flex items-center gap-1.5 font-bold">
              <input
                type="checkbox"
                checked={todoVendedor}
                onChange={(event) => setTodoVendedor(event.target.checked)}
                className="accent-[#2A5590]"
              />
              Todo Vendedor
            </label>
            <label className="grid grid-cols-[68px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Vendedor:</span>
              <select
                className={`${inp} h-6 min-w-0 px-1`}
                defaultValue="all"
                disabled={todoVendedor}
              >
                <option value="all">(Todos)</option>
              </select>
            </label>
          </Fs>

          <Fs legend="Buscar Cliente" className="px-2 pb-1 pt-0">
            <label className="flex items-center gap-1.5 font-bold">
              <input
                type="checkbox"
                checked={todoCliente}
                onChange={(event) => setTodoCliente(event.target.checked)}
                className="accent-[#2A5590]"
              />
              Todo Cliente
            </label>
            <label className="grid grid-cols-[68px_minmax(0,1fr)_28px] items-center gap-1">
              <span className="font-bold">Cliente:</span>
              <input
                className={`${inp} h-6 min-w-0 px-1`}
                disabled={todoCliente}
              />
              <button
                type="button"
                className={`${iconBtn} border border-slate-400/70`}
                aria-label="Buscar cliente"
                disabled={todoCliente}
              >
                <Search className="h-3.5 w-3.5" />
              </button>
            </label>
            <label className="ml-10 grid max-w-[300px] grid-cols-[98px_minmax(0,1fr)] items-center gap-1 text-slate-500">
              <span className="font-bold">Locación Cliente</span>
              <select
                className={`${inp} h-5 min-w-0 px-1`}
                disabled={todoCliente}
              >
                <option>0</option>
              </select>
            </label>
          </Fs>

          <div className="grid grid-cols-[1.15fr_0.85fr] gap-1.5">
            <Fs legend="Buscar Mercadería" className="px-2 pb-1 pt-0">
              <label className="flex items-center gap-1.5 font-bold">
                <input
                  type="checkbox"
                  checked={todaMercaderia}
                  onChange={(event) => setTodaMercaderia(event.target.checked)}
                  className="accent-[#2A5590]"
                />
                Toda Mercadería
              </label>
              <div className="grid grid-cols-[minmax(0,1fr)_28px] items-center gap-1">
                <input
                  className={`${inp} h-6 min-w-0 px-1`}
                  disabled={todaMercaderia}
                />
                <button
                  type="button"
                  className={`${iconBtn} border border-slate-400/70`}
                  aria-label="Buscar mercadería"
                  disabled={todaMercaderia}
                >
                  <Search className="h-3.5 w-3.5" />
                </button>
              </div>
            </Fs>

            <Fs legend="Tipo Reporte" className="px-2 pb-1 pt-0">
              <div className="flex flex-col gap-0.5">
                <Radio
                  name="reporte-ventas-detallado-tipo"
                  label="Detallado"
                  defaultChecked
                />
                <Radio
                  name="reporte-ventas-detallado-tipo"
                  label="Detallado Unitario"
                />
                <Radio name="reporte-ventas-detallado-tipo" label="Resumen" />
              </div>
            </Fs>
          </div>

          <div className="grid grid-cols-[0.92fr_1.18fr] gap-1.5">
            <Fs legend="Documentos" className="px-2 pb-1 pt-0">
              <div className="flex flex-col gap-0.5">
                <Radio
                  name="reporte-ventas-detallado-documentos"
                  label="Todos"
                  defaultChecked
                />
                <Radio
                  name="reporte-ventas-detallado-documentos"
                  label="Facturación"
                />
                <Radio
                  name="reporte-ventas-detallado-documentos"
                  label="Facturados sin Exportaciones"
                />
                <Radio
                  name="reporte-ventas-detallado-documentos"
                  label="Exportaciones"
                />
              </div>
            </Fs>

            <Fs legend="Reporte Agrupado" className="px-2 pb-1 pt-0">
              <div className="grid grid-cols-[70px_minmax(0,1fr)] items-stretch gap-1">
                <div className="grid grid-rows-2 items-center gap-1 py-1">
                  <label className="inline-flex items-center gap-1">
                    <input
                      type="radio"
                      name="reporte-ventas-detallado-agrupado"
                      checked={agrupadoPor === "cliente"}
                      onChange={() => setAgrupadoPor("cliente")}
                      className="accent-[#2A5590]"
                    />
                    Cliente
                  </label>
                  <label className="inline-flex items-center gap-1">
                    <input
                      type="radio"
                      name="reporte-ventas-detallado-agrupado"
                      checked={agrupadoPor === "mercaderia"}
                      onChange={() => setAgrupadoPor("mercaderia")}
                      className="accent-[#2A5590]"
                    />
                    Mercadería
                  </label>
                </div>
                <div className="space-y-1">
                  <Fs legend="Ordenar por :" className="px-1 pb-1 pt-0">
                    <div className="flex gap-2">
                      <label className={`inline-flex items-center gap-1 ${agrupadoPor !== "cliente" ? "text-slate-400" : ""}`}>
                        <input
                          type="radio"
                          name="reporte-ventas-detallado-orden-cliente"
                          defaultChecked
                          disabled={agrupadoPor !== "cliente"}
                          className="accent-[#2A5590]"
                        />
                        Fecha
                      </label>
                      <label className={`inline-flex items-center gap-1 ${agrupadoPor !== "cliente" ? "text-slate-400" : ""}`}>
                        <input
                          type="radio"
                          name="reporte-ventas-detallado-orden-cliente"
                          disabled={agrupadoPor !== "cliente"}
                          className="accent-[#2A5590]"
                        />
                        Mercadería
                      </label>
                    </div>
                  </Fs>
                  <Fs legend="Ordenar por :" className="px-1 pb-1 pt-0">
                    <div className="flex gap-2">
                      <label className={`inline-flex items-center gap-1 ${agrupadoPor !== "mercaderia" ? "text-slate-400" : ""}`}>
                        <input
                          type="radio"
                          name="reporte-ventas-detallado-orden-mercaderia"
                          defaultChecked
                          disabled={agrupadoPor !== "mercaderia"}
                          className="accent-[#2A5590]"
                        />
                        Fecha
                      </label>
                      <label className={`inline-flex items-center gap-1 ${agrupadoPor !== "mercaderia" ? "text-slate-400" : ""}`}>
                        <input
                          type="radio"
                          name="reporte-ventas-detallado-orden-mercaderia"
                          disabled={agrupadoPor !== "mercaderia"}
                          className="accent-[#2A5590]"
                        />
                        Cliente
                      </label>
                    </div>
                  </Fs>
                </div>
              </div>
            </Fs>
          </div>

          <div className="flex items-end justify-between gap-2">
            <Fs legend="Exportar" className="px-2 pb-1 pt-0">
              <div className="flex items-start gap-2">
                <div className="flex flex-col gap-0.5">
                  <label className="inline-flex items-center gap-1">
                    <input
                      type="radio"
                      name="reporte-ventas-detallado-exportar"
                      checked={!exportar}
                      onChange={() => setExportar(false)}
                      className="accent-[#2A5590]"
                    />
                    Pantalla
                  </label>
                  <label className="inline-flex items-center gap-1">
                    <input
                      type="radio"
                      name="reporte-ventas-detallado-exportar"
                      checked={exportar}
                      onChange={() => setExportar(true)}
                      className="accent-[#2A5590]"
                    />
                    Exportar
                  </label>
                </div>
                <Fs legend="" className="px-1 pb-1 pt-0">
                  <div className="flex flex-col gap-0.5">
                    <label className={`inline-flex items-center gap-1 ${!exportar ? "text-slate-400" : ""}`}>
                      <input
                        type="radio"
                        name="reporte-ventas-detallado-formato"
                        defaultChecked
                        disabled={!exportar}
                        className="accent-[#2A5590]"
                      />
                      Detallado
                    </label>
                    <label className={`inline-flex items-center gap-1 ${!exportar ? "text-slate-400" : ""}`}>
                      <input
                        type="radio"
                        name="reporte-ventas-detallado-formato"
                        disabled={!exportar}
                        className="accent-[#2A5590]"
                      />
                      Resumido
                    </label>
                  </div>
                </Fs>
              </div>
            </Fs>

            <div className="flex justify-center gap-2 pb-1">
              <button type="button" className={btnPrimary}>
                Aceptar
              </button>
              <button type="button" className={btn}>
                Cancelar
              </button>
            </div>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}
