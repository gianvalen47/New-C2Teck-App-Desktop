// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import {
  inp,
  btn,
  btnPrimary,
  WindowShell,
  Fs,
} from "@/components/ui/desktop-primitives";
import { FileSpreadsheet, LogOut } from "lucide-react";

export function ReporteComisiones() {
  return <ReporteComisionesList />;
}

export function ReporteComisionesList() {
  return (
    <WindowShell title="Reporte de Comisiones">
      <div className="flex h-full items-center justify-center p-3">
      <div className="w-full max-w-md space-y-2 text-[11.5px] text-slate-800">
        <Fs legend="Tipo Reporte">
          <div className="flex flex-wrap items-center justify-center gap-x-5 gap-y-1">
            <label className="inline-flex items-center gap-1">
              <input type="radio" name="tiprep" defaultChecked className="accent-[#2A5590]" />
              Comisiones de vendedor
            </label>
            <label className="inline-flex items-center gap-1">
              <input type="radio" name="tiprep" className="accent-[#2A5590]" />
              Compensación Allison
            </label>
          </div>
        </Fs>
        <Fs legend="Rango de Fechas">
          <div className="flex flex-wrap items-center justify-center gap-x-2 gap-y-1">
            <span>Fechas</span>
            <label className="inline-flex items-center gap-1">
              Del
              <input className={`${inp} w-[102px]`} type="date" defaultValue="2026-06-01" />
            </label>
            <label className="inline-flex items-center gap-1">
              A:
              <input className={`${inp} w-[102px]`} type="date" defaultValue="2026-06-30" />
            </label>
          </div>
        </Fs>
        <div className="mt-2 flex justify-center gap-2">
          <button className={btnPrimary}><FileSpreadsheet className="h-3.5 w-3.5" />Aceptar</button>
          <button className={btn}><LogOut className="h-3.5 w-3.5" />Cancelar</button>
        </div>
      </div>
      </div>
    </WindowShell>
  );
}
