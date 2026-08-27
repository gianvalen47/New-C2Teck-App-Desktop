import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import TablasUbicacionesPage from '@/modules/Tablas/pages/ubicaciones'

export const Route = createFileRoute('/dashboard/tablas/ubicaciones')({
  component: () => (
    <DashboardLayout>
      <TablasUbicacionesPage />
    </DashboardLayout>
  ),
})
