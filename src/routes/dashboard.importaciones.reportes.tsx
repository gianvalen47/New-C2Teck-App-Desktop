import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ImportacionesReportesPage from '@/modules/Importaciones/pages/reportes'

export const Route = createFileRoute('/dashboard/importaciones/reportes')({
  component: () => (
    <DashboardLayout>
      <ImportacionesReportesPage />
    </DashboardLayout>
  ),
})
