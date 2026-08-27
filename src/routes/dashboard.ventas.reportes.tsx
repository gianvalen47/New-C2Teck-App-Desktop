import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import VentasReportesPage from '@/modules/Ventas/pages/reportes'

export const Route = createFileRoute('/dashboard/ventas/reportes')({
  component: () => (
    <DashboardLayout>
      <VentasReportesPage />
    </DashboardLayout>
  ),
})
