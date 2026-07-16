import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import ActivosFijos from '@/modules/ActivosFijos/pages'

export const Route = createFileRoute('/dashboard/activos-fijos')({
  component: () => (
    <DashboardLayout>
      <ActivosFijos />
    </DashboardLayout>
  ),
})
