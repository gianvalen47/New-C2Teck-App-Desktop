import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import TelefoniaEquiposPage from '@/modules/Telefonia/pages/equipos'

export const Route = createFileRoute('/dashboard/telefonia/equipos')({
  component: () => (
    <DashboardLayout>
      <TelefoniaEquiposPage />
    </DashboardLayout>
  ),
})
