import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import TelefoniaAsignacionesPage from '@/modules/Telefonia/pages/asignaciones'

export const Route = createFileRoute('/dashboard/telefonia/asignaciones')({
  component: () => (
    <DashboardLayout>
      <TelefoniaAsignacionesPage />
    </DashboardLayout>
  ),
})
