// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  Field,
  WindowShell,
  Fs
} from "@/components/ui/desktop-primitives";

export function ResumenRegistroList() {
  return (
    <WindowShell title="Resumen de Registro de Ventas">
      <div className="max-w-2xl mx-auto p-3 space-y-3">
        <div className="flex items-end gap-3">
          <div className="flex-1 space-y-1">
            <label className="text-[11px] font-semibold text-slate-700">Fechas</label>
            <div className="flex gap-2 items-center">
              <div className="flex items-center gap-1">
                <span className="text-[11px] text-slate-700">Del :</span>
                <input className={inp} type="date" defaultValue="2026-08-01" />
              </div>
              <div className="flex items-center gap-1">
                <span className="text-[11px] text-slate-700">Al</span>
                <input className={inp} type="date" defaultValue="2026-08-08" />
              </div>
            </div>
          </div>
        </div>

        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2">
            <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
            <span className="text-[12px] text-slate-700">Todo Cliente</span>
          </label>
          <Field label="Cliente" className="w-full">
            <div className="flex gap-1">
              <input className={`${inp} flex-1`} />
              <button className={iconBtn}>
                <Search className="h-3.5 w-3.5" />
              </button>
            </div>
          </Field>
        </Fs>

        <div className="grid grid-cols-2 gap-3">
          <Fs legend="Tipo">
            <div className="flex flex-col gap-1">
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="tipo_res" defaultChecked className="accent-[#2A5590]" />
                <span className="text-[12px] text-slate-700">Ventas</span>
              </label>
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="tipo_res" className="accent-[#2A5590]" />
                <span className="text-[12px] text-slate-700">Exportación</span>
              </label>
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="tipo_res" className="accent-[#2A5590]" />
                <span className="text-[12px] text-slate-700">Trans. Gratuitas</span>
              </label>
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="tipo_res" className="accent-[#2A5590]" />
                <span className="text-[12px] text-slate-700">Agrupado por Cliente</span>
              </label>
            </div>
          </Fs>

          <Fs legend="Exportar">
            <div className="flex flex-col gap-1">
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="exp_res" defaultChecked className="accent-[#2A5590]" />
                <span className="text-[12px] text-slate-700">Pantalla</span>
              </label>
              <label className="inline-flex items-center gap-2">
                <input type="radio" name="exp_res" className="accent-[#2A5590]" />
                <span className="text-[12px] text-slate-700">Excel</span>
              </label>
            </div>
          </Fs>
        </div>

        <div className="flex justify-end gap-2 pt-2 border-t border-slate-200">
          <button className={btnPrimary}>Aceptar</button>
          <button className={btn}>Cancelar</button>
        </div>
      </div>
    </WindowShell>
  );
}
