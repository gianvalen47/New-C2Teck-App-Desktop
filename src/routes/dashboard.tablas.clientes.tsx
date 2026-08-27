import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import TablasClientesPage from '@/modules/Tablas/pages/clientes'

export const Route = createFileRoute('/dashboard/tablas/clientes')({
  component: () => (
    <DashboardLayout>
      <TablasClientesPage />
    </DashboardLayout>
  ),
})
