import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import RondasRuteadoresPage from '@/modules/Rondas/pages/ruteadores'

export const Route = createFileRoute('/dashboard/rondas/ruteadores')({
  component: () => (
    <DashboardLayout>
      <RondasRuteadoresPage />
    </DashboardLayout>
  ),
})
