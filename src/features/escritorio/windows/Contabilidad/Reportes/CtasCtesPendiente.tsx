import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function CtasCtesPendiente({ title = "Ctas Ctes Pendiente" }: { title?: string }) {
  return <CtasCtesPendienteList title={title} />;
}
export function CtasCtesPendienteList({ title = "Ctas Ctes Pendiente " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
