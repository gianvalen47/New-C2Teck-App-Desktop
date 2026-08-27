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

export function VentaReporteDialogList({ label }: { label: string }) {
  const n = label.toLowerCase();
  const isDetalle = n.includes("detalle");

  if (isDetalle) {
    return (
      <WindowShell title="Reporte de Ventas Detallado">
        <div className="max-w-5xl mx-auto p-3 space-y-3 text-[11.5px] text-slate-800">
          <div className="grid grid-cols-1 gap-2 xl:grid-cols-[2fr_1fr]">
            <div className="xl:pr-2">
              <Fs legend="Fechas">
                <div className="flex flex-wrap items-center gap-2">
                  <span className="font-semibold">Del :</span>
                  <input className={`${inp} w-40`} type="date" defaultValue="2026-08-01" />
                  <span className="font-semibold">Al</span>
                  <input className={`${inp} w-40`} type="date" defaultValue="2026-08-08" />
                </div>
                <div className="mt-3">
                  <Field label="Rubro" className="w-full">
                    <select className={inp}><option>(Todos)</option></select>
                  </Field>
                </div>
              </Fs>
            </div>

            <div className="grid grid-cols-1 gap-2">
              <Field label="Oficina" className="w-full">
                <select className={inp}><option>(Todos)</option></select>
              </Field>
              <Field label="Almacén" className="w-full">
                <select className={inp}><option>(Todos)</option></select>
              </Field>
            </div>
          </div>

          <div className="grid grid-cols-1 gap-2 lg:grid-cols-3">
            <Fs legend="Buscar Por Vendedor">
              <label className="inline-flex items-center gap-2 text-[11px]">
                <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                <span>Todo Vendedor</span>
              </label>
              <Field label="Vendedor" className="w-full">
                <select className={inp}><option>(Todos)</option></select>
              </Field>
            </Fs>

            <Fs legend="Buscar Cliente">
              <label className="inline-flex items-center gap-2 text-[11px]">
                <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                <span>Todo Cliente</span>
              </label>
              <Field label="Cliente" className="w-full">
                <div className="flex items-center gap-2">
                  <input className={`${inp} flex-1`} />
                  <button className={iconBtn}><Search className="h-3.5 w-3.5" /></button>
                </div>
              </Field>
              <Field label="Locación Cliente" className="w-full">
                <select className={inp}><option>0</option></select>
              </Field>
            </Fs>

            <Fs legend="Buscar Mercadería">
              <label className="inline-flex items-center gap-2 text-[11px]">
                <input type="checkbox" defaultChecked className="accent-[#2A5590]" />
                <span>Toda Mercadería</span>
              </label>
              <Field label="Mercadería" className="w-full">
                <div className="flex items-center gap-2">
                  <input className={`${inp} flex-1`} />
                  <button className={iconBtn}><Search className="h-3.5 w-3.5" /></button>
                </div>
              </Field>
            </Fs>
          </div>

          <div className="grid grid-cols-1 gap-2 lg:grid-cols-3">
            <Fs legend="Documentos">
              <div className="flex flex-col gap-1 text-[11px]">
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="docs" defaultChecked className="accent-[#2A5590]" />
                  <span>Todos</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="docs" className="accent-[#2A5590]" />
                  <span>Facturación</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="docs" className="accent-[#2A5590]" />
                  <span>Facturados sin Exportaciones</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="docs" className="accent-[#2A5590]" />
                  <span>Exportaciones</span>
                </label>
              </div>
            </Fs>

            <Fs legend="Tipo Reporte">
              <div className="flex flex-col gap-1 text-[11px]">
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="tipo" defaultChecked className="accent-[#2A5590]" />
                  <span>Detallado</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="tipo" className="accent-[#2A5590]" />
                  <span>Detallado Unitario</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="tipo" className="accent-[#2A5590]" />
                  <span>Resumen</span>
                </label>
              </div>
            </Fs>

            <Fs legend="Reporte Agrupado">
              <div className="space-y-3 text-[11px]">
                <div>
                  <label className="inline-flex items-center gap-2">
                    <input type="radio" name="agrup" defaultChecked className="accent-[#2A5590]" />
                    <span>Cliente</span>
                  </label>
                </div>
                <div className="flex flex-wrap items-center gap-2 text-[10px]">
                  <span>Ordenar por :</span>
                  <label className="inline-flex items-center gap-1">
                    <input type="radio" name="orden1" defaultChecked className="accent-[#2A5590]" />
                    <span>Fecha</span>
                  </label>
                  <label className="inline-flex items-center gap-1">
                    <input type="radio" name="orden1" className="accent-[#2A5590]" />
                    <span>Mercadería</span>
                  </label>
                </div>
                <div>
                  <label className="inline-flex items-center gap-2">
                    <input type="radio" name="agrup" className="accent-[#2A5590]" />
                    <span>Mercadería</span>
                  </label>
                </div>
                <div className="flex flex-wrap items-center gap-2 text-[10px]">
                  <span>Ordenar por :</span>
                  <label className="inline-flex items-center gap-1">
                    <input type="radio" name="orden2" className="accent-[#2A5590]" />
                    <span>Fecha</span>
                  </label>
                  <label className="inline-flex items-center gap-1">
                    <input type="radio" name="orden2" defaultChecked className="accent-[#2A5590]" />
                    <span>Cliente</span>
                  </label>
                </div>
              </div>
            </Fs>
          </div>

          <div className="grid grid-cols-1 gap-2 xl:grid-cols-[2fr_auto]">
            <Fs legend="Exportar">
              <div className="space-y-2 text-[11px]">
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="export" defaultChecked className="accent-[#2A5590]" />
                  <span>Pantalla</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="export" className="accent-[#2A5590]" />
                  <span>Exportar</span>
                </label>
              </div>
              <div className="ml-5 flex flex-col gap-2 mt-2 text-[11px]">
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="exp_type" defaultChecked className="accent-[#2A5590]" />
                  <span>Detallado</span>
                </label>
                <label className="inline-flex items-center gap-2">
                  <input type="radio" name="exp_type" className="accent-[#2A5590]" />
                  <span>Resumido</span>
                </label>
              </div>
            </Fs>

            <div className="flex items-end justify-end">
              <div className="flex gap-2">
                <button className={btnPrimary}>Aceptar</button>
                <button className={btn}>Cancelar</button>
              </div>
            </div>
          </div>
        </div>
      </WindowShell>
    );
  }

  // Otros tipos de reportes...
  return (
    <WindowShell title={`Reporte — ${label}`}>
      <div className="p-3 space-y-2 max-w-4xl mx-auto">
        <div className="flex justify-end gap-2 pt-2 border-t border-slate-200">
          <button className={btnPrimary}>Aceptar</button>
          <button className={btn}>Cancelar</button>
        </div>
      </div>
    </WindowShell>
  );
}
