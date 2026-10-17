import { PersonalReportList } from "./PersonalReportList";

export function ReporteRecursosList() {
  return (
    <PersonalReportList
      title="Reporte de Recursos"
      columns={[
        "Código",
        "Colaborador",
        "Área",
        "Recurso asignado",
        "Fecha de entrega",
        "Devolución",
        "Estado",
      ]}
    />
  );
}

export function ReporteRecursos() {
  return <ReporteRecursosList />;
}
