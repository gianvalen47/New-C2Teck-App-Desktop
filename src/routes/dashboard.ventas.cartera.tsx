import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import VentasCarteraPage from '@/modules/Ventas/pages/cartera'

export const Route = createFileRoute('/dashboard/ventas/cartera')({
  component: () => (
    <DashboardLayout>
      <VentasCarteraPage />
    </DashboardLayout>
  ),
})
