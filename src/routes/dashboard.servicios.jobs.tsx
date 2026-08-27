import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ServiciosJobsPage from '@/modules/Servicios/pages/jobs'

export const Route = createFileRoute('/dashboard/servicios/jobs')({
  component: () => (
    <DashboardLayout>
      <ServiciosJobsPage />
    </DashboardLayout>
  ),
})
