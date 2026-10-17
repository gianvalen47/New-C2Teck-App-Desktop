import { PersonalReportList } from "./PersonalReportList";

export function PersonalList() {
  return (
    <PersonalReportList
      title="Reporte de Personal"
      columns={[
        "Código",
        "Documento",
        "Colaborador",
        "Área",
        "Cargo",
        "Fecha de ingreso",
        "Estado",
      ]}
    />
  );
}

export function Personal() {
  return <PersonalList />;
}
