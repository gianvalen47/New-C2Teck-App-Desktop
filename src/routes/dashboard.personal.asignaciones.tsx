import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import PersonalAsignacionesPage from '@/modules/Personal/pages/asignaciones'

export const Route = createFileRoute('/dashboard/personal/asignaciones')({
  component: () => (
    <DashboardLayout>
      <PersonalAsignacionesPage />
    </DashboardLayout>
  ),
})
