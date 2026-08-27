import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import B2mPedidosPage from '@/modules/B2M/pages/pedidos'

export const Route = createFileRoute('/dashboard/b2m/pedidos')({
  component: () => (
    <DashboardLayout>
      <B2mPedidosPage />
    </DashboardLayout>
  ),
})
