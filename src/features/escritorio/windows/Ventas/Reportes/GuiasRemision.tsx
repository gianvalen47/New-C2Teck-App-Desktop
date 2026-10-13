import { Search } from "lucide-react";
import {
  btn,
  btnPrimary,
  Fs,
  iconBtn,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

export function ReporteGuiasRemisionList() {
  return (
    <WindowShell title="Reporte de Guías Remisión">
      <div className="flex h-full items-center justify-center p-3 text-[11.5px] text-slate-800">
        <div className="w-full max-w-[430px] space-y-3 px-2 py-3">
          <div className="grid grid-cols-[42px_30px_98px_24px_98px] items-center justify-center gap-x-1">
            <span className="text-right font-bold">Fechas</span>
            <label htmlFor="fecha-desde" className="text-right font-bold">Del</label>
            <input id="fecha-desde" className={`${inp} h-6 w-[98px] px-1`} type="date" defaultValue="2026-10-01" />
            <label htmlFor="fecha-hasta" className="text-right font-bold">Al</label>
            <input id="fecha-hasta" className={`${inp} h-6 w-[98px] px-1`} type="date" defaultValue="2026-10-10" />
          </div>

          <div className="space-y-1">
            <label className="grid grid-cols-[72px_128px] items-center gap-1">
              <span className="text-right font-bold">Oficina :</span>
              <select className={`${inp} h-6 w-[128px] px-1`}>
                <option>(Todos)</option>
                <option>LIMA</option>
                <option>AREQUIPA</option>
              </select>
            </label>
            <label className="grid grid-cols-[72px_192px] items-center gap-1">
              <span className="text-right font-bold">Almacén :</span>
              <select className={`${inp} h-6 w-[192px] px-1`}>
                <option>(Todos)</option>
                <option>COMERCIAL</option>
                <option>PRINCIPAL</option>
              </select>
            </label>
          </div>

          <Fs legend="Buscar Cliente" className="px-2 pb-1 pt-0">
            <div className="flex justify-center">
              <label className="inline-flex items-center gap-1.5 text-[11.5px] font-medium text-slate-500">
                <input type="checkbox" defaultChecked disabled className="accent-[#2A5590]" />
                Todo Cliente
              </label>
            </div>
            <label className="grid grid-cols-[54px_minmax(0,1fr)_28px] items-center gap-1">
              <span className="font-bold">Cliente :</span>
              <input className={`${inp} h-6 min-w-0 px-1`} defaultValue="(Todos)" />
              <button type="button" className={iconBtn} aria-label="Buscar cliente">
                <Search className="h-3.5 w-3.5" />
              </button>
            </label>
          </Fs>

          <div className="space-y-1">
            <div className="grid grid-cols-[54px_74px_1fr_54px] items-center gap-x-1">
              <label htmlFor="moneda" className="text-right font-bold">Moneda :</label>
              <select id="moneda" className={`${inp} h-6 w-[74px] px-1`}>
                <option value=""></option>
                <option>Soles</option>
                <option>Dólares</option>
              </select>
              <label htmlFor="serie-doc" className="text-right font-bold">Serie Doc. :</label>
              <input id="serie-doc" className={`${inp} h-6 w-[52px] px-1`} />
            </div>
            <div className="grid grid-cols-[70px_minmax(0,1fr)_50px_110px] items-center gap-x-1">
              <label htmlFor="motivo" className="text-right font-bold">Motivo :</label>
              <select id="motivo" className={`${inp} h-6 min-w-0 px-1`}>
                <option>(Todos)</option>
                <option>Venta</option>
                <option>Traslado</option>
              </select>
              <label htmlFor="estado" className="text-right font-bold">Estado :</label>
              <select id="estado" className={`${inp} h-6 w-[110px] px-1`}>
                <option>(Todos)</option>
                <option>GENERADO</option>
                <option>ANULADO</option>
              </select>
            </div>
          </div>

          <div className="flex justify-center gap-2 pt-1">
            <button type="button" className={btnPrimary}>
              Aceptar
            </button>
            <button type="button" className={btn}>
              Cancelar
            </button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}
