import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Buscadores from '@/modules/Buscadores/pages'

export const Route = createFileRoute('/dashboard/buscadores')({
  component: () => (
    <DashboardLayout>
      <Buscadores />
    </DashboardLayout>
  ),
})
