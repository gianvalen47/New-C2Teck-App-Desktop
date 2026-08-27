import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import BuscadoresProductosPage from '@/modules/Buscadores/pages/productos'

export const Route = createFileRoute('/dashboard/buscadores/productos')({
  component: () => (
    <DashboardLayout>
      <BuscadoresProductosPage />
    </DashboardLayout>
  ),
})
