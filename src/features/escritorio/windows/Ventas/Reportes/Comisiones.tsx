// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import {
  inp,
  btn,
  btnPrimary,
  Field,
  WindowShell,
  Fs
} from "@/components/ui/desktop-primitives";

export function ReporteComisionesList() {
  return (
    <WindowShell title="Reporte de Comisiones"
    >
      <div className="p-3 space-y-2 max-w-2xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Tipo Reporte">
          <div className="flex gap-2">
            <label className="flex items-center gap-1"><input type="radio" name="tiprep" defaultChecked className="accent-[#2A5590]" />Comisiones de vendedor</label>
            <label className="flex items-center gap-1"><input type="radio" name="tiprep" className="accent-[#2A5590]" />Compensación Allison</label>
          </div>
        </Fs>
        <Fs legend="Rango de Fechas">
          <Field label="Fechas Del"><input className={inp} type="date" defaultValue="2026-06-01" /></Field>
          <Field label="Al"><input className={inp} type="date" defaultValue="2026-06-30" /></Field>
        </Fs>
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}
