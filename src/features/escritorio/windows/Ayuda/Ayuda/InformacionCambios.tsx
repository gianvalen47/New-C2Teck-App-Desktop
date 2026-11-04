import { WindowShell } from "@/components/ui/desktop-primitives";

export function InfoCambios() {
  return (
    <WindowShell title="Información de Cambios">
      <p className="p-4 text-sm text-slate-600">
        El historial de versiones se abre en el navegador externo desde el ribbon de Ayuda.
      </p>
    </WindowShell>
  );
}
