import { PersonalReportList } from "./PersonalReportList";

export function ContratosList() {
  return (
    <PersonalReportList
      title="Reporte de Contratos"
      columns={["Código", "Colaborador", "Tipo de contrato", "Inicio", "Fin", "Área", "Estado"]}
    />
  );
}

export function Contratos() {
  return <ContratosList />;
}
