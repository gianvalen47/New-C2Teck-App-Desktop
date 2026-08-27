import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import TablasProveedoresPage from '@/modules/Tablas/pages/proveedores'

export const Route = createFileRoute('/dashboard/tablas/proveedores')({
  component: () => (
    <DashboardLayout>
      <TablasProveedoresPage />
    </DashboardLayout>
  ),
})
