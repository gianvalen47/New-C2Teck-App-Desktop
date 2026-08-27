import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import VentasBoletasPage from '@/modules/Ventas/pages/boletas'

export const Route = createFileRoute('/dashboard/ventas/boletas')({
  component: () => (
    <DashboardLayout>
      <VentasBoletasPage />
    </DashboardLayout>
  ),
})
