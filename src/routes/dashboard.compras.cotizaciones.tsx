import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ComprasCotizacionesPage from '@/modules/Compras/pages/cotizaciones'

export const Route = createFileRoute('/dashboard/compras/cotizaciones')({
  component: () => (
    <DashboardLayout>
      <ComprasCotizacionesPage />
    </DashboardLayout>
  ),
})
