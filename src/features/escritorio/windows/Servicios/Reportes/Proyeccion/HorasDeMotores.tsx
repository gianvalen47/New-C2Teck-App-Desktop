import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function HorasDeMotores({ title = "Horas De Motores" }: { title?: string }) {
  return <HorasDeMotoresList title={title} />;
}
export function HorasDeMotoresList({ title = "Horas De Motores " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
