import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ImportacionesPedidosPage from '@/modules/Importaciones/pages/pedidos'

export const Route = createFileRoute('/dashboard/importaciones/pedidos')({
  component: () => (
    <DashboardLayout>
      <ImportacionesPedidosPage />
    </DashboardLayout>
  ),
})
