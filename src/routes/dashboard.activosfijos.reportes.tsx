import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ActivosfijosReportesPage from '@/modules/ActivosFijos/pages/reportes'

export const Route = createFileRoute('/dashboard/activosfijos/reportes')({
  component: () => (
    <DashboardLayout>
      <ActivosfijosReportesPage />
    </DashboardLayout>
  ),
})
