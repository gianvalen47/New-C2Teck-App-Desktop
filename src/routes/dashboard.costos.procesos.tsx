import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CostosProcesosPage from '@/modules/Costos/pages/procesos'

export const Route = createFileRoute('/dashboard/costos/procesos')({
  component: () => (
    <DashboardLayout>
      <CostosProcesosPage />
    </DashboardLayout>
  ),
})
