import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ProyeccionDeReparaciones({
  title = "Proyeccion De Reparaciones",
}: {
  title?: string;
}) {
  return <ProyeccionDeReparacionesList title={title} />;
}
export function ProyeccionDeReparacionesList({
  title = "Proyeccion De Reparaciones ",
}: {
  title?: string;
}) {
  return <RegistryWindowList title={title} />;
}
