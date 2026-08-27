import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import AlmacenConsultasPage from '@/modules/Almacen/pages/consultas'

export const Route = createFileRoute('/dashboard/almacen/consultas')({
  component: () => (
    <DashboardLayout>
      <AlmacenConsultasPage />
    </DashboardLayout>
  ),
})
