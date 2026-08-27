import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ComprasOrdenesCompraPage from '@/modules/Compras/pages/ordenes-compra'

export const Route = createFileRoute('/dashboard/compras/ordenes-compra')({
  component: () => (
    <DashboardLayout>
      <ComprasOrdenesCompraPage />
    </DashboardLayout>
  ),
})
