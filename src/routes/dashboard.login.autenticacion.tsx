import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import LoginAutenticacionPage from '@/modules/Login/pages/autenticacion'

export const Route = createFileRoute('/dashboard/login/autenticacion')({
  component: () => (
    <DashboardLayout>
      <LoginAutenticacionPage />
    </DashboardLayout>
  ),
})
