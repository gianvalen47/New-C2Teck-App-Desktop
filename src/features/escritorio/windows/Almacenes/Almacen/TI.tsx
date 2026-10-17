import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function AlmacenTI({ title = "Transferencias Internas" }: { title?: string }) {
  return <AlmacenTIList title={title} />;
}
export function AlmacenTIList({ title = "Almacen TI " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
