import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function CtasCtes({ title = "Ctas Ctes" }: { title?: string }) {
  return <CtasCtesList title={title} />;
}
export function CtasCtesList({ title = "Ctas Ctes " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
