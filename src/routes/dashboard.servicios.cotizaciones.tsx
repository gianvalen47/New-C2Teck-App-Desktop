import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ServiciosCotizacionesPage from '@/modules/Servicios/pages/cotizaciones'

export const Route = createFileRoute('/dashboard/servicios/cotizaciones')({
  component: () => (
    <DashboardLayout>
      <ServiciosCotizacionesPage />
    </DashboardLayout>
  ),
})
