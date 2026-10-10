import { Search } from "lucide-react";
import {
  btn,
  btnPrimary,
  Field,
  Fs,
  iconBtn,
  inp,
  WindowShell,
} from "@/components/ui/desktop-primitives";

export function ReporteGuiasRemisionList() {
  return (
    <WindowShell title="Reporte de Guías de Remisión">
      <div className="mx-auto max-w-2xl space-y-3 p-3 text-[11.5px] text-slate-800">
        <Fs legend="Fechas">
          <div className="grid grid-cols-1 gap-2 sm:grid-cols-2">
            <Field label="Del">
              <input className={inp} type="date" />
            </Field>
            <Field label="Al">
              <input className={inp} type="date" />
            </Field>
          </div>
        </Fs>

        <div className="grid grid-cols-1 gap-2 sm:grid-cols-2">
          <Field label="Oficina">
            <select className={inp}>
              <option>(Todos)</option>
              <option>LIMA</option>
            </select>
          </Field>
          <Field label="Almacén">
            <select className={inp}>
              <option>(Todos)</option>
              <option>COMERCIAL</option>
            </select>
          </Field>
        </div>

        <Fs legend="Buscar Cliente">
          <label className="inline-flex items-center gap-2">
            <input
              type="checkbox"
              defaultChecked
              disabled
              className="accent-[#2A5590]"
            />
            Todo Cliente
          </label>
          <Field label="Cliente">
            <div className="flex gap-1">
              <input className={`${inp} min-w-0 flex-1`} defaultValue="(Todos)" />
              <button type="button" className={iconBtn} aria-label="Buscar cliente">
                <Search className="h-3.5 w-3.5" />
              </button>
            </div>
          </Field>
        </Fs>

        <Fs legend="Opciones">
          <div className="grid grid-cols-1 gap-2 sm:grid-cols-2">
            <Field label="Moneda">
              <select className={inp}>
                <option value=""></option>
                <option>Soles</option>
                <option>Dólares</option>
              </select>
            </Field>
            <Field label="Serie Doc.">
              <input className={`${inp} max-w-[90px]`} />
            </Field>
            <Field label="Motivo">
              <select className={inp}>
                <option>(Todos)</option>
                <option>Venta</option>
                <option>Traslado</option>
              </select>
            </Field>
            <Field label="Estado">
              <select className={inp}>
                <option>(Todos)</option>
                <option>GENERADO</option>
                <option>ANULADO</option>
              </select>
            </Field>
          </div>
        </Fs>

        <div className="flex justify-end gap-2 border-t border-slate-200 pt-2">
          <button type="button" className={btn}>Cancelar</button>
          <button type="button" className={btnPrimary}>Aceptar</button>
        </div>
      </div>
    </WindowShell>
  );
}
