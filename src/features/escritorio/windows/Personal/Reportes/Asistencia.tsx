import { PersonalReportList } from "./PersonalReportList";

export function AsistenciaList() {
  return (
    <PersonalReportList
      title="Reporte de Asistencia"
      columns={[
        "Fecha",
        "Código",
        "Colaborador",
        "Área",
        "Entrada",
        "Salida",
        "Tardanza",
        "Estado",
      ]}
    />
  );
}

export function Asistencia() {
  return <AsistenciaList />;
}
