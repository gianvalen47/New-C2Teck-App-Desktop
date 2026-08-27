import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import PersonalComunicacionPage from '@/modules/Personal/pages/comunicacion'

export const Route = createFileRoute('/dashboard/personal/comunicacion')({
  component: () => (
    <DashboardLayout>
      <PersonalComunicacionPage />
    </DashboardLayout>
  ),
})
