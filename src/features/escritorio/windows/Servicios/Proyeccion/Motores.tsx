import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function Motores({ title = "Motores" }: { title?: string }) {
  return <MotoresList title={title} />;
}
export function MotoresList({ title = "Motores " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
