import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import PersonalReportesPage from '@/modules/Personal/pages/reportes'

export const Route = createFileRoute('/dashboard/personal/reportes')({
  component: () => (
    <DashboardLayout>
      <PersonalReportesPage />
    </DashboardLayout>
  ),
})
