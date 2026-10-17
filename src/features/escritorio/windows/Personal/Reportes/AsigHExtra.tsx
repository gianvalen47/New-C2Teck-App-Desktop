import { PersonalReportList } from "./PersonalReportList";

export function AsigHExtraList() {
  return (
    <PersonalReportList
      title="Asignación de Horas Extras"
      columns={["Código", "Colaborador", "Área", "Fecha", "Horas", "Autorizado por", "Estado"]}
    />
  );
}

export function AsigHExtra() {
  return <AsigHExtraList />;
}
