import { PersonalReportList } from "./PersonalReportList";

export function ReporteDescuentosList() {
  return (
    <PersonalReportList
      title="Reporte de Descuentos"
      columns={["Código", "Colaborador", "Concepto", "Periodo", "Importe", "Motivo", "Estado"]}
    />
  );
}

export function ReporteDescuentos() {
  return <ReporteDescuentosList />;
}
