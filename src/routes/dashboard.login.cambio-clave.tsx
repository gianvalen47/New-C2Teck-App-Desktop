import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import LoginCambioClavePage from '@/modules/Login/pages/cambio-clave'

export const Route = createFileRoute('/dashboard/login/cambio-clave')({
  component: () => (
    <DashboardLayout>
      <LoginCambioClavePage />
    </DashboardLayout>
  ),
})
