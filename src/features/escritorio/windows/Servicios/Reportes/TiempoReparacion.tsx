import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function TiempoReparacion({ title = "Tiempo Reparacion" }: { title?: string }) {
  return <TiempoReparacionList title={title} />;
}
export function TiempoReparacionList({ title = "Tiempo Reparacion " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
