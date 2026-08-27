import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import AdministracionConfiguracionPage from '@/modules/Administracion/pages/configuracion'

export const Route = createFileRoute('/dashboard/administracion/configuracion')({
  component: () => (
    <DashboardLayout>
      <AdministracionConfiguracionPage />
    </DashboardLayout>
  ),
})
