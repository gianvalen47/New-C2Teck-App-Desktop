import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function ConsultasMarcaciones({ title = "Consultas Marcaciones" }: { title?: string }) {
  return <ConsultasMarcacionesList title={title} />;
}
export function ConsultasMarcacionesList({ title = "Consultas Marcaciones " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
