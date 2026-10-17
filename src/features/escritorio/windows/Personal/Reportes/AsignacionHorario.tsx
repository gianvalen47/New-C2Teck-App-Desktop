import { PersonalReportList } from "./PersonalReportList";

export function AsignacionHorarioList() {
  return (
    <PersonalReportList
      title="Asignación de Horarios"
      columns={[
        "Código",
        "Colaborador",
        "Área",
        "Horario",
        "Entrada",
        "Salida",
        "Vigencia",
        "Estado",
      ]}
    />
  );
}

export function AsignacionHorario() {
  return <AsignacionHorarioList />;
}
