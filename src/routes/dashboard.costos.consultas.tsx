import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CostosConsultasPage from '@/modules/Costos/pages/consultas'

export const Route = createFileRoute('/dashboard/costos/consultas')({
  component: () => (
    <DashboardLayout>
      <CostosConsultasPage />
    </DashboardLayout>
  ),
})
