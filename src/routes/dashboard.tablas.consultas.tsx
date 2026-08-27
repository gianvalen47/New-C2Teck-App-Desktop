import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import TablasConsultasPage from '@/modules/Tablas/pages/consultas'

export const Route = createFileRoute('/dashboard/tablas/consultas')({
  component: () => (
    <DashboardLayout>
      <TablasConsultasPage />
    </DashboardLayout>
  ),
})
