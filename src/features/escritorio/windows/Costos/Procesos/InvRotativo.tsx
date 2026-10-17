import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function InvRotativo({ title = "Inv Rotativo" }: { title?: string }) {
  return <InvRotativoList title={title} />;
}
export function InvRotativoList({ title = "Inv Rotativo " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
