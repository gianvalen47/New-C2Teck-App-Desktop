import { PersonalReportList } from "./PersonalReportList";

export function CapacitacionesList() {
  return (
    <PersonalReportList
      title="Reporte de Capacitaciones"
      columns={[
        "Código",
        "Colaborador",
        "Capacitación",
        "Instructor",
        "Fecha",
        "Horas",
        "Resultado",
        "Estado",
      ]}
    />
  );
}

export function Capacitaciones() {
  return <CapacitacionesList />;
}
