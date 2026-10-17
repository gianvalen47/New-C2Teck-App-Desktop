import { PersonalReportList } from "./PersonalReportList";

export function TardanzasList() {
  return (
    <PersonalReportList
      title="Reporte de Tardanzas"
      columns={[
        "Fecha",
        "Código",
        "Colaborador",
        "Área",
        "Hora programada",
        "Hora de ingreso",
        "Minutos",
        "Estado",
      ]}
    />
  );
}

export function Tardanzas() {
  return <TardanzasList />;
}
