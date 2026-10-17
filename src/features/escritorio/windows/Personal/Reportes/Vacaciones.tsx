import { PersonalReportList } from "./PersonalReportList";

export function ReporteVacacionesList() {
  return (
    <PersonalReportList
      title="Reporte de Vacaciones"
      columns={[
        "Código",
        "Colaborador",
        "Área",
        "Días disponibles",
        "Inicio",
        "Fin",
        "Retorno",
        "Estado",
      ]}
    />
  );
}

export function ReporteVacaciones() {
  return <ReporteVacacionesList />;
}
