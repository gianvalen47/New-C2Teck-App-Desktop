import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import AlmacenUbicacionesPage from '@/modules/Almacen/pages/ubicaciones'

export const Route = createFileRoute('/dashboard/almacen/ubicaciones')({
  component: () => (
    <DashboardLayout>
      <AlmacenUbicacionesPage />
    </DashboardLayout>
  ),
})
