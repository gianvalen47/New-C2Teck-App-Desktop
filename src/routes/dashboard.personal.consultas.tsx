import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import PersonalConsultasPage from '@/modules/Personal/pages/consultas'

export const Route = createFileRoute('/dashboard/personal/consultas')({
  component: () => (
    <DashboardLayout>
      <PersonalConsultasPage />
    </DashboardLayout>
  ),
})
