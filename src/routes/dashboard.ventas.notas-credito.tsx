import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import VentasNotasCreditoPage from '@/modules/Ventas/pages/notas-credito'

export const Route = createFileRoute('/dashboard/ventas/notas-credito')({
  component: () => (
    <DashboardLayout>
      <VentasNotasCreditoPage />
    </DashboardLayout>
  ),
})
