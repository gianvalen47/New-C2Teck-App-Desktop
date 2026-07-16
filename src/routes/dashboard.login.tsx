import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Login from '@/modules/Login/pages'

export const Route = createFileRoute('/dashboard/login')({
  component: () => (
    <DashboardLayout>
      <Login />
    </DashboardLayout>
  ),
})
