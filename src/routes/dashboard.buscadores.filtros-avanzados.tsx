import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import BuscadoresFiltrosAvanzadosPage from '@/modules/Buscadores/pages/filtros-avanzados'

export const Route = createFileRoute('/dashboard/buscadores/filtros-avanzados')({
  component: () => (
    <DashboardLayout>
      <BuscadoresFiltrosAvanzadosPage />
    </DashboardLayout>
  ),
})
