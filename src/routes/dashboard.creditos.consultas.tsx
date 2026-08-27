import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CreditosConsultasPage from '@/modules/Creditos/pages/consultas'

export const Route = createFileRoute('/dashboard/creditos/consultas')({
  component: () => (
    <DashboardLayout>
      <CreditosConsultasPage />
    </DashboardLayout>
  ),
})
