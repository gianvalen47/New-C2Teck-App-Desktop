import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CreditosAnticiposPage from '@/modules/Creditos/pages/anticipos'

export const Route = createFileRoute('/dashboard/creditos/anticipos')({
  component: () => (
    <DashboardLayout>
      <CreditosAnticiposPage />
    </DashboardLayout>
  ),
})
