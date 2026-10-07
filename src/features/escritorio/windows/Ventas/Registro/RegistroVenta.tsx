// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import { useState } from "react";
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
      <div className="flex h-full w-full justify-center overflow-hidden p-1">
        <div className="w-full max-w-[560px]">
          <div className="grid grid-cols-1 gap-2">
            <div className="space-y-2">
          {/* Ventas Section */}
        <Fs legend="Ventas">
          <div className="flex items-start gap-0 min-w-0">
            <div className="space-y-2 min-w-[220px]">
              <div className="flex items-center gap-2">
                <span className="text-[11px] text-slate-600 w-12">Desde :</span>
                <input className={`${inp} w-[110px]`} type="date" defaultValue="2026-08-01" />
              </div>
              <div className="flex items-center gap-2">
                <span className="text-[11px] text-slate-600 w-12">Hasta :</span>
                <input className={`${inp} w-[110px]`} type="date" defaultValue="2026-08-07" />
              </div>
            </div>

            <div className="min-w-0">
              <Fs legend="Impresión">
                <div className="grid grid-cols-2 gap-2">
                  <label className="inline-flex items-center gap-2">
                    <input type="radio" name="impresion_pagina" defaultChecked className="accent-[#2A5590]" />
                    <span className="text-[11px] text-slate-700">Con Página</span>
                  </label>
                  <label className="inline-flex items-center gap-2">
                    <input type="radio" name="impresion_celdas" defaultChecked className="accent-[#2A5590]" />
                    <span className="text-[11px] text-slate-700">Con Celdas</span>
                  </label>
                  <label className="inline-flex items-center gap-2">
                    <input type="radio" name="impresion_pagina" className="accent-[#2A5590]" />
                    <span className="text-[11px] text-slate-700">Sin Página</span>
                  </label>
                  <label className="inline-flex items-center gap-2">
                    <input type="radio" name="impresion_celdas" className="accent-[#2A5590]" />
                    <span className="text-[11px] text-slate-700">Sin Celdas</span>
                  </label>
                </div>
              </Fs>
            </div>
          </div>

        {/* Buscar Cliente Section */}
        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2 mb-2">
            <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
            <span className="text-[11px] text-slate-700 font-semibold">Todo Cliente</span>
          </label>
          <div className="space-y-1">
            <div className="flex items-center gap-1">
              <span className="text-[11px] text-slate-600 w-12">Cliente</span>
              <input className={`${inp} w-[230px]`} />
              <button className={iconBtn}><Search className="h-3.5 w-3.5" /></button>
            </div>
          </div>
        </Fs>

        {/* Por Documento Section */}
        <Fs legend="Por Documento">
          <div className="space-y-1">
            <div className="flex items-center gap-4">
            <span className="text-[11px] text-slate-600 w-12">Documento</span>
            <select className={`${inp} w-[180px]`}><option>(Todos)</option></select>
          </div>
          </div>
        </Fs>

        {/* Moneda, Formato, Exportar in Grid */}
        <div className="grid grid-cols-3 gap-1">
          <Fs legend="Moneda" className="w-full min-w-0">
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
          <Fs legend="Formato" className="w-full min-w-0">
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
          <Fs legend="Exportar" className="w-full min-w-0">
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
        </Fs>
        </div>
      </div>
      </div>
      </div>
    </WindowShell>
  );
}