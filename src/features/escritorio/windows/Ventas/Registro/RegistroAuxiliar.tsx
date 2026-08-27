// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import {
  inp,
  btn,
  btnPrimary,
  Field,
  WindowShell,
  Fs
} from "@/components/ui/desktop-primitives";
import { Notas } from "@/features/escritorio/windows/Ventas/Documentos/Notas";

export function RegistroAuxiliarList() {
  return (
    <WindowShell title="Registro Auxiliar de Ventas">
      <div className="max-w-[520px] mx-auto p-3 space-y-3">
        <Fs legend="Fechas">
          <div className="grid grid-cols-[auto_auto_auto_auto] items-center gap-2">
            <span className="text-[11px] font-semibold text-slate-700">Del :</span>
            <input className={inp} type="date" defaultValue="2026-08-01" />
            <span className="text-[11px] font-semibold text-slate-700">Al</span>
            <input className={inp} type="date" defaultValue="2026-08-07" />
          </div>
        </Fs>

        <div className="grid grid-cols-[1fr_1.2fr] gap-3">
          <div className="space-y-3">
            <Field label="Oficina" className="w-full">
              <select className={inp}>
                <option>LIMA</option>
                <option>AREQUIPA</option>
                <option>TRUJILLO</option>
              </select>
            </Field>

            <Fs legend="Moneda">
              <div className="flex flex-col gap-2">
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="moneda_aux" defaultChecked className="accent-[#2A5590]" />
                  <span className="text-[12px] text-slate-700">En Soles</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="moneda_aux" className="accent-[#2A5590]" />
                  <span className="text-[12px] text-slate-700">En Dólares</span>
                </label>
              </div>
            </Fs>
          </div>

          <Fs legend="Departamento">
            <div className="flex flex-col gap-1">
              {[
                'Repuestos',
                'Baterías',
                'Filtros',
                'Servicios',
                'Motores',
                'Mercadería sin movimiento',
                'Consignación',
                'Notas de Débito',
                'Transferencia gratuita',
                'Back Office',
                'Proyectos Nuevos',
              ].map((dep) => (
                <label key={dep} className="inline-flex items-center gap-2">
                  <input type="radio" name="dep_aux" className="accent-[#2A5590]" />
                  <span className="text-[12px] text-slate-700">{dep}</span>
                </label>
              ))}
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
