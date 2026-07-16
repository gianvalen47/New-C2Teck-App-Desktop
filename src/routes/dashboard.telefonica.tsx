import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import Telefonica from '@/modules/Telefonia/pages'

export const Route = createFileRoute('/dashboard/telefonica')({
  component: () => (
    <DashboardLayout>
      <Telefonica />
    </DashboardLayout>
  ),
})
