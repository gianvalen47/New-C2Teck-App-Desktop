import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import B2M from '@/modules/B2M/pages'

export const Route = createFileRoute('/dashboard/b2m')({
  component: () => (
    <DashboardLayout>
      <B2M />
    </DashboardLayout>
  ),
})
