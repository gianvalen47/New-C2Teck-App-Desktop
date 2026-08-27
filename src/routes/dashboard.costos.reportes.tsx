import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CostosReportesPage from '@/modules/Costos/pages/reportes'

export const Route = createFileRoute('/dashboard/costos/reportes')({
  component: () => (
    <DashboardLayout>
      <CostosReportesPage />
    </DashboardLayout>
  ),
})
