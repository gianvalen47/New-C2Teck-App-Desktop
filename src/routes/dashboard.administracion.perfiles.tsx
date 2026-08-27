import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import AdministracionPerfilesPage from '@/modules/Administracion/pages/perfiles'

export const Route = createFileRoute('/dashboard/administracion/perfiles')({
  component: () => (
    <DashboardLayout>
      <AdministracionPerfilesPage />
    </DashboardLayout>
  ),
})
