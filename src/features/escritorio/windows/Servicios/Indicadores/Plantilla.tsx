import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function Plantilla({ title = "Plantilla" }: { title?: string }) {
  return <PlantillaList title={title} />;
}
export function PlantillaList({ title = "Plantilla " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
