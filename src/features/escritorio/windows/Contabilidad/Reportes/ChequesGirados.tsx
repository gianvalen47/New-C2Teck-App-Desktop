import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ChequesGirados({ title = "Cheques Girados" }: { title?: string }) {
  return <ChequesGiradosList title={title} />;
}
export function ChequesGiradosList({ title = "Cheques Girados " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
