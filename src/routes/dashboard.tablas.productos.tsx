import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import TablasProductosPage from '@/modules/Tablas/pages/productos'

export const Route = createFileRoute('/dashboard/tablas/productos')({
  component: () => (
    <DashboardLayout>
      <TablasProductosPage />
    </DashboardLayout>
  ),
})
