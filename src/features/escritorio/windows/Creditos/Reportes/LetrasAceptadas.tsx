import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function LetrasAceptadas({ title = "Letras Aceptadas" }: { title?: string }) {
  return <LetrasAceptadasList title={title} />;
}
export function LetrasAceptadasList({ title = "Letras Aceptadas " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
