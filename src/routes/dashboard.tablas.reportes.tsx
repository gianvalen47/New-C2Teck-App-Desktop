import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import TablasReportesPage from '@/modules/Tablas/pages/reportes'

export const Route = createFileRoute('/dashboard/tablas/reportes')({
  component: () => (
    <DashboardLayout>
      <TablasReportesPage />
    </DashboardLayout>
  ),
})
