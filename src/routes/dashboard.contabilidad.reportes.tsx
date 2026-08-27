import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ContabilidadReportesPage from '@/modules/Contabilidad/pages/reportes'

export const Route = createFileRoute('/dashboard/contabilidad/reportes')({
  component: () => (
    <DashboardLayout>
      <ContabilidadReportesPage />
    </DashboardLayout>
  ),
})
