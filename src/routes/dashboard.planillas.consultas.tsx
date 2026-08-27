import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import PlanillasConsultasPage from '@/modules/Planillas/pages/consultas'

export const Route = createFileRoute('/dashboard/planillas/consultas')({
  component: () => (
    <DashboardLayout>
      <PlanillasConsultasPage />
    </DashboardLayout>
  ),
})
