import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import GerenciaIndicadoresPage from '@/modules/Gerencia/pages/indicadores'

export const Route = createFileRoute('/dashboard/gerencia/indicadores')({
  component: () => (
    <DashboardLayout>
      <GerenciaIndicadoresPage />
    </DashboardLayout>
  ),
})
