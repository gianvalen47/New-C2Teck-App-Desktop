import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Administracion from '@/modules/Administracion/pages'

export const Route = createFileRoute('/dashboard/administracion')({
  component: () => (
    <DashboardLayout>
      <Administracion />
    </DashboardLayout>
  ),
})
