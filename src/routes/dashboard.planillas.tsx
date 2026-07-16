import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Planillas from '@/modules/Planillas/pages'

export const Route = createFileRoute('/dashboard/planillas')({
  component: () => (
    <DashboardLayout>
      <Planillas />
    </DashboardLayout>
  ),
})
