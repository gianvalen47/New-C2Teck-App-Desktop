import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CreditosReportesPage from '@/modules/Creditos/pages/reportes'

export const Route = createFileRoute('/dashboard/creditos/reportes')({
  component: () => (
    <DashboardLayout>
      <CreditosReportesPage />
    </DashboardLayout>
  ),
})
