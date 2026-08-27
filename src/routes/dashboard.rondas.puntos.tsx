import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import RondasPuntosPage from '@/modules/Rondas/pages/puntos'

export const Route = createFileRoute('/dashboard/rondas/puntos')({
  component: () => (
    <DashboardLayout>
      <RondasPuntosPage />
    </DashboardLayout>
  ),
})
