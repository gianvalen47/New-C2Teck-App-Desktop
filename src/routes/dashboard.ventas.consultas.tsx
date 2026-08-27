import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import VentasConsultasPage from '@/modules/Ventas/pages/consultas'

export const Route = createFileRoute('/dashboard/ventas/consultas')({
  component: () => (
    <DashboardLayout>
      <VentasConsultasPage />
    </DashboardLayout>
  ),
})
