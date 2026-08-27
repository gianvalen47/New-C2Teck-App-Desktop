import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ContabilidadDiariosPage from '@/modules/Contabilidad/pages/diarios'

export const Route = createFileRoute('/dashboard/contabilidad/diarios')({
  component: () => (
    <DashboardLayout>
      <ContabilidadDiariosPage />
    </DashboardLayout>
  ),
})
