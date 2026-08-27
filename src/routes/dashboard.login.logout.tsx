import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import LoginLogoutPage from '@/modules/Login/pages/logout'

export const Route = createFileRoute('/dashboard/login/logout')({
  component: () => (
    <DashboardLayout>
      <LoginLogoutPage />
    </DashboardLayout>
  ),
})
