import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function HorasMuertas({ title = "Horas Muertas" }: { title?: string }) {
  return <HorasMuertasList title={title} />;
}
export function HorasMuertasList({ title = "Horas Muertas " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
