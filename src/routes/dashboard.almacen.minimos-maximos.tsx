import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import AlmacenMinimosMaximosPage from '@/modules/Almacen/pages/minimos-maximos'

export const Route = createFileRoute('/dashboard/almacen/minimos-maximos')({
  component: () => (
    <DashboardLayout>
      <AlmacenMinimosMaximosPage />
    </DashboardLayout>
  ),
})
