import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import AdministracionReportesPage from '@/modules/Administracion/pages/reportes'

export const Route = createFileRoute('/dashboard/administracion/reportes')({
  component: () => (
    <DashboardLayout>
      <AdministracionReportesPage />
    </DashboardLayout>
  ),
})
