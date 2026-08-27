import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import PersonalInformacionPage from '@/modules/Personal/pages/informacion'

export const Route = createFileRoute('/dashboard/personal/informacion')({
  component: () => (
    <DashboardLayout>
      <PersonalInformacionPage />
    </DashboardLayout>
  ),
})
