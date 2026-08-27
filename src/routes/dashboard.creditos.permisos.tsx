import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import CreditosPermisosPage from '@/modules/Creditos/pages/permisos'

export const Route = createFileRoute('/dashboard/creditos/permisos')({
  component: () => (
    <DashboardLayout>
      <CreditosPermisosPage />
    </DashboardLayout>
  ),
})
