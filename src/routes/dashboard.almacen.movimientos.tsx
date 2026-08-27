import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import AlmacenMovimientosPage from '@/modules/Almacen/pages/movimientos'

export const Route = createFileRoute('/dashboard/almacen/movimientos')({
  component: () => (
    <DashboardLayout>
      <AlmacenMovimientosPage />
    </DashboardLayout>
  ),
})
