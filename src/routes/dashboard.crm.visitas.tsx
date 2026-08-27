import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CrmVisitasPage from '@/modules/CRM/pages/visitas'

export const Route = createFileRoute('/dashboard/crm/visitas')({
  component: () => (
    <DashboardLayout>
      <CrmVisitasPage />
    </DashboardLayout>
  ),
})
