import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import TelefoniaLineasPage from '@/modules/Telefonia/pages/lineas'

export const Route = createFileRoute('/dashboard/telefonia/lineas')({
  component: () => (
    <DashboardLayout>
      <TelefoniaLineasPage />
    </DashboardLayout>
  ),
})
