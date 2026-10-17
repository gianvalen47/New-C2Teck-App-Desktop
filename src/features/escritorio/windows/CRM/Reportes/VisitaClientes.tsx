import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";
// Auto-extraido de windows (1).tsx (monolito legacy) — revisar antes de usar en produccion.
export { VisitaClientes } from "@/features/escritorio/windows/CRM/Oportunidades/VisitaClientes";

export function ReporteVisitaClientes({ title = "Reporte Visita Clientes" }: { title?: string }) {
  return <ReporteVisitaClientesList title={title} />;
}
export function ReporteVisitaClientesList({ title = "Reporte Visita Clientes " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
