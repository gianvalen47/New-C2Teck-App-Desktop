import { createFileRoute } from '@tanstack/react-router'
import { DashboardLayout } from '@/components/layout/DashboardLayout'
import AyudaContactoPage from '@/modules/Ayuda/pages/contacto'

export const Route = createFileRoute('/dashboard/ayuda/contacto')({
  component: () => (
    <DashboardLayout>
      <AyudaContactoPage />
    </DashboardLayout>
  ),
})
