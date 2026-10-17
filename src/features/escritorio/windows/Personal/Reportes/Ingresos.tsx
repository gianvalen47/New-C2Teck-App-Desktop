import { PersonalReportList } from "./PersonalReportList";

export function ReporteIngresosList() {
  return (
    <PersonalReportList
      title="Reporte de Ingresos de Personal"
      columns={["Fecha", "Código", "Colaborador", "Tipo de ingreso", "Área", "Cargo", "Estado"]}
    />
  );
}

export function ReporteIngresos() {
  return <ReporteIngresosList />;
}
