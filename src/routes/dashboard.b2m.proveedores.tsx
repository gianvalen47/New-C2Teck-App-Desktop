import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import B2mProveedoresPage from '@/modules/B2M/pages/proveedores'

export const Route = createFileRoute('/dashboard/b2m/proveedores')({
  component: () => (
    <DashboardLayout>
      <B2mProveedoresPage />
    </DashboardLayout>
  ),
})
