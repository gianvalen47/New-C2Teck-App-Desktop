import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CreditosAprobacionesPage from '@/modules/Creditos/pages/aprobaciones'

export const Route = createFileRoute('/dashboard/creditos/aprobaciones')({
  component: () => (
    <DashboardLayout>
      <CreditosAprobacionesPage />
    </DashboardLayout>
  ),
})
