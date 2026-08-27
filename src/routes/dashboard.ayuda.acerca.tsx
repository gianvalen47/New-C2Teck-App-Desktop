import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import AyudaAcercaPage from '@/modules/Ayuda/pages/acerca'

export const Route = createFileRoute('/dashboard/ayuda/acerca')({
  component: () => (
    <DashboardLayout>
      <AyudaAcercaPage />
    </DashboardLayout>
  ),
})
