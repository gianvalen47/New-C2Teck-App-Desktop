import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function HorasEscalon({ title = "Horas Escalon" }: { title?: string }) {
  return <HorasEscalonList title={title} />;
}
export function HorasEscalonList({ title = "Horas Escalon " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
