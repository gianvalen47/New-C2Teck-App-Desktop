import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import GerenciaEstadoFinancieroPage from '@/modules/Gerencia/pages/estado-financiero'

export const Route = createFileRoute('/dashboard/gerencia/estado-financiero')({
  component: () => (
    <DashboardLayout>
      <GerenciaEstadoFinancieroPage />
    </DashboardLayout>
  ),
})
