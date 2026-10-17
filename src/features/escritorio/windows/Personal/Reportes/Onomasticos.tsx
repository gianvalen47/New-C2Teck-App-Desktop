import { PersonalReportList } from "./PersonalReportList";

export function OnomasticosList() {
  return (
    <PersonalReportList
      title="Reporte de Onomásticos"
      columns={[
        "Código",
        "Colaborador",
        "Área",
        "Fecha de nacimiento",
        "Fecha de celebración",
        "Estado",
      ]}
    />
  );
}

export function Onomasticos() {
  return <OnomasticosList />;
}
