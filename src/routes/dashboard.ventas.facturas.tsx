import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import VentasFacturasPage from '@/modules/Ventas/pages/facturas'

export const Route = createFileRoute('/dashboard/ventas/facturas')({
  component: () => (
    <DashboardLayout>
      <VentasFacturasPage />
    </DashboardLayout>
  ),
})
