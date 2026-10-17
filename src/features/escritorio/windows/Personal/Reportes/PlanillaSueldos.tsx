import { PersonalReportList } from "./PersonalReportList";

export function ReportePlanillaSueldosList() {
  return (
    <PersonalReportList
      title="Reporte de Planilla de Sueldos"
      columns={[
        "Código",
        "Colaborador",
        "Cargo",
        "Sueldo básico",
        "Ingresos",
        "Descuentos",
        "Neto",
      ]}
    />
  );
}

export function ReportePlanillaSueldos() {
  return <ReportePlanillaSueldosList />;
}
