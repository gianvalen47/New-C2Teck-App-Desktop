// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, Printer, FileDown } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function FichaGeneralList() {
  return (
    <WindowShell title="Ficha General del Empleado"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Printer className="h-3.5 w-3.5" />Imprimir ficha</button>
        <button className={btn}><FileDown className="h-3.5 w-3.5" />Contrato PDF</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="DNI"><input className={inp} /></Field>
        <Field label="Apellidos" className="col-span-2"><input className={inp} /></Field>
        <Field label="Nombres"><input className={inp} /></Field>
        <Field label="Fecha nacimiento"><input className={inp} type="date" /></Field>
        <Field label="Estado civil"><select className={inp}><option>Soltero</option><option>Casado</option><option>Conviviente</option></select></Field>
        <Field label="Dirección" className="col-span-2"><input className={inp} /></Field>
        <Field label="Teléfono"><input className={inp} /></Field>
        <Field label="Email"><input className={inp} type="email" /></Field>
        <Field label="Contacto emergencia" className="col-span-2"><input className={inp} /></Field>
        <Field label="Tipo de contrato"><select className={inp}><option>Indefinido</option><option>Plazo fijo</option><option>Locación</option></select></Field>
        <Field label="Régimen salud"><select className={inp}><option>EsSalud</option><option>EPS</option></select></Field>
        <Field label="AFP"><select className={inp}><option>Integra</option><option>Prima</option><option>Profuturo</option><option>Habitat</option><option>ONP</option></select></Field>
        <Field label="Sueldo base S/"><input className={inp} type="number" /></Field>
      </div>
      <div className="mt-3">
        <div className="text-[11px] font-semibold text-slate-600 mb-1">Historial de puestos</div>
        <DataTable columns={["Desde", "Hasta", "Puesto", "Área", "Sueldo", "Motivo cambio"]} rows={4} />
      </div>
    </WindowShell>
  );
}
