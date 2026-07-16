import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Creditos from '@/modules/Creditos/pages'

export const Route = createFileRoute('/dashboard/creditos')({
  component: () => (
    <DashboardLayout>
      <Creditos />
    </DashboardLayout>
  ),
})
