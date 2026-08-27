import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import GerenciaDashboardPage from '@/modules/Gerencia/pages/dashboard'

export const Route = createFileRoute('/dashboard/gerencia/dashboard')({
  component: () => (
    <DashboardLayout>
      <GerenciaDashboardPage />
    </DashboardLayout>
  ),
})
