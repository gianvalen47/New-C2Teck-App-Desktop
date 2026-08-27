// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, RefreshCw, MapPin } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function PuntosControlList({ title }: { title: string }) {
  return (
    <WindowShell title={title + " — Rondas / Rutas de Control"}
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Guardar</button>
        <button className={btn}><MapPin className="h-3.5 w-3.5" />Ver en mapa</button>
        <button className={btn}><RefreshCw className="h-3.5 w-3.5" />Optimizar ruta</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Ruta" className="col-span-2"><input className={inp} /></Field>
        <Field label="Vigilante / Chofer"><input className={inp} /></Field>
        <Field label="Turno"><select className={inp}><option>Día</option><option>Noche</option></select></Field>
      </div>
      <div className="mt-3"><DataTable columns={["#", "Punto de control", "Dirección", "Hora exigida", "Tolerancia (min)", "Marcación"]} rows={8} /></div>
    </WindowShell>
  );
}
