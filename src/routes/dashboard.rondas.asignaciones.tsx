import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import RondasAsignacionesPage from '@/modules/Rondas/pages/asignaciones'

export const Route = createFileRoute('/dashboard/rondas/asignaciones')({
  component: () => (
    <DashboardLayout>
      <RondasAsignacionesPage />
    </DashboardLayout>
  ),
})
