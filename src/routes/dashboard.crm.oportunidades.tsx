import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CrmOportunidadesPage from '@/modules/CRM/pages/oportunidades'

export const Route = createFileRoute('/dashboard/crm/oportunidades')({
  component: () => (
    <DashboardLayout>
      <CrmOportunidadesPage />
    </DashboardLayout>
  ),
})
