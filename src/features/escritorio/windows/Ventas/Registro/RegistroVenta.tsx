// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  WindowShell,
  Fs
} from "@/components/ui/desktop-primitives";

export function RegistroVentaList() {
  return (
    <WindowShell title="Registro de Ventas">
      <div className="w-full h-full p-4 overflow-auto flex flex-col">
        <div className="space-y-3">
        {/* Ventas Section */}
        <Fs legend="Ventas">
          <div className="space-y-2">
            <div className="flex items-center gap-2">
              <span className="text-[11px] text-slate-600 w-12">Desde :</span>
              <input className={inp} type="date" defaultValue="2026-08-01" />
            </div>
            <div className="flex items-center gap-2">
              <span className="text-[11px] text-slate-600 w-12">Hasta :</span>
              <input className={inp} type="date" defaultValue="2026-08-07" />
            </div>
          </div>
          <div className="mt-3 pt-3 border-t border-slate-200">
            <div className="text-[11px] text-slate-600 font-semibold mb-2">Impresión</div>
            <div className="grid grid-cols-2 gap-4">
              <div className="flex flex-col gap-1.5">
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="impresion_pagina" defaultChecked className="accent-[#2A5590]" />
                  <span className="text-[11px] text-slate-700">Con Página</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="impresion_pagina" className="accent-[#2A5590]" />
                  <span className="text-[11px] text-slate-700">Sin Página</span>
                </label>
              </div>
              <div className="flex flex-col gap-1.5">
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="impresion_celdas" defaultChecked className="accent-[#2A5590]" />
                  <span className="text-[11px] text-slate-700">Con Celdas</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="impresion_celdas" className="accent-[#2A5590]" />
                  <span className="text-[11px] text-slate-700">Sin Celdas</span>
                </label>
              </div>
            </div>
          </div>
        </Fs>

        {/* Buscar Cliente Section */}
        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2 mb-2">
            <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
            <span className="text-[11px] text-slate-700 font-semibold">Todo Cliente</span>
          </label>
          <div className="space-y-1">
            <span className="text-[11px] text-slate-600">Cliente</span>
            <div className="flex gap-1">
              <input className={`${inp} flex-1`} />
              <button className={iconBtn}><Search className="h-3.5 w-3.5" /></button>
            </div>
          </div>
        </Fs>

        {/* Por Documento Section */}
        <Fs legend="Por Documento">
          <div className="space-y-1">
            <span className="text-[11px] text-slate-600">Documento</span>
            <select className={inp}><option>(Todos)</option></select>
          </div>
        </Fs>

        {/* Moneda, Formato, Exportar in Grid */}
        <div className="grid grid-cols-3 gap-2">
          <Fs legend="Moneda">
            <div className="flex flex-col gap-1.5">
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="moneda_reg" defaultChecked className="accent-[#2A5590]" />
                <span className="text-[11px] text-slate-700">En Soles</span>
              </label>
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="moneda_reg" className="accent-[#2A5590]" />
                <span className="text-[11px] text-slate-700">En Dólares</span>
              </label>
            </div>
          </Fs>
          <Fs legend="Formato">
            <div className="flex flex-col gap-1.5">
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="formato_reg" defaultChecked className="accent-[#2A5590]" />
                <span className="text-[11px] text-slate-700">Antiguo</span>
              </label>
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="formato_reg" className="accent-[#2A5590]" />
                <span className="text-[11px] text-slate-700">Nuevo</span>
              </label>
            </div>
          </Fs>
          <Fs legend="Exportar">
            <div className="flex flex-col gap-1.5">
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="exportar_reg" defaultChecked className="accent-[#2A5590]" />
                <span className="text-[11px] text-slate-700">Pantalla</span>
              </label>
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="exportar_reg" className="accent-[#2A5590]" />
                <span className="text-[11px] text-slate-700">Excel</span>
              </label>
            </div>
          </Fs>
        </div>

        {/* Buttons */}
        <div className="flex justify-end gap-2 pt-2 border-t border-slate-200 mt-4">
          <button className={btn}>Cancelar</button>
          <button className={btnPrimary}>Aceptar</button>
        </div>
        </div>
      </div>
    </WindowShell>
  );
}
