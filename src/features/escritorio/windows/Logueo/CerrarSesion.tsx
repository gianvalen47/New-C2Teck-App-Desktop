// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import {
  btn,
  btnPrimary,
  WindowShell
} from "@/components/ui/desktop-primitives";

export function CerrarSesionList() {
  return (
    <WindowShell title="Cerrar Sesión">
      <div className="max-w-md mx-auto mt-6 p-6 border border-slate-300 rounded bg-slate-50">
        <div className="text-center text-[13px] text-slate-700 mb-4">¿Está seguro que desea cerrar la sesión actual? Se destruirá el token de autenticación y volverá a la pantalla de Login.</div>
        <div className="flex gap-2 justify-center">
          <button className={btnPrimary}>Sí, cerrar sesión</button>
          <button className={btn}>Cancelar</button>
        </div>
      </div>
    </WindowShell>
  );
}
