import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ContabilidadConsultasPage from '@/modules/Contabilidad/pages/consultas'

export const Route = createFileRoute('/dashboard/contabilidad/consultas')({
  component: () => (
    <DashboardLayout>
      <ContabilidadConsultasPage />
    </DashboardLayout>
  ),
})
