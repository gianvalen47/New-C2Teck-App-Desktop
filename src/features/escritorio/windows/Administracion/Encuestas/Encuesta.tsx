// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, Send } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function EncuestaWinList({ title }: { title: string }) {
  return (
    <WindowShell title={title + " — Clima Laboral / Satisfacción"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><Send className="h-3.5 w-3.5" />Enviar</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Encuesta" className="col-span-2"><input className={inp} /></Field>
        <Field label="Público"><select className={inp}><option>Colaboradores</option><option>Clientes internos</option></select></Field>
        <Field label="Periodo"><input className={inp} placeholder="2026-Q3" /></Field>
      </div>
      <div className="mt-3"><DataTable columns={["#", "Pregunta", "Tipo", "Escala", "Obligatoria"]} rows={6} /></div>
    </WindowShell>
  );
}
