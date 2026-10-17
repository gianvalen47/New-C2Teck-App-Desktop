import { PersonalReportList } from "./PersonalReportList";

export function ReporteCronogramaMinaList() {
  return (
    <PersonalReportList
      title="Cronograma de Mina"
      columns={[
        "Código",
        "Colaborador",
        "Unidad minera",
        "Régimen",
        "Inicio",
        "Fin",
        "Días",
        "Estado",
      ]}
    />
  );
}

export function ReporteCronogramaMina() {
  return <ReporteCronogramaMinaList />;
}
