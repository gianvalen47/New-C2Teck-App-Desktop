import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import PlanillasSueldosPage from '@/modules/Planillas/pages/sueldos'

export const Route = createFileRoute('/dashboard/planillas/sueldos')({
  component: () => (
    <DashboardLayout>
      <PlanillasSueldosPage />
    </DashboardLayout>
  ),
})
