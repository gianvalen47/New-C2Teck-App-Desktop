// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Search } from "lucide-react";
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

export function ReporteOrdenCompraList() {
  return (
    <WindowShell title="Reporte de Orden de Compra"
    >
      <div className="p-3 space-y-3 max-w-4xl mx-auto text-[11.5px] text-slate-800">
        {/* Dos columnas: izquierda filtros, derecha Tipo */}
        <div className="grid grid-cols-[1.2fr_1fr] gap-4">
          {/* Columna Izquierda */}
          <div className="space-y-2">
            <div className="grid grid-cols-[auto_1fr_auto_1fr] items-center gap-x-2 gap-y-1">
              <div className="font-medium">Fechas</div>
              <div></div>
              <div className="text-right">Del :</div>
              <input className={inp} type="date" defaultValue="2026-08-01" />
              <div></div>
              <div></div>
              <div className="text-right">Al :</div>
              <input className={inp} type="date" defaultValue="2026-08-08" />
            </div>
            <Field label="Oficina :"><select className={inp}><option>LIMA</option></select></Field>
            <Field label="Almacén :"><select className={inp}><option>COMERCIAL</option></select></Field>
            <Field label="Estados :"><select className={inp}><option>(Todos)</option></select></Field>
            <Field label="Rubros :"><select className={inp}><option>(Todos)</option></select></Field>
          </div>

          {/* Columna Derecha - Tipo */}
          <Fs legend="Tipo">
            <div className="space-y-2">
              <Radio name="tipo" label="Totalizado" defaultChecked />
              <div className="space-y-1">
                <Radio name="tipo" label="Detallado" />
                <div className="ml-6 space-y-1">
                  <div className="text-[11px] font-medium">Condición</div>
                  <Radio name="cond" label="Separado" />
                  <Radio name="cond" label="Todos" />
                </div>
              </div>
              <Radio name="tipo" label="Atendidos" />
            </div>
          </Fs>
        </div>

        {/* Secciones de búsqueda - full width */}
        <Fs legend="Buscar Mercadería">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Mercadería</label>
          <Field label="Mercadería"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
        </Fs>

        <Fs legend="Buscar Cliente">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Cliente</label>
          <Field label="Cliente"><div className="flex gap-1"><input className={`${inp} flex-1`} /><button className={iconBtn}><Search className="h-3.5 w-3.5" /></button></div></Field>
        </Fs>

        <Fs legend="Buscar Vendedor">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Vendedor</label>
          <Field label="Vendedor"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>

        <Fs legend="Exportar">
          <div className="flex gap-3"><Radio name="exp" label="Pantalla" defaultChecked /><Radio name="exp" label="Excel" /></div>
        </Fs>

        <div className="mt-2 flex justify-center gap-2"><button className={btnPrimary}>Aceptar</button><button className={btn}>Cancelar</button></div>
      </div>
    </WindowShell>
  );
}
