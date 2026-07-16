import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Costos from '@/modules/Costos/pages'

export const Route = createFileRoute('/dashboard/costos')({
  component: () => (
    <DashboardLayout>
      <Costos />
    </DashboardLayout>
  ),
})
