import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ServiciosMantenimientoPage from '@/modules/Servicios/pages/mantenimiento'

export const Route = createFileRoute('/dashboard/servicios/mantenimiento')({
  component: () => (
    <DashboardLayout>
      <ServiciosMantenimientoPage />
    </DashboardLayout>
  ),
})
