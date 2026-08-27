import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ContabilidadTesoreriaPage from '@/modules/Contabilidad/pages/tesoreria'

export const Route = createFileRoute('/dashboard/contabilidad/tesoreria')({
  component: () => (
    <DashboardLayout>
      <ContabilidadTesoreriaPage />
    </DashboardLayout>
  ),
})
