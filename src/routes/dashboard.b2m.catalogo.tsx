import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import B2mCatalogoPage from '@/modules/B2M/pages/catalogo'

export const Route = createFileRoute('/dashboard/b2m/catalogo')({
  component: () => (
    <DashboardLayout>
      <B2mCatalogoPage />
    </DashboardLayout>
  ),
})
