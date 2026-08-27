// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, Printer, Wrench } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";
import { Kilometraje } from "@/features/escritorio/windows/Servicios/Control Vehicular/Kilometraje";

export function OrdenTrabajoList() {
  return (
    <WindowShell title="Orden de Trabajo — Taller / Servicio Técnico"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar OT</button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir</button>
        <button className={btn}><Wrench className="h-3.5 w-3.5" />Asignar mecánicos</button>
        <span className="ml-auto text-[11px] text-slate-500">Estado: <b className="text-amber-700">En proceso</b></span>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Nº OT"><input className={inp} defaultValue="OT-000000" readOnly /></Field>
        <Field label="Fecha"><input className={inp} type="date" /></Field>
        <Field label="Cliente" className="col-span-2"><input className={inp} placeholder="RUC / DNI / Razón Social" /></Field>
        <Field label="Placa / Equipo"><input className={inp} /></Field>
        <Field label="Marca"><input className={inp} /></Field>
        <Field label="Modelo"><input className={inp} /></Field>
        <Field label="Kilometraje"><input className={inp} type="number" /></Field>
        <Field label="Descripción de la falla" className="col-span-4">
          <textarea className={inp + " h-14 py-1"} />
        </Field>
      </div>
      <div className="grid grid-cols-2 gap-3 mt-3">
        <div>
          <div className="text-[11px] font-semibold text-slate-600 mb-1">Mano de Obra</div>
          <DataTable columns={["Mecánico", "Tarea", "Inicio", "Fin", "Horas", "Costo"]} rows={4} />
        </div>
        <div>
          <div className="text-[11px] font-semibold text-slate-600 mb-1">Repuestos utilizados</div>
          <DataTable columns={["Código", "Descripción", "Cant.", "P. Unit", "Total"]} rows={4} />
        </div>
      </div>
      <div className="mt-3 grid grid-cols-4 gap-2 max-w-md ml-auto text-[11.5px]">
        <div className="text-right text-slate-600 col-span-3">Mano de obra:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right text-slate-600 col-span-3">Repuestos:</div><div className="text-right font-mono">0.00</div>
        <div className="text-right font-bold text-[#2A3F55] col-span-3">Total OT S/:</div><div className="text-right font-mono font-bold">0.00</div>
      </div>
    </WindowShell>
  );
}
