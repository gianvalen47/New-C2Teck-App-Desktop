import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import PlanillasQuintaPage from '@/modules/Planillas/pages/quinta'

export const Route = createFileRoute('/dashboard/planillas/quinta')({
  component: () => (
    <DashboardLayout>
      <PlanillasQuintaPage />
    </DashboardLayout>
  ),
})
