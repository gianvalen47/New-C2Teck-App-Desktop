import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function CuentasCorrientes({ title = "Cuentas Corrientes" }: { title?: string }) {
  return <CuentasCorrientesList title={title} />;
}
export function CuentasCorrientesList({ title = "Cuentas Corrientes " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
