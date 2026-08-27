import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import B2mReportesPage from '@/modules/B2M/pages/reportes'

export const Route = createFileRoute('/dashboard/b2m/reportes')({
  component: () => (
    <DashboardLayout>
      <B2mReportesPage />
    </DashboardLayout>
  ),
})
