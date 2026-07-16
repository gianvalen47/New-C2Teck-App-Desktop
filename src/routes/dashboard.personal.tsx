import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Personal from '@/modules/Personal/pages'

export const Route = createFileRoute('/dashboard/personal')({
  component: () => (
    <DashboardLayout>
      <Personal />
    </DashboardLayout>
  ),
})
