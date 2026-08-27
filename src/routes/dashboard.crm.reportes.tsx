import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CrmReportesPage from '@/modules/CRM/pages/reportes'

export const Route = createFileRoute('/dashboard/crm/reportes')({
  component: () => (
    <DashboardLayout>
      <CrmReportesPage />
    </DashboardLayout>
  ),
})
