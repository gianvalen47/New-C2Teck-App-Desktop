import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import AyudaManualPage from '@/modules/Ayuda/pages/manual'

export const Route = createFileRoute('/dashboard/ayuda/manual')({
  component: () => (
    <DashboardLayout>
      <AyudaManualPage />
    </DashboardLayout>
  ),
})
