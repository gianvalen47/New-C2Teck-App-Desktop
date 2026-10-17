import { PersonalReportList } from "./PersonalReportList";

export function HorasExtraList() {
  return (
    <PersonalReportList
      title="Reporte de Horas Extras"
      columns={["Fecha", "Código", "Colaborador", "Área", "Horas", "Tarifa", "Importe", "Estado"]}
    />
  );
}

export function HorasExtra() {
  return <HorasExtraList />;
}
