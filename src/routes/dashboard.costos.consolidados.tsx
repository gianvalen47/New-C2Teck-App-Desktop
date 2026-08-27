import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CostosConsolidadosPage from '@/modules/Costos/pages/consolidados'

export const Route = createFileRoute('/dashboard/costos/consolidados')({
  component: () => (
    <DashboardLayout>
      <CostosConsolidadosPage />
    </DashboardLayout>
  ),
})
