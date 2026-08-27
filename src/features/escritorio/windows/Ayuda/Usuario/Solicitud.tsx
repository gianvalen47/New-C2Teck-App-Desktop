// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Send } from "lucide-react";
import {
  inp,
  btnPrimary,
  Field,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function SolicitudSoporteList() {
  return (
    <WindowShell title="Solicitud de Soporte — Ticket TI"
      toolbar={<><button className={btnPrimary}><Send className="h-3.5 w-3.5" />Enviar ticket</button></>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Nº ticket"><input className={inp} defaultValue="TCK-0000" readOnly /></Field>
        <Field label="Prioridad"><select className={inp}><option>Baja</option><option>Media</option><option>Alta</option><option>Crítica</option></select></Field>
        <Field label="Módulo afectado" className="col-span-2"><input className={inp} /></Field>
        <Field label="Asunto" className="col-span-4"><input className={inp} /></Field>
        <Field label="Descripción del problema" className="col-span-4"><textarea className={inp + " h-24 py-1"} /></Field>
        <Field label="Adjuntar captura" className="col-span-2"><input className={inp} type="file" /></Field>
      </div>
    </WindowShell>
  );
}
