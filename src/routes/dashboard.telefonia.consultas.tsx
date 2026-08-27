import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import TelefoniaConsultasPage from '@/modules/Telefonia/pages/consultas'

export const Route = createFileRoute('/dashboard/telefonia/consultas')({
  component: () => (
    <DashboardLayout>
      <TelefoniaConsultasPage />
    </DashboardLayout>
  ),
})
