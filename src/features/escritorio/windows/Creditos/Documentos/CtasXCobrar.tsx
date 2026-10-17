import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function DocCtasXCobrar({ title = "Doc Ctas X Cobrar" }: { title?: string }) {
  return <DocCtasXCobrarList title={title} />;
}
export function DocCtasXCobrarList({ title = "Doc Ctas X Cobrar " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
