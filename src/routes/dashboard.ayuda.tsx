import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Ayuda from '@/modules/Ayuda/pages'

export const Route = createFileRoute('/dashboard/ayuda')({
  component: () => (
    <DashboardLayout>
      <Ayuda />
    </DashboardLayout>
  ),
})
