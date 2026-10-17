import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function HorasMotor({ title = "Horas Motor" }: { title?: string }) {
  return <HorasMotorList title={title} />;
}
export function HorasMotorList({ title = "Horas Motor " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
