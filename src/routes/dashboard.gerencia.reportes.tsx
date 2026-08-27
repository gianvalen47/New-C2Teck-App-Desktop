import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import GerenciaReportesPage from '@/modules/Gerencia/pages/reportes'

export const Route = createFileRoute('/dashboard/gerencia/reportes')({
  component: () => (
    <DashboardLayout>
      <GerenciaReportesPage />
    </DashboardLayout>
  ),
})
