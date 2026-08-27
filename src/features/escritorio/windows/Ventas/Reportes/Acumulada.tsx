// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { X, Search } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  iconBtn,
  Field,
  WindowShell,
  Fs,
  Radio
} from "@/components/ui/desktop-primitives";

export function ReporteAcumuladaList() {
  return (
    <WindowShell title="Reporte de Ventas Acumuladas">
      <div className="p-3 space-y-3 max-w-5xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de Fechas">
          <div className="grid grid-cols-1 gap-2 sm:grid-cols-2">
            <Field label="Del">
              <input className={`${inp} w-40`} type="date" defaultValue="2026-08-01" />
            </Field>
            <Field label="Al">
              <input className={`${inp} w-40`} type="date" defaultValue="2026-08-08" />
            </Field>
          </div>
        </Fs>

        <div className="grid grid-cols-1 gap-2 sm:grid-cols-2">
          <Field label="Oficina">
            <select className={inp}><option>(Todos)</option></select>
          </Field>
          <Field label="Almacén">
            <select className={inp}><option>(Todos)</option></select>
          </Field>
        </div>

        <div className="grid grid-cols-1 gap-2 sm:grid-cols-2">
          <Field label="Rubro">
            <select className={inp}><option>(Todos)</option></select>
          </Field>
          <Field label="Motivo">
            <select className={inp}><option>(Todos)</option></select>
          </Field>
        </div>

        <Field label="Vendedor">
          <select className={inp}><option>(Todos)</option></select>
        </Field>

        <div className="grid grid-cols-1 gap-2 lg:grid-cols-[1.6fr_1fr_1fr_0.95fr]">
          <div className="h-full">
            <Fs legend="Acumulado X">
              <div className="flex flex-col gap-1">
                <Radio name="acum" label="Mercadería" defaultChecked />
                <Radio name="acum" label="Cliente" />
                <Radio name="acum" label="Año" />
                <Radio name="acum" label="Cantidades Vendidas" />
              </div>
            </Fs>
          </div>

          <div className="h-full">
            <Fs legend="Ordenado X">
              <div className="flex flex-col gap-1">
                <Radio name="ord" label="Descripción" defaultChecked />
                <Radio name="ord" label="Dólares" />
                <Radio name="ord" label="Soles" />
              </div>
            </Fs>
          </div>

          <div className="h-full">
            <Fs legend="Buscar Marca">
              <label className="inline-flex items-center gap-2">
                <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                <span>Buscar Marca</span>
              </label>
              <div className="mt-2 flex items-center gap-1 min-w-0">
                <input className={`${inp} flex-1 min-w-0`} />
                <button className={iconBtn}><Search className="h-3.5 w-3.5" /></button>
              </div>
            </Fs>
          </div>

          <div className="h-full">
            <Fs legend="Tipo Orden">
              <div className="flex flex-col gap-1">
                <Radio name="tipo_orden" label="Ascendente" defaultChecked />
                <Radio name="tipo_orden" label="Descendente" />
              </div>
            </Fs>
          </div>
        </div>

        <Fs legend="Exportar">
          <div className="flex flex-col gap-2">
            <label className="inline-flex items-center gap-2">
              <input type="radio" name="export" defaultChecked className="accent-[#2A5590]" />
              <span>Pantalla</span>
            </label>
            <label className="inline-flex items-center gap-2">
              <input type="radio" name="export" className="accent-[#2A5590]" />
              <span>Excel</span>
            </label>
          </div>
        </Fs>

        <div className="flex justify-center gap-2 pt-2 border-t border-slate-200">
          <button className={btnPrimary}>Aceptar</button>
          <button className={btn}>Cancelar</button>
        </div>
      </div>
    </WindowShell>
  );
}
