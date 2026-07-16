import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Servicios from '@/modules/Servicios/pages'

export const Route = createFileRoute('/dashboard/servicios')({
  component: () => (
    <DashboardLayout>
      <Servicios />
    </DashboardLayout>
  ),
})
