import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CostosImportacionesPage from '@/modules/Costos/pages/importaciones'

export const Route = createFileRoute('/dashboard/costos/importaciones')({
  component: () => (
    <DashboardLayout>
      <CostosImportacionesPage />
    </DashboardLayout>
  ),
})
