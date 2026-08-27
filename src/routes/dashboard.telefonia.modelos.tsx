import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import TelefoniaModelosPage from '@/modules/Telefonia/pages/modelos'

export const Route = createFileRoute('/dashboard/telefonia/modelos')({
  component: () => (
    <DashboardLayout>
      <TelefoniaModelosPage />
    </DashboardLayout>
  ),
})
