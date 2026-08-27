import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import AlmacenReportesPage from '@/modules/Almacen/pages/reportes'

export const Route = createFileRoute('/dashboard/almacen/reportes')({
  component: () => (
    <DashboardLayout>
      <AlmacenReportesPage />
    </DashboardLayout>
  ),
})
