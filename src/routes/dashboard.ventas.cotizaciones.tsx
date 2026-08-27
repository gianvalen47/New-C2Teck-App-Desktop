import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import VentasCotizacionesPage from '@/modules/Ventas/pages/cotizaciones'

export const Route = createFileRoute('/dashboard/ventas/cotizaciones')({
  component: () => (
    <DashboardLayout>
      <VentasCotizacionesPage />
    </DashboardLayout>
  ),
})
