import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Tablas from '@/modules/Tablas/pages'

export const Route = createFileRoute('/dashboard/tablas')({
  component: () => (
    <DashboardLayout>
      <Tablas />
    </DashboardLayout>
  ),
})
