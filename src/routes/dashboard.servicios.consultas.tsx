import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ServiciosConsultasPage from '@/modules/Servicios/pages/consultas'

export const Route = createFileRoute('/dashboard/servicios/consultas')({
  component: () => (
    <DashboardLayout>
      <ServiciosConsultasPage />
    </DashboardLayout>
  ),
})
