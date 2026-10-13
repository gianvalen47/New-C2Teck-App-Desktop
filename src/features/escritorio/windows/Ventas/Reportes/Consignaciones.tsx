import { Search } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  WindowShell,
  Fs,
} from "@/components/ui/desktop-primitives";

export function ReporteConsignacionList() {
  return (
    <WindowShell title="Consignación">
      <div className="flex h-full items-center justify-center text-[11.5px] text-slate-800">
        <div className="w-full max-w-[430px] px-2">
          <div className="grid grid-cols-[46px_54px_114px_57px_114px] items-center gap-x-1">
            <span className="text-right font-bold">Fechas</span>
            <label htmlFor="consignacion-fecha-desde" className="pl-1 font-bold">Del :</label>
            <input
              id="consignacion-fecha-desde"
              className={`${inp} h-6 w-[114px] px-1`}
              type="date"
              defaultValue="2026-10-01"
            />
            <label htmlFor="consignacion-fecha-hasta" className="pl-[18px] font-bold">Al :</label>
            <input
              id="consignacion-fecha-hasta"
              className={`${inp} h-6 w-[114px] px-1`}
              type="date"
              defaultValue="2026-10-10"
            />
          </div>

          <div className="mt-5 space-y-1">
            <label className="grid grid-cols-[52px_150px] items-center gap-x-[18px]">
              <span className="text-right font-bold">Oficina:</span>
              <select className={`${inp} h-6 w-[150px] px-1`}>
                <option>(Todos)</option>
              </select>
            </label>
            <label className="grid grid-cols-[52px_224px] items-center gap-x-[18px]">
              <span className="text-right font-bold">Almacén:</span>
              <select className={`${inp} h-6 w-[224px] px-1`}>
                <option>(Todos)</option>
              </select>
            </label>
          </div>

          <Fs legend="Buscar Mercadería" className="mt-5 px-2 pb-1 pt-0">
            <div className="mx-auto w-[180px]">
              <label className="inline-flex items-center gap-1.5 font-bold">
                <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                Toda Mercadería
              </label>
              <div className="flex items-center gap-1">
                <input className={`${inp} h-6 w-[150px] px-1`} aria-label="Mercadería" />
                <button type="button" className={iconBtn} aria-label="Buscar mercadería">
                  <Search className="h-3.5 w-3.5" />
                </button>
              </div>
            </div>
          </Fs>

          <Fs legend="Paginación" className="mt-3 px-2 pb-1 pt-0">
            <div className="flex justify-center">
              <label className="inline-flex items-center gap-1.5 font-bold">
                <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                Con Paginación
              </label>
            </div>
          </Fs>

          <div className="mt-4 flex justify-center gap-2">
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
