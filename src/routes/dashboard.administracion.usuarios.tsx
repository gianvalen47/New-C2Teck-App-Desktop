import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import AdministracionUsuariosPage from '@/modules/Administracion/pages/usuarios'

export const Route = createFileRoute('/dashboard/administracion/usuarios')({
  component: () => (
    <DashboardLayout>
      <AdministracionUsuariosPage />
    </DashboardLayout>
  ),
})
