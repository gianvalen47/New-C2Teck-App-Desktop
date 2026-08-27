import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import TablasMarcasPage from '@/modules/Tablas/pages/marcas'

export const Route = createFileRoute('/dashboard/tablas/marcas')({
  component: () => (
    <DashboardLayout>
      <TablasMarcasPage />
    </DashboardLayout>
  ),
})
