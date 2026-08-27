import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CrmConsultasPage from '@/modules/CRM/pages/consultas'

export const Route = createFileRoute('/dashboard/crm/consultas')({
  component: () => (
    <DashboardLayout>
      <CrmConsultasPage />
    </DashboardLayout>
  ),
})
