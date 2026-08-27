// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Clock, Play, Square } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function MarcacionesList({ title = "Marcación de Tareas OT" }: { title?: string }) {
  return (
    <WindowShell title={title}
      toolbar={<>
        <button className={btnPrimary}><Play className="h-3.5 w-3.5" />Inicio Tarea</button>
        <button className={btn}><Square className="h-3.5 w-3.5" />Fin Tarea</button>
        <button className={btn}><Clock className="h-3.5 w-3.5" />Reloj biométrico</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Mecánico"><input className={inp} placeholder="Código / Nombre" /></Field>
        <Field label="OT"><input className={inp} /></Field>
        <Field label="Tarea" className="col-span-2"><input className={inp} /></Field>
      </div>
      <div className="mt-3"><DataTable columns={["Fecha", "Mecánico", "OT", "Tarea", "Inicio", "Fin", "Horas", "Estado"]} rows={8} /></div>
    </WindowShell>
  );
}
