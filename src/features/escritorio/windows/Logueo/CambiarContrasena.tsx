// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { Save } from "lucide-react";
import {
  inp,
  btnPrimary,
  Field,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function CambiarContrasenaList() {
  return (
    <WindowShell title="Cambiar Contraseña"
      toolbar={<><button className={btnPrimary}><Save className="h-3.5 w-3.5" />Actualizar</button></>}>
      <div className="max-w-md mx-auto mt-4 space-y-3">
        <Field label="Contraseña actual"><input className={inp} type="password" /></Field>
        <Field label="Nueva contraseña"><input className={inp} type="password" /></Field>
        <Field label="Confirmar nueva contraseña"><input className={inp} type="password" /></Field>
        <div className="text-[10.5px] text-slate-500 pt-1">Mínimo 8 caracteres, incluir mayúscula, minúscula, número y carácter especial.</div>
      </div>
    </WindowShell>
  );
}
