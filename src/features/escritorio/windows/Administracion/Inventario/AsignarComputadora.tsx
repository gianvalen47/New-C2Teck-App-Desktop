// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save } from "lucide-react";
import {
  inp,
  btnPrimary,
  Field,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function ComputadoraAsignarList() {
  return (
    <WindowShell title="Asignar Computadora — Inventario TI"
      toolbar={<><button className={btnPrimary}><Save className="h-3.5 w-3.5" />Asignar</button></>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Colaborador" className="col-span-2"><input className={inp} /></Field>
        <Field label="Equipo (Serie)"><input className={inp} /></Field>
        <Field label="Fecha entrega"><input className={inp} type="date" /></Field>
        <Field label="Tipo"><select className={inp}><option>Laptop</option><option>Desktop</option><option>Monitor</option></select></Field>
        <Field label="Licencias"><input className={inp} placeholder="Office, Antivirus…" /></Field>
        <Field label="Estado"><select className={inp}><option>Asignado</option><option>Devuelto</option><option>Baja</option></select></Field>
      </div>
      <div className="mt-3"><DataTable columns={["Fecha", "Colaborador", "Equipo", "Tipo", "Licencias", "Estado"]} rows={6} /></div>
    </WindowShell>
  );
}
