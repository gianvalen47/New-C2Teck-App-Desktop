import { Search } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  WindowShell,
  Fs,
  Radio,
} from "@/components/ui/desktop-primitives";

export function ReporteAcumuladaList() {
  return (
    <WindowShell title="Reporte de Ventas Acumuladas">
      <div className="flex h-full items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[470px] space-y-2 px-1 py-2">
          <Fs legend="Rango de Fechas" className="px-2 pb-1 pt-0">
            <div className="flex justify-center">
              <div className="flex items-center gap-6">
                <div className="flex items-center gap-2">
                  <label htmlFor="acumulada-desde" className="font-bold">Del</label>
                  <input
                    id="acumulada-desde"
                    className={`${inp} h-6 w-[100px] px-1`}
                    type="date"
                    defaultValue="2026-10-01"
                  />
                </div>
                <div className="flex items-center gap-2">
                  <label htmlFor="acumulada-hasta" className="font-bold">Al</label>
                  <input
                    id="acumulada-hasta"
                    className={`${inp} h-6 w-[100px] px-1`}
                    type="date"
                    defaultValue="2026-10-15"
                  />
                </div>
              </div>
            </div>
          </Fs>

          <div className="grid grid-cols-2 gap-x-5 gap-y-1">
            <label className="grid grid-cols-[68px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Oficina</span>
              <select className={`${inp} h-6 min-w-0 px-1`}><option>(Todos)</option></select>
            </label>
            <label className="grid grid-cols-[58px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Almacén</span>
              <select className={`${inp} h-6 min-w-0 px-1`}><option>(Todos)</option></select>
            </label>
            <label className="grid grid-cols-[68px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Rubro</span>
              <select className={`${inp} h-6 min-w-0 px-1`}><option>(Todos)</option></select>
            </label>
            <label className="grid grid-cols-[58px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Motivo</span>
              <select className={`${inp} h-6 min-w-0 px-1`}><option>(Todos)</option></select>
            </label>
            <label className="col-span-2 grid grid-cols-[68px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Vendedor</span>
              <select className={`${inp} h-6 min-w-0 px-1`}><option>(Todos)</option></select>
            </label>
          </div>

          <Fs legend="Buscar Cliente" className="px-2 pb-1 pt-0">
            <div className="flex justify-center">
              <label className="inline-flex items-center gap-1.5 font-bold">
                <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                Todo Cliente
              </label>
            </div>
            <label className="grid grid-cols-[50px_minmax(0,1fr)_28px] items-center gap-1">
              <span className="font-bold">Cliente</span>
              <input className={`${inp} h-6 min-w-0 px-1`} />
              <button type="button" className={iconBtn} aria-label="Buscar cliente">
                <Search className="h-3.5 w-3.5" />
              </button>
            </label>
          </Fs>

          <div className="grid grid-cols-[1.1fr_0.8fr_1.05fr] gap-1.5">
            <Fs legend="Acumulado X" className="px-2 pb-1 pt-0">
              <div className="flex flex-col gap-1">
                <Radio name="acumulada-por" label="Mercadería" defaultChecked />
                <Radio name="acumulada-por" label="Cliente" />
                <Radio name="acumulada-por" label="Año" />
                <Radio name="acumulada-por" label="Cantidades Vendidas" />
              </div>
            </Fs>

            <Fs legend="Ordenado X" className="px-2 pb-1 pt-0">
              <div className="flex flex-col gap-1">
                <Radio name="acumulada-orden" label="Descripción" defaultChecked />
                <Radio name="acumulada-orden" label="Dólares" />
                <Radio name="acumulada-orden" label="Soles" />
              </div>
            </Fs>

            <div className="space-y-1.5">
              <Fs legend="Buscar Marca" className="px-2 pb-1 pt-0">
                <label className="inline-flex items-center gap-1 font-bold">
                  <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                  Buscar Marca
                </label>
                <div className="flex items-center gap-1">
                  <input className={`${inp} h-6 min-w-0 flex-1 px-1`} aria-label="Marca" />
                  <button type="button" className={iconBtn} aria-label="Buscar marca">
                    <Search className="h-3.5 w-3.5" />
                  </button>
                </div>
              </Fs>
              <Fs legend="Tipo Orden" className="px-2 pb-1 pt-0">
                <div className="flex flex-col gap-1">
                  <Radio name="acumulada-tipo-orden" label="Ascendente" defaultChecked />
                  <Radio name="acumulada-tipo-orden" label="Descendente" />
                </div>
              </Fs>
            </div>
          </div>

          <Fs legend="Exportar" className="mx-auto w-[205px] px-2 pb-1 pt-0">
            <div className="flex justify-center gap-4">
              <Radio name="acumulada-exportar" label="Pantalla" defaultChecked />
              <Radio name="acumulada-exportar" label="Excel" />
            </div>
          </Fs>

          <div className="flex justify-center gap-2 pt-1">
            <button type="button" className={btnPrimary}>Aceptar</button>
            <button type="button" className={btn}>Cancelar</button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}
