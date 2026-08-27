import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ActivosfijosConsultasPage from '@/modules/ActivosFijos/pages/consultas'

export const Route = createFileRoute('/dashboard/activosfijos/consultas')({
  component: () => (
    <DashboardLayout>
      <ActivosfijosConsultasPage />
    </DashboardLayout>
  ),
})
