import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import TablasParametrosPage from '@/modules/Tablas/pages/parametros'

export const Route = createFileRoute('/dashboard/tablas/parametros')({
  component: () => (
    <DashboardLayout>
      <TablasParametrosPage />
    </DashboardLayout>
  ),
})
