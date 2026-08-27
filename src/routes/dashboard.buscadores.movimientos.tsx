import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import BuscadoresMovimientosPage from '@/modules/Buscadores/pages/movimientos'

export const Route = createFileRoute('/dashboard/buscadores/movimientos')({
  component: () => (
    <DashboardLayout>
      <BuscadoresMovimientosPage />
    </DashboardLayout>
  ),
})
