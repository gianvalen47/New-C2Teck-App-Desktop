import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function AlmacenMTI({
  title = "Mantenimiento de Transferencias Internas",
}: {
  title?: string;
}) {
  return <AlmacenMTIList title={title} />;
}
export function AlmacenMTIList({ title = "Almacen MTI " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
