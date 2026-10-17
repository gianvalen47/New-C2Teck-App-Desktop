import { PersonalReportList } from "./PersonalReportList";

export function FaltasList() {
  return (
    <PersonalReportList
      title="Reporte de Faltas"
      columns={[
        "Fecha",
        "Código",
        "Colaborador",
        "Área",
        "Motivo",
        "Justificada",
        "Descuento",
        "Estado",
      ]}
    />
  );
}

export function Faltas() {
  return <FaltasList />;
}
