// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { CircleCheck, LogOut, Search } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  Field,
  WindowShell,
  Fs
} from "@/components/ui/desktop-primitives";

export function ReporteReclamosList() {
  return (
    <WindowShell title="Reporte de Reclamos">
      <div className="flex h-full items-center justify-center p-3">
        <div className="w-full max-w-md space-y-2 text-[11.5px] text-slate-800">
          <div className="flex flex-wrap items-center justify-center gap-x-4 gap-y-2">
            <label className="inline-flex items-center gap-1.5 font-medium">
              Del :
              <input className={`${inp} w-[145px]`} type="date" defaultValue="2026-10-01" />
            </label>
            <label className="inline-flex items-center gap-1.5 font-medium">
              Al
              <input className={`${inp} w-[125px]`} type="date" defaultValue="2026-10-10" />
            </label>
          </div>

          <div className="mx-auto grid max-w-[360px] grid-cols-[64px_150px] items-center gap-x-2 gap-y-1.5">
            <label htmlFor="reclamos-oficina" className="text-right font-medium">Oficina:</label>
            <select id="reclamos-oficina" className={`${inp} w-[150px]`} defaultValue="LIMA">
              <option>LIMA</option>
            </select>
            <label htmlFor="reclamos-almacen" className="text-right font-medium">Almacén:</label>
            <select id="reclamos-almacen" className={`${inp} w-[150px]`} defaultValue="">
              <option value=""></option>
              <option>COMERCIAL</option>
            </select>
            <label htmlFor="reclamos-estado" className="text-right font-medium">Estado :</label>
            <select id="reclamos-estado" className={`${inp} w-fit`} defaultValue="(Todos)">
              <option>(Todos)</option>
            </select>
          </div>

          <Fs legend="Buscar Cliente">
            <div className="mx-auto max-w-[345px] space-y-1.5">
              <label className="flex items-center justify-center gap-2 font-medium">
                <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                Todo Cliente
              </label>
              <Field label="Cliente">
                <div className="flex gap-1">
                  <input className={`${inp} min-w-0 flex-1`} />
                  <button type="button" aria-label="Buscar cliente" className={iconBtn}>
                    <Search className="h-3.5 w-3.5" />
                  </button>
                </div>
              </Field>
            </div>
          </Fs>

          <div className="mt-2 flex justify-center gap-2">
            <button type="button" className={btnPrimary}><CircleCheck className="h-3.5 w-3.5 text-emerald-400" />Aceptar</button>
            <button type="button" className={btn}><LogOut className="h-3.5 w-3.5" />Cancelar</button>
          </div>
        </div>
      </div>
    </WindowShell>
  );
}
