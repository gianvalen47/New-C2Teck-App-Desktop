import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CreditosLetrasPage from '@/modules/Creditos/pages/letras'

export const Route = createFileRoute('/dashboard/creditos/letras')({
  component: () => (
    <DashboardLayout>
      <CreditosLetrasPage />
    </DashboardLayout>
  ),
})
