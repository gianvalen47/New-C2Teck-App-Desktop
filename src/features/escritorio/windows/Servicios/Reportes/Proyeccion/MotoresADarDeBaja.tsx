import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function MotoresADarDeBaja({ title = "Motores A Dar De Baja" }: { title?: string }) {
  return <MotoresADarDeBajaList title={title} />;
}
export function MotoresADarDeBajaList({ title = "Motores A Dar De Baja " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
