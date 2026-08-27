import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import AlmacenDespachoPage from '@/modules/Almacen/pages/despacho'

export const Route = createFileRoute('/dashboard/almacen/despacho')({
  component: () => (
    <DashboardLayout>
      <AlmacenDespachoPage />
    </DashboardLayout>
  ),
})
