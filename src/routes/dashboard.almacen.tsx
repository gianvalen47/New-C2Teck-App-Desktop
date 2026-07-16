import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Almacen from '@/modules/Almacen/pages'

export const Route = createFileRoute('/dashboard/almacen')({
  component: () => (
    <DashboardLayout>
      <Almacen />
    </DashboardLayout>
  ),
})
