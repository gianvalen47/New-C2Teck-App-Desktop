import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import BuscadoresComponentesPage from '@/modules/Buscadores/pages/componentes'

export const Route = createFileRoute('/dashboard/buscadores/componentes')({
  component: () => (
    <DashboardLayout>
      <BuscadoresComponentesPage />
    </DashboardLayout>
  ),
})
