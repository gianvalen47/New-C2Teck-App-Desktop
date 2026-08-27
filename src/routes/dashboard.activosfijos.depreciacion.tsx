import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ActivosfijosDepreciacionPage from '@/modules/ActivosFijos/pages/depreciacion'

export const Route = createFileRoute('/dashboard/activosfijos/depreciacion')({
  component: () => (
    <DashboardLayout>
      <ActivosfijosDepreciacionPage />
    </DashboardLayout>
  ),
})
