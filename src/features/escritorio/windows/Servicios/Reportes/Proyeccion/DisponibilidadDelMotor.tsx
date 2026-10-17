import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function DisponibilidadDelMotor({ title = "Disponibilidad Del Motor" }: { title?: string }) {
  return <DisponibilidadDelMotorList title={title} />;
}
export function DisponibilidadDelMotorList({
  title = "Disponibilidad Del Motor ",
}: {
  title?: string;
}) {
  return <RegistryWindowList title={title} />;
}
