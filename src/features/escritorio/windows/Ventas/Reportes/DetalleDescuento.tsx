// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search, RefreshCw, Filter } from "lucide-react";
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

export function ReporteDetalleDescuentoList() {
  return (
    <WindowShell title="Reporte de Venta Detallado con Descuento"
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
      </>}
    >
      <div className="p-3 space-y-3 max-w-2xl mx-auto text-[11.5px] text-slate-800">
        <div className="grid grid-cols-[auto_1fr_auto_1fr] items-center gap-x-2 gap-y-2">
          <div className="text-right font-medium">Fechas</div>
          <div className="grid grid-cols-[auto_1fr] gap-2 items-center">
            <span className="text-right">Del :</span>
            <input className={inp} type="date" defaultValue="2026-08-01" />
          </div>
          <div className="text-right">Al</div>
          <div><input className={inp} type="date" defaultValue="2026-08-08" /></div>
        </div>

        <div className="grid grid-cols-2 gap-3">
          <Fs legend="Localización">
            <Field label="Oficina"><select className={inp}><option>(Todos)</option></select></Field>
            <Field label="Almacén"><select className={inp}><option>(Todos)</option></select></Field>
          </Fs>
          <div />
        </div>

        <Fs legend="Buscar Por Vendedor">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Vendedor</label>
          <Field label="Vendedor"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>

        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Cliente</label>
          <Field label="Cliente"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
        </Fs>

        <div className="grid grid-cols-2 gap-3">
          <Fs legend="Buscar Mercadería">
            <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Toda Mercadería</label>
            <Field label=""><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
          </Fs>
          <Fs legend="Imprimir">
            <div className="flex flex-col gap-1">
              <Radio name="imp" label="Pantalla" defaultChecked />
              <Radio name="imp" label="Exportar" />
            </div>
          </Fs>
        </div>

        <div className="mt-2 flex justify-center gap-2"><button className={btnPrimary}>Aceptar</button><button className={btn}>Cancelar</button></div>
      </div>
    </WindowShell>
  );
}
