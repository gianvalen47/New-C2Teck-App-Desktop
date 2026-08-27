import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import GerenciaProyeccionesPage from '@/modules/Gerencia/pages/proyecciones'

export const Route = createFileRoute('/dashboard/gerencia/proyecciones')({
  component: () => (
    <DashboardLayout>
      <GerenciaProyeccionesPage />
    </DashboardLayout>
  ),
})
