import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ContabilidadProvisionalPage from '@/modules/Contabilidad/pages/provisional'

export const Route = createFileRoute('/dashboard/contabilidad/provisional')({
  component: () => (
    <DashboardLayout>
      <ContabilidadProvisionalPage />
    </DashboardLayout>
  ),
})
