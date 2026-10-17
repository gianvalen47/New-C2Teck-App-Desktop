// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
import { OportunidadNegocio as OportunidadNegocioWindow } from "@/features/escritorio/windows/CRM/Oportunidades/OportunidadNegocio";

export function OportunidadNegocio({ title = "Oportunidad Negocio" }: { title?: string }) {
  return <OportunidadNegocioList title={title} />;
}
export function OportunidadNegocioList({ title = "Oportunidad Negocio " }: { title?: string }) {
  return (
    <div aria-label={title} className="h-full min-h-0">
      <OportunidadNegocioWindow />
    </div>
  );
}
