import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import LoginPerfilPage from '@/modules/Login/pages/perfil'

export const Route = createFileRoute('/dashboard/login/perfil')({
  component: () => (
    <DashboardLayout>
      <LoginPerfilPage />
    </DashboardLayout>
  ),
})
