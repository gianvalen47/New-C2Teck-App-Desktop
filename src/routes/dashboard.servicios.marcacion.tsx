import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ServiciosMarcacionPage from '@/modules/Servicios/pages/marcacion'

export const Route = createFileRoute('/dashboard/servicios/marcacion')({
  component: () => (
    <DashboardLayout>
      <ServiciosMarcacionPage />
    </DashboardLayout>
  ),
})
