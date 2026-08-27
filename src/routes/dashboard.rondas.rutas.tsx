import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import RondasRutasPage from '@/modules/Rondas/pages/rutas'

export const Route = createFileRoute('/dashboard/rondas/rutas')({
  component: () => (
    <DashboardLayout>
      <RondasRutasPage />
    </DashboardLayout>
  ),
})
