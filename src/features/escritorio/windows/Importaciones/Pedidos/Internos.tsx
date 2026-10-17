import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function Internos({ title = "Internos" }: { title?: string }) {
  return <InternosList title={title} />;
}
export function InternosList({ title = "Internos " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
