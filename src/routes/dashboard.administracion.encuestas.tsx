import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import AdministracionEncuestasPage from '@/modules/Administracion/pages/encuestas'

export const Route = createFileRoute('/dashboard/administracion/encuestas')({
  component: () => (
    <DashboardLayout>
      <AdministracionEncuestasPage />
    </DashboardLayout>
  ),
})
