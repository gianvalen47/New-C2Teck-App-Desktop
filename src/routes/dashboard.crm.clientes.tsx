import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CrmClientesPage from '@/modules/CRM/pages/clientes'

export const Route = createFileRoute('/dashboard/crm/clientes')({
  component: () => (
    <DashboardLayout>
      <CrmClientesPage />
    </DashboardLayout>
  ),
})
