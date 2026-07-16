import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Gerencia from '@/modules/Gerencia/pages'

export const Route = createFileRoute('/dashboard/gerencia')({
  component: () => (
    <DashboardLayout>
      <Gerencia />
    </DashboardLayout>
  ),
})
