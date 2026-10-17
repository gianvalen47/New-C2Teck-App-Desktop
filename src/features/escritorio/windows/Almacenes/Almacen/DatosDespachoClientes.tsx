import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";


export function DatosDespachoWindow() {
  return <DatosDespachoList />;
}

export function DatosDespachoList({ title = "Datos de Despacho de Clientes" }: { title?: string }) {
  return (
    <RegistryWindowList
      title={title}
      columns={[
        "Cliente",
        "Lugar Entrega",
        "Cita",
        "Tiempo At.",
        "Tipo Almacén",
        "Documento",
        "Horario Atención",
        "Día Atención",
        "Contacto",
        "Zona",
        "Prioridad",
        "Observación",
      ]}
    />
  );
}
