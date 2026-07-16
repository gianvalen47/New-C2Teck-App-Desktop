import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Importaciones from '@/modules/Importaciones/pages'

export const Route = createFileRoute('/dashboard/importaciones')({
  component: () => (
    <DashboardLayout>
      <Importaciones />
    </DashboardLayout>
  ),
})
