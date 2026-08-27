import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ComprasConsultasPage from '@/modules/Compras/pages/consultas'

export const Route = createFileRoute('/dashboard/compras/consultas')({
  component: () => (
    <DashboardLayout>
      <ComprasConsultasPage />
    </DashboardLayout>
  ),
})
