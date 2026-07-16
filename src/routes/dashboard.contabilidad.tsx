import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Contabilidad from '@/modules/Contabilidad/pages'

export const Route = createFileRoute('/dashboard/contabilidad')({
  component: () => (
    <DashboardLayout>
      <Contabilidad />
    </DashboardLayout>
  ),
})
