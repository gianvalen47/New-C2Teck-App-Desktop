import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import VentasGuiasPage from '@/modules/Ventas/pages/guias'

export const Route = createFileRoute('/dashboard/ventas/guias')({
  component: () => (
    <DashboardLayout>
      <VentasGuiasPage />
    </DashboardLayout>
  ),
})
