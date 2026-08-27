// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save } from "lucide-react";
import {
  inp,
  btnPrimary,
  Field,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function AsignaPersonaList() {
  return (
    <WindowShell title="Asignar Teléfono / Línea a Colaborador"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Asignar</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Colaborador" className="col-span-2"><input className={inp} placeholder="DNI / Nombre" /></Field>
        <Field label="Equipo"><input className={inp} /></Field>
        <Field label="Línea"><input className={inp} /></Field>
        <Field label="Plan"><input className={inp} /></Field>
        <Field label="Fecha entrega"><input className={inp} type="date" /></Field>
        <Field label="Estado"><select className={inp}><option>Activo</option><option>Devuelto</option><option>Perdido</option></select></Field>
      </div>
      <div className="mt-3"><DataTable columns={["Fecha", "Colaborador", "Equipo", "Línea", "Plan", "Estado"]} rows={6} /></div>
    </WindowShell>
  );
}
