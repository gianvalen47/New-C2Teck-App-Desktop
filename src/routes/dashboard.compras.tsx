import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Compras from '@/modules/Compras/pages'

export const Route = createFileRoute('/dashboard/compras')({
  component: () => (
    <DashboardLayout>
      <Compras />
    </DashboardLayout>
  ),
})
