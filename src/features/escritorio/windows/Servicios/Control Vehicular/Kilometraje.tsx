// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save, Car } from "lucide-react";
import {
  inp,
  btn,
  btnPrimary,
  Field,
  DataTable,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function KilometrajeList() {
  return (
    <WindowShell title="Kilometraje / Horómetros — Flota Vehicular"
      toolbar={<>
        <button className={btnPrimary}><Save className="h-3.5 w-3.5" />Registrar lectura</button>
        <button className={btn}><Car className="h-3.5 w-3.5" />Alertas mantenimiento</button>
      </>}>
      <div className="grid grid-cols-4 gap-3">
        <Field label="Placa / Equipo"><input className={inp} /></Field>
        <Field label="Fecha lectura"><input className={inp} type="date" /></Field>
        <Field label="Kilometraje / Horas"><input className={inp} type="number" /></Field>
        <Field label="Próximo servicio en"><input className={inp} type="number" /></Field>
      </div>
      <div className="mt-3"><DataTable columns={["Placa", "Última lectura", "Fecha", "Prox. servicio", "Días restantes", "Estado"]} rows={8} /></div>
    </WindowShell>
  );
}
