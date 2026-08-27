// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { X } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  WindowShell,
  Fs,
  Radio
} from "@/components/ui/desktop-primitives";

export function ReporteMensualClienteList() {
  return (
    <WindowShell title="Reporte de Ventas Mensuales por Cliente"
    >
      <div className="p-3 space-y-3 max-w-2xl mx-auto text-[11.5px] text-slate-800">
        <div className="grid grid-cols-[auto_1fr_auto_1fr] items-center gap-x-2 gap-y-2">
          <div className="text-right font-medium">Del :</div>
          <div><input className={inp} type="date" defaultValue="2026-08-01" /></div>
          <div className="text-right font-medium">Al :</div>
          <div><input className={inp} type="date" defaultValue="2026-08-08" /></div>
        </div>

        <div className="grid grid-cols-3 gap-2">
          <Field label="Oficina"><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Almacén"><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Rubro"><select className={inp}><option>(Todos)</option></select></Field>
        </div>

        <Fs legend="Buscar Por Vendedor">
          <label className="flex items-center gap-2"><input type="checkbox" defaultChecked className="accent-[#2A5590]" />Todo Vendedor</label>
          <Field label="Vendedor"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>

        <Field label="Sector"><select className={inp}><option>(Todos)</option></select></Field>

        <Fs legend="Reporte">
          <div className="flex flex-col gap-1">
            <Radio name="reporte" label="Detalle" defaultChecked />
            <Radio name="reporte" label="Resumen" />
          </div>
        </Fs>

        <div className="grid grid-cols-3 gap-3">
          <Fs legend="Ordenado X">
            <div className="flex flex-col gap-1">
              <Radio name="orden_x" label="Cliente" defaultChecked />
              <Radio name="orden_x" label="Total Venta" />
            </div>
          </Fs>
          <Fs legend="Tipo de Orden">
            <div className="flex flex-col gap-1">
              <Radio name="tipo_orden" label="Ascendente" defaultChecked />
              <Radio name="tipo_orden" label="Descendente" />
            </div>
          </Fs>
          <Fs legend="Moneda">
            <div className="flex flex-col gap-1">
              <Radio name="moneda" label="En Soles" defaultChecked />
              <Radio name="moneda" label="En Dólares" />
            </div>
          </Fs>
        </div>

        <div className="mt-2 flex justify-center gap-2"><button className={btnPrimary}>Aceptar</button><button className={btn}>Cancelar</button></div>
      </div>
    </WindowShell>
  );
}
