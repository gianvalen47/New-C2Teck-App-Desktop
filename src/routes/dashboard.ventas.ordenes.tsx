import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import VentasOrdenesPage from '@/modules/Ventas/pages/ordenes'

export const Route = createFileRoute('/dashboard/ventas/ordenes')({
  component: () => (
    <DashboardLayout>
      <VentasOrdenesPage />
    </DashboardLayout>
  ),
})
