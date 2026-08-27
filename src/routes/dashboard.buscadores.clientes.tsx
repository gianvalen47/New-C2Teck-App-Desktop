import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import BuscadoresClientesPage from '@/modules/Buscadores/pages/clientes'

export const Route = createFileRoute('/dashboard/buscadores/clientes')({
  component: () => (
    <DashboardLayout>
      <BuscadoresClientesPage />
    </DashboardLayout>
  ),
})
