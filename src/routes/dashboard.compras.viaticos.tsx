import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ComprasViaticosPage from '@/modules/Compras/pages/viaticos'

export const Route = createFileRoute('/dashboard/compras/viaticos')({
  component: () => (
    <DashboardLayout>
      <ComprasViaticosPage />
    </DashboardLayout>
  ),
})
