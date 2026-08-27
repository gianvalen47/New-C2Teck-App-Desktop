import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ComprasReportesPage from '@/modules/Compras/pages/reportes'

export const Route = createFileRoute('/dashboard/compras/reportes')({
  component: () => (
    <DashboardLayout>
      <ComprasReportesPage />
    </DashboardLayout>
  ),
})
