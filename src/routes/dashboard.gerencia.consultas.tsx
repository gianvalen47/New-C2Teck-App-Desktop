import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import GerenciaConsultasPage from '@/modules/Gerencia/pages/consultas'

export const Route = createFileRoute('/dashboard/gerencia/consultas')({
  component: () => (
    <DashboardLayout>
      <GerenciaConsultasPage />
    </DashboardLayout>
  ),
})
