import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import RondasConsultasPage from '@/modules/Rondas/pages/consultas'

export const Route = createFileRoute('/dashboard/rondas/consultas')({
  component: () => (
    <DashboardLayout>
      <RondasConsultasPage />
    </DashboardLayout>
  ),
})
