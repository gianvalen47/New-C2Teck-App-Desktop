import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function Productividad({ title = "Productividad" }: { title?: string }) {
  return <ProductividadList title={title} />;
}
export function ProductividadList({ title = "Productividad " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
