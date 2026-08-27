import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import RondasReportesPage from '@/modules/Rondas/pages/reportes'

export const Route = createFileRoute('/dashboard/rondas/reportes')({
  component: () => (
    <DashboardLayout>
      <RondasReportesPage />
    </DashboardLayout>
  ),
})
