import { RegistryWindowList } from "@/features/escritorio/windows/shared/RegistryWindowList";

export function VentaCotizacion({ title = "Venta Cotizacion" }: { title?: string }) {
  return <VentaCotizacionList title={title} />;
}
export function VentaCotizacionList({ title = "Venta Cotizacion " }: { title?: string }) {
  return <RegistryWindowList title={title} />;
}
