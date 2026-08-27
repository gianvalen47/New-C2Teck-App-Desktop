import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import AyudaSoportePage from '@/modules/Ayuda/pages/soporte'

export const Route = createFileRoute('/dashboard/ayuda/soporte')({
  component: () => (
    <DashboardLayout>
      <AyudaSoportePage />
    </DashboardLayout>
  ),
})
