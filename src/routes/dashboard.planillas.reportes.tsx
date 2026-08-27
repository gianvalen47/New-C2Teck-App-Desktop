import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import PlanillasReportesPage from '@/modules/Planillas/pages/reportes'

export const Route = createFileRoute('/dashboard/planillas/reportes')({
  component: () => (
    <DashboardLayout>
      <PlanillasReportesPage />
    </DashboardLayout>
  ),
})
