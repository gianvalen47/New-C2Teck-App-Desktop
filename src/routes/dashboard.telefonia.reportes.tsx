import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import TelefoniaReportesPage from '@/modules/Telefonia/pages/reportes'

export const Route = createFileRoute('/dashboard/telefonia/reportes')({
  component: () => (
    <DashboardLayout>
      <TelefoniaReportesPage />
    </DashboardLayout>
  ),
})
