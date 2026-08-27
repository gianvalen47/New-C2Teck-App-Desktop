import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ComprasSolicitudesPage from '@/modules/Compras/pages/solicitudes'

export const Route = createFileRoute('/dashboard/compras/solicitudes')({
  component: () => (
    <DashboardLayout>
      <ComprasSolicitudesPage />
    </DashboardLayout>
  ),
})
