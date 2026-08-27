// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { RefreshCw, Filter } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  DataTable,
  WindowShell,
  Fs,
  Radio
} from "@/components/ui/desktop-primitives";
import { Vales } from "@/features/escritorio/windows/Almacenes/Almacen/Vales";

export function ReporteValeRequisicionList() {
  return (
    <WindowShell title="Vales de Requisiciones"
      toolbar={<>
        <button className={btn}><Filter className="h-3.5 w-3.5" />Filtros</button>
        <button className={btnPrimary}><RefreshCw className="h-3.5 w-3.5" />Generar</button>
      </>}
    >
      <div className="p-3 space-y-2 max-w-2xl mx-auto text-[11.5px] text-slate-800">
        <Fs legend="Rango de fechas">
          <Field label="Del"><input className={inp} type="date" defaultValue="2026-01-07" /></Field>
          <Field label="Al"><input className={inp} type="date" defaultValue="2026-07-21" /></Field>
        </Fs>
        <div className="grid grid-cols-2 gap-2">
          <Fs legend="Localización"><Field label="Oficina"><select className={inp}><option>LIMA</option></select></Field></Fs>
          <Fs legend="Almacén"><Field label=""><select className={inp}><option>COMERCIAL</option></select></Field></Fs>
        </div>
        <Fs legend="Estado">
          <Field label=""><select className={inp}><option>(Todos)</option></select></Field>
          <Field label="Rubro"><select className={inp}><option>(Todos)</option></select></Field>
        </Fs>
        <Fs legend="Exportar"><div className="flex flex-col gap-1"><Radio name="exp" label="Pantalla" defaultChecked /><Radio name="exp" label="Exportar" /></div></Fs>
        <DataTable columns={["Fecha", "Vale", "Concepto", "Cantidad", "Estado", "Ofic."]} rows={5} />
        <div className="mt-2 flex justify-end gap-2"><button className={btn}>Cancelar</button><button className={btnPrimary}>Aceptar</button></div>
      </div>
    </WindowShell>
  );
}
