import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import AdministracionSesionesPage from '@/modules/Administracion/pages/sesiones'

export const Route = createFileRoute('/dashboard/administracion/sesiones')({
  component: () => (
    <DashboardLayout>
      <AdministracionSesionesPage />
    </DashboardLayout>
  ),
})
