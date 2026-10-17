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

export function ReporteCotizacionesList() {
  return (
    <WindowShell title="Reporte de Cotizaciones">
      <div className="flex h-full items-center justify-center overflow-auto p-2 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[430px] space-y-2 px-1 py-2">
          <div className="flex items-center justify-center gap-4">
            <div className="flex items-center gap-2">
              <label htmlFor="cotizaciones-desde" className="font-bold">Del :</label>
              <input
                id="cotizaciones-desde"
                className={`${inp} h-6 w-[100px] px-1`}
                type="date"
                defaultValue="2026-10-01"
              />
            </div>
            <div className="flex items-center gap-2">
              <label htmlFor="cotizaciones-hasta" className="font-bold">Al</label>
              <input
                id="cotizaciones-hasta"
                className={`${inp} h-6 w-[100px] px-1`}
                type="date"
                defaultValue="2026-10-15"
              />
            </div>
          </div>

          <div className="mx-auto w-[225px] space-y-1">
            <label className="grid grid-cols-[68px_152px] items-center gap-1">
              <span className="font-bold">Oficinas:</span>
              <select className={`${inp} h-6 w-[152px] px-1`}>
                <option>(Todos)</option>
              </select>
            </label>
            <label className="grid grid-cols-[68px_152px] items-center gap-1">
              <span className="font-bold">Almacén:</span>
              <select className={`${inp} h-6 w-[152px] px-1`}>
                <option>(Todos)</option>
              </select>
            </label>
          </div>

          <Fs legend="Buscar Vendedor" className="px-2 pb-1 pt-0">
            <div className="flex justify-center">
              <label className="inline-flex items-center gap-1.5 font-bold">
                <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                Todo Cliente
              </label>
            </div>
            <label className="grid grid-cols-[62px_minmax(0,1fr)_28px] items-center gap-1">
              <span className="font-bold">Cliente:</span>
              <input className={`${inp} h-6 min-w-0 px-1`} />
              <button type="button" className={iconBtn} aria-label="Buscar cliente">
                <Search className="h-3.5 w-3.5" />
              </button>
            </label>
          </Fs>

          <Fs legend="Buscar Cliente" className="px-2 pb-1 pt-0">
            <div className="flex justify-center">
              <label className="inline-flex items-center gap-1.5 font-bold">
                <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                Todo Vendedor
              </label>
            </div>
            <label className="grid grid-cols-[68px_minmax(0,1fr)] items-center gap-1">
              <span className="font-bold">Vendedor:</span>
              <select className={`${inp} h-6 min-w-0 px-1`}>
                <option></option>
                <option>(Todos)</option>
              </select>
            </label>
          </Fs>

          <div className="grid grid-cols-[minmax(0,1fr)_138px] items-center gap-1.5">
            <div className="space-y-2">
              <label className="grid grid-cols-[132px_114px] items-center gap-1">
                <span className="font-bold">Estado:</span>
                <select className={`${inp} h-6 w-[114px] px-1`}>
                  <option>(Todos)</option>
                  <option>Generados</option>
                  <option>Vencidos</option>
                  <option>Atendidos</option>
                  <option>Rechazados</option>
                </select>
              </label>
              <label className="grid grid-cols-[132px_114px] items-center gap-1">
                <span className="font-bold">Tipo de Rechazo:</span>
                <select className={`${inp} h-6 w-[114px] px-1`}>
                  <option>(Todos)</option>
                </select>
              </label>
            </div>
            <Fs legend="Opciones" className="px-2 pb-1 pt-0">
              <div className="flex flex-col gap-0.5">
                <Radio name="cotizaciones-opcion" label="Todos" defaultChecked />
                <Radio name="cotizaciones-opcion" label="Generados" />
                <Radio name="cotizaciones-opcion" label="Vencidos" />
                <Radio name="cotizaciones-opcion" label="Atendidos" />
                <Radio name="cotizaciones-opcion" label="Rechazados" />
              </div>
            </Fs>
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
