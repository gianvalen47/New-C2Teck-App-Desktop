import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ActivosfijosCompraPage from '@/modules/ActivosFijos/pages/compra'

export const Route = createFileRoute('/dashboard/activosfijos/compra')({
  component: () => (
    <DashboardLayout>
      <ActivosfijosCompraPage />
    </DashboardLayout>
  ),
})
