import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Rondas from '@/modules/Rondas/pages'

export const Route = createFileRoute('/dashboard/rondas')({
  component: () => (
    <DashboardLayout>
      <Rondas />
    </DashboardLayout>
  ),
})
