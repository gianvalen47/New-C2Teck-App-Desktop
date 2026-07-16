import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Ventas from '@/modules/Ventas/pages'

export const Route = createFileRoute('/dashboard/ventas')({
  component: () => (
    <DashboardLayout>
      <Ventas />
    </DashboardLayout>
  ),
})
