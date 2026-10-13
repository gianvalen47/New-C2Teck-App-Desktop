// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import {
  inp,
  btn,
  btnPrimary,
  Field,
  WindowShell,
  Fs,
  Radio
} from "@/components/ui/desktop-primitives";

export function ReportePresupuestoVentaList() {
  return (
    <WindowShell title="Presupuesto Venta"
    >
      <div className="p-3 space-y-2 max-w-2xl mx-auto text-[11.5px] text-slate-800">
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
        <Fs legend="Tipo Reporte">
          <div className="flex flex-wrap items-center justify-center gap-x-5 gap-y-1">
            <Radio name="tiprep" label="Presupuesto Anual" defaultChecked />
            <Radio name="tiprep" label="Ventas vs Presupuesto" />
          </div>
        </Fs>
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}
