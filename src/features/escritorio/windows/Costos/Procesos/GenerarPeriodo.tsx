import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function GenerarPeriodo({ title = "Generar Periodo" }: { title?: string }) {
  return <GenerarPeriodoList title={title} />;
}
export function GenerarPeriodoList({ title = "Generar Periodo " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
