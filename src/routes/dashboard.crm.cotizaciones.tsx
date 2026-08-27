import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CrmCotizacionesPage from '@/modules/CRM/pages/cotizaciones'

export const Route = createFileRoute('/dashboard/crm/cotizaciones')({
  component: () => (
    <DashboardLayout>
      <CrmCotizacionesPage />
    </DashboardLayout>
  ),
})
