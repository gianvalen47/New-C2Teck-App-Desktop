import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import BuscadoresReportesBusquedaPage from '@/modules/Buscadores/pages/reportes-busqueda'

export const Route = createFileRoute('/dashboard/buscadores/reportes-busqueda')({
  component: () => (
    <DashboardLayout>
      <BuscadoresReportesBusquedaPage />
    </DashboardLayout>
  ),
})
