import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import PersonalDirectorioPage from '@/modules/Personal/pages/directorio'

export const Route = createFileRoute('/dashboard/personal/directorio')({
  component: () => (
    <DashboardLayout>
      <PersonalDirectorioPage />
    </DashboardLayout>
  ),
})
