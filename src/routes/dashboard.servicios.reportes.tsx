import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ServiciosReportesPage from '@/modules/Servicios/pages/reportes'

export const Route = createFileRoute('/dashboard/servicios/reportes')({
  component: () => (
    <DashboardLayout>
      <ServiciosReportesPage />
    </DashboardLayout>
  ),
})
